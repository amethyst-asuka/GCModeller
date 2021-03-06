﻿#Region "Microsoft.VisualBasic::ad398fd9ee5658cfd20531f0fe848a71, ..\core\Bio.Assembly\ProteinModel\Abstract.vb"

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

Imports SMRUCC.genomics.ComponentModel.Loci

Namespace ProteinModel

    ''' <summary>
    ''' 一个蛋白质结构域对象的抽象模型
    ''' </summary>
    Public Interface IMotifDomain

        ''' <summary>
        ''' 蛋白质结构域在数据库之中的编号或者名称
        ''' </summary>
        ''' <returns></returns>
        Property ID As String
        ''' <summary>
        ''' 在蛋白质分子序列上面的位置区域
        ''' </summary>
        ''' <returns></returns>
        Property Location As Location

    End Interface
End Namespace
