﻿#Region "Microsoft.VisualBasic::f7a61c24bdfb33ca8eda7af3815db022, ..\GCModeller\foundation\OBO_Foundry\RawTerm.vb"

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

Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Serialization.JSON

Public Structure RawTerm

    ''' <summary>
    ''' Example: ``[Term]``
    ''' </summary>
    ''' <returns></returns>
    Public Property Type As String
    Public Property data As NamedValue(Of String())()

    Public Function GetData() As Dictionary(Of String, String())
        Return data.ToDictionary(Function(x) x.Name, Function(x) x.Value)
    End Function

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Structure
