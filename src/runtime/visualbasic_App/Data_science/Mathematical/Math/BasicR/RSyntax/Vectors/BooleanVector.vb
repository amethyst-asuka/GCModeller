﻿#Region "Microsoft.VisualBasic::65973d8c52589dc706cc634ad14e2b25, ..\visualbasic_App\Data_science\Mathematical\Math\BasicR\RSyntax\Vectors\BooleanVector.vb"

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

Imports Microsoft.VisualBasic.Linq

Namespace SyntaxAPI.Vectors

    ''' <summary>
    ''' <see cref="System.Boolean"/> Array
    ''' </summary>
    Public Class BooleanVector : Inherits GenericVector(Of Boolean)

        ''' <summary>
        ''' Only one boolean value ``True`` in the array list
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property [True] As BooleanVector
            Get
                Return New BooleanVector({True})
            End Get
        End Property

        ''' <summary>
        ''' Only one boolean value ``False`` in the array list
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property [False] As BooleanVector
            Get
                Return New BooleanVector({False})
            End Get
        End Property

        Public ReadOnly Property IsLogical As Boolean
            Get
                Return [Dim] = 1
            End Get
        End Property

        Sub New(b As IEnumerable(Of Boolean))
            MyBase.New(b)
        End Sub

        ''' <summary>
        ''' And
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Shared Operator &(x As Boolean, y As BooleanVector) As BooleanVector
            Return New BooleanVector(From b As Boolean In y Select b AndAlso x)
        End Operator

        ''' <summary>
        ''' X AndAlso Y
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Shared Operator &(x As BooleanVector, y As BooleanVector) As BooleanVector
            Return New BooleanVector(From i As SeqValue(Of Boolean) In x.SeqIterator Select i.obj AndAlso y(i))
        End Operator

        Public Shared Operator Not(x As BooleanVector) As BooleanVector
            Return New BooleanVector((From b As Boolean In x Select Not b).ToArray)
        End Operator

        ''' <summary>
        ''' x(0)
        ''' </summary>
        ''' <param name="x"></param>
        ''' <returns></returns>
        Public Overloads Shared Narrowing Operator CType(x As BooleanVector) As Boolean
            Return x(0)
        End Operator

        Public Shared Widening Operator CType(b As Boolean()) As BooleanVector
            Return New BooleanVector(b)
        End Operator

        ''' <summary>
        ''' x Or Y
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Shared Operator Or(x As BooleanVector, y As Boolean()) As BooleanVector
            Return New BooleanVector(From i In x.SeqIterator Select i.obj OrElse y(i))
        End Operator

        ''' <summary>
        ''' x Or Y
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Shared Operator Or(x As BooleanVector, y As BooleanVector) As BooleanVector
            Return x Or y.ToArray
        End Operator

        ''' <summary>
        ''' <see cref="ToArray"/>
        ''' </summary>
        ''' <param name="x"></param>
        ''' <returns></returns>
        Public Overloads Shared Narrowing Operator CType(x As BooleanVector) As Boolean()
            Return x.ToArray
        End Operator
    End Class
End Namespace
