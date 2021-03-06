REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:24:24 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `object_synonym`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `object_synonym` (
'''   `object_id` char(12) NOT NULL,
'''   `object_synonym_name` varchar(255) NOT NULL,
'''   `os_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("object_synonym", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `object_synonym` (
  `object_id` char(12) NOT NULL,
  `object_synonym_name` varchar(255) NOT NULL,
  `os_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class object_synonym: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("object_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property object_id As String
    <DatabaseField("object_synonym_name"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property object_synonym_name As String
    <DatabaseField("os_internal_comment"), DataType(MySqlDbType.Text)> Public Property os_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `object_synonym` (`object_id`, `object_synonym_name`, `os_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `object_synonym` (`object_id`, `object_synonym_name`, `os_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `object_synonym` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `object_synonym` SET `object_id`='{0}', `object_synonym_name`='{1}', `os_internal_comment`='{2}', `key_id_org`='{3}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `object_synonym` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `object_synonym` (`object_id`, `object_synonym_name`, `os_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, object_id, object_synonym_name, os_internal_comment, key_id_org)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{object_id}', '{object_synonym_name}', '{os_internal_comment}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `object_synonym` (`object_id`, `object_synonym_name`, `os_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, object_id, object_synonym_name, os_internal_comment, key_id_org)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `object_synonym` SET `object_id`='{0}', `object_synonym_name`='{1}', `os_internal_comment`='{2}', `key_id_org`='{3}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
