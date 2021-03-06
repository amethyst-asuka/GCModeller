﻿#Region "Microsoft.VisualBasic::70d8485b07ca919c8204ef8fbce6d8b6, ..\core\Bio.Assembly\SequenceModel\FASTA\Reflection\Attributes.vb"

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

Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData

Namespace SequenceModel.FASTA.Reflection

    ''' <summary>
    ''' 自定義屬性用於指示哪一個屬性值為目標對象的序列數據
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field, AllowMultiple:=False, Inherited:=True)>
    Public Class FastaSequenceEntry : Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field, AllowMultiple:=False, Inherited:=True)>
    Public Class FastaAttributeItem : Inherits Attribute

        Public Property Index As Integer
        Public Property Format As String
        ''' <summary>
        ''' 當Format屬性值不為空的時候，本參數失效
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Precursor As String

        Sub New(Index As Integer, Optional Format As String = "")
            Me.Index = Index
            Me.Format = Format
        End Sub

        Public Shared ReadOnly FsaAttributeItem As System.Type = GetType(FastaAttributeItem)
    End Class

    ''' <summary>
    ''' 用於類型定義上的FASTA序列對象的標題格式
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Struct, AllowMultiple:=False, Inherited:=True)>
    Public Class FastaObject : Inherits Attribute

        Public Property Format As String

        Sub New(TitleFormat As String)
            Format = TitleFormat
        End Sub

        Public Overrides Function ToString() As String
            Return Format
        End Function

        Public Shared ReadOnly FsaTitle As System.Type = GetType(FastaObject)
    End Class
End Namespace
