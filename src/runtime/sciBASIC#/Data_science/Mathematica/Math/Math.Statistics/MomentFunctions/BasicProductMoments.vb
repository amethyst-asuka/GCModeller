﻿#Region "Microsoft.VisualBasic::97fa4e34f64a017ec0df9fb92bde1b5a, ..\sciBASIC#\Data_science\Mathematica\Math\Math.Statistics\MomentFunctions\BasicProductMoments.vb"

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

Imports System

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
    Public Class BasicProductMoments

        Public ReadOnly Property SampleVariance As Double

        Protected Friend _Count As Integer

        Private _Converged As Boolean = False
        Private _ZAlphaForConvergence As Double = 1.96039491692453
        Private _ToleranceForConvergence As Double = 0.01
        Private _MinValuesBeforeConvergenceTest As Integer = 100

        Public ReadOnly Property Mean() As Double

        Public ReadOnly Property StDev() As Double
            Get
                Return Math.Sqrt(_SampleVariance)
            End Get
        End Property

        Public ReadOnly Property Min() As Double

        Public ReadOnly Property Max() As Double

        Public ReadOnly Property SampleSize() As Integer
            Get
                Return _Count
            End Get
        End Property

        ''' <summary>
        ''' This function can be used to determine if enough samples have been added to determine convergence of the data stream. </summary>
        ''' <returns> this function will return false until the minimum number of observations have been added, and then will return the result of the convergence test after the most recent observation. </returns>
        Public Overridable Function IsConverged() As Boolean
            Return _Converged
        End Function

        ''' <summary>
        ''' This method allows the user to define a minimum number of observations before testing for convergence.
        ''' This would help to mitigate early convergence if similar observations are in close sequence early in the dataset. </summary>
        ''' <param name="numobservations"> the minimum number of observations to wait until testing for convergence. </param>
        Public Overridable Sub SetMinValuesBeforeConvergenceTest(numobservations As Integer)
            _MinValuesBeforeConvergenceTest = numobservations
        End Sub

        ''' <summary>
        ''' This method sets the tolerance for convergence.  This tolerance is used as an epsilon neighborhood around the confidence defined in SetZalphaForConvergence. </summary>
        ''' <param name="tolerance"> the distance that is determined to be close enough to the alpha in question. </param>
        Public Overridable Sub SetConvergenceTolerance(tolerance As Double)
            _ToleranceForConvergence = tolerance
        End Sub

        ''' <summary>
        ''' This method defines the alpha value used to determine convergence.  This value is based on a two sided confidence interval.  It uses the upper Confidence Limit. </summary>
        ''' <param name="ConfidenceInterval"> The value that would be used to determine the normal alpha value.  The default is a .9 Confidence interval, which corresponds to 1.96 alpha value. </param>
        Public Overridable Sub SetZAlphaForConvergence(ConfidenceInterval As Double)
            Dim sn As New Distributions.MethodOfMoments.Normal
            _ZAlphaForConvergence = sn.GetInvCDF(ConfidenceInterval + ((1 - ConfidenceInterval) / 2))
        End Sub

        ''' <summary>
        ''' This constructor allows one to create an instance without adding any data.
        ''' </summary>
        Public Sub New()
            _Mean = 0
            _SampleVariance = 0
            _Min = 0
            _Max = 0
            _Count = 0
        End Sub

        ''' <summary>
        ''' This constructor allows one to create an instance with some initial data, observations can be added after the constructor through the "AddObservations(double observation) call. </summary>
        ''' <param name="data"> the dataset to calculate mean and standard deviation for. </param>
        Public Sub New(data As IEnumerable(Of Double))
            _Mean = 0
            _SampleVariance = 0
            _Min = 0
            _Max = 0
            _Count = 0

            For Each d As Double In data
                Me.AddObservation(d)
            Next
        End Sub

        ''' <summary>
        ''' An inline algorithm for incrementing mean and standard of deviation. After this method call, the properties of this class should be updated to include this observation. </summary>
        ''' <param name="observation"> the observation to be added </param>
        Public Overridable Sub AddObservation(observation As Double)

            If _Count = 0 Then
                _Count = 1
                _Min = observation
                _Max = observation
                _Mean = observation
            Else
                'single pass algorithm. 
                If observation > _Max Then _Max = observation
                If observation < _Min Then _Min = observation
                _Count += 1
                Dim newmean As Double = _Mean + ((observation - _Mean) / _Count) 'check for integer rounding issues.
                _SampleVariance = (((CDbl(_Count - 2) / CDbl(_Count - 1)) * _SampleVariance) + (Math.Pow(observation - _Mean, 2.0)) / _Count)
                _Mean = newmean
            End If

            Call TestForConvergence()
        End Sub

        Public Overridable Sub AddObservations(data As Double())
            For Each d As Double In data
                Call AddObservation(d)
            Next
        End Sub

        Private Sub TestForConvergence()
            If _Count > _MinValuesBeforeConvergenceTest Then
                If Not _Converged Then
                    Dim var As Double = (_ZAlphaForConvergence * Me.StDev()) / (Me.Mean() * Math.Abs(Me.StDev()))
                    _Converged = (Math.Abs(var) <= _ToleranceForConvergence)
                End If
            End If
        End Sub
    End Class
End Namespace
