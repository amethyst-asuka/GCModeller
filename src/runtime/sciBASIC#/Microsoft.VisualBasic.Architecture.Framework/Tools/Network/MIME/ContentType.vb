﻿#Region "Microsoft.VisualBasic::db866b45b35db2358acd6432fad8fd2e, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Tools\Network\MIME\ContentType.vb"

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

Imports System.Data.Linq.Mapping
Imports Microsoft.VisualBasic.Text

Namespace Net.Protocols.ContentTypes

    ''' <summary>
    ''' MIME types / Internet Media Types
    ''' </summary>
    Public Structure ContentType

        ''' <summary>
        ''' Type name or brief info
        ''' </summary>
        ''' <returns></returns>
        Public Property Name As String
        ''' <summary>
        ''' MIME Type / Internet Media Type
        ''' </summary>
        ''' <returns></returns>
        <Column(Name:="MIME Type / Internet Media Type")> Public Property MIMEType As String

        ''' <summary>
        ''' File Extension
        ''' </summary>
        ''' <returns></returns>
        <Column(Name:="File Extension")>
        Public Property FileExt As String

        ''' <summary>
        ''' More Details
        ''' </summary>
        ''' <returns></returns>
        <Column(Name:="More Details")> Public Property Details As String

        Public Function IsEmpty() As Boolean
            Return Name Is Nothing AndAlso MIMEType Is Nothing AndAlso FileExt Is Nothing AndAlso Details Is Nothing
        End Function

        Public Overrides Function ToString() As String
            Return $"{MIMEType} (*{FileExt})"
        End Function

        Friend Shared Function __createObject(line As String) As ContentType
            Dim tokens As String() = line.Split(ASCII.TAB)

            If tokens.IsNullOrEmpty OrElse tokens.Length < 3 Then
                Call line.Warning
                Return Nothing
            Else
                Dim mime As New ContentType With {
                    .Name = tokens(Scan0),
                    .MIMEType = tokens(1),
                    .FileExt = tokens(2),
                    .Details = tokens(3)
                }
                Return mime
            End If
        End Function
    End Structure
End Namespace
