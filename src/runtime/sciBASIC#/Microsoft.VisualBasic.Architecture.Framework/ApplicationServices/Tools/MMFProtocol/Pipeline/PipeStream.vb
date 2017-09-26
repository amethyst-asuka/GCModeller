﻿#Region "Microsoft.VisualBasic::a8bf054dd382f954882972dd83a9e63a, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Tools\MMFProtocol\Pipeline\PipeStream.vb"

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

Imports Microsoft.VisualBasic.Net.Protocols

Namespace MMFProtocol.Pipeline

    ''' <summary>
    ''' 
    ''' </summary>
    Public Class PipeStream : Inherits RawStream

        Public Property hashTable As Dictionary(Of String, PipeBuffer)

        Sub New(raw As Byte())

        End Sub

        Public Overrides Function Serialize() As Byte()
            Throw New NotImplementedException
        End Function

        Public Shared Function GetValue(raw As Byte(), name As String) As PipeBuffer
            Dim i As Long = Scan0

            Do While True
                Dim buffer As Byte() = raw
            Loop

            Return Nothing
        End Function
    End Class
End Namespace
