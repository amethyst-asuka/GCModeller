﻿#Region "Microsoft.VisualBasic::0fbdb46574669a1f724589f9ef1ed678, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\ComponentModel\Settings\Inf\Section.vb"

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

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.Collection

Namespace ComponentModel.Settings.Inf

    Public Class Section

        <XmlAttribute> Public Property Name As String
        <XmlElement> Public Property Items As HashValue()
            Get
                Return _internalTable.Values.ToArray
            End Get
            Set(value As HashValue())
                If value Is Nothing Then
                    value = New HashValue() {}
                End If

                _internalTable = value.ToDictionary(Function(x) x.key.ToLower)
            End Set
        End Property

        Dim _internalTable As Dictionary(Of HashValue)

        Public Function GetValue(Key As String) As String
            Key = Key.ToLower

            If _internalTable.ContainsKey(Key) Then
                Return _internalTable(Key).value
            Else
                Return ""
            End If
        End Function

        ''' <summary>
        ''' 不存在则自动添加
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="value"></param>
        Public Sub SetValue(Name As String, value As String)
            Dim KeyFind As String = Name.ToLower

            If _internalTable.ContainsKey(KeyFind) Then
                Call _internalTable.Remove(KeyFind)
            End If

            Call _internalTable.Add(KeyFind, New HashValue(Name, value))
        End Sub
    End Class
End Namespace
