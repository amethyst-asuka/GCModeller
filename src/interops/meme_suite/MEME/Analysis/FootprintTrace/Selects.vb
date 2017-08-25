﻿#Region "Microsoft.VisualBasic::075da494031aad89078ca452986fdb44, ..\interops\meme_suite\MEME\Analysis\FootprintTrace\Selects.vb"

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
Imports SMRUCC.genomics.Interops.NBCR.MEME_Suite.Analysis.MotifScans
Imports Microsoft.VisualBasic.CommandLine.Reflection

Namespace Analysis.FootprintTraceAPI

    ''' <summary>
    ''' 从计算出来的footprint数据之中选出motif用来进行聚类操作
    ''' </summary>
    Public Module Selects

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="trace"></param>
        ''' <param name="MEME">MEME DIR</param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("")>
        <Extension>
        Public Function [Select](trace As FootprintTrace, MEME As String) As AnnotationModel()
            Dim memeHash As Dictionary(Of AnnotationModel) = AnnotationModel.LoadMEMEOUT(MEME)
            Dim LQuery = (From x As MatchResult
                          In trace.Footprints
                          Select x.Select(memeHash)).ToVector
            Return LQuery
        End Function

        <Extension>
        Public Function [Select](footprints As MatchResult, models As Dictionary(Of AnnotationModel)) As AnnotationModel()
            If footprints.Matches.IsNullOrEmpty Then
                Return Nothing
            Else
                Dim LQuery = (From x As MotifHits In footprints.Matches
                              Let tks As String() = Strings.Split(x.Trace, "::")
                              Let uid As String = $"{tks(Scan0)}.{tks(1)}"
                              Where models.ContainsKey(uid)
                              Select models(uid)).ToArray
                Return LQuery
            End If
        End Function
    End Module
End Namespace
