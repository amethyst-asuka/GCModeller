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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SMRUCC.genomics.Interops.CARMEN.Resources", GetType(Resources).Assembly)
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
        '''  Looks up a localized string similar to 
        '''&lt;!-- saved from url=(0059)https://carmen.cebitec.uni-bielefeld.de/cgi-bin/execute.cgi --&gt;
        '''&lt;html&gt;&lt;head&gt;&lt;meta http-equiv=&quot;Content-Type&quot; content=&quot;text/html; charset=windows-1252&quot;&gt;
        '''
        '''&lt;title&gt;CARMEN&lt;/title&gt;
        '''&lt;link rel=&quot;stylesheet&quot; type=&quot;text/css&quot; href=&quot;./CARMEN_files/carmen.css&quot;&gt;
        '''
        '''&lt;script src=&quot;./CARMEN_files/jquery-1.11.2.min.js&quot;&gt;&lt;/script&gt;
        '''
        '''&lt;script type=&quot;text/javascript&quot;&gt;
        '''var main = function() {
        '''	$(&quot;#topnav li:has(ul)&quot;).hover(function(){
        '''		$(this).find(&quot;ul&quot;).show();
        '''	}, function(){
        '''		$(this).find(&quot;ul&quot;).hide();
        '''	}) [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property CARMEN() As String
            Get
                Return ResourceManager.GetString("CARMEN", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property CarmenConfig() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("CarmenConfig", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property GetNCBIData() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("GetNCBIData", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property GetSpeciesData() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("GetSpeciesData", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property GetXMLData() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("GetXMLData", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property KEGG_Information() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("KEGG_Information", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to #!/vol/perl-5.8.8/bin/perl
        '''
        '''#
        '''#  Copyright (C) 2010 CeBiTec, Bielefeld University
        '''#
        '''#  This library is free software; you can redistribute it and/or
        '''#  modify it under the terms of the GNU General Public License
        '''#  version 2 as published by the Free Software Foundation.
        '''#
        '''#  This file is distributed in the hope that it will be useful,
        '''#  but WITHOUT ANY WARRANTY; without even the implied warranty of
        '''#  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
        '''#  General Public License for [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property KGML_reconstruction() As String
            Get
                Return ResourceManager.GetString("KGML_reconstruction", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property LICENSE() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("LICENSE", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to C00001	H2O	Water			
        '''C00002	ATP	Adenosine 5&apos;-triphosphate			
        '''C00003	NAD+	Nicotinamide adenine dinucleotide			
        '''C00004	NADH	1,4-Dihydronicotinamide adenine dinucleotide	DPNH		
        '''C00005	NADPH	Dihydronicotinamide adenine dinucleotide phosphate	TPNH		
        '''C00006	NADP+	Nicotinamide adenine dinucleotide phosphate			
        '''C00008	ADP	Adenosine 5&apos;-diphosphate			
        '''C00009	P	Phosphate			
        '''C00011	CO2	Carbon dioxide			
        '''C00016	FAD	Flavin adenine dinucleotide			
        '''C01352	FADH2				
        '''C00020	AMP	Adenosine 5&apos;-monophosphate			
        '''C00575 [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property metabolite_abbreviations() As String
            Get
                Return ResourceManager.GetString("metabolite_abbreviations", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property ReactionData() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("ReactionData", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to C00001	H2O	Water			
        '''C00002	ATP	Adenosine 5&apos;-triphosphate			
        '''C00003	NAD+	Nicotinamide adenine dinucleotide			
        '''C00004	NADH	1,4-Dihydronicotinamide adenine dinucleotide	DPNH		
        '''C00005	NADPH	Dihydronicotinamide adenine dinucleotide phosphate	TPNH		
        '''C00006	NADP+	Nicotinamide adenine dinucleotide phosphate			
        '''C00008	ADP	Adenosine 5&apos;-diphosphate			
        '''C00009	P	Phosphate			
        '''C00011	CO2	Carbon dioxide			
        '''C00016	FAD	Flavin adenine dinucleotide			
        '''C01352	FADH2				
        '''C00020	AMP	Adenosine 5&apos;-monophosphate			
        '''C00575 [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property shortcuts() As String
            Get
                Return ResourceManager.GetString("shortcuts", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property WriteSBML2_1_CellDesigner() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("WriteSBML2_1_CellDesigner", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property WriteSBML2_4() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("WriteSBML2_4", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property WriteSBML2_4_CellDesigner() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("WriteSBML2_4_CellDesigner", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property WriteSBML3_1() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("WriteSBML3_1", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
    End Module
End Namespace