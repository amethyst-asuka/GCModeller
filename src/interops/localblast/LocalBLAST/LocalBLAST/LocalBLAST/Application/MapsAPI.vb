﻿#Region "Microsoft.VisualBasic::af5a6f9b8b99de130323ec0ba0c7c7a3, ..\interops\localblast\LocalBLAST\LocalBLAST\LocalBLAST\Application\MapsAPI.vb"

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
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Parallel.Linq
Imports Microsoft.VisualBasic.Scripting.Runtime
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.BLASTOutput.BlastPlus

Namespace LocalBLAST.Application

    Public Module MapsAPI

        ''' <summary>
        ''' ```vbnet
        ''' Math.Abs(map.QueryRight - map.QueryLeft) / map.QueryLength
        ''' ```
        ''' </summary>
        ''' <param name="map"></param>
        ''' <returns></returns>
        <Extension> Public Function GetCoverage(map As BlastnMapping) As Double
            Return Math.Abs(map.QueryRight - map.QueryLeft) / map.QueryLength
        End Function

        Public Function Where(full As Boolean,
                              perfect As Boolean,
                              unique As Boolean,
                              Optional identities As Double = 0.9,
                              Optional logics As Logics = Logics.OrElse) As Func(Of BlastnMapping, Boolean)

            Dim tests As New List(Of Func(Of BlastnMapping, Boolean))

            If full Then
                tests += Function(x As BlastnMapping) x.AlignmentFullLength
            End If
            If perfect Then
                tests += Function(x As BlastnMapping) x.PerfectAlignment
            End If
            If unique Then
                tests += Function(x As BlastnMapping) x.Unique
            End If

            identities *= 100

            Dim preTest As Func(Of BlastnMapping, Boolean) = BuildAll(Of BlastnMapping)(logics, tests.ToArray)
            Dim test As Func(Of BlastnMapping, Boolean) = Function(x) preTest(x) AndAlso (x.Identities >= identities)

            Return test
        End Function

        ''' <summary>
        ''' 从blastn日志之中导出Mapping的数据
        ''' </summary>
        ''' <param name="Query"></param>
        ''' <returns></returns>
        ''' 
        <Extension>
        Public Function CreateObject(Query As Query) As BlastnMapping()
            Dim LQuery As BlastnMapping() =
                LinqAPI.Exec(Of BlastnMapping) <= From hitMapping As SubjectHit
                                                  In Query.SubjectHits
                                                  Let blastnHitMapping As BlastnHit = DirectCast(hitMapping, BlastnHit)
                                                  Select __createObject(Query, blastnHitMapping)
            Call __setUnique(LQuery)
            Return LQuery
        End Function

        ''' <summary>
        ''' Unique的判断原则：
        ''' 
        ''' 1. 假若一个query之中只含有一个hit，则为unique
        ''' 2. 假若一个query之中含有多个hit的话，假若只有一个hit是perfect类型的，则为unique
        ''' 3. 同一个query之中假若为多个perfect类型的hit的话，则不为unique
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Private Function __setUnique(ByRef data As BlastnMapping()) As Boolean
            If data.Length = 1 Then
                data(Scan0).Unique = True
                Return True
            End If

            Dim perfects = (From row As BlastnMapping In data
                            Where row.PerfectAlignment
                            Select row).ToArray

            For i As Integer = 0 To data.Length - 1
                data(i).Unique = False
            Next

            If perfects.Length = 0 Then
                Return False
            ElseIf perfects.Length = 1 Then  '只有perfect的被设置为真，其他的已经被设置为false了
                perfects(Scan0).Unique = True
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' 从blastn日志之中导出Mapping的数据
        ''' </summary>
        ''' <param name="Query"></param>
        ''' <param name="hitMapping"></param>
        ''' <returns></returns>
        Private Function __createObject(Query As Query, hitMapping As BlastnHit) As BlastnMapping
            Dim MappingView As New BlastnMapping With {
                .ReadQuery = Query.QueryName,
                .Reference = hitMapping.Name,
                .Evalue = hitMapping.Score.Expect,
                .Gaps = hitMapping.Score.Gaps.Value * 100,
                .GapsFraction = hitMapping.Score.Gaps.FractionExpr,
                .Identities = hitMapping.Score.Identities.Value * 100,
                .IdentitiesFraction = hitMapping.Score.Identities.FractionExpr,
                .QueryLeft = hitMapping.QueryLocation.Left,
                .QueryRight = hitMapping.QueryLocation.Right,
                .RawScore = hitMapping.Score.RawScore,
                .Score = hitMapping.Score.Score,
                .ReferenceLeft = hitMapping.SubjectLocation.Left,
                .ReferenceRight = hitMapping.SubjectLocation.Right,
                .Strand = hitMapping.Strand,
                .QueryLength = Query.QueryLength
            }         '.EffectiveSearchSpaceUsed = Query.EffectiveSearchSpace,
            '.H = Query.p.H,
            '.H_Gapped = Query.Gapped.H,
            '.K = Query.p.K,
            '.K_Gapped = Query.Gapped.K,
            '.Lambda = Query.p.Lambda,
            '.Lambda_Gapped = Query.Gapped.Lambda
            '}
            Return MappingView
        End Function

        ''' <summary>
        ''' 从blastn日志文件之中导出fastq对基因组的比对的结果
        ''' </summary>
        ''' <param name="blastnMapping"></param>
        ''' <param name="best">前提是query里面的hit的原有的顺序没有被破坏掉</param>
        ''' <returns></returns>
        <Extension>
        Public Function Export(blastnMapping As v228,
                               Optional best As Boolean = False,
                               Optional track$ = Nothing,
                               Optional parallel As Boolean = True) As BlastnMapping()

            Dim out As BlastnMapping()

            If Not best Then
                out = blastnMapping.Queries.Export
            Else
                out = Export(
                    blastnMapping _
                    .Queries _
                    .Select(Function(query) As Query
                                Dim copy As New Query(query)

                                If copy.SubjectHits.IsNullOrEmpty Then
                                    copy.SubjectHits = {}
                                Else
                                    copy.SubjectHits = {
                                    copy.SubjectHits.First
                                }
                                End If

                                Return copy
                            End Function), parallel)
            End If

            If Not String.IsNullOrEmpty(track) Then
                For Each x As BlastnMapping In out
                    x.Extensions = New Dictionary(Of String, String)
                    x.Extensions.Add(NameOf(track), track)
                Next
            End If

            Return out
        End Function

        <Extension>
        Public Function Export(lstQuery As IEnumerable(Of Query), Optional parallel As Boolean = True) As BlastnMapping()
            Dim LQuery As BlastnMapping() = lstQuery _
                .ToArray(AddressOf MapsAPI.CreateObject, parallel) _
                .ToVector
            Return LQuery
        End Function

        ''' <summary>
        ''' 按照条件 <see cref="BlastnMapping.Unique"/>=TRUE and <see cref="BlastnMapping.PerfectAlignment"/>=TRUE
        ''' 进行可用的alignment mapping结果的筛选
        ''' </summary>
        ''' <returns></returns>
        ''' 
        <Extension>
        Public Function TrimAssembly(data As IEnumerable(Of BlastnMapping)) As BlastnMapping()
            Dim sw = Stopwatch.StartNew
            Call $"Start of running {NameOf(TrimAssembly)} action...".__DEBUG_ECHO
            Dim LQuery As BlastnMapping() =
                LQuerySchedule.LQuery(Of
                    BlastnMapping,
                    BlastnMapping)(data,
                                   Function(x) x,
                            where:=Function(x) x.Unique AndAlso
                            x.PerfectAlignment).ToArray
            Call $"[Job DONE!] .....{sw.ElapsedMilliseconds}ms.".__DEBUG_ECHO
            Return LQuery
        End Function
    End Module
End Namespace
