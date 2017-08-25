﻿#Region "Microsoft.VisualBasic::04ca4e851dfd0973f91fa5a673625d4a, ..\GCModeller\engine\GCModeller\EngineSystem\ObjectModels\NodesMapping\EnzymePool.vb"

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
Imports SMRUCC.genomics.GCModeller.Assembly

Namespace EngineSystem.ObjectModels.PoolMappings

    ''' <summary>
    ''' 管理突变与进化过程之中的映射关系
    ''' </summary>
    ''' <remarks></remarks>
    Public Class EnzymePool : Inherits PoolMappings.MappingPool(Of PoolMappings.EnzymeClass, EngineSystem.ObjectModels.Feature.MetabolismEnzyme)
        Implements IReadOnlyDictionary(Of String, List(Of Feature.MetabolismEnzyme))
        Implements IDisposable

        Sub New(ReactionModels As Generic.IEnumerable(Of GCMarkupLanguage.GCML_Documents.XmlElements.Metabolism.Reaction),
                Enzymes As Generic.IEnumerable(Of EngineSystem.ObjectModels.Feature.MetabolismEnzyme))

            Me._MappingHandlers = (From strId As String In (From item In ReactionModels Select item.EC Distinct).ToArray.AsParallel Select New PoolMappings.EnzymeClass(strId)).ToArray.WriteAddress
            Me.__mappingPool = New Dictionary(Of String, List(Of Feature.MetabolismEnzyme))
            For Each Item As PoolMappings.EnzymeClass In _MappingHandlers
                Call __mappingPool.Add(Item.ECNumber, New List(Of EngineSystem.ObjectModels.Feature.MetabolismEnzyme))
            Next
            For Each Enzyme In Enzymes
                Call __mappingPool(Enzyme.ECNumber).Add(Enzyme)
            Next

            Call UpdateCache()
        End Sub
    End Class
End Namespace
