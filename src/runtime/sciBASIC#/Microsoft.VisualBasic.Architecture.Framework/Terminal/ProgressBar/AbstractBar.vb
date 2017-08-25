﻿#Region "Microsoft.VisualBasic::0b7944b7499a6150710f41ccec1cf578, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Terminal\ProgressBar\AbstractBar.vb"

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

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Terminal

    Public MustInherit Class AbstractBar

        Public Sub New()
        End Sub

        ''' <summary>
        ''' Prints a simple message 
        ''' </summary>
        ''' <param name="msg">Message to print</param>
        Public Sub PrintMessage(msg As String)
            Call Console.WriteLine(msg)
        End Sub

        Public MustOverride Sub [Step]()
    End Class
End Namespace
