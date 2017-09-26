﻿Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Ranges
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic.Axis
Imports Microsoft.VisualBasic.Data.Graph
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports Microsoft.VisualBasic.Scripting.Runtime

Namespace Heatmap

    ''' <summary>
    ''' 类似于<see cref="Contour"/>，但是这个是基于点的密度来绘图的
    ''' </summary>
    Public Module DensityPlot

        ''' <summary>
        ''' Similar to the <see cref="Contour"/> plot but plot in scatter mode.
        ''' </summary>
        ''' <param name="points"></param>
        ''' <param name="size$"></param>
        ''' <param name="padding$"></param>
        ''' <param name="bg$"></param>
        ''' <param name="schema$"></param>
        ''' <returns></returns>
        Public Function Plot(points As IEnumerable(Of PointF),
                             Optional size$ = "1600,1200",
                             Optional padding$ = g.DefaultPadding,
                             Optional bg$ = "white",
                             Optional schema$ = "Jet",
                             Optional levels% = 20,
                             Optional steps$ = Nothing,
                             Optional ptSize! = 5,
                             Optional legendWidth% = 150,
                             Optional legendTitleFontCSS$ = CSSFont.Win7LargerNormal,
                             Optional legendTickFontCSS$ = CSSFont.Win7Normal,
                             Optional legendTickStrokeCSS$ = Stroke.AxisStroke) As GraphicsData

            Dim data = points _
                .Where(Function(pt)
                           Return Not New Double() {
                               pt.X, pt.Y
                           }.Any(Function(x)
                                     Return x.IsNaNImaginary
                                 End Function)
                       End Function) _
                .VectorShadows
            Dim xrange As DoubleRange = DirectCast(data.X, VectorShadows(Of Single)) ' As IEnumerable(Of Single)
            Dim yrange As DoubleRange = DirectCast(data.Y, VectorShadows(Of Single)) ' As IEnumerable(Of Single)
            Dim pointData = DirectCast(data, VectorShadows(Of PointF))
            Dim colors$() = Designer _
                .GetColors(schema, levels) _
                .Select(Function(c) c.ToHtmlColor) _
                .ToArray
            Dim density = (xrange, yrange) _
                .Grid(steps.FloatSizeParser) _
                .DensityMatrix(
                    pointData,
                    schema:=colors,
                    r:=ptSize)
            Dim scatterPadding As Padding = padding

            scatterPadding.Right += legendWidth

            Using g As IGraphics = Scatter.Plot(
                c:={density},
                size:=size, padding:=scatterPadding, bg:=bg,
                drawLine:=False,
                showLegend:=False,
                fillPie:=True).CreateGraphics

                ' 在这里还需要绘制颜色谱的legend
                ' 计算出legend的layout信息
                ' 竖直样式的legend：右边居中，宽度为legendwidth，高度则是plotregion的高度的2/3
                Dim plotRegion As New GraphicsRegion With {
                    .Size = g.Size,
                    .Padding = scatterPadding
                }
                Dim scatterRegion As Rectangle = plotRegion.PlotRegion
                Dim legendHeight! = scatterRegion.Height * 2 / 3
                Dim legendLayout As New Rectangle With {
                    .Size = New Size With {
                        .Width = legendWidth,
                        .Height = legendHeight
                    },
                    .Location = New Point With {
                        .X = scatterRegion.Right,
                        .Y = (scatterRegion.Height - legendHeight) / 2 + scatterPadding.Top
                    }
                }
                Dim designer As SolidBrush() = colors _
                    .Select(AddressOf TranslateColor) _
                    .Select(Function(c) New SolidBrush(c)) _
                    .ToArray
                Dim rangeTicks = density _
                    .pts _
                    .Select(Function(pt) pt.Statics) _
                    .IteratesALL _
                    .Range _
                    .CreateAxisTicks
                Dim legendTitleFont As Font = CSSFont.TryParse(legendTitleFontCSS).GDIObject
                Dim legendTickFont As Font = CSSFont.TryParse(legendTickFontCSS).GDIObject
                Dim legendTickStroke As Pen = Stroke.TryParse(legendTickStrokeCSS).GDIObject

                Call Legends.ColorMapLegend(
                    g, legendLayout, designer, rangeTicks,
                    legendTitleFont, "Density",
                    tickFont:=legendTickFont,
                    tickAxisStroke:=legendTickStroke,
                    unmapColor:=NameOf(Color.Gray))

                If TypeOf g Is Graphics2D Then
                    Return New ImageData(DirectCast(g, Graphics2D).ImageResource, g.Size)
                Else
                    Return New SVGData(g, g.Size)
                End If
            End Using
        End Function

        ''' <summary>
        ''' Create point density function by using <see cref="Grid"/> model
        ''' </summary>
        ''' <param name="grid"></param>
        ''' <param name="points"></param>
        ''' <returns></returns>
        <Extension>
        Public Function DensityMatrix(grid As Grid, points As IEnumerable(Of PointF), schema$(), r!) As SerialData
            ' 先统计出网络之中的每一个方格的点的数量，然后将数量转换为颜色值，生成散点图的模型
            Dim pointData As PointF() = points.ToArray
            Dim gridIndex = pointData _
                .Select(AddressOf grid.Index) _
                .ToArray
            Dim counts = gridIndex _
                .GroupBy(Function(index) index.ToString) _
                .ToDictionary(Function(index) index.Key,
                              Function(n) n.Count)
            Dim range As New IntRange(counts.Values)
            Dim colorIndex As IntRange = {0, schema.Length - 1}
            Dim density = gridIndex _
                .Select(Function(index) counts(index.ToString)) _
                .Select(Function(d)
                            Return range _
                                .ScaleMapping(d, colorIndex) _
                                .As(Of Integer)
                        End Function) _
                .ToArray
            Dim serialData = pointData _
                .SeqIterator _
                .Select(Function(pt)
                            Return New PointData With {
                                .value = density(pt),
                                .color = schema(CInt(.value)),
                                .pt = pt,
                                .Statics = {
                                    CDbl(counts(gridIndex(pt).ToString))
                                }
                            }
                        End Function) _
                .OrderBy(Function(pt) pt.value) _
                .ToArray

            Return New SerialData With {
                .color = Color.Black,
                .pts = serialData,
                .PointSize = r!
            }
        End Function
    End Module
End Namespace