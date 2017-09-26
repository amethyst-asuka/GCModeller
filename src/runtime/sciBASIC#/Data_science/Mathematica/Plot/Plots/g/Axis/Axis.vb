﻿#Region "Microsoft.VisualBasic::622df45bf8c9b9f10b6a38d76e990985, ..\sciBASIC#\Data_science\Mathematica\Plot\Plots\g\Axis\Axis.vb"

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
Imports Microsoft.VisualBasic.Data.ChartPlots.Plot3D
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.BitmapImage
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Text
Imports Microsoft.VisualBasic.Math
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports Microsoft.VisualBasic.Scripting.Runtime
Imports Microsoft.VisualBasic.Text.HtmlParser

Namespace Graphic.Axis

    Public Module Axis

        ''' <summary>
        ''' 绘制按照任意角度旋转的文本
        ''' </summary>
        ''' <param name="g"></param>
        ''' <param name="text"></param>
        ''' <param name="font"></param>
        ''' <param name="brush"></param>
        ''' <param name="x!"></param>
        ''' <param name="y!"></param>
        ''' <param name="angle!"></param>
        <Extension>
        Public Sub DrawString(g As IGraphics, text$, font As Font, brush As Brush, x!, y!, angle!)
            With g
                Call g.TranslateTransform(.Size.Width / 2, .Size.Height / 2)
                Call g.RotateTransform(angle)

                ' 不清楚旋转之后会不会对字符串的大小产生影响，所以measureString放在旋转之后
                Dim textSize As SizeF = g.MeasureString(text, font)
                Call g.DrawString(text, font, brush, -(textSize.Width / 2), -(textSize.Height / 2))
                Call g.ResetTransform()
            End With
        End Sub

        <Extension>
        Public Sub DrawAxis(ByRef g As IGraphics, region As GraphicsRegion,
                            scaler As DataScaler,
                            showGrid As Boolean,
                            Optional offset As Point = Nothing,
                            Optional xlabel$ = "",
                            Optional ylabel$ = "",
                            Optional xlayout As XAxisLayoutStyles = XAxisLayoutStyles.Bottom,
                            Optional ylayout As YAxisLayoutStyles = YAxisLayoutStyles.Left,
                            Optional labelFont$ = CSSFont.PlotSubTitle,
                            Optional axisStroke$ = Stroke.AxisStroke,
                            Optional gridFill$ = "rgb(245,245,245)")
            With region
                Call g.DrawAxis(
                    scaler,
                    showGrid,
                    offset,
                    xlabel, ylabel,
                    xlayout:=xlayout, ylayout:=ylayout,
                    labelFontStyle:=labelFont,
                    axisStroke:=axisStroke, gridFill:=gridFill)
            End With
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="g"></param>
        ''' <param name="scaler">Drawing Point data auto scaler</param>
        ''' <param name="showGrid">Show axis grid on the plot region?</param>
        ''' <param name="xlayout">修改y属性</param>
        ''' <param name="ylayout">修改x属性</param>
        <Extension>
        Public Sub DrawAxis(ByRef g As IGraphics,
                            scaler As DataScaler,
                            showGrid As Boolean,
                            Optional offset As Point = Nothing,
                            Optional xlabel$ = "",
                            Optional ylabel$ = "",
                            Optional labelFontStyle$ = CSSFont.PlotSubTitle,
                            Optional xlayout As XAxisLayoutStyles = XAxisLayoutStyles.Bottom,
                            Optional ylayout As YAxisLayoutStyles = YAxisLayoutStyles.Left,
                            Optional gridFill$ = "rgb(245,245,245)",
                            Optional gridColor$ = "white",
                            Optional axisStroke$ = Stroke.AxisStroke,
                            Optional tickFontStyle$ = CSSFont.Win7Normal)

            ' 填充网格要先于坐标轴的绘制操作进行，否则会将坐标轴给覆盖掉
            Dim rect As Rectangle = scaler.ChartRegion
            Dim tickFont As Font = CSSFont.TryParse(tickFontStyle)
            Dim gridPenX As New Pen(gridColor.TranslateColor, 2) With {
                .DashStyle = Drawing2D.DashStyle.Dash
            }
            Dim gridPenY As New Pen(gridColor.TranslateColor, 2) With {
                .DashStyle = Drawing2D.DashStyle.Dot
            }

            Call g.FillRectangle(gridFill.GetBrush, rect)

            If Not scaler.AxisTicks.X.IsNullOrEmpty Then
                For Each tick In scaler.AxisTicks.X
                    Dim x = scaler.X(tick) + offset.X
                    Dim top As New Point(x, rect.Top)
                    Dim bottom As New Point(x, rect.Bottom)

                    ' 绘制x网格线
                    Call g.DrawLine(gridPenX, top, bottom)
                Next
            End If

            If Not scaler.AxisTicks.Y.IsNullOrEmpty Then
                For Each tick In scaler.AxisTicks.Y
                    Dim y = scaler.TranslateY(tick) + offset.Y
                    Dim left As New Point(rect.Left, y)
                    Dim right As New Point(rect.Right, y)

                    ' 绘制y网格线
                    Call g.DrawLine(gridPenY, left, right)
                Next
            End If

            Dim pen As Pen = Stroke.TryParse(axisStroke).GDIObject

            If xlayout <> XAxisLayoutStyles.None Then
                Call g.DrawX(pen, xlabel, scaler, xlayout, offset, labelFontStyle, tickFont)
            End If
            If ylayout <> YAxisLayoutStyles.None Then
                Call g.DrawY(pen, ylabel, scaler, ylayout, offset, labelFontStyle, tickFont)
            End If
        End Sub

        <Extension>
        Public Sub DrawYGrid(scaler As DataScaler, g As IGraphics, region As GraphicsRegion,
                             pen As Pen,
                             label$,
                             Optional offset As Point = Nothing,
                             Optional labelFont$ = CSSFont.Win7Large,
                             Optional tickFont$ = CSSFont.Win10NormalLarger,
                             Optional gridStroke$ = Stroke.AxisGridStroke)
            With region
                Dim rect As Rectangle = .Padding.GetCanvasRegion(.Size)
                Dim gridPen As Pen = Stroke.TryParse(css:=gridStroke)

                For Each tick As Double In scaler.AxisTicks.Y
                    Dim y = scaler.TranslateY(tick) + offset.Y
                    Dim left As New Point(rect.Left, y)
                    Dim right As New Point(rect.Right, y)

                    ' 绘制y网格线
                    Call g.DrawLine(gridPen, left, right)
                Next

                Call g.DrawY(pen, label,
                             scaler,
                             YAxisLayoutStyles.Left,
                             offset,
                             labelFont, CSSFont.TryParse(tickFont),
                             False)
            End With
        End Sub

        Public Property delta As Integer = 10

        <Extension> Public Sub DrawY(ByRef g As IGraphics,
                                     pen As Pen, label$,
                                     scaler As DataScaler,
                                     layout As YAxisLayoutStyles, offset As Point,
                                     labelFont$,
                                     tickFont As Font,
                                     Optional showAxisLine As Boolean = True)

            Dim X%  ' y轴的layout的变化只需要变换x的值即可
            Dim size = scaler.ChartRegion.Size

            Select Case layout
                Case YAxisLayoutStyles.Centra
                    X = scaler.ChartRegion.Left + (size.Width) / 2 + offset.X
                Case YAxisLayoutStyles.Right
                    X = scaler.ChartRegion.Left + size.Width + offset.X
                Case YAxisLayoutStyles.ZERO
                    X = scaler.X(0) + offset.X
                Case Else
                    X = scaler.ChartRegion.Left + offset.X
            End Select

            Dim top As New Point(X, scaler.ChartRegion.Y + offset.Y)                ' Y轴
            Dim ZERO As New Point(X, size.Height + top.Y) ' 坐标轴原点，需要在这里修改layout

            If showAxisLine Then
                Call g.DrawLine(pen, ZERO, top)     ' y轴
            End If

            If Not scaler.AxisTicks.Y.IsNullOrEmpty Then
                For Each tick# In scaler.AxisTicks.Y
                    Dim y! = scaler.TranslateY(tick) + offset.Y
                    Dim axisY As New PointF(ZERO.X, y)

                    If showAxisLine Then
                        Call g.DrawLine(pen, axisY, New PointF(ZERO.X - delta, y))
                    End If

                    Dim labelText = (tick).ToString("F" & 2)
                    Dim sz As SizeF = g.MeasureString(labelText, tickFont)
                    Dim p As New Point(ZERO.X - delta - sz.Width, y - sz.Height / 2)

                    g.DrawString(labelText, tickFont, Brushes.Black, p)
                Next
            End If

            If Not label.StripHTMLTags(stripBlank:=True).StringEmpty Then
                Dim labelImage As Image = label.__plotLabel(labelFont)

                ' y轴标签文本是旋转90度绘制于左边
                labelImage = labelImage.RotateImage(-90)

                Dim location As New Point With {
                    .X = scaler.ChartRegion.Left - labelImage.Width * 1.5,
                    .Y = (size.Height - labelImage.Height) / 2
                }

                Call g.DrawImageUnscaled(labelImage, location)
            End If
        End Sub

        ''' <summary>
        ''' 绘制坐标轴标签html文本
        ''' </summary>
        ''' <param name="label$"></param>
        ''' <param name="css$"></param>
        ''' <returns></returns>
        <Extension> Private Function __plotLabel(label$, css$) As Image
            Return TextRender.DrawHtmlText(label, css)
        End Function

        ''' <summary>
        ''' 这个函数不是将文本作为html来进行渲染，而是直接使用gdi进行绘图，如果需要将文本
        ''' 作为html渲染出来，则需要使用<see cref="TextRender.DrawHtmlText"/>方法
        ''' </summary>
        ''' <param name="label$"></param>
        ''' <param name="css$"><see cref="CssFont"/></param>
        ''' <param name="fcolor">Brush color or texture.</param>
        ''' <returns></returns>
        <Extension>
        Public Function DrawLabel(label$, css$, Optional fcolor$ = "black", Optional size$ = "1440,900") As Image
            Dim font As Font = CSSFont.TryParse(css, [default]:=New Font(FontFace.MicrosoftYaHei, 12)).GDIObject
            Return label.DrawLabel(font, fcolor, size)
        End Function

        ''' <summary>
        ''' 这个函数不是将文本作为html来进行渲染，而是直接使用gdi进行绘图，如果需要将文本
        ''' 作为html渲染出来，则需要使用<see cref="TextRender.DrawHtmlText"/>方法
        ''' </summary>
        ''' <param name="label$"></param>
        ''' <param name="font"></param>
        ''' <param name="fcolor$"></param>
        ''' <param name="size$">
        ''' 假若程序是运行在低内存的机器之上，则大小值应该尽量设置小些，避免内存被浪费，
        ''' 测试发现在32bit系统上经常会出现OutOfmemory的错误，将这个大小值改小之后
        ''' 一切恢复正常
        ''' </param>
        ''' <returns></returns>
        <Extension>
        Public Function DrawLabel(label$, font As Font, Optional fcolor$ = "black", Optional size$ = "1440,900") As Image
            Using g As Graphics2D = size.SizeParser.CreateGDIDevice(Color.Transparent)
                With g
                    Dim b As Brush = fcolor.GetBrush

                    Call .DrawString(label, font, b, New Point)

                    Dim img As Image =
                        .ImageResource _
                        .CorpBlank(blankColor:=Color.Transparent) _
                        .RotateImage(-90)
                    Return img
                End With
            End Using
        End Function

        <Extension> Public Sub DrawX(ByRef g As IGraphics,
                                     pen As Pen, label$,
                                     scaler As DataScaler,
                                     layout As XAxisLayoutStyles, offset As Point,
                                     labelFont$,
                                     tickFont As Font,
                                     Optional overridesTickLine% = -1,
                                     Optional noTicks As Boolean = False)

            Dim Y% = scaler.ChartRegion.Top + offset.Y
            Dim size = scaler.ChartRegion.Size

            Select Case layout
                Case XAxisLayoutStyles.Centra
                    Y += size.Height / 2 + offset.Y
                Case XAxisLayoutStyles.Top
                    Y += 0
                Case Else
                    Y += size.Height
            End Select

            Dim ZERO As New Point(scaler.ChartRegion.Left + offset.X, Y)                 ' 坐标轴原点
            Dim right As New Point(ZERO.X + size.Width, Y)   ' X轴
            Dim d! = If(overridesTickLine <= 0, 10, overridesTickLine)

            Call g.DrawLine(pen, ZERO, right)   ' X轴

            If Not noTicks AndAlso Not scaler.AxisTicks.X.IsNullOrEmpty Then
                For Each tick# In scaler.AxisTicks.X
                    Dim x As Single = scaler.X(tick) + offset.X
                    Dim axisX As New PointF(x, ZERO.Y)

                    Dim labelText = (tick).ToString("F" & 2)
                    Dim sz As SizeF = g.MeasureString(labelText, tickFont)

                    Call g.DrawLine(pen, axisX, New PointF(x, ZERO.Y + d!))
                    Call g.DrawString(labelText, tickFont, Brushes.Black, New Point(x - sz.Width / 2, ZERO.Y + d * 1.2))
                Next
            End If

            If Not label.StripHTMLTags(stripBlank:=True).StringEmpty Then
                Dim labelImage As Image = label.__plotLabel(labelFont)
                Dim point As New Point With {
                    .X = (size.Width - labelImage.Width) / 2 + scaler.ChartRegion.Left,
                    .Y = scaler.ChartRegion.Top + size.Height + tickFont.Height + d * 3
                }

                Call g.DrawImageUnscaled(labelImage, point)
            End If
        End Sub
    End Module
End Namespace
