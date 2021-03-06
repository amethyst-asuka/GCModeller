﻿#Region "Microsoft.VisualBasic::4568c76933226d75678da34c842d6a9b, ..\core\Bio.Assembly\Assembly\NCBI\Database\GenBank\TabularFormat\ProteinTable\ProteinTable.vb"

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

Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Text

Namespace Assembly.NCBI.GenBank.TabularFormat

    Public Class ProteinTable : Inherits ITextFile

        Public Property Proteins As ProteinDescription()

        Public Overrides Function Save(Optional FilePath As String = "", Optional Encoding As Encoding = Nothing) As Boolean
            Throw New NotImplementedException()
        End Function

        Public Shared Function Load(Path As String) As ProteinTable
            Dim bufs As String() = IO.File.ReadAllLines(Path)
            Dim schema As New Index(Of String)(bufs.First.Split(ASCII.TAB))
            Dim LQuery = LinqAPI.Exec(Of ProteinDescription) <=
 _
                From str As String
                In bufs.Skip(1).AsParallel
                Select prot = CreateObject(str, schema)
                Order By prot.Locus_tag Ascending

            Return New ProteinTable With {
                .FilePath = Path,
                .Proteins = LQuery
            }
        End Function

        Public Overloads Shared Function CreateObject(str$, schema As Index(Of String)) As ProteinDescription
            Dim tokens As String() = Strings.Split(str, vbTab)
            Dim getValue = Function(key$)
                               Dim i% = schema(key)

                               If i = -1 Then
                                   Return ""
                               Else
                                   Return tokens(i)
                               End If
                           End Function
            Dim protein As New ProteinDescription With {
                .RepliconName = getValue(key:="#Replicon Name"),
                .RepliconAccession = getValue(key:="Replicon Accession"),
                .Start = CInt(getValue(key:="Start")),
                .Stop = CInt(getValue(key:="Stop")),
                .Strand = getValue(key:="Strand"),
                .GeneID = getValue(key:="GeneID"),
                .Locus = getValue(key:="Locus"),
                .Locus_tag = getValue(key:="Locus tag"),
                .Product = getValue(key:="Protein product"),
                .Length = CInt(getValue(key:="Length")),
                .COG = getValue(key:="COG"),
                .ProteinName = getValue(key:="Protein name")
            }

            Return protein
        End Function

        Public Function ToPTT() As PTT
            Return New PTT With {
                .GeneObjects = Proteins.ToArray(Function(prot) prot.ToPTTGene)
            }
        End Function
    End Class
End Namespace
