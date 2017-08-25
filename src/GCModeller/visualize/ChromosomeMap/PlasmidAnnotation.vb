﻿#Region "Microsoft.VisualBasic::ca676fbb39fddcf735b93507d76a24e4, ..\visualize\ChromosomeMap\PlasmidAnnotation.vb"

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

Imports System.Drawing
Imports System.Text
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Data.csv.Extensions
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Extensions
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Oracle.Java.IO.Properties.Reflector
Imports SMRUCC.genomics.Assembly.NCBI.GenBank
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.CsvExports
Imports SMRUCC.genomics.ComponentModel
Imports SMRUCC.genomics.SequenceModel.NucleotideModels

<[Namespace]("PlasmidAnnotations")>
Public Class PlasmidAnnotation : Implements IGeneBrief

    ''' <summary>
    ''' 基因号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ORF_ID As String Implements INamedValue.Key
    Public Property Strand As String
    <Column("Gene-Length")> Public Property Length As Integer Implements ICOGDigest.Length
    ''' <summary>
    ''' 基因核酸序列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Column("Gene")> Public Property GeneNA As String
    ''' <summary>
    ''' 蛋白质序列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Protein As String
    Public Property ST As Integer
    Public Property SP As Integer
    ''' <summary>
    ''' 简写的基因名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Gene_name As String
    ''' <summary>
    ''' 蛋白质功能注释
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property product As String Implements ICOGDigest.Product
    <Column("GO-I")> Public Property GOI As String
    <Column("GO-ID")> Public Property GO_ID As String
    Public Property GO_name As String
    Public Property GO_discription As String
    <Column("Protein family membership")> Public Property Family As String
    <Column("Protein family membership discription")> Public Property discription As String
    <Column("COG-NO.")> Public Property COG_NO As String Implements ICOGDigest.COG
    <Column("COG-cat")> Public Property COG_cat As String
    <Column("COG-annotation")> Public Property COG_annotation As String
    Public Property Identity As String
    <Column("qst.")> Public Property qst As String
    <Column("qsp.")> Public Property qsp As String
    <Column("sst.")> Public Property sst As String
    <Column("ssp.")> Public Property ssp As String
    Public Property subject_length As String
    <Column("E-value")> Public Property Evalue As String
    Public Property Protein_len As String

    Public Property Location As SMRUCC.genomics.ComponentModel.Loci.NucleotideLocation Implements IGeneBrief.Location
        Get
            Return New SMRUCC.genomics.ComponentModel.Loci.NucleotideLocation(ST, SP, Strand)
        End Get
        Set(value As SMRUCC.genomics.ComponentModel.Loci.NucleotideLocation)
            If Not value Is Nothing Then
                ST = value.Left
                SP = value.Right
            End If
        End Set
    End Property

    ''' <summary>
    ''' 导出蛋白质的序列信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <ExportAPI("Export.Orf")>
    Public Shared Function ExportProteinFasta(data As IEnumerable(Of PlasmidAnnotation),
                                              <Parameter("Id.Only")>
                                              Optional JustId As Boolean = False) As SequenceModel.FASTA.FastaFile
        Dim GetTitle As Func(Of PlasmidAnnotation, String()) = JustId.[If](
            Function(Gene As PlasmidAnnotation) {Gene.ORF_ID},
            Function(Gene As PlasmidAnnotation) New String() {Gene.ORF_ID, Gene.Gene_name, Gene.product})

        Dim LQuery = (From PlasmidGene As PlasmidAnnotation
                      In data
                      Where Not String.IsNullOrEmpty(PlasmidGene.Protein)
                      Select New SequenceModel.FASTA.FastaToken With {
                          .Attributes = GetTitle(PlasmidGene),
                          .SequenceData = PlasmidGene.Protein}).ToArray
        Return CType(LQuery, SequenceModel.FASTA.FastaFile)
    End Function

    <ExportAPI("read.csv.plasmid_data")>
    Public Shared Function READ_PlasmidData(path As String) As PlasmidAnnotation()
        Return path.LoadCsv(Of PlasmidAnnotation)(False).ToArray
    End Function

    <ExportAPI("export.as_ncbi_annotation")>
    Public Shared Function ExportAnnotations(data As Generic.IEnumerable(Of PlasmidAnnotation), Optional saveto As String = "") As GeneDumpInfo()
        Dim LQuery = (From item As PlasmidAnnotation In data
                      Where Not String.IsNullOrEmpty(item.Protein)
                      Let gc As Double = GC_Content(New NucleicAcid(item.GeneNA).ToArray)
                      Select New GeneDumpInfo With {
                          .CDS = item.GeneNA,
                          .GC_Content = gc,
                          .COG = item.COG_NO,
                          .Strand = item.Strand,
                          .CommonName = item.product,
                          .GeneName = item.Gene_name,
                          .LocusID = item.ORF_ID,
                          .Translation = item.Protein,
                          .Left = item.Location.Left,
                          .Right = item.Location.Right}).ToArray
        If Not String.IsNullOrEmpty(saveto) Then
            Call LQuery.SaveTo(saveto, False)
        End If

        Return LQuery
    End Function
End Class

