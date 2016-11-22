﻿#Region "Microsoft.VisualBasic::3ae0499e8deaca8d2d96f9257387a417, ..\interops\localblast\LocalBLAST\Analysis\Models\Besthit.vb"

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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Assembly.NCBI.GenBank

Namespace Analysis

    ''' <summary>
    ''' 元数据Xml文件
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BestHit

        ''' <summary>
        ''' The species name of query.(进行当前匹配操作的物种名称，这个属性不是蛋白质的名称)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property sp As String
        <XmlElement> Public Property hits As HitCollection()
            Get
                Return __hits
            End Get
            Set(value As HitCollection())
                __hits = value
                If __hits.IsNullOrEmpty Then
                    __protHash = New Dictionary(Of HitCollection)
                Else
                    __protHash = value.ToDictionary
                End If
            End Set
        End Property

        Dim __hits As HitCollection()
        Dim __protHash As Dictionary(Of HitCollection)

        Public Function IndexOf(QueryName As String) As Integer
            Dim LQuery = LinqAPI.DefaultFirst(Of HitCollection) <=
                From hit As HitCollection
                In hits
                Where String.Equals(hit.QueryName, QueryName, StringComparison.OrdinalIgnoreCase)
                Select hit

            If LQuery Is Nothing Then
                Return -1
            Else
                Return Array.IndexOf(hits, LQuery)
            End If
        End Function

        Public Function Take(ParamArray spTags$()) As BestHit
            Return New BestHit With {
                .sp = sp,
                .hits =
                LinqAPI.Exec(Of HitCollection) <= From x As HitCollection
                                                  In hits.AsParallel
                                                  Select x.Take(spTags)
            }
        End Function

        Public Function GetTotalIdentities(sp As String) As Double
            Dim LQuery As Double() = LinqAPI.Exec(Of Double) <=
 _
                From hit As HitCollection
                In hits
                Select From sp_obj As Hit
                       In hit.Hits
                       Where String.Equals(sp, sp_obj.tag, StringComparison.OrdinalIgnoreCase)
                       Select sp_obj.Identities

            If LQuery.IsNullOrEmpty Then
                Return 0
            Else
                Return LQuery.Average
            End If
        End Function

        ''' <summary>
        ''' 从保守的片段数据之中反向取出不保守的片段
        ''' </summary>
        ''' <param name="conserved"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUnConservedRegions(conserved As IReadOnlyList(Of String())) As String()
            Dim index As List(Of String) = conserved.Unlist
            Dim LQuery As String() = LinqAPI.Exec(Of String) <=
 _
                From hit As HitCollection
                In Me.hits
                Where index.IndexOf(hit.QueryName) = -1
                Select hit.QueryName

            Return LQuery
        End Function

        Default Public ReadOnly Property Hit(QueryName As String, HitSpecies As String) As String
            Get
                Dim LQuery As HitCollection = LinqAPI.DefaultFirst(Of HitCollection) <=
                    From hitEntry As HitCollection
                    In hits
                    Where String.Equals(hitEntry.QueryName, QueryName)
                    Select hitEntry

                If LQuery Is Nothing Then
                    Return ""
                Else
                    Dim HitData As String = (From hitEntry As Hit
                                             In LQuery.Hits
                                             Where String.Equals(hitEntry.tag, HitSpecies)
                                             Select hitEntry.HitName).FirstOrDefault
                    Return HitData
                End If
            End Get
        End Property

        ''' <summary>
        ''' 通过query查找的是reference的对象
        ''' </summary>
        ''' <param name="queryName"></param>
        ''' <returns></returns>
        Default Public ReadOnly Property Hit(queryName As String) As HitCollection
            Get
                If __protHash.ContainsKey(queryName) Then
                    Return __protHash(queryName)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("{0};  {1} proteins", sp, hits.Count)
        End Function

        ''' <summary>
        ''' 获取能够被比对上的较多数目的物种的编号
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GetTopHits As String()
            Get
                Dim LQuery = From hitData As HitCollection In hits Select hitData.Hits
                Dim groups = From hitData As Hit
                             In LQuery.IteratesALL
                             Where Not String.IsNullOrEmpty(hitData.HitName)
                             Select hitData
                             Group By hitData.tag Into Group
                Dim source = From bacData
                             In groups
                             Where bacData.Group.Count > 0
                             Select bacData.tag,
                                 n = bacData.Group.Count
                             Order By n Descending
                Dim Id As String() =
                    LinqAPI.Exec(Of String) <= From Tag
                                               In source
                                               Select Tag.tag

                Return Id
            End Get
        End Property

        ''' <summary>
        '''
        ''' </summary>
        ''' <param name="p">0-1</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TrimEmpty(p As Double) As BestHit
            Dim LQuery As IEnumerable(Of Hit) =
                Me.hits.Select(Function(hit) hit.Hits).IteratesALL
            Dim Grouped = (From hit As Hit
                           In LQuery
                           Where Not String.IsNullOrEmpty(hit.HitName)
                           Select hit
                           Group By hit.tag Into Group).ToArray
            Dim Id As String() = (From hit In Grouped
                                  Where hit.Group.Count >= p * (Grouped.Count - 1)
                                  Select hit.tag).ToArray
            Dim setValue = New SetValue(Of HitCollection) <= NameOf(HitCollection.Hits)
            Dim hits As HitCollection() =
                LinqAPI.Exec(Of HitCollection) <= From hit As HitCollection
                                                  In Me.hits
                                                  Let __hits As Hit() = (From x As Hit
                                                                         In hit.Hits
                                                                         Where Array.IndexOf(Id, x.tag) > -1
                                                                         Select x).ToArray
                                                  Select setValue(hit, __hits)
            Me.hits = hits

            Return Me
        End Function

        ''' <summary>
        ''' 根据比对数据自动的推断出保守的区域
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetConservedRegions(Optional p_cutoff As Double = 0.7, Optional Spacer As Integer = 2) As IReadOnlyList(Of String())
            Dim n As Integer = Me.hits.First.Hits.Length
            Dim p_cut As Double = If(n <= 10, p_cutoff, p_cutoff / n)
            Dim LQuery = (From hit As HitCollection
                          In hits
                          Let p = (From nn As Hit
                                   In hit.Hits
                                   Where Not String.IsNullOrEmpty(nn.HitName)
                                   Select 1).Sum / hit.Hits.Length
                          Select hit.QueryName,
                              IsConserved = p >= p_cut,
                              p).ToArray
            Dim buf As List(Of String()) = New List(Of String())
            Dim i As Integer = 0
            Dim tmps As List(Of String) = New List(Of String)

            Dim __cut = Sub(QueryName As String)      '断裂了
                            Call tmps.Add(QueryName)
                            Call buf.Add(tmps.ToArray)
                            Call tmps.Clear()

                            i = 0
                        End Sub

            For Each x In LQuery

                If Not x.IsConserved Then

                    If i = Spacer Then
                        Call __cut(x.QueryName)
                    ElseIf i = 0 Then '这里的情况是连续的空缺断裂
                        Call __cut(x.QueryName)
                    Else
                        Call tmps.Add(x.QueryName)
                        i += 1
                    End If
                Else
                    Call tmps.Add(x.QueryName)
                    i = 0
                End If
            Next

            Dim unConserved As String() = (From x In LQuery Where Not x.IsConserved Select x.QueryName).ToArray
            buf = (From locus As String()
                   In buf
                   Where locus.Count > 1 OrElse
                       (locus.Count = 1 AndAlso Array.IndexOf(unConserved, locus.First) = -1)
                   Select locus).ToList '删除不保守的位点

            Return buf
        End Function

        ''' <summary>
        ''' 将比对上的物种的fasta文件复制到目标文件夹<paramref name="copyTo"></paramref>之中，目标函数返回所复制的菌株的编号列表
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="copyTo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SelectSourceFromHits(source As String, copyTo As String) As String()
            Dim gbEntry As Dictionary(Of NamedValue(Of String)) =
                gbExportService.LoadGbkSource(source)
            Dim LQuery As IEnumerable(Of Hit) =
                hits _
                .Select(Function(hit) hit.Hits) _
                .IteratesALL
            Dim grouped = (From hit As Hit
                           In LQuery
                           Where Not String.IsNullOrEmpty(hit.HitName)
                           Select hit
                           Group By hit.tag Into Group).ToArray

            Dim list = From x In grouped
                       Where x.Group.Count > 0
                       Select x.tag, x.Group.Count

            For Each x In list
                Dim tagId As String = x.tag

                If gbEntry.ContainsKey(tagId) Then
                    Dim path As String = gbEntry(tagId).Value
                    Dim ext As String = FileIO.FileSystem.GetFileInfo(path).Extension
                    Dim cppath As String = copyTo & "/" & tagId & ext

                    Call FileIO.FileSystem.CopyFile(path, cppath, showUI:=FileIO.UIOption.OnlyErrorDialogs, onUserCancel:=FileIO.UICancelOption.ThrowException)
                End If
            Next

            Call list.SaveTo(copyTo & "/Statistics.csv", False)

            Return (From item In list Select item.tag).ToArray
        End Function

        ''' <summary>
        ''' 按照比对的蛋白质的数目的多少对Hit之中的元素进行统一进行排序
        ''' </summary>
        ''' <param name="TrimNull">将没有任何匹配的对象去除</param>
        ''' <remarks></remarks>
        Public Function InternalSort(TrimNull As Boolean) As List(Of HitCollection)
            Dim source = From hit As HitCollection
                         In hits
                         Select From subHit As Hit
                                In hit.Hits
                                Select QueryName = hit.QueryName,
                                    Tag = subHit.tag,
                                    obj = subHit,
                                    IsHit = Not String.IsNullOrEmpty(subHit.HitName)

            Dim SourceLQuery = From query
                               In source.IteratesALL
                               Select query
                               Group By query.Tag Into Group
            Dim OrderByHits = (From x
                               In SourceLQuery
                               Let order = (From nnn In x.Group Where nnn.IsHit Select 1).Count
                               Select dict = x.Group.ToDictionary(
                                   Function(obj) obj.QueryName,
                                   Function(obj) obj.obj),
                                   SpeciesID = x.Tag, order
                               Order By order Descending).ToArray '已经按照比对上的数目排序了

            If TrimNull Then
                OrderByHits = From x
                              In OrderByHits
                              Where x.order > 0
                              Select x
            End If

            Dim list As New List(Of HitCollection)

            For Each hit As HitCollection In Me.hits
                Dim data As Hit() = LinqAPI.Exec(Of Hit) <= From x
                                                            In OrderByHits
                                                            Where x.dict.ContainsKey(hit.QueryName)
                                                            Select x.dict(hit.QueryName)
                list += hit
                hit.Hits = data
            Next

            Return list
        End Function

        ''' <summary>
        ''' 在这里导出Venn表
        '''
        ''' 格式
        ''' [Description] [QueryProtein]  {[] [HitProtein] [Identities] [Positive]}
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>请注意，为了保持数据之间的一一对应关系，这里不能够再使用并行化了</remarks>
        Public Function ExportCsv(TrimNull As Boolean) As DocumentStream.File
            Dim Head As New DocumentStream.RowObject From {"Description", "QueryProtein"}  ' 生成表头
            Dim index As List(Of String) =
                LinqAPI.MakeList(Of String) <=
                    From x As HitCollection
                    In hits
                    Select x.Hits.Select(Function(o) o.tag)   ' 在这里得到所有物种的标签信息

            hits = InternalSort(TrimNull).ToArray
            hits = (From item In hits Select nnn = item Order By nnn.QueryName Ascending).ToArray  '对Query的蛋白质编号进行排序
            index = index.Distinct.ToList

            On Error Resume Next

            For Each name As String In index
                Call Head.Add("")
                Call Head.Add(name)
                Call Head.Add("Identities")
                Call Head.Add("Positive")
            Next

            Dim File As DocumentStream.File = New DocumentStream.File + Head

            For Each Hit As HitCollection In hits
                Dim Row As New DocumentStream.RowObject From {Hit.Description, Hit.QueryName}

                For Each prot As Hit In Hit.Hits
                    Dim i As Integer = index.IndexOf(prot.tag)
                    i = i * 4   ' <space>,name,identities,positive 所占用的位置
                    i += 2   ' Hit.Description, Hit.QueryName 所占用的位置

                    Row(i) = ""
                    Row(i + 1) = prot.HitName
                    Row(i + 2) = prot.Identities
                    Row(i + 3) = prot.Positive
                Next

                File += Row
            Next

            Return File
        End Function
    End Class
End Namespace
