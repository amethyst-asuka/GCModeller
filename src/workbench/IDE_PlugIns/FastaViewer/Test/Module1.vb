﻿#Region "Microsoft.VisualBasic::679b8dd52ec01d5649e4f1701b0a3895, ..\workbench\IDE_PlugIns\FastaViewer\Test\Module1.vb"

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

Imports FastaViewer
Imports LANS.SystemsBiology.SequenceModel.FASTA

Module Module1

    Sub Main()

        '    Dim html As String = HTMLRenderer.VisualNts(New FastaFile("D:\Xanthomonas_oryzae_oryzicola_BLS256_uid16740\CP003057.ffn"))
        ' Call html.SaveTo("./test.html")
        Call New FastaViewer.FormViwer().ShowDialog()
    End Sub
End Module

