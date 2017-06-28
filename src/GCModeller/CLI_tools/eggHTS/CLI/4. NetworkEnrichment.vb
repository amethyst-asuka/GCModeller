﻿Imports System.ComponentModel
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.visualize.Network.Analysis
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Analysis.Microarray.DEGProfiling
Imports SMRUCC.genomics.Assembly.Uniprot.XML
Imports SMRUCC.genomics.Data.STRING
Imports SMRUCC.genomics.Model.Network.STRING
Imports protein = Microsoft.VisualBasic.Data.csv.IO.EntityObject

Partial Module CLI

    ''' <summary>
    ''' 可视化string-db搜索结果，并使用KEGG pathway进行颜色分组
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/func.rich.string")>
    <Usage("/func.rich.string /in <string_interactions.tsv> /uniprot <uniprot.XML> /DEP <dep.t.test.csv> [/r.range <default=5,20> /fold <1.5> /iTraq /logFC <logFC> /layout <string_network_coordinates.txt> /out <out.network.DIR>]")>
    <Description("DEPs' functional enrichment network based on string-db exports, and color by KEGG pathway.")>
    Public Function FunctionalNetworkEnrichment(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim uniprot$ = args <= "/uniprot"
        Dim DEP$ = args <= "/DEP"
        Dim fold# = args.GetValue("/fold", 1.5)
        Dim iTraq As Boolean = args.GetBoolean("/iTraq")
        Dim logFC$ = args.GetValue("/logFC", NameOf(logFC))
        Dim out$ = args.GetValue("/out", [in].TrimSuffix & "-funrich_string/")
        Dim proteins As protein() = protein.LoadDataSet(DEP).ToArray
        Dim annotations = UniprotXML.Load(uniprot).StringUniprot ' STRING -> uniprot
        Dim model = [in].LoadTsv(Of InteractExports).BuildModel(annotations)
        Dim threshold As (up#, down#)
        Dim layouts As Coordinates() = (args <= "/layout").LoadTsv(Of Coordinates)

        If iTraq Then
            threshold = (fold, 1 / fold)
        Else
            threshold = (fold.Log2, (1 / fold).Log2)
        End If

        Dim DEGs = proteins.GetDEGs(
            Function(gene)
                Return gene("is.DEP").TextEquals("TRUE")
            End Function,
            threshold, logFC)

        With DEGs
            Dim uniprotSTRING = annotations.Values _
                .Distinct _
                .Select(Function(protein)
                            Return protein.accessions.Select(Function(unid) (unid, protein))
                        End Function) _
                .IteratesALL _
                .GroupBy(Function(x) x.Item1) _
                .ToDictionary(Function(x) x.Key,
                              Function(x)
                                  Return x.First.Item2 _
                                      .Xrefs(InteractExports.STRING) _
                                      .Select(Function(link) link.id) _
                                      .ToArray
                              End Function)
            Dim uniprot2STRING = Function(list As String())
                                     Return list _
                                         .Where(Function(id) uniprotSTRING.ContainsKey(id)) _
                                         .Select(Function(id) uniprotSTRING(id)) _
                                         .IteratesALL _
                                         .Distinct _
                                         .ToArray
                                 End Function
            DEGs = (uniprot2STRING(.UP), uniprot2STRING(.DOWN))
        End With

        Dim radius = args.GetValue("/r.range", "12,30")

        Call model.ComputeNodeDegrees
        Call model.RenderDEGsColor(DEGs, (up:="brown", down:="skyblue"),)
        Call model.VisualizeKEGG(
                layouts,
                size:="4000,3000",
                scale:=2.5,
                radius:=radius,
                groupLowerBounds:=4) _
            .SaveAs(out & "/network.png")

        Return model.Save(out).CLICode
    End Function
End Module