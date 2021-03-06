﻿#Region "Microsoft.VisualBasic::20eda6f0c52fbbec386610b13a6a6322, ..\localblast\LocalBLAST\LocalBLAST\BlastOutput\Reader\Blast+\2.2.28\Query.vb"

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

Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Extensions
Imports Microsoft.VisualBasic.Language
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.BLASTOutput.ComponentModel

Namespace LocalBLAST.BLASTOutput.BlastPlus

    Public Class Query

        <XmlAttribute> Public Property QueryName As String
        ''' <summary>
        ''' Protein length of <see cref="QueryName">the target query protein</see>.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property QueryLength As Integer
        <XmlAttribute> Public Property EffectiveSearchSpace As Long
        <XmlElement> Public Property p As Parameter
        <XmlElement> Public Property Gapped As Parameter

        <XmlArray> Public Property SubjectHits As SubjectHit()

        Sub New()
        End Sub

        ''' <summary>
        ''' Value copy
        ''' </summary>
        ''' <param name="query"></param>
        Sub New(query As Query)
            With Me
                .EffectiveSearchSpace = query.EffectiveSearchSpace
                .Gapped = query.Gapped
                .p = query.p
                .QueryLength = query.QueryLength
                .QueryName = query.QueryName
                .SubjectHits = query.SubjectHits
            End With
        End Sub

        Public Overrides Function ToString() As String
            Return QueryName
        End Function

        Public Function GetBestHit(Optional coverage As Double = 0.5, Optional identities As Double = 0.15) As SubjectHit
            If SubjectHits.IsNullOrEmpty Then Return Nothing

            Dim LQuery = (From hit As SubjectHit
                          In SubjectHits
                          Where hit.LengthQuery / QueryLength >= coverage AndAlso
                                  hit.Score.Identities.Value >= identities
                          Select hit
                          Order By hit.Score.RawScore Descending).FirstOrDefault
            Return LQuery
        End Function

        ''' <summary>
        ''' 导出所有符合条件的最佳匹配
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBesthits(coverage As Double, identities As Double) As SubjectHit()
            If SubjectHits.IsNullOrEmpty Then
                Return Nothing
            End If

            Dim LQuery As SubjectHit() = LinqAPI.Exec(Of SubjectHit) <=
 _
                From hit As SubjectHit
                In SubjectHits
                Where hit.LengthQuery / QueryLength >= coverage AndAlso
                    hit.Score.Identities.Value >= identities
                Select hit
                Order By hit.Score.RawScore Descending

            Return LQuery
        End Function

        ''' <summary>
        ''' <see cref="ReaderTypes.BLASTP"/>
        ''' </summary>
        ''' <param name="strText"></param>
        ''' <returns></returns>
        Public Shared Function TryParse(strText As String) As Query
            Dim Query As Query = New Query With {
                .QueryName = GetQueryName(strText),
                .QueryLength = GetQueryLength(strText)
            }
            Query.SubjectHits = SubjectHit.GetItems(strText)

            Dim TEMP = Parameter.TryParseBlastPlusParameters(strText)
            Dim ssp$ = Regex.Match(strText, EffectiveSearchSpaceRegexp, RegexOptions.Singleline).Value.Match("\d+")
            Query.p = TEMP(0)
            Query.Gapped = TEMP(1)
            Query.EffectiveSearchSpace = Val(ssp)

            Return Query
        End Function

        Const EffectiveSearchSpaceRegexp$ = "Effective search space used: \d+"

        ''' <summary>
        ''' <see cref="ReaderTypes.BLASTN"/>
        ''' </summary>
        ''' <param name="text"></param>
        ''' <returns></returns>
        Public Shared Function BlastnOutputParser(text As String) As Query
            Dim hitsBuffer As BlastnHit() = BlastnHit.hitParser(text)
            Dim query As New Query With {
                .QueryName = GetQueryName(text),
                .QueryLength = GetQueryLength(text),
                .SubjectHits = Constrain(Of SubjectHit, BlastnHit)(hitsBuffer)
            }

            Dim TEMP = Parameter.TryParseBlastPlusBlastn(text)
            Dim ssp$ = Regex _
                .Match(text, EffectiveSearchSpaceRegexp, RegexOptions.Singleline) _
                .Value _
                .Match("\d+")

            query.p = TEMP(0)
            query.Gapped = TEMP(1)
            query.EffectiveSearchSpace = Val(ssp$)

            Return query
        End Function

        Private Shared Function GetQueryLength(text As String) As Integer
            Return Val(Mid(Regex.Match(text, "Length=\d+").Value, 8))
        End Function

        Private Shared Function GetQueryName(text As String) As String
            Dim QueryName As String = Mid(Regex.Match(text, "Query= .+?Length", RegexOptions.Singleline).Value, 8).Trim
            If Len(QueryName) > 8 Then
                QueryName = Mid(QueryName, 1, Len(QueryName) - 8).TrimNewLine
            Else
                Call $"This query name value is not valid!{vbCrLf}""{QueryName}""".__DEBUG_ECHO
                QueryName = Regex.Replace(QueryName, "Length$", "", RegexOptions.IgnoreCase)
            End If

            Return QueryName
        End Function
    End Class
End Namespace
