﻿Imports LANS.SystemsBiology.GCModeller.ModellingEngine.Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Bacterial_GENOME
Imports Microsoft.VisualBasic.Extensions
Imports Microsoft.VisualBasic.Terminal.STDIO
Imports Microsoft.VisualBasic
Imports LANS.SystemsBiology.GCModeller.ModellingEngine.Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements
Imports Microsoft.VisualBasic.ComponentModel

Namespace Builder

    Public Class RegulationNetworkBuilder : Inherits Builder.IBuilder

        Sub New(MetaCyc As LANS.SystemsBiology.Assembly.MetaCyc.File.FileSystem.DatabaseLoadder, Model As Assembly.DocumentFormat.GCMarkupLanguage.BacterialModel)
            MyBase.New(MetaCyc, Model)
        End Sub

        Public Overrides Function Invoke() As BacterialModel
            Call BuildRegulationNetwork(MetaCyc, Model)

            Return Me.Model
        End Function

        ''' <summary>
        ''' 创建基因表达调控网络，在构造出了基因对象和转录单元对象之后进行调用
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub BuildRegulationNetwork(MetaCyc As LANS.SystemsBiology.Assembly.MetaCyc.File.FileSystem.DatabaseLoadder, Model As Assembly.DocumentFormat.GCMarkupLanguage.BacterialModel)
            Dim Regulations As LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Regulations = MetaCyc.GetRegulations
            Dim AllGeneList As String() = MetaCyc.GetGenes.Index
            Dim TUList As List(Of GCML_Documents.XmlElements.Bacterial_GENOME.TranscriptUnit) = Model.BacteriaGenome.TransUnits.ToList

            For Each regulation In Regulations
                Select Case GCML_Documents.XmlElements.SignalTransductions.Regulator.GetRegulationsType(regulation.Types)
                    Case GCML_Documents.XmlElements.SignalTransductions.Regulator.RegulationTypes.TranscriptionRegulation Or GCML_Documents.XmlElements.SignalTransductions.Regulator.RegulationTypes.TranslationRegulation '在转录单元对象中查找
                        Dim Regulator As GCML_Documents.XmlElements.SignalTransductions.Regulator = New GCML_Documents.XmlElements.SignalTransductions.Regulator With
                                                     {
                                                         .Identifier = regulation.Identifier,
                                                         .Activation = String.Equals(regulation.Mode, "+"),
                                                         .CommonName = regulation.CommonName}
                        Dim Target = GetTransUnit(regulation)

                        If Target Is Nothing Then Continue For

                        For Each TU In Target '一个基因对象，可能会包含在多个转录单元之中
                            TU._add_Regulator(regulation.RegulatedEntity, Regulator)
                        Next
                    Case GCML_Documents.XmlElements.SignalTransductions.Regulator.RegulationTypes.EnzymeActivityRegulation '在代谢网络中查找
                    Case GCML_Documents.XmlElements.SignalTransductions.Regulator.RegulationTypes.Regulation '未知，仅做下记录
                        Call Printf("[WARN] Unknown regulation: '%s'", regulation.Identifier)
                End Select
            Next
        End Sub

        ''' <summary>
        ''' 根据Regulation中的对象查找出相应的转录单元对象
        ''' </summary>
        ''' <param name="Regulation"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetTransUnit(Regulation As LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots.Regulation) As GCML_Documents.XmlElements.Bacterial_GENOME.TranscriptUnit()
            Dim RegulatedObject As LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots.Object = Regulation.GetRegulatedObject(MetaCyc)  '获取目标被调控对象
            Dim [Handles] = RegulatedObject.GetHandles(Model)

            If [Handles].IsNullOrEmpty Then
                If RegulatedObject.Table = LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots.Object.Tables.genes Then '目标对象为一个基因，并且没有与之相对应的转录单元对象，则创建一个新的转录单元对象
                    Printf("[INFO] TU_NOT_FOUND: create a new transcript unit for gene object: %s", RegulatedObject.Identifier)

                    Dim Gene = RegulatedObject.Select(Of LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots.Gene, GeneObject)(Model.BacteriaGenome.Genes)
                    Dim TU As GCML_Documents.XmlElements.Bacterial_GENOME.TranscriptUnit =
                        New GCML_Documents.XmlElements.Bacterial_GENOME.TranscriptUnit With
                        {
                            .GeneCluster = New KeyValuePair() {
                                New KeyValuePair With {
                                    .Value = Gene.AccessionId}
                        }, .Identifier = Gene.Identifier & "_TU"} '转录单元中进含有单个基因对象
                    Call Model.BacteriaGenome.TransUnits.Add(TU)

                    Return New GCML_Documents.XmlElements.Bacterial_GENOME.TranscriptUnit() {TU}
                End If
            Else
                If RegulatedObject.Table = LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots.Object.Tables.transunits Then
                    Return Take(Of LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots.TransUnit, Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Bacterial_GENOME.TranscriptUnit)(Model.BacteriaGenome.TransUnits, [Handles])
                ElseIf RegulatedObject.Table = LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots.Object.Tables.genes Then
                    Console.WriteLine("[NOT_IMPLEMENTS] takes.genes")
                ElseIf RegulatedObject.Table = LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots.Object.Tables.promoters Then
                    Console.WriteLine("[NOT_IMPLEMENTS] takes.promoters")
                ElseIf RegulatedObject.Table = LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots.Object.Tables.terminators Then
                    Console.WriteLine("[NOT_IMPLEMENTS] takes.terminators")
                ElseIf RegulatedObject.Table = LANS.SystemsBiology.Assembly.MetaCyc.File.DataFiles.Slots.Object.Tables.trna Then
                    Console.WriteLine("[NOT_IMPLEMENTS] takes.trna")
                Else
                    Return Nothing
                End If
            End If

            Return Nothing
        End Function
    End Class
End Namespace