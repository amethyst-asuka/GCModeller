﻿#Region "Microsoft.VisualBasic::daea91fe17c7c2fc2827d98521497d57, ..\core\Bio.Assembly\Assembly\KEGG\Medical\Disease.vb"

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

Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Assembly.KEGG.DBGET.bGetObject
Imports SMRUCC.genomics.ComponentModel.DBLinkBuilder

Namespace Assembly.KEGG.Medical

    Public Class Disease : Implements INamedValue

        Public Property Entry As String Implements INamedValue.Key
        Public Property Names As String()
        Public Property Description As String
        Public Property Category As String
        Public Property Genes As String()
        Public Property Carcinogen As String()
        Public Property Pathogens As String()
        Public Property Markers As String()
        Public Property Drugs As String()

        ''' <summary>
        ''' 多行数据已经join过了的单行字符串
        ''' </summary>
        ''' <returns></returns>
        Public Property Comments As String
        Public Property DbLinks As DBLink()
        Public Property References As Reference()
        Public Property Env_factors As String()

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class
End Namespace

