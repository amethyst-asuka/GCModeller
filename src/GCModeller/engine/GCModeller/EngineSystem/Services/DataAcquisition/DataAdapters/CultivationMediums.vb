﻿#Region "Microsoft.VisualBasic::54ac84d5a5f1f46e61b3ba52e7947dbf, ..\GCModeller\engine\GCModeller\EngineSystem\Services\DataAcquisition\DataAdapters\CultivationMediums.vb"

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

Imports SMRUCC.genomics.GCModeller.ModellingEngine.EngineSystem.Services.DataAcquisition.DataSerializer
Imports SMRUCC.genomics.GCModeller.ModellingEngine.EngineSystem.Services.DataAcquisition.Services

Namespace EngineSystem.Services.DataAcquisition.DataAdapters

    Public Class CultivationMediumsMetabolites : Inherits DataAdapter(Of EngineSystem.ObjectModels.SubSystem.CultivationMediums)
        Implements IDataAdapter

        Public Overrides ReadOnly Property TableName As String
            Get
                Return "CultivationMediumsMetabolites"
            End Get
        End Property

        Sub New(DataSource As EngineSystem.ObjectModels.SubSystem.CultivationMediums)
            Call MyBase.New(DataSource)
        End Sub

        Public Overrides Function DataSource() As DataSource()
            Dim LQuery = (From item In System.CultivationMediums Let value = item.DataSource Select value).ToArray
            Return LQuery
        End Function

        Public Overrides Function DefHandles() As HandleF()
            Dim LQuery = (From item In System.CultivationMediums Select New HandleF With {.Handle = item.Handle, .Identifier = item.Identifier}).ToArray
            Return LQuery
        End Function
    End Class

    Public Class CultivationMediumsReactor : Inherits DataAdapter(Of EngineSystem.ObjectModels.SubSystem.CultivationMediums)
        Implements IDataAdapter

        Public Overrides ReadOnly Property TableName As String
            Get
                Return "CultivationMediumsReactor"
            End Get
        End Property

        Sub New(DataSource As EngineSystem.ObjectModels.SubSystem.CultivationMediums)
            Call MyBase.New(DataSource)
        End Sub

        Public Overrides Function DataSource() As DataSource()
            Return Me.System.DataSource
        End Function

        Public Overrides Function DefHandles() As HandleF()
            Return Me.System.get_DataSerializerHandles
        End Function
    End Class
End Namespace
