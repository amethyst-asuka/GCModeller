﻿#Region "Microsoft.VisualBasic::8adc1549d85e730c3a36a8235cc09ed3, ..\GCModeller\data\ExternalDBSource\ShellScriptAPI.vb"

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

Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv.Extensions
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Data.Regprecise
Imports SMRUCC.genomics.Data.SabiorkKineticLaws

Namespace ShellScriptAPI

    <Package("Sabio-rk",
                        Category:=APICategories.ResearchTools,
                        Publisher:="xie.guigang@gmail.com")>
    Public Module SabiorkKinetics

        <ExportAPI("Load.From", Info:="Load sabio-rk database from a specific data directory.")>
        Public Function LoadData(dir As String) As SABIORK()
            Dim LQuery = (From strPath As String
                            In FileIO.FileSystem.GetFiles(dir, FileIO.SearchOption.SearchTopLevelOnly, "*.sbml").AsParallel
                          Where FileIO.FileSystem.GetFileInfo(strPath).Length > 0
                          Select SabiorkKineticLaws.SBMLParser.kineticLawModel.LoadDocument(strPath)).ToArray 'Read sbml file document from the filesystem
            Call Console.WriteLine("{0} sabio-rk data was loaded from filesystem!", LQuery.Count)
            Return LQuery
        End Function

        <ExportAPI("Export")>
        Public Function ExportDatabase(data As SabiorkKineticLaws.SABIORK(),
                                       <Parameter("DIR.Export",
                                                  "The directory for export the loaded sabio-rk database as assembly file.")> exportDIR As String) As Integer
            Call $"Export sabio-rk database to ""{exportDIR}""".__DEBUG_ECHO
            Call "Start to proceeding ......".__DEBUG_ECHO
            Call SabiorkKineticLaws.ExportDatabase(data, exportDIR)
            Call "Job done!".__DEBUG_ECHO
            Return 0
        End Function
    End Module
End Namespace
