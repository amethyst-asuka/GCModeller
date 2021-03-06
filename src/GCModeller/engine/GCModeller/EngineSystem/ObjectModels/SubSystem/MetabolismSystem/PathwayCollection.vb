﻿#Region "Microsoft.VisualBasic::e6d17e630fa3d53595ab6dab07da281a, ..\GCModeller\engine\GCModeller\EngineSystem\ObjectModels\SubSystem\MetabolismSystem\PathwayCollection.vb"

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

Imports Microsoft.VisualBasic.Serialization
Imports SMRUCC.genomics.GCModeller.ModellingEngine.EngineSystem.RuntimeObjects
Imports SMRUCC.genomics.GCModeller.ModellingEngine.EngineSystem.Services.DataAcquisition.Services
Imports SMRUCC.genomics.GCModeller.ModellingEngine.EngineSystem.Services.MySQL

Namespace EngineSystem.ObjectModels.SubSystem

    Public Class PathwayCollection : Inherits CellComponentSystemFramework(Of ObjectModels.Module.Pathway)
        Implements PlugIns.ISystemFrameworkEntry.ISystemFramework
        Implements IDrivenable

        Sub New(Metabolism As SubSystem.MetabolismCompartment)
            Call MyBase.New(Metabolism)
        End Sub

        Public Overrides Function CreateServiceSerials() As IDataAcquisitionService()
            If MyBase._DynamicsExprs.IsNullOrEmpty Then
                Call SystemLogging.WriteLine("There is no pathway data define in the data model, will not create the data service for the pathway collection.", "", Type:=Logging.MSG_TYPES.INF)
                Return New IDataAcquisitionService() {}
            Else
                Return New IDataAcquisitionService() {
          New DataAcquisitionService(New EngineSystem.Services.DataAcquisition.DataAdapters.PathwayCollection(Me), RuntimeContainer:=MyBase.get_RuntimeContainer)}
            End If
        End Function

        Public Overrides Function Initialize() As Integer
            Dim CellSystem = DirectCast(_CellComponentContainer, SubSystem.MetabolismCompartment)._CellSystem

            If CellSystem.DataModel.Metabolism.Pathways.IsNullOrEmpty Then
                MyBase._DynamicsExprs = New ObjectModels.Module.Pathway() {}
            Else
                MyBase._DynamicsExprs = (From item In CellSystem.DataModel.Metabolism.Pathways Select EngineSystem.ObjectModels.Module.Pathway.CreateObject(item, CellSystem.Metabolism)).ToArray
                Call SystemLogging.WriteLine(NetworkComponents.Count & " pathway objects was defined in the data model.", "", Type:=Logging.MSG_TYPES.INF)
            End If

            Return 0
        End Function

        Public Overrides Sub MemoryDump(Dir As String)
            Call Me.I_CreateDump.SaveTo(String.Format("{0}/{1}.log", Dir, Me.GetType.Name))
        End Sub

        Public ReadOnly Property EventId As String Implements IDrivenable.EventId
            Get
                Return "Pathway DataSource Driver"
            End Get
        End Property

        Protected Overrides Function __innerTicks(KernelCycle As Integer) As Integer Implements IDrivenable.__innerTicks
            Dim LQuery = (From data0expr In _DynamicsExprs.AsParallel Select data0expr.Invoke).ToArray
            Return 0
        End Function
    End Class
End Namespace
