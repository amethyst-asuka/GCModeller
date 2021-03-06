﻿#Region "Microsoft.VisualBasic::05d006a15e59a0683aa6ae2f3d92610d, ..\core\Bio.Assembly\Assembly\NCBI\Taxonomy\Tree\TaxonomyNode.vb"

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

Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Metagenomics.BIOMTaxonomy

Namespace Assembly.NCBI.Taxonomy

    ''' <summary>
    ''' The tree node calculation model for <see cref="NcbiTaxonomyTree"/>
    ''' </summary>
    Public Class TaxonomyNode

        Public Property taxid As Integer
        Public Property name As String
        Public Property rank As String
        ''' <summary>
        ''' 当前的节点的父节点的编号: ``<see cref="taxid"/>``
        ''' </summary>
        ''' <returns></returns>
        Public Property parent As String
        Public Property children As List(Of Integer)

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function

        ''' <summary>
        ''' 直接处理<see cref="NcbiTaxonomyTree.GetAscendantsWithRanksAndNames(Integer, Boolean)"/>的输出数据，不需要进行额外的排序操作
        ''' </summary>
        ''' <param name="tree"></param>
        ''' <param name="delimiter"></param>
        ''' <returns></returns>
        Public Shared Function Taxonomy(tree As TaxonomyNode(), Optional delimiter As String = ",") As String
            tree = tree.Reverse.ToArray
            Return String.Join(delimiter, tree.ToArray(Function(x) x.name))
        End Function

        Public Shared Function ToHash(tree As IEnumerable(Of TaxonomyNode)) As Dictionary(Of String, String)
            Return (From x As TaxonomyNode
                    In tree
                    Where Not String.IsNullOrEmpty(x.rank)
                    Select x
                    Group x By x.rank Into Group) _
                         .ToDictionary(Function(x) x.rank,
                                       Function(x) x.Group.First.name)
        End Function

        ''' <summary>
        ''' <see cref="BIOMPrefix"/>
        ''' </summary>
        ''' <param name="nodes"></param>
        ''' <returns></returns>
        Public Shared Function BuildBIOM(nodes As IEnumerable(Of TaxonomyNode)) As String
            Dim data As Dictionary(Of String, String) = ToHash(nodes)
            Dim list As New List(Of String)

            For Each r$ In NcbiTaxonomyTree.stdranks.Reverse
                If data.ContainsKey(r) Then
                    list.Add(data(r$))
                Else
                    list.Add("")
                End If
            Next

            SyncLock BIOMPrefix
                Return list _
                    .SeqIterator _
                    .Select(Function(x) BIOMPrefix(x.i) & x.value) _
                    .JoinBy(";")
            End SyncLock
        End Function
    End Class
End Namespace
