﻿#Region "Microsoft.VisualBasic::90714979183a25f8253c8e758e9b417c, ..\core\Bio.Assembly\SequenceModel\Patterns\Variation.vb"

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

Imports Microsoft.VisualBasic.ComponentModel.Algorithm.base
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.SequenceModel.FASTA

Namespace SequenceModel.Patterns

    Public Class Variation

        Public Enum Variations
            ''' <summary>
            ''' No changes
            ''' </summary>
            NULL = 0
            NA
            NG
            NC
            NT
            AG
            AC
            AT
            GA
            GC
            GT
            CA
            CG
            CT
            TA
            TG
            TC
        End Enum

        Public ReadOnly Property Nt As String
        Public ReadOnly Property ref As Char()
        Public Property Strict As Boolean = True

        Sub New(ref As FastaToken)
            _Nt = ref.Title
            _ref = ref.SequenceData.ToUpper.Replace("N", "-")
        End Sub

        Public Function NtVariation(SequenceModel As IPolymerSequenceModel, SlideWindowSize As Integer, Steps As Integer, Circular As Boolean) As Double()
            Dim nt As Char() = SequenceModel.SequenceData.ToUpper.Replace("N", "-")
            Dim array As Variations() = nt.SeqIterator.ToArray(Function(base) Variation(ref(base), +base, Strict))
            Dim blocks = array.SlideWindows(SlideWindowSize, offset:=Steps)
            Dim out As New List(Of Double)

            For Each x In blocks
                Dim type = (From v As Variations
                            In x.Items
                            Select v
                            Group v By v Into Count
                            Order By Count Descending).Last.v
                out += CInt(type)
            Next

            Return out
        End Function

        Public Shared Function Build(source As FastaFile, ref$) As SeqValue(Of Dictionary(Of String, Variations))()
            Try
                Return Build(source, source.Index(ref$))
            Catch ex As Exception
                Throw New Exception("ref:=" & ref, ex)
            End Try
        End Function

        Public Shared Function Build(source As FastaFile, ref%, Optional strict As Boolean = False) As SeqValue(Of Dictionary(Of String, Variations))()
            If ref < 0 Then
                Throw New EvaluateException($"Reference index value:={ref} is not a valid index!")
            End If

            Dim refFa As FastaToken = source(ref)

            Call source.RemoveAt(ref)
            Call $"Using {refFa.Title} as references...".__DEBUG_ECHO

            Dim refSeq$ = refFa.SequenceData.ToUpper.Replace("N", "-")
            Dim out As SeqValue(Of Dictionary(Of String, Variations))() =
                New SeqValue(Of Dictionary(Of String, Variations))(refSeq.Length - 1) {}

            For i As Integer = 0 To out.Length - 1
                out(i) = New SeqValue(Of Dictionary(Of String, Variations)) With {
                    .i = i,
                    .value = New Dictionary(Of String, Variations)
                }
            Next

            Dim array As NamedValue(Of Char())() =
 _
                LinqAPI.Exec(Of NamedValue(Of Char())) <=
 _
                From seq As FastaToken
                In source
                Let trimSeq As String = seq.SequenceData _
                    .ToUpper _
                    .Replace("N", "-")
                Select New NamedValue(Of Char()) With {
                    .Name = seq.Title,
                    .Value = trimSeq.ToArray
                }

            For i As Integer = 0 To out.Length - 1
                Dim refC As Char = refSeq(i)

                For Each seq As NamedValue(Of Char()) In array
                    out(i).value.Add(seq.Name, Variation(refC, seq.Value(i), strict))
                Next
            Next

            Return out
        End Function

        Public Shared Function Variation(ref As Char, v As Char, strict As Boolean) As Variations
re0:
            Select Case ref
                Case "-"c
                    Select Case v
                        Case "-"c : Return Variations.NULL
                        Case "A"c : Return Variations.NA
                        Case "T"c : Return Variations.NT
                        Case "G"c : Return Variations.NG
                        Case "C"c : Return Variations.NC
                        Case Else
                            If strict Then
                                Throw New Exception("nt is not valid: " & v)
                            Else
                                Return Variations.NULL
                            End If
                    End Select
                Case "A"c
                    Select Case v
                        Case "-"c : Return Variations.NA
                        Case "A"c : Return Variations.NULL
                        Case "T"c : Return Variations.AT
                        Case "G"c : Return Variations.AG
                        Case "C"c : Return Variations.AC
                        Case Else
                            If strict Then
                                Throw New Exception("nt is not valid: " & v)
                            Else
                                Return Variations.NA
                            End If
                    End Select
                Case "T"c
                    Select Case v
                        Case "-"c : Return Variations.NT
                        Case "A"c : Return Variations.TA
                        Case "T"c : Return Variations.NULL
                        Case "G"c : Return Variations.TG
                        Case "C"c : Return Variations.TC
                        Case Else
                            If strict Then
                                Throw New Exception("nt is not valid: " & v)
                            Else
                                Return Variations.NT
                            End If
                    End Select
                Case "G"c
                    Select Case v
                        Case "-"c : Return Variations.NG
                        Case "A"c : Return Variations.GA
                        Case "T"c : Return Variations.GT
                        Case "G"c : Return Variations.NULL
                        Case "C"c : Return Variations.GC
                        Case Else
                            If strict Then
                                Throw New Exception("nt is not valid: " & v)
                            Else
                                Return Variations.NG
                            End If
                    End Select
                Case "C"c
                    Select Case v
                        Case "-"c : Return Variations.NC
                        Case "A"c : Return Variations.CA
                        Case "T"c : Return Variations.CT
                        Case "G"c : Return Variations.CG
                        Case "C"c : Return Variations.NULL
                        Case Else
                            If strict Then
                                Throw New Exception("nt is not valid: " & v)
                            Else
                                Return Variations.NC
                            End If
                    End Select
                Case Else
                    If strict Then
                        Throw New Exception("Reference nt is not valid: " & ref)
                    Else
                        ref = "-"c
                        GoTo re0
                    End If
            End Select
        End Function

        Public Shared Function Build(source As IEnumerable(Of FastaToken), ref$) As SeqValue(Of Dictionary(Of String, Variations))()
            Return Build(New FastaFile(source), ref$)
        End Function
    End Class
End Namespace
