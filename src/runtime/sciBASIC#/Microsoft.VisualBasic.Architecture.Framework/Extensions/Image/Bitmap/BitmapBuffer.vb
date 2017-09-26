﻿#Region "Microsoft.VisualBasic::08de5de5771098e3294ff1a8d98a94d0, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Extensions\Image\Bitmap\BitmapBuffer.vb"

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

Imports System.Drawing
Imports System.Drawing.Imaging
Imports sys = System.Math

Namespace Imaging.BitmapImage

    ''' <summary>
    ''' 线程不安全的图片数据对象
    ''' </summary>
    Public Class BitmapBuffer : Inherits Emit.Marshal.Byte
        Implements IDisposable
        Implements IEnumerable(Of Color)

        ReadOnly __source As Bitmap
        ReadOnly __handle As BitmapData

        Protected Sub New(ptr As IntPtr,
                          byts%,
                          raw As Bitmap,
                          handle As BitmapData)

            Call MyBase.New(ptr, byts)

            __source = raw
            __handle = handle

            Stride = handle.Stride
            Width = raw.Width
            Height = raw.Height
            Size = New Size(Width, Height)
        End Sub

        Public ReadOnly Property Width As Integer
        Public ReadOnly Property Height As Integer
        Public ReadOnly Property Size As Size
        Public ReadOnly Property Stride As Integer

        ''' <summary>
        ''' Gets a copy of the original raw image value that which constructed this bitmap object class
        ''' </summary>
        ''' <returns></returns>
        Public Function GetImage() As Bitmap
            Return DirectCast(__source.Clone, Bitmap)
        End Function

        ''' <summary>
        ''' 返回第一个元素的位置
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns>B, G, R</returns>
        Public Function GetIndex(x As Integer, y As Integer) As Integer
            y = y * (Width * 4)
            x = x * 4
            Return x + y
        End Function

        Public Function OutOfRange(x%, y%) As Boolean
            Return x < 0 OrElse x >= Width OrElse y < 0 OrElse y >= Height
        End Function

        ''' <summary>
        ''' Gets the color of the specified pixel in this <see cref="Bitmap"/>.
        ''' </summary>
        ''' <param name="x">The x-coordinate of the pixel to retrieve.</param>
        ''' <param name="y">The y-coordinate of the pixel to retrieve.</param>
        ''' <returns>
        ''' A <see cref="Color"/> structure that represents the color of the specified pixel.
        ''' </returns>
        Public Function GetPixel(x As Integer, y As Integer) As Color
            Dim i As Integer = GetIndex(x, y)
            Dim iR As Byte = buffer(i + 2)
            Dim iG As Byte = buffer(i + 1)
            Dim iB As Byte = buffer(i + 0)

            Return Color.FromArgb(CInt(iR), CInt(iG), CInt(iB))
        End Function

        ''' <summary>
        ''' Sets the color of the specified pixel in this System.Drawing.Bitmap.(这个函数线程不安全)
        ''' </summary>
        ''' <param name="x">The x-coordinate of the pixel to set.</param>
        ''' <param name="y">The y-coordinate of the pixel to set.</param>
        ''' <param name="color">
        ''' A System.Drawing.Color structure that represents the color to assign to the specified
        ''' pixel.</param>
        Public Sub SetPixel(x As Integer, y As Integer, color As Color)
            Dim i As Integer = GetIndex(x, y)

            buffer(i + 2) = color.R
            buffer(i + 1) = color.G
            buffer(i + 0) = color.B
        End Sub

        ''' <summary>
        ''' 这个函数会自动复制原始图片数据里面的东西的
        ''' </summary>
        ''' <param name="res"></param>
        ''' <returns></returns>
        Public Shared Function FromImage(res As Image) As BitmapBuffer
            Return BitmapBuffer.FromBitmap(New Bitmap(res))
        End Function

        Public Shared Function FromBitmap(curBitmap As Bitmap) As BitmapBuffer
            ' Lock the bitmap's bits.  
            Dim rect As New Rectangle(0, 0, curBitmap.Width, curBitmap.Height)
            Dim bmpData As BitmapData = curBitmap.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                curBitmap.PixelFormat)

            ' Get the address of the first line.
            Dim ptr As IntPtr = bmpData.Scan0
            ' Declare an array to hold the bytes of the bitmap.
            Dim bytes As Integer = sys.Abs(bmpData.Stride) * curBitmap.Height

            Return New BitmapBuffer(ptr, bytes, curBitmap, bmpData)
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            Call Write()
            Call __source.UnlockBits(__handle)
        End Sub

        Public Iterator Function GetEnumerator() As IEnumerator(Of Color) Implements IEnumerable(Of Color).GetEnumerator
            For Each x As Color In buffer.Colors
                Yield x
            Next
        End Function

        Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function

        ''' <summary>
        ''' Current pointer location offset to next position
        ''' </summary>
        ''' <param name="bmp"></param>
        ''' <param name="offset%"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator +(bmp As BitmapBuffer, offset%) As BitmapBuffer
            bmp.__index += offset
            Return bmp
        End Operator
    End Class
End Namespace