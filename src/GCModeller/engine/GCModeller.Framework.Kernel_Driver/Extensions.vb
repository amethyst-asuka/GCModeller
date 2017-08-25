﻿#Region "Microsoft.VisualBasic::ddb63bef17e5e379d118ea0a1e5ecf6e, ..\GCModeller\engine\GCModeller.Framework.Kernel_Driver\Extensions.vb"

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

Imports System.Runtime.CompilerServices

Public Module Extensions

    <Extension> Public Function GetHandle(Of T)(DynamicsExpression As Framework.Kernel_Driver.IDynamicsExpression(Of T)) As Framework.Kernel_Driver.DataStorage.FileModel.ObjectHandle
        Return New Framework.Kernel_Driver.DataStorage.FileModel.ObjectHandle With {
            .Identifier = DynamicsExpression.Key,
            .Handle = DynamicsExpression.Address
        }
    End Function
End Module
