REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:27 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `person`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `person` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `eMailAddress` varchar(255) DEFAULT NULL,
'''   `firstname` text,
'''   `initial` varchar(10) DEFAULT NULL,
'''   `project` text,
'''   `surname` varchar(255) DEFAULT NULL,
'''   `url` text,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `eMailAddress` (`eMailAddress`),
'''   KEY `initial` (`initial`),
'''   KEY `surname` (`surname`),
'''   FULLTEXT KEY `eMailAddress_fulltext` (`eMailAddress`),
'''   FULLTEXT KEY `firstname` (`firstname`),
'''   FULLTEXT KEY `initial_fulltext` (`initial`),
'''   FULLTEXT KEY `project` (`project`),
'''   FULLTEXT KEY `surname_fulltext` (`surname`),
'''   FULLTEXT KEY `url` (`url`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("person", Database:="gk_current", SchemaSQL:="
CREATE TABLE `person` (
  `DB_ID` int(10) unsigned NOT NULL,
  `eMailAddress` varchar(255) DEFAULT NULL,
  `firstname` text,
  `initial` varchar(10) DEFAULT NULL,
  `project` text,
  `surname` varchar(255) DEFAULT NULL,
  `url` text,
  PRIMARY KEY (`DB_ID`),
  KEY `eMailAddress` (`eMailAddress`),
  KEY `initial` (`initial`),
  KEY `surname` (`surname`),
  FULLTEXT KEY `eMailAddress_fulltext` (`eMailAddress`),
  FULLTEXT KEY `firstname` (`firstname`),
  FULLTEXT KEY `initial_fulltext` (`initial`),
  FULLTEXT KEY `project` (`project`),
  FULLTEXT KEY `surname_fulltext` (`surname`),
  FULLTEXT KEY `url` (`url`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class person: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("eMailAddress"), DataType(MySqlDbType.VarChar, "255")> Public Property eMailAddress As String
    <DatabaseField("firstname"), DataType(MySqlDbType.Text)> Public Property firstname As String
    <DatabaseField("initial"), DataType(MySqlDbType.VarChar, "10")> Public Property initial As String
    <DatabaseField("project"), DataType(MySqlDbType.Text)> Public Property project As String
    <DatabaseField("surname"), DataType(MySqlDbType.VarChar, "255")> Public Property surname As String
    <DatabaseField("url"), DataType(MySqlDbType.Text)> Public Property url As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `person` (`DB_ID`, `eMailAddress`, `firstname`, `initial`, `project`, `surname`, `url`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `person` (`DB_ID`, `eMailAddress`, `firstname`, `initial`, `project`, `surname`, `url`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `person` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `person` SET `DB_ID`='{0}', `eMailAddress`='{1}', `firstname`='{2}', `initial`='{3}', `project`='{4}', `surname`='{5}', `url`='{6}' WHERE `DB_ID` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `person` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `person` (`DB_ID`, `eMailAddress`, `firstname`, `initial`, `project`, `surname`, `url`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, eMailAddress, firstname, initial, project, surname, url)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{eMailAddress}', '{firstname}', '{initial}', '{project}', '{surname}', '{url}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `person` (`DB_ID`, `eMailAddress`, `firstname`, `initial`, `project`, `surname`, `url`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, eMailAddress, firstname, initial, project, surname, url)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `person` SET `DB_ID`='{0}', `eMailAddress`='{1}', `firstname`='{2}', `initial`='{3}', `project`='{4}', `surname`='{5}', `url`='{6}' WHERE `DB_ID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, eMailAddress, firstname, initial, project, surname, url, DB_ID)
    End Function
#End Region
End Class


End Namespace
