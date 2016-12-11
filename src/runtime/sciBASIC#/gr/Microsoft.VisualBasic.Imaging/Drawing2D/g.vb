﻿#Region "Microsoft.VisualBasic::8ebb50a0b54327432b417e6f7b3db02b, ..\sciBASIC#\gr\Microsoft.VisualBasic.Imaging\Drawing2D\g.vb"

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
Imports System.Drawing.Text
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Net.Http

Namespace Drawing2D

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="g">GDI+设备</param>
    ''' <param name="grct">绘图区域的大小</param>
    Public Delegate Sub IPlot(ByRef g As Graphics, grct As GraphicsRegion)

    ''' <summary>
    ''' Data plots graphics engine common abstract.
    ''' </summary>
    Public Module g

        ''' <summary>
        ''' Data plots graphics engine. Default: <paramref name="size"/>:=(4300, 2000), <paramref name="margin"/>:=(100,100)
        ''' </summary>
        ''' <param name="size"></param>
        ''' <param name="margin"></param>
        ''' <param name="bg"></param>
        ''' <param name="plotAPI"></param>
        ''' <returns></returns>
        Public Function GraphicsPlots(ByRef size As Size, ByRef margin As Size, bg$, plotAPI As IPlot) As Bitmap
            If size.IsEmpty Then
                size = New Size(4300, 2000)
            End If
            If margin.IsEmpty Then
                margin = New Size(100, 100)
            End If

            Dim bmp As New Bitmap(size.Width, size.Height)

            Using g As Graphics = Graphics.FromImage(bmp)
                Dim rect As New Rectangle(New Point, size)

                g.FillBg(bg$, rect)
                g.CompositingQuality = CompositingQuality.HighQuality
                g.CompositingMode = CompositingMode.SourceOver
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                g.PixelOffsetMode = PixelOffsetMode.HighQuality
                g.SmoothingMode = SmoothingMode.HighQuality
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

                Call plotAPI(g, New GraphicsRegion With {
                     .Size = size,
                     .Margin = margin
                })
            End Using

            Return bmp
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="g"></param>
        ''' <param name="bg$">
        ''' 1. 可能为颜色表达式
        ''' 2. 可能为图片的路径
        ''' 3. 可能为base64图片字符串
        ''' </param>
        <Extension>
        Public Sub FillBg(ByRef g As Graphics, bg$, rect As Rectangle)
            Dim bgColor As Color = bg.ToColor(onFailure:=Nothing)

            If Not bgColor.IsEmpty Then
                Call g.FillRectangle(New SolidBrush(bgColor), rect)
            Else
                Dim res As Image

                If Not bg.FileExists Then
                    res = Base64Codec.GetImage(bg$)
                Else
                    res = LoadImage(path:=bg$)
                End If

                Call g.DrawImage(res, rect)
            End If
        End Sub

        ''' <summary>
        ''' Data plots graphics engine.
        ''' </summary>
        ''' <param name="size"></param>
        ''' <param name="margin"></param>
        ''' <param name="bg"></param>
        ''' <param name="plot"></param>
        ''' <returns></returns>
        Public Function GraphicsPlots(ByRef size As Size, ByRef margin As Size, bg$, plot As Action(Of Graphics)) As Bitmap
            Return GraphicsPlots(size, margin, bg, Sub(ByRef g, rect) Call plot(g))
        End Function
    End Module
End Namespace
