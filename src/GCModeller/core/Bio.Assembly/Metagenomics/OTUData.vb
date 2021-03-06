﻿#Region "Microsoft.VisualBasic::cefa2238cff4432dc9b59da128512e20, ..\core\Bio.Assembly\Metagenomics\OTUData.vb"

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

Imports System.Data.Linq.Mapping
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Metagenomics

    ''' <summary>
    ''' <see cref="OTUData.Data"/> that associated with <see cref="OTUData.OTU"/> tag
    ''' </summary>
    Public Class OTUData : Implements INamedValue

        ''' <summary>
        ''' ``#OTU_num``
        ''' </summary>
        ''' <returns></returns>
        <Column(Name:="#OTU_num")>
        Public Property OTU As String Implements INamedValue.Key
        ''' <summary>
        ''' Usually this property is the BIOM format taxonomy information
        ''' </summary>
        ''' <returns></returns>
        Public Property Taxonomy As String
        Public Property Data As Dictionary(Of String, String)

        Sub New()
        End Sub

        Sub New(data As OTUData)
            With Me
                .OTU = data.OTU
                .Data = New Dictionary(Of String, String)(data.Data)
            End With
        End Sub

        Public Overrides Function ToString() As String
            Return OTU & " --> " & Data.GetJson
        End Function
    End Class
End Namespace
