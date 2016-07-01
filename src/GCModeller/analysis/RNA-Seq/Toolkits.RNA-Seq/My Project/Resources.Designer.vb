﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SMRUCC.genomics.Analysis.RNA_Seq.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ##################################################################################
        '''# BaSAR package 
        '''# Emma Granqvist, Matthew Hartley and Richard J Morris
        '''##################################################################################
        '''
        '''require(polynom)
        '''require(orthopolynom)
        '''
        '''##################################################################################
        '''# Basic functions
        '''##################################################################################
        '''
        '''.BSA.linspace &lt;- function(vstart, ve [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property BaSAR() As String
            Get
                Return ResourceManager.GetString("BaSAR", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ## RNA-seq analysis with DESeq2
        '''## xie.guigang xie.guigang@gcmodeller.org
        '''
        '''# RNA-seq data from GSE52202
        '''# http://www.ncbi.nlm.nih.gov/geo/query/acc.cgi?acc=gse52202. All patients with
        '''# ALS, 4 with C9 expansion (&quot;exp&quot;), 4 controls without expansion (&quot;ctl&quot;)
        '''
        '''
        '''
        '''
        '''
        '''# Import &amp; pre-process ----------------------------------------------------
        '''
        '''# Import data from raw featureCounts
        '''countData &lt;- read.csv(&quot;{countData.MAT.csv}&quot;)
        '''
        '''# Remove first columns (geneID)
        '''countData &lt;- countData[ ,2:ncol(countData [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property DEseq2_Template() As String
            Get
                Return ResourceManager.GetString("DEseq2_Template", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property filter() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("filter", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to library(&apos;DESeq2&apos;)
        '''
        '''dir.source                  &lt;- &quot;&lt;DIR.Source&gt;&quot;,
        '''
        '''sampleFiles                 &lt;- c(&lt;*.SAM_FILE_LIST&gt;);
        '''sampleCondition             &lt;- c(&lt;Conditions_Corresponding_TO_SampleFiles&gt;);
        '''sampleTable                 &lt;- data.frame(sampleName=sampleFiles, fileName=sampleFiles, condition=sampleCondition)
        '''ddsHTSeq                    &lt;- DESeqDataSetFromHTSeqCount(sampleTable=sampleTable, directory=dir.source, design=~condition)
        '''colData(ddsHTSeq)$condition &lt;- factor(colData(ddsHTSeq)$condition, l [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property Invoke_DESeq2() As String
            Get
                Return ResourceManager.GetString("Invoke_DESeq2", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property onLoad() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("onLoad", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property pfsnet() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("pfsnet", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property pfsnet_not_rJava() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("pfsnet_not_rJava", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to # inits variables
        '''
        '''# If necessary, change the path below to the directory where the data files are stored.
        '''# &quot;.&quot; means current directory. On Windows use a forward slash / instead of the usual \.
        '''    workingDir = &quot;[WORK]&quot;;
        '''       exprCsv = &quot;[dataExpr]&quot;;
        '''       TOMsave = &quot;[TOMsave]&quot;;
        ''' annotationCsv = &quot;[Annotations.csv]&quot;;
        '''   
        '''# Display the current working directory
        '''getwd();
        '''setwd(workingDir);
        '''
        '''# Load the package
        '''library(WGCNA);
        '''library(flashClust);
        '''
        '''# The following setting is important, do not [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property WGCNA() As String
            Get
                Return ResourceManager.GetString("WGCNA", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
