﻿Imports System.ComponentModel
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Analysis.Microarray.DEGProfiling
Imports SMRUCC.genomics.Analysis.Microarray.KOBAS
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
    <Group(CLIGroups.NetworkEnrichment_CLI)>
    Public Function FunctionalNetworkEnrichment(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim uniprot$ = args <= "/uniprot"
        Dim DEP$ = args <= "/DEP"
        Dim fold# = args.GetValue("/fold", 1.5)
        Dim iTraq As Boolean = args.GetBoolean("/iTraq")
        Dim logFC$ = args.GetValue("/logFC", NameOf(logFC))
        Dim out$ = args.GetValue("/out", [in].TrimSuffix & "-funrich_string/")
        Dim proteins As protein() = protein.LoadDataSet(DEP).ToArray
        Dim stringNetwork = [in].LoadTsv(Of InteractExports)
        Dim threshold As (up#, down#)
        Dim layouts As Coordinates() = (args <= "/layout").LoadTsv(Of Coordinates)
        Dim annotations = UniprotXML.Load(uniprot).StringUniprot ' STRING -> uniprot

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
        Dim Uniprot2STRING = annotations.Uniprot2STRING

        With DEGs
            DEGs = (Uniprot2STRING(.UP), Uniprot2STRING(.DOWN))
        End With

        Dim radius = args.GetValue("/r.range", "12,30")

        With stringNetwork.NetworkVisualize(
            annotations:=annotations,
            DEGs:=DEGs,
            layouts:=layouts,
            radius:=radius)

            Call .image _
                .SaveAs(out & "/network.png")

            Return .model _
                .Save(out) _
                .CLICode
        End With
    End Function

    ''' <summary>
    ''' 将KOBAS富集得到的基因的编号列表写入到一个文本文件之中
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    ''' 
    <ExportAPI("/Gene.list.from.KOBAS")>
    <Usage("/Gene.list.from.KOBAS /in <KOBAS.csv> [/p.value <default=1> /out <out.txt>]")>
    <Description("Using this command for generates the gene id list input for the STRING-db search.")>
    <Argument("/p.value", True, AcceptTypes:={GetType(Double)},
              Description:="Using for enrichment term result filters, default is p.value less than or equals to 1, means no cutoff.")>
    <Group(CLIGroups.NetworkEnrichment_CLI)>
    Public Function GeneIDListFromKOBASResult(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim pvalue = args.GetValue("/p.value", 1.0R)
        Dim out$ = If(pvalue = 1.0R,
            [in].TrimSuffix & ".gene.list.txt",
            [in].TrimSuffix & $"_p.value={pvalue},gene.list.txt")

        out = args.GetValue("/out", out)

        Dim data As EnrichmentTerm() = [in].LoadCsv(Of EnrichmentTerm)
        data = data _
            .Where(Function(t) t.Pvalue <= pvalue) _
            .ToArray

        Return data _
            .Select(Function(t) t.ORF) _
            .IteratesALL _
            .Distinct _
            .ToArray _
            .SaveTo(out) _
            .CLICode
    End Function

    <ExportAPI("/richfun.KOBAS")>
    <Usage("/richfun.KOBAS /in <string_interactions.tsv> /uniprot <uniprot.XML> /DEP <dep.t.test.csv> /KOBAS <enrichment.csv> [/r.range <default=5,20> /fold <1.5> /iTraq /logFC <logFC> /layout <string_network_coordinates.txt> /out <out.network.DIR>]")>
    <Argument("/KOBAS", Description:="The pvalue result in the enrichment term, will be using as the node radius size.")>
    <Group(CLIGroups.NetworkEnrichment_CLI)>
    Public Function KOBASNetwork(args As CommandLine) As Integer

    End Function
End Module