﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Terminal

Namespace Layouts

    Public Module forceNetwork

        ''' <summary>
        ''' Applies the force directed layout.
        ''' (如果有些时候这个函数不起作用的话，考虑一下在调用这个函数之前，先使用<see cref="doRandomLayout"/>初始化随机位置)
        ''' </summary>
        ''' <param name="net"></param>
        ''' <param name="iterations"></param>
        <ExportAPI("Layout.ForceDirected")>
        <Extension>
        Public Sub doForceLayout(ByRef net As NetworkGraph,
                                 Optional Stiffness# = 80,
                                 Optional Repulsion# = 4000,
                                 Optional Damping# = 0.83,
                                 Optional iterations% = 1000,
                                 Optional showProgress As Boolean = False)

            Dim physicsEngine As New ForceDirected2D(net, Stiffness, Repulsion, Damping)

            Using progress As New ProgressBar("Do Force Directed Layout...", cls:=showProgress)
                Dim tick As New ProgressProvider(iterations)
                Dim ETA$

                For i As Integer = 0 To iterations
                    Call physicsEngine.Calculate(0.05F)

                    If showProgress Then
                        ETA = "ETA=" & tick _
                            .ETA(progress.ElapsedMilliseconds) _
                            .FormatTime
                        progress.SetProgress(tick.StepProgress, ETA)
                    End If
                Next
            End Using

            Call physicsEngine.EachNode(
                Sub(node, point)
                    node.Data.initialPostion = point.position
                End Sub)
        End Sub

        <Extension>
        Public Sub doRandomLayout(ByRef net As NetworkGraph)
            Dim rnd As New Random

            For Each x As Node In net.nodes
                x.Data.initialPostion = New FDGVector2 With {
                    .x = rnd.NextDouble * 1000,
                    .y = rnd.NextDouble * 1000
                }
            Next
        End Sub
    End Module
End Namespace