﻿#Region "Microsoft.VisualBasic::468d3071ac102efca5ab01e713d873e7, ..\core\Bio.Assembly\Assembly\NCBI\Database\COG\COGs\COGTable.vb"

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
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Scripting.Runtime

Namespace Assembly.NCBI.COG.COGs

    ''' <summary>
    ''' cog2003-2014.csv
    ''' CSV table row for COG, Contains list of orthology domains. Comma-delimited,
    ''' </summary>
    ''' <remarks></remarks>
    Public Class COGTable

        ''' <summary>
        ''' &lt;domain-id>
        ''' 
        ''' In this version the fields &lt;domain-id> and &lt;protein-id> are identical
        ''' And both normally refer to GenBank GIs. Thus neither &lt;domain-id> nor
        ''' &lt;protein-id> are necessarily unique in this file (this happens when a
        ''' protein consists Of more than one orthology domains, e.g. 48478501).
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute("domain-id")> Public Property DomainID As String
        ''' <summary>
        ''' &lt;genome-name>
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute("genome-name")> Public Property GenomeName As String
        ''' <summary>
        ''' &lt;protein-id>: GI
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute("protein-id")> Public Property ProteinID As String
        ''' <summary>
        ''' &lt;protein-length>
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute("protein-length")> Public Property ProteinLength As Integer
        ''' <summary>
        ''' &lt;domain-start>
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute("domain-start")> Public Property Start As Integer
        ''' <summary>
        ''' &lt;domain-End>
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute("domain-End")> Public Property Ends As Integer
        ''' <summary>
        ''' &lt;COG-id>
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute("COG-id")> Public Property COGId As String
        ''' <summary>
        ''' &lt;membership-Class>
        ''' 
        ''' The &lt;membership-class> field indicates the nature of the match
        ''' between the sequence And the COG consensus
        ''' 
        ''' 0 - the domain matches the COG consensus;
        ''' 
        ''' 1 - the domain Is significantly longer than the COG consensus;
        ''' 
        ''' 2 - the domain Is significantly shorter than the COG consensus;
        ''' 
        ''' 3 - partial match between the domain And the COG consensus.
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute("membership-class")> Public Property Membership As Integer

        Sub New()
        End Sub

        Protected Sub New(tokens As String())
            Dim i As int = 0

            DomainID = tokens(++i)
            GenomeName = tokens(++i)
            ProteinID = tokens(++i)
            ProteinLength = CastInteger(tokens(++i))
            Start = CastInteger(tokens(++i))
            Ends = CastInteger(tokens(++i))
            COGId = tokens(++i)
            Membership = CastInteger(tokens(++i))
        End Sub

        Public Overrides Function ToString() As String
            Return String.Format("{0}:  {1}", ProteinID, COGId)
        End Function

        ''' <summary>
        ''' * Example:
        '''
        ''' 333894695,Alteromonas_SN2_uid67349,333894695,427,1,427,COG0001,0,
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Shared Function LoadCsv(path As String) As COGTable()
            Dim LQuery As COGTable() = LinqAPI.Exec(Of COGTable) <=
 _
                From line As String
                In path.ReadAllLines.AsParallel
                Let tokens As String() = line.Split(","c)
                Select New COGTable(tokens)

            Return LQuery
        End Function

        ''' <summary>
        ''' 一个蛋白可能会因为比对上多个结构域而出现多个COG编号的情况
        ''' </summary>
        ''' <param name="cogTable"></param>
        ''' <returns>``gi, (genome_name, cogs())``</returns>
        Public Shared Function GI2COGs(cogTable As IEnumerable(Of COGTable)) As Dictionary(Of String, NamedValue(Of String()))
            Dim proteins = cogTable.GroupBy(Function(prot) prot.ProteinID)
            Dim out = proteins.ToDictionary(
                Function(prot) prot.Key,
                Function(prot) New NamedValue(Of String()) With {
                    .Name = prot.First.GenomeName,
                    .Value = prot _
                        .Select(Function(x) x.COGId) _
                        .Distinct _
                        .ToArray
                })

            Return out
        End Function
    End Class
End Namespace
