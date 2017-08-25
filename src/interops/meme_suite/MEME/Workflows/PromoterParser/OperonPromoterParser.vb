﻿#Region "Microsoft.VisualBasic::0e9122a07279eca8fb067e08f872fff0, ..\interops\meme_suite\MEME\Workflows\PromoterParser\OperonPromoterParser.vb"

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

Imports SMRUCC.genomics.Assembly.DOOR
Imports SMRUCC.genomics.ComponentModel.Loci
Imports SMRUCC.genomics.SequenceModel

Namespace Workflows.PromoterParser

    ''' <summary>
    ''' 这个是考虑了操纵子的情况的，只有操纵子的第一个基因才会被取出来
    ''' </summary>
    Public Class OperonPromoterParser : Inherits Workflows.PromoterParser.PromoterParser

        Implements System.IDisposable

        Public Property DoorOperonView As SMRUCC.genomics.Assembly.DOOR.OperonView

        Sub New(GenomeSequenceFastaFile As String, Door As String)
            Me.DoorOperonView = SMRUCC.genomics.Assembly.DOOR.Load(Door).DOOROperonView
            Call InitalizeOperons(Door, OS:=GenomeSequenceFastaFile)
        End Sub

        Private Sub InitalizeOperons(DoorFile As String, OS As String)
            Dim GenomeSeq As FASTA.FastaToken = SMRUCC.genomics.SequenceModel.FASTA.FastaToken.LoadNucleotideData(OS)
            Dim Door As Assembly.DOOR.OperonView = Me.DoorOperonView

            Me.Promoter_150 = CreateObject(150, Door, GenomeSeq)
            Me.Promoter_200 = CreateObject(200, Door, GenomeSeq)
            Me.Promoter_250 = CreateObject(250, Door, GenomeSeq)
            Me.Promoter_300 = CreateObject(300, Door, GenomeSeq)
            Me.Promoter_350 = CreateObject(350, Door, GenomeSeq)
            Me.Promoter_400 = CreateObject(400, Door, GenomeSeq)
            Me.Promoter_450 = CreateObject(450, Door, GenomeSeq)
            Me.Promoter_500 = CreateObject(500, Door, GenomeSeq)
        End Sub

        Private Shared Function CreateObject(SegmentLength As Integer, Door As OperonView, GenomeSeq As IPolymerSequenceModel) As Dictionary(Of String, FASTA.FastaToken)
            Dim LQuery = (From i As Integer
                          In Door.Operons.Sequence.AsParallel
                          Let Operon = Door.Operons(i)
                          Let FirstGene = Operon.InitialX
                          Select Operon.Key,
                              PromoterFasta = GetFASTA(i, SegmentLength, Operon, FirstGene, GenomeSeq)).ToArray
            Dim DictData As Dictionary(Of String, SMRUCC.genomics.SequenceModel.FASTA.FastaToken) =
                LQuery.ToDictionary(Function(obj) obj.Key, elementSelector:=Function(obj) obj.PromoterFasta)
            Return DictData
        End Function

        Private Shared Function GetFASTA(i As Integer,
                                         SegmentLength As Integer,
                                         Operon As Operon,
                                         FirstGene As OperonGene,
                                         GenomeSeq As IPolymerSequenceModel) _
            As SMRUCC.genomics.SequenceModel.FASTA.FastaToken

            Dim PromoterFsa As SequenceModel.FASTA.FastaToken =
                New SequenceModel.FASTA.FastaToken With {
                .Attributes = New String() {
                    $"lcl_{i + 1} [AssociatedOperon={Operon.Key}] [OperonPromoter={FirstGene.Synonym}; {FirstGene.Location.ToString}] [OperonGenes={ViewAPI.GenerateLstIdString(Operon)}]"}}

            Dim Location As NucleotideLocation = FirstGene.Location

            If Location.Strand = Strands.Forward Then '假若是正向链，则不会做任何处理
                PromoterFsa.SequenceData = GenomeSeq.CutSequenceBylength(CInt(Location.Left), SegmentLength).SequenceData  '取上游的序列
            Else
                PromoterFsa.SequenceData = GenomeSeq.ReadComplement(Location.Right, SegmentLength).SequenceData  '取下游，然后再反向互补
            End If

            Return PromoterFsa
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overrides Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub
#End Region

    End Class
End Namespace
