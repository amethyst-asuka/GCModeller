﻿#Region "Microsoft.VisualBasic::7d5dd882e311f3cba63b174cdc1f9514, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Text\Parser\HtmlParser\HtmlStrips.vb"

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

Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Scripting.MetaData

Namespace Text.HtmlParser

    Public Module HtmlStrips

        ''' <summary>
        ''' 从html文本之中解析出所有的链接
        ''' </summary>
        ''' <param name="html$"></param>
        ''' <returns></returns>
        <Extension> Public Function GetLinks(html$) As String()
            If String.IsNullOrEmpty(html) Then
                Return New String() {}
            Else
                Dim links$() = Regex _
                    .Matches(html, HtmlLink, RegexICSng) _
                    .ToArray(AddressOf HtmlStrips.GetValue)
                Return links
            End If
        End Function

        Public Const HtmlLink As String = "<a href="".+?"">.+?</a>"
        Public Const HtmlPageTitle As String = "<title>.+</title>"

        ''' <summary>
        ''' Parsing the title text from the html inputs.
        ''' </summary>
        ''' <param name="html"></param>
        ''' <returns></returns>
        <Extension> Public Function HTMLTitle(html As String) As String
            Dim title As String =
                Regex.Match(html, HtmlPageTitle, RegexOptions.IgnoreCase).Value

            If String.IsNullOrEmpty(title) Then
                title = "NULL_TITLE"
            Else
                title = title.GetValue
            End If

            Return title
        End Function

        ''' <summary>
        ''' Removes the html tags from the text string.
        ''' </summary>
        ''' <param name="s"></param>
        ''' <returns></returns>
        <ExportAPI("Html.Tag.Trim"), Extension> Public Function StripHTMLTags(s$, Optional stripBlank As Boolean = False) As String
            If String.IsNullOrEmpty(s) Then
                Return ""
            End If

            s = Regex.Replace(s, "<[^>]+>", "")
            s = Regex.Replace(s, "</[^>]+>", "")

            If stripBlank Then
                s = s.StripBlank
            End If

            Return s
        End Function

        Const HTML_TAG As String = "</?.+?(\s+.+?="".+?"")*>"

        ''' <summary>
        ''' Gets the link text in the html fragement text.
        ''' </summary>
        ''' <param name="html">A string that contains the url string pattern like: href="url_text"</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        '''
        <ExportAPI("Html.Href")>
        <Extension> Public Function href(<Parameter("HTML", "A string that contains the url string pattern like: href=""url_text""")> html$) As String

            If String.IsNullOrEmpty(html) Then
                Return ""
            End If

            Dim url As String = Regex.Match(html, "href=[""'].+?[""']", RegexOptions.IgnoreCase).Value

            If String.IsNullOrEmpty(url) Then
                Return ""
            Else
                url = Mid(url, 6)
                url = Mid(url, 2, Len(url) - 2)
                Return url
            End If
        End Function

        Public Const IMAGE_SOURCE As String = "<img.+?src=.+?>"

        ''' <summary>
        ''' Parsing image source url from the img html tag.
        ''' </summary>
        ''' <param name="img"></param>
        ''' <returns></returns>
        <Extension> Public Function ImageSource(img As String) As String
            If String.IsNullOrEmpty(img) Then
                Return ""
            Else
                img = Regex.Match(img, "src="".+?""", RegexOptions.IgnoreCase).Value
            End If
            If String.IsNullOrEmpty(img) Then
                Return ""
            Else
                img = Mid(img, 5)
                img = Mid(img, 2, Len(img) - 2)
                Return img
            End If
        End Function

        ''' <summary>
        ''' 有些时候后面可能会存在多余的vbCrLf，则使用这个函数去除
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <Extension> Public Function TrimResponseTail(value As String) As String
            If String.IsNullOrEmpty(value) Then
                Return ""
            End If

            Dim l As Integer = Len(value)
            Dim i As Integer = value.LastIndexOf(vbCrLf)
            If i = l - 2 Then
                Return Mid(value, 1, l - 2)
            Else
                Return value
            End If
        End Function

        Private ReadOnly vbCrLfLen As Integer = Len(vbCrLf)

        ''' <summary>
        ''' 获取两个尖括号之间的内容
        ''' </summary>
        ''' <param name="html"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        '''
        <ExportAPI("Html.GetValue", Info:="Gets the string value between two wrapper character.")>
        <Extension> Public Function GetValue(html As String) As String
            Return html.GetStackValue(">", "<")
        End Function

        ' <br><br/>

        Const LineFeed$ = "(<br>)|(<br\s*/>)"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="html$"></param>
        ''' <returns></returns>
        <Extension>
        Public Function HtmlLines(html$) As String()
            If html.StringEmpty Then
                Return {}
            Else
                Return Regex.Split(html, LineFeed, RegexICSng)
            End If
        End Function

        ' <area shape=rect	coords=40,45,168,70	href="/dbget-bin/www_bget?hsa05034"	title="hsa05034: Alcoholism" onmouseover="popupTimer(&quot;hsa05034&quot;, &quot;hsa05034: Alcoholism&quot;, &quot;#ffffff&quot;)" onmouseout="hideMapTn()" />

        Const attributeParse$ = "\S+?=.+?"

        <Extension>
        Private Function stripTag(ByRef tag$) As String
            tag = tag.Trim("<"c).Trim(">"c).Trim("/"c)
            Return tag
        End Function

        ''' <summary>
        ''' 获取一个html标签之中的所有的attribute属性数据
        ''' </summary>
        ''' <param name="tag$"></param>
        ''' <returns></returns>
        <Extension>
        Public Iterator Function TagAttributes(tag$) As IEnumerable(Of NamedValue(Of String))
            Dim list = Regex.Matches(tag.stripTag, attributeParse, RegexICSng).ToArray
            Dim p%
            Dim s$
            Dim name$

            For i As Integer = 0 To list.Length - 1
                name = list(i)
                p = InStr(tag, name)
                s = Mid(tag, p)
                s = Regex.Split(s, "\S+=").ElementAtOrDefault(1) ' value

                name = name.Split("="c).First

                If Not s Is Nothing Then
                    s = s.Trim(" "c, ASCII.TAB, ASCII.Quot)
                End If

                Yield New NamedValue(Of String) With {
                    .Name = name,
                    .Value = s
                }
            Next
        End Function
    End Module
End Namespace
