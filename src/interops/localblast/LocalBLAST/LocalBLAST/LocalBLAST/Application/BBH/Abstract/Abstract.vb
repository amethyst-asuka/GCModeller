﻿#Region "Microsoft.VisualBasic::d7865cf369c249c1b7619148419c23ac, ..\localblast\LocalBLAST\LocalBLAST\LocalBLAST\Application\BBH\Abstract\Abstract.vb"

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

Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.KeyValuePair
Imports Microsoft.VisualBasic.ComponentModel.Map(Of String, String)
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.BLASTOutput

Namespace LocalBLAST.Application.BBH.Abstract

    Public Interface IBlastHit
        Property locusId As String
        Property Address As String
    End Interface

    Public Interface IQueryHits : Inherits IBlastHit
        Property identities As Double
    End Interface

    ''' <summary>
    ''' <see cref="I_BlastQueryHit.QueryName"></see> and <see cref="I_BlastQueryHit.HitName"></see>
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class I_BlastQueryHit : Implements IKeyValuePair
        Implements IBlastHit
        Implements IMap

        ''' <summary>
        ''' The query source.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Column("query_name")> Public Overridable Property QueryName As String _
            Implements IKeyValuePairObject(Of String, String).Key,
                       IBlastHit.locusId,
                       IMap.Key
        ''' <summary>
        ''' The subject hit.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Column("hit_name")> Public Overridable Property HitName As String _
            Implements IKeyValuePairObject(Of String, String).Value,
                       IBlastHit.Address,
                       IMap.Maps

        ''' <summary>
        ''' 仅仅是依靠对HitName的判断来使用这个属性了解<see cref="QueryName"></see>是否已经和<see cref="HitName"></see>比对上了
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ignored> Public ReadOnly Property Matched As Boolean
            Get
                If String.IsNullOrEmpty(QueryName) OrElse
                    String.Equals(QueryName, IBlastOutput.HITS_NOT_FOUND) Then
                    Return False
                End If
                Return Not String.IsNullOrEmpty(HitName) AndAlso
                    Not String.Equals(HitName, IBlastOutput.HITS_NOT_FOUND)
            End Get
        End Property

        <Ignored> Public ReadOnly Property SelfHit As Boolean
            Get
                Return String.Equals(QueryName, HitName, StringComparison.OrdinalIgnoreCase)
            End Get
        End Property

        Public Const BBH_ID_SEPERATOR As String = "+++++++++"

        ''' <summary>
        ''' 会忽略掉基因号ID的先后顺序的，重新按照字符先后进行排序
        ''' </summary>
        ''' <returns></returns>
        <Ignored> Public ReadOnly Property BBH_ID As String
            Get
                Dim asc As String() = LinqAPI.Exec(Of String) <=
 _
                    From s As String
                    In {Me.QueryName, Me.HitName}
                    Select str = s.ToUpper
                    Order By str Ascending

                Return String.Join(BBH_ID_SEPERATOR, asc)
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return MyClass.GetJson
        End Function
    End Class
End Namespace

