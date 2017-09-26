﻿#Region "Microsoft.VisualBasic::b4f776f881dc1264eaabe4d92b1feee4, ..\sciBASIC#\Data\DataFrame\Extensions\Extensions.vb"

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

Imports System.Data.Common
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Data.csv.IO.Linq
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.ComponentModels
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Scripting
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Text

''' <summary>
''' The shortcuts operation for the common csv document operations.
''' </summary>
''' <remarks></remarks>
'''
<Package("IO_Device.Csv.Extensions",
                  Description:="The shortcuts operation for the common csv document operations.",
                  Publisher:="xie.guigang@gmail.com")>
Public Module Extensions

    Sub New()
        Call __initStreamIO_pointer()
    End Sub

    ''' <summary>
    ''' Anonymous type data reader helper.(System.MissingMethodException occurred
    '''  HResult=0x80131513
    '''  Message=No parameterless constructor defined for this object.
    '''  Source=mscorlib
    '''  StackTrace:
    '''   at System.RuntimeTypeHandle.CreateInstance(RuntimeType type, Boolean publicOnly, Boolean noCheck, Boolean&amp; canBeCached, RuntimeMethodHandleInternal&amp; ctor, Boolean&amp; bNeedSecurityCheck)
    '''   at System.RuntimeType.CreateInstanceSlow(Boolean publicOnly, Boolean skipCheckThis, Boolean fillCache, StackCrawlMark&amp; stackMark)
    '''   at System.Activator.CreateInstance(Type type, Boolean nonPublic)
    '''   at System.Activator.CreateInstance(Type type)
    '''   at Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection.Reflector._Closure$__1-0._Lambda$__0(SeqValue`1 line) In G:\GCModeller\src\runtime\sciBASIC#\Data\DataFrame\StorageProvider\Reflection\StorageProviders\Reflection.vb:line 96
    '''   at System.Linq.Parallel.SelectQueryOperator`2.SelectQueryOperatorEnumerator`1.MoveNext(TOutput&amp; currentElement, TKey&amp; currentKey)
    '''   at System.Linq.Parallel.PipelineSpoolingTask`2.SpoolingWork()
    '''   at System.Linq.Parallel.SpoolingTaskBase.Work()
    ''')对于匿名类型，这个方法还无法正常工作
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="path$"></param>
    ''' <param name="template"></param>
    ''' <param name="encoding"></param>
    ''' <returns></returns>
    <Extension>
    Public Function LoadCsv(Of T As Class)(path$, template As T, Optional encoding As Encodings = Encodings.UTF8) As T()
        Return path.LoadCsv(Of T)(encoding:=encoding.CodePage).ToArray
    End Function

    ''' <summary>
    ''' Save all of the <see cref="Dictionary(Of T).Values"/> into a csv file.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="table"></param>
    ''' <param name="path$"></param>
    ''' <param name="encoding"></param>
    ''' <returns></returns>
    <Extension>
    Public Function SaveTo(Of T As INamedValue)(table As Dictionary(Of T), path$, Optional encoding As Encodings = Encodings.UTF8) As Boolean
        Return table.Values.SaveTo(path, encoding)
    End Function

    ''' <summary>
    ''' Save variable value vector as data frame
    ''' </summary>
    ''' <param name="samples"></param>
    ''' <param name="path$"></param>
    ''' <param name="encoding"></param>
    ''' <param name="xlabels#"></param>
    ''' <returns></returns>
    <Extension>
    Public Function SaveTo(samples As IEnumerable(Of NamedValue(Of Double())),
                           path$,
                           Optional encoding As Encodings = Encodings.ASCII,
                           Optional xlabels#() = Nothing) As Boolean
        Dim out As New IO.File
        Dim data As NamedValue(Of Double())() = samples.ToArray

        If xlabels.IsNullOrEmpty Then
            out += New RowObject(data.Select(Function(s) s.Name))

            For i As Integer = 0 To data(Scan0).Value.Length - 1
                Dim row As New RowObject

                For Each sample In data
                    row.Add(CStr(sample.Value(i)))
                Next

                out += row
            Next
        Else
            out += New RowObject("X".Join(data.Select(Function(s) s.Name)))

            For i As Integer = 0 To data(Scan0).Value.Length - 1
                Dim row As New RowObject From {
                    CStr(xlabels(i))
                }
                For Each sample As NamedValue(Of Double()) In data
                    Call row.Add(CStr(sample.Value(i)))
                Next

                out += row
            Next
        End If

        Return out.Save(path, encoding)
    End Function

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="path">Csv file path</param>
    ''' <returns></returns>
    Public Function GetLocusMapName(path As String) As String
        Dim first As String = path.ReadFirstLine
        Dim tokens = IO.CharsParser(first)
        Return tokens.FirstOrDefault
    End Function

    <Extension>
    Public Function TabExport(Of T As Class)(source As IEnumerable(Of T), saveTo As String, Optional noTitle As Boolean = False, Optional encoding As Encodings = Encodings.UTF8) As Boolean
        Dim doc As IO.File = StorageProvider.Reflection.Reflector.Save(source, False)
        Dim lines As RowObject() = If(noTitle, doc.Skip(1).ToArray, doc.ToArray)
        Dim slines As String() = lines.ToArray(Function(x) x.AsLine(vbTab))
        Dim sdoc As String = String.Join(vbCrLf, slines)
        Return sdoc.SaveTo(saveTo, encoding.CodePage)
    End Function

    <Extension> Public Sub ForEach(Of T As Class)(path As String, invoke As Action(Of T))
        Call DataStream.OpenHandle(path).ForEach(Of T)(invoke)
    End Sub

    ''' <summary>
    ''' As query source for the LINQ or PLINQ, this function is much save time for the large data set query!
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="path"></param>
    ''' <returns></returns>
    <Extension> Public Function AsLinq(Of T As Class)(path$, Optional parallel As Boolean = False) As IEnumerable(Of T)
        Return DataStream.OpenHandle(path).AsLinq(Of T)(parallel)
    End Function

    ''' <summary>
    ''' Convert a database table into a dynamics dataframe in VisualBasic.(将数据库之中所读取出来的数据表转换为表格对象)
    ''' </summary>
    ''' <param name="reader"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''
    <ExportAPI(NameOf(DataFrame),
               Info:="Convert a database table into a dynamics dataframe in VisualBasic.")>
    <Extension> Public Function DataFrame(reader As DbDataReader) As DataFrame
        Dim csv As New IO.File
        Dim fields As Integer() = reader.FieldCount.Sequence.ToArray

        csv += From i As Integer
               In fields
               Select reader.GetName(i)

        Do While reader.Read
            csv += From i As Integer
                   In fields
                   Let val As Object = reader.GetValue(i)
                   Select s = Scripting.ToString(val)
        Loop

        Return DataFrame.CreateObject(csv)
    End Function

    <Extension>
    Public Function DataFrame(source As IEnumerable(Of NamedValue(Of Dictionary(Of String, String)))) As EntityObject()
        Return source.ToArray(
            Function(o)
                Return New EntityObject With {
                    .ID = o.Name,
                    .Properties = o.Value
                }
            End Function)
    End Function

    <ExportAPI("Write.Csv")>
    <Extension> Public Function SaveTo(data As IEnumerable(Of Object), path$, Optional encoding As Encoding = Nothing) As Boolean
        ' 假若序列之中的第一个元素为Nothing的话，则尝试使用第二个元素来获取type信息
        Dim type As Type = (data.First Or [Default](data.SecondOrNull)).GetType

        Return Reflector _
            .__save(___source:=data,
                    typeDef:=type,
                    strict:=False,
                    schemaOut:=Nothing) _
            .SaveDataFrame(path, encoding:=encoding)
    End Function

    <ExportAPI("Write.Csv")>
    <Extension> Public Function SaveTo(data As IEnumerable(Of DynamicObjectLoader), path As String, Optional encoding As Encoding = Nothing) As Boolean
        Dim headers As Dictionary(Of String, Integer) = data.First.Schema
        Dim LQuery = LinqAPI.Exec(Of RowObject) <=
 _
            From x As DynamicObjectLoader
            In data
            Select New RowObject(From p In headers Select x.GetValue(p.Value))

        Dim csv As New IO.File

        Call csv.AppendLine((From p In headers Select p.Key).AsList)
        Call csv.AppendRange(LQuery)

        Return csv.Save(path, encoding)
    End Function

    <ExportAPI("Write.Csv")>
    <Extension> Public Function SaveTo(dat As IEnumerable(Of RowObject), Path As String, Optional encoding As Encoding = Nothing) As Boolean
        Dim Csv As IO.File = CType(dat, IO.File)
        Return Csv.Save(Path, Encoding:=encoding)
    End Function

    <ExportAPI("Row.Parsing")>
    <Extension> Public Function ToCsvRow(data As IEnumerable(Of String)) As RowObject
        Return CType(data.AsList, RowObject)
    End Function

    ''' <summary>
    ''' Create a dynamics data frame object from a csv document object.(从Csv文件之中创建一个数据框容器)
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''
    <ExportAPI(NameOf(DataFrame), Info:="Create a dynamics data frame object from a csv document object.")>
    <Extension> Public Function DataFrame(data As IO.File) As DataFrame
        Return DataFrame.CreateObject(data)
    End Function

    ''' <summary>
    ''' Convert the csv data file to a type specific collection.(将目标Csv文件转换为特定类型的集合数据)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="dataSet"></param>
    ''' <param name="explicit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension> Public Function AsDataSource(Of T As Class)(dataSet As IO.File,
                                                            Optional explicit As Boolean = False,
                                                            Optional maps As Dictionary(Of String, String) = Nothing) As T()
        Dim df As DataFrame = IO.DataFrame.CreateObject(dataSet)
        Return df.AsDataSource(Of T)(explicit, maps)
    End Function

    ''' <summary>
    ''' Convert the csv data file to a type specific collection.(将目标Csv文件转换为特定类型的集合数据)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="df"></param>
    ''' <param name="explicit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension> Public Function AsDataSource(Of T As Class)(df As DataFrame,
                                                            Optional explicit As Boolean = False,
                                                            Optional maps As Dictionary(Of String, String) = Nothing) As T()
        If Not maps Is Nothing Then
            Call df.ChangeMapping(maps)
        End If
        Dim source As T() = Reflector.Convert(Of T)(df, explicit).ToArray
        Return source
    End Function

    ''' <summary>
    '''
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="importsFile">The file path of the text doucment which will be imports as a csv document.</param>
    ''' <param name="Delimiter">The delimiter to parsing a row in the csv document.</param>
    ''' <param name="explicit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension> Public Function AsDataSource(Of T As Class)(importsFile$, Optional delimiter$ = ",", Optional explicit As Boolean = True) As T()
        Dim df As DataFrame = IO.DataFrame.CreateObject([Imports](importsFile, delimiter))
        Dim data As T() = Reflector.Convert(Of T)(df, explicit).ToArray
        Return data
    End Function

    ''' <summary>
    ''' Convert the string collection as the type specific collection, please make sure the first element
    ''' in this collection is stands for the title row.
    ''' (将字符串数组转换为数据源对象，注意：请确保第一行为标题行)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="strDataLines"></param>
    ''' <param name="Delimiter"></param>
    ''' <param name="explicit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension> Public Function AsDataSource(Of T As Class)(strDataLines As IEnumerable(Of String), Optional Delimiter As String = ",", Optional explicit As Boolean = True) As T()
        Dim Expression As String = String.Format(DataImports.SplitRegxExpression, Delimiter)
        Dim LQuery = (From line As String In strDataLines Select RowParsing(line, Expression)).ToArray
        Return CType(LQuery, csv.IO.File).AsDataSource(Of T)(explicit)
    End Function

    ''' <summary>
    ''' Load a csv data file document using a specific object type.(将某一个Csv数据文件加载仅一个特定类型的对象集合中，空文件的话会返回一个空集合，这是一个安全的函数，不会返回空值)
    ''' </summary>
    ''' <typeparam name="T">The type parameter of the element in the returns collection data.</typeparam>
    ''' <param name="path">The csv document file path.(目标Csv数据文件的文件路径)</param>
    ''' <param name="explicit"></param>
    ''' <param name="encoding"></param>
    ''' <param name="maps">``Csv.Field -> <see cref="PropertyInfo.Name"/>``</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension> Public Function LoadCsv(Of T As Class)(path$,
                                                       Optional explicit As Boolean = False,
                                                       Optional encoding As Encoding = Nothing,
                                                       Optional fast As Boolean = False,
                                                       Optional maps As Dictionary(Of String, String) = Nothing) As List(Of T)
        Call "Start to load csv data....".__DEBUG_ECHO
        Dim st = Stopwatch.StartNew
        Dim bufs = Reflector.Load(Of T)(path, explicit, encoding, fast, maps)
        Dim ms As Long = st.ElapsedMilliseconds
        Dim fs As String = If(ms > 1000, (ms / 1000) & "sec", ms & "ms")
        Call $"[CSV.Reflector::{GetType(T).FullName}]
Load {bufs.Count} lines of data from ""{path.ToFileURL}""! ...................{fs}".__DEBUG_ECHO
        Return bufs
    End Function

    ''' <summary>
    ''' Load object data set from the text lines stream.(从文本行之中加载数据集)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="explicit"></param>
    ''' <returns></returns>
    <Extension> Public Function LoadStream(Of T As Class)(source As IEnumerable(Of String), Optional explicit As Boolean = True, Optional trimBlanks As Boolean = False) As T()
        Dim dataFrame As IO.File =
            IO.File.Load(source.ToArray, trimBlanks)
        Dim buf As T() = dataFrame.AsDataSource(Of T)(explicit)
        Return buf
    End Function

    ''' <summary>
    ''' Save the object collection data dump into a csv file.(将一个对象数组之中的对象保存至一个Csv文件之中，请注意，这个方法仅仅会保存简单的基本数据类型的属性值)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="path"></param>
    ''' <param name="strict">
    ''' If true then all of the simple data type property its value will be save to the data file,
    ''' if not then only save the property with the <see cref="ColumnAttribute"></see>
    ''' </param>
    ''' <param name="encoding"></param>
    ''' <param name="maps">``{meta_define -> custom}``</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension> Public Function SaveTo(Of T)(source As IEnumerable(Of T),
                                             path$,
                                             Optional strict As Boolean = False,
                                             Optional encoding As Encoding = Nothing,
                                             Optional metaBlank As String = "",
                                             Optional nonParallel As Boolean = False,
                                             Optional maps As Dictionary(Of String, String) = Nothing,
                                             Optional reorderKeys As Integer = 0,
                                             Optional layout As Dictionary(Of String, Integer) = Nothing,
                                             Optional tsv As Boolean = False) As Boolean
        Try
            path = FileIO.FileSystem.GetFileInfo(path).FullName
        Catch ex As Exception
            Throw New Exception("Probably invalid path value: " & path, ex)
        End Try

        Call EchoLine($"[CSV.Reflector::{GetType(T).FullName}]")
        Call EchoLine($"Save data to file:///{path}")
        Call EchoLine($"[CSV.Reflector] Reflector have {source.Count} lines of data to write.")

        Dim csv As IEnumerable(Of RowObject) = Reflector.GetsRowData(
            source.Select(Function(o) DirectCast(o, Object)),
            GetType(T),
            strict,
            maps,
            Not nonParallel,
            metaBlank, reorderKeys, layout)

        Dim success = csv.SaveDataFrame(
            path:=path,
            encoding:=encoding,
            tsv:=tsv)

        If success Then
            Call "CSV saved!".EchoLine
        End If

        Return success
    End Function

    ''' <summary>
    ''' 如果直接使用<see cref="SaveTo"/>函数来保存数据集的话，可能列的顺序是被打乱的，
    ''' 则下次加载的时候<see cref="EntityObject.ID"/>列可能就不是第一列了，会出错，
    ''' 故而需要使用这个专门的函数来进行数据集的保存操作
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="path$"></param>
    ''' <param name="encoding"></param>
    ''' <param name="KeyMap$">将<see cref="EntityObject.ID"/>重命名为这个参数的值，假若这个参数值不是空字符串的话</param>
    ''' <param name="blank$"></param>
    ''' <param name="reorderKeys"></param>
    ''' <returns></returns>
    <Extension>
    Public Function SaveDataSet(Of T As EntityObject)(source As IEnumerable(Of T),
                                                      path$,
                                                      Optional encoding As Encodings = Encodings.ASCII,
                                                      Optional KeyMap$ = Nothing,
                                                      Optional blank$ = "",
                                                      Optional reorderKeys As Integer = 0) As Boolean

        Dim modify As Dictionary(Of String, String) = Nothing
        Dim layout As New Dictionary(Of String, Integer) From {
            {NameOf(EntityObject.ID), -10000}
        }

        If Not KeyMap.StringEmpty Then
            modify = New Dictionary(Of String, String) From {
                {NameOf(EntityObject.ID), KeyMap}
            }
            layout.Clear()
            layout.Add(KeyMap, -10000)
        End If

        Return source.SaveTo(path, , encoding.CodePage, blank,, modify, reorderKeys, layout)
    End Function

    <Extension> Public Function SaveTo(Of T)(source As IEnumerable(Of T),
                                             path As String,
                                             encoding As Encodings,
                                             Optional explicit As Boolean = False) As Boolean
        Return source.SaveTo(path, explicit, encoding.CodePage)
    End Function

    ''' <summary>
    ''' Generate a csv document from a object collection.
    ''' (从一个特定类型的数据集合之中生成一个Csv文件，非并行化的以保持数据原有的顺序)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="explicit">默认导出所有的可用属性</param>
    ''' <param name="metaBlank">对于字典对象之中，空缺下来的域键名的值使用什么来替代？默认使用空白字符串</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension> Public Function ToCsvDoc(Of T)(source As IEnumerable(Of T),
                                               Optional explicit As Boolean = False,
                                               Optional maps As Dictionary(Of String, String) = Nothing,
                                               Optional metaBlank$ = "",
                                               Optional reorderKeys% = 0) As IO.File
        Return Reflector.Save(
            source, explicit,
            maps:=maps,
            metaBlank:=metaBlank,
            reorderKeys:=reorderKeys)
    End Function

    ''' <summary>
    ''' Save the data collection vector as a csv document.
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''
    <ExportAPI("Write.Csv", Info:="Save the data collection vector as a csv document.")>
    <Extension> Public Function SaveTo(data As IEnumerable(Of Double), path$, Optional encoding As Encodings = Encodings.ASCII) As Boolean
        Dim row As IEnumerable(Of String) = From n As Double
                                            In data
                                            Select s =
                                                n.ToString
        Dim buf As New IO.File({New RowObject(row)})
        Return buf.Save(path, encoding.CodePage)
    End Function

    ''' <summary>
    ''' Load the data from the csv document as a double data type vector.
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''
    <ExportAPI("DblVector.LoadCsv", Info:="Load the data from the csv document as a double data type vector. ")>
    <Extension> Public Function LoadDblVector(path As String) As Double()
        Dim buf As IO.File = IO.File.Load(path)
        Dim FirstRow As RowObject = buf.First
        Dim data As Double() = FirstRow.ToArray(AddressOf Val)
        Return data
    End Function

    <Extension> Public Sub Cable(Of T)(Method As LoadObject(Of T))
        Dim type As Type = GetType(T)
        Dim name As String = type.FullName
        Dim helper As New __loadHelper(Of T) With {
            .handle = Method
        }

        Call CapabilityPromise(name, type, AddressOf helper.LoadObject)
    End Sub

    Private Structure __loadHelper(Of T)
        Public handle As LoadObject(Of T)

        Public Function LoadObject(s$) As T
            Return handle(s)
        End Function
    End Structure
End Module
