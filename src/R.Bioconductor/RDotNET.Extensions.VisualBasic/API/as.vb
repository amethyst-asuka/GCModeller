﻿#Region "Microsoft.VisualBasic::d1e85ca748de2715558757d3dca76b14, ..\R.Bioconductor\RDotNET.Extensions.VisualBasic\API\as.vb"

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

Imports RDotNET.Extensions.VisualBasic.SymbolBuilder

Namespace API.as

    ' 2017-6-28
    '
    ' 在这里是使用命名空间[as]来实现as.XXX的R函数名称语法的
    ' 函数在as命名空间下被分散在不同的module之中表示来自于不同的R API的命名空间
    ' [is]命名空间之中的设计也是如此
    ' 所以不需要专门修改这个命名空间下的module为class了

    Public Module stats

        ''' <summary>
        ''' as.ts and is.ts coerce an object to a time-series and test whether an object is a time series.
        ''' </summary>
        ''' <param name="x">an arbitrary R object.</param>
        ''' <param name="additionals">arguments passed to methods (unused for the default method).</param>
        ''' <returns>
        ''' ``as.ts`` is generic. Its default method will use the tsp attribute of the object 
        ''' if it has one to set the start and end times and frequency.
        ''' </returns>
        Public Function ts(x As String, ParamArray additionals As String()) As String
            Dim out As String = App.NextTempName
            Call $"{out} <- as.ts({x}, {String.Join(",", additionals)})".__call
            Return out
        End Function
    End Module

    Public Module base

        ''' <summary>
        ''' as.vector, a generic, attempts to coerce its argument into a vector of mode mode 
        ''' (the default is to coerce to whichever vector mode is most convenient): 
        ''' if the result is atomic all attributes are removed.
        ''' </summary>
        ''' <param name="x$"></param>
        ''' <param name="mode$"></param>
        ''' <returns></returns>
        Public Function vector(x$, Optional mode$ = "any") As String
            Dim var$ = App.NextTempName

            SyncLock R
                With R
                    .call = $"{var} <- as.vector({x}, mode = {Rstring(mode)})"
                End With
            End SyncLock

            Return var
        End Function

        ''' <summary>
        ''' ``as.matrix`` attempts to turn its argument into a matrix.
        ''' </summary>
        ''' <param name="x$">an R object.</param>
        ''' <param name="rownamesForce">
        ''' logical indicating if the resulting matrix should have character (rather than NULL) rownames. 
        ''' The default, NA, uses NULL rownames if the data frame has ‘automatic’ row.names or for a zero-row data frame.
        ''' </param>
        ''' <param name="list">
        ''' using function <see cref="BuilderAPI.list(String())"/> for generates this additional arguments to be passed to or from methods.
        ''' </param>
        ''' <returns></returns>
        Public Function matrix(x$, Optional rownamesForce As String = "NA", Optional list As ParameterList = Nothing) As String
            SyncLock R
                With R
                    Dim var$ = App.NextTempName

                    .call = $"{var} <- as.matrix({x}, rownames.force = {rownamesForce}, {list?.ToString})"
                    Return var
                End With
            End SyncLock
        End Function
    End Module
End Namespace
