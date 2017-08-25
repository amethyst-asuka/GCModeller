﻿#Region "Microsoft.VisualBasic::fdf66bf531cd773a8ed30bfed9dd10c2, ..\GCModeller\models\Networks\STRING\EffectorMap.vb"

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
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection

''' <summary>
''' Regprecise Effector与MetaCyc Compounds Mapping
''' </summary>
''' <remarks></remarks>
Public Class EffectorMap : Implements INamedValue

    <Column("regprecise-effector")>
    Public Property Effector As String Implements INamedValue.Key
    Public Property MetaCycId As String
    <Collection("Effector-Alias")>
    Public Property EffectorAlias As String()

    Public Overrides Function ToString() As String
        Return String.Format("{0} --> {1}", Effector, MetaCycId)
    End Function
End Class
