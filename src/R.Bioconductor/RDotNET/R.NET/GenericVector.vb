﻿#Region "Microsoft.VisualBasic::de8b2cc0f47842cb2ffacd228b9f3373, ..\R.Bioconductor\RDotNET\R.NET\GenericVector.vb"

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

Imports RDotNet.Dynamic
Imports RDotNet.Internals
Imports System.Collections.Generic
Imports System.Dynamic
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

''' <summary>
''' A generic list. This is also known as list in R.
''' </summary>
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.UnmanagedCode)> _
Public Class GenericVector
	Inherits Vector(Of SymbolicExpression)
	''' <summary>
	''' Creates a new empty GenericVector with the specified length.
	''' </summary>
	''' <param name="engine">The <see cref="REngine"/> handling this instance.</param>
	''' <param name="length">The length.</param>
	Public Sub New(engine As REngine, length As Integer)
		MyBase.New(engine, engine.GetFunction(Of Rf_allocVector)()(SymbolicExpressionType.List, length))
	End Sub

	''' <summary>
	''' Creates a new GenericVector with the specified values.
	''' </summary>
	''' <param name="engine">The <see cref="REngine"/> handling this instance.</param>
	''' <param name="list">The values.</param>
	Public Sub New(engine As REngine, list As IEnumerable(Of SymbolicExpression))
		MyBase.New(engine, SymbolicExpressionType.List, list)
	End Sub

	''' <summary>
	''' Creates a new instance for a list.
	''' </summary>
	''' <param name="engine">The <see cref="REngine"/> handling this instance.</param>
	''' <param name="coerced">The pointer to a list.</param>
	Protected Friend Sub New(engine As REngine, coerced As IntPtr)
		MyBase.New(engine, coerced)
	End Sub

	''' <summary>
	''' Gets or sets the element at the specified index.
	''' </summary>
	''' <param name="index">The zero-based index of the element to get or set.</param>
	''' <returns>The element at the specified index.</returns>
	Public Overrides Default Property Item(index As Integer) As SymbolicExpression
		Get
			If index < 0 OrElse Length <= index Then
				Throw New ArgumentOutOfRangeException()
			End If
			Using New ProtectedPointer(Me)
				Return GetValue(index)
			End Using
		End Get
		Set
			If index < 0 OrElse Length <= index Then
				Throw New ArgumentOutOfRangeException()
			End If
			Using New ProtectedPointer(Me)
				SetValue(index, value)
			End Using
		End Set
	End Property

	Private Function GetValue(index As Integer) As SymbolicExpression
		Dim offset As Integer = GetOffset(index)
		Dim pointer As IntPtr = Marshal.ReadIntPtr(DataPointer, offset)
		Return New SymbolicExpression(Engine, pointer)
	End Function

	Private Sub SetValue(index As Integer, value As SymbolicExpression)
		Dim offset As Integer = GetOffset(index)
		Marshal.WriteIntPtr(DataPointer, offset, (If(value, Engine.NilValue)).DangerousGetHandle())
	End Sub

	''' <summary>
	''' Efficient conversion from R vector representation to the array equivalent in the CLR
	''' </summary>
	''' <returns>Array equivalent</returns>
	Protected Overrides Function GetArrayFast() As SymbolicExpression()
		Dim res = New SymbolicExpression(Me.Length - 1) {}
		For i As Integer = 0 To res.Length - 1
			res(i) = GetValue(i)
		Next
		Return res
	End Function

	''' <summary>
	''' Efficient initialisation of R vector values from an array representation in the CLR
	''' </summary>
	Protected Overrides Sub SetVectorDirect(values As SymbolicExpression())
		For i As Integer = 0 To values.Length - 1
			SetValue(i, values(i))
		Next
	End Sub

	''' <summary>
	''' Gets the size of each item in this vector
	''' </summary>
	Protected Overrides ReadOnly Property DataSize() As Integer
		Get
			Return Marshal.SizeOf(GetType(IntPtr))
		End Get
	End Property

	''' <summary>
	''' Converts into a <see cref="RDotNet.Pairlist"/>.
	''' </summary>
	''' <returns>The pairlist.</returns>
	Public Function ToPairlist() As Pairlist
		Return New Pairlist(Engine, Me.GetFunction(Of Rf_VectorToPairList)()(handle))
	End Function

	''' <summary>
	''' returns a new ListDynamicMeta for this Generic Vector
	''' </summary>
	''' <param name="parameter"></param>
	''' <returns></returns>
	Public Overrides Function GetMetaObject(parameter As System.Linq.Expressions.Expression) As DynamicMetaObject
		Return New ListDynamicMeta(parameter, Me)
	End Function
End Class
