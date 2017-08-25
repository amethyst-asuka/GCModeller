﻿#Region "Microsoft.VisualBasic::ac1d4f453fe24c574eca92d7e584624f, ..\sciBASIC#\gr\Microsoft.VisualBasic.Imaging\Drawing3D\Device\IDevice.vb"

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

Namespace Drawing3D.Device

    Public MustInherit Class IDevice

        Protected WithEvents device As GDIDevice

        Sub New(dev As GDIDevice)
            device = dev
        End Sub
    End Class

    ''' <summary>
    ''' 3D plot for <see cref="Gdidevice"/>，由于是需要将图像显示到WinFom控件上面，所以在这里要求的是gdi+的图形驱动程序
    ''' </summary>
    ''' <param name="canvas">gdi+ handle</param>
    ''' <param name="camera">3d camera</param>
    Public Delegate Sub DrawGraphics(ByRef canvas As Graphics, camera As Camera)

End Namespace
