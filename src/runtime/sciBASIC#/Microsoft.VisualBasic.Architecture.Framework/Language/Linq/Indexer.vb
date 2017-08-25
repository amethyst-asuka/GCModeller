﻿#Region "Microsoft.VisualBasic::a3b44f2b716ba38ae5bf45b459fb45b6, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Language\Linq\Indexer.vb"

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
Imports Microsoft.VisualBasic.Emit.Delegates

Namespace Language

    Public Module Indexer

#Region "Default Public Overloads Property Item(args As Object) As T()"
        Public Function Indexing(args As Object) As IEnumerable(Of Integer)
            Dim type As Type = args.GetType

            If type Is GetType(Integer) Then
                Return {DirectCast(args, Integer)}
            ElseIf type.ImplementsInterface(GetType(IEnumerable(Of Integer))) Then
                Return DirectCast(args, IEnumerable(Of Integer))
            ElseIf type.ImplementsInterface(GetType(IEnumerable(Of Boolean))) Then
                Return Which.IsTrue(DirectCast(args, IEnumerable(Of Boolean)))
            ElseIf type.ImplementsInterface(GetType(IEnumerable(Of Object))) Then
                Dim array = DirectCast(args, IEnumerable(Of Object)).ToArray

                With array(Scan0).GetType
                    If .ref Is GetType(Boolean) Then
                        Return Which.IsTrue(array.Select(Function(o) CBool(o)))
                    ElseIf .ref Is GetType(Integer) Then
                        Return array.Select(Function(o) CInt(o))
                    Else
                        Throw New NotImplementedException
                    End If
                End With
            Else
                Throw New NotImplementedException
            End If
        End Function
#End Region
    End Module
End Namespace
