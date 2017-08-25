﻿#Region "Microsoft.VisualBasic::81d2849986e047e897f7b55fd5f7e07a, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\CommandLine\CommandLine.vb"

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

Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.CommandLine.Parsers
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash.FileSystem
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Scripting
Imports Microsoft.VisualBasic.Scripting.Expressions
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Text

Namespace CommandLine

    ''' <summary>
    ''' A command line object that parse from the user input commandline string.
    ''' (从用户所输入的命令行字符串之中解析出来的命令行对象，标准的命令行格式为：
    ''' <example>&lt;EXE> &lt;CLI_Name> ["Parameter" "Value"]</example>)
    ''' </summary>
    ''' <remarks></remarks>
    '''
    Public Class CommandLine : Inherits ClassObject
        Implements ICollection(Of NamedValue(Of String))
        Implements INamedValue

        Friend __listArguments As New List(Of NamedValue(Of String))
        ''' <summary>
        ''' 原始的命令行字符串
        ''' </summary>
        Friend _CLICommandArgvs As String

        Dim _name As String

        ''' <summary>
        ''' The command name that parse from the input command line.
        ''' (从输入的命令行中所解析出来的命令的名称)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Name As String Implements INamedValue.Key
            Get
                Return _name
            End Get
            Protected Friend Set(value As String)
                _name = value
            End Set
        End Property

        ''' <summary>
        ''' The command tokens that were parsed from the input commandline.
        ''' (从所输入的命令行之中所解析出来的命令参数单元)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Tokens As String()

        ''' <summary>
        ''' Listing all of the parameter value collection that parsed from the commandline string.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property ParameterList As NamedValue(Of String)()
            Get
                Return __listArguments.ToArray
            End Get
        End Property

        ''' <summary>
        ''' 得到当前的命令行对象之中的所有的参数的名称的列表
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Keys As String()
            Get
                Return __listArguments.ToArray(Function(v) v.Name)
            End Get
        End Property

        ''' <summary>
        ''' The parameters in the commandline without the first token of the command name.
        ''' (将命令行解析为词元之后去掉命令的名称之后所剩下的所有的字符串列表)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DumpNode> Public ReadOnly Property Parameters As String()
            Get
                Return Tokens.Skip(1).ToArray
            End Get
        End Property

        ''' <summary>
        ''' 对于参数而言，都是--或者-或者/或者\开头的，下一个单词为单引号或者非上面的字符开头的，例如/o &lt;path>
        ''' 对于开关而言，与参数相同的其实符号，但是后面不跟参数而是其他的开关，通常开关用来进行简要表述一个逻辑值
        ''' </summary>
        ''' <returns></returns>
        Public Property BoolFlags As String()

        ''' <summary>
        ''' Get the original command line string.(获取所输入的命令行对象的原始的字符串)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CLICommandArgvs As String
            Get
                Return _CLICommandArgvs
            End Get
        End Property

        ''' <summary>
        ''' The parameter name is not case sensitive.(开关的名称是不区分大小写的)
        ''' </summary>
        ''' <param name="paramName">The argument name in the commandline.</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Default Public ReadOnly Property Item(paramName As String) As String
            Get
                Dim LQuery As NamedValue(Of String) =
                    __listArguments _
                        .Where(Function(x) String.Equals(x.Name, paramName, StringComparison.OrdinalIgnoreCase)) _
                        .FirstOrDefault

                Dim value As String = LQuery.Value ' 是值类型，不会出现空引用的情况

                If value Is Nothing Then
                    value = ""
                Else
                    ' 尝试进行字符串插值，从而实现命令行部分脚本化

                    ' 2017-3-13
                    ' 对于Windows文件路径而言， 不推荐转义
                    ' 因为Windows的文件路径分隔符为\，很容易引起误解，例如C:\tsv会被误转义为C:<TAB>sv而导致错误
                    ' 所以在这里关闭escape参数选项
                    value = value.Interpolate(__envir, escape:=False)
                End If

                Return value
            End Get
        End Property

        ReadOnly __envir As Func(Of String, String) = AddressOf App.GetVariable

        Public Property SingleValue As String

        ''' <summary>
        ''' See if the target logical flag argument is exists in the commandline?
        ''' (查看命令行之中是否存在某一个逻辑开关)
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function HavebFlag(name As String) As Boolean
            If Me.BoolFlags.IsNullOrEmpty Then
                Return False
            Else
                Return Array.IndexOf(BoolFlags, name.ToLower) > -1
            End If
        End Function

        ''' <summary>
        ''' Returns the original cli command line argument string.(返回所传入的命令行的原始字符串)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return CLICommandArgvs
        End Function

        ''' <summary>
        ''' Get specific argument value as full directory path.
        ''' </summary>
        ''' <param name="name">parameter name</param>
        ''' <returns></returns>
        Public Function GetFullDIRPath(name As String) As String
            Return FileIO.FileSystem.GetDirectoryInfo(Me(name)).FullName
        End Function

        ''' <summary>
        ''' Get specific argument value as full file path.(这个函数还会同时修正file://协议的头部)
        ''' </summary>
        ''' <param name="name">parameter name</param>
        ''' <returns></returns>
        Public Function GetFullFilePath(name As String) As String
            Dim path$ = Me(name)
            path = FixPath(path)
            Return FileIO.FileSystem.GetFileInfo(path).FullName
        End Function

        ''' <summary>
        ''' Gets the brief summary information of current cli command line object.
        ''' (获取当前的命令行对象的参数摘要信息)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCommandsOverview() As String
            Dim sb As New StringBuilder(vbCrLf, 1024)
            Call sb.AppendLine($"Commandline arguments overviews{vbCrLf}Command Name  --  ""{Me.Name}""")
            Call sb.AppendLine()
            Call sb.AppendLine("---------------------------------------------------------")
            Call sb.AppendLine()

            If __listArguments.Count = 0 Then
                Call sb.AppendLine("No parameter was define in this commandline.")
                Return sb.ToString
            End If

            Dim MaxSwitchName As Integer = (From item As NamedValue(Of String)
                                            In __listArguments
                                            Select Len(item.Name)).Max
            For Each sw As NamedValue(Of String) In __listArguments
                Call sb.AppendLine($"  {sw.Name}  {New String(" "c, MaxSwitchName - Len(sw.Name))}= ""{sw.Value}"";")
            Next

            Return sb.ToString
        End Function

        ''' <summary>
        ''' Checking for the missing required parameter, this function will returns the missing parameter
        ''' in the current cli command line object using a specific parameter name list.
        ''' (检查<paramref name="list"></paramref>之中的所有参数是否存在，函数会返回不存在的参数名)
        ''' </summary>
        ''' <param name="list"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckMissingRequiredParameters(list As IEnumerable(Of String)) As String()
            Dim LQuery As String() =
                LinqAPI.Exec(Of String) <= From p As String
                                           In list
                                           Where String.IsNullOrEmpty(Me(p))
                                           Select p
            Return LQuery
        End Function

        ''' <summary>
        ''' Gets a list of missing required argument name.
        ''' </summary>
        ''' <param name="args"></param>
        ''' <returns></returns>
        Public Function CheckMissingRequiredArguments(ParamArray args As String()) As String()
            Return CheckMissingRequiredParameters(list:=args)
        End Function

        ''' <summary>
        ''' Does this cli command line object contains any parameter argument information.
        ''' (查看本命令行参数对象之中是否存在有参数信息)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsNullOrEmpty As Boolean
            Get
                Return Tokens.IsNullOrEmpty OrElse (Tokens.Length = 1 AndAlso String.IsNullOrEmpty(Tokens.First))
            End Get
        End Property

        ''' <summary>
        ''' <see cref="String.IsNullOrEmpty"/> of <see cref="Name"/> AndAlso <see cref="IsNullOrEmpty"/>
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property IsNothing As Boolean
            Get
                Return String.IsNullOrEmpty(Me.Name) AndAlso IsNullOrEmpty
            End Get
        End Property

        ''' <summary>
        ''' Does the specific argument exists in this commandline? argument name is not case sensitity.
        ''' (参数名称字符串大小写不敏感)
        ''' </summary>
        ''' <param name="parameterName"></param>
        ''' <returns></returns>
        Public Function ContainsParameter(parameterName As String, trim As Boolean) As Boolean
            Dim namer As String = If(trim, parameterName.TrimParamPrefix, parameterName)
            Dim LQuery As Integer =
                LinqAPI.DefaultFirst(Of Integer) <= From para As NamedValue(Of String)
                                                    In Me.__listArguments  '  名称都是没有处理过的
                                                    Where String.Equals(namer, para.Name, StringComparison.OrdinalIgnoreCase)
                                                    Select 100
            Return LQuery > 50
        End Function

        ''' <summary>
        ''' Parsing the commandline string as object model
        ''' </summary>
        ''' <param name="CommandLine"></param>
        ''' <returns></returns>
        Public Shared Widening Operator CType(CommandLine As String) As CommandLine
            Return TryParse(CommandLine)
        End Operator

        Public Shared Widening Operator CType(CLI As Func(Of String)) As CommandLine
            Return TryParse(CLI())
        End Operator

        ''' <summary>
        ''' Determined that the specific Boolean flag is exists or not? 
        ''' if not then returns <paramref name="failure"/>, if exists such flag, then returns the <paramref name="name"/>.
        ''' </summary>
        ''' <param name="name">Boolean flag name</param>
        ''' <param name="failure"></param>
        ''' <returns></returns>
        Public Function Assert(name As String, Optional failure As String = "") As String
            If GetBoolean(name) Then
                Return name
            Else
                Return failure
            End If
        End Function

        ''' <summary>
        ''' If the target parameter is not presents in the CLI, then this function will returns nothing.
        ''' (键值对之间使用分号分隔)
        ''' </summary>
        ''' <param name="name$"></param>
        ''' <returns></returns>
        Public Function GetDictionary(name$) As Dictionary(Of String, String)
            Dim s$ = Me(name$)

            If String.IsNullOrEmpty(s$) Then
                Return Nothing
            Else
                Return DictionaryParser.TryParse(s$)
            End If
        End Function

        Public Function IsTrue(parameter$) As Boolean
            If Me.HavebFlag(parameter) Then
                Return True
            End If
            Return Me(parameter).ParseBoolean
        End Function

#Region "Pipeline"

        ''' <summary>About <paramref name="s"/>:
        ''' 
        ''' + If the file path is not a value path, then is the value is not null, the argument value will be returned from this parameter. 
        ''' + If the value is nothing, then this function will open the standard input as input.
        ''' + If the file path is valid as input file, then a local file system pointer will be returned.
        ''' 
        ''' [管道函数] 假若参数名存在并且所指向的文件也存在，则返回本地文件的文件指针，否则返回标准输入的指针
        ''' </summary>
        ''' <param name="param"></param>
        ''' <param name="s">
        ''' + If the file path is not a value path, then is the value is not null, the argument value will be returned from this parameter. 
        ''' + If the value is nothing, then this function will open the standard input as input.
        ''' + If the file path is valid as input file, then a local file system pointer will be returned.
        ''' </param>
        ''' <returns></returns>
        Public Function OpenStreamInput(param As String, Optional ByRef s As String = Nothing) As StreamReader
            Dim path As String = Me(param)

            If path.FileExists Then
                Return New StreamReader(New FileStream(path, FileMode.Open, access:=FileAccess.Read))
            ElseIf Not String.IsNullOrEmpty(path) Then
                s = path
                Return Nothing
            Else
                Return New StreamReader(Console.OpenStandardInput)
            End If
        End Function

        ''' <summary>
        ''' [管道函数] 假若参数名存在，则返回本地文件的文件指针，否则返回标准输出的指针
        ''' </summary>
        ''' <param name="param"></param>
        ''' <returns></returns>
        Public Function OpenStreamOutput(param As String) As StreamWriter
            Dim path As String = Me(param)

            If path.StringEmpty Then
                Return New StreamWriter(Console.OpenStandardOutput)
            Else
                Call path.ParentPath.MkDIR

                Dim fs As New FileStream(path, FileMode.OpenOrCreate, access:=FileAccess.ReadWrite)
                Return New StreamWriter(fs)
            End If
        End Function

        ''' <summary>
        ''' Read all of the text input from the file or ``std_in``
        ''' </summary>
        ''' <param name="param"></param>
        ''' <returns></returns>
        Public Function ReadInput(param As String) As String
            Dim s As String = Nothing
            Dim read As StreamReader = OpenStreamInput(param, s)
            If read Is Nothing Then
                Return s
            Else
                Return read.ReadToEnd
            End If
        End Function
#End Region

#Region "IDataRecord Methods"

        ''' <summary>
        ''' Gets the value Of the specified column As a Boolean.
        ''' (这个函数也同时包含有开关参数的，开关参数默认为逻辑值类型，当包含有开关参数的时候，其逻辑值为True，反之函数会检查参数列表，参数不存在则为空值字符串，则也为False)
        ''' </summary>
        ''' <param name="parameter">可以包含有开关参数</param>
        ''' <returns></returns>
        Public Function GetBoolean(parameter As String) As Boolean
            Return Me.IsTrue(parameter)
        End Function

        ''' <summary>
        ''' Gets the 8-bit unsigned Integer value Of the specified column.
        ''' </summary>
        ''' <param name="parameter"></param>
        ''' <returns></returns>
        Public Function GetByte(parameter As String) As Byte
            Return CByte(Val(Me(parameter)))
        End Function

        ''' <summary>
        ''' Reads a stream Of bytes from the specified column offset into the buffer As an array, starting at the given buffer offset.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetBytes(parameter As String) As Byte()
            Dim tokens As String() = Me(parameter).Split(","c)
            Return (From s As String In tokens Select CByte(Val(s))).ToArray
        End Function

        ''' <summary>
        ''' Gets the character value Of the specified column.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetChar(parameter As String) As Char
            Dim s As String = Me(parameter)

            If String.IsNullOrEmpty(s) Then
                Return ASCII.NUL
            Else
                Return s.First
            End If
        End Function

        ''' <summary>
        ''' Reads a stream Of characters from the specified column offset into the buffer As an array, starting at the given buffer offset.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetChars(parameter As String) As Char()
            Return Me(parameter)
        End Function

        ''' <summary>
        ''' Gets the Date And time data value Of the specified field.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetDateTime(parameter As String) As DateTime
            Return Me(parameter).ParseDateTime
        End Function

        ''' <summary>
        ''' Gets the fixed-position numeric value Of the specified field.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetDecimal(parameter As String) As Decimal
            Return CDec(Val(Me(parameter)))
        End Function

        ''' <summary>
        ''' Gets the Double-precision floating point number Of the specified field.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetDouble(parameter As String) As Double
            Return Val(Me(parameter))
        End Function

        ''' <summary>
        ''' Gets the Single-precision floating point number Of the specified field.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetFloat(parameter As String) As Single
            Return CSng(Val(Me(parameter)))
        End Function

        ''' <summary>
        ''' Returns the GUID value Of the specified field.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetGuid(parameter As String) As Guid
            Return Guid.Parse(Me(parameter))
        End Function

        ''' <summary>
        ''' Gets the 16-bit signed Integer value Of the specified field.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetInt16(parameter As String) As Int16
            Return CType(Val(Me(parameter)), Int16)
        End Function

        ''' <summary>
        ''' Gets the 32-bit signed Integer value Of the specified field.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetInt32(parameter As String) As Int32
            Return CInt(Val(Me(parameter)))
        End Function

        ''' <summary>
        ''' Gets the 64-bit signed Integer value Of the specified field.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetInt64(parameter As String) As Int64
            Return CLng(Val(Me(parameter)))
        End Function

        ''' <summary>
        ''' Return the index Of the named field. If the name is not exists in the parameter list, then a -1 value will be return.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetOrdinal(parameter As String) As Integer
            Dim i As Integer =
                LinqAPI.DefaultFirst(Of Integer)(-1) <=
                From entry As NamedValue(Of String)
                In Me.__listArguments
                Where String.Equals(parameter, entry.Name, StringComparison.OrdinalIgnoreCase)
                Select __listArguments.IndexOf(entry)

            Return i
        End Function

        ''' <summary>
        ''' Gets the String value Of the specified field.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetString(parameter As String) As String
            Return Me(parameter)
        End Function

        ''' <summary>
        ''' Return whether the specified field Is Set To null.
        ''' </summary>
        ''' <returns></returns>
        Public Function IsNull(parameter As String) As Boolean
            Return Not Me.ContainsParameter(parameter, False)
        End Function

        ''' <summary>
        '''
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="parameter">Command parameter name in the command line inputs.</param>
        ''' <param name="__getObject"></param>
        ''' <returns></returns>
        Public Function GetObject(Of T)(parameter As String, __getObject As Func(Of String, T)) As T
            If __getObject Is Nothing Then
                Return Nothing
            End If

            Dim value As String = Me(parameter)
            Dim obj As T = __getObject(arg:=value)
            Return obj
        End Function

        ''' <summary>
        ''' If the given parameter is not exists in the user input arguments, then a developer specific default value will be return.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="name">The optional argument parameter name</param>
        ''' <param name="[default]">The default value for returns when the parameter is not exists in the user input.</param>
        ''' <param name="__ctype">The custom string parser for the CLI argument value</param>
        ''' <returns></returns>
        Public Function GetValue(Of T)(name$, [default] As T, Optional __ctype As Func(Of String, T) = Nothing) As T
            If Not Me.ContainsParameter(name, False) Then
                If GetType(T).Equals(GetType(Boolean)) Then
                    If HavebFlag(name) Then
                        Return DirectCast(DirectCast(GetBoolean(name), Object), T)
                    End If
                End If

                Return [default]
            End If

            Dim str As String = Me(name)

            If __ctype Is Nothing Then
                Dim value As Object = InputHandler.CTypeDynamic(str, GetType(T))
                Return DirectCast(value, T)
            Else
                Return __ctype(str)
            End If
        End Function

        ''' <summary>
        ''' Open a file handle by using the parameter value
        ''' </summary>
        ''' <param name="name">The parameter name, and its argument value should be a valid file path</param>
        ''' <param name="[default]">Default file path if the argument value is not exists</param>
        ''' <returns></returns>
        Public Function OpenHandle(name$, Optional default$ = "") As int
            Dim file As String = Me(name)
            If String.IsNullOrEmpty(file) Then
                file = [default]
            End If
            Return New int(FileHandles.OpenHandle(file))
        End Function
#End Region

#Region "Implements IReadOnlyCollection(Of KeyValuePair(Of String, String))"

        ''' <summary>
        ''' 这个枚举函数也会将开关给包含进来，与<see cref="ToArgumentVector"/>方法所不同的是，这个函数里面的逻辑值开关的名称没有被修饰剪裁
        ''' </summary>
        ''' <returns></returns>
        Public Iterator Function GetEnumerator() As IEnumerator(Of NamedValue(Of String)) Implements IEnumerable(Of NamedValue(Of String)).GetEnumerator
            Dim source As New List(Of NamedValue(Of String))(Me.__listArguments)

            If Not Me.BoolFlags.IsNullOrEmpty Then
                source += From name As String
                          In BoolFlags
                          Select New NamedValue(Of String)(name, "true")
            End If

            For Each x As NamedValue(Of String) In source
                Yield x
            Next
        End Function

        Public Iterator Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function

        ''' <summary>
        ''' Adds an item to the System.Collections.Generic.ICollection`1.
        ''' </summary>
        ''' <param name="item"></param>
        Public Sub Add(item As NamedValue(Of String)) Implements ICollection(Of NamedValue(Of String)).Add
            Call __listArguments.Add(item)
        End Sub

        ''' <summary>
        ''' Add a parameter with name and its value.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <param name="value"></param>
        Public Sub Add(key$, value$,
                       Optional allowDuplicated As Boolean = False,
                       <CallerMemberName> Optional stack$ = Nothing)

            Dim item As New NamedValue(Of String) With {
                .Name = key.ToLower,
                .Value = value,
                .Description = stack & "->" & NameOf(Add)
            }

            If Not allowDuplicated Then
                For i As Integer = 0 To __listArguments.Count - 1
                    With __listArguments(i)
                        If .Name.TextEquals(key) Then
                            __listArguments(i) = item
                            Return
                        End If
                    End With
                Next

                ' 没有查找到需要被替换掉的下标，则直接在下面的代码之中进行添加
            End If

            __listArguments += item
        End Sub

        ''' <summary>
        ''' Clear the inner list buffer
        ''' </summary>
        Public Sub Clear() Implements ICollection(Of NamedValue(Of String)).Clear
            Call __listArguments.Clear()
        End Sub

        ''' <summary>
        ''' 只是通过比较名称来判断是否存在，值没有进行比较
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Public Function Contains(item As NamedValue(Of String)) As Boolean Implements ICollection(Of NamedValue(Of String)).Contains
            Dim LQuery As Integer =
                LinqAPI.DefaultFirst(-1) <= From obj As NamedValue(Of String)
                                            In Me.__listArguments
                                            Where String.Equals(obj.Name, item.Name, StringComparison.OrdinalIgnoreCase)
                                            Select 100
            Return LQuery > 50
        End Function

        Public Sub CopyTo(array() As NamedValue(Of String), arrayIndex As Integer) Implements ICollection(Of NamedValue(Of String)).CopyTo
            Call __listArguments.ToArray.CopyTo(array, arrayIndex)
        End Sub

        ''' <summary>
        ''' Get the switch counts in this commandline object.(获取本命令行对象中的所定义的开关的数目)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Count As Integer Implements ICollection(Of NamedValue(Of String)).Count
            Get
                Return Me.__listArguments.Count
            End Get
        End Property

        Private ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of NamedValue(Of String)).IsReadOnly
            Get
                Return True
            End Get
        End Property

        ''' <summary>
        ''' Removes a parameter by name
        ''' </summary>
        ''' <param name="paramName"></param>
        ''' <returns></returns>
        Public Function Remove(paramName As String) As Boolean
            Dim LQuery As NamedValue(Of String) =
                LinqAPI.DefaultFirst(Of NamedValue(Of String)) <=
                    From obj As NamedValue(Of String)
                    In Me.__listArguments
                    Where String.Equals(obj.Name, paramName, StringComparison.OrdinalIgnoreCase)
                    Select obj

            If LQuery.IsEmpty Then
                Return False
            Else
                Call __listArguments.Remove(LQuery)
                Return True
            End If
        End Function

        ''' <summary>
        ''' Removes a parameter by <see cref="NamedValue(Of String).Name"/>
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Public Function Remove(item As NamedValue(Of String)) As Boolean Implements ICollection(Of NamedValue(Of String)).Remove
            Return Remove(item.Name)
        End Function
#End Region

        ''' <summary>
        ''' 将当前的这个命令行对象之中的所有的参数值都合并到一个向量之中返回.
        ''' (``ToArray``拓展好像是有BUG的，所以请使用这个函数来获取所有的参数信息。
        ''' 请注意，逻辑值开关的名称会被去掉前缀)
        ''' </summary>
        ''' <returns></returns>
        Public Function ToArgumentVector() As NamedValue(Of String)()
            Dim list As New List(Of NamedValue(Of String))

            If Not Me.__listArguments.IsNullOrEmpty Then
                list += From obj As NamedValue(Of String)
                        In __listArguments
                        Select New NamedValue(Of String)(obj.Name, obj.Value)
            End If

            If Not Me.BoolFlags.IsNullOrEmpty Then
                list += From bs As String
                        In Me.BoolFlags
                        Select New NamedValue(Of String)(TrimParamPrefix(bs), "True")
            End If

            Return list.ToArray
        End Function

        ''' <summary>
        ''' Open a handle for a file system object.
        ''' </summary>
        ''' <param name="args"></param>
        ''' <param name="fs"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator +(args As CommandLine, fs As String) As Integer
            Dim path As String = args(fs)
            Return FileHandles.OpenHandle(path)
        End Operator

        ''' <summary>
        ''' Gets the CLI parameter value.
        ''' </summary>
        ''' <param name="args"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator <=(args As CommandLine, name As String) As String
            If args Is Nothing Then
                Return Nothing
            Else
                Return args(name)
            End If
        End Operator

        Public Shared Operator <=(opt As String, args As CommandLine) As CommandLine
            Return TryParse(args(opt))
        End Operator

        Public Shared Operator ^(args As CommandLine, [default] As String) As String
            If args Is Nothing OrElse String.IsNullOrEmpty(args.CLICommandArgvs) Then
                Return [default]
            Else
                Return args.CLICommandArgvs
            End If
        End Operator

        Public Shared Operator >=(opt As String, args As CommandLine) As CommandLine
            Throw New NotSupportedException
        End Operator

        ''' <summary>
        ''' Try get parameter value.
        ''' </summary>
        ''' <param name="args"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>

        Public Overloads Shared Operator -(args As CommandLine, name As String) As String
            Return args(name)
        End Operator

        ''' <summary>
        ''' Try get parameter value.
        ''' </summary>
        ''' <param name="args"></param>
        ''' <returns></returns>

        Public Overloads Shared Operator -(args As CommandLine, null As CommandLine) As CommandLine
            Return args
        End Operator

        Public Overloads Shared Operator -(args As CommandLine, name As IEnumerable(Of String)) As String
            Return args.GetValue(name.First, name.Last)
        End Operator

        Public Shared Operator -(args As CommandLine) As CommandLine
            Return args
        End Operator

        Public Shared Operator >(args As CommandLine, name As String) As String
            Return args(name)
        End Operator

        Public Shared Operator <(args As CommandLine, name As String) As String
            Return args(name)
        End Operator

        Public Shared Operator >=(args As CommandLine, name As String) As String
            Throw New NotSupportedException
        End Operator
    End Class
End Namespace
