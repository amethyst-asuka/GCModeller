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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SMRUCC.genomics.Resources", GetType(Resources).Assembly)
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
        '''  查找类似 +D	Biochemical compound
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Compounds with Biological Roles&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08001
        '''#NAME        Metabolite
        '''#DEFINITION  Compounds with biological roles
        '''#---&gt;
        '''!
        '''A&lt;b&gt;Organic acids&lt;/b&gt;
        '''B  Carboxylic acids [Fig]
        '''C    Monocarboxylic acids
        '''D      C00058  Formate; Methanoate
        '''D      C00033  Acetate; Ethanoate
        '''D      C00163  Propionate; Propanoate
        '''D      C00246  Butyrate; Butanoate
        '''D      C00803  Valerate; Pentano [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08001() As String
            Get
                Return ResourceManager.GetString("br08001", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +E	Lipid
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Lipids&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08002
        '''#NAME        Lipid
        '''#DEFINITION  Lipids
        '''#---&gt;
        '''!
        '''A&lt;b&gt;FA  Fatty acyls&lt;/b&gt;
        '''B  FA01 Fatty Acids and Conjugates
        '''C    FA0101 Straight chain fatty acids
        '''D      C00058  Formic acid
        '''D      C00033  Acetic acid
        '''D      C00163  Propanoic acid
        '''D      C00246  Butanoic acid
        '''D      C00803  Pentanoic acid
        '''D      C01585  Hexanoic acid
        '''D      C17714  Heptanoic acid
        '''D      C06423  Oct [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08002() As String
            Get
                Return ResourceManager.GetString("br08002", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +D
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Phytochemical Compounds&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08003
        '''#NAME        Phytochemical Compounds
        '''#DEFINITION  Phytochemical Compounds
        '''#---&gt;
        '''!
        '''A&lt;b&gt;Alkaloids&lt;/b&gt;
        '''B  Alkaloids derived from ornithine
        '''C    Pyrrolidine alkaloids
        '''D      C06179  Hygrine
        '''D      C11359  (-)-Hygrine
        '''D      C06521  Cuscohygrine
        '''D      C10152  (-)-Hygroline
        '''D      C10172  Stachydrine
        '''D      C08283  Homostachydrine
        '''D      C10151  3-Hydroxyst [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08003() As String
            Get
                Return ResourceManager.GetString("br08003", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +C	Peptide
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Bioactive Peptides&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08005
        '''#NAME        Peptide
        '''#DEFINITION  Bioactive Peptides
        '''#---&gt;
        '''!
        '''A&lt;b&gt;Neuropeptides&lt;/b&gt;
        '''B  Tachykinin
        '''C    C16094  Substance P
        '''C    C16095  Neuropeptide K
        '''C    C16096  Neuropeptide gamma
        '''C    C16097  Neurokinin A
        '''C    C16098  Neurokinin B
        '''C    C16099  Endokinin A/B
        '''C    C16100  Endokinin C
        '''C    C16101  Endokinin D
        '''B  Neurotensin
        '''C    C01836  Neurotensin
        ''' [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08005() As String
            Get
                Return ResourceManager.GetString("br08005", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +C	Environmental compound
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt; &amp;nbsp; Endocrine Disrupting Compounds&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08006
        '''#NAME        EDC
        '''#DEFINITION  Endocrine disrupting compounds
        '''#---&gt;
        '''!
        '''A&lt;b&gt;Pesticides and herbicides&lt;/b&gt;
        '''B  Carbamate pesticides
        '''C    C11015  Aldicarb
        '''C    C10896  Benlate
        '''C    C07491  Carbaryl
        '''C    C11196  Methomyl
        '''C    C10981  Vinclozolin
        '''B  Dithiocarbamate pesticides
        '''C    C15225  Mancozeb
        '''C    C15231  Maneb
        '''C    C18144   [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08006() As String
            Get
                Return ResourceManager.GetString("br08006", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +D
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Pesticides&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08007
        '''#NAME        Pesticides
        '''#DEFINITION  Pesticides
        '''#---&gt;
        '''!
        '''A&lt;b&gt;Pesticides&lt;/b&gt;
        '''B  Fungicides
        '''C    Aliphatic nitrogen fungicides
        '''D      C18498  Cymoxanil
        '''D      C18723  Dodine
        '''D      C18568  Iminoctadine acetate
        '''C    Amide fungicides
        '''D      C18581  Amisulbrom
        '''D      C10929  Benalaxyl
        '''D      C18547  Boscalid
        '''D      C11255  Carboxin
        '''D      C10932  Carpropamid
        '''D      C1857 [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08007() As String
            Get
                Return ResourceManager.GetString("br08007", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +C	Carcinogen	Cancer site
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Carcinogens&lt;/h2&gt;
        '''%&lt;style type=&quot;text/css&quot;&gt;&lt;!--#grid{table-layout:fixed;font-family:monospace;position:relative;color:black;width:1000px;}.col1{position:relative;background:white;z-index:1;overflow:hidden;width:600px;}.col2{position:relative;background:white;z-index:2;padding-left:10px;}--&gt;&lt;/style&gt;
        '''#&lt;!---
        '''#ENTRY       br08008
        '''#NAME        Carcinogen
        '''#DEFINITION  Carcinogens
        '''#---&gt;
        '''!
        '''A&lt;b&gt;G [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08008() As String
            Get
                Return ResourceManager.GetString("br08008", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +D
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Natural toxins&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08009
        '''#NAME        Natural toxins
        '''#DEFINITION  Natural toxins
        '''#---&gt;
        '''!
        '''A&lt;b&gt;Fungal toxins&lt;/b&gt;
        '''B  Mushroom toxins
        '''C    Alkaloids
        '''D      C07473  Muscarine
        '''D      C08311  Muscimol
        '''D      C19959  Orellanine
        '''D      C08312  Psilocin
        '''D      C07576  Psilocybin
        '''C    Cyclic peptides
        '''D      C08438  alpha-Amanitin
        '''D      C08439  Phalloidin
        '''C    Terpenoids
        '''D      C19957  Fasciculol [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08009() As String
            Get
                Return ResourceManager.GetString("br08009", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +E	Compound	Remark
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Target-based Classification of Compounds&lt;/h2&gt;
        '''%&lt;style type=&quot;text/css&quot;&gt;&lt;!--#grid{table-layout:fixed;font-family:monospace;position:relative;color:black;width:1000px;}.col1{position:relative;background:white;z-index:1;overflow:hidden;width:600px;}.col2{position:relative;background:white;z-index:2;padding-left:10px;}--&gt;&lt;/style&gt;
        '''#&lt;!---
        '''#ENTRY       br08010
        '''#DEFINITION  Target-based classification [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08010() As String
            Get
                Return ResourceManager.GetString("br08010", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +E	Reaction
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Enzymatic Reactions&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08201
        '''#DEFINITION  Enzymatic reactions
        '''#---&gt;
        '''!
        '''A&lt;b&gt;1. Oxidoreductase reactions&lt;/b&gt;
        '''B  1.1  Acting on the CH-OH group of donors
        '''C    1.1.1  With NAD+ or NADP+ as acceptor
        '''D      1.1.1.1
        '''E        R00623  Primary alcohol + NAD+ &lt;=&gt; Aldehyde + NADH + H+
        '''E        R00624  Secondary alcohol + NAD+ &lt;=&gt; Ketone + NADH + H+
        '''E        R00754  Ethanol + NAD+ &lt;=&gt; Acet [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08201() As String
            Get
                Return ResourceManager.GetString("br08201", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +D	Reaction	Substrate	Product	Substrate2	Product2
        '''%&lt;style type=&quot;text/css&quot;&gt;&lt;!--#grid{table-layout:fixed;font-family:monospace;position:relative;color:black;width:1400px;}.col1{position:relative;background:white;z-index:1;overflow:hidden;width:200px;}.col2{position:relative;background:white;z-index:2;padding-left:10px;overflow:hidden;width:300px;}.col3{position:relative;background:white;z-index:3;padding-left:10px;overflow:hidden;width:300px;}.col4{position:relative;background:white;z-index:2;padding-left:10p [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08202() As String
            Get
                Return ResourceManager.GetString("br08202", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +B	Glycosyltransferase reaction
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt; &amp;nbsp; Glycosyltransferase Reactions&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08203
        '''#DEFINITION  Glycosyltransferase reactions
        '''#---&gt;
        '''!
        '''A&lt;b&gt;Glucosyltransferase reactions&lt;/b&gt;
        '''B  R06264  Glc a1-2 Glc [KO:K03850] [PATH:rn00510]
        '''B  R03118  Glc a1-3 Glc [KO:K00706] [PATH:rn00500]
        '''B  R06263  Glc a1-3 Glc [KO:K03849] [PATH:rn00510]
        '''B  R00292  Glc a1-4 Glc [KO:K00693] [PATH:rn00500]
        '''B  R06184  Glc a1-6 Glc
        '''B [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08203() As String
            Get
                Return ResourceManager.GetString("br08203", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +U
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; KEGG Organisms in the NCBI Taxonomy&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08610
        '''#DEFINITION  KEGG Organisms in the NCBI taxonomy
        '''#---&gt;
        '''!
        '''AEukaryota
        '''B  Metazoa
        '''C    Chordata
        '''D      Craniata
        '''E        Vertebrata
        '''F          Euteleostomi
        '''G            Mammalia
        '''H              Eutheria
        '''I                Euarchontoglires
        '''J                  Primates
        '''K                    Haplorrhini
        '''L                      Catarrhini
        '''M              [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08610() As String
            Get
                Return ResourceManager.GetString("br08610", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +C	Map number
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; KEGG Pathway Maps&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08901
        '''#NAME        Pathway
        '''#DEFINITION  KEGG pathway maps
        '''#---&gt;
        '''!
        '''A&lt;b&gt;Metabolism&lt;/b&gt;
        '''B  Global and overview maps
        '''C    01100  Metabolic pathways
        '''C    01110  Biosynthesis of secondary metabolites
        '''C    01120  Microbial metabolism in diverse environments
        '''C    01130  Biosynthesis of antibiotics
        '''C    01200  Carbon metabolism
        '''C    01210  2-Oxocarboxylic acid m [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property br08901() As String
            Get
                Return ResourceManager.GetString("br08901", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 use Bio::DB::GenBank;
        '''use Bio::Seq;
        '''
        '''# Download and search gbk
        '''my $gb     = new Bio::DB::GenBank(); 
        '''my $gbk    = $gb-&gt;get_Seq_by_acc(&apos;[$ACCESSION_ID]&apos;); 
        '''my $seq_io = Bio::SeqIO-&gt;new(-format =&gt; &apos;genbank&apos;, -file =&gt; &quot;&gt;[$SAVED_FILE]&quot;);
        '''
        '''# Call Write FileStream 
        '''$seq_io-&gt;write_seq($gbk); 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property GenBankQuery() As String
            Get
                Return ResourceManager.GetString("GenBankQuery", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +D	KO
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt; &amp;nbsp; KEGG Orthology (KO) - All Categories&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       ko00000
        '''#NAME        KO_all
        '''#DEFINITION  KEGG Orthology (KO) - all categories
        '''#---&gt;
        '''!
        '''A09100 Metabolism
        '''B
        '''B  09101 Carbohydrate metabolism
        '''C    00010 Glycolysis / Gluconeogenesis [PATH:ko00010]
        '''D      K00844  HK; hexokinase
        '''D      K12407  GCK; glucokinase
        '''D      K00845  glk; glucokinase
        '''D      K01810  GPI, pgi; glucose-6-phosphate isomerase
        '''D  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property ko00000() As String
            Get
                Return ResourceManager.GetString("ko00000", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +D	KO
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt; &amp;nbsp; KEGG Orthology (KO)&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       ko00001
        '''#NAME        KO
        '''#DEFINITION  KEGG Orthology (KO)
        '''#---&gt;
        '''!
        '''A&lt;b&gt;Metabolism&lt;/b&gt;
        '''B
        '''B  &lt;b&gt;Overview&lt;/b&gt;
        '''C    01200 Carbon metabolism [PATH:ko01200]
        '''D      K00844  HK; hexokinase [EC:2.7.1.1]
        '''D      K12407  GCK; glucokinase [EC:2.7.1.2]
        '''D      K00845  glk; glucokinase [EC:2.7.1.2]
        '''D      K00886  ppgK; polyphosphate glucokinase [EC:2.7.1.63]
        '''D      K08074  ADPG [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property ko00001() As String
            Get
                Return ResourceManager.GetString("ko00001", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 +E	Module
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; KEGG Modules&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       ko00002
        '''#NAME        Module
        '''#DEFINITION  KEGG modules
        '''#---&gt;
        '''!
        '''A&lt;b&gt;Pathway module&lt;/b&gt;
        '''B
        '''B  &lt;b&gt;Energy metabolism&lt;/b&gt;
        '''C    Carbon fixation
        '''D      M00165  Reductive pentose phosphate cycle (Calvin cycle) [PATH:map01200 map00710]
        '''E        K00855  PRK, prkB; phosphoribulokinase [EC:2.7.1.19]
        '''E        K01601  rbcL; ribulose-bisphosphate carboxylase large ch [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property ko00002_keg() As String
            Get
                Return ResourceManager.GetString("ko00002_keg", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 Pfam AccessionId,Signaling domain ID,Domain name,Kind,Function,Marker
        '''PF01339,CheB_methylest,CheB_methylest,chemotaxis,Chemotaxis,Yes
        '''PF04509,CheC,CheC,chemotaxis,Chemotaxis,Yes
        '''PF03975,CheD,CheD,chemotaxis,Chemotaxis,Yes
        '''PF01739,CheR,CheR,chemotaxis,Chemotaxis,Yes
        '''PF03705,CheR_N,CheR_N,chemotaxis,Chemotaxis,Yes
        '''PF01584,CheW,CheW,chemotaxis,Chemotaxis,Yes
        '''PF09078,CheY-binding,CheY-binding,chemotaxis,Chemotaxis,Yes
        '''PF04344,CheZ,CheZ,chemotaxis,Chemotaxis,Yes
        '''PF02895,H-kinase_dim,H-kinase_dim,chemota [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property MiST2() As String
            Get
                Return ResourceManager.GetString("MiST2", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 Test 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property String1() As String
            Get
                Return ResourceManager.GetString("String1", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=1
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA * Ter  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu i    CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr   [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_1() As String
            Get
                Return ResourceManager.GetString("transl_table_1", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=10
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA C Cys  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_10() As String
            Get
                Return ResourceManager.GetString("transl_table_10", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=11
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA * Ter  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu i    CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile i    ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_11() As String
            Get
                Return ResourceManager.GetString("transl_table_11", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=12
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA * Ter  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG S Ser i    CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_12() As String
            Get
                Return ResourceManager.GetString("transl_table_12", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=13
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_13() As String
            Get
                Return ResourceManager.GetString("transl_table_13", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=14
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA Y Tyr      TGA W Trp  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_14() As String
            Get
                Return ResourceManager.GetString("transl_table_14", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=16
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA * Ter  
        '''TTG L Leu      TCG S Ser      TAG L Leu      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_16() As String
            Get
                Return ResourceManager.GetString("transl_table_16", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=2
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile i    ACT T Thr   [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_2() As String
            Get
                Return ResourceManager.GetString("transl_table_2", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=21
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_21() As String
            Get
                Return ResourceManager.GetString("transl_table_21", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=22
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA * Ter      TAA * Ter      TGA * Ter  
        '''TTG L Leu      TCG S Ser      TAG L Leu      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_22() As String
            Get
                Return ResourceManager.GetString("transl_table_22", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=23
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA * Ter      TCA S Ser      TAA * Ter      TGA * Ter  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile i    ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_23() As String
            Get
                Return ResourceManager.GetString("transl_table_23", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=24
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu i    CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_24() As String
            Get
                Return ResourceManager.GetString("transl_table_24", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=25
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA G Gly  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_25() As String
            Get
                Return ResourceManager.GetString("transl_table_25", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=3
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT T Thr      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC T Thr      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA T Thr      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG T Thr      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr   [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_3() As String
            Get
                Return ResourceManager.GetString("transl_table_3", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=4
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu i    TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu i    CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile i    ACT T Thr   [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_4() As String
            Get
                Return ResourceManager.GetString("transl_table_4", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=5
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile i    ACT T Thr   [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_5() As String
            Get
                Return ResourceManager.GetString("transl_table_5", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=6
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA Q Gln      TGA * Ter  
        '''TTG L Leu      TCG S Ser      TAG Q Gln      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr   [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_6() As String
            Get
                Return ResourceManager.GetString("transl_table_6", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 transl_table=9
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr   [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend ReadOnly Property transl_table_9() As String
            Get
                Return ResourceManager.GetString("transl_table_9", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
