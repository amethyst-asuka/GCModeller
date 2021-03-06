﻿#Region "Microsoft.VisualBasic::0f101c5c4eaf2fbf8191340782b6745f, ..\R.Bioconductor\RDotNET\Graphics\GraphicsDeviceEventArgs.vb"

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

    Public Class GraphicsDeviceEventArgs
        Inherits EventArgs
        Private ReadOnly m_context As GraphicsContext
        Private ReadOnly m_description As DeviceDescription

        Public Sub New(description As DeviceDescription, Optional context As GraphicsContext = Nothing)
            Me.m_description = description
            Me.m_context = context
        End Sub

        Public ReadOnly Property Description() As DeviceDescription
            Get
                Return Me.m_description
            End Get
        End Property

        Public ReadOnly Property Context() As GraphicsContext
            Get
                Return Me.m_context
            End Get
        End Property
    End Class
End Namespace
