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
''' DROP TABLE IF EXISTS `_release`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `_release` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `releaseDate` text,
'''   `releaseNumber` int(10) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `releaseNumber` (`releaseNumber`),
'''   FULLTEXT KEY `releaseDate` (`releaseDate`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("_release", Database:="gk_current", SchemaSQL:="
CREATE TABLE `_release` (
  `DB_ID` int(10) unsigned NOT NULL,
  `releaseDate` text,
  `releaseNumber` int(10) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `releaseNumber` (`releaseNumber`),
  FULLTEXT KEY `releaseDate` (`releaseDate`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class _release: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("releaseDate"), DataType(MySqlDbType.Text)> Public Property releaseDate As String
    <DatabaseField("releaseNumber"), DataType(MySqlDbType.Int64, "10")> Public Property releaseNumber As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `_release` (`DB_ID`, `releaseDate`, `releaseNumber`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `_release` (`DB_ID`, `releaseDate`, `releaseNumber`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `_release` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `_release` SET `DB_ID`='{0}', `releaseDate`='{1}', `releaseNumber`='{2}' WHERE `DB_ID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `_release` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `_release` (`DB_ID`, `releaseDate`, `releaseNumber`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, releaseDate, releaseNumber)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{releaseDate}', '{releaseNumber}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `_release` (`DB_ID`, `releaseDate`, `releaseNumber`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, releaseDate, releaseNumber)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `_release` SET `DB_ID`='{0}', `releaseDate`='{1}', `releaseNumber`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, releaseDate, releaseNumber, DB_ID)
    End Function
#End Region
End Class


End Namespace
