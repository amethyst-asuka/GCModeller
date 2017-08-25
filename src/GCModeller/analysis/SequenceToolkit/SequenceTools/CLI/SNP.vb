﻿#Region "Microsoft.VisualBasic::0cd1a5c89eaea30ba3af3189933d97a9, ..\GCModeller\analysis\SequenceToolkit\SequenceTools\CLI\SNP.vb"

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

Imports System.Text
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Text
Imports SMRUCC.genomics.Analysis.SequenceTools.SNP
Imports SMRUCC.genomics.Analysis.SequenceTools.SNP.VCF
Imports SMRUCC.genomics.SequenceModel.FASTA

Partial Module Utilities

    <ExportAPI("/SNP",
               Usage:="/SNP /in <nt.fasta> [/ref <int_index/title, default:0> /pure /monomorphic /high <0.65>]")>
    <Argument("/in", False, AcceptTypes:={GetType(FastaFile)}, Description:="")>
    <Argument("/ref", True, AcceptTypes:={GetType(Integer)})>
    <Argument("/pure", True, AcceptTypes:={GetType(Boolean)})>
    <Group(CLIGrouping.SNPTools)>
    Public Function SNP(args As CommandLine) As Integer
        Dim [in] As String = args - "/in"
        Dim pure As Boolean = args.GetBoolean("/pure")
        Dim monomorphic As Boolean = args.GetBoolean("/monomorphic")
        Dim nt As New FastaFile([in])
        Dim ref$ = args.GetValue("/ref", "0")
        Dim high# = args.GetValue("/high", 0.65)
        Dim json As String = [in].TrimSuffix & ".SNPs.args.json"
        Dim vcf$ = Nothing

        Call nt _
            .ScanSNPs(ref, pure, monomorphic, vcf_output_filename:=vcf) _
            .GetJson _
            .SaveTo(json)

        Return SNPVcf.VcfHighMutateScreens(vcf, cut:=high#) _
            .SaveTo(vcf.TrimSuffix & $"-hight_{high}.vcf")
    End Function

    <ExportAPI("/Time.Mutation",
               Info:="The ongoing time mutation of the genome sequence.",
               Usage:="/Time.Mutation /in <aln.fasta> [/ref <default:first,other:title/index> /cumulative /out <out.csv>]")>
    <Group(CLIGrouping.SNPTools)>
    Public Function TimeDiffs(args As CommandLine) As Integer
        Dim [in] As String = args - "/in"
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & ".time_variation.csv")
        Dim isCumulative As Boolean = args.GetBoolean("/cumulative")

        If isCumulative Then
            out = out.TrimSuffix & "-cumulative.csv"
        End If

        Dim source As New FastaFile([in])
        Dim raw As List(Of EntityObject) = Nothing
        Dim result As DataSet() = source _
            .GetSeqs(args("/ref")) _
            .GroupByDate(isCumulative, raw)
        Dim T As IO.File = result.ToCsvDoc.Transpose
        Dim rawData As File = raw.ToCsvDoc.Transpose
        Call rawData.Save(out.TrimSuffix & "-raw.csv", Encodings.ASCII)
        Return T.Save(out, Encoding.ASCII)
    End Function
End Module
