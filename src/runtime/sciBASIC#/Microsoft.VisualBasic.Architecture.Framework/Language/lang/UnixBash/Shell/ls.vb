﻿#Region "Microsoft.VisualBasic::fd17b835dc6de51b3216291c40e1f4b3, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Language\lang\UnixBash\Shell\ls.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.

#End Region

Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.Language.UnixBash.FileSystem
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Language.UnixBash

    Public Class Search : Implements ICloneable

        ''' <summary>
        ''' The search options
        ''' </summary>
        Dim __opts As New Dictionary(Of SearchOpt.Options, SearchOpt)

        Public Overrides Function ToString() As String
            Return __opts.GetJson
        End Function

        Public Function Clone() As Object Implements ICloneable.Clone
            Return New Search With {
                .__opts = New Dictionary(Of SearchOpt.Options, SearchOpt)(__opts)
            }
        End Function

        ''' <summary>
        ''' Add a search options
        ''' </summary>
        ''' <param name="ls"></param>
        ''' <param name="l"></param>
        ''' <returns></returns>
        Public Shared Operator -(ls As Search, l As SearchOpt) As Search
            If l.opt <> SearchOpt.Options.None Then
                Dim clone As Search = DirectCast(ls.Clone, Search)
                Call clone.__opts.Add(l.opt, l)
                Return clone
            Else
                Return ls
            End If
        End Operator

        Public Shared Operator -(ls As Search, wildcards$()) As Search
            Return ls - ShellSyntax.wildcards(wildcards$)
        End Operator

        Public Shared Operator -(ls As Search, wildcards$) As Search
            Return ls - wildcards.Split(","c)
        End Operator

        Public ReadOnly Property SearchType As FileIO.SearchOption
            Get
                Dim opt As FileIO.SearchOption = FileIO.SearchOption.SearchTopLevelOnly
                If __opts.ContainsKey(SearchOpt.Options.Recursive) Then
                    Return FileIO.SearchOption.SearchAllSubDirectories
                Else
                    Return opt
                End If
            End Get
        End Property

        Public ReadOnly Property wildcards As String()
            Get
                If Not __opts.ContainsKey(SearchOpt.Options.Ext) Then
                    Return Nothing
                Else
                    Return __opts(SearchOpt.Options.Ext).wildcards.ToArray
                End If
            End Get
        End Property

        ''' <summary>
        ''' Search the files in the specific directory
        ''' </summary>
        ''' <param name="ls"></param>
        ''' <param name="DIR"></param>
        ''' <returns></returns>
        Public Shared Operator <<(ls As Search, DIR As Integer) As IEnumerable(Of String)
            Dim url As String = __getHandle(DIR).FileName
            Return ls < url
        End Operator

        ''' <summary>
        ''' Search the files in the specific directory
        ''' </summary>
        ''' <param name="ls"></param>
        ''' <param name="DIR"></param>
        ''' <returns></returns>
        Public Shared Operator <(ls As Search, DIR As String) As IEnumerable(Of String)
            Return ls <= DIR
        End Operator

        ''' <summary>
        ''' Search the files in the specific directory
        ''' </summary>
        ''' <param name="ls"></param>
        ''' <param name="DIR"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator <=(ls As Search, DIR As String) As IEnumerable(Of String)
            Dim l As Boolean = ls.__opts.ContainsKey(SearchOpt.Options.LongName)
            'Dim wc As String() =
            '    ls.wildcards.ToArray(Function(x) x.Replace(".", "\."))
            'For i As Integer = 0 To wc.Length - 1
            '    If wc(i).Last <> "*"c Then
            '        wc(i) = wc(i) & "$"
            '    End If
            '    wc(i) = wc(i).Replace("*", ".+")
            'Next
            Dim wc$() = ls.wildcards
            Dim isMatch As Func(Of String, Boolean) =
                AddressOf New wildcardsCompatible With {
                    .regexp = If(wc.IsNullOrEmpty, {"*"}, wc)
                }.IsMatch
            Dim list As IEnumerable(Of String)

            With ls
                If .__opts.ContainsKey(SearchOpt.Options.Directory) Then
                    list = DIR.ListDirectory(.SearchType)
                Else
                    list = DIR.ReadDirectory(.SearchType)
                End If

                If .__opts.ContainsKey(SearchOpt.Options.Directory) Then
                    If l Then
                        Return list.Where(isMatch)
                    Else
                        Return list.Where(isMatch) _
                            .Select(Function(s) s.BaseName)
                    End If
                Else
                    If l Then
                        Return list.Where(isMatch)
                    Else
                        Return From path As String
                               In list
                               Where isMatch(path)
                               Let name As String = path.Replace("\", "/").Split("/"c).Last
                               Select name
                    End If
                End If
            End With
        End Operator

        Public Shared Operator >(ls As Search, DIR As String) As IEnumerable(Of String)
            Throw New NotSupportedException
        End Operator

        Public Shared Operator >=(ls As Search, DIR As String) As IEnumerable(Of String)
            Throw New NotSupportedException
        End Operator
    End Class

    ''' <summary>
    ''' Using regular expression to find a match on the file name.
    ''' </summary>
    Public Structure wildcardsCompatible

        Dim regexp As String()
        ''' <summary>
        ''' Using the regexp engine instead of the wildcard match engine?
        ''' </summary>
        Dim usingRegexp As Boolean

        ''' <summary>
        ''' Windows系统上面文件路径不区分大小写，但是Linux、Mac系统却区分大小写
        ''' 所以使用这个来保持对Windows文件系统的兼容性
        ''' </summary>
        Shared ReadOnly opt As RegexOptions =
            If(App.Platform = PlatformID.MacOSX OrElse
               App.Platform = PlatformID.Unix,
               RegexOptions.Singleline, RegexICSng)
        Shared ReadOnly pathIgnoreCase As Boolean = App.IsMicrosoftPlatform

        ''' <summary>
        ''' Linux/Mac系统不支持Windows系统的通配符，所以在这里是用正则表达式来保持代码的兼容性
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function IsMatch(path As String) As Boolean
            If regexp.IsNullOrEmpty Then
                ' 匹配的规则是空的，则默认是允许所有的路径
                Return True
            End If

            Dim name As String = path.Replace("\", "/").Split("/"c).Last

            If usingRegexp Then
                For Each r As String In regexp
                    If Regex.Match(name, r, opt).Success Then
                        Return True
                    End If
                Next
            Else
                For Each r As String In regexp
                    If WildcardsExtension.WildcardMatch(r, name, pathIgnoreCase) Then
                        Return True
                    End If
                Next
            End If

            Return False
        End Function
    End Structure

    Public Structure SearchOpt

        Dim opt As Options
        Dim value As String
        Dim wildcards As List(Of String)

        Sub New(opt As Options, s As String)
            Me.opt = opt
            Me.value = s
            Me.wildcards = New List(Of String)
        End Sub

        Sub New(opt As Options)
            Call Me.New(opt, "")
        End Sub

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function

        Public Enum Options
            None
            Ext
            LongName
            ''' <summary>
            ''' List directories, not files listing.
            ''' </summary>
            Directory
            ''' <summary>
            ''' 递归搜索所有的文件夹
            ''' </summary>
            Recursive
        End Enum
    End Structure
End Namespace
