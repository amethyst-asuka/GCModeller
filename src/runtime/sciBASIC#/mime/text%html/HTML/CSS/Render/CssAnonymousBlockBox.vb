﻿#Region "Microsoft.VisualBasic::bca1d6ad170dbfaaadaa41ee5ebaabef, ..\sciBASIC#\mime\text%html\HTML\CSS\Render\CssAnonymousBlockBox.vb"

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

Imports System.Collections.Generic
Imports System.Text

Namespace HTML.CSS.Render

    ''' <summary>
    ''' Represents an anonymous block box
    ''' </summary>
    ''' <remarks>
    ''' To learn more about anonymous block boxes visit CSS spec:
    ''' http://www.w3.org/TR/CSS21/visuren.html#anonymous-block-level
    ''' </remarks>
    Public Class CssAnonymousBlockBox
        Inherits CssBox
        Public Sub New(parent As CssBox)
            MyBase.New(parent)
            Display = CssConstants.Block
        End Sub

        Public Sub New(parent As CssBox, insertBefore As CssBox)
            Me.New(parent)
            Dim index As Integer = parent.Boxes.IndexOf(insertBefore)

            If index < 0 Then
                Throw New Exception("insertBefore box doesn't exist on parent")
            End If
            parent.Boxes.Remove(Me)
            parent.Boxes.Insert(index, Me)
        End Sub
    End Class

    ''' <summary>
    ''' Represents an AnonymousBlockBox which contains only blank spaces
    ''' </summary>
    Public Class CssAnonymousSpaceBlockBox
        Inherits CssAnonymousBlockBox
        Public Sub New(parent As CssBox)
            MyBase.New(parent)
            Display = CssConstants.None
        End Sub

        Public Sub New(parent As CssBox, insertBefore As CssBox)
            MyBase.New(parent, insertBefore)
            Display = CssConstants.None
        End Sub
    End Class
End Namespace
