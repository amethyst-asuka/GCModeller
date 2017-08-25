﻿#Region "Microsoft.VisualBasic::29f7ab3a7c33a5872d61f32e9a86f209, ..\sciBASIC#\mime\application%json\Parser\JsonObject.vb"

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

Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Linq

Namespace Parser

    ''' <summary>
    ''' Dictionary/Array in javascript
    ''' </summary>
    Public Class JsonObject : Inherits JsonElement
        Implements IEnumerable(Of NamedValue(Of JsonElement))

        Dim array As New Dictionary(Of String, JsonElement)

        Public Sub Add(key As String, element As JsonElement)
            Call array.Add(key, element)
        End Sub

        Public Sub Add(key$, value$)
            Call array.Add(key, New JsonValue(value))
        End Sub

        Default Public Overloads Property Item(key As String) As JsonElement
            Get
                Return array(key)
            End Get
            Set(value As JsonElement)
                array(key) = value
            End Set
        End Property

        Public Function Remove(key As String) As Boolean
            Return array.Remove(key)
        End Function

        Public Function ContainsKey(key As String) As Boolean
            Return array.ContainsKey(key)
        End Function

        Public Function ContainsElement(element As JsonElement) As Boolean
            Return array.ContainsValue(element)
        End Function

        Public Overrides Function ToString() As String
            Return "Class::[" & array.Keys.JoinBy(", ") & "]"
        End Function

        Public Overrides Function BuildJsonString() As String
            Dim a As New StringBuilder
            Dim array$() = Me _
                .array _
                .ToArray(Function(kp) $"""{kp.Key}"": {kp.Value.BuildJsonString}")

            Call a.AppendLine("{")
            Call a.AppendLine(array.JoinBy("," & vbLf))
            Call a.AppendLine("}")

            Return a.ToString
        End Function

        Public Iterator Function GetEnumerator() As IEnumerator(Of NamedValue(Of JsonElement)) Implements IEnumerable(Of NamedValue(Of JsonElement)).GetEnumerator
            For Each kp As KeyValuePair(Of String, JsonElement) In array
                Yield New NamedValue(Of JsonElement) With {
                .Name = kp.Key,
                .Value = kp.Value
            }
            Next
        End Function

        Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function
    End Class
End Namespace
