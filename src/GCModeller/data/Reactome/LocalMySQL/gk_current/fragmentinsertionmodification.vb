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
''' DROP TABLE IF EXISTS `fragmentinsertionmodification`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `fragmentinsertionmodification` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `coordinate` int(10) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `coordinate` (`coordinate`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("fragmentinsertionmodification", Database:="gk_current", SchemaSQL:="
CREATE TABLE `fragmentinsertionmodification` (
  `DB_ID` int(10) unsigned NOT NULL,
  `coordinate` int(10) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `coordinate` (`coordinate`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class fragmentinsertionmodification: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("coordinate"), DataType(MySqlDbType.Int64, "10")> Public Property coordinate As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `fragmentinsertionmodification` (`DB_ID`, `coordinate`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `fragmentinsertionmodification` (`DB_ID`, `coordinate`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `fragmentinsertionmodification` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `fragmentinsertionmodification` SET `DB_ID`='{0}', `coordinate`='{1}' WHERE `DB_ID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `fragmentinsertionmodification` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `fragmentinsertionmodification` (`DB_ID`, `coordinate`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, coordinate)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{coordinate}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `fragmentinsertionmodification` (`DB_ID`, `coordinate`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, coordinate)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `fragmentinsertionmodification` SET `DB_ID`='{0}', `coordinate`='{1}' WHERE `DB_ID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, coordinate, DB_ID)
    End Function
#End Region
End Class


End Namespace
