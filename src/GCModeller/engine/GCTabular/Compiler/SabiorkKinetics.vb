﻿#Region "Microsoft.VisualBasic::ca13cf777ccb6018e81bdcb9a9722c77, ..\GCModeller\engine\GCTabular\Compiler\SabiorkKinetics.vb"

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

Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Data.csv.Extensions
Imports Microsoft.VisualBasic.Language
Imports SMRUCC.genomics.Assembly
Imports SMRUCC.genomics.Assembly.Expasy.AnnotationsTool
Imports SMRUCC.genomics.Assembly.KEGG.DBGET
Imports SMRUCC.genomics.Assembly.MetaCyc.File.FileSystem
Imports SMRUCC.genomics.Assembly.MetaCyc.Schema
Imports SMRUCC.genomics.Data.SabiorkKineticLaws.TabularDump

Namespace Compiler.Components

    Public Class SabiorkKinetics

        Dim _ModelLoader As FileStream.IO.XmlresxLoader
        Dim _KineticsData As EnzymeCatalystKineticLaw()
        Dim _EnzymeModify As ModifierKinetics()
        Dim _EuqationEquals As EquationEquals
        Dim _ExpasyClass As T_EnzymeClass_BLAST_OUT()

        Sub New(ModelLoader As FileStream.IO.XmlresxLoader, SabiorkKineticsCsv As String, EnzymeModifyKinetics As String, ExpasyClass As T_EnzymeClass_BLAST_OUT())
            _ModelLoader = ModelLoader
            _KineticsData = (From record In SabiorkKineticsCsv.LoadCsv(Of EnzymeCatalystKineticLaw)(False) Where Not String.IsNullOrEmpty(record.KEGGReactionId) Select record).ToArray
            _EnzymeModify = EnzymeModifyKinetics.LoadCsv(Of ModifierKinetics)(False).ToArray
            _ExpasyClass = ExpasyClass
        End Sub

        ''' <summary>
        ''' {KEGGReaction, MetaCycReactions()}
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function BuildEqualsTable(MetaCyc As DatabaseLoadder,
                                          KEGGCompounds As bGetObject.Compound(),
                                          KEGGReactions As bGetObject.Reaction(),
                                          ByRef EffectorMapping As EffectorMap()) As Key_strArrayValuePair()

            Dim MetaCycReactions = (From item In MetaCyc.GetReactions Select Metabolism.Reaction.CreateObject(item)).ToArray
            Dim List As List(Of Key_strArrayValuePair) = New List(Of Key_strArrayValuePair)

            KEGGReactions = (From KineticsRecord In Me._KineticsData Let KEGGReaction = KEGGReactions.GetItem(KineticsRecord.KEGGReactionId) Where Not KEGGReaction Is Nothing Select KEGGReaction).ToArray
            _EuqationEquals = New EquationEquals(Me._ModelLoader.MetabolitesModel, KEGGCompounds)
            EffectorMapping = _EuqationEquals.CompoundMapping

            For Each KEGGReaction In KEGGReactions
                Dim LQuery = (From MetaCycReaction In MetaCycReactions.AsParallel Where _EuqationEquals.Equals(KEGGReaction.Equation, MetaCycEquation:=MetaCycReaction, Explicit:=False) Select MetaCycReaction).ToArray
                If Not LQuery.IsNullOrEmpty Then
                    Call List.Add(New Microsoft.VisualBasic.ComponentModel.Key_strArrayValuePair With {.Key = KEGGReaction.Entry, .Value = (From item In LQuery Select item.Identifier).ToArray})
                End If
            Next

            Return List.ToArray
        End Function

        Public Sub InvokeMethod(MetaCyc As DatabaseLoadder, KEGGCompounds As bGetObject.Compound(), KEGGReactions As bGetObject.Reaction())
            Dim ChunkList As List(Of EnzymeCatalystKineticLaw) = New List(Of EnzymeCatalystKineticLaw)
            Dim EffectorMapping As EffectorMap() = Nothing
            Dim MapTable = BuildEqualsTable(MetaCyc, KEGGCompounds, KEGGReactions, EffectorMapping)

            For Each MetabolismFlux In _ModelLoader.MetabolismModel
                If MetabolismFlux.Enzymes.IsNullOrEmpty Then
                    Continue For
                End If

                Dim UniprotId = GetUniprotIDlist(MetabolismFlux.Enzymes)
                Dim KEGGReactionId As String() = (From item In MapTable Where Array.IndexOf(item.Value, MetabolismFlux.Identifier) > -1 Select item.Key).ToArray

                For Each id As String In KEGGReactionId
                    Dim LQuery = (From Enzyme In UniprotId
                                  Let data = SelectKinetics(EnzymeId:=Enzyme.uniprot, ReactionId:=id, KineticsData:=_KineticsData)
                                  Where data IsNot Nothing
                                  Select New EnzymeCatalystKineticLaw With {
                                      .Enzyme = Enzyme.ProteinId,
                                      .Km = data.Km,
                                      .PH = data.PH,
                                      .KineticRecord = MetabolismFlux.Identifier,
                                      .Metabolite = EffectorMapping.GetItem(data.KEGGCompoundId).MetaCycId,
                                      .Temperature = data.Temperature,
                                      .Kcat = data.Kcat}).ToArray

                    If Not LQuery.IsNullOrEmpty Then
                        Call ChunkList.AddRange(LQuery)
                    End If
                Next
            Next

            If _ModelLoader.Enzymes.IsNullOrEmpty Then
                _ModelLoader.Enzymes = New List(Of EnzymeCatalystKineticLaw)
            End If
            Call _ModelLoader.Enzymes.AddRange(ChunkList)
        End Sub

        Private Function GetUniprotIDlist(Enzymes As String()) As T_EnzymeClass_BLAST_OUT()
            Dim ChunkBuffer = (From NCBI_id As String
                               In Enzymes
                               Let records = _ExpasyClass.GetItems(NCBI_id)
                               Select (From item As T_EnzymeClass_BLAST_OUT
                                       In records
                                       Select item).ToArray).ToArray

            Dim ChunkList As List(Of T_EnzymeClass_BLAST_OUT) = New List(Of T_EnzymeClass_BLAST_OUT)
            For Each Line In ChunkBuffer
                If Not Line.IsNullOrEmpty Then Call ChunkList.AddRange(Line)
            Next
            Return ChunkList.ToArray
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="EnzymeId">UniprotId</param>
        ''' <param name="ReactionId">Kegg.Reaction Id</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function SelectKinetics(EnzymeId As String, ReactionId As String, KineticsData As EnzymeCatalystKineticLaw()) As EnzymeCatalystKineticLaw
            Dim LQuery = From item In KineticsData Where String.Equals(item.KEGGReactionId, ReactionId) AndAlso String.Equals(item.Uniprot, EnzymeId) Select item '
            Return LQuery.FirstOrDefault
        End Function
    End Class
End Namespace
