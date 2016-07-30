﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace StringDB.Tsv

    ''' <summary>
    ''' interaction types for protein links
    ''' </summary>
    Public Class Actions

        Public Property item_id_a As String
        Public Property item_id_b As String
        Public Property mode As String
        Public Property action As String
        Public Property a_is_acting As String
        Public Property score As String

        Public Shared Iterator Function LoadText(path As String) As IEnumerable(Of Actions)
            For Each line As String In path.IterateAllLines.Skip(1)
                Dim tokens As String() = line.Split(Text.ASCII.TAB)

                Yield New Actions With {
                    .item_id_a = tokens(0),
                    .item_id_b = tokens(1),
                    .mode = tokens(2),
                    .action = tokens(3),
                    .a_is_acting = tokens(4),
                    .score = tokens(5)
                }
            Next
        End Function
    End Class

    ''' <summary>
    ''' protein network data (incl. subscores per channel); commercial entities require a license.	
    ''' </summary>
    Public Class linksDetail

        Public Property protein1 As String
        Public Property protein2 As String
        Public Property neighborhood As String
        Public Property fusion As String
        Public Property cooccurence As String
        Public Property coexpression As String
        Public Property experimental As String
        Public Property database As String
        Public Property textmining As String
        Public Property combined_score As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function

        Public Shared Iterator Function LoadFile(path As String) As IEnumerable(Of linksDetail)
            For Each line As String In path.IterateAllLines.Skip(1)
                Dim tokens As String() = line.Split(" "c)

                Yield New linksDetail With {
                    .protein1 = tokens(0),
                    .protein2 = tokens(1),
                    .neighborhood = tokens(2),
                    .fusion = tokens(3),
                    .cooccurence = tokens(4),
                    .coexpression = tokens(5),
                    .experimental = tokens(6),
                    .database = tokens(7),
                    .textmining = tokens(8),
                    .combined_score = tokens(9)
                }
            Next
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="maps"></param>
        ''' <returns></returns>
        Public Shared Iterator Function Selects(
                                        source As IEnumerable(Of EntityObject),
                                        links As IEnumerable(Of linksDetail),
                               Optional maps As Dictionary(Of String, String) = Nothing) _
                                             As IEnumerable(Of EntityObject)
            If maps Is Nothing Then
                maps = New Dictionary(Of String, String)
            End If

            Dim FromHash As Dictionary(Of String, linksDetail()) = (
                From x As linksDetail
                In links
                Select x
                Group x By x.protein1 Into Group) _
                     .ToDictionary(Function(x) x.protein1,
                                   Function(x) x.Group.ToArray)
            Dim ToHash As Dictionary(Of String, linksDetail()) = (
                From x As linksDetail
                In FromHash.Values.MatrixAsIterator
                Select x
                Group x By x.protein2 Into Group) _
                     .ToDictionary(Function(x) x.protein2,
                                   Function(x) x.Group.ToArray)
            Dim revMaps = maps.ToDictionary(Function(x) x.Value, Function(x) x.Key)

            For Each x As EntityObject In source
                Dim key As String = x.Identifier
                Dim STRINGmap As String

                If maps.ContainsKey(x.Identifier) Then
                    STRINGmap = maps(x.Identifier)
                Else
                    STRINGmap = x.Identifier
                End If

                If FromHash.ContainsKey(STRINGmap) Then
                    For Each part As linksDetail In FromHash(STRINGmap)
                        Dim copy As EntityObject = x.Copy

                        copy.Properties.Add(NameOf(part.textmining), part.textmining)
                        copy.Properties.Add(NameOf(part.neighborhood), part.neighborhood)
                        copy.Properties.Add(NameOf(part.fusion), part.fusion)
                        copy.Properties.Add(NameOf(part.experimental), part.experimental)
                        copy.Properties.Add(NameOf(part.database), part.database)
                        copy.Properties.Add(NameOf(part.cooccurence), part.cooccurence)
                        copy.Properties.Add(NameOf(part.combined_score), part.combined_score)
                        copy.Properties.Add(NameOf(part.coexpression), part.coexpression)
                        copy.Properties.Add("Part To", part.protein2)

                        If revMaps.ContainsKey(part.protein2) Then
                            copy.Properties.Add("(NCBI)Part To", revMaps(part.protein2))
                        End If

                        Yield copy
                    Next
                End If
                If ToHash.ContainsKey(STRINGmap) Then
                    For Each part As linksDetail In ToHash(STRINGmap)
                        Dim copy As EntityObject = x.Copy

                        copy.Properties.Add(NameOf(part.textmining), part.textmining)
                        copy.Properties.Add(NameOf(part.neighborhood), part.neighborhood)
                        copy.Properties.Add(NameOf(part.fusion), part.fusion)
                        copy.Properties.Add(NameOf(part.experimental), part.experimental)
                        copy.Properties.Add(NameOf(part.database), part.database)
                        copy.Properties.Add(NameOf(part.cooccurence), part.cooccurence)
                        copy.Properties.Add(NameOf(part.combined_score), part.combined_score)
                        copy.Properties.Add(NameOf(part.coexpression), part.coexpression)
                        copy.Properties.Add("Part From", part.protein1)

                        If revMaps.ContainsKey(part.protein1) Then
                            copy.Properties.Add("(NCBI)Part From", revMaps(part.protein1))
                        End If

                        Yield copy
                    Next
                End If
            Next
        End Function
    End Class

    ''' <summary>
    ''' separate identifier mapping files, for several frequently used name_spaces...
    ''' </summary>
    Public Class entrez_gene_id_vs_string

        <Column("#Entrez_Gene_ID")> Public Property Entrez_Gene_ID As String
        Public Property STRING_Locus_ID As String

        Public Overrides Function ToString() As String
            Return $"{Entrez_Gene_ID} <--> {STRING_Locus_ID}"
        End Function

        Public Shared Function BuildMapsFromFile(path As String, Optional tsv As Boolean = True) As Dictionary(Of String, String)
            If tsv Then
                Return BuildMaps(path.Imports(Of entrez_gene_id_vs_string)(vbTab))
            Else
                Return BuildMaps(path.LoadCsv(Of entrez_gene_id_vs_string))
            End If
        End Function

        Public Shared Function BuildMaps(source As IEnumerable(Of entrez_gene_id_vs_string)) As Dictionary(Of String, String)
            Return source.ToDictionary(Function(x) x.Entrez_Gene_ID, Function(x) x.STRING_Locus_ID)
        End Function
    End Class
End Namespace
