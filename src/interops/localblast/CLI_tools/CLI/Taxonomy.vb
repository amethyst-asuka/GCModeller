﻿Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Assembly.NCBI
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application
Imports SMRUCC.genomics.Metagenomics

Partial Module CLI

    <ExportAPI("/Ref.Gi.list", Usage:="/Ref.Gi.list /in <blastnMaps.csv> [/out <out.csv>]")>
    Public Function GiList(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & ".gi.list.txt")
        Dim list$() = [in] _
            .LoadCsv(Of BlastnMapping) _
            .Select(Function(x) Regex _
                .Match(x.Reference, "gi\|\d+") _
                .Value _
                .Split("|"c) _
                .Last) _
            .Distinct _
            .ToArray

        Return list.FlushAllLines(out).CLICode
    End Function

    <ExportAPI("/Reads.OTU.Taxonomy",
               Usage:="/Reads.OTU.Taxonomy /in <blastnMaps.csv> /OTU <OTU_data.csv> /tax <taxonomy:nodes/names> [/out <out.csv>]")>
    Public Function ReadsOTU_Taxonomy(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim OTU As String = args("/OTU")
        Dim tax As String = args("/tax")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & "-" & OTU.BaseName & ".Taxonomy.csv")
        Dim maps = [in].LoadCsv(Of BlastnMapping)
        Dim data = OTU.LoadCsv(Of OTUData)
        Dim taxonomy As New NcbiTaxonomyTree(tax)
        Dim readsTable = (From x As BlastnMapping
                          In maps
                          Select x
                          Group x By x.ReadQuery Into Group) _
            .ToDictionary(Function(x) x.ReadQuery,
                          Function(x) x.Group.ToArray)
        Dim output As New List(Of OTUData)
        Dim diff As New List(Of String)

        For Each r In data
            Dim reads As BlastnMapping()
            Try
                reads = readsTable(r.OTU)
            Catch ex As Exception
                ' 由于可能是从所有的数据data之中匹配部分maps的数据，所以肯定会出现找不到的对象，在这里记录下来就行了，不需要报错
                diff += r.OTU
                Continue For
            End Try

            For Each o In reads
                Dim copy As New OTUData(r)
                Dim taxid% = CInt(o.Extensions("taxid"))
                Dim nodes = taxonomy.GetAscendantsWithRanksAndNames(taxid, True)
                copy.Data("taxid") = taxid
                copy.Data("Taxonomy") = TaxonomyNode.BuildBIOM(nodes)
                copy.Data("Reference") = o.Reference
                copy.Data("gi") = Regex.Match(o.Reference, "gi\|\d+").Value

                output += copy
            Next
        Next

        Call App.LogException(diff.GetJson)  ' 将缺失的记录下来

        Return output.SaveTo(out).CLICode
    End Function
End Module