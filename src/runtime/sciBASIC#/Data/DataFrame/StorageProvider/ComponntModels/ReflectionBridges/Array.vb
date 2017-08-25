﻿#Region "Microsoft.VisualBasic::cd474d7d6681032cd14f851c45271326, ..\sciBASIC#\Data\DataFrame\StorageProvider\ComponntModels\ReflectionBridges\Array.vb"

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

Imports System.Reflection
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Linq

Namespace StorageProvider.ComponentModels

    Public Class CollectionColumn : Inherits StorageProvider

        Public Property ArrayDefine As CollectionAttribute

        Public Overrides ReadOnly Property Name As String
            Get
                Return ArrayDefine.Name
            End Get
        End Property

        Public Overrides ReadOnly Property ProviderId As ProviderIds
            Get
                Return ProviderIds.CollectionColumn
            End Get
        End Property

        Private Sub New(attr As CollectionAttribute, BindProperty As PropertyInfo, LoadMethod As Func(Of String, Object))
            Call MyBase.New(BindProperty, LoadMethod)
            Me.ArrayDefine = attr
        End Sub

        Public Shared Function CreateObject(attr As CollectionAttribute, BindProperty As PropertyInfo, ElementType As Type) As CollectionColumn
            Dim LoadData As New __createArray(ElementType, attr.Delimiter)
            Return New CollectionColumn(attr, BindProperty, AddressOf LoadData.LoadData)
        End Function

        Private Class __createArray

            Dim Cast As Func(Of String, Object)
            Dim Delimiter As String
            Dim Element As Type

            Sub New(type As Type, delimiter As String)
                Me.Delimiter = delimiter
                Me.Element = type

                Cast = Scripting.CasterString(type)
            End Sub

            Public Function LoadData(cellData As String) As Object
                If String.IsNullOrEmpty(cellData) Then
                    Return Nothing
                End If
                Dim Tokens As String() = Strings.Split(cellData, Delimiter)
                Dim array As Object() = Tokens.ToArray(Cast)
                Return Scripting.InputHandler.DirectCast(array, Element)
            End Function

            Public Overrides Function ToString() As String
                Return Element.FullName
            End Function
        End Class

        Public Overrides Function ToString([object] As Object) As String
            If [object] Is Nothing Then
                Return ""
            End If

            Dim array$() = Scripting _
                .CastArray(Of Object)([object]) _
                .ToArray(AddressOf Scripting.ToString)
            Return String.Join(ArrayDefine.Delimiter, array)
        End Function
    End Class
End Namespace
