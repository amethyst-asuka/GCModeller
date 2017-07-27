﻿#Region "Microsoft.VisualBasic::b5f0bf4384115034044e7b97bd17c9cd, ..\GCModeller\analysis\RNA-Seq\Toolkits.RNA-Seq\GenePrediction\NCBIWebMaster.vb"

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

Imports System.Net
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Analysis.RNA_Seq.GenePrediction.DocNodes

Namespace GenePrediction

    ''' <summary>
    ''' Microbial Genome Annotation Tools @http://www.ncbi.nlm.nih.gov/genomes/MICROBES/genemark.cgi
    ''' </summary>
    ''' 
    <PackageAttribute("GeneMark",
                      Publisher:="Microbial Genome Annotation Tools",
                      Category:=APICategories.ResearchTools,
                      Description:="The GeneMark family of gene finding programs has been used for prokaryotic genome annotation since 1995 
                      when GeneMark contributed to launching the genomic era by providing automatic gene annotation of complete genomes of Haemophilus influenza, 
                      Methanoccus jannaschii as well as Escherichia coli and Bacillus subtilis.
In GeneMark.hmm, 1,3 the second generation of GeneMark, the DNA sequence is interpreted as a realization of the hidden 
                      semi-Markov model with genome specific parameters. Then the maximum likelihood parse of the sequence into protein-coding and 
                      non-coding regions is generated by an optimization algorithm. Note that the genome specific parameters of the model are determined from the submitted DNA sequence 2,3.",
                      Url:="<pre>
1.  Lukashin AV, Borodovsky M. 1998. GeneMark.hmm: new solutions for gene finding., Nucleic Acids Research 26: 1107-1115.
2.  Besemer J, Borodovsky M. 1999. Heuristic approach to deriving models for gene finding., Nucleic Acids Research 27: 3911-3920.
3.  Besemer J., Lomsadze A. and Borodovsky M. 2001. GeneMarkS: a self-training method for prediction of gene starts in microbial genomes. Implications for finding sequence motifs in regulatory regions. Nucleic Acids Research, 29: 2607-2618.
                      </pre>",
                      Url:=NCBIWebMaster.Url)>
    Public Module NCBIWebMaster

        Public Const Url As String = "http://www.ncbi.nlm.nih.gov/genomes/MICROBES/genemark.cgi"

        Public Class params

            ''' <summary>
            ''' The GeneMark family of gene finding programs has been used for prokaryotic genome annotation since 1995 
            ''' when GeneMark contributed to launching the genomic era by providing automatic gene annotation of 
            ''' complete genomes of Haemophilus influenza, Methanoccus jannaschii as well as Escherichia coli and Bacillus subtilis.
            ''' In GeneMark.hmm, 1,3 the second generation of GeneMark, the DNA sequence Is interpreted as a realization 
            ''' of the hidden semi-Markov model with genome specific parameters. Then the maximum likelihood parse of 
            ''' the sequence into protein-coding And non-coding regions Is generated by an optimization algorithm. 
            ''' Note that the genome specific parameters of the model are determined from the submitted DNA sequence 2,3.
            ''' </summary>
            ''' <param name="gencode">
            ''' 11 (Bacteria, Archaea);
            ''' 4 (Mycoplasma/Spiroplasma)
            ''' </param>
            ''' <param name="topology">
            ''' 0 partial/circular;
            ''' 1 linear
            ''' </param>
            Sub New(gencode As Integer, topology As Integer)
                _shape = topology
                _gencode = gencode
            End Sub

            Sub New()
                Call Me.New(11, 0)
            End Sub

            Sub New(Bacteria As Boolean, linear As Boolean)
                Call Me.New(If(Bacteria, 11, 4), If(linear, 1, 0))
            End Sub

            Dim _shape As Integer
            Dim _gencode As Integer

            Const InputFasta As String = "sequence"
            Const GeneticCode As String = "gencode"
            Const Shape As String = "topology"

            Public Function UploadFasta(Fasta As SequenceModel.FASTA.FastaToken) As Specialized.NameValueCollection
                Dim reqparm As New Specialized.NameValueCollection
                Call reqparm.Add(InputFasta, Fasta.GenerateDocument(-1))
                Call reqparm.Add(GeneticCode, _gencode)
                Call reqparm.Add(Shape, _shape)
                Return reqparm
            End Function
        End Class

        <ExportAPI("Genemarks")>
        Public Function Predicts(source As SMRUCC.genomics.SequenceModel.FASTA.FastaFile,
                                 Optional Bacteria As Boolean = True,
                                 Optional linear As Boolean = False) As GeneMark()
            Dim LQuery = (From x In source Select Predicts(x, Bacteria, linear)).ToArray
            Return LQuery
        End Function

        <ExportAPI("Genemark")>
        Public Function Predicts(source As SMRUCC.genomics.SequenceModel.FASTA.FastaToken,
                                 Optional Bacteria As Boolean = True,
                                 Optional linear As Boolean = False) As GeneMark
            Dim webPage As String = GetPredictsData(source, Bacteria, linear)
            Dim result As GeneMark = GeneMark.ParseDoc(webPage)
            Return result
        End Function

        <ExportAPI("Run.Genemarks")>
        Public Function GetsPredictData(source As SMRUCC.genomics.SequenceModel.FASTA.FastaFile,
                                        Optional Bacteria As Boolean = True,
                                        Optional linear As Boolean = False) As String()
            Dim LQuery As String() = (From x In source Select GetPredictsData(x, Bacteria, linear)).ToArray
            Return LQuery
        End Function

        <ExportAPI("Run.Genemark")>
        Public Function GetPredictsData(source As SMRUCC.genomics.SequenceModel.FASTA.FastaToken,
                                        Optional Bacteria As Boolean = True,
                                        Optional linear As Boolean = False) As String
            Dim webPage As String

            Call source.__DEBUG_ECHO

            Using client As Net.WebClient = New Net.WebClient
                Dim reqparm = New params(Bacteria, linear).UploadFasta(source)
                Dim responsebytes = client.UploadValues(NCBIWebMaster.Url, "POST", reqparm)

                webPage = (New Text.UTF8Encoding).GetString(responsebytes)
                webPage = Regex.Match(webPage, "<pre>.+</pre>", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Value
                webPage = Mid(webPage, 6)
                webPage = Mid(webPage, 1, Len(webPage) - 6)

                Return webPage
            End Using
        End Function
    End Module
End Namespace
