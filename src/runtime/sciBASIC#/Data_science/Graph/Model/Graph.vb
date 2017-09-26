﻿#Region "Microsoft.VisualBasic::77c0a0dc940244d91e3fc03d4f0d5d5a, ..\sciBASIC#\gr\Datavisualization.Network\Graph\Graph.vb"

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
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq

''' <summary>
''' A graph ``G = (V, E)`` consists of a set V of vertices and a set E edges, that is, unordered
''' pairs Of vertices. Unless explicitly stated otherwise, we assume that the graph Is simple,
''' that Is, it has no multiple edges And no self-loops.
''' </summary>
Public Class Graph : Implements IEnumerable(Of Edge)

#Region "Let G=(V, E) be a simple graph"
    Dim edges As New Dictionary(Of Edge)
    Dim vertices As New Dictionary(Of Vertex)
    Dim buffer As New HandledList(Of Vertex)
#End Region

    Public ReadOnly Property Size As (Vertex%, Edges%)
        Get
            Return (vertices.Count, edges.Count)
        End Get
    End Property

    Public ReadOnly Property Vertex As Vertex()
        Get
            Return buffer
        End Get
    End Property

    Public Function GetConnectedVertex() As Vertex()
        Return edges.Values _
            .Select(Function(e) {e.U, e.V}) _
            .IteratesALL _
            .Distinct _
            .ToArray
    End Function

    ''' <summary>
    ''' <see cref="Data.Graph.Vertex.ID"/> should contains its index value before this method was called.
    ''' </summary>
    ''' <param name="u"></param>
    ''' <returns></returns>
    Public Function AddVertex(u As Vertex) As Graph
        vertices += u
        buffer.Add(u)
        Return Me
    End Function

    Public Function ExistVertex(name$) As Boolean
        Return vertices.ContainsKey(name)
    End Function

    Public Function AddVertex(label$) As Vertex
        With New Vertex With {
            .ID = buffer.GetAvailablePos,
            .Label = label
        }
            Call AddVertex(.ref)
            Return .ref
        End With
    End Function

    Public Function AddEdge(u As Vertex, v As Vertex, Optional weight# = 0) As Graph
        edges += New Edge With {
            .U = u,
            .V = v,
            .Weight = weight
        }
        If Not vertices.ContainsKey(u.Label) Then
            vertices += u
            buffer.Add(u)
        End If
        If Not vertices.ContainsKey(v.Label) Then
            vertices += v
            buffer.Add(v)
        End If

        Return Me
    End Function

    Public Function AddEdge(i%, j%, Optional weight# = 0) As Graph
        edges += New Edge With {
            .U = buffer(i),
            .V = buffer(j),
            .Weight = weight
        }

        Return Me
    End Function

    Public Function AddEdge(u$, v$, Optional weight# = 0) As Graph
        edges += New Edge With {
            .U = vertices(u),
            .V = vertices(v),
            .Weight = weight
        }

        Return Me
    End Function

    ''' <summary>
    ''' 只会删除边，并不会删除节点<paramref name="U"/>和<paramref name="V"/>
    ''' </summary>
    ''' <param name="U"></param>
    ''' <param name="V"></param>
    ''' <returns></returns>
    Public Function Delete(U As Vertex, V As Vertex) As Graph
        Return Delete(U.ID, V.ID)
    End Function

    Public Function Delete(u$, v$) As Graph
        Return Delete(vertices(u).ID, vertices(v).ID)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function Delete(u%, v%) As Graph
        Dim key$ = $"{u}-{v}"

        If edges.ContainsKey(key) Then
            Call edges.Remove(key)
        End If

        Return Me
    End Function

    Public Iterator Function GetEnumerator() As IEnumerator(Of Edge) Implements IEnumerable(Of Edge).GetEnumerator
        For Each edge As Edge In edges.Values
            Yield edge
        Next
    End Function

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Yield GetEnumerator()
    End Function
End Class
