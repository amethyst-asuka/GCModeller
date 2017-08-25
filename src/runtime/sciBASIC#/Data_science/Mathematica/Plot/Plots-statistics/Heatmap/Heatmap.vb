﻿#Region "Microsoft.VisualBasic::6e9eddf5dbaf07f708b12a876ac34839, ..\sciBASIC#\Data_science\Mathematica\Plot\Plots\Heatmaps\Heatmap.vb"

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
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math
Imports Microsoft.VisualBasic.Math.Correlations
Imports Microsoft.VisualBasic.Math.Correlations.Correlations
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports Microsoft.VisualBasic.Scripting.Runtime

Namespace Heatmap

    ''' <summary>
    ''' A heat map (or heatmap) is a graphical representation of data where the individual values 
    ''' contained in a matrix are represented as colors. The term 'heat map' was originally coined 
    ''' and trademarked by software designer Cormac Kinney in 1991, to describe a 2D display 
    ''' depicting financial market information,[1] though similar plots such as shading matrices 
    ''' have existed for over a century.
    ''' </summary>
    Public Module Heatmap

        ''' <summary>
        ''' 相比于<see cref="LoadDataSet(String, String, Boolean, Correlations.ICorrelation)"/>函数，这个函数处理的是没有经过归一化处理的原始数据
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="correlation">假若这个参数为空，则默认使用<see cref="Correlations.GetPearson(Double(), Double())"/></param>
        ''' <returns></returns>
        <Extension>
        Public Iterator Function CorrelatesNormalized(
                                    data As IEnumerable(Of DataSet),
                    Optional correlation As Correlations.ICorrelation = Nothing) _
                                         As IEnumerable(Of NamedValue(Of Dictionary(Of String, Double)))

            Dim dataset As DataSet() = data.ToArray
            Dim keys$() = dataset(Scan0) _
                .Properties _
                .Keys _
                .ToArray

            If correlation Is Nothing Then
                correlation = AddressOf Correlations.GetPearson
            End If

            For Each x As DataSet In dataset
                Dim out As New Dictionary(Of String, Double)
                Dim array As Double() = keys.ToArray(Function(o$) x(o))

                For Each y As DataSet In dataset
                    out(y.ID) = correlation(
                    array,
                    keys.ToArray(Function(o) y(o)))
                Next

                Yield New NamedValue(Of Dictionary(Of String, Double)) With {
                    .Name = x.ID,
                    .Value = out
                }
            Next
        End Function

        ''' <summary>
        ''' (这个函数是直接加在已经计算好了的相关度数据).假若使用这个直接加载数据来进行heatmap的绘制，
        ''' 请先要确保数据集之中的所有数据都是经过归一化的，假若没有归一化，则确保函数参数
        ''' <paramref name="normalization"/>的值为真
        ''' </summary>
        ''' <param name="path"></param>
        ''' <param name="uidMap$"></param>
        ''' <param name="normalization">是否对输入的数据集进行归一化处理？</param>
        ''' <param name="correlation">
        ''' 默认为<see cref="Correlations.GetPearson(Double(), Double())"/>方法
        ''' </param>
        ''' <returns></returns>
        <Extension>
        Public Function LoadDataSet(path As String,
                                    Optional uidMap$ = Nothing,
                                    Optional normalization As Boolean = False,
                                    Optional correlation As ICorrelation = Nothing) As NamedValue(Of Dictionary(Of String, Double))()

            Dim ds As IEnumerable(Of DataSet) = DataSet.LoadDataSet(path, uidMap)

            If normalization Then
                Return ds.CorrelatesNormalized(correlation).ToArray
            Else
                Return LinqAPI.Exec(Of NamedValue(Of Dictionary(Of String, Double))) _
 _
                    () <= From x As DataSet
                          In ds
                          Select New NamedValue(Of Dictionary(Of String, Double)) With {
                              .Name = x.ID,
                              .Value = x.Properties
                          }
            End If
        End Function

        ' dendrogramLayout$ = A,B
        '                                         |
        '    A                                    | B
        ' ------+---------------------------------+
        '       |
        '       |
        '       |
        '       |

        ''' <summary>
        ''' 可以用来表示任意变量之间的相关度
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="customColors">
        ''' 可以使用这一组颜色来手动自定义heatmap的颜色，也可以使用<paramref name="mapName"/>来获取内置的颜色谱
        ''' </param>
        ''' <param name="mapLevels%"></param>
        ''' <param name="mapName$">
        ''' The color map name, using for the <see cref="Designer"/>
        ''' 
        ''' There are many different color schemes that can be used to illustrate the heatmap, with perceptual advantages 
        ''' and disadvantages for each. Rainbow colormaps are often used, as humans can perceive more shades of color than 
        ''' they can of gray, and this would purportedly increase the amount of detail perceivable in the image. However, 
        ''' this is discouraged by many in the scientific community, for the following reasons:
        '''
        ''' + The colors lack the natural perceptual ordering found In grayscale Or blackbody spectrum colormaps.
        ''' + Common colormaps(Like the "jet" colormap used As the Default In many visualization software packages) have 
        '''   uncontrolled changes In luminance that prevent meaningful conversion To grayscale For display Or printing. 
        '''   This also distracts from the actual data, arbitrarily making yellow And cyan regions appear more prominent 
        '''   than the regions Of the data that are actually most important.[citation needed]
        ''' + The changes between colors also lead To perception Of gradients that aren't actually present, making actual 
        '''   gradients less prominent, meaning that rainbow colormaps can actually obscure detail in many cases rather than 
        '''   enhancing it.
        ''' </param>
        ''' <param name="size"></param>
        ''' <param name="bg$"></param>
        ''' <param name="logTransform">0或者小于零的数表示不会进行log变换</param>
        ''' <returns></returns>
        <Extension>
        Public Function Plot(data As IEnumerable(Of DataSet),
                             Optional customColors As Color() = Nothing,
                             Optional reverseClrSeq As Boolean = False,
                             Optional mapLevels% = 100,
                             Optional mapName$ = ColorMap.PatternJet,
                             Optional size$ = "3000,2700",
                             Optional padding$ = g.DefaultPadding,
                             Optional bg$ = "white",
                             Optional logTransform# = 0,
                             Optional drawScaleMethod As DrawElements = DrawElements.Cols,
                             Optional drawLabels As DrawElements = DrawElements.Both,
                             Optional drawDendrograms As DrawElements = DrawElements.Rows,
                             Optional dendrogramLayout$ = "200,200",
                             Optional rowLabelfontStyle$ = CSSFont.Win7Normal,
                             Optional colLabelFontStyle$ = CSSFont.Win7LargerBold,
                             Optional legendTitle$ = "Heatmap Color Legend",
                             Optional legendFontStyle$ = CSSFont.PlotSubTitle,
                             Optional min# = -1,
                             Optional max# = 1,
                             Optional mainTitle$ = "heatmap",
                             Optional titleFontCSS$ = CSSFont.Win7VeryLarge,
                             Optional drawGrid As Boolean = False,
                             Optional drawValueLabel As Boolean = False,
                             Optional valuelabelFontCSS$ = CSSFont.PlotLabelNormal,
                             Optional legendWidth! = -1,
                             Optional legendHasUnmapped As Boolean = True,
                             Optional legendSize$ = "600,100") As GraphicsData

            Dim valuelabelFont As Font = CSSFont.TryParse(valuelabelFontCSS)
            Dim array As DataSet() = data.ToArray
            Dim dlayout As (A%, B%)
            Dim dataTable As Dictionary(Of DataSet) = array.ToDictionary

            With dendrogramLayout.SizeParser
                dlayout = (.Width, .Height)
            End With

            Dim titleFont As Font = CSSFont.TryParse(titleFontCSS)
            Dim legendFont As Font = CSSFont.TryParse(legendFontStyle)
            Dim margin As Padding = padding
            Dim rowLabelFont As Font = CSSFont.TryParse(rowLabelfontStyle).GDIObject
            Dim plotInternal =
                Sub(g As IGraphics, region As GraphicsRegion, args As PlotArguments)

                    Dim dw! = args.dStep.Width, dh! = args.dStep.Height
                    Dim blockSize As New SizeF(dw, dh)
                    Dim colors As SolidBrush() = args.colors

                    ' 按行绘制heatmap之中的矩阵
                    For Each x As DataSet In args.RowOrders.Select(Function(key) dataTable(key))     ' 在这里绘制具体的矩阵
                        Dim levelRow As DataSet = args.levels(x.ID)

                        For Each key As String In args.ColOrders
                            Dim c# = x(key)
                            Dim level% = levelRow(key)  '  得到等级
                            Dim b = colors(
                                If(level% > colors.Length - 1,
                                    colors.Length - 1,
                                    level))
                            Dim rect As New RectangleF(New PointF(args.left, args.top), blockSize)
#If DEBUG Then
                            ' Call $"{level} -> {b.Color.ToString}".__DEBUG_ECHO
#End If
                            Call g.FillRectangle(b, rect)

                            If drawGrid Then
                                Call g.DrawRectangles(Pens.WhiteSmoke, {rect})
                            End If
                            If drawValueLabel Then
                                key = c.FormatNumeric(2)
                                Dim ksz As SizeF = g.MeasureString(key, valuelabelFont)
                                Dim kpos As New PointF With {
                                    .X = rect.Left + (rect.Width - ksz.Width) / 2,
                                    .Y = rect.Top + (rect.Height - ksz.Height) / 2
                                }
                                Call g.DrawString(key, valuelabelFont, Brushes.White, kpos)
                            End If

                            args.left += dw!
                        Next

                        args.left = args.matrixPlotRegion.Left
                        args.top += dh!

                        ' debug
                        ' Call g.DrawLine(Pens.Blue, New Point(args.left, args.top), New Point(args.matrixPlotRegion.Right, args.top))

                        If drawLabels = DrawElements.Both OrElse drawLabels = DrawElements.Rows Then
                            Dim sz As SizeF = g.MeasureString(x.ID, rowLabelFont)
                            Dim y As Single = args.top - dh - (sz.Height - dh) / 2
                            Dim lx As Single = args.matrixPlotRegion.Right + 10

                            ' 绘制行标签
                            Call g.DrawString(x.ID, rowLabelFont, Brushes.Black, New PointF(lx, y))
                        End If
                    Next

                    ' debug
                    ' Call g.DrawRectangle(Pens.LawnGreen, args.matrixPlotRegion)
                End Sub

            Return __plotInterval(
                plotInternal, array,
                rowLabelFont, CSSFont.TryParse(colLabelFontStyle).GDIObject, logTransform, drawScaleMethod, drawLabels, drawDendrograms, dlayout,
                reverseClrSeq, customColors.GetBrushes, mapLevels, mapName,
                size.SizeParser, margin, bg,
                legendTitle, legendFont, Nothing,
                min, max,
                mainTitle, titleFont,
                legendWidth, legendHasUnmapped, legendSize.SizeParser)
        End Function
    End Module
End Namespace