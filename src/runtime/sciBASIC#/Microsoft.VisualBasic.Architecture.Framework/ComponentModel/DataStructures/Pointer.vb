﻿#Region "Microsoft.VisualBasic::ab48d1aa28d8e7e99aad21f8e143ea14, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\ComponentModel\DataStructures\Pointer.vb"

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

Imports Microsoft.VisualBasic.Language

Namespace ComponentModel.DataStructures

    Public Class Pointer(Of T) : Inherits Pointer

        ''' <summary>
        ''' Returns current line in the array and then pointer moves to next.
        ''' </summary>
        ''' <param name="array"></param>
        ''' <param name="i"></param>
        ''' <returns></returns>

        Public Overloads Shared Operator +(array As T(), i As Pointer(Of T)) As T
            Return array(+i)
        End Operator

        Public Overloads Shared Operator -(array As T(), i As Pointer(Of T)) As T
            Return array(-i)
        End Operator

        Public Overloads Shared Operator +(list As List(Of T), i As Pointer(Of T)) As T
            Return list(+i)
        End Operator

        Public Overloads Shared Operator -(list As List(Of T), i As Pointer(Of T)) As T
            Return list(-i)
        End Operator
    End Class
End Namespace
