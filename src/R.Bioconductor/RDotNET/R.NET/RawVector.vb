﻿#Region "Microsoft.VisualBasic::c9e811b581ea1958c7869c6a65f1bbd7, ..\R.Bioconductor\RDotNET\R.NET\RawVector.vb"

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

Imports RDotNet.Internals
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

''' <summary>
''' A sequence of byte values.
''' </summary>
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.UnmanagedCode)> _
Public Class RawVector
	Inherits Vector(Of Byte)
	''' <summary>
	''' Creates a new RawVector with the specified length.
	''' </summary>
	''' <param name="engine">The <see cref="REngine"/> handling this instance.</param>
	''' <param name="length">The length.</param>
	Public Sub New(engine As REngine, length As Integer)
		MyBase.New(engine, SymbolicExpressionType.RawVector, length)
	End Sub

	''' <summary>
	''' Creates a new RawVector with the specified values.
	''' </summary>
	''' <param name="engine">The <see cref="REngine"/> handling this instance.</param>
	''' <param name="vector">The values.</param>
    ''' <seealso cref="REngineExtension.CreateRawVector"/>
	Public Sub New(engine As REngine, vector As IEnumerable(Of Byte))
		MyBase.New(engine, SymbolicExpressionType.RawVector, vector)
	End Sub

	''' <summary>
	''' Creates a new RawVector with the specified values.
	''' </summary>
	''' <param name="engine">The <see cref="REngine"/> handling this instance.</param>
	''' <param name="vector">The values.</param>
    ''' <seealso cref="REngineExtension.CreateRawVector"/>
	Public Sub New(engine As REngine, vector As Byte())
		MyBase.New(engine, SymbolicExpressionType.RawVector, vector.Length)
		Marshal.Copy(vector, 0, DataPointer, vector.Length)
	End Sub

	''' <summary>
	''' Creates a new instance for a raw vector.
	''' </summary>
	''' <param name="engine">The <see cref="REngine"/> handling this instance.</param>
	''' <param name="coerced">The pointer to a raw vector.</param>
    ''' <seealso cref="REngineExtension.CreateRawVector"/>
	Protected Friend Sub New(engine As REngine, coerced As IntPtr)
		MyBase.New(engine, coerced)
	End Sub

	''' <summary>
	''' Gets or sets the element at the specified index.
	''' </summary>
	''' <param name="index">The zero-based index of the element to get or set.</param>
	''' <returns>The element at the specified index.</returns>
	Public Overrides Default Property Item(index As Integer) As Byte
		Get
			If index < 0 OrElse Length <= index Then
				Throw New ArgumentOutOfRangeException()
			End If
			Using New ProtectedPointer(Me)
				Dim offset As Integer = GetOffset(index)
				Return Marshal.ReadByte(DataPointer, offset)
			End Using
		End Get
		Set
			If index < 0 OrElse Length <= index Then
				Throw New ArgumentOutOfRangeException()
			End If
			Using New ProtectedPointer(Me)
				Dim offset As Integer = GetOffset(index)
				Marshal.WriteByte(DataPointer, offset, value)
			End Using
		End Set
	End Property

	''' <summary>
	''' Efficient conversion from R vector representation to the array equivalent in the CLR
	''' </summary>
	''' <returns>Array equivalent</returns>
	Protected Overrides Function GetArrayFast() As Byte()
        Dim res As Byte() = New Byte(Me.Length - 1) {}
		Marshal.Copy(DataPointer, res, 0, res.Length)
		Return res
	End Function

	''' <summary>
	''' Sets the values of this RawVector
	''' </summary>
	''' <param name="values">Managed values, to be converted to unmanaged equivalent</param>
	Protected Overrides Sub SetVectorDirect(values As Byte())
		Marshal.Copy(values, 0, DataPointer, values.Length)
	End Sub

	''' <summary>
	''' Gets the size of a byte value in byte.
	''' </summary>
	Protected Overrides ReadOnly Property DataSize() As Integer
		Get
			Return 1
		End Get
	End Property

	''' <summary>
	''' Copies the elements to the specified array.
	''' </summary>
	''' <param name="destination">The destination array.</param>
    ''' <param name="length__1">The length to copy.</param>
	''' <param name="sourceIndex">The first index of the vector.</param>
	''' <param name="destinationIndex">The first index of the destination array.</param>
	Public Shadows Sub CopyTo(destination As Byte(), length__1 As Integer, Optional sourceIndex As Integer = 0, Optional destinationIndex As Integer = 0)
		If destination Is Nothing Then
			Throw New ArgumentNullException("destination")
		End If
		If length__1 < 0 Then
			Throw New IndexOutOfRangeException("length")
		End If
		If sourceIndex < 0 OrElse Length < sourceIndex + length__1 Then
			Throw New IndexOutOfRangeException("sourceIndex")
		End If
		If destinationIndex < 0 OrElse destination.Length < destinationIndex + length__1 Then
			Throw New IndexOutOfRangeException("destinationIndex")
		End If

		Dim offset As Integer = GetOffset(sourceIndex)
		Dim pointer As IntPtr = IntPtr.Add(DataPointer, offset)
		Marshal.Copy(pointer, destination, destinationIndex, length__1)
	End Sub
End Class
