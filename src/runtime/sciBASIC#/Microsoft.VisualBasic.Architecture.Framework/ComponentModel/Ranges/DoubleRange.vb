﻿#Region "Microsoft.VisualBasic::e426106dda980cd47bd8c8dbde4c821b, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\ComponentModel\Ranges\DoubleRange.vb"

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

' AForge Library
'
' Copyright © Andrew Kirillov, 2006
' andrew.kirillov@gmail.com
'

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace ComponentModel.Ranges

    ''' <summary>
    ''' Represents a double range with minimum and maximum values
    ''' </summary>
    Public Class DoubleRange : Implements IRanges(Of Double)
        Implements IEnumerable(Of Double)

        ''' <summary>
        ''' Minimum value
        ''' </summary>
        ''' 
        <XmlAttribute>
        Public Property Min As Double Implements IRanges(Of Double).Min

        ''' <summary>
        ''' Maximum value
        ''' </summary>
        '''   
        <XmlAttribute>
        Public Property Max As Double Implements IRanges(Of Double).Max

        ''' <summary>
        ''' Length of the range (deffirence between maximum and minimum values)
        ''' </summary>
        Public ReadOnly Property Length() As Double
            Get
                Return Max - Min
            End Get
        End Property

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DoubleRange"/> class
        ''' </summary>
        ''' 
        ''' <param name="min">Minimum value of the range</param>
        ''' <param name="max">Maximum value of the range</param>
        Public Sub New(min As Double, max As Double)
            Me.Min = min
            Me.Max = max
        End Sub

        ''' <summary>
        ''' 从一个任意的实数数组之中构建出一个实数区间范围
        ''' </summary>
        ''' <param name="data"></param>
        Sub New(data As Double())
            Call Me.New(data.Min, data.Max)
        End Sub

        ''' <summary>
        ''' 从一个任意的实数向量之中构建出一个实数区间范围
        ''' </summary>
        ''' <param name="vector"></param>
        Sub New(vector As IEnumerable(Of Double))
            Call Me.New(data:=vector.ToArray)
        End Sub

        Sub New(range As IntRange)
            Call Me.New(range.Min, range.Max)
        End Sub

        Sub New()
        End Sub

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function

        ''' <summary>
        ''' Check if the specified value is inside this range
        ''' </summary>
        ''' 
        ''' <param name="x">Value to check</param>
        ''' 
        ''' <returns><b>True</b> if the specified value is inside this range or
        ''' <b>false</b> otherwise.</returns>
        ''' 
        Public Function IsInside(x As Double) As Boolean Implements IRanges(Of Double).IsInside
            Return ((x >= Min) AndAlso (x <= Max))
        End Function

        ''' <summary>
        ''' Check if the specified range is inside this range
        ''' </summary>
        ''' 
        ''' <param name="range">Range to check</param>
        ''' 
        ''' <returns><b>True</b> if the specified range is inside this range or
        ''' <b>false</b> otherwise.</returns>
        ''' 
        Public Function IsInside(range As DoubleRange) As Boolean
            Return ((IsInside(range.Min)) AndAlso (IsInside(range.Max)))
        End Function

        ''' <summary>
        ''' Check if the specified range overlaps with this range
        ''' </summary>
        ''' 
        ''' <param name="range">Range to check for overlapping</param>
        ''' 
        ''' <returns><b>True</b> if the specified range overlaps with this range or
        ''' <b>false</b> otherwise.</returns>
        ''' 
        Public Function IsOverlapping(range As DoubleRange) As Boolean
            Return ((IsInside(range.Min)) OrElse (IsInside(range.Max)))
        End Function

        Public Function IsInside(range As IRanges(Of Double)) As Boolean Implements IRanges(Of Double).IsInside
            Return ((IsInside(range.Min)) AndAlso (IsInside(range.Max)))
        End Function

        Public Function IsOverlapping(range As IRanges(Of Double)) As Boolean Implements IRanges(Of Double).IsOverlapping
            Return ((IsInside(range.Min)) OrElse (IsInside(range.Max)))
        End Function

        Public Shared Widening Operator CType(exp$) As DoubleRange
            Dim r As New DoubleRange
            Call exp.Parser(r.Min, r.Max)
            Return r
        End Operator

        Public Function Enumerate(n%) As Double()
            Dim delta# = Length / n
            Dim out As New List(Of Double)

            For x As Double = Min To Max Step delta
                out += x
            Next

            Return out
        End Function

        ''' <summary>
        ''' Transform a numeric value in this <see cref="DoubleRange"/> into 
        ''' target numeric range: ``<paramref name="valueRange"/>``.
        ''' (将当前的范围内的一个实数映射到另外的一个范围内的实数区间之中)
        ''' </summary>
        ''' <param name="x#"></param>
        ''' <param name="valueRange"></param>
        ''' <returns></returns>
        Public Function ScaleMapping(x#, valueRange As DoubleRange) As Double
            Dim percent# = (x - Min) / Length
            Dim value# = percent * valueRange.Length + valueRange.Min
            Return value
        End Function

        Public Iterator Function GetEnumerator() As IEnumerator(Of Double) Implements IEnumerable(Of Double).GetEnumerator
            For Each x In Me.Enumerate(100)
                Yield x
            Next
        End Function

        Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function
    End Class
End Namespace
