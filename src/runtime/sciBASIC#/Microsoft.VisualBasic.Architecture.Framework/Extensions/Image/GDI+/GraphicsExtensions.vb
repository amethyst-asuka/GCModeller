﻿#Region "Microsoft.VisualBasic::9dfcdfdc234432a79bb84c33f4d863a0, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Extensions\Image\GDI+\GraphicsExtensions.vb"

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
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Algorithm.base
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Net.Http
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Serialization.JSON
Imports sys = System.Math

Namespace Imaging

    ''' <summary>
    ''' GDI+
    ''' </summary>
    '''
    <Package("GDI+", Description:="GDI+ GDIPlus Extensions Module to provide some useful interface.",
                  Publisher:="xie.guigang@gmail.com",
                  Revision:=58,
                  Url:="http://gcmodeller.org")>
    Public Module GraphicsExtensions

        <Extension> Public Function SaveIcon(ico As Icon, path$) As Boolean
            Call path.ParentPath.MkDIR

            Try
                Using file As New FileStream(path, FileMode.OpenOrCreate)
                    Call ico.Save(file)
                    Call file.Flush()
                End Using

                Return True
            Catch ex As Exception
                Call App.LogException(New Exception(path, ex))
            End Try

            Return False
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function ToFloat(rect As Rectangle) As RectangleF
            Return New RectangleF With {
                .Location = rect.Location.PointF,
                .Size = rect.Size.SizeF
            }
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function PointF(pf As Point) As PointF
            Return New PointF(pf.X, pf.Y)
        End Function

        <Extension>
        Public Function GraphicsPath(points As IEnumerable(Of Point)) As GraphicsPath
            Dim path As New GraphicsPath

            For Each pt In points.SlideWindows(2)
                Call path.AddLine(pt(0), pt(1))
            Next

            Return path
        End Function

        <Extension>
        Public Function GraphicsPath(points As IEnumerable(Of PointF)) As GraphicsPath
            Dim path As New GraphicsPath

            For Each pt In points.SlideWindows(2)
                Call path.AddLine(pt(0), pt(1))
            Next

            Return path
        End Function

        ''' <summary>
        ''' 同时兼容颜色以及图片纹理画刷的创建
        ''' </summary>
        ''' <param name="res$"></param>
        ''' <returns></returns>
        <Extension> Public Function GetBrush(res$) As Brush
            Dim bgColor As Color = res.TranslateColor

            If Not bgColor.IsEmpty Then
                Return New SolidBrush(bgColor)
            Else
                Dim img As Image

                If res.FileExists Then
                    img = LoadImage(path:=res$)
                Else
                    img = Base64Codec.GetImage(res$)
                End If

                Return New TextureBrush(img)
            End If
        End Function

        ''' <summary>
        ''' Converts the colors into solidbrushes in batch.
        ''' </summary>
        ''' <param name="colors"></param>
        ''' <returns></returns>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function GetBrushes(colors As IEnumerable(Of Color)) As SolidBrush()
            Return colors _
                .SafeQuery _
                .Select(Function(c) New SolidBrush(c)) _
                .ToArray
        End Function

        <Extension>
        Public Sub DrawCircle(ByRef g As Graphics, centra As PointF, r!, color As SolidBrush)
            Dim d = r * 2

            With centra
                Call g.FillPie(color, .X - r, .Y - r, d, d, 0, 360)
            End With
        End Sub

        <Extension>
        Public Sub DrawCircle(ByRef g As Graphics, centra As PointF, r!, color As Pen, Optional fill As Boolean = True)
            With centra
                Dim d! = r * 2
                Dim rect As New Rectangle(.X - r, .Y - r, d, d)

                If fill Then
                    Call g.FillPie(New SolidBrush(color.Color), rect, 0, 360)
                Else
                    Call g.DrawEllipse(color, rect)
                End If
            End With
        End Sub

        ''' <summary>
        ''' 模仿Java之中的``DrawCircle``方法
        ''' </summary>
        ''' <param name="g"></param>
        ''' <param name="color"></param>
        ''' <param name="x!"></param>
        ''' <param name="y!"></param>
        ''' <param name="r!"></param>
        ''' <param name="fill"></param>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Sub DrawCircle(ByRef g As Graphics, color As Pen, x!, y!, r!, Optional fill As Boolean = True)
            Call g.DrawCircle(New PointF(x, y), r, color, fill)
        End Sub

        <Extension>
        Public Sub DrawCircle(ByRef g As IGraphics, centra As PointF, r!, color As SolidBrush)
            Dim d = r * 2

            With centra
                Call g.FillPie(color, .X - r, .Y - r, d, d, 0, 360)
            End With
        End Sub

        ''' <summary>
        ''' 进行圆的绘制
        ''' </summary>
        ''' <param name="g"></param>
        ''' <param name="centra">圆心的坐标，这个函数之中会自动转换为<see cref="Rectangle"/>的左上角位置坐标</param>
        ''' <param name="r!">圆的半径</param>
        ''' <param name="color">线条的颜色</param>
        ''' <param name="fill">是否进行填充？</param>
        <Extension>
        Public Sub DrawCircle(ByRef g As IGraphics, centra As PointF, r!, color As Pen, Optional fill As Boolean = True)
            Dim d = r * 2

            With centra
                If fill Then
                    Call g.FillPie(New SolidBrush(color.Color), .X - r, .Y - r, d, d, 0, 360)
                Else
                    Call g.DrawEllipse(color, .X - r, .Y - r, d, d)
                End If
            End With
        End Sub

        ''' <summary>
        ''' 这个方形区域的面积
        ''' </summary>
        ''' <param name="rect"></param>
        ''' <returns></returns>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function Area(rect As Rectangle) As Double
            Return rect.Width * rect.Height
        End Function

        ''' <summary>
        ''' 返回整个图像的区域
        ''' </summary>
        ''' <param name="img"></param>
        ''' <returns></returns>
        <Extension>
        Public Function EntireImage(img As Image) As Rectangle
            Dim size As Size = img.Size
            Return New Rectangle(New Point, size)
        End Function

        ''' <summary>
        ''' Is target point in the target region?
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="rect"></param>
        ''' <returns></returns>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function InRegion(x As Point, rect As Rectangle) As Boolean
            Return New PointF(x.X, x.Y).InRegion(rect)
        End Function

        ''' <summary>
        ''' Is target point in the target region?
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="rect"></param>
        ''' <returns></returns>
        <Extension>
        Public Function InRegion(x As PointF, rect As Rectangle) As Boolean
            If x.X < rect.Left OrElse x.X > rect.Right Then
                Return False
            End If
            If x.Y < rect.Top OrElse x.Y > rect.Bottom Then
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Calculate the center location of the target sized region
        ''' </summary>
        ''' <param name="size"></param>
        ''' <returns></returns>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension> Public Function GetCenter(size As Size) As Point
            Return New Point(size.Width / 2, size.Height / 2)
        End Function

        ''' <summary>
        ''' Convert image to icon
        ''' </summary>
        ''' <param name="res"></param>
        ''' <returns></returns>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("To.Icon")>
        <Extension> Public Function GetIcon(res As Image) As Icon
            Return Drawing.Icon.FromHandle(New Bitmap(res).GetHicon)
        End Function

        ''' <summary>
        ''' Convert image to icon
        ''' </summary>
        ''' <param name="res"></param>
        ''' <returns></returns>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("To.Icon")>
        <Extension> Public Function GetIcon(res As Bitmap) As Icon
            Return Drawing.Icon.FromHandle(res.GetHicon)
        End Function

        ''' <summary>
        ''' Load image from a file and then close the file handle.
        ''' (使用<see cref="Image.FromFile(String)"/>函数在加载完成图像到Dispose这段之间内都不会释放文件句柄，
        ''' 则使用这个函数则没有这个问题，在图片加载之后会立即释放掉文件句柄)
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        <ExportAPI("LoadImage"), Extension>
        Public Function LoadImage(path As String, Optional base64 As Boolean = False) As Image
            If base64 Then
                Dim base64String = path.ReadAllText
                Dim img As Image = base64String.GetImage
                Return img
            Else
                Dim stream As Byte() = FileIO.FileSystem.ReadAllBytes(path)
                Dim res = Image.FromStream(stream:=New IO.MemoryStream(stream))
                Return res
            End If
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("LoadImage")>
        <Extension> Public Function LoadImage(rawStream As Byte()) As Image
            Dim res = Image.FromStream(stream:=New IO.MemoryStream(rawStream))
            Return res
        End Function

        ''' <summary>
        ''' 将图片对象转换为原始的字节流
        ''' </summary>
        ''' <param name="image"></param>
        ''' <returns></returns>
        '''
        <ExportAPI("Get.RawStream")>
        <Extension> Public Function GetRawStream(image As Image) As Byte()
            Dim stream As New IO.MemoryStream
            Call image.Save(stream, ImageFormat.Png)
            Return stream.ToArray
        End Function

        Private ReadOnly gdiShared As Graphics = Graphics.FromImage(New Bitmap(64, 64))

        ''' <summary>
        ''' Measures the specified string when drawn with the specified System.Drawing.Font.
        ''' </summary>
        ''' <param name="s">String to measure.</param>
        ''' <param name="Font">System.Drawing.Font that defines the text format of the string.</param>
        ''' <param name="XScaleSize"></param>
        ''' <param name="YScaleSize"></param>
        ''' <returns>This method returns a System.Drawing.SizeF structure that represents the size,
        ''' in the units specified by the System.Drawing.Graphics.PageUnit property, of the
        ''' string specified by the text parameter as drawn with the font parameter.
        ''' </returns>
        <Extension> Public Function MeasureString(s As String, Font As Font,
                                                  Optional XScaleSize As Single = 1,
                                                  Optional YScaleSize As Single = 1) As Size
            SyncLock gdiShared
                Call gdiShared.ScaleTransform(XScaleSize, YScaleSize)
                Dim sz As SizeF = gdiShared.MeasureString(s, Font)
                Return New Size(sz.Width, sz.Height)
            End SyncLock
        End Function

        <ExportAPI("GrayBitmap", Info:="Create the gray color of the target image.")>
        <Extension> Public Function CreateGrayBitmap(res As Image) As Image
            Using g = DirectCast(res.Clone, Image).CreateCanvas2D
                With g
                    Call ControlPaint.DrawImageDisabled(.Graphics, res, 0, 0, Color.FromArgb(0, 0, 0, 0))
                    Return .ImageResource
                End With
            End Using
        End Function

        ''' <summary>
        ''' Adding a frame box to the target image source.(为图像添加边框)
        ''' </summary>
        ''' <param name="Handle"></param>
        ''' <param name="pen">Default pen width is 1px and with color <see cref="Color.Black"/>.(默认的绘图笔为黑色的1个像素的边框)</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Extension> Public Function ImageAddFrame(handle As Graphics2D,
                                                  Optional pen As Pen = Nothing,
                                                  Optional offset As Integer = 0) As Graphics2D

            Dim TopLeft As New Point(offset, offset)
            Dim TopRight As New Point(handle.Width - offset, 1 + offset)
            Dim BottomLeft As New Point(offset + 1, handle.Height - offset)
            Dim BottomRight As New Point(handle.Width - offset, handle.Height - offset)

            If pen Is Nothing Then
                pen = Pens.Black
            End If

            Call handle.Graphics.DrawLine(pen, TopLeft, TopRight)
            Call handle.Graphics.DrawLine(pen, TopRight, BottomRight)
            Call handle.Graphics.DrawLine(pen, BottomRight, BottomLeft)
            Call handle.Graphics.DrawLine(pen, BottomLeft, TopLeft)

            Call handle.Graphics.FillRectangle(New SolidBrush(pen.Color), New Rectangle(New Point, New Size(1, 1)))

            Return handle
        End Function

        ''' <summary>
        ''' 创建一个GDI+的绘图设备
        ''' </summary>
        ''' <param name="r"></param>
        ''' <param name="filled">默认的背景填充颜色为白色</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("GDI+.Create")>
        <Extension> Public Function CreateGDIDevice(r As SizeF, Optional filled As Color = Nothing) As Graphics2D
            Return (New Size(CInt(r.Width), CInt(r.Height))).CreateGDIDevice(filled)
        End Function

        <Extension> Public Function OpenDevice(ctrl As Control) As Graphics2D
            Dim ImageRes As Image

            'If ctrl.BackgroundImage Is Nothing Then
            ImageRes = New Bitmap(ctrl.Width, ctrl.Height)
            'Else
            'ImageRes = ctrl.BackgroundImage
            'End If

            Dim Device = ImageRes.CreateCanvas2D

            If ctrl.BackgroundImage Is Nothing Then
                Call Device.Graphics.FillRectangle(Brushes.White, New Rectangle(New Point, ImageRes.Size))
            End If

            Return Device
        End Function

        ''' <summary>
        ''' 从指定的文件之中加载GDI+设备的句柄
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        '''
        <ExportAPI("GDI+.Create")>
        <Extension> Public Function GDIPlusDeviceHandleFromImageFile(path As String) As Graphics2D
            Dim image As Image = LoadImage(path)
            Dim g As Graphics = Graphics.FromImage(image)

            With g
                .CompositingQuality = CompositingQuality.HighQuality
                .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            End With

            Return Graphics2D.CreateObject(g, image)
        End Function

        ''' <summary>
        ''' 无需处理图像数据，这个函数默认已经自动克隆了该对象，不会影响到原来的对象，
        ''' 除非你将<paramref name="directAccess"/>参数设置为真，函数才不会自动克隆图像对象
        ''' </summary>
        ''' <param name="res"></param>
        ''' <returns></returns>
        <ExportAPI("GDI+.Create")>
        <Extension> Public Function CreateCanvas2D(res As Image,
                                                   Optional directAccess As Boolean = False,
                                                   <CallerMemberName>
                                                   Optional caller$ = "") As Graphics2D
            If directAccess Then
                Return Graphics2D.CreateObject(Graphics.FromImage(res), res)
            Else
                With res.Size.CreateGDIDevice
                    Call .DrawImage(res, 0, 0, .Width, .Height)
                    Return .ref
                End With
            End If
        End Function

        <Extension> Public Function BackgroundGraphics(ctrl As Control) As Graphics2D
            If Not ctrl.BackgroundImage Is Nothing Then
                Try
                    Return ctrl.BackgroundImage.CreateCanvas2D
                Catch ex As Exception
                    Call App.LogException(ex)
                    Return ctrl.Size.CreateGDIDevice(ctrl.BackColor)
                End Try
            Else
                Return ctrl.Size.CreateGDIDevice(ctrl.BackColor)
            End If
        End Function

        ''' <summary>
        ''' 返回位移的新的点位置值
        ''' </summary>
        ''' <param name="p"></param>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        <ExportAPI("Offset")>
        <Extension> Public Function OffSet2D(p As Point, x As Integer, y As Integer) As Point
            Return New Point(x + p.X, y + p.Y)
        End Function

        ''' <summary>
        ''' 返回位置的新的点位置值
        ''' </summary>
        ''' <param name="p"></param>
        ''' <param name="offset"></param>
        ''' <returns></returns>
        <ExportAPI("Offset")>
        <Extension> Public Function OffSet2D(p As Point, offset As Point) As Point
            Return New Point(offset.X + p.X, offset.Y + p.Y)
        End Function

        <Extension> Public Function OffSet2D(pt As PointF, offset As PointF) As PointF
            With pt
                Return New PointF(offset.X + .X, offset.Y + .Y)
            End With
        End Function

        <Extension> Public Function OffSet2D(pt As PointF, x!, y!) As PointF
            With pt
                Return New PointF(x + .X, y + .Y)
            End With
        End Function

        <Extension> Public Function IsValidGDIParameter(size As Size) As Boolean
            Return size.Width > 0 AndAlso size.Height > 0
        End Function

        Const InvalidSize As String = "One of the size parameter for the gdi+ device is not valid!"

        ''' <summary>
        ''' 创建一个GDI+的绘图设备，默认的背景填充色为白色
        ''' </summary>
        ''' <param name="r"></param>
        ''' <param name="filled">默认的背景填充颜色为白色</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        '''
        <ExportAPI("GDI+.Create")>
        <Extension> Public Function CreateGDIDevice(r As Size, Optional filled As Color = Nothing, <CallerMemberName> Optional trace$ = "") As Graphics2D
            Dim Bitmap As Bitmap

            If r.Width = 0 OrElse r.Height = 0 Then
                Throw New Exception(InvalidSize)
            End If

            Try
                Bitmap = New Bitmap(r.Width, r.Height)
            Catch ex As Exception
                ex = New Exception(r.ToString, ex)
                ex = New Exception(trace, ex)
                Call App.LogException(ex, MethodBase.GetCurrentMethod.GetFullName)
                Throw ex
            End Try

            Dim gdi As Graphics = Graphics.FromImage(Bitmap)
            Dim rect As New Rectangle(New Point, Bitmap.Size)

            If filled.IsNullOrEmpty Then
                filled = Color.White
            End If

            Call gdi.Clear(filled)

            gdi.InterpolationMode = InterpolationMode.HighQualityBicubic
            gdi.PixelOffsetMode = PixelOffsetMode.HighQuality
            gdi.CompositingQuality = CompositingQuality.HighQuality
            gdi.SmoothingMode = SmoothingMode.HighQuality

            Return Graphics2D.CreateObject(gdi, Bitmap)
        End Function

        <Extension> Public Function Clone(res As Bitmap) As Bitmap
            If res Is Nothing Then Return Nothing
            Return DirectCast(res.Clone, Bitmap)
        End Function

        <Extension> Public Function Clone(res As Image) As Image
            If res Is Nothing Then Return Nothing
            Return DirectCast(res.Clone, Image)
        End Function
    End Module
End Namespace
