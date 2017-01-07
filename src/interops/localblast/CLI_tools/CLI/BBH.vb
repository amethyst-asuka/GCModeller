﻿#Region "Microsoft.VisualBasic::f63cfab7bc51d2faa412285007cf630d, ..\interops\localblast\CLI_tools\CLI\BBH.vb"

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
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Parallel.Linq
Imports Microsoft.VisualBasic.Text
Imports SMRUCC.genomics.Analysis.localblast.VennDiagram.BlastAPI
Imports SMRUCC.genomics.Interops.NCBI.Extensions
Imports SMRUCC.genomics.Interops.NCBI.Extensions.Analysis.BBHLogs
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BatchParallel
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH.Abstract
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.BLASTOutput
Imports SMRUCC.genomics.SequenceModel.FASTA

Partial Module CLI

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/Blastp.BBH.Query",
               Info:="Using query fasta invoke blastp against the fasta files in a directory.
               * This command tools required of NCBI blast+ suite, you must config the blast bin path by using ``settings.exe`` before running this command.",
               Usage:="/Blastp.BBH.Query /query <query.fasta> /hit <hit.source> [/out <outDIR> /overrides /num_threads <-1>]")>
    <Argument("/query", False, CLITypes.File,
              AcceptTypes:={GetType(FastaFile)},
              Description:="The protein query fasta file.")>
    <Argument("/hit", False, CLITypes.File,
              AcceptTypes:={GetType(FastaFile)},
              Description:="A directory contains the protein sequence fasta files which will be using for bbh search.")>
    <Group(CLIGrouping.BBHTools)>
    Public Function BlastpBBHQuery(args As CommandLine) As Integer
        Dim [in] As String = args("/query")
        Dim subject As String = args("/hit")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & "-" & subject.BaseName & ".BBH_OUT/")
        Dim localBlast As New Programs.BLASTPlus(GCModeller.FileSystem.GetLocalblast)
        Dim blastp As BlastInvoker = localBlast.CreateInvokeHandle
        Dim [overrides] As Boolean = args.GetBoolean("/overrides")
        Dim nt As Integer = args.GetValue("/num_threads", -1)

        Call "Start [query ==> {Hits}] direction...".__DEBUG_ECHO
        Call ParallelTaskAPI.BatchBlastp(blastp, [in], subject, out, 10, [overrides], numThreads:=nt)
        Call "Start [{Hits} ==> query] direction...".__DEBUG_ECHO
        Call ParallelTaskAPI.BatchBlastpRev(localBlast, subject, [in], out, 10, [overrides], True, numThreads:=nt)

        Return 0
    End Function

    <ExportAPI("/Select.Meta", Usage:="/Select.Meta /in <meta.Xml> /bbh <bbh.csv> [/out <out.csv>]")>
    <Group(CLIGrouping.BBHTools)>
    Public Function SelectsMeta(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim bbh As String = args("/bbh")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & "." & bbh.BaseName & ".meta.Xml")
        Dim meta As Analysis.BestHit = [in].LoadXml(Of Analysis.BestHit)
        Dim bbhs As IEnumerable(Of BBHIndex) = bbh.LoadCsv(Of BBHIndex)
        Dim uids As IEnumerable(Of String) = (From x As BBHIndex In bbhs Select {x.HitName, x.QueryName}).IteratesALL.Distinct

        meta.hits = (From s As String
                     In uids
                     Let h As Analysis.HitCollection = meta.Hit(s)
                     Where Not h Is Nothing
                     Select h).ToArray
        Return meta.SaveAsXml(out).CLICode
    End Function

    <ExportAPI("/sbh2bbh",
               Usage:="/sbh2bbh /qvs <qvs.sbh.csv> /svq <svq.sbh.csv> [/identities <-1> /coverage <-1> /all /out <bbh.csv>]")>
    <Argument("/identities", True,
                   Description:="Makes a further filtering on the bbh by using this option, default value is -1, so that this means no filter.")>
    <Argument("/coverage", True,
                   Description:="Makes a further filtering on the bbh by using this option, default value is -1, so that this means no filter.")>
    <Group(CLIGrouping.BBHTools)>
    Public Function BBHExport2(args As CommandLine) As Integer
        Dim qvs As String = args("/qvs")
        Dim svq As String = args("/svq")
        Dim identities As Double = args.GetValue("/identities", -1.0R)
        Dim coverage As Double = args.GetValue("/coverage", -1.0R)
        Dim qsbh = qvs.LoadCsv(Of BestHit)
        Dim ssbh = svq.LoadCsv(Of BestHit)
        Dim all As Boolean = args.GetBoolean("/all")
        Dim bbh As BiDirectionalBesthit() = If(all,
            BBHParser.GetDirreBhAll2(qsbh.ToArray, ssbh.ToArray, identities, coverage),
            BBHParser.GetBBHTop(qsbh.ToArray, ssbh.ToArray, identities, coverage))
        Dim out As String =
            args.GetValue("/out", qvs.TrimSuffix & $"{If(all, "-all", "")},{identities},{coverage}.bbh.csv")
        Return bbh.SaveTo(out).CLICode
    End Function

    <ExportAPI("/SBH.BBH.Batch",
               Usage:="/SBH.BBH.Batch /in <sbh.DIR> [/identities <-1> /coverage <-1> /all /out <bbh.DIR> /num_threads <-1>]")>
    <Group(CLIGrouping.BBHTools)>
    Public Function SBH_BBH_Batch(args As CommandLine) As Integer
        Dim inDIR As String = args("/in")
        Dim identities As Double = args.GetValue("/identities", -1.0R)
        Dim coverage As Double = args.GetValue("/coverage", -1.0R)
        Dim isAll As String = If(args.GetBoolean("/all"), "/all", "")
        Dim outDIR As String = args.GetValue("/out", inDIR & ".BBH_OUT/")
        Dim files As IEnumerable(Of String) = ls - r - l - wildcards("*.csv") <= inDIR
        Dim entries = BuildBBHEntry(inDIR, "*.csv")
        Dim taskBuilder As Func(Of String, String, String) =
            Function(query, subject) _
                $"{GetType(CLI).API(NameOf(BBHExport2))} /qvs {query.CLIPath} /svq {subject.CLIPath} /identities {identities} /coverage {coverage} /out {outDIR & "/" & query.BaseName & ".bbh.csv"} {isAll}"
        Dim CLI As String() =
            LinqAPI.Exec(Of String) <= From x In entries Select taskBuilder(x.Key.FilePath, x.Value.FilePath)
        Dim numT As Integer = args.GetValue("/num_threads", -1)

        If numT <= 0 Then
            numT = LQuerySchedule.Recommended_NUM_THREADS
        End If

        Return App.SelfFolks(CLI, numT)
    End Function

    <ExportAPI("/bbh.Export",
               Usage:="/bbh.Export /query <query.blastp_out> /subject <subject.blast_out> [/trim /out <bbh.csv> /evalue 1e-3 /coverage 0.85 /identities 0.3]")>
    <Group(CLIGrouping.BBHTools)>
    Public Function BBHExportFile(args As CommandLine) As Integer
        Dim query As String = args("/query")
        Dim subject As String = args("/subject")
        Dim out As String = args.GetValue("/out", query.TrimSuffix & "_bbh.csv")
        Dim evalue As Double = args.GetValue("/evalue", 0.001)
        Dim coverage As Double = args.GetValue("/coverage", 0.85)
        Dim identities As Double = args.GetValue("/identities", 0.3)
        Dim trim As Boolean = args.GetBoolean("/trim")
        Dim sbhq = __sbhHelper(query, coverage, identities:=identities, trim:=trim)
        Dim sbhs = __sbhHelper(subject, coverage, identities, trim)
        Dim bbh = BBHParser.GetDirreBhAll2(sbhq, sbhs)
        Return bbh.SaveTo(out).CLICode
    End Function

    ''' <summary>
    ''' 主要是为了节省内存的需要
    ''' </summary>
    ''' <param name="out"></param>
    ''' <param name="coverage"></param>
    ''' <param name="identities"></param>
    ''' <returns></returns>
    Private Function __sbhHelper(out As String, coverage As Double, identities As Double, trim As Boolean) As BestHit()
        Dim queryOUT = BLASTOutput.BlastPlus.TryParseUltraLarge(out)

        If trim Then
            Dim script As TextGrepMethod =
                TextGrepScriptEngine.Compile("tokens ' ' first").Method
            Call queryOUT.Grep(script, script)
        End If

        Dim sbh = queryOUT.ExportAllBestHist(coverage, identities)
        Return sbh
    End Function

    <ExportAPI("/SBH.Trim", Usage:="/SBH.Trim /in <sbh.csv> /evalue <evalue> [/identities 0.15 /coverage 0.5 /out <out.csv>]")>
    <Group(CLIGrouping.BBHTools)>
    Public Function SBHTrim(args As CommandLine) As Integer
        Dim inFile As String = args("/in")
        Dim evalue As Double = args.GetDouble("/evalue")
        Dim out As String = args.GetValue("/out", inFile.TrimSuffix & "." & args("/evalue") & ".Csv")
        Dim readStream As New DocumentStream.Linq.DataStream(inFile)
        Dim coverage As Double = args.GetValue("/coverage", 0.5)
        Dim identities As Double = args.GetValue("/identities", 0.15)

        Using writeStream As New DocumentStream.Linq.WriteStream(Of BestHit)(out)

            Call $"Cutoffs ==>".__DEBUG_ECHO
            Call $"   {NameOf(coverage)}   := {coverage}".__DEBUG_ECHO
            Call $"   {NameOf(identities)} := {identities}".__DEBUG_ECHO
            Call $"   {NameOf(evalue)}     := {evalue}".__DEBUG_ECHO

            Call readStream.ForEachBlock(Of BestHit)(
                Sub(hits)
                    hits = (From x As BestHit
                            In hits
                            Where x.evalue <= evalue AndAlso
                                x.IsMatchedBesthit(identities, coverage) AndAlso
                                Not x.SelfHit
                            Select x).ToArray
                    Call writeStream.Flush(hits)
                End Sub)

            Return 0
        End Using
    End Function

    <ExportAPI("/BBH.Merge", Usage:="/BBH.Merge /in <inDIR> [/out <out.csv>]")>
    <Group(CLIGrouping.BBHTools)>
    Public Function MergeBBH(args As CommandLine) As Integer
        Dim inDIR As String = args("/in")
        Dim out As String = args.GetValue("/out", inDIR & ".bbh.Csv")
        Dim LQuery = (From file As String
                      In FileIO.FileSystem.GetFiles(inDIR, FileIO.SearchOption.SearchTopLevelOnly, "*.csv").AsParallel
                      Select file.LoadCsv(Of BiDirectionalBesthit)).Unlist
        Return LQuery.SaveTo(out)
    End Function

    ''' <summary>
    ''' 两两比对
    ''' </summary>
    ''' <returns></returns>
    '''
    <ExportAPI("/venn.BlastAll",
               Usage:="/venn.BlastAll /query <queryDIR> /out <outDIR> [/num_threads <-1> /evalue 10 /overrides /all /coverage <0.8> /identities <0.3>]",
               Info:="Completely paired combos blastp bbh operations for the venn diagram Or network builder.")>
    <Argument("/num_threads", True,
                   Description:="The number of the parallel blast task in this command, default value Is -1 which means the number of the blast threads Is determined by system automatically.")>
    <Argument("/all", True,
                   Description:="If this parameter Is represent, then all of the paired best hit will be export, otherwise only the top best will be export.")>
    <Argument("/query", False,
                   Description:="Recommended format of the fasta title Is that the fasta title only contains gene locus_tag.")>
    <Group(CLIGrouping.BBHTools)>
    Public Function vennBlastAll(args As CommandLine) As Integer
        Dim queryDIR As String = args("/query")
        Dim out As String = args("/out")
        Dim numThreads As Integer = args.GetValue("/num_threads", -1)
        Dim evalue As String = args.GetValue("/evalue", "10")
        Dim [overrides] As Boolean = args.GetBoolean("/overrides")

        If numThreads <= 0 Then
            numThreads = LQuerySchedule.Recommended_NUM_THREADS
        End If

        Dim blastapp As String = GCModeller.FileSystem.GetLocalblast
        Dim blastplus As New Programs.BLASTPlus(blastapp)
        Dim blastpHandle = blastplus.BuildBLASTP_InvokeHandle
        Dim outList = ParallelTask(queryDIR, out, evalue, blastpHandle, [overrides], numThreads)

        '  从这里开始导出最佳双向比对的结果
        Dim entryList = New List(Of AlignEntry)(outList).BuildBBHEntry
        Dim isAll As Boolean = args.GetBoolean("/all")
        Dim coverage As Double = args.GetValue("/coverage", 0.8)
        Dim identities As Double = args.GetValue("/identities", 0.3)

        Return entryList.__exportBBH(isAll, coverage, identities, "", outDIR:=out & "/BBH_OUT/")
    End Function

    <ExportAPI("/venn.BBH",
               Info:="2. Build venn table And bbh data from the blastp result out Or sbh data cache.",
               Usage:="/venn.BBH /imports <blastp_out.DIR> [/skip-load /query <queryName> /all /coverage <0.6> /identities <0.3> /out <outDIR>]")>
    <Argument("/skip-load", True,
                   Description:="If the data source in the imports directory Is already the sbh data source, then using this parameter to skip the blastp file parsing.")>
    <Group(CLIGrouping.BBHTools)>
    Public Function VennBBH(args As CommandLine) As Integer
        Dim importsDIR As String = args("/imports")
        Dim all As Boolean = args.GetBoolean("/all")
        Dim coverage As Double = args.GetValue("/coverage", 0.6)
        Dim identities As Double = args.GetValue("/identities", 0.3)
        Dim out As String = args.GetValue("/out", importsDIR & ".vennBBH/")
        Dim skipLoads As Boolean = args.GetBoolean("/skip-load")
        Dim sbhEntries As AlignEntry() = If(Not skipLoads, ExportLogData(importsDIR.LoadEntries, out & "/sbh/"), importsDIR.LoadEntries("*.csv"))
        Dim vennModel = ExportBidirectionalBesthit(sbhEntries, out & "/venn/")  ' 导出的是Top数据,  all的不好做
        Dim query As String = args.GetValue("/query", "")
        Dim VennTable As DocumentStream.File = DeltaMove(vennModel, query)
        Return VennTable > (out & "/Venn.Csv")
    End Function

    ''' <summary>
    ''' 导出单项最佳比对数据的工作线程
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/venn.sbh.thread",
               Usage:="/venn.sbh.thread /in <blastp.txt> [/out <out.sbh.csv> /coverage <0.6> /identities <0.3> /overrides]")>
    <Group(CLIGrouping.BBHTools)>
    Public Function SBHThread(args As CommandLine) As Integer
        Dim blastp As String = args("/in")
        Dim out As String = args.GetValue("/out", blastp.TrimSuffix & ".sbh.csv")
        Dim coverage As Double = args.GetValue("/coverage", 0.6)
        Dim identities As Double = args.GetValue("/identities", 0.3)
        Dim [overrides] As Boolean = args.GetBoolean("/overrides")

        If Not [overrides] Then
            If out.FileExists Then
                Return 0
            End If
        End If

        Dim logs As BlastPlus.v228 = BlastPlus.ParsingSizeAuto(blastp)
        Dim GrepMethod = TextGrepScriptEngine.Compile("tokens ' ' first").Method
        Dim GrepOperation As GrepOperation = New GrepOperation(GrepMethod, GrepMethod)
        Call GrepOperation.Grep(logs)
        Return logs.ExportAllBestHist(coverage, identities).SaveTo(out).CLICode
    End Function

    ''' <summary>
    ''' 1
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/venn.cache",
               Info:="1. [SBH_Batch] Creates the sbh cache data for the downstream bbh analysis. 
               And this batch function is suitable with any scale of the blastp sbh data output.",
               Usage:="/venn.cache /imports <blastp.DIR> [/out <sbh.out.DIR> /coverage <0.6> /identities <0.3> /num_threads <-1> /overrides]")>
    <Argument("/num_threads", True,
                   Description:="The number of the sub process thread. -1 value is stands for auto config by the system.")>
    <Group(CLIGrouping.BBHTools)>
    Public Function VennCache(args As CommandLine) As Integer
        Dim importsDIR As String = args("/imports")
        Dim coverage As Double = args.GetValue("/coverage", 0.6)
        Dim identities As Double = args.GetValue("/identities", 0.3)
        Dim out As String = args.GetValue("/out", importsDIR & ".venn-SBH/")
        Dim files As IEnumerable(Of String) = ls - l - r - wildcards("*.txt") <= importsDIR
        Dim [overrides] As String = If(args.GetBoolean("/overrides"), "/overrides", "")
        Dim taskBuilder As Func(Of String, String) =
            Function(blastp) _
                $"{GetType(CLI).API(NameOf(SBHThread))} /in {blastp.CLIPath} /out {(out & "/" & blastp.BaseName & ".csv").CLIPath} /coverage {coverage} /identities {identities} {[overrides]}"
        Dim CLI As String() =
            LinqAPI.Exec(Of String) <= From blastp As String
                                       In ls - l - r - wildcards("*.txt") <= importsDIR
                                       Select taskBuilder(blastp)
        Dim numT As Integer = args.GetValue("/num_threads", -1)

        If numT <= 0 Then
            numT = LQuerySchedule.Recommended_NUM_THREADS
        End If

        Return App.SelfFolks(CLI, numT)
    End Function

    <ExportAPI("/locus.Selects",
               Usage:="/locus.Selects /locus <locus.txt> /bh <bbhindex.csv> [/out <out.csv>]")>
    <Group(CLIGrouping.BBHTools)>
    Public Function LocusSelects(args As CommandLine) As Integer
        Dim [in] As String = args("/locus")
        Dim bh As String = args("/bh")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & $"-{bh.BaseName}.selects.Csv")
        Dim bbh As IEnumerable(Of BBHIndex) = bh.LoadCsv(Of BBHIndex)
        Dim locus As New IndexOf(Of String)([in].ReadAllLines)
        Dim LQuery = (From x In bbh.AsParallel Where locus.IndexOf(x.QueryName) > -1 Select x).ToArray
        Return LQuery.SaveTo(out).CLICode
    End Function

    <ExportAPI("/Export.Locus", Usage:="/Export.Locus /in <sbh/bbh_DIR> [/hit /out <out.txt>]")>
    <Group(CLIGrouping.BBHTools)>
    Public Function ExportLocus(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim isHit As Boolean = args.GetBoolean("/hit")
        Dim out As String = args.GetValue("/out", [in] & "-" & If(isHit, "hit_name", "query_name") & ".txt")
        Dim source As IEnumerable(Of BBHIndex) =
            (ls - l - r - wildcards("*.csv") <= [in]).Select(AddressOf LoadCsv(Of BBHIndex)).IteratesALL
        Dim locus As String()
        Dim getName As Func(Of BBHIndex, String)
        Dim test As Func(Of BBHIndex, Boolean)

        If isHit Then
            getName = Function(x) x.HitName
            test = Function(x) Not String.IsNullOrEmpty(x.HitName) AndAlso
                Not String.Equals(IBlastOutput.HITS_NOT_FOUND, x.HitName)
        Else
            getName = Function(x) x.QueryName
            test = Function(x) Not String.IsNullOrEmpty(x.QueryName) AndAlso
                Not String.Equals(IBlastOutput.HITS_NOT_FOUND, x.QueryName)
        End If

        locus =
            LinqAPI.Exec(Of String) <= From x As BBHIndex
                                       In source
                                       Where test(x)
                                       Select getName(x)
                                       Distinct

        Return locus.FlushAllLines(out, Encodings.ASCII).CLICode
    End Function
End Module
