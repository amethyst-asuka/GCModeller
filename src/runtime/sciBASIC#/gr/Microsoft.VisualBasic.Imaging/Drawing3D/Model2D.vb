﻿#Region "Microsoft.VisualBasic::cadce96635fd54cf8bdbec8860096224, ..\sciBASIC#\gr\Microsoft.VisualBasic.Imaging\Drawing3D\Model2D.vb"

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
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Drawing3D.Models.Isometric

Namespace Drawing3D

    Public Class Model2D

        ''' <summary>
        ''' 实际的模型数据
        ''' </summary>
        Friend path As Path3D
        Friend baseColor As Color
        Friend Paint As SolidBrush
        Friend drawn As Integer
        Friend TransformedPoints As Point3D()

        ''' <summary>
        ''' 经过模型数据<see cref="path"/>转换之后所得到的绘图所使用的对象模型
        ''' </summary>
        Friend DrawPath As Path2D

        Friend Sub New(item As Model2D)
            TransformedPoints = item.TransformedPoints
            DrawPath = item.DrawPath
            drawn = item.drawn
            Me.Paint = item.Paint
            Me.path = item.path
            Me.baseColor = item.baseColor
        End Sub

        Friend Sub New(path As Path3D, baseColor As Color)
            DrawPath = New Path2D
            drawn = 0
            Me.baseColor = baseColor
            Me.Paint = New SolidBrush(Color.FromArgb(CInt(Fix(baseColor.A)), CInt(Fix(baseColor.R)), CInt(Fix(baseColor.G)), CInt(Fix(baseColor.B))))
            Me.path = path
        End Sub
    End Class
End Namespace