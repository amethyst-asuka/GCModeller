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
''' 对蛋白质的GO功能注释的信息关联表
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protein_go`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_go` (
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) NOT NULL,
'''   `go_id` int(10) unsigned NOT NULL,
'''   `GO_term` varchar(45) NOT NULL COMMENT 'GO编号',
'''   `term_name` tinytext,
'''   `namespace_id` int(10) unsigned NOT NULL,
'''   `namespace` char(32) DEFAULT NULL,
'''   PRIMARY KEY (`hash_code`,`go_id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='对蛋白质的GO功能注释的信息关联表';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_go", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `protein_go` (
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) NOT NULL,
  `go_id` int(10) unsigned NOT NULL,
  `GO_term` varchar(45) NOT NULL COMMENT 'GO编号',
  `term_name` tinytext,
  `namespace_id` int(10) unsigned NOT NULL,
  `namespace` char(32) DEFAULT NULL,
  PRIMARY KEY (`hash_code`,`go_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='对蛋白质的GO功能注释的信息关联表';")>
Public Class protein_go: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("hash_code"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code"), XmlAttribute> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), NotNull, DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("go_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="go_id"), XmlAttribute> Public Property go_id As Long
''' <summary>
''' GO编号
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("GO_term"), NotNull, DataType(MySqlDbType.VarChar, "45"), Column(Name:="GO_term")> Public Property GO_term As String
    <DatabaseField("term_name"), DataType(MySqlDbType.Text), Column(Name:="term_name")> Public Property term_name As String
    <DatabaseField("namespace_id"), NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="namespace_id")> Public Property namespace_id As Long
    <DatabaseField("namespace"), DataType(MySqlDbType.VarChar, "32"), Column(Name:="namespace")> Public Property [namespace] As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protein_go` (`hash_code`, `uniprot_id`, `go_id`, `GO_term`, `term_name`, `namespace_id`, `namespace`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protein_go` (`hash_code`, `uniprot_id`, `go_id`, `GO_term`, `term_name`, `namespace_id`, `namespace`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protein_go` WHERE `hash_code`='{0}' and `go_id`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protein_go` SET `hash_code`='{0}', `uniprot_id`='{1}', `go_id`='{2}', `GO_term`='{3}', `term_name`='{4}', `namespace_id`='{5}', `namespace`='{6}' WHERE `hash_code`='{7}' and `go_id`='{8}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protein_go` WHERE `hash_code`='{0}' and `go_id`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, hash_code, go_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protein_go` (`hash_code`, `uniprot_id`, `go_id`, `GO_term`, `term_name`, `namespace_id`, `namespace`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, go_id, GO_term, term_name, namespace_id, [namespace])
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{hash_code}', '{uniprot_id}', '{go_id}', '{GO_term}', '{term_name}', '{namespace_id}', '{[namespace]}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_go` (`hash_code`, `uniprot_id`, `go_id`, `GO_term`, `term_name`, `namespace_id`, `namespace`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, go_id, GO_term, term_name, namespace_id, [namespace])
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protein_go` SET `hash_code`='{0}', `uniprot_id`='{1}', `go_id`='{2}', `GO_term`='{3}', `term_name`='{4}', `namespace_id`='{5}', `namespace`='{6}' WHERE `hash_code`='{7}' and `go_id`='{8}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, hash_code, uniprot_id, go_id, GO_term, term_name, namespace_id, [namespace], hash_code, go_id)
    End Function
#End Region
Public Function Clone() As protein_go
                  Return DirectCast(MyClass.MemberwiseClone, protein_go)
              End Function
End Class


End Namespace
