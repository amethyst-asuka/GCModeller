﻿#Region "Microsoft.VisualBasic::2491e37f1be63c2db660e5d24428b758, ..\localblast\LocalBLAST\LocalBLAST\BlastOutput\Common\Percentage.vb"

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

Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Scripting.Runtime

Namespace LocalBLAST.BLASTOutput.ComponentModel

    ''' <summary>
    ''' 分数，百分比
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Percentage

        ''' <summary>
        ''' 分子
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property Numerator As Double
        ''' <summary>
        ''' 分母
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property Denominator As Double

        ''' <summary>
        ''' <see cref="Numerator"></see>/<see cref="Denominator"></see>
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Value As Double
            Get
                Return Numerator / Denominator
            End Get
        End Property

        Public ReadOnly Property FractionExpr As String
            Get
                Return $"{Numerator}/{Denominator}"
            End Get
        End Property

        Sub New(n As Double, d As Double)
            Numerator = n
            Denominator = d
        End Sub

        Public Overrides Function ToString() As String
            Return String.Format("{0}/{1} ({2}%)", Numerator, Denominator, Value)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Text">\d+[/]\d+ \(\d+[%]\)</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function TryParse(Text As String) As Percentage
            If String.IsNullOrEmpty(Text) Then Return ZERO

            Dim Matchs As String() = Regex.Matches(Text, "\d+").ToArray
            Dim n As Double = Matchs(0).RegexParseDouble
            Dim d As Double = Matchs(1).RegexParseDouble

            Return New Percentage With {
                .Numerator = n,
                .Denominator = d
            }
        End Function

        Public Shared ReadOnly Property ZERO As Percentage
            Get
                Return New Percentage(0, 1)
            End Get
        End Property

        Public Shared Narrowing Operator CType(value As Percentage) As Double
            Return value.Value
        End Operator

        Public Shared Operator >(value As Percentage, n As Double) As Boolean
            Return value.Value > n
        End Operator

        Public Shared Operator <(value As Percentage, n As Double) As Boolean
            Return value.Value < n
        End Operator
    End Structure
End Namespace
