﻿'------------------------------------------------------------------------------
' <auto-generated>
'     此代码由工具生成。
'     运行时版本:4.0.30319.42000
'
'     对此文件的更改可能会导致不正确的行为，并且如果
'     重新生成代码，这些更改将会丢失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    '此类是由 StronglyTypedResourceBuilder
    '类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    '若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    '(以 /str 作为命令选项)，或重新生成 VS 项目。
    '''<summary>
    '''  一个强类型的资源类，用于查找本地化的字符串等。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  返回此类使用的缓存的 ResourceManager 实例。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Microsoft.VisualBasic.Scripting.ShoalShell.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  使用此强类型资源类，为所有资源查找
        '''  重写当前线程的 CurrentUICulture 属性。
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
        '''  查找类似                     GNU GENERAL PUBLIC LICENSE
        '''                       Version 3, 29 June 2007
        '''
        ''' Copyright (C) 2007 Free Software Foundation, Inc. &lt;http://fsf.org/&gt;
        ''' Everyone is permitted to copy and distribute verbatim copies
        ''' of this license document, but changing it is not allowed.
        '''
        '''                            Preamble
        '''
        '''  The GNU General Public License is a free, copyleft license for
        '''software and other kinds of works.
        '''
        '''  The licenses for most software and other practical works are designed
        '''to [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property gpl() As String
            Get
                Return ResourceManager.GetString("gpl", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 &lt;!DOCTYPE html&gt;
        '''
        '''&lt;html lang=&quot;en&quot;&gt;
        '''
        '''	&lt;head&gt;
        '''		
        '''		&lt;meta charset=&quot;utf-8&quot;&gt;
        '''		&lt;title&gt;GCModeller ShoalShell Document Library&lt;/title&gt;
        '''        &lt;link rel=&quot;shortcut icon&quot; href=&quot;http://gcmodeller.org/DNA.ico&quot; /&gt; 
        '''		&lt;style&gt;::-moz-selection {
        '''        background: #b3d4fc;
        '''        text-shadow: none;
        '''      }
        '''
        '''      ::selection {
        '''        background: #b3d4fc;
        '''        text-shadow: none;
        '''      }
        '''
        '''      html {
        '''        padding: 30px 10px;
        '''        font-size: 16px;
        '''        line-height: 1.4;
        '''        color: #7 [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property index() As String
            Get
                Return ResourceManager.GetString("index", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 This program is free software: you can redistribute it and/or modify
        '''it under the terms of the GNU General Public License as published by
        '''the Free Software Foundation, either version 3 of the License, or
        '''any later version.
        '''
        '''This program is distributed in the hope that it will be useful,
        '''but WITHOUT ANY WARRANTY; without even the implied warranty of
        '''MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
        '''GNU General Public License for more details.
        '''
        '''You should have received a copy of the GNU  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property license() As String
            Get
                Return ResourceManager.GetString("license", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 &lt;!DOCTYPE html&gt;
        '''
        '''&lt;html lang=&quot;en&quot;&gt;
        '''
        '''	&lt;head&gt;
        '''		
        '''		&lt;meta charset=&quot;utf-8&quot;&gt;
        '''		&lt;title&gt;%Namespace%&lt;/title&gt;
        '''        &lt;link rel=&quot;shortcut icon&quot; href=&quot;http://gcmodeller.org/DNA.ico&quot; /&gt; 
        '''		&lt;style&gt;::-moz-selection {
        '''        background: #b3d4fc;
        '''        text-shadow: none;
        '''      }
        '''
        '''      ::selection {
        '''        background: #b3d4fc;
        '''        text-shadow: none;
        '''      }
        '''
        '''      html {
        '''        padding: 30px 10px;
        '''        font-size: 16px;
        '''        line-height: 1.4;
        '''        color: #737373;
        '''        background: [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property sdk_doc() As String
            Get
                Return ResourceManager.GetString("sdk_doc", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找 System.Byte[] 类型的本地化资源。
        '''</summary>
        Friend ReadOnly Property Shoal() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("Shoal", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 &lt;!DOCTYPE html&gt;
        '''
        '''&lt;html lang=&quot;en&quot;&gt;
        '''
        '''	&lt;head&gt;
        '''		
        '''		&lt;meta charset=&quot;utf-8&quot;&gt;
        '''		&lt;title&gt;%Type%&lt;/title&gt;
        '''        &lt;link rel=&quot;shortcut icon&quot; href=&quot;http://gcmodeller.org/DNA.ico&quot; /&gt; 
        '''		&lt;style&gt;::-moz-selection {
        '''        background: #b3d4fc;
        '''        text-shadow: none;
        '''      }
        '''
        '''      ::selection {
        '''        background: #b3d4fc;
        '''        text-shadow: none;
        '''      }
        '''
        '''      html {
        '''        padding: 30px 10px;
        '''        font-size: 16px;
        '''        line-height: 1.4;
        '''        color: #737373;
        '''        background: #f0f [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property typeLinks_doc() As String
            Get
                Return ResourceManager.GetString("typeLinks_doc", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
