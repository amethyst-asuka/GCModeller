﻿#Region "Microsoft.VisualBasic::26e4effd468b83fbd29f4ca8c9eb2bc3, ..\core\Bio.Assembly\Assembly\KEGG\DBGET\Objects\Disease\DownloadAPI.vb"

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
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Algorithm.base
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Text.HtmlParser
Imports SMRUCC.genomics.Assembly.KEGG.WebServices
Imports SMRUCC.genomics.Assembly.KEGG.WebServices.InternalWebFormParsers

Namespace Assembly.KEGG.DBGET.bGetObject

    ''' <summary>
    ''' 从KEGG之上下载疾病的信息
    ''' </summary>
    Public Module DownloadDiseases

        ''' <summary>
        ''' 解析KEGG上面的疾病模型数据的网页文本
        ''' </summary>
        ''' <param name="html$"></param>
        ''' <returns></returns>
        <Extension> Public Function Parse(html As WebForm) As Disease
            Dim dis As New Disease With {
                .Entry = html.GetText("Entry").Split.First,
                .Name = html.GetText("Name"),
                .Description = html.GetText("Description"),
                .Category = html.GetText("Category"),
                .Pathway = PathwayWebParser.__parseHTML_ModuleList(html("Pathway").FirstOrDefault, LIST_TYPES.Pathway),
                .Comment = html.GetText("Comment"),
                .References = html.References,
                .Markers = html("Marker").FirstOrDefault _
                    .DivInternals _
                    .Select(AddressOf HtmlLines) _
                    .IteratesALL _
                    .Select(Function(s) s.StripHTMLTags.StripBlank) _
                    .Where(Function(s) Not s.StringEmpty) _
                    .ToArray,
                .Genes = html("Gene").FirstOrDefault.MarkerList,
                .Drug = html("Drug").FirstOrDefault.__pairList(
                    Function(s$)
                        Dim id$ = Regex.Match(s, "\[.+?\]", RegexICSng) _
                            .Value _
                            .GetStackValue("[", "]")
                        Return New KeyValuePair With {
                            .Key = s,
                            .Value = id
                        }
                    End Function),
                .OtherDBs = html("Other DBs").FirstOrDefault.__otherDBs,
                .Carcinogen = html(NameOf(Disease.Carcinogen)) _
                    .FirstOrDefault _
                    .StripHTMLTags(stripBlank:=True)
            }

            Return dis
        End Function

        <Extension>
        Friend Function __otherDBs(html$) As KeyValuePair()
            Dim lines$() = html _
                .DivInternals _
                .ToArray(Function(s) s.StripHTMLTags(stripBlank:=True))
            Dim slides = lines.SlideWindows(2, offset:=2)
            Dim out As New List(Of KeyValuePair)

            For Each s As SlideWindow(Of String) In slides
                out += New KeyValuePair With {
                    .Key = s(Scan0).Trim(":"c),
                    .Value = s(1)
                }
            Next

            Return out
        End Function

        <Extension>
        Friend Function __pairList(html$, parser As Func(Of String, KeyValuePair)) As KeyValuePair()
            Dim lines$() = html.DivInternals _
                .FirstOrDefault _
                .HtmlLines _
                .Select(Function(s) s.StripHTMLTags(stripBlank:=True)) _
                .Where(Function(s) Not s.StringEmpty) _
                .ToArray
            Dim out As KeyValuePair() = lines.ToArray(parser)
            Return out
        End Function

        <Extension> Private Function MarkerList(html$) As TripleKeyValuesPair()
            Dim list As New List(Of TripleKeyValuesPair)

            html = html.DivInternals.FirstOrDefault

            Dim lines$() = html _
                .HtmlLines _
                .Select(Function(s) s.StripHTMLTags(stripBlank:=True)) _
                .Where(Function(s) Not s.StringEmpty) _
                .ToArray

            For Each line$ In lines
                Dim refs$() = Regex _
                    .Matches(line, "\[.+?\]", RegexICSng) _
                    .ToArray

                list += New TripleKeyValuesPair With {
                    .Key = line,
                    .Value1 = refs(0),
                    .Value2 = refs(1)
                }
            Next

            Return list
        End Function

        ''' <summary>
        ''' 使用疾病编号下载疾病数据模型
        ''' </summary>
        ''' <param name="ID$"></param>
        ''' <returns></returns>
        <Extension>
        Public Function Download(ID$) As Disease
            Dim url$ = $"http://www.kegg.jp/dbget-bin/www_bget?ds:{ID}"
            Return DownloadURL(url)
        End Function

        Public Function DownloadURL(url$) As Disease
            Return New WebForm(url).Parse
        End Function

        <Extension> Public Function ParseDrugData(form As WebForm) As Drug
            Dim drug As New Drug With {
                .Entry = form.GetText("Entry").Split.First,
                .Name = form.GetText("Name"),
                .Comment = form.GetText("Comment"),
                .Metabolism = form.GetText("Metabolism"),
                .Remark = form.GetText("Remark"),
                .Target = form("Target").FirstOrDefault.MarkerList,
                .Members = form("Member").FirstOrDefault.__drugMembers
            }

            Return drug
        End Function

        <Extension>
        Private Function __drugMembers(html$) As KeyValuePair()
            Dim t = html.GetTablesHTML
            Dim out As New List(Of KeyValuePair)
            Dim rows = t.Select(Function(s) s.GetRowsHTML).IteratesALL.ToArray

            For Each row$ In rows
                Dim cols = row.GetColumnsHTML
                If cols.Length >= 2 Then
                    out += New KeyValuePair With {
                        .Key = cols(Scan0).StripHTMLTags.StripBlank,
                        .Value = cols(1).StripHTMLTags.StripBlank
                    }
                End If
            Next

            Return out
        End Function

        Public Function DownloadDrug(url$) As Drug
            Return New WebForm(url).ParseDrugData
        End Function
    End Module
End Namespace
