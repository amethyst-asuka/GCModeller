﻿
Imports Microsoft.VisualBasic.ComponentModel.DataStructures
Imports Microsoft.VisualBasic.ComponentModel.Ranges
Imports SMRUCC.genomics.ComponentModel.Loci
Imports SMRUCC.genomics.SequenceModel.FASTA
Imports SMRUCC.genomics.SequenceModel.NucleotideModels

''' <summary>
''' Build the sampling windows by using GC% or GC skew.
''' </summary>
Public Module GCWindows

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nt"></param>
    ''' <param name="slideWin"></param>
    ''' <param name="steps"></param>
    ''' <param name="[property]"><see cref="GCSkew"/> or <see cref="GCContent"/> or your custom engine.</param>
    ''' <returns></returns>
    Public Iterator Function GetWindows(nt As FastaToken, slideWin As Integer, steps As Integer, Optional [property] As NtProperty = Nothing) As IEnumerable(Of NucleotideLocation)
        Dim gc As Double() = If([property] Is Nothing, New NtProperty(AddressOf GCSkew), [property])(nt, slideWin, steps, True)
        Dim avg As Double = gc.Average
        Dim pdelta As Double = (gc.Max - gc.Min) / 10
        Dim range As New DoubleRange(avg - pdelta, avg + pdelta)
        Dim pre As Double = -1

        For Each win In gc.SlideWindows(slideWin / 2, steps / 2)
            Dim d As Double = win.Elements.Average

            If Not range.IsInside(d) Then

            End If
        Next
    End Function
End Module