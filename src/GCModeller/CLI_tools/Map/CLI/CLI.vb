﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv.Extensions
Imports SMRUCC.genomics.Assembly.NCBI.GenBank
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.TabularFormat
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.RpsBLAST
Imports SMRUCC.genomics.Visualize
Imports SMRUCC.genomics.Visualize.ChromosomeMap
Imports SMRUCC.genomics.Visualize.ChromosomeMap.Configuration
Imports SMRUCC.genomics.Visualize.ChromosomeMap.DrawingModels

Public Module CLI

    <ExportAPI("--Draw.ChromosomeMap",
               Info:="Drawing the chromosomes map from the PTT object as the basically genome information source.",
               Usage:="--Draw.ChromosomeMap /ptt <genome.ptt> [/conf <config.inf> /out <dir.export> /COG <cog.csv>]")>
    <Argument("/COG", True, CLITypes.File,
              AcceptTypes:={GetType(MyvaCOG)},
              Description:="The gene object color definition, you can using this parameter to overrides the cog definition in the PTT file.")>
    Public Function DrawingChrMap(args As CommandLine) As Integer
        Dim PTT = args.GetObject("/ptt", AddressOf TabularFormat.PTT.Load)
        Dim out As String = args.GetValue("/out", App.CurrentDirectory)
        Dim confInf As String = args.GetValue("/conf", out & "/config.inf")
        Dim COG As String = args("/COG")

        Return PTT.Draw(COG, confInf, out)
    End Function

    <Extension>
    Private Function Draw(PTT As PTT, COG$, conf$, out$) As Integer
        Dim config As Config

        If Not conf.FileExists(True) Then
Create:     config = ChromosomeMap.GetDefaultConfiguration(conf)
        Else
            Try
                config = ChromosomeMap.LoadConfig(conf)
            Catch ex As Exception
                GoTo Create
            End Try
        End If

        Dim device As DrawingDevice = ChromosomeMap.CreateDevice(config)
        Dim model As ChromesomeDrawingModel = ChromosomeMap.FromPTT(PTT, config)

        If COG.FileExists(True) Then
            Dim COGProfiles As MyvaCOG() = COG.LoadCsv(Of MyvaCOG).ToArray
            model = ChromosomeMap.ApplyCogColorProfile(model, COGProfiles)
        End If

        Return device _
            .InvokeDrawing(model) _
            .SaveImage(out, "tiff")
    End Function

    <ExportAPI("--Draw.ChromosomeMap.genbank",
               Usage:="--Draw.ChromosomeMap.genbank /gb <genome.gbk> [/conf <config.inf> /out <dir.export> /COG <cog.csv>]")>
    Public Function DrawGenbank(args As CommandLine) As Integer
        Dim gb As String = args("/gb")
        Dim out As String = args.GetValue("/out", App.CurrentDirectory)
        Dim confInf As String = args.GetValue("/conf", out & "/config.inf")
        Dim COG As String = args("/COG")
        Dim PTT As PTT = GBFF.File.Load(gb).GbkffExportToPTT

        Return PTT.Draw(COG, confInf, out)
    End Function
End Module
