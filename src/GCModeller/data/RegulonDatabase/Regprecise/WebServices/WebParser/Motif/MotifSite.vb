﻿#Region "Microsoft.VisualBasic::2e9143bbf8e87fdb078682cb36a89620, ..\GCModeller\data\RegulonDatabase\Regprecise\WebServices\WebParser\Motif\MotifSite.vb"

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
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.ComponentModel
Imports SMRUCC.genomics.Data.Regtransbase.WebServices
Imports SMRUCC.genomics.SequenceModel.FASTA

Namespace Regprecise

    ''' <summary>
    ''' regulogs.Xml RegPrecise数据库之中已经完成的Motif位点的数据
    ''' </summary>
    <XmlType("MotifSite")> Public Class MotifSitelog
        Implements INamedValue

        Public Property Family As String
        Public Property RegulationMode As String
        Public Property BiologicalProcess As String
        Public Property Effector As String
        Public Property Regulog As KeyValuePair
        Public Property Taxonomy As KeyValuePair
        Public Property Sites As FastaObject()
        <XmlAttribute> Public Property logo As String

        Private Property Identifier As String Implements INamedValue.Key
            Get
                Return Regulog.Key
            End Get
            Set(value As String)
                Regulog.Key = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function

        Public Function ExportMotifs() As FastaToken()
            Dim LQuery As FastaToken() =
                LinqAPI.Exec(Of FastaToken) <= From fa As FastaObject
                                               In Sites
                                               Let attrs As String() = {String.Format("[gene={0}] [family={1}] [regulog={2}]", fa.LocusTag, Family, Regulog.Key)}
                                               Select New FastaToken With {
                                                   .SequenceData = Regtransbase.WebServices.Regulator.SequenceTrimming(fa),
                                                   .Attributes = attrs
                                               }
            Return LQuery
        End Function

        Public Shared Function Name(log As MotifSitelog) As String
            Dim s As String = log.Taxonomy.Key.NormalizePathString & "_" & log.Regulog.Key.NormalizePathString
            s = s.Replace(" ", "_").Replace("-", "_")
            Return s
        End Function
    End Class
End Namespace
