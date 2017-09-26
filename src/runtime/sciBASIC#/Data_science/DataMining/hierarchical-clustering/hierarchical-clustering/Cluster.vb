﻿#Region "Microsoft.VisualBasic::008f877f0901d03814c157c8ab57af29, ..\sciBASIC#\Data_science\DataMining\hierarchical-clustering\hierarchical-clustering\Cluster.vb"

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

Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Data.Graph
Imports Microsoft.VisualBasic.DataMining.HierarchicalClustering
Imports Microsoft.VisualBasic.DataMining.HierarchicalClustering.Hierarchy

'
'*****************************************************************************
' Copyright 2013 Lars Behnke
' <p/>
' Licensed under the Apache License, Version 2.0 (the "License");
' you may not use this file except in compliance with the License.
' You may obtain a copy of the License at
' <p/>
' http://www.apache.org/licenses/LICENSE-2.0
' <p/>
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
' See the License for the specific language governing permissions and
' limitations under the License.
' *****************************************************************************
'

Public Class Cluster : Inherits AbstractTree(Of Cluster)
    Implements INamedValue
    Implements IComparable(Of Cluster)

    Public Property Distance As Distance

    Public ReadOnly Property WeightValue As Double
        Get
            Return Distance.Weight
        End Get
    End Property

    Public ReadOnly Property DistanceValue As Double
        Get
            Return Distance.Distance
        End Get
    End Property

    Public ReadOnly Property LeafNames As List(Of String)

    Public ReadOnly Property TotalDistance As Double
        Get
            Dim dist As Double = If(Distance Is Nothing, 0, Distance.Distance)
            If Childs.Count > 0 Then
                dist += Childs(0).TotalDistance
            End If
            Return dist
        End Get
    End Property

    Public Sub New(name$)
        Label = name
        LeafNames = New List(Of String)
        Childs = New List(Of Cluster)
        Distance = New Distance
    End Sub

    Public Sub AddLeafName(lname$)
        LeafNames.Add(lname)
    End Sub

    Public Sub AppendLeafNames(lnames As IEnumerable(Of String))
        LeafNames.AddRange(lnames)
    End Sub

    Public Sub AddChild(cluster As Cluster)
        Childs.Add(cluster)
    End Sub

    Public Function Contains(cluster As Cluster) As Boolean
        Return Childs.Contains(cluster)
    End Function

    Public Overrides Function ToString() As String
        Return "Cluster " & Label
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        ElseIf Me.GetType() IsNot obj.GetType() Then
            Return False
        Else
            Return CompareTo(DirectCast(obj, Cluster))
        End If
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return If(Label Is Nothing, 0, Label.GetHashCode())
    End Function

    Public Function CompareTo(other As Cluster) As Integer Implements IComparable(Of Cluster).CompareTo
        If other Is Nothing Then
            Return 1
        End If
        If Me Is other Then
            Return 0
        End If

        If Label Is Nothing Then
            If other.Label IsNot Nothing Then
                Return -1
            Else
                Return 0
            End If
        ElseIf other.Label Is Nothing Then
            Return 1
        Else
            Return Label.CompareTo(other.Label)
        End If
    End Function
End Class
