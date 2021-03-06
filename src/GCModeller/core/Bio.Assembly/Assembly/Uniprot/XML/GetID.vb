﻿#Region "Microsoft.VisualBasic::e84f6e88cffb691b55088eb18341175c, ..\core\Bio.Assembly\Assembly\Uniprot\XML\GetID.vb"

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

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic

Namespace Assembly.Uniprot.XML

    Public Module GetIDs

        Public Enum IDTypes
            ''' <summary>
            ''' Uniprot accession ID
            ''' </summary>
            Accession
            ORF
            LocusTag
            RefSeq
            KEGG
            EMBL
        End Enum

        ''' <summary>
        ''' 名字是小写的
        ''' </summary>
        Dim parser As New MapsHelper(Of IDTypes)(map:=EnumParser(Of IDTypes)(), [default]:=IDTypes.Accession)

        Public Function ParseType(type$) As IDTypes
            Return parser(LCase(type))
        End Function

        <Extension> Public Function GetID(type As IDTypes) As Func(Of entry, String)
            Select Case type
                Case IDTypes.Accession
                    Return Function(prot As entry)
                               Return DirectCast(prot, INamedValue).Key
                           End Function
                Case IDTypes.EMBL
                    Return Function(prot As entry)
                               If prot.Xrefs.ContainsKey(NameOf(IDTypes.EMBL)) Then
                                   Return prot.Xrefs(NameOf(IDTypes.EMBL)) _
                                       .First _
                                       .properties _
                                       .Where(Function(p) p.type = "protein sequence ID") _
                                       .FirstOrDefault?.value
                               Else
                                   Return Nothing
                               End If
                           End Function
                Case IDTypes.KEGG
                    Return Function(prot As entry)
                               If prot.Xrefs.ContainsKey(NameOf(IDTypes.KEGG)) Then
                                   Return prot.Xrefs(NameOf(IDTypes.KEGG)).FirstOrDefault?.id
                               Else
                                   Return Nothing
                               End If
                           End Function
                Case IDTypes.LocusTag
                    Return Function(prot As entry)
                               Return prot.gene("ordered locus").FirstOrDefault
                           End Function
                Case IDTypes.ORF
                    Return Function(prot As entry)
                               Return prot.gene.ORF.FirstOrDefault
                           End Function
                Case IDTypes.RefSeq
                    Return Function(prot As entry)
                               If prot.Xrefs.ContainsKey(NameOf(IDTypes.RefSeq)) Then
                                   Return prot.Xrefs(NameOf(IDTypes.RefSeq)).FirstOrDefault?.id
                               Else
                                   Return Nothing
                               End If
                           End Function
                Case Else
                    Throw New NotImplementedException(type.ToString)
            End Select
        End Function

        <Extension> Public Function GetID(type$) As Func(Of entry, String)
            Return parser(LCase(type)).GetID
        End Function

    End Module
End Namespace
