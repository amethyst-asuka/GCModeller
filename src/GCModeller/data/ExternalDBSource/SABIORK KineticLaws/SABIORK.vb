﻿#Region "Microsoft.VisualBasic::0fe2b128da58f4cec28fbf1c61d3501e, ..\GCModeller\data\ExternalDBSource\SABIORK KineticLaws\SABIORK.vb"

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

Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.IEnumerations
Imports SMRUCC.genomics.ComponentModel.EquaionModel.DefaultTypes
Imports SMRUCC.genomics.Data.SabiorkKineticLaws.TabularDump

Namespace SabiorkKineticLaws

    Public Class SABIORK : Inherits Equation

        ''' <summary>
        ''' http://sabiork.h-its.org/sabioRestWebServices/kineticLaws?kinlawids=
        ''' </summary>
        Public Const URL_SABIORK_KINETIC_LAWS_QUERY As String = "http://sabiork.h-its.org/sabioRestWebServices/kineticLaws?kinlawids="

        Public Property kineticLawID As Long
        Public Property startValuepH As Double
        Public Property startValueTemperature As Double
        Public Property Buffer As String
        Public Property Fast As Boolean

        Public Property CompoundSpecies As SBMLParser.CompoundSpecie()
        Public Property Identifiers As String()
        Public Property LocalParameters As TripleKeyValuesPair()

        Public Overrides Function ToString() As String
            Return kineticLawID
        End Function
    End Class
End Namespace
