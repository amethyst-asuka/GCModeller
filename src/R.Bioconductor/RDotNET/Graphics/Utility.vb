﻿#Region "Microsoft.VisualBasic::f8f3cc4d32015735200616e3600d81fb, ..\R.Bioconductor\RDotNET\Graphics\Utility.vb"

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

Imports System.Runtime.InteropServices

Namespace Graphics

    Module Utility

        Public Function ReadDouble(pointer As IntPtr, offset As Integer) As Double
            Dim value = New Double(0) {}
            Marshal.Copy(IntPtr.Add(pointer, offset), value, 0, value.Length)
            Return value(0)
        End Function
    End Module
End Namespace
