﻿#Region "Microsoft.VisualBasic::cbfaa297baf7c4ba143ce972f972d823, ..\sciBASIC#\Data_science\Mathematica\Math\Math.Statistics\MomentFunctions\ProductMoments.vb"

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

Imports Microsoft.VisualBasic.Math.StatisticsMathExtensions
Imports Microsoft.VisualBasic.Serialization.JSON

'
' * To change this license header, choose License Headers in Project Properties.
' * To change this template file, choose Tools | Templates
' * and open the template in the editor.
' 
Namespace MomentFunctions

    ''' 
    ''' <summary>
    ''' @author Will_and_Sara
    ''' </summary>
    Public Class ProductMoments

        Public Sub New(data As Double())
            Dim count = data.Length
            Dim BPM As New BasicProductMoments(data)

            _Min = BPM.Min()
            _Max = BPM.Max()
            _Mean = BPM.Mean()
            _StandardDeviation = BPM.StDev()
            _SampleSize = count

            Dim skewsums As Double = 0
            Dim ksums As Double = 0

            For i As Integer = 0 To data.Length - 1
                skewsums += Math.Pow((data(i) - _Mean), 3)
                ksums += Math.Pow(((data(i) - _Mean) / _StandardDeviation), 4)
            Next

            'just alittle more math...
            ksums *= (count * (count + 1)) \ ((count - 1) * (count - 2) * (count - 3))
            _Skew = (count * skewsums) / ((count - 1) * (count - 2) * Math.Pow(_StandardDeviation, 3))
            _Kurtosis = ksums - ((3 * (Math.Pow(count - 1, 2))) / ((count - 2) * (count - 3)))

            'figure out an efficent algorithm for median...
            Median = data.Median
        End Sub

        Public ReadOnly Property Median As Double

        Public ReadOnly Property Skew() As Double

        Public ReadOnly Property Kurtosis() As Double

        Public ReadOnly Property Min() As Double

        Public ReadOnly Property Max() As Double

        Public ReadOnly Property Mean() As Double

        Public ReadOnly Property StandardDeviation() As Double

        Public ReadOnly Property SampleSize() As Integer

        Public Overrides Function ToString() As String
            Return GetJson
        End Function
    End Class
End Namespace
