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
''' 这个表主要是为了加快整个数据库的查询效率而建立的冗余表，在这里为每一个uniport accession编号都赋值了一个唯一编号，然后利用这个唯一编号就可以实现对其他数据表之中的数据的快速查询了
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `hash_table`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `hash_table` (
'''   `hash_code` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '每一个字符串形式的uniprot数据库编号都有一个唯一的哈希值编号',
'''   `uniprot_id` char(32) NOT NULL COMMENT 'uniprot数据库编号首先会在这个表之中进行查找，得到自己唯一的哈希值结果，然后再根据这个哈希值去快速的查找其他的表之中的结果',
'''   `name` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`uniprot_id`),
'''   UNIQUE KEY `uniprot_id_UNIQUE` (`uniprot_id`),
'''   UNIQUE KEY `hash_code_UNIQUE` (`hash_code`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='这个表主要是为了加快整个数据库的查询效率而建立的冗余表，在这里为每一个uniport accession编号都赋值了一个唯一编号，然后利用这个唯一编号就可以实现对其他数据表之中的数据的快速查询了';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("hash_table", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `hash_table` (
  `hash_code` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '每一个字符串形式的uniprot数据库编号都有一个唯一的哈希值编号',
  `uniprot_id` char(32) NOT NULL COMMENT 'uniprot数据库编号首先会在这个表之中进行查找，得到自己唯一的哈希值结果，然后再根据这个哈希值去快速的查找其他的表之中的结果',
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`uniprot_id`),
  UNIQUE KEY `uniprot_id_UNIQUE` (`uniprot_id`),
  UNIQUE KEY `hash_code_UNIQUE` (`hash_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='这个表主要是为了加快整个数据库的查询效率而建立的冗余表，在这里为每一个uniport accession编号都赋值了一个唯一编号，然后利用这个唯一编号就可以实现对其他数据表之中的数据的快速查询了';")>
Public Class hash_table: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
''' <summary>
''' 每一个字符串形式的uniprot数据库编号都有一个唯一的哈希值编号
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("hash_code"), AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code")> Public Property hash_code As Long
''' <summary>
''' uniprot数据库编号首先会在这个表之中进行查找，得到自己唯一的哈希值结果，然后再根据这个哈希值去快速的查找其他的表之中的结果
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("uniprot_id"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "32"), Column(Name:="uniprot_id"), XmlAttribute> Public Property uniprot_id As String
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="name")> Public Property name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `hash_table` (`hash_code`, `uniprot_id`, `name`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `hash_table` (`hash_code`, `uniprot_id`, `name`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `hash_table` WHERE `uniprot_id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `hash_table` SET `hash_code`='{0}', `uniprot_id`='{1}', `name`='{2}' WHERE `uniprot_id` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `hash_table` WHERE `uniprot_id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, uniprot_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `hash_table` (`hash_code`, `uniprot_id`, `name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, name)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{hash_code}', '{uniprot_id}', '{name}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `hash_table` (`hash_code`, `uniprot_id`, `name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, name)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `hash_table` SET `hash_code`='{0}', `uniprot_id`='{1}', `name`='{2}' WHERE `uniprot_id` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, hash_code, uniprot_id, name, uniprot_id)
    End Function
#End Region
Public Function Clone() As hash_table
                  Return DirectCast(MyClass.MemberwiseClone, hash_table)
              End Function
End Class


End Namespace
