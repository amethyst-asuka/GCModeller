﻿#Region "Microsoft.VisualBasic::f22d91bf4c0bd37ad449a397a4ccc75a, ..\localblast\LocalBLAST\Web\ParserAPI.vb"

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

Imports System.IO
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.BLASTOutput.BlastPlus
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.BLASTOutput.BlastPlus.BlastX

Namespace NCBIBlastResult

    ''' <summary>
    ''' 从NCBI网站之中下载的比对结果的表格文本文件之中进行数据的解析操作
    ''' </summary>
    Public Module AlignmentTableParserAPI

        ''' <summary>
        ''' 适用于一个文件只有一个表的时候
        ''' </summary>
        ''' <param name="path">使用NCBI的web blast的结果输出表的默认格式的文件</param>
        ''' <param name="headerSplit">
        ''' 当<see cref="HitRecord.SubjectIDs"/>之中包含有多个比对结果序列的时候，是否使用分号``;``作为分隔符将表头分开？默认不分开
        ''' </param>
        ''' <returns></returns>
        Public Function LoadTable(path$, Optional headerSplit As Boolean = False) As AlignmentTable
            Dim lines$() = LinqAPI.Exec(Of String) <=
 _
                From s As String
                In path.ReadAllLines
                Where Not String.IsNullOrEmpty(s)
                Select s

            Dim header$() = LinqAPI.Exec(Of String) <=
 _
                From s As String
                In lines
                Where InStr(s, "# ") = 1
                Select s

            If lines.IsNullOrEmpty Then
                Throw New InvalidExpressionException($"Target alignment table file ""{path}"" have no data!")
            End If

            Return lines _
                .Skip(header.Length) _
                .ToArray _
                .__parseTable(path$, header, headerSplit)
        End Function

        <Extension>
        Private Function __parseTable(lines$(), path$, header$(), headerSplit As Boolean) As AlignmentTable
            Dim hits As HitRecord() = lines _
                .ToArray(AddressOf HitRecord.Mapper)
            Dim headAttrs As Dictionary(Of String, String) =
                header _
                .Skip(1) _
                .Select(Function(s) s.GetTagValue(": ")) _
                .ToDictionary(Function(x) x.Name,
                              Function(x) x.Value)

            If headerSplit Then
                hits = hits _
                    .Select(Function(x) x.SplitByHeaders) _
                    .ToVector
            End If

            Return New AlignmentTable With {
                .Hits = hits,
                .FilePath = path,
                .Program = header.First.Trim.Split.Last,
                .Query = headAttrs("# Query"),
                .Database = headAttrs("# Database"),
                .RID = headAttrs("# RID")
            }
        End Function

        ''' <summary>
        ''' 当文件之中包含有多个表的时候使用
        ''' </summary>
        ''' <param name="path$"></param>
        ''' <returns></returns>
        <Extension>
        Public Iterator Function IterateTables(path$, headerSplit As Boolean) As IEnumerable(Of AlignmentTable)
            Dim headers As New List(Of String)
            Dim lines As New List(Of String)
            Dim line As New Value(Of String)
            Dim reader As StreamReader = path.OpenReader

            Do While Not reader.EndOfStream
                Do While (line = reader.ReadLine).First = "#"c
                    headers += (+line)
                Loop

                lines += (+line)

                Do While Not String.IsNullOrEmpty(line = reader.ReadLine) AndAlso
                    (+line).First <> "#"c
                    lines += (+line)
                Loop

                Yield lines.ToArray.__parseTable(path$, headers, headerSplit)

                headers *= 0
                lines *= 0
                headers += (+line)

                If String.IsNullOrEmpty(headers.First) Then
                    Do While Not reader.EndOfStream AndAlso String.IsNullOrEmpty(line = reader.ReadLine)
                    Loop
                    headers += (+line)
                End If
            Loop
        End Function

        Private Function __createFromBlastn(sId As String, out As v228) As HitRecord()
            Dim LQuery As HitRecord() =
                LinqAPI.Exec(Of HitRecord) <= From Query As Query
                                              In out.Queries
                                              Select __createFromBlastn(sId, Query.SubjectHits)
            Return LQuery
        End Function

        <Extension>
        Private Function __createFromBlastn(sId As String, hits As SubjectHit()) As HitRecord()
            Dim LQuery As HitRecord() = LinqAPI.Exec(Of HitRecord) <=
 _
                From hspNT As SubjectHit
                In hits
                Let identity As Double = hspNT.Score.Identities.Value
                Let bits As Double = hspNT.Score.RawScore
                Let left As Integer = hspNT.QueryLocation.Left
                Let right As Integer = hspNT.QueryLocation.Right
                Select New HitRecord With {
                    .Identity = identity,
                    .DebugTag = hspNT.Name,
                    .SubjectIDs = sId,
                    .BitScore = bits,
                    .QueryStart = left,
                    .QueryEnd = right
                }

            Return LQuery
        End Function

        ''' <summary>
        ''' 从一个包含有blastn结果的文件夹之中构建出比对的结果表
        ''' </summary>
        ''' <param name="sourceDIR$"></param>
        ''' <returns></returns>
        Public Function CreateFromBlastn(sourceDIR$) As AlignmentTable
            Return (ls - l - r - "*.txt" <= sourceDIR).CreateFromBlastnFiles(sourceDIR.BaseName)
        End Function

        ''' <summary>
        ''' 从单个blastn结果输出文件之中构建出比对结果表
        ''' </summary>
        ''' <param name="file$">query vs multiple subjects</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' 因为只是一条query比对多条序列，所以所输出的blastn结果之中只有一个query
        ''' </remarks>
        Public Function CreateFromBlastnFile(file$, Optional stripNameLength% = -1) As AlignmentTable
            Dim blastn As v228 = Parser.LoadBlastOutput(file)
            Dim query As Query = blastn.Queries.First
            Dim hits = query.SubjectHits _
                .GroupBy(Function(h) h.Name) _
                .Select(Function(g)
                            Dim name$ = g.Key

                            If stripNameLength > 0 Then
                                name = Mid(name, 1, stripNameLength)
                            End If

                            Return name.__createFromBlastn(hits:=g.ToArray)
                        End Function) _
                .ToVector
            Dim Tab As New AlignmentTable With {
                .Hits = hits,
                .RID = Now.ToShortDateString,
                .Program = "BLASTN",
                .Database = blastn.Database,
                .Query = file.BaseName
            }
            Return Tab
        End Function

        ''' <summary>
        ''' 从一组blastn数据的结果文件之中构建出比对结果表
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="database$"></param>
        ''' <returns></returns>
        <Extension>
        Public Function CreateFromBlastnFiles(source As IEnumerable(Of String), database$) As AlignmentTable
            Dim Files = LinqAPI.Exec(Of NamedValue(Of v228)) <=
 _
                From path As String
                In source
                Let XOutput As v228 = Parser.LoadBlastOutput(path)
                Where Not XOutput Is Nothing AndAlso
                    Not XOutput.Queries.IsNullOrEmpty
                Select New NamedValue(Of v228) With {
                    .Name = path.BaseName,
                    .Value = XOutput
                }

            Dim LQuery As HitRecord() = (From file In Files Select __createFromBlastn(file.Name, file.Value)).ToVector
            Dim Tab As New AlignmentTable With {
                .Hits = LQuery,
                .RID = Now.ToShortDateString,
                .Program = "BLASTN",
                .Database = database,
                .Query = LinqAPI.DefaultFirst(Of String) <=
 _
                    From file As NamedValue(Of v228)
                    In Files
                    Let Q As Query() = file.Value.Queries
                    Where Not Q.IsNullOrEmpty
                    Select Q.First.QueryName
            }
            Return Tab
        End Function

        Public Function CreateFromBlastX(source As String) As AlignmentTable
            Dim Files = (From path As String
                         In ls - l - r - "*.txt" <= source
                         Select ID = path.BaseName,
                             XOutput = OutputReader.TryParseOutput(path)).ToArray
            Dim LQuery As HitRecord() = (From file In Files Select file.ID.__hits(file.XOutput)).ToVector
            Dim q$ = Files.First.XOutput.Queries.First.QueryName
            Dim tab As New AlignmentTable With {
                .Hits = LQuery,
                .Query = q,
                .RID = Now.ToShortDateString,
                .Program = "BlastX",
                .Database = source
            }
            Return tab
        End Function

        <Extension> Private Function __hits(id As String, out As v228_BlastX) As IEnumerable(Of HitRecord)
            Return out.Queries _
                .Select(Function(query) id.__hspHits(query)) _
                .IteratesALL
        End Function

        <Extension>
        Private Function __hspHits(id$, query As BlastX.Components.Query) As IEnumerable(Of HitRecord)
            Return From hsp As BlastX.Components.HitFragment
                   In query.Hits
                   Let row As HitRecord = New HitRecord With {
                       .Identity = hsp.Score.Identities.Value,
                       .DebugTag = query.SubjectName,
                       .SubjectIDs = id,
                       .BitScore = hsp.Score.RawScore,
                       .QueryStart = hsp.Hsp.First.Query.Left,
                       .QueryEnd = hsp.Hsp.Last.Query.Right
                   }
                   Select row
        End Function
    End Module
End Namespace
