﻿#Region "Microsoft.VisualBasic::206d2a895cc532713f57becb2c982947, ..\sciBASIC#\Data_science\DataMining\network\NeuralNetwork\ModelAPI.vb"

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

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.DataMining.NeuralNetwork
Imports Microsoft.VisualBasic.Data.visualize.Network
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Language

Namespace NeuralNetwork.Models

    ''' <summary>
    ''' 网络可视化工具
    ''' </summary>
    Public Module NetworkModelAPI

        <Extension> Public Function VisualizeModel(net As NeuralNetwork.Network) As FileStream.NetworkTables
            Dim network As New FileStream.NetworkTables
            Dim hash = (New List(Of Neuron) + net.HiddenLayer + net.InputLayer + net.OutputLayer) _
                .SeqIterator _
                .ToDictionary(Function(x) x.value,
                              Function(x) x.i)

            network += net.HiddenLayer.ToArray(Function(x) x.__node(NameOf(net.HiddenLayer), hash))
            network += net.InputLayer.ToArray(Function(x) x.__node(NameOf(net.InputLayer), hash))
            network += net.OutputLayer.ToArray(Function(x) x.__node(NameOf(net.OutputLayer), hash))

            network += net.HiddenLayer.ToArray(Function(x) x.__edges(NameOf(net.HiddenLayer), hash)).IteratesALL
            network += net.InputLayer.ToArray(Function(x) x.__edges(NameOf(net.InputLayer), hash)).IteratesALL
            network += net.OutputLayer.ToArray(Function(x) x.__edges(NameOf(net.OutputLayer), hash)).IteratesALL

            Return network
        End Function

        <Extension>
        Private Function __node(neuron As Neuron, type As String, uidhash As Dictionary(Of Neuron, Integer)) As FileStream.Node
            Dim uid As String = uidhash(neuron).ToString
            Return New FileStream.Node With {
                .ID = uid,
                .NodeType = type
            }
        End Function

        <Extension>
        Private Function __edges(neuron As Neuron, type As String, uidHash As Dictionary(Of Neuron, Integer)) As FileStream.NetworkEdge()
            Dim LQuery = (From c As Synapse
                          In neuron.InputSynapses
                          Where c.Weight <> 0R  ' 忽略掉没有链接强度的神经元链接
                          Let itName As String = $"{type}-{NameOf(neuron.InputSynapses)}"
                          Select c.__synapse(itName, uidHash)).AsList +
                          (From c As Synapse
                           In neuron.OutputSynapses
                           Where c.Weight <> 0R
                           Select c.__synapse(type & "-" & NameOf(neuron.OutputSynapses), uidHash))

            Return LQuery.ToArray
        End Function

        <Extension>
        Private Function __synapse(synapse As Synapse, type As String, uidHash As Dictionary(Of Neuron, Integer)) As FileStream.NetworkEdge
            Return New FileStream.NetworkEdge With {
                .value = synapse.Weight,
                .FromNode = CStr(uidHash(synapse.InputNeuron)),
                .ToNode = CStr(uidHash(synapse.OutputNeuron)),
                .Interaction = type
            }
        End Function
    End Module
End Namespace
