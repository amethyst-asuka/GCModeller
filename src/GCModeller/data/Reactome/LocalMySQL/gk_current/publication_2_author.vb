REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:28 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `publication_2_author`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `publication_2_author` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `author_rank` int(10) unsigned DEFAULT NULL,
'''   `author` int(10) unsigned DEFAULT NULL,
'''   `author_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `author` (`author`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("publication_2_author", Database:="gk_current", SchemaSQL:="
CREATE TABLE `publication_2_author` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `author_rank` int(10) unsigned DEFAULT NULL,
  `author` int(10) unsigned DEFAULT NULL,
  `author_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `author` (`author`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class publication_2_author: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("author_rank"), DataType(MySqlDbType.Int64, "10")> Public Property author_rank As Long
    <DatabaseField("author"), DataType(MySqlDbType.Int64, "10")> Public Property author As Long
    <DatabaseField("author_class"), DataType(MySqlDbType.VarChar, "64")> Public Property author_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `publication_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `publication_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `publication_2_author` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `publication_2_author` SET `DB_ID`='{0}', `author_rank`='{1}', `author`='{2}', `author_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `publication_2_author` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `publication_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, author_rank, author, author_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{author_rank}', '{author}', '{author_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `publication_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, author_rank, author, author_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `publication_2_author` SET `DB_ID`='{0}', `author_rank`='{1}', `author`='{2}', `author_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, author_rank, author, author_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
