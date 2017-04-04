﻿#Region "Microsoft.VisualBasic::cd1371de55c63cab009b7db9052c7144, ..\core\Bio.Assembly\Assembly\KEGG\DBGET\LinkDB\Module.vb"

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
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Text.HtmlParser
Imports SMRUCC.genomics.Assembly.KEGG.DBGET.bGetObject

Namespace Assembly.KEGG.DBGET.LinkDB

    ''' <summary>
    ''' Downloader for <see cref="[Module]"/>
    ''' </summary>
    Public Module Modules

        Public Const URL_KEGG_MODULES_ENTRY_PAGE As String = "http://www.genome.jp/dbget-bin/get_linkdb?-t+module+genome:{0}"
        Public Const SEPERATOR As String = "<pre>ID                   Definition"

        Public Function Download(speciesId As String) As [Module]()
            Dim pageContent As String = Strings.Split(String.Format(URL_KEGG_MODULES_ENTRY_PAGE, speciesId).GET, SEPERATOR).Last
            Dim Entries As String() = Regex.Matches(pageContent, "<a href="".+?"">", RegexOptions.Singleline + RegexOptions.IgnoreCase).ToArray
            Dim Modules As [Module]() = New [Module](Entries.Count - 1) {}

            For i As Integer = 0 To Modules.Length - 1
                Dim url = "http://www.genome.jp" & Entries(i).href
                Modules(i) = [Module].Download(url)
            Next

            Return Modules
        End Function

        Public Function Download(speciesId As String, Optional EXPORT As String = Nothing) As [Module]()
            Dim pageContent As String = Strings.Split(String.Format(URL_KEGG_MODULES_ENTRY_PAGE, speciesId).GET, SEPERATOR).Last
            Dim Entries As String() = Regex.Matches(pageContent, "<a href="".+?"">.+?</a>.+?$", RegexOptions.Multiline + RegexOptions.IgnoreCase).ToArray
            Dim Genes As KeyValuePairObject(Of KeyValuePair(Of String, String), KeyValuePair())() =
                New KeyValuePairObject(Of KeyValuePair(Of String, String), KeyValuePair())(Entries.Length - 2) {}
            Dim Downloader As New System.Net.WebClient()

            Entries = Entries.Take(Entries.Length - 1).ToArray

            If String.IsNullOrEmpty(EXPORT) Then
                EXPORT = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "/Modules/"
            End If

            Call EXPORT.MkDIR

            Dim ModuleList As New List(Of [Module])

            For i As Integer = 0 To Genes.Length - 1
                Dim Item As String = Entries(i)
                Dim Entry As String = Regex.Match(Item, ">.+?</a>").Value
                Entry = Mid(Entry, 2, Len(Entry) - 5)
                Dim Description As String = Strings.Split(Item, "</a>").Last.Trim
                Dim Url As String = String.Format(KEGGgenes.URL_MODULE_GENES, Entry)
                Dim ImageUrl = String.Format("http://www.genome.jp/tmp/pathway_thumbnail/{0}.png", Entry)

                Try
                    Dim ObjUrl = "http://www.genome.jp" & Item.href
                    Dim SaveFile As String = String.Format("{0}/Webpages/{1}.html", EXPORT, Entry)

                    Call ObjUrl.GET.SaveTo(SaveFile)
                    Call ModuleList.Add([Module].Download(SaveFile))
                    Call ModuleList.Last.GetXml.SaveTo(String.Format("{0}/{1}.xml", EXPORT, Entry))
                    Call Downloader.DownloadFile(ImageUrl, String.Format("{0}/{1}.png", EXPORT, Entry))
                Catch ex As Exception

                End Try

                Genes(i) = New KeyValuePairObject(Of KeyValuePair(Of String, String), KeyValuePair()) With {
                    .Key = New KeyValuePair(Of String, String)(Entry, Description),
                    .Value = KEGGgenes.Download(Url).ToArray
                }
            Next

            Return __createBriefModuleData(Genes)
        End Function

        Private Function __createBriefModuleData(Items As KeyValuePairObject(Of KeyValuePair(Of String, String), KeyValuePair())()) As [Module]()
            Dim LQuery = LinqAPI.Exec(Of [Module]) <=
                From x
                In Items
                Select New [Module] With {
                    .EntryId = x.Key.Key,
                    .Description = x.Key.Value,
                    .PathwayGenes = x.Value
                }

            Return LQuery
        End Function
    End Module
End Namespace
