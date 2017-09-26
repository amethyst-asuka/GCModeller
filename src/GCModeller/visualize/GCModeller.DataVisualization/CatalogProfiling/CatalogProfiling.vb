﻿#Region "Microsoft.VisualBasic::86dde9961433d7d6bcfa46386292a4a0, ..\visualize\GCModeller.DataVisualization\CatalogProfiling\CatalogProfiling.vb"

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
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.ChartPlots
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic.Axis
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports Microsoft.VisualBasic.Scripting.Runtime

''' <summary>
''' COG, GO, KEGG
''' </summary>
Public Module CatalogProfiling

    <Extension>
    Public Function AsDouble(data As Dictionary(Of String, NamedValue(Of Integer)())) As Dictionary(Of String, NamedValue(Of Double)())
        Dim out As New Dictionary(Of String, NamedValue(Of Double)())

        For Each [class] In data
            out([class].Key) = [class] _
                .Value _
                .Select(Function(c)
                            Return New NamedValue(Of Double) With {
                                .Name = c.Name,
                                .Value = c.Value
                            }
                        End Function) _
                .ToArray
        Next

        Return out
    End Function

    ''' <summary>
    ''' No classification
    ''' </summary>
    Public Const NOT_ASSIGN As String = NameOf(NOT_ASSIGN)

    ''' <summary>
    ''' Catalog profiling bar plot
    ''' </summary>
    ''' <param name="profile"></param>
    ''' <param name="title$"></param>
    ''' <param name="colorSchema$"></param>
    ''' <param name="bg$"></param>
    ''' <param name="size"></param>
    ''' <param name="classFontStyle$"></param>
    ''' <param name="catalogFontStyle$"></param>
    ''' <param name="titleFontStyle$"></param>
    ''' <returns></returns>
    <Extension>
    Public Function ProfilesPlot(profile As Dictionary(Of String, NamedValue(Of Double)()),
                                 Optional title$ = "Profiling Plot",
                                 Optional axisTitle$ = "Number Of Gene",
                                 Optional colorSchema$ = "Set1:c6",
                                 Optional bg$ = "white",
                                 Optional size$ = "2200,2000",
                                 Optional padding$ = "padding: 125 25 25 25",
                                 Optional classFontStyle$ = CSSFont.Win7LargerBold,
                                 Optional catalogFontStyle$ = CSSFont.Win7Bold,
                                 Optional titleFontStyle$ = CSSFont.PlotTitle,
                                 Optional valueFontStyle$ = CSSFont.Win7Bold,
                                 Optional tickFontStyle$ = CSSFont.Win7LargerBold,
                                 Optional tick# = 50,
                                 Optional removeNotAssign As Boolean = True,
                                 Optional gray As Boolean = False,
                                 Optional labelRightAlignment As Boolean = False) As GraphicsData

        If removeNotAssign AndAlso profile.ContainsKey(NOT_ASSIGN) Then
            profile = New Dictionary(Of String, NamedValue(Of Double)())(profile)
            profile.Remove(NOT_ASSIGN)
        End If

        Dim colors As Color() = Designer.FromSchema(colorSchema, profile.Count - 1)
        Dim mapper As New Scaling(
            profile _
            .Values _
            .Select(Function(c) c.Select(Function(v) CDbl(v.Value))) _
            .IteratesALL, horizontal:=True)

        Dim plotInternal =
            Sub(ByRef g As IGraphics, region As GraphicsRegion)
                Call g.__plotInternal(
                   region, profile, title,
                   colors,
                   titleFontStyle, catalogFontStyle, classFontStyle, valueFontStyle,
                   New Mapper(mapper, ignoreAxis:=True),
                   tickFontStyle, tick,
                   axisTitle,
                   gray:=gray,
                   labelAlignmentRight:=labelRightAlignment)
            End Sub

        Return g.GraphicsPlots(size.SizeParser, padding, bg, plotInternal)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="region"></param>
    ''' <param name="profile"></param>
    ''' <param name="title$">图形上方的标题字符串</param>
    ''' <param name="colors"></param>
    ''' <param name="titleFontStyle$"></param>
    ''' <param name="catalogFontStyle$"></param>
    ''' <param name="classFontStyle$"></param>
    ''' <param name="valueFontStyle$"></param>
    ''' <param name="mapper"></param>
    ''' <param name="tickFontStyle$"></param>
    ''' <param name="tick#"></param>
    ''' <param name="axisTitle$"></param>
    ''' <param name="gray">条形图使用灰色的颜色，不再根据分类而产生不同颜色了</param>
    <Extension>
    Private Sub __plotInternal(ByRef g As IGraphics, region As GraphicsRegion,
                               profile As Dictionary(Of String, NamedValue(Of Double)()),
                               title$,
                               colors As Color(),
                               titleFontStyle$,
                               catalogFontStyle$,
                               classFontStyle$, valueFontStyle$,
                               mapper As Mapper,
                               tickFontStyle$,
                               tick#,
                               axisTitle$,
                               gray As Boolean,
                               labelAlignmentRight As Boolean)

        ' 这里是大标签的字符串向量
        Dim classes$() = profile.Keys.ToArray
        Dim titleFont As Font = CSSFont.TryParse(titleFontStyle).GDIObject
        Dim catalogFont As Font = CSSFont.TryParse(catalogFontStyle).GDIObject
        Dim classFont As Font = CSSFont.TryParse(classFontStyle).GDIObject
        Dim padding As Padding = region.Padding
        Dim size As Size = region.Size

        Dim maxLenSubKey$ = profile _
            .Values _
            .Select(Function(o) o.Select(Function(oo) oo.Name)) _
            .IteratesALL _
            .OrderByDescending(Function(s) s.Length) _
            .First
        Dim maxLenClsKey$ = classes _
            .OrderByDescending(Function(s) s.Length) _
            .First
        Dim maxLenSubKeySize As SizeF = g.MeasureString(maxLenSubKey, catalogFont)
        Dim maxLenClsKeySize As SizeF = g.MeasureString(maxLenClsKey, classFont)
        Dim valueFont As Font = CSSFont.TryParse(valueFontStyle)

        ' 所绘制的图形的总的高度
        Dim totalHeight = classes.Length * (maxLenClsKeySize.Height + 5) +
            profile.Values.IteratesALL.Count * (maxLenSubKeySize.Height + 4) +
            classes.Length * 20
        Dim left!
        Dim y! = region.Padding.Top + (region.PlotRegion.Height - totalHeight) / 2

        ' barPlot的最左边的坐标
        Dim barRect As New Rectangle With {
            .X = padding.Left * 1.5 + Math.Max(maxLenSubKeySize.Width, maxLenClsKeySize.Width),
            .Y = y,
            .Width = size.Width - padding.Horizontal - Math.Max(maxLenSubKeySize.Width, maxLenClsKeySize.Width) - padding.Left / 2,
            .Height = totalHeight
        }

        left = barRect.Left - padding.Left
        left = (size.Width - padding.Horizontal - left) / 2 + left + padding.Left

        Dim titleSize As SizeF = g.MeasureString(title, titleFont)
        Dim anchor As New PointF With {
            .X = barRect.Left + (barRect.Width - titleSize.Width) / 2,
            .Y = (y - titleSize.Height) / 2.0!
        }

        ' 在这里进行plot的标题的绘制操作
        Call g.DrawString(title, titleFont, Brushes.Black, anchor)
        Call g.DrawRectangle(New Pen(Color.Black, 5), barRect)

        Dim gap! = 10.0!
        Dim grayColor As DefaultValue(Of Color) = Color.Gray.AsDefault(Function() gray)

        left = padding.Left

        For Each [class] As SeqValue(Of String) In classes.SeqIterator
            Dim color As New SolidBrush(colors([class]))
            Dim penColor As Color = colors([class]) Or grayColor
            Dim linePen As New Pen(penColor, 2) With {
                .DashStyle = DashStyle.Dot
            }
            Dim yPlot!
            Dim barWidth!
            Dim barRectPlot As Rectangle
            Dim valueSize As SizeF
            Dim valueLeft!
            Dim valueLabel$

            If gray Then
                color = "rgb(30,30,30)".GetBrush
            End If

            ' 绘制Class大分类的标签
            Call g.DrawString(+[class], classFont, Brushes.Black, New PointF(left, y))
            y += maxLenClsKeySize.Height + 5

            ' 绘制统计的小分类标签以及barplot图形
            For Each cata As NamedValue(Of Double) In profile(+[class])
                Dim pos As PointF

                If labelAlignmentRight Then
                    ' 重新计算位置进行右对齐操作
                    pos = New PointF With {
                        .X = barRect.Left - 25 - g.MeasureString(cata.Name, catalogFont).Width,
                        .Y = y
                    }
                Else
                    pos = New PointF(left + 25, y)
                End If

                Call g.DrawString(cata.Name, catalogFont, color, pos)

                ' 绘制虚线
                yPlot = y + maxLenSubKeySize.Height / 2
                barWidth = mapper.ScallingWidth(cata.Value, barRect.Width - gap)
                barRectPlot = New Rectangle With {
                    .Location = New Point(barRect.Left, y),
                    .Size = New Size With {
                        .Width = barWidth - gap,
                        .Height = maxLenSubKeySize.Height
                    }
                }

                valueLabel = cata.Value.ToString("F2")
                valueSize = g.MeasureString(valueLabel, valueFont)
                valueLeft = barRectPlot.Right - valueSize.Width

                If valueLeft < barRect.Left Then
                    valueLeft = barRect.Left + 2
                End If

                Call g.DrawLine(linePen, New Point(barRect.Left, yPlot), New Point(barRect.Right, yPlot))
                Call g.FillRectangle(color, barRectPlot)

                If Not gray Then
                    ' 如果是灰度的图，就不需要再绘制值得标签字符串了，因为灰色和黑色的颜色太相近了，看不清楚
                    anchor = New PointF With {
                        .X = valueLeft,
                        .Y = y - valueSize.Height / 3
                    }
                    Call g.DrawString(valueLabel, valueFont, Brushes.Black, anchor)
                End If

                y += maxLenSubKeySize.Height + 4
            Next

            y += 20
        Next

        Dim maxValue# = profile.Values.Max(Function(v) If(v.Length = 0, 0, v.Max(Function(n) n.Value)))
        Dim axisTicks#() = GetTicks(maxValue, tick)
        Dim d# = 25
        Dim tickFont = CSSFont.TryParse(tickFontStyle)
        Dim tickSize As SizeF
        Dim tickPen As New Pen(Color.Black, 3)

        For Each tick In axisTicks.Where(Function(v) v <= maxValue)
            Dim tickX = barRect.Left + mapper.ScallingWidth(tick, barRect.Width - gap)

            tickSize = g.MeasureString(tick, tickFont)
            anchor = New PointF With {
                .X = tickX - tickSize.Width / 2,
                .Y = y + d + 10
            }

            Call g.DrawLine(tickPen, New PointF(tickX, y), New PointF(tickX, y + d))
            Call g.DrawString(tick, tickFont, Brushes.Black, anchor)
        Next

        y += 75

        titleFont = CSSFont.TryParse(CSSFont.Win7LargerBold)
        titleSize = g.MeasureString(title, titleFont)
        left = barRect.Left + (barRect.Width - titleSize.Width) / 2

        Call g.DrawString(axisTitle, titleFont, Brushes.Black, New PointF(left, y))
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="max#"></param>
    ''' <param name="tick!">
    ''' 如果间隔参数是小于零的话，函数则会自动根据[0, <paramref name="max"/>]区间来生成tick，否则会直接使用<paramref name="tick"/>间隔叠加到<paramref name="max"/>产生tick序列
    ''' </param>
    ''' <returns></returns>
    Private Function GetTicks(max#, tick!) As Double()
        If tick <= 0 Then
            ' 自动生成
            Call "Ticks created from auto axis ticking...".__INFO_ECHO
            Return AxisScalling.CreateAxisTicks({0, max})
        Else
            Call "Ticks created from tick sequence...".__INFO_ECHO
            Return AxisScalling.GetAxisByTick(max, tick)
        End If
    End Function
End Module
