﻿#Region "Microsoft.VisualBasic::dec9d142413ddeb29546d6dc10958862, ..\sciBASIC#\Data\DataFrame\IO\Generic\Extensions.vb"

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

Imports System.Runtime.CompilerServices

Namespace IO

    Public Module Extensions

        ''' <summary>
        ''' 使用这个函数请确保相同编号的对象集合之中是没有相同的属性名称的，
        ''' 但是假若会存在重复的名称的话，这些重复的名称的值会被<see cref="JoinBy"/>操作，分隔符为``分号``
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        <Extension>
        Public Function DataFrame(data As IEnumerable(Of IPropertyValue)) As EntityObject()
            Dim objects = data.GroupBy(Function(k) k.Key).ToArray
            Dim out As EntityObject() = objects _
                .Select(AddressOf CreateObject) _
                .ToArray
            Return out
        End Function

        <Extension>
        Public Function CreateObject(g As IGrouping(Of String, IPropertyValue)) As EntityObject
            Dim data As IPropertyValue() = g.ToArray
            Dim props As Dictionary(Of String, String) = data _
                .GroupBy(Function(p) p.Property) _
                .ToDictionary(Function(k) k.Key,
                              Function(v) v.Select(
                              Function(s) s.value).JoinBy("; "))

            Return New EntityObject With {
                .ID = g.Key,
                .Properties = props
            }
        End Function

        ''' <summary>
        ''' 批量的从目标对象集合之中选出目标属性值
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="key$"></param>
        ''' <returns></returns>
        <Extension>
        Public Function Values(data As IEnumerable(Of EntityObject), key$) As String()
            Return data.Select(Function(r) r(key$)).ToArray
        End Function
    End Module
End Namespace
