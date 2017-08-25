﻿#Region "Microsoft.VisualBasic::6d5907210264b79949b3aafd45847761, ..\R.Bioconductor\RDotNET.Extensions.VisualBasic\API\methods.vb"

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

Namespace API

    Public Module methods

#Region "S4 object"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="x$">either the name of a class (as character string), or a class definition. If given an argument that is neither a character string nor a class definition, slotNames (only) uses class(x) instead.</param>
        ''' <returns></returns>
        Public Function slotNames(x$) As String
            Dim var$ = App.NextTempName

            SyncLock R
                With R
                    .call = $"{var} <- slotNames({x});"
                End With
            End SyncLock

            Return var
        End Function
#End Region
    End Module
End Namespace
