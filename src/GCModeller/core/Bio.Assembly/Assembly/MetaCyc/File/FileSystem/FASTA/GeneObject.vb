﻿#Region "Microsoft.VisualBasic::3d4856e456e64c1a33ede06f04f55aa8, ..\Bio.Assembly\Assembly\MetaCyc\File\FileSystem\FASTA\GeneObject.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
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

Imports System.Text.RegularExpressions
Imports System.Text
Imports SMRUCC.genomics.ComponentModel.Loci
Imports SMRUCC.genomics.SequenceModel.FASTA
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic

Namespace Assembly.MetaCyc.File.FileSystem.FastaObjects

    Public Class GeneObject : Inherits FastaToken
        Implements IReadOnlyId

        Public ReadOnly Property UniqueId As String Implements IReadOnlyId.Identity
            Get
                Return Attributes.Last.Split.First
            End Get
        End Property

        Public ReadOnly Property AccessionId As String
            Get
                Return Attributes.Last.Split()(1)
            End Get
        End Property

        Public ReadOnly Property ProductUniqueId As String
            Get
                Return Attributes.Last.Split()(2).Replace("""", "")
            End Get
        End Property

        '>gnl|ECOLI|EG10570 map "EG10570-MONOMER" (complement(189506..188712)) Escherichia coli K-12 substr. MG1655
        '>gnl|ECOLI|EG11769 ybbC "EG11769-MONOMER" 526805..527173 Escherichia coli K-12 substr. MG1655
        Public Const METACYC_LOCATION_REGX As String = "(\(complement\(\d+\.\.\d+\)\))|(\d+\.\.\d+)"

        Public ReadOnly Property Location As NucleotideLocation
            Get
                ' Dim strLocation As String = Attributes.Last.Split()(3)
                Dim strLocation As String = Regex.Match(Attributes.Last, METACYC_LOCATION_REGX).Value
                Dim Tokens As String() = Nothing
                Dim Strand As Strands

                If InStr(strLocation, "complement") Then
                    strLocation = Regex.Match(strLocation, "\d+\.\.\d+").Value
                    Tokens = Strings.Split(strLocation, "..")
                    Strand = Strands.Reverse
                Else
                    Tokens = Strings.Split(strLocation, "..")
                    Strand = Strands.Forward
                End If

                Dim objLocation = New NucleotideLocation
                objLocation.Left = Val(Tokens(0))
                objLocation.Right = Val(Tokens(1))
                objLocation.Strand = Strand

                Return objLocation
            End Get
        End Property

        Public ReadOnly Property Species As String
            Get
                Dim sBuilder As StringBuilder = New StringBuilder(128)
                Dim Tokens As String() = Attributes.Last.Split

                For i As Integer = 4 To Tokens.Length - 1
                    Call sBuilder.Append(Tokens(i) & " ")
                Next

                Return Trim(sBuilder.ToString)
            End Get
        End Property

        Sub New()
        End Sub

        Sub New(fa As FastaToken)
            Attributes = fa.Attributes
            SequenceData = fa.SequenceData
        End Sub

        Public Overloads Shared Sub Save(Data As GeneObject(), FilePath As String)
            Dim FsaFile As FastaFile = New FastaFile With {
                .FilePath = FilePath,
                ._innerList = New List(Of FastaToken)
            }
            Call FsaFile._innerList.AddRange(Data)
            Call FsaFile.Save()
        End Sub
    End Class
End Namespace