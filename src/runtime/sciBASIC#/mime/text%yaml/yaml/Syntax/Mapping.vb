﻿#Region "Microsoft.VisualBasic::d3a35f838b8385a97c1b088d81dbc481, ..\sciBASIC#\mime\text%yaml\yaml\Syntax\Mapping.vb"

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

Namespace Syntax
    Public Class Mapping
        Inherits DataItem

        Public Enties As New List(Of MappingEntry)()

        Public Function GetMaps() As Dictionary(Of MappingEntry)
            Return New Dictionary(Of MappingEntry)(Enties)
        End Function
    End Class
End Namespace
