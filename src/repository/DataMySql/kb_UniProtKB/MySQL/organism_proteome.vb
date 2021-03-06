REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2017/9/3 12:29:35


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports System.Xml.Serialization

Namespace kb_UniProtKB.mysql

''' <summary>
''' ```SQL
''' 这个表之中列举出了某一个物种其基因组之中所拥有的蛋白质的集合
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `organism_proteome`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `organism_proteome` (
'''   `org_id` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) DEFAULT NULL,
'''   `id_hashcode` int(10) unsigned NOT NULL,
'''   `gene_name` varchar(45) DEFAULT NULL,
'''   `proteomes_id` varchar(45) DEFAULT NULL COMMENT 'Proteomes蛋白组数据库之中的编号',
'''   `component` varchar(45) DEFAULT NULL COMMENT '染色体编号',
'''   PRIMARY KEY (`org_id`,`id_hashcode`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='这个表之中列举出了某一个物种其基因组之中所拥有的蛋白质的集合';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("organism_proteome", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `organism_proteome` (
  `org_id` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) DEFAULT NULL,
  `id_hashcode` int(10) unsigned NOT NULL,
  `gene_name` varchar(45) DEFAULT NULL,
  `proteomes_id` varchar(45) DEFAULT NULL COMMENT 'Proteomes蛋白组数据库之中的编号',
  `component` varchar(45) DEFAULT NULL COMMENT '染色体编号',
  PRIMARY KEY (`org_id`,`id_hashcode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='这个表之中列举出了某一个物种其基因组之中所拥有的蛋白质的集合';")>
Public Class organism_proteome: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("org_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="org_id"), XmlAttribute> Public Property org_id As Long
    <DatabaseField("uniprot_id"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("id_hashcode"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="id_hashcode"), XmlAttribute> Public Property id_hashcode As Long
    <DatabaseField("gene_name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="gene_name")> Public Property gene_name As String
''' <summary>
''' Proteomes蛋白组数据库之中的编号
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("proteomes_id"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="proteomes_id")> Public Property proteomes_id As String
''' <summary>
''' 染色体编号
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("component"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="component")> Public Property component As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `organism_proteome` (`org_id`, `uniprot_id`, `id_hashcode`, `gene_name`, `proteomes_id`, `component`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `organism_proteome` (`org_id`, `uniprot_id`, `id_hashcode`, `gene_name`, `proteomes_id`, `component`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `organism_proteome` WHERE `org_id`='{0}' and `id_hashcode`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `organism_proteome` SET `org_id`='{0}', `uniprot_id`='{1}', `id_hashcode`='{2}', `gene_name`='{3}', `proteomes_id`='{4}', `component`='{5}' WHERE `org_id`='{6}' and `id_hashcode`='{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `organism_proteome` WHERE `org_id`='{0}' and `id_hashcode`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, org_id, id_hashcode)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `organism_proteome` (`org_id`, `uniprot_id`, `id_hashcode`, `gene_name`, `proteomes_id`, `component`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, org_id, uniprot_id, id_hashcode, gene_name, proteomes_id, component)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{org_id}', '{uniprot_id}', '{id_hashcode}', '{gene_name}', '{proteomes_id}', '{component}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `organism_proteome` (`org_id`, `uniprot_id`, `id_hashcode`, `gene_name`, `proteomes_id`, `component`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, org_id, uniprot_id, id_hashcode, gene_name, proteomes_id, component)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `organism_proteome` SET `org_id`='{0}', `uniprot_id`='{1}', `id_hashcode`='{2}', `gene_name`='{3}', `proteomes_id`='{4}', `component`='{5}' WHERE `org_id`='{6}' and `id_hashcode`='{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, org_id, uniprot_id, id_hashcode, gene_name, proteomes_id, component, org_id, id_hashcode)
    End Function
#End Region
Public Function Clone() As organism_proteome
                  Return DirectCast(MyClass.MemberwiseClone, organism_proteome)
              End Function
End Class


End Namespace
