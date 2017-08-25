﻿Imports System.ComponentModel
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports SMRUCC.genomics.Analysis.Metagenome

Partial Module CLI

    <ExportAPI("/Rank_Abundance")>
    <Description("https://en.wikipedia.org/wiki/Rank_abundance_curve")>
    <Usage("/Rank_Abundance /in <OTU.table.csv> [/schema <color schema, default=Rainbow> /out <out.DIR>]")>
    <Group(CLIGroups.Alpha_Diversity)>
    Public Function Rank_Abundance(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim schema$ = args.GetValue("/schema", "Rainbow")
        Dim out$ = args.GetValue("/out", [in].TrimSuffix & ".Rank_Abundance/")
        Dim OTUs As OTUTable() = OTUTable.LoadSample([in])
        Dim rankAbundance = OTUs.RankAbundance

        Call rankAbundance.SaveTo(out & "/Rank_Abundance.csv")

        Return 0
    End Function
End Module