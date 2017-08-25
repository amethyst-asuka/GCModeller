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
''' DROP TABLE IF EXISTS `person_2_affiliation`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `person_2_affiliation` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `affiliation_rank` int(10) unsigned DEFAULT NULL,
'''   `affiliation` int(10) unsigned DEFAULT NULL,
'''   `affiliation_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `affiliation` (`affiliation`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("person_2_affiliation", Database:="gk_current", SchemaSQL:="
CREATE TABLE `person_2_affiliation` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `affiliation_rank` int(10) unsigned DEFAULT NULL,
  `affiliation` int(10) unsigned DEFAULT NULL,
  `affiliation_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `affiliation` (`affiliation`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class person_2_affiliation: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("affiliation_rank"), DataType(MySqlDbType.Int64, "10")> Public Property affiliation_rank As Long
    <DatabaseField("affiliation"), DataType(MySqlDbType.Int64, "10")> Public Property affiliation As Long
    <DatabaseField("affiliation_class"), DataType(MySqlDbType.VarChar, "64")> Public Property affiliation_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `person_2_affiliation` (`DB_ID`, `affiliation_rank`, `affiliation`, `affiliation_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `person_2_affiliation` (`DB_ID`, `affiliation_rank`, `affiliation`, `affiliation_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `person_2_affiliation` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `person_2_affiliation` SET `DB_ID`='{0}', `affiliation_rank`='{1}', `affiliation`='{2}', `affiliation_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `person_2_affiliation` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `person_2_affiliation` (`DB_ID`, `affiliation_rank`, `affiliation`, `affiliation_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, affiliation_rank, affiliation, affiliation_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{affiliation_rank}', '{affiliation}', '{affiliation_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `person_2_affiliation` (`DB_ID`, `affiliation_rank`, `affiliation`, `affiliation_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, affiliation_rank, affiliation, affiliation_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `person_2_affiliation` SET `DB_ID`='{0}', `affiliation_rank`='{1}', `affiliation`='{2}', `affiliation_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, affiliation_rank, affiliation, affiliation_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
