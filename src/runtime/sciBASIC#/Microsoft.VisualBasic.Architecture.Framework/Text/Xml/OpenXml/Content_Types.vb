﻿#Region "Microsoft.VisualBasic::cc2ee0cdb81b98f44c5041ab17cf6534, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Text\Xml\OpenXml\Content_Types.vb"

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

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Text.Xml.OpenXml

    ''' <summary>
    ''' ``[Content_Types].xml``
    ''' </summary>
    ''' 
    <XmlRoot("Types", Namespace:="http://schemas.openxmlformats.org/package/2006/content-types")>
    Public Class Content_Types
        <XmlElement> Public Property [Default] As Type()
        <XmlElement("Override")>
        Public Property [Overrides] As Type()
    End Class

    Public Structure Type

        <XmlAttribute> Public Property Extension As String
        <XmlAttribute> Public Property ContentType As String
        <XmlAttribute> Public Property PartName As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Structure
End Namespace
