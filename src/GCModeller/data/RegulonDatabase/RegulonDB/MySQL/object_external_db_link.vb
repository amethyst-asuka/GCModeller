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
''' DROP TABLE IF EXISTS `object_external_db_link`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `object_external_db_link` (
'''   `object_id` char(12) NOT NULL,
'''   `external_db_id` char(12) NOT NULL,
'''   `ext_reference_id` varchar(255) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("object_external_db_link", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `object_external_db_link` (
  `object_id` char(12) NOT NULL,
  `external_db_id` char(12) NOT NULL,
  `ext_reference_id` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class object_external_db_link: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("object_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property object_id As String
    <DatabaseField("external_db_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property external_db_id As String
    <DatabaseField("ext_reference_id"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property ext_reference_id As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `object_external_db_link` (`object_id`, `external_db_id`, `ext_reference_id`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `object_external_db_link` (`object_id`, `external_db_id`, `ext_reference_id`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `object_external_db_link` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `object_external_db_link` SET `object_id`='{0}', `external_db_id`='{1}', `ext_reference_id`='{2}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `object_external_db_link` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `object_external_db_link` (`object_id`, `external_db_id`, `ext_reference_id`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, object_id, external_db_id, ext_reference_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{object_id}', '{external_db_id}', '{ext_reference_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `object_external_db_link` (`object_id`, `external_db_id`, `ext_reference_id`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, object_id, external_db_id, ext_reference_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `object_external_db_link` SET `object_id`='{0}', `external_db_id`='{1}', `ext_reference_id`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
