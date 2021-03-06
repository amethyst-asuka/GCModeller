﻿#Region "Microsoft.VisualBasic::5f2f73cc3838cd9fa4fb4be003c64cc9, ..\localblast\LocalBLAST\LocalBLAST\LocalBLAST\Application\BBH\BiDirectionalBesthit.vb"

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

Imports Microsoft.VisualBasic.ComponentModel.KeyValuePair
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH.Abstract

Namespace LocalBLAST.Application.BBH

    ''' <summary>
    ''' Best hit result from the binary direction blastp result.(最佳双向比对结果，BBH，直系同源)
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BiDirectionalBesthit : Inherits I_BlastQueryHit
        Implements IKeyValuePair, IQueryHits

        ''' <summary>
        ''' Annotiation for protein <see cref="BiDirectionalBesthit.QueryName"></see>
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Description As String
        ''' <summary>
        ''' COG annotiation for protein <see cref="BiDirectionalBesthit.QueryName"></see>
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property COG As String
        ''' <summary>
        ''' Protein length annotiation for protein <see cref="BiDirectionalBesthit.QueryName"></see>.(本蛋白质实体对象的序列长度)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Length As String
        Public Property Identities As Double Implements IQueryHits.identities
        Public Property Positive As Double

        Public Shared ReadOnly Property NullValue As BiDirectionalBesthit
            Get
                Return New BiDirectionalBesthit
            End Get
        End Property

        ''' <summary>
        '''
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return String.Format("{0} <==> {1}", QueryName, HitName)
        End Function

        Public Function ShadowCopy(Of T As BiDirectionalBesthit)() As T
            Dim data As T = Activator.CreateInstance(Of T)()
            data.QueryName = QueryName
            data.HitName = HitName
            data.COG = COG
            data.Description = Description
            data.Length = Length

            Return data
        End Function

        ''' <summary>
        ''' Get gene function description from the specific locus_tag
        ''' </summary>
        ''' <param name="locusId"></param>
        ''' <returns></returns>
        Public Delegate Function GetDescriptionHandle(locusId As String) As String

        Public Shared Function MatchDescription(data As BiDirectionalBesthit(), sourceDescription As GetDescriptionHandle) As BiDirectionalBesthit()
            Dim setValue = New SetValue(Of BiDirectionalBesthit) <= NameOf(BiDirectionalBesthit.Description)
            Dim LQuery As BiDirectionalBesthit() =
                LinqAPI.Exec(Of BiDirectionalBesthit) <= From bbh As BiDirectionalBesthit
                                                         In data.AsParallel
                                                         Let desc As String = sourceDescription(locusId:=bbh.QueryName)
                                                         Select setValue(bbh, desc)
            Return LQuery
        End Function
    End Class
End Namespace
