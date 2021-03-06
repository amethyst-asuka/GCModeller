﻿#Region "Microsoft.VisualBasic::81fb027e60621eb819770b3fa71951a3, ..\core\Bio.Assembly\ContextModel\PromoterRegionParser.vb"

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

Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.TagData
Imports Microsoft.VisualBasic.Extensions
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.TabularFormat
Imports SMRUCC.genomics.ComponentModel.Loci
Imports SMRUCC.genomics.SequenceModel
Imports SMRUCC.genomics.SequenceModel.FASTA
Imports SMRUCC.genomics.SequenceModel.NucleotideModels

Namespace ContextModel

    ''' <summary>
    ''' 直接从基因的启动子区选取序列数据以及外加操纵子的第一个基因的启动子序列
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <Package("Parser.Gene.Promoter", Publisher:="xie.guigang@gmail.com")>
    Public Class PromoterRegionParser

        Public Shared ReadOnly Property PrefixLength As IReadOnlyList(Of Integer) = {100, 150, 200, 250, 300, 400, 500}

        Public ReadOnly Property PromoterRegions As IntegerTagged(Of Dictionary(Of String, FastaToken))()
        ReadOnly lengthIndex As New Index(Of Integer)(PrefixLength)

        ''' <summary>
        ''' 基因组的Fasta核酸序列
        ''' </summary>
        ''' <param name="nt">全基因组序列</param>
        ''' <remarks></remarks>
        Sub New(nt As FastaToken, PTT As PTT)
            Dim genome As IPolymerSequenceModel = nt
            Dim regions(PrefixLength.GetLength - 1) As IntegerTagged(Of Dictionary(Of String, FastaToken))
            Dim i As int = 0

            genome.SequenceData = genome.SequenceData.ToUpper

            For Each l% In PrefixLength
                regions(++i) = New IntegerTagged(Of Dictionary(Of String, FastaToken)) With {
                    .Tag = l,
                    .value = CreateObject(l, PTT, genome)
                }
            Next

            PromoterRegions = regions
        End Sub

        Sub New(genome As PTTDbLoader)
            Call Me.New(genome.GenomeFasta, genome.ORF_PTT)
        End Sub

        ''' <summary>
        ''' 解析出所有基因前面的序列片段
        ''' </summary>
        ''' <param name="Length"></param>
        ''' <param name="PTT"></param>
        ''' <param name="nt"></param>
        ''' <returns></returns>
        Private Shared Function CreateObject(Length As Integer, PTT As PTT, nt As IPolymerSequenceModel) As Dictionary(Of String, FASTA.FastaToken)
            Dim LQuery = (From gene As ComponentModels.GeneBrief
                          In PTT.GeneObjects.AsParallel
                          Select gene.Synonym,
                              Promoter = GetFASTA(gene, nt, Length)).ToArray
            Dim DictData As Dictionary(Of String, FastaToken) =
                LQuery.ToDictionary(Function(obj) obj.Synonym,
                                    Function(obj) obj.Promoter)
            Return DictData
        End Function

        ''' <summary>
        ''' 在这个函数之中，位点的计算的时候会有一个碱基的偏移量是因为为了不将起始密码子ATG之中的A包含在结果序列之中
        ''' </summary>
        ''' <param name="gene"></param>
        ''' <param name="nt"></param>
        ''' <param name="len%"></param>
        ''' <returns></returns>
        Private Shared Function GetFASTA(gene As ComponentModels.GeneBrief, nt As IPolymerSequenceModel, len%) As FastaToken
            Dim loci As NucleotideLocation = gene.Location

            Call loci.Normalization()

            If loci.Strand = Strands.Forward Then
                loci = New NucleotideLocation(loci.Left - len, loci.Left - 1)  ' 正向序列是上游，无需额外处理
            Else
                loci = New NucleotideLocation(loci.Right + 1, loci.Right + len, ComplementStrand:=True)  '反向序列是下游，需要额外小心
            End If

            Dim site As SimpleSegment = nt.CutSequenceCircular(loci)
            Dim attrs$() = If(
                gene.Product.StringEmpty,
                {gene.Synonym & " " & site.ID},
                {gene.Synonym & " " & site.ID, gene.Product})
            Dim promoterRegion As New FastaToken With {
                .Attributes = attrs,
                .SequenceData = site.SequenceData
            }

            Return promoterRegion
        End Function

        Public Function GetRegionCollectionByLength(l%) As Dictionary(Of String, FastaToken)
            Dim i As Integer = Me.lengthIndex.IndexOf(l)
            Return Me.PromoterRegions(i%)
        End Function

        Public Function GetSequenceById(lstId As IEnumerable(Of String), <Parameter("Len")> Length As Integer) As FASTA.FastaFile
            Return GetSequenceById(Me, lstId, Length)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Promoter"></param>
        ''' <param name="idList"></param>
        ''' <param name="Length"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ExportAPI("Get.Sequence.By.Id")>
        Public Shared Function GetSequenceById(Promoter As PromoterRegionParser,
                                               <Parameter("id.list", "The gene id list.")> idList As IEnumerable(Of String),
                                               <Parameter("Len")> Optional Length As Integer = 150) As FASTA.FastaFile
            If Not ContainsLength(Length) Then
                Call $"The promoter region length {Length} is not valid, using default value is 150bp.".__DEBUG_ECHO
                Length = 150
            End If

            Dim ListData As New List(Of String)(idList)
            Dim out As New FastaFile(From Fasta In Promoter.GetRegionCollectionByLength(Length).AsParallel Where ListData.IndexOf(Fasta.Key) > -1 Select Fasta.Value)

            Return out
        End Function

        Private Shared Function ContainsLength(l As Integer) As Boolean
            Return Array.IndexOf(PrefixLength, l) > -1
        End Function
    End Class
End Namespace
