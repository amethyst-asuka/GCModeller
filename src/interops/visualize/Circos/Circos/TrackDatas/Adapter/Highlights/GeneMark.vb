﻿#Region "Microsoft.VisualBasic::7bc26d5c0089f51276e92d43c71c2661, ..\interops\visualize\Circos\Circos\TrackDatas\Adapter\Highlights\Gene.vb"

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
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.ComponentModel
Imports SMRUCC.genomics.ComponentModel.Loci
Imports SMRUCC.genomics.Visualize.Circos.Colors
Imports SMRUCC.genomics.Visualize.Circos.Configurations.Nodes.Plots

Namespace TrackDatas.Highlights

    ''' <summary>
    ''' 使用highlights来标记基因组之中的基因
    ''' </summary>
    Public Class GeneMark : Inherits Highlights

        Public Property COGColors As Dictionary(Of String, String)

        ''' <summary>
        ''' 在这里是使用直方图来显示基因的位置的
        ''' </summary>
        ''' <param name="annos"></param>
        ''' <param name="Color"></param>
        Sub New(annos As IEnumerable(Of IGeneBrief), Color As Dictionary(Of String, String))
            __source = LinqAPI.MakeList(Of ValueTrackData) <=
 _
                From gene As IGeneBrief
                In annos
                Let COG As String = If(String.IsNullOrEmpty(gene.COG), "-", gene.COG)
                Let fill As String = If(
                    Color.ContainsKey(COG),
                    Color(COG),
                    CircosColor.DefaultCOGColor)
                Select New ValueTrackData With {
                    .start = CInt(gene.Location.Left),
                    .end = CInt(gene.Location.Right),
                    .value = 1,
                    .chr = "chr1",
                    .formatting = New Formatting With {
                        .fill_color = fill
                    }
                }

            COGColors = Color
        End Sub

        ''' <summary>
        ''' 直接从motif位点构建，这个模型并不显示标签信息
        ''' 使用<see cref="HighLight"/>生成track数据
        ''' 
        ''' ```vbnet
        ''' Dim track As New HighLight(New GeneMark(genes, colors))
        ''' ```
        ''' </summary>
        ''' <param name="sites"></param>
        ''' <param name="color"></param>
        Sub New(sites As IEnumerable(Of IMotifSite), color As Dictionary(Of String, String), Optional chr$ = "chr1")
            Dim locis As IMotifSite() = sites.ToArray
            Dim types$() = locis _
                .Select(Function(x) x.Type) _
                .Distinct _
                .ToArray

            Call __motifSitesCommon(locis, color, chr)
        End Sub

        Private Sub __motifSitesCommon(locis As IMotifSite(), color As Dictionary(Of String, String), chr$)
            COGColors = color
            __source = LinqAPI.MakeList(Of ValueTrackData) <=
                From site As IMotifSite
                In locis
                Let COG = If(String.IsNullOrEmpty(site.Type), "-", site.Type)
                Let fill = If(
                    color.ContainsKey(COG),
                    color(COG),
                    CircosColor.DefaultCOGColor)
                Select New ValueTrackData With {
                    .start = site.Site.Left,
                    .end = site.Site.Right,
                    .value = 1,
                    .chr = chr,
                    .formatting = New Formatting With {
                        .fill_color = fill
                    }
                }
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sites"></param>
        ''' <param name="colors$">The color theme name</param>
        ''' <param name="chr$"></param>
        Sub New(sites As IEnumerable(Of IMotifSite), Optional colors$ = "Paired:c10", Optional chr$ = "chr1")
            Dim locis As IMotifSite() = sites.ToArray
            Dim types$() = locis _
                .Select(Function(x) x.Type.Split("+"c).Distinct.JoinBy("_")) _
                .Distinct _
                .ToArray
            Dim colorlist As Color() = Designer.FromSchema(colors, types.Length)
            Dim colorData As Dictionary(Of String, String) =
                types _
                .SeqIterator _
                .ToDictionary(Function(name) name.value,
                              Function(color) colorlist(color.i).RGBExpression)

            Call __motifSitesCommon(locis, colorData, chr)
        End Sub

        ''' <summary>
        ''' 假若使用这个构造函数的话，这个需要手工初始化<see cref="__source"/>和<see cref="COGColors"/>
        ''' </summary>
        Protected Sub New()
        End Sub

        Public Function LegendsDrawing(ref As Point, ByRef gdi As IGraphics) As Point
            Dim COGColors = (From clProfile
                             In Me.COGColors
                             Select clProfile.Key,
                                 Cl = CircosColor.FromKnownColorName(clProfile.Value)) _
                                    .ToDictionary(Function(cl) cl.Key,
                                                  Function(x) DirectCast(New SolidBrush(x.Cl), Brush))
            Dim Margin As Integer = 50
            Dim font As New Font(FontFace.MicrosoftYaHei, 20)
            Dim size As Size = gdi.Size
            Dim w As Integer = CInt(size.Width * 0.3)

            ref = New Point(Margin, size.Height - 7 * Margin)

            Call gdi.DrawingCOGColors(COGColors, ref, font, w, Margin)

            Return ref
        End Function
    End Class
End Namespace
