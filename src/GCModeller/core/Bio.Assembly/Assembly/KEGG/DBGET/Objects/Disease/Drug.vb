﻿#Region "Microsoft.VisualBasic::07813ae3ba2be872a66034fa2e3734fd, ..\core\Bio.Assembly\Assembly\KEGG\DBGET\Objects\Disease\Drug.vb"

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
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository

Namespace Assembly.KEGG.DBGET.bGetObject

    Public Class Drug : Implements INamedValue

        Public Property Entry As String Implements IKeyedEntity(Of String).Key
        Public Property Name As String
        Public Property Members As KeyValuePair()
        Public Property Remark As String
        Public Property Comment As String
        Public Property Target As TripleKeyValuesPair()
        Public Property Metabolism As String

    End Class
End Namespace
