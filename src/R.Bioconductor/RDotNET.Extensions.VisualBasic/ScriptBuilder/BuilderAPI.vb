﻿#Region "Microsoft.VisualBasic::16de9227ad21b87b091e5de43dd799a0, ..\R.Bioconductor\RDotNET.Extensions.VisualBasic\ScriptBuilder\BuilderAPI.vb"

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

Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports RDotNET.Extensions.VisualBasic.SymbolBuilder.Rtypes

Namespace SymbolBuilder

    ''' <summary>
    ''' Build script token
    ''' </summary>
    Public Module BuilderAPI

        ''' <summary>
        ''' additional arguments to be passed to or from methods.
        ''' </summary>
        ''' <param name="parameters$"></param>
        ''' <returns></returns>
        Public Function list(ParamArray parameters$()) As ParameterList
            Return New ParameterList(parameters)
        End Function

        Const IsNotAFunc = "Target object is not a R function abstract!"

        ''' <summary>
        ''' R.func(param="",...)
        ''' </summary>
        ''' <param name="token"></param>
        ''' <returns></returns>
        ''' 
        <Extension>
        Public Function GetScript(token As Object, Optional type As Type = Nothing) As String
            If token Is Nothing Then
                Throw New NullReferenceException("Script tokens is nothing!")
            End If

            If type Is Nothing Then
                type = token.GetType
            End If

            Return __getScript(token, type)
        End Function

        ''' <summary>
        ''' Create script token from the class
        ''' </summary>
        ''' <param name="token"></param>
        ''' <param name="type"></param>
        ''' <returns></returns>
        Private Function __getScript(token As Object, type As Type) As String
            Dim name As String = type.GetAPIName
            Dim props = (From prop As PropertyInfo In type.GetProperties
                         Where prop.GetAttribute(Of Ignored) Is Nothing AndAlso
                             prop.CanRead
                         Let param As Parameter = prop.GetAttribute(Of Parameter)
                         Select prop,
                             func = prop.__getName(param),
                             param.__isOptional,
                             param
                         Order By __isOptional Ascending)
            Dim parameters As String() =
                props.ToArray(Function(x) __getExpr(token, x.prop, x.func, x.param))
            Dim args As String() = LinqAPI.Exec(Of String) <=
 _
                From p As String
                In parameters
                Where Not String.IsNullOrEmpty(p)
                Select p

            Dim script As String = $"{name}({String.Join(", " & vbCrLf, args)})"
            Return script
        End Function

        ''' <summary>
        ''' GET API name
        ''' </summary>
        ''' <param name="type"></param>
        ''' <returns></returns>
        <Extension> Public Function GetAPIName(type As Type) As String
            Dim name As RFunc = type.GetAttribute(Of RFunc) ' Get function name

            If name Is Nothing Then
                Dim ex As New Exception(IsNotAFunc)
                ex = New Exception(type.FullName, ex)
                Throw ex
            Else
                Return name.Name
            End If
        End Function

        ''' <summary>
        ''' R.func(param="",...)
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="token"></param>
        ''' <returns></returns>
        ''' 
        <Extension>
        Public Function GetScript(Of T)(token As T) As String
            Dim type As Type = GetType(T)
            Return __getScript(token, type)
        End Function

        ''' <summary>
        ''' name=value
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="prop"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Private Function __getExpr(x As Object, prop As PropertyInfo, name As String, param As Parameter) As String
            Dim value As Object = prop.GetValue(x)
            Dim type = If(param Is Nothing, ValueTypes.String, param.Type)
            Dim s As String = prop.PropertyType.__getValue(value, type)
            If String.IsNullOrEmpty(s) Then
                Return ""
            Else
                Return $"{name}={s}"
            End If
        End Function

        <Extension>
        Private Function __getValue(type As Type, value As Object, valueType As ValueTypes) As String
            If value Is Nothing Then
                Return Nothing
            End If

            Select Case type

                Case GetType(String)
                    If valueType = ValueTypes.Path Then
                        Return Rstring(Scripting.ToString(value).UnixPath)
                    Else
                        Return Rstring(Scripting.ToString(value))
                    End If
                Case GetType(Boolean)
                    If True = DirectCast(value, Boolean) Then
                        Return RBoolean.TRUE.__value
                    Else
                        Return RBoolean.FALSE.__value
                    End If
                Case GetType(RExpression)
                    Return DirectCast(value, RExpression).RScript
                Case Else
                    Return Scripting.ToString(value)
            End Select
        End Function

        <Extension>
        Private Function __isOptional(param As Parameter) As Boolean
            If param Is Nothing Then
                Return False
            Else
                Return param.Optional
            End If
        End Function

        <Extension>
        Private Function __getName(prop As PropertyInfo, param As Parameter) As String
            If param Is Nothing Then
                Return prop.Name
            Else
                Return param.Name
            End If
        End Function
    End Module
End Namespace
