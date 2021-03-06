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
''' DROP TABLE IF EXISTS `complex_2_hascomponent`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `complex_2_hascomponent` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `hasComponent_rank` int(10) unsigned DEFAULT NULL,
'''   `hasComponent` int(10) unsigned DEFAULT NULL,
'''   `hasComponent_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `hasComponent` (`hasComponent`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("complex_2_hascomponent", Database:="gk_current", SchemaSQL:="
CREATE TABLE `complex_2_hascomponent` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `hasComponent_rank` int(10) unsigned DEFAULT NULL,
  `hasComponent` int(10) unsigned DEFAULT NULL,
  `hasComponent_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `hasComponent` (`hasComponent`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class complex_2_hascomponent: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("hasComponent_rank"), DataType(MySqlDbType.Int64, "10")> Public Property hasComponent_rank As Long
    <DatabaseField("hasComponent"), DataType(MySqlDbType.Int64, "10")> Public Property hasComponent As Long
    <DatabaseField("hasComponent_class"), DataType(MySqlDbType.VarChar, "64")> Public Property hasComponent_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `complex_2_hascomponent` (`DB_ID`, `hasComponent_rank`, `hasComponent`, `hasComponent_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `complex_2_hascomponent` (`DB_ID`, `hasComponent_rank`, `hasComponent`, `hasComponent_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `complex_2_hascomponent` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `complex_2_hascomponent` SET `DB_ID`='{0}', `hasComponent_rank`='{1}', `hasComponent`='{2}', `hasComponent_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `complex_2_hascomponent` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `complex_2_hascomponent` (`DB_ID`, `hasComponent_rank`, `hasComponent`, `hasComponent_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, hasComponent_rank, hasComponent, hasComponent_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{hasComponent_rank}', '{hasComponent}', '{hasComponent_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `complex_2_hascomponent` (`DB_ID`, `hasComponent_rank`, `hasComponent`, `hasComponent_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, hasComponent_rank, hasComponent, hasComponent_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `complex_2_hascomponent` SET `DB_ID`='{0}', `hasComponent_rank`='{1}', `hasComponent`='{2}', `hasComponent_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, hasComponent_rank, hasComponent, hasComponent_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
