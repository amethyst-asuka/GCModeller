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
''' DROP TABLE IF EXISTS `medium`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `medium` (
'''   `medium_id` char(12) NOT NULL,
'''   `medium_name` varchar(300) NOT NULL,
'''   `medium_description` varchar(2000) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("medium", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `medium` (
  `medium_id` char(12) NOT NULL,
  `medium_name` varchar(300) NOT NULL,
  `medium_description` varchar(2000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class medium: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("medium_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property medium_id As String
    <DatabaseField("medium_name"), NotNull, DataType(MySqlDbType.VarChar, "300")> Public Property medium_name As String
    <DatabaseField("medium_description"), NotNull, DataType(MySqlDbType.VarChar, "2000")> Public Property medium_description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `medium` (`medium_id`, `medium_name`, `medium_description`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `medium` (`medium_id`, `medium_name`, `medium_description`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `medium` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `medium` SET `medium_id`='{0}', `medium_name`='{1}', `medium_description`='{2}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `medium` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `medium` (`medium_id`, `medium_name`, `medium_description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, medium_id, medium_name, medium_description)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{medium_id}', '{medium_name}', '{medium_description}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `medium` (`medium_id`, `medium_name`, `medium_description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, medium_id, medium_name, medium_description)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `medium` SET `medium_id`='{0}', `medium_name`='{1}', `medium_description`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
