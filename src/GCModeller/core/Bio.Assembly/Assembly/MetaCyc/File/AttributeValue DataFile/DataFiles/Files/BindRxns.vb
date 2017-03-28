﻿#Region "Microsoft.VisualBasic::a567aa31aadf30d5ef5b18d080394514, ..\core\Bio.Assembly\Assembly\MetaCyc\File\AttributeValue DataFile\DataFiles\Files\BindRxns.vb"

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

Imports SMRUCC.genomics.Assembly.MetaCyc.Schema.Reflection

Namespace Assembly.MetaCyc.File.DataFiles

    Public Class BindRxns : Inherits DataFile(Of Slots.BindReaction)

        Public Overrides ReadOnly Property AttributeList As String()
            Get
                Return {
                    "UNIQUE-ID", "TYPES", "COMMON-NAME", "ACTIVATORS",
                    "BALANCE-STATE", "BASAL-TRANSCRIPTION-VALUE",
                    "CITATIONS", "COMMENT", "COMPONENT-OF", "COMPONENTS",
                    "CREDITS", "DBLINKS", "DELTAG0", "DEPRESSORS",
                    "EC-NUMBER", "ENZYMATIC-REACTION",
                    "EQUILIBRIUM-CONSTANT", "IN-PATHWAY", "INHIBITORS",
                    "INSTANCE-NAME-TEMPLATE", "LEFT", "OFFICIAL-EC?",
                    "ORPHAN?", "REACTANTS", "REACTION-PRESENT-IN-E-COLI?",
                    "REQUIREMENTS", "RIGHT", "SIGNAL", "SPECIES",
                    "SPONTANEOUS?", "STIMULATORS", "SYNONYMS"
                }
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("{0}  {1} frame object records.", DbProperty.ToString, FrameObjects.Count)
        End Function
    End Class
End Namespace
