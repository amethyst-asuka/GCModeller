﻿#Region "Microsoft.VisualBasic::2e79598ba319eeeb1d5dbcfe81a99a05, ..\sciBASIC#\Data_science\Mathematica\Math\ODE\var.vb"

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
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Language

''' <summary>
''' Y variable in the ODE
''' </summary>
Public Class var : Inherits float
    Implements Ivar
    Implements ICloneable
    Implements IAddress(Of Integer)

    Public Property Index As Integer Implements IAddress(Of Integer).Address
    Public Property Name As String Implements INamedValue.Key
    Public Overrides Property value As Double Implements Ivar.value

    Friend Evaluate As Func(Of Double)

    Public Shared ReadOnly type As Type = GetType(var)

    Sub New()
    End Sub

    Sub New(name$, value#)
        With Me
            .Name = name
            .value = value
        End With
    End Sub

    Sub New(name As String)
        Me.Name = name
    End Sub

    ''' <summary>
    ''' Value copy
    ''' </summary>
    ''' <param name="var"></param>
    Sub New(var As var)
        With var
            Index = .Index
            Name = .Name
            value = .value
        End With
    End Sub

    Public Overrides Function ToString() As String
        Return $"Dim [{Index}] {Name} As System.Double = {value}"
    End Function

    Public Overloads Shared Operator =(var As var, x As Double) As var
        var.value = x
        Return var
    End Operator

    Public Overloads Shared Operator =(var As var, equation As Func(Of Double)) As var
        var.Evaluate = equation
        Return var
    End Operator

    Public Overloads Shared Operator <>(var As var, equation As Func(Of Double)) As var
        Throw New NotImplementedException
    End Operator

    Public Overloads Shared Narrowing Operator CType(x As var) As Integer
        Return x.Index
    End Operator

    Public Overloads Shared Operator <>(var As var, x As Double) As var
        Throw New NotSupportedException
    End Operator

    Public Function Clone() As Object Implements ICloneable.Clone
        Return New var(Me)
    End Function
End Class

Public Interface Ivar : Inherits INamedValue

    Property value As Double
End Interface
