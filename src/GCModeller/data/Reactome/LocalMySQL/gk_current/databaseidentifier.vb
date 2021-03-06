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
''' DROP TABLE IF EXISTS `databaseidentifier`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `databaseidentifier` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `identifier` varchar(20) DEFAULT NULL,
'''   `referenceDatabase` int(10) unsigned DEFAULT NULL,
'''   `referenceDatabase_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `identifier` (`identifier`),
'''   KEY `referenceDatabase` (`referenceDatabase`),
'''   FULLTEXT KEY `identifier_fulltext` (`identifier`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("databaseidentifier", Database:="gk_current", SchemaSQL:="
CREATE TABLE `databaseidentifier` (
  `DB_ID` int(10) unsigned NOT NULL,
  `identifier` varchar(20) DEFAULT NULL,
  `referenceDatabase` int(10) unsigned DEFAULT NULL,
  `referenceDatabase_class` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `identifier` (`identifier`),
  KEY `referenceDatabase` (`referenceDatabase`),
  FULLTEXT KEY `identifier_fulltext` (`identifier`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class databaseidentifier: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("identifier"), DataType(MySqlDbType.VarChar, "20")> Public Property identifier As String
    <DatabaseField("referenceDatabase"), DataType(MySqlDbType.Int64, "10")> Public Property referenceDatabase As Long
    <DatabaseField("referenceDatabase_class"), DataType(MySqlDbType.VarChar, "64")> Public Property referenceDatabase_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `databaseidentifier` (`DB_ID`, `identifier`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `databaseidentifier` (`DB_ID`, `identifier`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `databaseidentifier` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `databaseidentifier` SET `DB_ID`='{0}', `identifier`='{1}', `referenceDatabase`='{2}', `referenceDatabase_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `databaseidentifier` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `databaseidentifier` (`DB_ID`, `identifier`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, identifier, referenceDatabase, referenceDatabase_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{identifier}', '{referenceDatabase}', '{referenceDatabase_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `databaseidentifier` (`DB_ID`, `identifier`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, identifier, referenceDatabase, referenceDatabase_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `databaseidentifier` SET `DB_ID`='{0}', `identifier`='{1}', `referenceDatabase`='{2}', `referenceDatabase_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, identifier, referenceDatabase, referenceDatabase_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
