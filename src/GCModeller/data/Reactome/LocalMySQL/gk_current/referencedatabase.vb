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
''' DROP TABLE IF EXISTS `referencedatabase`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `referencedatabase` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `accessUrl` text,
'''   `url` text,
'''   PRIMARY KEY (`DB_ID`),
'''   FULLTEXT KEY `accessUrl` (`accessUrl`),
'''   FULLTEXT KEY `url` (`url`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("referencedatabase", Database:="gk_current", SchemaSQL:="
CREATE TABLE `referencedatabase` (
  `DB_ID` int(10) unsigned NOT NULL,
  `accessUrl` text,
  `url` text,
  PRIMARY KEY (`DB_ID`),
  FULLTEXT KEY `accessUrl` (`accessUrl`),
  FULLTEXT KEY `url` (`url`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class referencedatabase: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("accessUrl"), DataType(MySqlDbType.Text)> Public Property accessUrl As String
    <DatabaseField("url"), DataType(MySqlDbType.Text)> Public Property url As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `referencedatabase` (`DB_ID`, `accessUrl`, `url`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `referencedatabase` (`DB_ID`, `accessUrl`, `url`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `referencedatabase` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `referencedatabase` SET `DB_ID`='{0}', `accessUrl`='{1}', `url`='{2}' WHERE `DB_ID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `referencedatabase` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `referencedatabase` (`DB_ID`, `accessUrl`, `url`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, accessUrl, url)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{accessUrl}', '{url}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `referencedatabase` (`DB_ID`, `accessUrl`, `url`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, accessUrl, url)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `referencedatabase` SET `DB_ID`='{0}', `accessUrl`='{1}', `url`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, accessUrl, url, DB_ID)
    End Function
#End Region
End Class


End Namespace
