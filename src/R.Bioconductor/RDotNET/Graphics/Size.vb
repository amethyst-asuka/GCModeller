﻿#Region "Microsoft.VisualBasic::6c52ae682755fe050e0c75999e78dc13, ..\R.Bioconductor\RDotNET\Graphics\Size.vb"

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

Namespace Graphics

    Public Structure Size
        Implements IEquatable(Of Size)
        Private m_height As Double
        Private m_width As Double

        Public Sub New(width As Double, height As Double)
            Me.m_width = width
            Me.m_height = height
        End Sub

        Public Property Width() As Double
            Get
                Return Me.m_width
            End Get
            Set(value As Double)
                Me.m_width = Value
            End Set
        End Property

        Public Property Height() As Double
            Get
                Return Me.m_height
            End Get
            Set(value As Double)
                Me.m_height = Value
            End Set
        End Property

#Region "IEquatable<Size> Members"

        Public Overloads Function Equals(other As Size) As Boolean Implements IEquatable(Of RDotNet.Graphics.Size).Equals
            Return (Me = other)
        End Function

#End Region

        Public Shared Operator =(size1 As Size, size2 As Size) As Boolean
            Return size1.Width = size2.Width AndAlso size1.Height = size2.Height
        End Operator

        Public Shared Operator <>(size1 As Size, size2 As Size) As Boolean
            Return Not (size1 = size2)
        End Operator

        Public Overrides Function GetHashCode() As Integer
            Const Prime As Integer = 31
            Return Prime * Width.GetHashCode() + Height.GetHashCode()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is Size Then
                Dim size = CType(obj, Size)
                Return (Me = size)
            End If
            Return False
        End Function
    End Structure
End Namespace
