﻿#Region "Microsoft.VisualBasic::31d6a32a4191fa8a41e297130fcc1a55, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Tools\Network\MIME\Type.vb"

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

'#Region "Microsoft.VisualBasic::a4445348bb9f829f9c7046c1d266b9a6, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Tools\Network\MIME\Type.vb"

'    ' Author:
'    ' 
'    '       asuka (amethyst.asuka@gcmodeller.org)
'    '       xieguigang (xie.guigang@live.com)
'    '       xie (genetics@smrucc.org)
'    ' 
'    ' Copyright (c) 2016 GPL3 Licensed
'    ' 
'    ' 
'    ' GNU GENERAL PUBLIC LICENSE (GPL3)
'    ' 
'    ' This program is free software: you can redistribute it and/or modify
'    ' it under the terms of the GNU General Public License as published by
'    ' the Free Software Foundation, either version 3 of the License, or
'    ' (at your option) any later version.
'    ' 
'    ' This program is distributed in the hope that it will be useful,
'    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
'    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    ' GNU General Public License for more details.
'    ' 
'    ' You should have received a copy of the GNU General Public License
'    ' along with this program. If not, see <http://www.gnu.org/licenses/>.

'#End Region

'Imports System.Xml.Serialization
'Imports Microsoft.VisualBasic.Serialization.JSON
'Imports Microsoft.VisualBasic.Text
'Imports Microsoft.VisualBasic.Text.Xml

'Namespace Net.Protocols.ContentTypes

'    Public Class Type

'        <XmlAttribute> Public Property Extension As String
'        <XmlAttribute> Public Property ContentType As String

'        Public Overrides Function ToString() As String
'            Return $"<Default Extension=""{Extension}"" ContentType=""{ContentType}"" />"
'        End Function

'        Public Class Types

'            Const xmlns$ = "http://schemas.openxmlformats.org/package/2006/content-types"

'            <XmlElement("Default")> Public Property Defaults As Type()

'            Public Overrides Function ToString() As String
'                Return Me.GetJson
'            End Function

'            Public Function SaveAsXml(path$) As Boolean
'                Dim xml As New XmlDoc(Me.GetXml)
'                xml.xmlns.xsd = Nothing
'                xml.xmlns.xsi = Nothing
'                xml.xmlns.xmlns = xmlns
'                xml.encoding = XmlEncodings.UTF8

'                Return xml.ToString.SaveTo(path, Encodings.UTF8.CodePage)
'            End Function
'        End Class
'    End Class
'End Namespace

