﻿#Region "Microsoft.VisualBasic::8e9ba5312a6bffc0b4c88d6e7f637e2f, ..\GCModeller\analysis\SequenceToolkit\SequenceTools\CLI\Palindrome.vb"

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

Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO.Linq
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Parallel
Imports Microsoft.VisualBasic.Parallel.Linq
Imports Microsoft.VisualBasic.Parallel.Threads
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Text
Imports SMRUCC.genomics.Analysis.SequenceTools.SequencePatterns
Imports SMRUCC.genomics.Analysis.SequenceTools.SequencePatterns.Topologically
Imports SMRUCC.genomics.Analysis.SequenceTools.SequencePatterns.Topologically.SimilarityMatches
Imports SMRUCC.genomics.Assembly.NCBI
Imports SMRUCC.genomics.Assembly.NCBI.GenBank
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.TabularFormat.ComponentModels
Imports SMRUCC.genomics.ComponentModel.Loci
Imports SMRUCC.genomics.ContextModel
Imports SMRUCC.genomics.SequenceModel
Imports SMRUCC.genomics.SequenceModel.FASTA

Partial Module Utilities

    <ExportAPI("/Loci.describ",
               Info:="Testing",
               Usage:="/Loci.describ /ptt <genome-context.ptt> [/test <loci:randomize> /complement /unstrand]")>
    Public Function LociDescript(args As CommandLine) As Integer
        Dim PTT = GenBank.TabularFormat.PTT.Load(args("/ptt"))
        Dim test As Integer = args.GetValue("/test", PTT.Size * Rnd())
        Dim complement As Boolean = args.GetBoolean("/complement")
        Dim loci As New NucleotideLocation(test, test + 30, complement)
        Dim unstrand As Boolean = args.GetBoolean("/unstrand")
        Dim lst = PTT.GetRelatedGenes(loci, unstrand)

        For Each g As Relationship(Of GeneBrief) In lst
            Call g.__DEBUG_ECHO
        Next

        Return 0
    End Function

    <ExportAPI("--Palindrome.From.NT",
               Info:="This function is just for debugger test, /nt parameter is the nucleotide sequence data as ATGCCCC",
               Usage:="--Palindrome.From.NT /nt <nt-sequence> /out <out.csv> [/min <3> /max <20>]")>
    <Argument("/out", True, AcceptTypes:={(GetType(PalindromeLoci))})>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function SearchPalindromeNT(args As CommandLine) As Integer
        Dim NT As New FastaToken With {
            .SequenceData = args("/nt"),
            .Attributes = {"auto"}
        }
        Dim Out As String = args("/out")
        Dim Min As Integer = args.GetValue("/min", 3)
        Dim Max As Integer = args.GetValue("/max", 20)
        Dim Search As New Topologically.PalindromeSearch(NT, Min, Max)
        Call Search.DoSearch()
        Call Search.ResultSet.SaveTo(Out)
        Return 0
    End Function

    <ExportAPI("--Palindrome.From.FASTA",
               Usage:="--Palindrome.From.Fasta /nt <nt-sequence.fasta> [/out <out.csv> /min <3> /max <20>]")>
    <Argument("/nt", False,
                   Description:="Fasta sequence file, and this file should just contains only one sequence.",
                   AcceptTypes:={GetType(FastaToken)})>
    <Argument("/out", True, AcceptTypes:={(GetType(PalindromeLoci))})>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function SearchPalindromeFasta(args As CommandLine) As Integer
        Dim nt As FastaToken = FastaToken.Load(args("/nt"))
        Dim Out As String = args.GetValue("/out", args("/nt").TrimSuffix & ".csv")
        Dim Min As Integer = args.GetValue("/min", 3)
        Dim Max As Integer = args.GetValue("/max", 20)
        Dim Search As New Topologically.PalindromeSearch(nt, Min, Max)
        Call Search.DoSearch()
        Call Search.ResultSet.SaveTo(Out)
        Return 0
    End Function

    ''' <summary>
    ''' 同一条链上面的镜像回文
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("--Mirror.From.NT",
               Usage:="--Mirror.From.NT /nt <nt-sequence> /out <out.csv> [/min <3> /max <20>]",
               Info:="Mirror Palindrome, and this function is for the debugging test")>
    <Argument("/out", True, AcceptTypes:={(GetType(PalindromeLoci))})>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function SearchMirrotNT(args As CommandLine) As Integer
        Dim NT As New FastaToken With {
           .SequenceData = args("/nt"),
           .Attributes = {"auto"}
        }
        Dim Out As String = args("/out")
        Dim Min As Integer = args.GetValue("/min", 3)
        Dim Max As Integer = args.GetValue("/max", 20)
        Dim Search As New Topologically.MirrorPalindrome(NT, Min, Max)
        Call Search.DoSearch()
        Call Search.ResultSet.SaveTo(Out)
        Return 0
    End Function

    <ExportAPI("/Mirrors.Nt.Trim", Usage:="/Mirrors.Nt.Trim /in <mirrors.Csv> [/out <out.Csv>]")>
    <Argument("/out", True, AcceptTypes:={(GetType(PalindromeLoci))})>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function TrimNtMirrors(args As CommandLine) As Integer
        Dim [in] As String = args.GetFullFilePath("/in")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & "." & NameOf(TrimNtMirrors) & ".Csv")
        Dim data As IEnumerable(Of PalindromeLoci) = [in].LoadCsv(Of PalindromeLoci)
        Dim invalids As Char() = ISequenceModel.AA_CHARS_ALL
        Dim result As PalindromeLoci() = LinqAPI.Exec(Of PalindromeLoci) <=
            From x As PalindromeLoci
            In data
            Where x.Loci.IndexOfAny(invalids) = -1 AndAlso
                x.Palindrome.IndexOfAny(invalids) = -1 AndAlso
                x.MirrorSite.IndexOfAny(invalids) = -1
            Select x

        Return result.SaveTo(out).CLICode
    End Function

    <ExportAPI("/Mirror.Fuzzy",
               Usage:="/Mirror.Fuzzy /in <in.fasta> [/out <out.csv> /cut 0.6 /max-dist 6 /min 3 /max 20]")>
    <Argument("/in", False, AcceptTypes:={GetType(FastaToken)})>
    <Argument("/out", True, AcceptTypes:={GetType(PalindromeLoci)})>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function FuzzyMirrors(args As CommandLine) As Integer
        Dim [in] As String = args - "/in"
        Dim cut As Double = args.GetValue("/cut", 0.6)
        Dim maxDist As Integer = args.GetValue("/max-dist", 6)
        Dim min As Integer = args.GetValue("/min", 3)
        Dim max As Integer = args.GetValue("/max", 20)
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & $".cut,{cut}-dist,{maxDist}-min,max={min},{max}.Csv")
        Dim nt As New FastaToken([in])
        Dim search As New FuzzyMirrors(nt, min, max, maxDist, cut)
        Call search.DoSearch()
        Call search.ResultSet.SaveTo(out)

        Return 0
    End Function

    <ExportAPI("/Mirror.Fuzzy.Batch",
               Usage:="/Mirror.Fuzzy.Batch /in <in.fasta/DIR> [/out <out.DIR> /cut 0.6 /max-dist 6 /min 3 /max 20 /num_threads <-1>]")>
    <Argument("/out", True, AcceptTypes:={(GetType(PalindromeLoci))})>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function FuzzyMirrorsBatch(args As CommandLine) As Integer
        Dim [in] As String = args - "/in"
        Dim cut As Double = args.GetValue("/cut", 0.6)
        Dim maxDist As Integer = args.GetValue("/max-dist", 6)
        Dim min As Integer = args.GetValue("/min", 3)
        Dim max As Integer = args.GetValue("/max", 20)
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & $".cut,{cut}-dist,{maxDist}-min,max={min},{max}/")
        Dim nt As IEnumerable(Of FastaToken) =
            StreamIterator.SeqSource([in], {"*.fasta", "*.fsa", "*.fa", "*.fna", "*.fas"})
        Dim CLI As New List(Of String)
        Dim n As Integer = args.GetValue("/num_threads", -1)

        For Each fa As FastaToken In nt
            Dim tmp As String = App.GetAppSysTempFile(".fasta")
            Dim path As String = out & "/" & fa.Title.NormalizePathString(True).Replace(" ", "_") & ".Csv"

            Call fa.SaveTo(tmp)

            CLI += $"{GetType(Utilities).API(NameOf(FuzzyMirrors))} /in {tmp.CLIPath} /out {path.CLIPath} /cut {cut} /max-dist {maxDist} /min {min} /max {max}"
        Next

        Return App.SelfFolks(CLI, LQuerySchedule.AutoConfig(n))
    End Function

    <ExportAPI("/Mirror.Batch",
               Usage:="/Mirror.Batch /nt <nt.fasta> [/out <out.csv> /mp /min <3> /max <20> /num_threads <-1>]")>
    <Argument("/mp", True,
                   Description:="Calculation in the multiple process mode?",
                   AcceptTypes:={GetType(Boolean)})>
    <Argument("/nt", False, AcceptTypes:={GetType(FastaFile)})>
    <Argument("/out", True, AcceptTypes:={GetType(PalindromeLoci)})>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function MirrorBatch(args As CommandLine) As Integer
        Dim NT As New FastaFile(args - "/nt")
        Dim out As String = args.GetValue("/out", args("/nt").TrimSuffix & "-Mirror/")
        Dim Min As Integer = args.GetValue("/min", 3)
        Dim Max As Integer = args.GetValue("/max", 20)
        Dim n As Integer = args.GetValue("/num_threads", -1)

        n = LQuerySchedule.AutoConfig(n)

        If args.GetBoolean("/mp") Then
            Dim api As String = GetType(Utilities).API(NameOf(SearchMirrotFasta))
            Dim task As Func(Of String, String) =
                Function(path) $"{api} /nt {path.CLIPath} /out {(out & "/" & path.BaseName & ".csv").CLIPath} /min {Min} /max {Max}"
            Dim CLI As String() =
                LinqAPI.Exec(Of String) <= From fa As FastaToken
                                           In NT
                                           Let norm As String = fa.Title.NormalizePathString(True).Replace(" ", "_")
                                           Let path As String = App.AppSystemTemp & $"/{norm}.fasta"
                                           Let save As Boolean = fa.Save(path, Encodings.ASCII)
                                           Select task(path)
            Call App.SelfFolks(CLI, n)
        Else
            For Each seq As FastaToken In NT
                Dim Search As New Topologically.MirrorPalindrome(seq, Min, Max)
                Dim path As String = out & $"/{seq.Title.NormalizePathString.Replace(" ", "_")}.csv"
                Call Search.DoSearch()
                Call Search.ResultSet.SaveTo(path)
            Next
        End If

        Return 0
    End Function

    ''' <summary>
    ''' 同一条链上面的镜像回文
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("--Mirror.From.Fasta",
               Usage:="--Mirror.From.Fasta /nt <nt-sequence.fasta> [/out <out.csv> /min <3> /max <20>]",
               Info:="Mirror Palindrome, search from a fasta file.")>
    <Argument("/nt", False,
                   Description:="This fasta file should contains only just one sequence.",
                   AcceptTypes:={GetType(FastaToken)})>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function SearchMirrotFasta(args As CommandLine) As Integer
        Dim Nt = FastaToken.Load(args("/nt"))
        Dim Out As String = args.GetValue("/out", args("/nt").TrimSuffix & ".csv")
        Dim Min As Integer = args.GetValue("/min", 3)
        Dim Max As Integer = args.GetValue("/max", 20)
        Dim Search As New Topologically.MirrorPalindrome(Nt, Min, Max)
        Call Search.DoSearch()
        Return Search.ResultSet.SaveTo(Out).CLICode
    End Function

    ''' <summary>
    ''' 主要是搜索可能的酶切位点
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("--Palindrome.batch.Task",
               Usage:="--Palindrome.batch.Task /in <in.fasta> /out <outDir> [/min <3> /max <20> /num_threads <-1>]")>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function BatchSearchPalindrome(args As CommandLine) As Integer
        Dim input As String = args("/in")
        Dim outDIR As String = args("/out")
        Dim min As Integer = args.GetValue("/min", 3)
        Dim max As Integer = args.GetValue("/max", 20)
        Dim Fasta As FastaFile = FastaFile.Read(input)
        Dim numThreads As Integer = args.GetValue("/num_threads", -1)

        Call BatchTask(Fasta,
                       getCLI:=Function(fa) __palindromeTask(fa, outDIR, min, max),
                       getExe:=Function() App.ExecutablePath,
                       numThreads:=numThreads)
        Return 0
    End Function

    ''' <summary>
    ''' 搜索可能的酶切位点
    ''' </summary>
    ''' <param name="fasta"></param>
    ''' <param name="EXPORT"></param>
    ''' <param name="min"></param>
    ''' <param name="max"></param>
    ''' <returns></returns>
    Private Function __palindromeTask(fasta As FastaToken, EXPORT As String, min As Integer, max As Integer) As String
        Dim csv As String = $"{EXPORT}/{fasta.Title.NormalizePathString(True)}.csv"
        Dim Temp As String = App.GetAppSysTempFile(".fasta", App.PID)
        Dim CLI As String = $"--Palindrome.From.Fasta /nt {Temp.CLIPath} /out {csv.CLIPath} /min {min} /max {max}"
        Call fasta.SaveTo(Temp)

        Return CLI
    End Function

    ''' <summary>
    ''' 主要是搜索可能的RNA发卡结构的形成位点
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("--ImperfectsPalindrome.batch.Task",
               Usage:="--ImperfectsPalindrome.batch.Task /in <in.fasta> /out <outDir> [/min <3> /max <20> /cutoff <0.6> /max-dist <1000 (bp)> /num_threads <-1>]")>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function BatchSearchImperfectsPalindrome(args As CommandLine) As Integer
        Dim input As String = args("/in")
        Dim out As String = args("/out")
        Dim min As Integer = args.GetValue("/min", 3)
        Dim max As Integer = args.GetValue("/max", 20)
        Dim cutoff As Double = args.GetValue("/cutoff", 0.6)
        Dim maxDist As Integer = args.GetValue("/max-dist", 1000)
        Dim Fasta = FastaFile.Read(input)
        Dim numThreads As Integer = args.GetValue("/num_threads", -1)

        Call BatchTask(Fasta,
                       getCLI:=Function(fa) __imperfectsPalindromeTask(fa, out, min, max, cutoff, maxDist),
                       getExe:=Function() App.ExecutablePath,
                       numThreads:=numThreads)
        Return 0
    End Function

    ''' <summary>
    ''' 搜索可能的RNA发卡结构
    ''' </summary>
    ''' <param name="fasta"></param>
    ''' <param name="EXPORT"></param>
    ''' <param name="min"></param>
    ''' <param name="max"></param>
    ''' <param name="cutoff"></param>
    ''' <param name="maxDist"></param>
    ''' <returns></returns>
    Private Function __imperfectsPalindromeTask(fasta As FastaToken,
                                                EXPORT As String,
                                                min As Integer,
                                                max As Integer,
                                                cutoff As Double,
                                                maxDist As Integer) As String
        Dim csv As String = $"{EXPORT}/{fasta.Title.NormalizePathString(True)}.csv"
        Dim Temp As String = App.GetAppSysTempFile(".fasta")
        Dim CLI As String =
            $"--Palindrome.Imperfects /in {Temp.CLIPath} /out {csv.CLIPath} /min {min} /max {max} /cutoff {cutoff} /max-dist {maxDist}"
        Call fasta.SaveTo(Temp)

        Return CLI
    End Function

    <ExportAPI("--Palindrome.Imperfects",
               Usage:="--Palindrome.Imperfects /in <in.fasta> [/out <out.csv> /min <3> /max <20> /cutoff <0.6> /max-dist <1000 (bp)> /partitions <-1>]")>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function ImperfectPalindrome(args As CommandLine) As Integer
        Dim input As String = args("/in")
        Dim out As String = args.GetValue("/out", input.TrimSuffix & ".csv")
        Dim min As Integer = args.GetValue("/min", 3)
        Dim max As Integer = args.GetValue("/max", 20)
        Dim inFasta As FastaToken
        Dim cutoff As Double = args.GetValue("/cutoff", 0.6)
        Dim maxDist As Integer = args.GetValue("/max-dist", 1000)
        Dim partitions As Integer = args.GetValue("/partitions", -1)

        If input.FileExists Then
            inFasta = FastaToken.Load(input)
        Else
            inFasta = New FASTA.FastaToken With {
                .SequenceData = input,
                .Attributes = {"auto-generated"}
            }
        End If

        Dim search As New Topologically.Imperfect(inFasta, min, max, cutoff, maxDist, partitions)
        Call search.DoSearch()
        Return search.ResultSet.SaveTo(out)
    End Function

    ''' <summary>
    ''' /num_threads &lt;-1>: -1表示使用系统自动分配的参数值
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("--Hairpinks.batch.task",
               Usage:="--Hairpinks.batch.task /in <in.fasta> [/out <outDIR> /min <6> /max <7> /cutoff <0.6> /max-dist <35 (bp)> /num_threads <-1>]")>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function HairpinksBatch(args As CommandLine) As Integer
        Dim input As String = args("/in")
        Dim out As String = args.GetValue("/out", App.CurrentDirectory & "/Hairpinks/")
        Dim min As Integer = args.GetValue("/min", 6)
        Dim max As Integer = args.GetValue("/max", 7)
        Dim cutoff As Double = args.GetValue("/cutoff", 0.6)
        Dim maxDist As Integer = args.GetValue("/max-dist", 35)
        Dim inFasta As New FastaFile(input)

        For Each fa As FastaToken In inFasta
            Dim path As String = out & "/" & fa.Title.NormalizePathString & ".csv"
            If Not fa.SearchHairpinks(min, max, cutoff, maxDist).SaveTo(path) Then
                Throw New Exception(fa.GetJson)
            End If
        Next

        Return 0
    End Function

    Private Function __hairpinksCLI(fasta As FastaToken,
                                    EXPORT As String,
                                    min As Integer,
                                    max As Integer,
                                    cutoff As Double,
                                    maxDist As Integer) As String
        Dim csv As String = $"{EXPORT}/{fasta.Title.NormalizePathString(True)}.csv"
        Dim Temp As String = App.GetAppSysTempFile(".fasta", App.PID)
        Dim CLI As String = $"--Hairpinks /in {Temp.CLIPath} /out {csv.CLIPath} /min {min} /max {max} /cutoff {cutoff} /max-dist {maxDist}"
        Call fasta.SaveTo(Temp)

        Return CLI
    End Function

    <ExportAPI("/Palindrome.Screen.MaxMatches.Batch",
               Usage:="/Palindrome.Screen.MaxMatches.Batch /in <inDIR> /min <min.max-matches> [/out <out.DIR> /num_threads <-1>]")>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function FilteringMatchesBatch(args As CommandLine) As Integer
        Dim [in] As String = args - "/in"
        Dim min As Integer = args.GetInt32("/min")
        Dim out As String = args.GetValue("/out", [in].TrimDIR & "-min." & min & "/")
        Dim CLI As New List(Of String)
        Dim n As Integer = args.GetValue("/num_threads", -1)

        For Each file As String In ls - l - r - wildcards("*.csv") <= [in]
            CLI += $"{GetType(Utilities).API(NameOf(FilteringMatches))} /in {file.CLIPath} /min {min} /out {(out & "/" & file.BaseName & ".Csv").CLIPath}"
        Next

        Return App.SelfFolks(CLI, LQuerySchedule.AutoConfig(n))
    End Function

    <ExportAPI("/Palindrome.Screen.MaxMatches",
               Usage:="/Palindrome.Screen.MaxMatches /in <in.csv> /min <min.max-matches> [/out <out.csv>]")>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function FilteringMatches(args As CommandLine) As Integer
        Dim [in] As String = args - "/in"
        Dim min As Integer = args.GetInt32("/min")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & "-min." & min & ".csv")

        If FileIO.FileSystem.GetFileInfo([in]).Length > 1024 * 1024 * 16 Then
            ' 大文件
            Using writer As New WriteStream(Of ImperfectPalindrome)(out)
                Dim buf As DataStream = DataStream.OpenHandle([in])
                Call buf.ForEachBlock(Of ImperfectPalindrome)(
                    Sub(array)
                        Dim data As IEnumerable(Of ImperfectPalindrome) =
                            LinqAPI.MakeList(Of ImperfectPalindrome) <= From x As ImperfectPalindrome
                                                                        In array
                                                                        Where x.MaxMatch >= min
                                                                        Select x
                        Call writer.Flush(data)
                    End Sub)

                Return 0
            End Using
        Else
            Dim data As IEnumerable(Of ImperfectPalindrome) =
                LinqAPI.MakeList(Of ImperfectPalindrome) <= From x As ImperfectPalindrome
                                                            In [in].LoadCsv(Of Topologically.ImperfectPalindrome)
                                                            Where x.MaxMatch >= min
                                                            Select x
            Return data.SaveTo(out).CLICode
        End If
    End Function

    <ExportAPI("--PerfectPalindrome.Filtering",
               Usage:="--PerfectPalindrome.Filtering /in <inDIR> [/min <8> /out <outDIR>]")>
    <Argument("/out", True, AcceptTypes:={GetType(ImperfectPalindrome)})>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function FilterPerfectPalindrome(args As CommandLine) As Integer
        Dim LQuery = (From file As String
                      In FileIO.FileSystem.GetFiles(args("/in"), FileIO.SearchOption.SearchTopLevelOnly, "*.csv")
                      Select file,
                          hrp = file.LoadCsv(Of Topologically.ImperfectPalindrome)).ToArray
        Dim Cut As Integer = args.GetValue("/min", 8)
        Dim Filter = (From x In LQuery
                      Select x.file,
                          perfects = (From loci As Topologically.ImperfectPalindrome
                                      In x.hrp.AsParallel
                                      Where loci.Palindrome.Count("-"c) <> loci.Palindrome.Length AndAlso
                                          loci.Site.Count("-"c) <> loci.Site.Length AndAlso
                                          loci.MaxMatch >= Cut
                                      Select loci).ToArray).ToArray
        Dim out As String = args.GetValue("/out", App.CurrentDirectory & "/Perfects/")

        For Each file In Filter
            Dim name As String = BaseName(file.file)
            Dim path As String = $"{out}/{name}.csv"
            Call file.perfects.SaveTo(path)
        Next

        Return True
    End Function

    <ExportAPI("--Hairpinks",
               Usage:="--Hairpinks /in <in.fasta> [/out <out.csv> /min <6> /max <7> /cutoff 3 /max-dist <35 (bp)>]")>
    <Argument("/out", True, AcceptTypes:={GetType(ImperfectPalindrome)})>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function Hairpinks(args As CommandLine) As Integer
        Dim input As String = args("/in")
        Dim out As String = args.GetValue("/out", input.TrimSuffix & ".hairpink.csv")
        Dim min As Integer = args.GetValue("/min", 6)
        Dim max As Integer = args.GetValue("/max", 7)
        Dim cutoff As Integer = args.GetValue("/cutoff", 3)
        Dim maxDist As Integer = args.GetValue("/max-dist", 35)
        Dim inFasta As FastaToken = FastaToken.Load(input)
        Dim resultSet = inFasta.SearchHairpinks(min, max, cutoff, maxDist)
        Return resultSet.SaveTo(out)
    End Function

    <ExportAPI("--ToVector",
               Usage:="--ToVector /in <in.DIR> /min <4> /max <8> /out <out.txt> /size <genome.size>")>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function ToVector(args As CommandLine) As Integer
        Dim inDIR As String = args("/in")
        Dim min = args.GetInt32("/min")
        Dim max = args.GetInt32("/max")
        Dim out As String = args("/out")
        Dim size As Integer = args.GetInt32("/size")
        Dim vector = Topologically.Palindrome.ImperfectPalindromeVector(inDIR, size, min, max)
        Return vector.ToArray(Function(n) CStr(n)).FlushAllLines(out).CLICode
    End Function

    <ExportAPI("/Mirror.Vector",
               Usage:="/Mirror.Vector /in <inDIR> /size <genome.size> [/out out.txt]")>
    <Group(CLIGrouping.PalindromeTools)>
    Public Function MirrorsVector(args As CommandLine) As Integer
        Dim inDIR As String = args("/in")
        Dim out As String = args.GetValue("/out", inDIR.TrimDIR & ".Mirror.Vector.txt")
        Dim files As IEnumerable(Of String) = ls - l - r - wildcards("*.csv") <= inDIR
        Dim size As Integer = args.GetInt32("/size")
        Dim Loads = (From path As String
                     In files
                     Select path.BaseName,
                         data = path.LoadCsv(Of PalindromeLoci)) _
                         .ToDictionary(Function(x) x.BaseName,
                                       Function(x) x.data)
        Dim result As Double() = Topologically.Palindrome.Density(Loads.Values, size)
        Return result.FlushAllLines(out)
    End Function

    <ExportAPI("/Promoter.Regions.Palindrome",
               Usage:="/Promoter.Regions.Palindrome /in <genbank.gb> [/min <3> /max <20> /len <100,150,200,250,300,400,500, default:=250> /mirror /out <out.csv>]")>
    <Argument("/mirror", True, CLITypes.Boolean,
              AcceptTypes:={GetType(Boolean)},
              Description:="Search for the mirror palindrome loci sites.")>
    Public Function PromoterRegionPalindrome(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim min% = args.GetValue("/min", 3)
        Dim max% = args.GetValue("/max", 20)
        Dim len% = args.GetValue("/len", 250)
        Dim mirror As Boolean = args.GetBoolean("/mirror")
        Dim out$ = args.GetValue(
            "/out",
            [in].TrimSuffix & $"_min={min},max={max},upstream=-{len}bp.palindrome{If(mirror, "-mirror", "")}.csv")
        Dim gb As GBFF.File = GBFF.File.Load([in])
        Dim parser As New PromoterRegionParser(gb.Origin.ToFasta, gb.GbkffExportToPTT)
        Dim source As New FastaFile(parser.GetRegionCollectionByLength(len).Values)
        Dim output As New List(Of PalindromeLoci)

        For Each promoter As FastaToken In source
            Call promoter.Title.__DEBUG_ECHO

            If mirror Then
                output += promoter.SearchMirrorPalindrome(min, max, promoter.Title)
            Else
                output += promoter.SearchPalindrome(min, max, promoter.Title)
            End If
        Next

        Return output.SaveTo(out, Encodings.ASCII).CLICode
    End Function

    <ExportAPI("/Promoter.Palindrome.Fasta",
               Usage:="/Promoter.Palindrome.Fasta /in <palindrome.csv> [/out <out.fasta>]")>
    Public Function PromoterPalindrome2Fasta(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & ".fasta")
        Dim palindromes = [in].LoadCsv(Of PalindromeLoci)
        Dim output As New List(Of FastaToken)
        Dim tag$

        For Each site As PalindromeLoci In palindromes
            tag = site.Data("tag")
            output += New FastaToken With {
                .Attributes = {
                    tag.Split.First & $" {site.Start}..{site.PalEnd}",
                    tag
                },
                .SequenceData = site.SequenceData
            }
        Next

        Return New FastaFile(output).Save(out, Encodings.ASCII).CLICode
    End Function
End Module
