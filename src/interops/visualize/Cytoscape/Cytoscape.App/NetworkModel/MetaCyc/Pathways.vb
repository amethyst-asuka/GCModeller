﻿Imports Microsoft.VisualBasic.DocumentFormat.Csv.Extensions
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.DataVisualization.Network
Imports LANS.SystemsBiology.Assembly.MetaCyc.File.FileSystem
Imports LANS.SystemsBiology.Assembly
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports LANS.SystemsBiology.Assembly.MetaCyc.Schema.Metabolism
Imports Microsoft.VisualBasic.Language
Imports LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots

Namespace NetworkModel

    Public Class Pathways

        Protected _MetaCyc As DatabaseLoadder

        Sub New(MetaCyc As DatabaseLoadder)
            _MetaCyc = MetaCyc
        End Sub

        ''' <summary>
        ''' 导出代谢途径的网络
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Export(Dir As String) As Integer
            Dim Edges As FileStream.NetworkEdge() = Nothing, Nodes As Pathways.Pathway() = Nothing
            Call Export(Edges, Nodes)

            Call Edges.SaveTo(String.Format("{0}/Edges.csv", Dir), False)
            Call Nodes.SaveTo(String.Format("{0}/Nodes.csv", Dir), False)

            Return 0
        End Function

        Protected Sub Export(ByRef Edges As FileStream.NetworkEdge(), ByRef Nodes As Pathways.Pathway())
            Dim Pathways = _MetaCyc.GetPathways
            Dim Network As New List(Of FileStream.NetworkEdge)
            Dim NodeList As New List(Of Pathway)

            Dim EnyzmeAnalysis As New MetaCycPathways(Me._MetaCyc)
            Dim AnalysisResult = EnyzmeAnalysis.Performance
            Dim GeneObjects = _MetaCyc.GetGenes

            For Each Pwy In Pathways
                Dim LQuery As PathwayLink() =
                    LinqAPI.Exec(Of PathwayLink) <= From pwyItem As String
                                                    In Pwy.PathwayLinks
                                                    Select New PathwayLink(pwyItem) ' interaction list
                If LQuery.IsNullOrEmpty Then
                    Network += New FileStream.NetworkEdge With {
                        .FromNode = Pwy.Identifier
                    }
                Else
                    Network += GenerateLinks(LQuery, Pwy.Identifier)
                End If

                If Not Pwy.InPathway.IsNullOrEmpty Then
                    Network += From Id As String
                               In Pwy.InPathway
                               Select New FileStream.NetworkEdge With {
                                   .FromNode = Id.ToUpper,
                                   .InteractionType = "Contains",
                                   .ToNode = Pwy.Identifier
                               }
                End If

                Dim assocEnzymes As String() =
                    AnalysisResult.GetItem(Pwy.Identifier).AssociatedGenes
                assocEnzymes =
                    LinqAPI.Exec(Of String) <= From gene As Gene
                                               In GeneObjects.Takes(assocEnzymes)
                                               Select gene.Accession1
                                               Distinct
                                               Order By Accession1 Ascending
                NodeList += New Pathway With {
                    .Identifier = Pwy.Identifier,
                    .GeneObjects = assocEnzymes,
                    .EnzymeCounts = assocEnzymes.Count,
                    .SuperPathway = Not Pwy.SubPathways.IsNullOrEmpty,
                    .ReactionCounts = Pwy.ReactionList.Count,
                    .CommonName = Pwy.CommonName
                }
            Next

            Edges = Network.ToArray
            Nodes = NodeList.ToArray
        End Sub

        Public Class Pathway : Implements sIdEnumerable

            Public Property Identifier As String Implements sIdEnumerable.Identifier
            Public Property ReactionCounts As Integer
            Public Property EnzymeCounts As Integer
            Public Property CommonName As String
            Public Property GeneObjects As String()
            Public Property SuperPathway As Boolean

            Public Overrides Function ToString() As String
                Return Identifier
            End Function
        End Class

        Public Function GenerateLinks(pwy As PathwayLink(), UniqueId As String) As FileStream.NetworkEdge()
            Dim EdgeList As New List(Of FileStream.NetworkEdge)

            For Each Link As PathwayLink In pwy
                EdgeList += From item In Link.LinkedPathways
                            Let iter As String =
                                If(item.LinkType = PathwayLink.PathwaysLink.LinkTypes.NotSpecific,
                                  "interact_with",
                                  item.LinkType.ToString)
                            Select New FileStream.NetworkEdge With {
                                .FromNode = UniqueId,
                                .InteractionType = iter,
                                .ToNode = item.Id.Replace("|", "").ToUpper
                            }
            Next

            Return EdgeList.ToArray
        End Function
    End Class
End Namespace