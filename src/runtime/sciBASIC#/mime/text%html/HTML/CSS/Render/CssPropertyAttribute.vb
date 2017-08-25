﻿#Region "Microsoft.VisualBasic::f6f063749f236726e3e00d2c26efac29, ..\sciBASIC#\mime\text%html\HTML\CSS\Render\CssPropertyAttribute.vb"

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

Imports System.Collections.Generic
Imports System.Text

Namespace HTML.CSS.Render

    ''' <summary>
    ''' Used to mark a property as a Css property.
    ''' The <see cref="Name"/> property is used to specify the oficial CSS name
    ''' </summary>
    Public Class CssPropertyAttribute
        Inherits Attribute
#Region "Fields"
        Private _name As String
#End Region

#Region "Ctor"

        ''' <summary>
        ''' Creates a new CssPropertyAttribute
        ''' </summary>
        ''' <param name="name">Name of the Css property</param>
        Public Sub New(name As String)
            Me.Name = name
        End Sub
#End Region

#Region "Properties"

        ''' <summary>
        ''' Gets or sets the name of the CSS property
        ''' </summary>
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set
                _name = value
            End Set
        End Property


#End Region
    End Class
End Namespace
