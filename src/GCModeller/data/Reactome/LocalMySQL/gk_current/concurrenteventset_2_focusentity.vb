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
''' DROP TABLE IF EXISTS `concurrenteventset_2_focusentity`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `concurrenteventset_2_focusentity` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `focusEntity_rank` int(10) unsigned DEFAULT NULL,
'''   `focusEntity` int(10) unsigned DEFAULT NULL,
'''   `focusEntity_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `focusEntity` (`focusEntity`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("concurrenteventset_2_focusentity", Database:="gk_current", SchemaSQL:="
CREATE TABLE `concurrenteventset_2_focusentity` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `focusEntity_rank` int(10) unsigned DEFAULT NULL,
  `focusEntity` int(10) unsigned DEFAULT NULL,
  `focusEntity_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `focusEntity` (`focusEntity`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class concurrenteventset_2_focusentity: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("focusEntity_rank"), DataType(MySqlDbType.Int64, "10")> Public Property focusEntity_rank As Long
    <DatabaseField("focusEntity"), DataType(MySqlDbType.Int64, "10")> Public Property focusEntity As Long
    <DatabaseField("focusEntity_class"), DataType(MySqlDbType.VarChar, "64")> Public Property focusEntity_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `concurrenteventset_2_focusentity` (`DB_ID`, `focusEntity_rank`, `focusEntity`, `focusEntity_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `concurrenteventset_2_focusentity` (`DB_ID`, `focusEntity_rank`, `focusEntity`, `focusEntity_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `concurrenteventset_2_focusentity` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `concurrenteventset_2_focusentity` SET `DB_ID`='{0}', `focusEntity_rank`='{1}', `focusEntity`='{2}', `focusEntity_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `concurrenteventset_2_focusentity` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `concurrenteventset_2_focusentity` (`DB_ID`, `focusEntity_rank`, `focusEntity`, `focusEntity_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, focusEntity_rank, focusEntity, focusEntity_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{focusEntity_rank}', '{focusEntity}', '{focusEntity_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `concurrenteventset_2_focusentity` (`DB_ID`, `focusEntity_rank`, `focusEntity`, `focusEntity_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, focusEntity_rank, focusEntity, focusEntity_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `concurrenteventset_2_focusentity` SET `DB_ID`='{0}', `focusEntity_rank`='{1}', `focusEntity`='{2}', `focusEntity_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, focusEntity_rank, focusEntity, focusEntity_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
