﻿#Region "Microsoft.VisualBasic::888beafc0bc7eecf62a2378738607cc2, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Extensions\Reflection\Marshal\Pointer(Of T).vb"

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

Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Linq

Namespace Emit.Marshal

    ''' <summary>
    ''' 在数组的索引基础上封装了数组本身
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    Public Class Pointer(Of T) : Inherits DataStructures.Pointer(Of T)

        Protected buffer As T()

        ''' <summary>
        ''' <see cref="Position"/> -> its current value
        ''' </summary>
        ''' <returns></returns>
        Public Property Current As T
            Get
                Return Value(Scan0)  ' 当前的位置是指相对于当前的位置offset为0的位置就是当前的位置
            End Get
            Protected Friend Set(value As T)
                Me.Value(Scan0) = value
            End Set
        End Property

        ''' <summary>
        ''' Memory block size
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Length As Integer
            Get
                Return buffer.Length
            End Get
        End Property

        ''' <summary>
        ''' 返回指定维度的一个数组，最高可用的下标。
        ''' </summary>
        ''' <returns>
        ''' <see cref="Integer"/>。 指定维度的下标可以包含的最大值。 如果 Array 只有一个元素， UBound ，则返回 0。 如果 Array 不包含任何元素，例如，如果它是零长度字符串，
        ''' UBound 返回-1。</returns>
        Public ReadOnly Property UBound As Integer
            Get
                Return Information.UBound(buffer)
            End Get
        End Property

        ''' <summary>
        ''' 相对于当前的指针的位置而言的
        ''' </summary>
        ''' <param name="p">相对于当前的位置的offset偏移量</param>
        ''' <returns></returns>
        Default Public Property Value(p%) As T
            Get
                p += __index

                If p < 0 OrElse p >= buffer.Length Then
                    Return Nothing
                Else
                    Return buffer(p)
                End If
            End Get
            Set(value As T)
                p += __index

                If p < 0 OrElse p >= buffer.Length Then
                    Throw New MemberAccessException(p & " reference to invalid memory region!")
                Else
                    buffer(p) = value
                End If
            End Set
        End Property

        ''' <summary>
        ''' Raw memory of this pointer
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property RawBuffer As T()
            Get
                Return buffer
            End Get
        End Property

        Public ReadOnly Property NullEnd(Optional offset As Integer = 0) As Boolean
            Get
                Return __index >= (buffer.Length - 1 - offset)
            End Get
        End Property

        ''' <summary>
        ''' Is read to end?
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property EndRead As Boolean
            Get
                Return __index >= buffer.Length
            End Get
        End Property

        ''' <summary>
        ''' Current read position
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Position As Integer
            Get
                Return __index
            End Get
        End Property

        Sub New(ByRef array As T())
            buffer = array
        End Sub

        Sub New(array As List(Of T))
            buffer = array.ToArray
        End Sub

        ''' <summary>
        ''' Create a collection wrapper from a <paramref name="source"/> buffer.
        ''' </summary>
        ''' <param name="source">The collection source buffer</param>
        Sub New(source As IEnumerable(Of T))
            buffer = source.ToArray
        End Sub

        Sub New()
        End Sub

        Public Overrides Function ToString() As String
            Return $"* {GetType(T).Name} + {__index} --> {Current}  // {Scan0.ToString}"
        End Function

        '''' <summary>
        '''' 前移<paramref name="offset"/>个单位，然后返回值，这个和Peek的作用一样，不会改变指针位置
        '''' </summary>
        '''' <param name="p"></param>
        '''' <param name="offset"></param>
        '''' <returns></returns>
        'Public Overloads Shared Operator <=(p As Pointer(Of T), offset As Integer) As T
        '    Return p(-offset)
        'End Operator

        '''' <summary>
        '''' 后移<paramref name="offset"/>个单位，然后返回值，这个和Peek的作用一样，不会改变指针位置
        '''' </summary>
        '''' <param name="p"></param>
        '''' <param name="offset"></param>
        '''' <returns></returns>
        'Public Overloads Shared Operator >=(p As Pointer(Of T), offset As Integer) As T
        '    Return p(offset)
        'End Operator

        Public Overloads Shared Narrowing Operator CType(p As Pointer(Of T)) As T
            Return p.Current
        End Operator

        ''' <summary>
        ''' 前移<paramref name="offset"/>个单位，然后返回值，这个和Peek的作用一样，不会改变指针位置
        ''' </summary>
        ''' <param name="p"></param>
        ''' <param name="offset"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator <<(p As Pointer(Of T), offset As Integer) As T
            Return p(-offset)
        End Operator

        ''' <summary>
        ''' 后移<paramref name="offset"/>个单位，然后返回值，这个和Peek的作用一样，不会改变指针位置
        ''' </summary>
        ''' <param name="p"></param>
        ''' <param name="offset"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator >>(p As Pointer(Of T), offset As Integer) As T
            Return p(offset)
        End Operator

        Public Overloads Shared Widening Operator CType(raw As T()) As Pointer(Of T)
            Return New Pointer(Of T)(raw)
        End Operator

        ''' <summary>
        ''' Move steps and returns this pointer
        ''' </summary>
        ''' <param name="ptr"></param>
        ''' <param name="d"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator +(ptr As Pointer(Of T), d As Integer) As Pointer(Of T)
            ptr.__index += d
            Return ptr
        End Operator

        Public Overloads Shared Operator -(ptr As Pointer(Of T), d As Integer) As Pointer(Of T)
            ptr.__index -= d
            Return ptr
        End Operator

        ''' <summary>
        ''' Pointer move to next and then returns is <see cref="EndRead"/>
        ''' </summary>
        ''' <returns></returns>
        Public Function MoveNext() As Boolean
            __index += 1
            Return Not EndRead
        End Function

        ''' <summary>
        ''' Pointer move to next and then returns the previous value
        ''' </summary>
        ''' <param name="ptr"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator +(ptr As Pointer(Of T)) As SeqValue(Of T)
            Dim i% = ptr.__index
            ptr.__index += 1

            Return New SeqValue(Of T) With {
                .i = i,
                .value = ptr.buffer(i)
            }
        End Operator

        ''' <summary>
        ''' 指针的位置往回移动一个单位，然后返回原来的位置的元素的值
        ''' </summary>
        ''' <param name="ptr"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator -(ptr As Pointer(Of T)) As SeqValue(Of T)
            Dim i% = ptr.__index
            ptr.__index -= 1

            Return New SeqValue(Of T) With {
                .i = i,
                .value = ptr.buffer(i)
            }
        End Operator

        Public Overloads Shared Operator <=(a As Pointer(Of T), b As Pointer(Of T)) As SwapHelper(Of T)
            Return New SwapHelper(Of T) With {.a = a, .b = b}
        End Operator

        Public Overloads Shared Operator >=(a As Pointer(Of T), b As Pointer(Of T)) As SwapHelper(Of T)
            Throw New NotSupportedException
        End Operator

        Public Overloads Shared Operator <=(a As Pointer(Of T), b As Integer) As SwapHelper(Of T)
            Return New SwapHelper(Of T) With {.a = a, .i = b}
        End Operator

        Public Overloads Shared Operator >=(a As Pointer(Of T), b As Integer) As SwapHelper(Of T)
            Throw New NotSupportedException
        End Operator
    End Class

    Public Structure SwapHelper(Of T)

        Public a As Pointer(Of T)
        Public b As Pointer(Of T)
        Public i As Integer

        Public Sub Swap()
            Dim tmp As T = a.Current

            If b Is Nothing Then
                a.Current = a(i)
                a(i) = tmp
            Else
                a.Current = b.Current
                b.Current = tmp
            End If
        End Sub
    End Structure
End Namespace
