﻿#Region "Microsoft.VisualBasic::5b32dfee69476e40543c71e3742dca5b, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Tools\Network\Protocol\IVerifySession.vb"

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

Namespace Net.Protocols

    ''' <summary>
    ''' 这个组件用来为用户输入一些验证信息
    ''' </summary>
    Public Interface IVerifySession
        ReadOnly Property SessionID As Long
        ReadOnly Property ValueInput As String
    End Interface
End Namespace
