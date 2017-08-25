﻿#Region "Microsoft.VisualBasic::4c3e61b23bc006363e95cad0ec1d6bc8, ..\GCModeller\CLI_tools\MEME\TomReport.vb"

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

Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Text
Imports SMRUCC.genomics.Interops.NBCR.MEME_Suite
Imports SMRUCC.genomics.Interops.NBCR.MEME_Suite.Analysis.Similarity.TOMQuery
Imports SMRUCC.genomics.GCModeller.Workbench
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Imaging

<Package("Tom.Report", Publisher:="amethyst.asuka@gcmodeller.org")>
Public Module TomReport

    Const A = 0, T = 1, G = 2, C = 3

    <ExportAPI("Write.HTML")>
    Public Function WriteHTML(query As Output, outDIR As String) As Boolean
        Dim innerHTML As StringBuilder = New StringBuilder(1024)
        Dim queryLogo As Image = SequenceLogoAPI.DrawLogo(query.Query)
        Dim subjectLogo As Image = SequenceLogoAPI.DrawLogo(query.Subject)

        Call query.SaveAsXml(outDIR & "/TomQuery.Xml")
        Call queryLogo.CorpBlank(20).SaveAs(outDIR & "/Query.png", ImageFormats.Png)
        Call subjectLogo.CorpBlank(20).SaveAs(outDIR & "/Subject.png", ImageFormats.Png)

        Call innerHTML.AppendLine(ReportBuilder.MEMESWTomQuery)
        Call innerHTML.AppendLine("<table class=""API"">")
        Call innerHTML.AppendLine($"<tr>
<td width=""350px""><p>
<strong>Query Name</strong><br />
{query.Query.Uid}<br />
<strong>{query.Query.Motif}</strong><br />
Width: {query.Query.PWM.Length}<br />
E-Value: {query.Query.Evalue}
</p></td>
<td><img src=""Query.png""></td></tr>")
        Call innerHTML.AppendLine($"<tr>
<td><p>
<strong>Subject Name</strong><br />
{query.Subject.Uid}<br />
<strong>{query.Subject.Motif}</strong><br />
Width: {query.Subject.PWM.Length}<br />
E-Value: {query.Subject.Evalue}
</p>
</td>
<td><img src=""Subject.png""></td></tr>")
        Call innerHTML.AppendLine("</table><hr>")
        Call innerHTML.AppendLine("Parameters:<br />")
        Call innerHTML.AppendLine({query.Parameters}.ToHTMLTable)
        Call innerHTML.AppendLine(If(query.HSP.IsNullOrEmpty, "No Hits", query.HSP.Length & " Hits HSP:") & "<br />")

        For Each hsp In query.HSP
            Dim link As String = $"<li><a href=""#{hsp.ToString}"">{hsp.ToString}</a></li>"
            Call innerHTML.AppendLine(link)
        Next

        Call innerHTML.AppendLine($"<table>
<tr><td>Coverage</td><td>{Math.Round(query.Coverage * 100, 2)}%</td></tr>
<tr><td>Lev%</td><td>{Math.Round(query.lev * 100, 2)}%</td></tr>
<tr><td>SW-TOM.Similarity</td><td>{Math.Round(query.Similarity * 100, 2)}%</td></tr>
</table>")

        Call innerHTML.AppendLine("<br />")
        Call innerHTML.AppendLine($"Download Result: <a href=""TomQuery.zip""><strong>{query.Query.Uid} hits {query.Subject.Uid}</strong></a><br />")
        Call innerHTML.AppendLine($"View Alignment Raw: <a href=""TomQuery.Xml""><strong>Smith-Waterman & Levenshtein Alignment</strong></a>")
        Call innerHTML.AppendLine("<hr>")
        Call innerHTML.AppendLine("<h6>Query sites:</h6>")
        Call innerHTML.AppendLine("<font size=""3"">")
        Call innerHTML.AppendLine(query.Query.Sites.ToHTMLTable("", "1440px"))
        Call innerHTML.AppendLine("</font>")
        Call innerHTML.AppendLine("<h6>Subject sites:</h6>")
        Call innerHTML.AppendLine("<font size=""3"">")
        Call innerHTML.AppendLine(query.Subject.Sites.ToHTMLTable("", "1440px"))
        Call innerHTML.AppendLine("</font>")

        Call innerHTML.AppendLine("<hr>")

        If query.HSP.IsNullOrEmpty Then
            Call innerHTML.AppendLine("<strong>*** NO_HITS_FOUND ***</strong>")
        Else
            Call __printHSP(innerHTML, query, outDIR)
        End If

        Call ReportBuilder.SaveAsHTML(innerHTML.ToString,
                                      outDIR & "/TomQuery.html",
                                      "Motif Query: " & query.Query.ToString)
        Call GZip.AddToArchive(outDIR & "/TomQuery.zip", FileIO.FileSystem.GetFiles(outDIR, FileIO.SearchOption.SearchAllSubDirectories), ArchiveAction.Replace, Overwrite.Always, IO.Compression.CompressionLevel.Fastest)

        Return True
    End Function

    <Extension> Private Function __printHSP(hsp As SW_HSP, outDIR As String) As String
        Dim innerHTML As StringBuilder = New StringBuilder(1024)
        Call innerHTML.AppendLine("<tr>")
        Call innerHTML.AppendLine($"<td>
<table>
<tr>
<td>
<h5><a name=""{hsp.ToString}"" href=""#"">{hsp.ToString}</a></h5><br />
Query: {hsp.FromQ} -> {hsp.ToQ}<br />
Subject: {hsp.FromS} -> {hsp.ToS}<br />
Smith-Waterman Score: {hsp.Score}
<hr>
</td>
</tr>
<tr>
<td>
<table>
<tr><td>
<h6>Query PWM</h6>
<table>
<tr><td>Bits</td><td>A</td><td>T</td><td>G</td><td>C</td></tr>
{hsp.Query.PWM.ToArray(Function(x) $"<tr><td>{x.Bits}</td><td>{x.PWM(A)}</td><td>{x.PWM(T)}</td><td>{x.PWM(G)}</td><td>{x.PWM(C)}</td></tr>").JoinBy(vbCrLf)}
</table>
</td>
<td>
<h6>Subject PWM</h6>
<table>
<tr><td>Bits</td><td>A</td><td>T</td><td>G</td><td>C</td></tr>
{hsp.Subject.PWM.ToArray(Function(x) $"<tr><td>{x.Bits}</td><td>{x.PWM(A)}</td><td>{x.PWM(T)}</td><td>{x.PWM(G)}</td><td>{x.PWM(C)}</td></tr>").JoinBy(vbCrLf)}
</table>
</td>
<td>")
        Dim res As Image = hsp.Visual
        Dim png As String = outDIR & "/" & hsp.ToString.Replace(" ", "") & ".png"
        Call res.SaveAs(png, ImageFormats.Png)
        Call $"  ---> {png.ToFileURL}".__DEBUG_ECHO
        Call innerHTML.AppendLine($"<td>
<table>
<tr><td><img src=""{hsp.ToString.Replace(" ", "")}.png"" width=""450px""/></td></tr>
<tr>
<td>
<pre>
Levenshtein Edits: {hsp.Alignment.DistEdits}

      Query:       {hsp.Alignment.Reference}
  Consensus:       {hsp.Alignment.Matches}
    Subject:       {hsp.Alignment.Hypotheses}

   Distance:       {hsp.Alignment.Distance}
 Similarity:       {Math.Round(hsp.Alignment.MatchSimilarity * 100, 2)}%
</pre>
</td>
</tr>
</table>")
        Call innerHTML.AppendLine("</td>
</tr>
</table>
</td>
</tr>
</table>")
        Call innerHTML.AppendLine("</td></tr>")

        Return innerHTML.ToString
    End Function

    Private Sub __printHSP(ByRef innerHTML As StringBuilder, query As Output, outDIR As String)
        Call innerHTML.AppendLine("<h3>Smith-Waterman HSP</h3><br />")
        Call innerHTML.AppendLine("<table width=""1440px"">")
        Call innerHTML.AppendLine(query.HSP.ToArray(Function(x) x.__printHSP(outDIR), Parallel:=True).JoinBy(vbCrLf))
        Call innerHTML.AppendLine("</table>")
    End Sub
End Module
