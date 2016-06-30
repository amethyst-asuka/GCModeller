﻿Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Xml.Serialization
Imports LANS.SystemsBiology.SequenceModel
Imports LANS.SystemsBiology.SequenceModel.FASTA
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel

Namespace Regtransbase.WebServices

    Public Class RegPreciseTFFamily
        <XmlElement> Public Property Family As TranscriptionFactorFamily()

        Const ITEM As String = "<tr .+?</tr>"

        Public Shared Function Download(url As String) As RegPreciseTFFamily
            Dim pageContent As String = url.GET()
            Dim Items = (From m As Match In Regex.Matches(pageContent, ITEM, RegexOptions.Singleline + RegexOptions.IgnoreCase) Select m.Value).ToArray
            Dim Families = (From item As String In Items Select WebServices.TranscriptionFactorFamily.Parse(item)).ToArray

            Return New RegPreciseTFFamily With {.Family = Families}
        End Function

        Public Sub Export(ExportDir As String)
            Call FileIO.FileSystem.CreateDirectory(ExportDir)

            For Each TFF In Family
                Dim file = String.Format("{0}/{1}.fsa", ExportDir, TFF.Family)
                Call CType(TFF.Regulogs.Export, SequenceModel.FASTA.FastaFile).Save(file)
            Next
        End Sub

        Public Shared Function Export(RegPreciseTFFamily As RegPreciseTFFamily) As SequenceModel.FASTA.FastaFile
            Dim Fsa As LANS.SystemsBiology.SequenceModel.FASTA.FastaFile = New SequenceModel.FASTA.FastaFile
            For Each TFF In RegPreciseTFFamily.Family
                Dim List = TFF.Regulogs.Export
                Call Fsa.AddRange(List)
            Next

            For i As Integer = 0 To Fsa.Count - 1
                Fsa(i).Attributes(0) = String.Format("tfbs_{0} {1}", i, Fsa(i).Attributes(0))
            Next

            Return Fsa
        End Function

        Public Function FindAtRegulog(Keyword As String) As Regulator
            For Each tff In Family
                Dim LQuery = (From item In tff.Regulogs.Logs Where String.Equals(item.Regulog.Key, Keyword) Select item.TFBSs).ToArray
                If Not LQuery.IsNullOrEmpty Then
                    Return LQuery.First
                End If
            Next
            Return Nothing
        End Function

        Public Overrides Function ToString() As String
            Return "http://regprecise.lbl.gov/RegPrecise/collections_tffam.jsp"
        End Function

        Public Shared Widening Operator CType(FilePath As String) As RegPreciseTFFamily
            Return FilePath.LoadXml(Of RegPreciseTFFamily)()
        End Operator
    End Class

    ''' <summary>
    ''' http://regprecise.lbl.gov/RegPrecise/collections_tffam.jsp
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TranscriptionFactorFamily
        <XmlAttribute> Public Property Family As String
        Public Property Url As String
        Public Property Regulogs As Regulogs
        <XmlAttribute> Public Property TFRegulons As String
        <XmlAttribute> Public Property TFBindingSites As String
        <XmlAttribute> Public Property Genomes As String

        Public Overrides Function ToString() As String
            Return Family
        End Function

        Const COLUMN_ITEM As String = "<td.+?</td>"
        Const HREF As String = "href="".+?"""

        Protected Friend Shared Function Parse(strText As String) As TranscriptionFactorFamily
            Dim Items = (From m As Match In Regex.Matches(strText, COLUMN_ITEM, RegexOptions.Singleline + RegexOptions.IgnoreCase) Select m.Value).ToArray
            Dim TFF As TranscriptionFactorFamily = New TranscriptionFactorFamily With {.Regulogs = New Regulogs}
            Dim p As Integer
            Dim Head As String = Items(p.MoveNext)
            TFF.Regulogs.Counts = Regex.Match(Items(p.MoveNext), "[^>]+</").Value
            TFF.TFRegulons = Regex.Match(Items(p.MoveNext), "[^>]+</").Value
            TFF.TFBindingSites = Regex.Match(Items(p.MoveNext), "[^>]+</").Value
            TFF.Genomes = Regex.Match(Items(p.MoveNext), "[^>]+</").Value
            TFF.Url = Regex.Match(Head, HREF, RegexOptions.IgnoreCase).Value
            TFF.Family = Regex.Match(Mid(Head, InStr(Head, "href", CompareMethod.Text)), "[^>]+<a", RegexOptions.Singleline).Value

            TFF.Url = Mid(TFF.Url, 6)
            TFF.Url = "http://regprecise.lbl.gov/RegPrecise/" & Mid(TFF.Url, 2, Len(TFF.Url) - 2)
            TFF.Regulogs.Counts = Mid(TFF.Regulogs.Counts, 1, Len(TFF.Regulogs.Counts) - 2)
            TFF.TFRegulons = Mid(TFF.TFRegulons, 1, Len(TFF.TFRegulons) - 2)
            TFF.TFBindingSites = Mid(TFF.TFBindingSites, 1, Len(TFF.TFBindingSites) - 2)
            TFF.Genomes = Mid(TFF.Genomes, 1, Len(TFF.Genomes) - 2)
            TFF.Family = Mid(TFF.Family, 1, Len(TFF.Family) - 2)
            Call Regulogs.Parse(TFF.Url, TFF.Regulogs)

            Call Threading.Thread.Sleep(1000) '防止服务器的访问压力过大被封IP

            Return TFF
        End Function
    End Class

    Public Class Regulogs

        <XmlElement> Public Property Logs As Item()
        <XmlAttribute> Public Property Counts As String
        Public Property Description As String

        Public Function Export() As FASTA.FastaToken()
            Return Logs.Select(Function(x) x.TFBSs.ExportMotifs).MatrixToVector
        End Function

        ''' <summary>
        ''' {Regulog, {Locus_tag, Locus_tag()}}
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUniqueIds() As KeyValuePair(Of String, KeyValuePair(Of String, String())())()
            Dim LQuery = (From item In Logs Select item.TFBSs.GetUniqueId).ToArray
            Return LQuery
        End Function

        Public Class Item

            <XmlAttribute> Public Property Phylum As String
            Public Property Regulog As KeyValuePair
            <XmlAttribute> Public Property TFRegulons As String
            Public Property TFBSs As Regulator

            Public Overrides Function ToString() As String
                Return Regulog.ToString
            End Function

            Const COLUMNS As String = "<td.+?</td>"

            Protected Friend Shared Function Parse(strText As String) As Item
                Dim Columns = (From m As Match In Regex.Matches(strText, Regulogs.Item.COLUMNS, RegexOptions.Singleline + RegexOptions.IgnoreCase) Select m.Value).ToArray.Skip(1).ToArray
                Dim p As Integer
                Dim item As Item = New Item

                item.Phylum = Regex.Match(Columns(p.MoveNext), ">[^>]+?</").Value
                item.Regulog = ParseLog(Columns(p.MoveNext))
                item.TFRegulons = Regex.Match(Columns(p.MoveNext), ">[^>]+?</").Value

                item.Phylum = TrimText(Mid(item.Phylum, 2, Len(item.Phylum) - 3))
                item.TFRegulons = Mid(item.TFRegulons, 2, Len(item.TFRegulons) - 3)

                Dim TFBSsUrl As String = Columns(p.MoveNext)
                TFBSsUrl = Mid(Regex.Match(TFBSsUrl, "href="".+?""").Value, 7)
                TFBSsUrl = "http://regprecise.lbl.gov/RegPrecise/" & Mid(TFBSsUrl, 1, Len(TFBSsUrl) - 1)

                item.TFBSs = Regulator.Parse(TFBSsUrl)

                Return item
            End Function

            Private Shared Function ParseLog(strText As String) As KeyValuePair
                Dim Pair As New KeyValuePair
                Pair.Key = Regex.Match(strText, ">[^>]+?</a").Value
                Pair.Value = Regex.Match(strText, "href="".+?""").Value
                Pair.Key = Mid(Pair.Key, 2, Len(Pair.Key) - 4)
                Pair.Value = "http://regprecise.lbl.gov/RegPrecise/" & Mid(Pair.Value, 7, Len(Pair.Value) - 7)

                Return Pair
            End Function
        End Class

        Const ROW_ITEM As String = "<tr>.+?</tr>"

        Protected Friend Shared Sub Parse(url As String, Regulogs As Regulogs)
            Dim pageContent As String = url.GET

            Regulogs.Description = GetDescription(pageContent)
            pageContent = Regex.Matches(pageContent, "<tbody>.+?</tbody>", RegexOptions.Singleline + RegexOptions.IgnoreCase).Item(1).Value

            Dim Rows = (From m As Match In Regex.Matches(pageContent, ROW_ITEM, RegexOptions.Singleline + RegexOptions.IgnoreCase) Select m.Value).ToArray

            Regulogs.Logs = (From strText As String In Rows Select Item.Parse(strText)).ToArray
        End Sub

        Const TEXT_DESCRIPTION As String = "<h2 class=""text_description"".+?</h2>"

        Private Shared Function GetDescription(pageContent As String) As String
            Dim strText As String = Regex.Match(pageContent, TEXT_DESCRIPTION, RegexOptions.Singleline).Value

            Const SPAN As String = "<span .+</span>"
            Dim Tokens = Regex.Split(strText, SPAN, RegexOptions.Singleline)
            Tokens(0) = TrimText(Mid(Tokens(0), Len(Regex.Match(Tokens(0), "<h2.+?"">", RegexOptions.Singleline).Value) + 1))
            If Tokens.Count > 1 Then
                Tokens(1) = Regex.Match(Tokens(1), ">.+?</div", RegexOptions.Singleline).Value
                Tokens(1) = TrimText(Mid(Tokens(1), 2, Len(Tokens(1)) - 6))

                Return Tokens(0) & " " & Tokens(1)
            Else
                Return Tokens(0)
            End If
        End Function

        Protected Friend Shared Function TrimText(strText As String) As String
            strText = strText.Replace(vbCrLf, " ").Replace(vbCr, " ").Replace(vbLf, " ")
            strText = Trim(strText.Replace(vbTab, " "))
            Return strText
        End Function
    End Class

    Public Class Regulator
        <XmlAttribute> Public Property Family As String
        <XmlAttribute> Public Property RegulationMode As String
        Public Property BiologicalProcess As String
        Public Property Effector As String
        Public Property Regulog As KeyValuePair

        Public Property TFBSs As FastaObject()

        ''' <summary>
        ''' 获取一个唯一的物种的编号 {Regulog, {Locus_tag, Locus_tag()}}
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUniqueId() As KeyValuePair(Of String, KeyValuePair(Of String, String())())
            Dim Species = (From obj As FastaObject In TFBSs Select obj.Bacteria Distinct).ToArray
            Dim IdList As KeyValuePair(Of String, String())() = (From sp In Species Let Collection As String() = [Select](sp) Select New KeyValuePair(Of String, String())(Collection.First, Collection)).ToArray

            Return New KeyValuePair(Of String, KeyValuePair(Of String, String())())(Regulog.Key, IdList)
        End Function

        ''' <summary>
        ''' 根据物种编号筛选出基因号
        ''' </summary>
        ''' <param name="SpeciesId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function [Select](SpeciesId As String) As String()
            Dim LQuery = (From rec In TFBSs Where String.Equals(rec.Bacteria, SpeciesId) Select rec.LocusTag).ToArray
            Return LQuery
        End Function

        Public Function ExportMotifs() As FastaToken()
            Dim LQuery = (From FastaObject As FastaObject
                          In TFBSs
                          Select New FastaToken With {
                              .SequenceData = SequenceTrimming(FastaObject),
                              .Attributes = New String() {String.Format("[gene={0}] [family={1}] [regulog={2}]", FastaObject.LocusTag, Family, Regulog.Key)}}).ToArray
            Return LQuery
        End Function

        Public Shared Function SequenceTrimming(FastaObject As WebServices.FastaObject) As String
            Return SequenceTrimming(FastaObject.SequenceData.Replace("-", "N"))
        End Function

        Public Shared Function SequenceTrimming(Sequence As String) As String
            Dim Tokens = (From mh As Match In Regex.Matches(Sequence, ".\(\d+\)", RegexOptions.Singleline) Select mh.Value).ToArray
            Dim sBuilder As StringBuilder = New StringBuilder(Sequence)
            For Each Token As String In Tokens
                Dim strTemp As String = New String(Token.First, Convert.ToInt32(Regex.Match(Token, "\d+").Value))
                Call VBDebugger.Warning($"  {Token}   --> {strTemp}")
                Call sBuilder.Replace(Token, strTemp)
            Next

            Return sBuilder.ToString
        End Function

        Public Shared Function Parse(url As String) As Regulator
            Dim pageContent As String = url.GET
            Dim ExportDownloadUrl As String = Regex.Match(pageContent, "<a href=""[^>]+?""><b>DOWNLOAD</b></a>", RegexOptions.Singleline).Value
            ExportDownloadUrl = Regex.Match(ExportDownloadUrl, "href="".+?""", RegexOptions.IgnoreCase).Value
            ExportDownloadUrl = "http://regprecise.lbl.gov/RegPrecise/" & Mid(ExportDownloadUrl, 7, Len(ExportDownloadUrl) - 7)

            Dim Regulator As Regulator = New Regulator
            Regulator.TFBSs = FastaObject.Parse(ExportDownloadUrl)
            pageContent = Mid(pageContent, InStr(pageContent, "<caption class=""tbl_caption"">Properties</caption>", CompareMethod.Text) + 50)
            pageContent = Regex.Matches(pageContent, "<tbody>.+?</tbody>", RegexOptions.Singleline + RegexOptions.IgnoreCase).Item(0).Value
            Dim Tokens = (From m As Match In Regex.Matches(pageContent, "<tr>.+?</tr>", RegexOptions.Singleline + RegexOptions.IgnoreCase) Select m.Value).ToArray.Skip(1).ToArray
            Dim p As Integer
            Regulator.Family = Regex.Matches(Tokens(p.MoveNext), "<td.+?</td>", RegexOptions.Singleline + RegexOptions.IgnoreCase).Item(1).Value
            Regulator.RegulationMode = Regex.Matches(Tokens(p.MoveNext), "<td.+?</td>", RegexOptions.Singleline + RegexOptions.IgnoreCase).Item(1).Value
            Regulator.BiologicalProcess = Regex.Matches(Tokens(p.MoveNext), "<td.+?</td>", RegexOptions.Singleline + RegexOptions.IgnoreCase).Item(1).Value
            Regulator.Effector = Regex.Matches(Tokens(p.MoveNext), "<td.+?</td>", RegexOptions.Singleline + RegexOptions.IgnoreCase).Item(1).Value
            Regulator.Regulog = ParseLog(Regex.Matches(Tokens(p.MoveNext), "<td.+?</td>", RegexOptions.Singleline + RegexOptions.IgnoreCase).Item(1).Value)

            Regulator.Family = GetValue(Regulator.Family)
            Regulator.RegulationMode = GetValue(Regulator.RegulationMode)
            Regulator.BiologicalProcess = GetValue(Regulator.BiologicalProcess)
            Regulator.Effector = GetValue(Regulator.Effector)

            Return Regulator
        End Function

        Private Shared Function GetValue(str As String) As String
            str = Mid(str, 5, Len(str) - 9)
            Return str
        End Function

        Private Shared Function ParseLog(str As String) As KeyValuePair
            Dim pair As New KeyValuePair
            pair.Key = Regex.Match(str, ">[^>]+?</a>", RegexOptions.Singleline).Value
            pair.Value = Regex.Match(str, "href="".+?""", RegexOptions.Singleline).Value
            pair.Key = Regulogs.TrimText(Mid(pair.Key, 2, Len(pair.Key) - 5))
            pair.Value = "http://regprecise.lbl.gov/RegPrecise/" & Mid(pair.Value, 7, Len(pair.Value) - 7)

            Return pair
        End Function
    End Class

    Public Class FastaObject
        Implements IReadOnlyId
        Implements I_PolymerSequenceModel
        Implements I_FastaProvider

        <XmlAttribute> Public Property LocusTag As String
        <XmlAttribute> Public Property Name As String
        <XmlAttribute> Public Property Position As Integer
        <XmlAttribute> Public Property Score As Double

        <XmlElement("Sequence")>
        Public Property SequenceData As String Implements I_PolymerSequenceModel.SequenceData
        Public Property Bacteria As String

        Public ReadOnly Property UniqueId As String Implements IReadOnlyId.Identity
            Get
                Return String.Format("{0}:{1}", LocusTag, Position)
            End Get
        End Property

        Public ReadOnly Property Title As String Implements I_FastaProvider.Title
            Get
                Return $"{UniqueId} {Bacteria}"
            End Get
        End Property

        Protected ReadOnly Property Attributes As String() Implements I_FastaProvider.Attributes
            Get
                Return {UniqueId, Bacteria}
            End Get
        End Property

        Public Shared Function Parse(url As String) As FastaObject()
            Dim Text As String = url.GET
            Dim FASTA As LANS.SystemsBiology.SequenceModel.FASTA.FastaFile =
                LANS.SystemsBiology.SequenceModel.FASTA.FastaFile.ParseDocument(doc:=Text)
            Dim LQuery = (From fsa As FastaToken In FASTA Select FastaObject.[New](fsa)).ToArray
            Return LQuery
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(">{0} : {1}", LocusTag, SequenceData)
        End Function

        Const REAL As String = "-?\d+(\.\d+)?"

        Protected Friend Shared Function [New](DownloadedFastaObject As LANS.SystemsBiology.SequenceModel.FASTA.FastaToken) As FastaObject
            Dim Title As String = DownloadedFastaObject.Title
            Dim FastaObject As FastaObject = New FastaObject
            Dim Score As String = Regex.Match(Title, "Score=" & REAL, RegexOptions.IgnoreCase).Value
            Dim Position As String = Regex.Match(Title, "Pos=" & REAL, RegexOptions.IgnoreCase).Value
            Dim Bacateria As String = Regex.Match(Title, "\[.+\]").Value

            FastaObject.SequenceData = DownloadedFastaObject.SequenceData
            FastaObject.Bacteria = Bacateria
            FastaObject.Bacteria = Mid(FastaObject.Bacteria, 2, Len(FastaObject.Bacteria) - 2)
            FastaObject.Position = Val(Position.Split(CChar("=")).Last)
            FastaObject.Score = Val(Score.Split(CChar("=")).Last)

            Dim LocusTag As String = Title.Replace(Score, "").Replace(Position, "").Replace(Bacateria, "").Trim
            FastaObject.Name = Regex.Match(LocusTag, "\(.+?\)").Value
            FastaObject.Name = If(Not String.IsNullOrEmpty(FastaObject.Name), Mid(FastaObject.Name, 2, Len(FastaObject.Name) - 2).Trim, "")
            LocusTag = Regex.Replace(LocusTag, "\(.+?\)", "")
            FastaObject.LocusTag = LocusTag.Replace(">", "").Trim

            Return FastaObject
        End Function
    End Class
End Namespace