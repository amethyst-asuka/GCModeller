﻿#Region "Microsoft.VisualBasic::f1af8257b799886ca41856cd99b05383, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Extensions\Collection\KeyValuePair.vb"

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

Imports System.Collections.Specialized
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq

''' <summary>
''' KeyValue pair data related extensions API.
''' </summary>
Public Module KeyValuePairExtensions

    <Extension>
    Public Iterator Function EnumerateTuples(Of T)(table As Dictionary(Of String, T)) As IEnumerable(Of (name As String, obj As T))
        For Each entry In table
            Yield (entry.Key, entry.Value)
        Next
    End Function

    <Extension> Public Function AsNamedVector(Of T)(groups As IEnumerable(Of IGrouping(Of String, T))) As IEnumerable(Of NamedCollection(Of T))
        Return groups.Select(Function(group)
                                 Return New NamedCollection(Of T) With {
                                    .Name = group.Key,
                                    .Value = group.ToArray
                                 }
                             End Function)
    End Function

    <Extension>
    Public Function AsGroups(Of T)(table As Dictionary(Of String, T())) As IEnumerable(Of NamedCollection(Of T))
        Return table.Select(Function(item)
                                Return New NamedCollection(Of T) With {
                                    .Name = item.Key,
                                    .Value = item.Value
                                }
                            End Function)
    End Function

    <Extension>
    Public Function IGrouping(Of T)(source As IEnumerable(Of NamedCollection(Of T))) As IEnumerable(Of IGrouping(Of String, T))
        Return source.Select(Function(x) DirectCast(x, IGrouping(Of String, T)))
    End Function

    ''' <summary>
    ''' Removes the target key in the dictionary table, and then gets the removed value.
    ''' (删除字典之中的指定的键值对，然后返回被删除的数据值)
    ''' </summary>
    ''' <typeparam name="K"></typeparam>
    ''' <typeparam name="V"></typeparam>
    ''' <param name="table"></param>
    ''' <param name="key"></param>
    ''' <returns>The value of the removed <paramref name="key"/></returns>
    <Extension>
    Public Function RemoveAndGet(Of K, V)(table As Dictionary(Of K, V), key As K) As V
        Dim item As V = table(key)
        Call table.Remove(key)
        Return item
    End Function

    ''' <summary>
    ''' Iterates all of the values in the <paramref name="source"/> collection data.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <returns></returns>
    <Extension>
    Public Function IteratesAll(Of T As INamedValue)(source As IEnumerable(Of NamedCollection(Of T))) As T()
        Return source.Select(Function(c) c.Value).IteratesALL.ToArray
    End Function

    ''' <summary>
    ''' Groups source by <see cref="INamedValue.Key"/>
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <returns></returns>
    <Extension>
    Public Function GroupByKey(Of T As INamedValue)(source As IEnumerable(Of T)) As NamedCollection(Of T)()
        Return source _
            .GroupBy(Function(o) o.Key) _
            .ToArray(Function(g)
                         Return New NamedCollection(Of T) With {
                             .Name = g.Key,
                             .Value = g.ToArray
                         }
                     End Function)
    End Function

    ''' <summary>
    ''' Retrieve all items' value data.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <returns></returns>
    <Extension>
    Public Function Values(Of T)(source As IEnumerable(Of NamedValue(Of T))) As T()
        Return source _
            .Select(Function(x) x.Value) _
            .ToArray
    End Function

    '<Extension>
    'Public Function Values(Of T, V As Value(Of T).IValueOf)(source As IEnumerable(Of V)) As T()
    '    Return source _
    '        .Select(Function(x) x.value) _
    '        .ToArray
    'End Function

    ''' <summary>
    ''' gets all <see cref="INamedValue.Key"/> values
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="distinct"></param>
    ''' <returns></returns>
    <Extension>
    Public Function Keys(Of T As INamedValue)(source As IEnumerable(Of T), Optional distinct As Boolean = False) As List(Of String)
        Dim list As IEnumerable(Of String) = source.Select(Function(o) o.Key)
        If distinct Then
            list = list.Distinct
        End If
        Return list.AsList
    End Function

    <Extension>
    Public Function Keys(Of K, V)(source As IEnumerable(Of IGrouping(Of K, V))) As K()
        Return source _
            .Select(Function(x) x.Key) _
            .ToArray
    End Function

    ''' <summary>
    ''' Dictionary object contains the specific <see cref="NamedValue(Of T).Name"/>?
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="table"></param>
    ''' <param name="k"></param>
    ''' <returns></returns>
    <Extension>
    Public Function ContainsKey(Of T As INamedValue)(table As Dictionary(Of T), k As NamedValue(Of T)) As Boolean
        Return table.ContainsKey(k.Name)
    End Function

    ''' <summary>
    ''' Dictionary object contains the specific <see cref="NamedValue(Of T).Name"/>?
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="table"></param>
    ''' <param name="k"></param>
    ''' <returns></returns>
    <Extension>
    Public Function ContainsKey(Of T)(table As Dictionary(Of String, T), k As NamedValue(Of T)) As Boolean
        Return table.ContainsKey(k.Name)
    End Function

    ''' <summary>
    ''' Converts the interface object into a Dictionary object.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <typeparam name="V"></typeparam>
    ''' <param name="source"></param>
    ''' <returns></returns>
    <Extension>
    Public Function DictionaryData(Of T, V)(source As IReadOnlyDictionary(Of T, V)) As Dictionary(Of T, V)
        Return source.ToDictionary(Function(x) x.Key, Function(x) x.Value)
    End Function

    ''' <summary>
    ''' Creates the dictionary for string converts to enum value.
    ''' (接受的泛型类型必须是枚举类型)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="lcaseKey"></param>
    ''' <param name="usingDescription"></param>
    ''' <returns></returns>
    Public Function EnumParser(Of T As Structure)(Optional lcaseKey As Boolean = True, Optional usingDescription As Boolean = False) As Dictionary(Of String, T)
        Dim values As [Enum]() = Enums(Of T)().ToArray(Function(e) DirectCast(CType(e, Object), [Enum]))
        Dim [case] = If(lcaseKey, Function(key$) LCase(key), Function(key$) key)

        If usingDescription Then
            Return values.ToDictionary(
                Function(e) [case](key:=e.Description),
                Function(e) DirectCast(CType(e, Object), T))
        Else
            Return values.ToDictionary(
                Function(e) [case](key:=e.ToString),
                Function(e) DirectCast(CType(e, Object), T))
        End If
    End Function

    <Extension>
    Public Function NamedValues(maps As IEnumerable(Of IDMap)) As NamedValue(Of String)()
        Return maps _
            .Select(Function(m) New NamedValue(Of String)(m.Key, m.Maps)) _
            .ToArray
    End Function

    ''' <summary>
    ''' 将目标字典之中的键值对转换为被命名为的变量值
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="table"></param>
    ''' <returns></returns>
    <Extension>
    Public Function NamedValues(Of T)(table As Dictionary(Of String, T)) As NamedValue(Of T)()
        Return table _
            .Select(Function(k)
                        Return New NamedValue(Of T) With {
                            .Name = k.Key,
                            .Value = k.Value
                        }
                    End Function) _
            .ToArray
    End Function

    <Extension>
    Public Function NameValueCollection(maps As IEnumerable(Of IDMap)) As NameValueCollection
        Dim nc As New NameValueCollection

        For Each m As IDMap In maps
            Call nc.Add(m.Key, m.Maps)
        Next

        Return nc
    End Function

    ''' <summary>
    ''' 获取得到的集合对象是一个安全的集合对象，不存在的键名会直接返回空值
    ''' </summary>
    ''' <param name="maps"></param>
    ''' <returns></returns>
    <Extension>
    Public Function NameValueCollection(maps As IEnumerable(Of NamedValue(Of String))) As NameValueCollection
        Dim nc As New NameValueCollection

        For Each m As NamedValue(Of String) In maps
            Call nc.Add(m.Name, m.Value)
        Next

        Return nc
    End Function

    <Extension> Public Sub SortByValue(Of V, T)(ByRef table As Dictionary(Of V, T), Optional desc As Boolean = False)
        Dim orders As KeyValuePair(Of V, T)()
        Dim out As New Dictionary(Of V, T)

        If Not desc Then
            orders = table.OrderBy(Function(p) p.Value).ToArray
        Else
            orders = table _
                .OrderByDescending(Function(p) p.Value) _
                .ToArray
        End If

        For Each k As KeyValuePair(Of V, T) In orders
            Call out.Add(k.Key, k.Value)
        Next

        table = out
    End Sub

    ''' <summary>
    ''' 按照键名对字典进行重新排序
    ''' </summary>
    ''' <typeparam name="V"></typeparam>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="table"></param>
    ''' <param name="desc">默认为从小到大的升序排序</param>
    <Extension> Public Sub SortByKey(Of V, T)(ByRef table As Dictionary(Of V, T), Optional desc As Boolean = False)
        Dim orders As V()
        Dim out As New Dictionary(Of V, T)

        If Not desc Then
            orders = table.Keys.OrderBy(Function(k) k).ToArray
        Else
            orders = table.Keys _
                .OrderByDescending(Function(k) k) _
                .ToArray
        End If

        For Each k As V In orders
            Call out.Add(k, table(k))
        Next

        table = out
    End Sub

    ''' <summary>
    ''' Determines whether the <see cref="NameValueCollection"/> contains the specified key.
    ''' </summary>
    ''' <param name="d"></param>
    ''' <param name="key$">The key to locate in the <see cref="NameValueCollection"/></param>
    ''' <returns>true if the System.Collections.Generic.Dictionary`2 contains an element with
    ''' the specified key; otherwise, false.</returns>
    <Extension>
    Public Function ContainsKey(d As NameValueCollection, key$) As Boolean
        Return Not String.IsNullOrEmpty(d(key))
    End Function

    <Extension>
    Public Function Join(Of T, V)(d As Dictionary(Of T, V), name As T, value As V) As Dictionary(Of T, V)
        d(name) = value
        Return d
    End Function

    ''' <summary>
    ''' 请注意，这里的类型约束只允许枚举类型
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <returns></returns>
    Public Function ParserDictionary(Of T As Structure)() As Dictionary(Of String, T)
        Return Enums(Of T).ToDictionary(Function(x) DirectCast(CType(x, Object), [Enum]).Description)
    End Function

    ''' <summary>
    ''' Data exists and not nothing
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="d"></param>
    ''' <param name="key"></param>
    ''' <returns></returns>
    <Extension>
    Public Function HaveData(Of T)(d As Dictionary(Of T, String), key As T) As Boolean
        Return d.ContainsKey(key) AndAlso Not String.IsNullOrEmpty(d(key))
    End Function

    <Extension>
    Public Function ToDictionary(nc As NameValueCollection) As Dictionary(Of String, String)
        Dim hash As New Dictionary(Of String, String)

        For Each key As String In nc.AllKeys
            hash(key) = nc(key)
        Next

        Return hash
    End Function

    Const sourceEmpty$ = "Source is nothing, returns empty dictionary table!"

    ''' <summary>
    ''' Creates a <see cref="System.Collections.Generic.Dictionary"/>`2 from an <see cref="System.Collections.Generic.IEnumerable"/>`1
    ''' according to a specified key selector function.
    ''' </summary>
    ''' <typeparam name="T">Unique identifier provider <see cref="INamedValue.Key"/></typeparam>
    ''' <param name="source"></param>
    ''' <returns></returns>
    <Extension>
    Public Function ToDictionary(Of T As INamedValue)(source As IEnumerable(Of T)) As Dictionary(Of T)
        If source Is Nothing Then
            Call sourceEmpty.Warning
            Return New Dictionary(Of T)
        End If

        Dim i As Integer = 0

        Try
            With New Dictionary(Of T)
                For Each item As T In source
                    Call .Add(item.Key, item)
                    i += 1
                Next

                Return .ref
            End With
        Catch ex As Exception
            ex = New Exception("key --> [ " & source(i).Key & " ]", ex)
            Throw ex
        End Try
    End Function

    <Extension> Public Function Add(Of TKey, TValue)(ByRef list As List(Of KeyValuePair(Of TKey, TValue)), key As TKey, value As TValue) As List(Of KeyValuePair(Of TKey, TValue))
        If list Is Nothing Then
            list = New List(Of KeyValuePair(Of TKey, TValue))
        End If
        list += New KeyValuePair(Of TKey, TValue)(key, value)
        Return list
    End Function

    ''' <summary>
    ''' Adds an object to the end of the List`1.
    ''' </summary>
    ''' <typeparam name="TKey"></typeparam>
    ''' <typeparam name="TValue"></typeparam>
    ''' <param name="list"></param>
    ''' <param name="key"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    <Extension> Public Function Add(Of TKey, TValue)(ByRef list As List(Of KeyValuePairObject(Of TKey, TValue)), key As TKey, value As TValue) As List(Of KeyValuePairObject(Of TKey, TValue))
        If list Is Nothing Then
            list = New List(Of KeyValuePairObject(Of TKey, TValue))
        End If
        list += New KeyValuePairObject(Of TKey, TValue)(key, value)
        Return list
    End Function

    ''' <summary>
    ''' 使用这个函数应该要确保value是没有重复的
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <typeparam name="V"></typeparam>
    ''' <param name="d"></param>
    ''' <returns></returns>
    <Extension>
    Public Function ReverseMaps(Of T, V)(d As Dictionary(Of T, V), Optional removeDuplicated As Boolean = False) As Dictionary(Of V, T)
        If removeDuplicated Then
            Dim groupsData = From x In d Select x Group x By x.Value Into Group
            Return groupsData.ToDictionary(
                Function(g) g.Value,
                Function(g) g.Group.First.Key)
        Else
            Return d.ToDictionary(
                Function(x) x.Value,
                Function(x) x.Key)
        End If
    End Function

    ''' <summary>
    ''' 一次性地使用一个键名的集合从字典之中选出一组数据
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <typeparam name="V"></typeparam>
    ''' <param name="d"></param>
    ''' <param name="keys"></param>
    ''' <param name="skipNonExist"></param>
    ''' <returns></returns>
    <Extension>
    Public Function Selects(Of T, V)(d As Dictionary(Of T, V), keys As IEnumerable(Of T), Optional skipNonExist As Boolean = False) As V()
        If skipNonExist Then
            Return keys _
                .Where(AddressOf d.ContainsKey) _
                .Select(Function(k) d(k)) _
                .ToArray
        Else
            Return keys.Select(Function(k) d(k)).ToArray
        End If
    End Function
End Module
