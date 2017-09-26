﻿Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.Ranges
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Assembly.Uniprot.XML
Imports SMRUCC.genomics.Data.STRING
Imports NetGraph = Microsoft.VisualBasic.Data.visualize.Network.FileStream.NetworkTables
Imports NetNode = Microsoft.VisualBasic.Data.visualize.Network.FileStream.Node

''' <summary>
''' 功能富集网络
''' </summary>
Public Module FunctionalEnrichmentNetwork

    ''' <summary>
    ''' Using string-db ID as the uniprot data index key
    ''' </summary>
    ''' <param name="uniprot"></param>
    ''' <returns></returns>
    <Extension> Public Function StringUniprot(uniprot As UniProtXML) As Dictionary(Of String, entry)
        Return uniprot _
            .entries _
            .Where(Function(protein) protein.Xrefs.ContainsKey(InteractExports.STRING)) _
            .Select(Function(protein) protein.Xrefs(InteractExports.STRING) _
            .Select(Function(id) (id, protein))) _
            .IteratesALL _
            .GroupBy(Function(id) id.Item1.id) _
            .ToDictionary(Function(x) x.Key,
                          Function(proteins) proteins.First.Item2)
    End Function

    Const delimiter$ = " === "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="interacts"></param>
    ''' <param name="uniprot"></param>
    ''' <param name="groupValues">进行Node分组所需要的group信息来源</param>
    ''' <returns></returns>
    <Extension>
    Public Function BuildModel(interacts As IEnumerable(Of InteractExports),
                               uniprot As Dictionary(Of String, entry),
                               groupValues As Dictionary(Of String, String)) As NetGraph

        Dim name2STRING = interacts _
            .Select(Function(x) {
                (x.node1, x.node1_external_id),
                (x.node2, x.node2_external_id)
            }) _
            .IteratesALL _
            .GroupBy(Function(x) x.Item1) _
            .ToDictionary(Function(x) x.Key,
                          Function(stringID) stringID.First.Item2)
        Dim nodes = interacts _
            .NodesID _
            .Select(Function(stringID$)
                        Dim pathways$()
                        Dim KO$()
                        Dim uniprotID$()
                        Dim name$ = stringID

                        stringID = name2STRING(name)

                        If uniprot.ContainsKey(stringID) Then
                            With uniprot(stringID)
                                KO = .Xrefs.TryGetValue("KO") _
                                     .SafeQuery _
                                     .Select(Function(x) x.id) _
                                     .ToArray
                                pathways = KO _
                                    .Where(Function(ID) groupValues.ContainsKey(ID)) _
                                    .Select(Function(ID) groupValues(ID)) _
                                    .Distinct _
                                    .ToArray
                                uniprotID = .accessions
                            End With
                        Else
                            KO = {}
                            pathways = {}
                            uniprotID = {}
                        End If

                        Dim data As New Dictionary(Of String, String)

                        data!KO = KO.JoinBy("|")
                        data!uniprotID = uniprotID.JoinBy("|")
                        data!STRING_ID = stringID

                        Return New NetNode(name) With {
                            .NodeType = pathways.JoinBy(FunctionalEnrichmentNetwork.delimiter),
                            .Properties = data
                        }
                    End Function) _
            .ToDictionary
        Dim links = interacts _
            .Select(Function(l)
                        Dim a = nodes(l.node1)
                        Dim b = nodes(l.node2)
                        Dim pa = Strings.Split(a.NodeType, FunctionalEnrichmentNetwork.delimiter)
                        Dim pb = Strings.Split(b.NodeType, FunctionalEnrichmentNetwork.delimiter)
                        Dim type$

                        If pa.Where(Function(pathway) pb.IndexOf(pathway) > -1).Count > 0 Then
                            type = "pathway_internal"
                        ElseIf pa.IsNullOrEmpty AndAlso pb.IsNullOrEmpty Then
                            type = "Unknown"
                        Else
                            type = "pathway_outbounds"
                        End If

                        Return New NetworkEdge With {
                            .FromNode = l.node1,
                            .ToNode = l.node2,
                            .Interaction = type,
                            .value = l.combined_score
                        }
                    End Function).ToArray

        Return New NetGraph(links, nodes.Values)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="model">是以STRING的蛋白编号为标识符的，所以在这里还需要使用uniprot的数据进行转换</param>
    ''' <param name="DEGs">uniprot蛋白编号</param>
    ''' <param name="colors"></param>
    ''' <returns></returns>
    ''' 
    <Extension>
    Public Function RenderDEGsColor(ByRef model As NetGraph,
                                    DEGs As (up As String(), down As String()),
                                    colors As (up$, down$),
                                    Optional nonDEPcolor$ = "gray") As NetGraph

        Dim up = DEGs.up.Indexing
        Dim down = DEGs.down.Indexing

        For Each node As NetNode In model.Nodes
            Dim id$ = node!STRING_ID

            If up.IndexOf(id) > -1 Then
                node!color = colors.up
            ElseIf down.IndexOf(id) > -1 Then
                node!color = colors.down
            Else
                node!color = nonDEPcolor
            End If
        Next

        Return model
    End Function

    <Extension>
    Public Function RenderDEGsColorSchema(ByRef model As NetGraph,
                                          DEGs As (up As Dictionary(Of String, Double), down As Dictionary(Of String, Double)),
                                          schema As (up$, down$),
                                          Optional nonDEPColor$ = NameOf(Color.Gray)) As NetGraph
        Dim upColors$() = Designer _
            .GetColors(schema.up, 256) _
            .Skip(56) _
            .Select(Function(c) c.ToHtmlColor) _
            .ToArray
        Dim downColors$() = Designer _
            .GetColors(schema.down, 256) _
            .Skip(56) _
            .Select(Function(c) c.ToHtmlColor) _
            .ToArray
        Dim colorIndex As DoubleRange = {0, 199}
        Dim upRange As DoubleRange = DEGs.up.Values.Range
        Dim downRange As DoubleRange = DEGs.down.Values.Range

        For Each node As NetNode In model.Nodes
            Dim id$ = node!STRING_ID

            If DEGs.up.ContainsKey(id) Then
                node!color = upColors(upRange.ScaleMapping(DEGs.up(id), colorIndex))
            ElseIf DEGs.down.ContainsKey(id) Then
                node!color = downColors(downRange.ScaleMapping(DEGs.down(id), colorIndex))
            Else
                node!color = nonDEPColor
            End If
        Next

        Return model
    End Function
End Module
