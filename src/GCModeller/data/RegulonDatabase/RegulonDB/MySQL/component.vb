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
''' DROP TABLE IF EXISTS `component`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `component` (
'''   `component_id` char(12) NOT NULL,
'''   `component_name` varchar(255) NOT NULL,
'''   `component_type` varchar(250) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("component", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `component` (
  `component_id` char(12) NOT NULL,
  `component_name` varchar(255) NOT NULL,
  `component_type` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class component: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("component_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property component_id As String
    <DatabaseField("component_name"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property component_name As String
    <DatabaseField("component_type"), NotNull, DataType(MySqlDbType.VarChar, "250")> Public Property component_type As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `component` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `component` SET `component_id`='{0}', `component_name`='{1}', `component_type`='{2}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `component` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, component_id, component_name, component_type)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{component_id}', '{component_name}', '{component_type}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, component_id, component_name, component_type)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `component` SET `component_id`='{0}', `component_name`='{1}', `component_type`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
