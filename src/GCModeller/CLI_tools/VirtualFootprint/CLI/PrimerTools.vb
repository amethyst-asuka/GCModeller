﻿Imports LANS.SystemsBiology.AnalysisTools.PrimerDesigner.Restriction_enzyme
Imports LANS.SystemsBiology.SequenceModel.FASTA
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.Serialization.JSON

Partial Module CLI

    <ExportAPI("/restrict_enzyme.builds",
               Info:="",
               Usage:="/restrict_enzyme.builds [/source <html_DIR> /out <out.json>]")>
    <ParameterInfo("/source", True,
                   Description:="Default using the data source from Wikipedia.")>
    <ParameterInfo("/out", True,
                   Description:="Enzyme database was writing to the GCModeller repository by default.")>
    Public Function BuildEnzymeDb(args As CommandLine) As Integer
        Dim source As String = args("/source")
        Dim out As String = args.GetValue("/out", GCModeller.FileSystem.RepositoryRoot & "/restrict_enzyme.Xml")

        If Not source.DirectoryExists Then
            Return -1
        Else
            Dim result As Enzyme() = source.LoadDIR
            Return result.GetXml.SaveTo(out).CLICode
        End If
    End Function

    <ExportAPI("/Export.Primer",
               Info:="[SSR name], [Forward primer], [Reverse primer]",
               Usage:="/Export.Primer /in <primer.csv/DIR> [/out <out.DIR> /batch]")>
    Public Function ExportPrimer(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim batch As Boolean = args.GetBoolean("/batch")
        Dim out As String =
            args.GetValue("/out", If(batch, [in].TrimDIR, [in].TrimFileExt) & ".Primers/")

        If batch Then
            For Each file As String In ls - l - r - wildcards("*.Csv") <= [in]
                Call __exportPrimer(file, out)
            Next
        Else
            Call __exportPrimer([in], out)
        End If

        Return 0
    End Function

    Private Sub __exportPrimer([in] As String, out As String)
        Dim raw As IEnumerable(Of SSRPrimers) = [in].LoadCsv(Of SSRPrimers)
        Dim forwards As FastaToken() =
            LinqAPI.Exec(Of FastaToken) <= From x As SSRPrimers
                                           In raw
                                           Select New FastaToken({x.name}, x.ForwardPrimer)
        Dim reversed As FastaToken() =
            LinqAPI.Exec(Of FastaToken) <= From x As SSRPrimers
                                           In raw
                                           Select New FastaToken({x.name}, x.ReversePrimer)

        Call New FastaFile(forwards).Save(out & "/F-" & [in].BaseName & ".fasta")
        Call New FastaFile(reversed).Save(out & "/R-" & [in].BaseName & ".fasta")

        Dim interval As String = New String("N"c, 20)
        Dim primers As FastaToken() =
            LinqAPI.Exec(Of FastaToken) <= From x As SSRPrimers
                                           In raw
                                           Let seq As String = x.ForwardPrimer & interval & x.ReversePrimer
                                           Select New FastaToken({x.name}, seq)

        Call New FastaFile(primers).Save(out & $"/Primers-{[in].BaseName}.fasta")
    End Sub
End Module

Public Class SSRPrimers
    <Column("SSR name")> Public Property name As String
    <Column("Forward primer")> Public Property ForwardPrimer As String
    <Column("Reverse primer")> Public Property ReversePrimer As String

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class