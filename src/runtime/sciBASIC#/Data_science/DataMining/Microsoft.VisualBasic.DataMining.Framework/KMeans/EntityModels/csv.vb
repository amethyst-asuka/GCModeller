﻿#Region "Microsoft.VisualBasic::fa795dea8fe861b66600c13bfe2ef469, ..\sciBASIC#\Data_science\DataMining\Microsoft.VisualBasic.DataMining.Framework\KMeans\EntityModels\csv.vb"

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
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection

Namespace KMeans

    ''' <summary>
    ''' 存储在Csv文件里面的数据模型，近似等价于<see cref="DataSet"/>，只不过多带了一个用来描述cluster的<see cref="Cluster"/>属性标签
    ''' </summary>
    Public Class EntityLDM : Inherits DynamicPropertyBase(Of Double)
        Implements INamedValue

        Public Property Name As String Implements INamedValue.Key

        <Meta(GetType(Double))>
        Public Overrides Property Properties As Dictionary(Of String, Double)
            Get
                Return MyBase.Properties
            End Get
            Set(value As Dictionary(Of String, Double))
                MyBase.Properties = value
            End Set
        End Property

        Public Property Cluster As String

        Public Sub Add(key As String, n As Double)
            Call Properties.Add(key, n)
        End Sub

        Public Overrides Function ToString() As String
            Return Name
        End Function

        Public Shared Function Load(path As String) As Entity()
            Return Entity.Load(path)
        End Function

        Public Function ToModel() As Entity
            Return New Entity With {
                .uid = Name,
                .Properties = Properties.Values.ToArray
            }
        End Function

        Public Shared Function Load(path As String, map As String) As EntityLDM()
            Dim maps As New Dictionary(Of String, String) From {
                {map, NameOf(EntityLDM.Name)}
            }
            Return path.LoadCsv(Of EntityLDM)(maps:=maps).ToArray
        End Function

        Public Shared Iterator Function FromModel(data As IEnumerable(Of NamedValue(Of Dictionary(Of String, Double)))) As IEnumerable(Of EntityLDM)
            For Each x As NamedValue(Of Dictionary(Of String, Double)) In data
                Yield New EntityLDM With {
                    .Name = x.Name,
                    .Properties = x.Value
                }
            Next
        End Function
    End Class
End Namespace
