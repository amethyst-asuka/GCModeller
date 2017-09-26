﻿#Region "Microsoft.VisualBasic::1d1950167114048f1f6dff519acbd2cd, ..\sciBASIC#\gr\Microsoft.VisualBasic.Imaging\Test.Project\Program.vb"

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
Imports Microsoft.VisualBasic.Imaging.BitmapImage
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Text.ASCIIArt
Imports Microsoft.VisualBasic.Imaging.Drawing3D
Imports Microsoft.VisualBasic.Imaging.Drawing3D.Models.Isometric.Shapes
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports Microsoft.VisualBasic.MIME.Markup.HTML.Render

Module Program

    Sub test3Dmodels()

        Dim isometricView As New IsometricEngine
        isometricView.Add(
    New Prism(
        New Point3D(0, 0, 0),
         1, 1, 1
    ),
     Color.FromArgb(33, 150, 243)
)
        Using g As Graphics2D = New Size(1000, 1000).CreateGDIDevice

            Call isometricView.Draw(g)
            Call g.ImageResource.SaveAs("x:\out.png")
        End Using

        Pause()
    End Sub


    Sub ASCIIArt_test()

        Dim logo = "sciBASIC#".ASCIIImage

        Call Console.WriteLine(logo)

        Call logo.SaveTo("x:\sciBASIC.txt")

        Pause()

        Dim image = "H:\GCModeller\src\runtime\sciBASIC#\etc\lena\f13e6388b975d9434ad9e1a41272d242_1_orig.jpg".LoadImage.Grayscale
        Dim ascii = image.Convert2ASCII

        Call ascii.SaveTo("H:\GCModeller\src\runtime\sciBASIC#\etc\lena\ASCII.txt")



        '     image = "H:\GCModeller\src\runtime\sciBASIC#\etc\lena\f13e6388b975d9434ad9e1a41272d242_1_orig.jpg".LoadImage
        '   image.AdjustContrast(10)

        '    Call image.SaveAs("x:\ggggg.png")

        Pause()
    End Sub

    Sub Main()


        Call ASCIIArt_test()

        Call test3Dmodels()
        Call SVGTest.Test()

        Dim html As String = "
<html>
<head>
<style type=""text/css"">
body {" & CSSFont.UbuntuLarge & "}
</style>
</head>
<body>

<strong><span style=""color:red"">text</span></strong><b> &lt;&lt;&lt; <i>value</i></b> 
<br />
log<sub>2</sub> ratio

<br />
-log<sub>10</sub>(P-value)
</body>
</html>
"

        Dim bitmap As New Bitmap(500, 300)

        Using g As Graphics = Graphics.FromImage(bitmap)

            g.Clear(Color.White)
            g.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            Call g.Render(html, New PointF(10, 10), 500)


            Call Microsoft.VisualBasic.Imaging.Drawing2D.Text.TextRender.RenderHTML(g, "<span style=""color:lime"">Green Color Text</span>", CSSFont.PlotTitle, New PointF(0, 200))


        End Using


        Call bitmap.SaveAs("x:/afsdfsdf.png")

        Pause()

        'Dim strings = TextAPI.GetStrings(html)

        'Using gdi As GDIPlusDeviceHandle = New Size(500, 200).CreateGDIDevice
        '    Call strings.DrawStrng(New Point(100, 100), gdi)
        '    Call gdi.Save("./test_text.png", ImageFormats.Png)
        'End Using

        '   Call New Form1().ShowDialog()

        Dim i As Integer = 1

        'For Each t In TextureResourceLoader.LoadInternalDefaultResource
        '    Call t.Save("x:\" & i & ".png")
        '    i += 1
        'Next


        ''    Call TextureResourceLoader.AdjustColor(Microsoft.VisualBasic.Drawing.TextureResourceLoader.LoadInternalDefaultResource.First, Color.SeaGreen).Save("x:\reddddd.bmp")

        'Dim vec = New Vectogram(1000, 1000)

        'Call vec.AddTextElement("1234", New Font(FontFace.MicrosoftYaHei, 20), System.Drawing.Color.DarkCyan, vec.GDIDevice.Center)

        'Call vec.AddCircle(Color.Red, New Point(100, 20), 100)

        'Dim res = vec.ToImage

        'Call res.Save("x:\ffff.png")

        'Call New DrawingScript(vec).ToScript.SaveTo("script.txt")

    End Sub

End Module
