REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2017/9/3 6:01:02


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports System.Xml.Serialization

Namespace kb_UniProtKB.mysql

''' <summary>
''' ```SQL
''' 对这个蛋白质的文献报道数据
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protein_reference`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_reference` (
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) DEFAULT NULL,
'''   `reference_id` int(10) unsigned NOT NULL,
'''   `scope` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`hash_code`,`reference_id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='对这个蛋白质的文献报道数据';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_reference", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `protein_reference` (
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) DEFAULT NULL,
  `reference_id` int(10) unsigned NOT NULL,
  `scope` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`hash_code`,`reference_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='对这个蛋白质的文献报道数据';")>
Public Class protein_reference: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("hash_code"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code"), XmlAttribute> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("reference_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="reference_id"), XmlAttribute> Public Property reference_id As Long
    <DatabaseField("scope"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="scope")> Public Property scope As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protein_reference` (`hash_code`, `uniprot_id`, `reference_id`, `scope`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protein_reference` (`hash_code`, `uniprot_id`, `reference_id`, `scope`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protein_reference` WHERE `hash_code`='{0}' and `reference_id`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protein_reference` SET `hash_code`='{0}', `uniprot_id`='{1}', `reference_id`='{2}', `scope`='{3}' WHERE `hash_code`='{4}' and `reference_id`='{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protein_reference` WHERE `hash_code`='{0}' and `reference_id`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, hash_code, reference_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protein_reference` (`hash_code`, `uniprot_id`, `reference_id`, `scope`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, reference_id, scope)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{hash_code}', '{uniprot_id}', '{reference_id}', '{scope}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_reference` (`hash_code`, `uniprot_id`, `reference_id`, `scope`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, reference_id, scope)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protein_reference` SET `hash_code`='{0}', `uniprot_id`='{1}', `reference_id`='{2}', `scope`='{3}' WHERE `hash_code`='{4}' and `reference_id`='{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, hash_code, uniprot_id, reference_id, scope, hash_code, reference_id)
    End Function
#End Region
Public Function Clone() As protein_reference
                  Return DirectCast(MyClass.MemberwiseClone, protein_reference)
              End Function
End Class


End Namespace
