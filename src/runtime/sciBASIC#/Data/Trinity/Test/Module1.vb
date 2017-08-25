﻿#Region "Microsoft.VisualBasic::c111fb5d5effc09cd916b70827e89f81, ..\sciBASIC#\Data\Trinity\Test\Module1.vb"

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

Imports Microsoft.VisualBasic.Data.NLP
Imports Microsoft.VisualBasic.Data.visualize.Network
Imports Microsoft.VisualBasic.Data.visualize.Network.Analysis.PageRank
Imports Microsoft.VisualBasic.Serialization.JSON

Module Module1

    Sub Main()
        Dim s = "
This module implements TextRank, an unsupervised keyword
significance scoring algorithm. TextRank builds a weighted
graph representation Of a document Using words As nodes
And coocurrence frequencies between pairs of words as edge 
weights.It then applies PageRank to this graph, And
treats the PageRank score of each word as its significance.
The original research paper proposing this algorithm Is
available here"


        s$ = "the important pagerank. show on pagerank. have significance pagerank. implements pagerank algorithm. textrank base on pagerank."

        Dim ps = TextRank.Sentences(s.TrimNewLine)
        Dim g As GraphMatrix = ps.TextGraph
        Dim pr As New PageRank(g)
        Dim result = g.TranslateVector(pr.ComputePageRank, True)

        Call result.GetJson(True).EchoLine

        Dim net = g.GetNetwork

        For Each node In net.Nodes
            node.Properties.Add("PageRank", result(node.ID))
        Next

        Call net.Save("G:\GCModeller\src\runtime\sciBASIC#\Data\TextRank\")

        Pause()
    End Sub
End Module
