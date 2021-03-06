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
''' DROP TABLE IF EXISTS `organism`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `organism` (
'''   `organism_id` char(12) NOT NULL,
'''   `organism_name` varchar(1000) NOT NULL,
'''   `organism_description` varchar(2000) DEFAULT NULL,
'''   `organism_note` varchar(2000) DEFAULT NULL,
'''   `organism_internal_comment` longtext
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("organism", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `organism` (
  `organism_id` char(12) NOT NULL,
  `organism_name` varchar(1000) NOT NULL,
  `organism_description` varchar(2000) DEFAULT NULL,
  `organism_note` varchar(2000) DEFAULT NULL,
  `organism_internal_comment` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class organism: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("organism_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property organism_id As String
    <DatabaseField("organism_name"), NotNull, DataType(MySqlDbType.VarChar, "1000")> Public Property organism_name As String
    <DatabaseField("organism_description"), DataType(MySqlDbType.VarChar, "2000")> Public Property organism_description As String
    <DatabaseField("organism_note"), DataType(MySqlDbType.VarChar, "2000")> Public Property organism_note As String
    <DatabaseField("organism_internal_comment"), DataType(MySqlDbType.Text)> Public Property organism_internal_comment As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `organism` (`organism_id`, `organism_name`, `organism_description`, `organism_note`, `organism_internal_comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `organism` (`organism_id`, `organism_name`, `organism_description`, `organism_note`, `organism_internal_comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `organism` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `organism` SET `organism_id`='{0}', `organism_name`='{1}', `organism_description`='{2}', `organism_note`='{3}', `organism_internal_comment`='{4}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `organism` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `organism` (`organism_id`, `organism_name`, `organism_description`, `organism_note`, `organism_internal_comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, organism_id, organism_name, organism_description, organism_note, organism_internal_comment)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{organism_id}', '{organism_name}', '{organism_description}', '{organism_note}', '{organism_internal_comment}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `organism` (`organism_id`, `organism_name`, `organism_description`, `organism_note`, `organism_internal_comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, organism_id, organism_name, organism_description, organism_note, organism_internal_comment)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `organism` SET `organism_id`='{0}', `organism_name`='{1}', `organism_description`='{2}', `organism_note`='{3}', `organism_internal_comment`='{4}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
