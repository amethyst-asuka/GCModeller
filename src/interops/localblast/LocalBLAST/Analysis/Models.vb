﻿#Region "Microsoft.VisualBasic::672537f735d4485e5275c4011c96368e, ..\localblast\LocalBLAST\Analysis\Models.vb"

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

Namespace Analysis

    Public Class LogsPair

        <XmlAttribute> Public LogsDir As String
        <XmlArray> Public Logs As QueryPair()()

        Public Shared Function GetFileName(LogsDir As String) As String
            Return String.Format("{0}/blast_venn.xml", LogsDir)
        End Function

        Public Shared Function GetXmlFileName(XmlLogsDir As String) As String
            Return String.Format("{0}/blast________xml_logs.xml", XmlLogsDir)
        End Function

        Public Overrides Function ToString() As String
            Return Logs.ToString
        End Function
    End Class

    Public Class QueryPair

        <XmlAttribute> Public Property Query As String
        <XmlAttribute> Public Property Target As String

        Public Overrides Function ToString() As String
            Return String.Format("[{0}]  &&  [{1}]", Query, Target)
        End Function
    End Class
End Namespace
