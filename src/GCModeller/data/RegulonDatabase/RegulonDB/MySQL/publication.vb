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
''' DROP TABLE IF EXISTS `publication`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `publication` (
'''   `publication_id` char(12) NOT NULL,
'''   `reference_id` varchar(255) NOT NULL,
'''   `external_db_id` char(12) NOT NULL,
'''   `author` varchar(2000) DEFAULT NULL,
'''   `title` varchar(2000) DEFAULT NULL,
'''   `source` varchar(2000) DEFAULT NULL,
'''   `years` varchar(50) DEFAULT NULL,
'''   `publication_note` varchar(2000) DEFAULT NULL,
'''   `publication_internal_comment` longtext
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("publication", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `publication` (
  `publication_id` char(12) NOT NULL,
  `reference_id` varchar(255) NOT NULL,
  `external_db_id` char(12) NOT NULL,
  `author` varchar(2000) DEFAULT NULL,
  `title` varchar(2000) DEFAULT NULL,
  `source` varchar(2000) DEFAULT NULL,
  `years` varchar(50) DEFAULT NULL,
  `publication_note` varchar(2000) DEFAULT NULL,
  `publication_internal_comment` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class publication: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("publication_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property publication_id As String
    <DatabaseField("reference_id"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property reference_id As String
    <DatabaseField("external_db_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property external_db_id As String
    <DatabaseField("author"), DataType(MySqlDbType.VarChar, "2000")> Public Property author As String
    <DatabaseField("title"), DataType(MySqlDbType.VarChar, "2000")> Public Property title As String
    <DatabaseField("source"), DataType(MySqlDbType.VarChar, "2000")> Public Property source As String
    <DatabaseField("years"), DataType(MySqlDbType.VarChar, "50")> Public Property years As String
    <DatabaseField("publication_note"), DataType(MySqlDbType.VarChar, "2000")> Public Property publication_note As String
    <DatabaseField("publication_internal_comment"), DataType(MySqlDbType.Text)> Public Property publication_internal_comment As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `publication` (`publication_id`, `reference_id`, `external_db_id`, `author`, `title`, `source`, `years`, `publication_note`, `publication_internal_comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `publication` (`publication_id`, `reference_id`, `external_db_id`, `author`, `title`, `source`, `years`, `publication_note`, `publication_internal_comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `publication` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `publication` SET `publication_id`='{0}', `reference_id`='{1}', `external_db_id`='{2}', `author`='{3}', `title`='{4}', `source`='{5}', `years`='{6}', `publication_note`='{7}', `publication_internal_comment`='{8}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `publication` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `publication` (`publication_id`, `reference_id`, `external_db_id`, `author`, `title`, `source`, `years`, `publication_note`, `publication_internal_comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, publication_id, reference_id, external_db_id, author, title, source, years, publication_note, publication_internal_comment)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{publication_id}', '{reference_id}', '{external_db_id}', '{author}', '{title}', '{source}', '{years}', '{publication_note}', '{publication_internal_comment}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `publication` (`publication_id`, `reference_id`, `external_db_id`, `author`, `title`, `source`, `years`, `publication_note`, `publication_internal_comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, publication_id, reference_id, external_db_id, author, title, source, years, publication_note, publication_internal_comment)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `publication` SET `publication_id`='{0}', `reference_id`='{1}', `external_db_id`='{2}', `author`='{3}', `title`='{4}', `source`='{5}', `years`='{6}', `publication_note`='{7}', `publication_internal_comment`='{8}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
