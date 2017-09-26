﻿#Region "Microsoft.VisualBasic::e790e9db09d087cbdad2f9b4bc8a0347, ..\CLI_tools\eggHTS\CLI\Repository.vb"

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

Imports System.ComponentModel
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports SMRUCC.genomics.Assembly.Uniprot.XML
Imports SMRUCC.genomics.Data.GeneOntology.mysql
Imports SMRUCC.genomics.Data.Repository.kb_UniProtKB
Imports SMRUCC.genomics.foundation.OBO_Foundry

Partial Module CLI

    <ExportAPI("/Imports.Go.obo.mysql")>
    <Description("")>
    <Usage("/Imports.Go.obo.mysql /in <go.obo> [/out <out.sql>]")>
    <Group(CLIGroups.Repository_CLI)>
    Public Function DumpGOAsMySQL(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim out$ = args.GetValue("/out", [in].TrimSuffix & ".kb_go.sql")

        Return New OBOFile([in]) _
            .DumpMySQL(saveSQL:=out) _
            .CLICode
    End Function

    <ExportAPI("/Imports.Uniprot.Xml")>
    <Usage("/Imports.Uniprot.Xml /in <uniprot.xml> [/out <out.sql>]")>
    <Group(CLIGroups.Repository_CLI)>
    Public Function DumpUniprot(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim out$ = args.GetValue("/out", [in].TrimSuffix & $".{UniprotKBEngine.DbName}.sql")
        Dim proteins = UniProtXML.EnumerateEntries(path:=[in])

        Return proteins _
            .DumpMySQLProject(EXPORT:=out) _
            .CLICode
    End Function
End Module

