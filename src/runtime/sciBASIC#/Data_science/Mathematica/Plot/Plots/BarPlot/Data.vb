﻿#Region "Microsoft.VisualBasic::208c1391708af97c27d85f43eb6efb01, ..\sciBASIC#\Data_science\Mathematica\Plot\Plots\BarPlot\Data.vb"

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

Imports System.Drawing
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math
Imports Microsoft.VisualBasic.Math.LinearAlgebra
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace BarPlot

    Public Class BarDataSample : Implements INamedValue

        ''' <summary>
        ''' 分组名称
        ''' </summary>
        ''' <returns></returns>
        Public Property Tag As String Implements INamedValue.Key
        ''' <summary>
        ''' 当前分组下的每一个序列的数据值
        ''' </summary>
        ''' <returns></returns>
        Public Property data As Double()

        ''' <summary>
        ''' The sum of <see cref="data"/>
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property StackedSum As Double
            Get
                Return data.Sum
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class

    Public Class BarDataGroup : Inherits ProfileGroup

        ''' <summary>
        ''' 与<see cref="BarDataSample.data"/>里面的数据顺序是一致的
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Property Serials As NamedValue(Of Color)()

        ''' <summary>
        ''' 分组数据
        ''' </summary>
        ''' <returns></returns>
        Public Property Samples As BarDataSample()
        Public Property Index As NamedVectorFactory

        Public Overrides Function ToString() As String
            Return Samples.Keys.GetJson
        End Function

        ''' <summary>
        ''' 如果系列在这里面，则会一次排在前面，否则任然是按照原始的顺序排布
        ''' </summary>
        ''' <param name="orders$"></param>
        ''' <returns></returns>
        Public Function Reorder(ParamArray orders$()) As BarDataGroup
            Dim oldOrders = Me.Serials _
                .Keys _
                .SeqIterator _
                .ToDictionary(Function(x) x.value,
                              Function(x) x.i)
            Dim newOrders As New List(Of SeqValue(Of String))

            For Each name In orders
                newOrders += New SeqValue(Of String) With {
                    .i = oldOrders(name),
                    .value = name
                }
                oldOrders.Remove(name)
            Next

            newOrders += oldOrders _
                .Select(Function(x)
                            Return New SeqValue(Of String) With {
                                .i = x.Value,
                                .value = x.Key
                            }
                        End Function)

            Dim serials = newOrders _
                .Select(Function(i) Me.Serials(i)) _
                .ToArray
            Dim groups As New List(Of BarDataSample)

            For Each g In Me.Samples
                groups += New BarDataSample With {
                    .Tag = g.Tag,
                    .data = newOrders _
                        .Select(Function(i) g.data(i)) _
                        .ToArray
                }
            Next

            Return New BarDataGroup With {
                .Index = Index,
                .Samples = groups,
                .Serials = serials
            }
        End Function

        ''' <summary>
        ''' 这个应该是生成直方图的数据
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="base!"></param>
        ''' <param name="color$"></param>
        ''' <returns></returns>
        Public Shared Function FromDistributes(data As IEnumerable(Of Double), Optional base! = 10.0F, Optional color$ = "darkblue") As BarDataGroup
            Dim source = data.Distributes(base!)
            Dim bg As Color = color.ToColor(onFailure:=Drawing.Color.DarkBlue)
            Dim values As New List(Of Double)
            Dim serials = LinqAPI.Exec(Of NamedValue(Of Color)) <=
 _
                From lv As Integer
                In source.Keys
                Select New NamedValue(Of Color) With {
                    .Name = lv.ToString,
                    .Value = bg
                }

            For Each x In serials
                values += source(CInt(x.Name)).Value
            Next

            Return New BarDataGroup With {
                .Serials = serials,
                .Samples = {
                    New BarDataSample With {
                        .Tag = "Distribution",
                        .data = values
                    }
                }
            }
        End Function
    End Class
End Namespace
