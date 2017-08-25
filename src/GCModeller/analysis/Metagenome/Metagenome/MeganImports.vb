﻿#Region "Microsoft.VisualBasic::dd9565e456223188f3719d7f2d80302d, ..\GCModeller\analysis\Metagenome\Metagenome\MeganImports.vb"

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

Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Analysis.Metagenome.gast
Imports SMRUCC.genomics.Assembly.NCBI
Imports SMRUCC.genomics.Assembly.NCBI.Taxonomy
Imports SMRUCC.genomics.SequenceModel.SAM

''' <summary>
''' Megan Csv imports
''' </summary>
Public Class MeganImports

    Public Property READ_NAME As String

    <Column("CLASS-NAME")>
    Public Property CLASS_NAME As String
    Public Property COUNT As String

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sam">*.sam</param>
    ''' <param name="gi2taxid">txt/bin</param>
    ''' <param name="tax_dmp">nodes/names.dmp DIR</param>
    ''' <returns></returns>
    Public Shared Iterator Function [Imports](sam As String, gi2taxid As String, tax_dmp As String) As IEnumerable(Of MeganImports)
        Dim giTaxid As BucketDictionary(Of Integer, Integer) = AcquireAuto(gi2taxid)
        Dim tree As New NcbiTaxonomyTree(tax_dmp)
        Dim reads As New Dictionary(Of String, List(Of String))

        For Each read As AlignmentReads In New SamStream(sam).ReadBlock

        Next
    End Function

    Public Shared Iterator Function [Imports](source As IEnumerable(Of Names)) As IEnumerable(Of MeganImports)
        For Each x As Names In source
            If x.Unique = TagNoAssign OrElse x.Unique = TagTotal Then
                Continue For
            End If

            Yield New MeganImports With {
                .CLASS_NAME = x.taxonomy,
                .COUNT = x.NumOfSeqs,
                .READ_NAME = x.Unique
            }
        Next
    End Function

    Public Shared Function Out(source As IEnumerable(Of Names)) As IO.File
        Dim file As New IO.File

        file += {NameOf(READ_NAME), NameOf(CLASS_NAME), NameOf(COUNT)}

        For Each x As Names In source
            file += New RowObject({x.Unique, x.taxonomy, x.NumOfSeqs})
        Next

        Return file
    End Function
End Class
