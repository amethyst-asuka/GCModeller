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
''' DROP TABLE IF EXISTS `crosslinkedresidue_2_secondcoordinate`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `crosslinkedresidue_2_secondcoordinate` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `secondCoordinate_rank` int(10) unsigned DEFAULT NULL,
'''   `secondCoordinate` int(10) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `secondCoordinate` (`secondCoordinate`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("crosslinkedresidue_2_secondcoordinate", Database:="gk_current", SchemaSQL:="
CREATE TABLE `crosslinkedresidue_2_secondcoordinate` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `secondCoordinate_rank` int(10) unsigned DEFAULT NULL,
  `secondCoordinate` int(10) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `secondCoordinate` (`secondCoordinate`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class crosslinkedresidue_2_secondcoordinate: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("secondCoordinate_rank"), DataType(MySqlDbType.Int64, "10")> Public Property secondCoordinate_rank As Long
    <DatabaseField("secondCoordinate"), DataType(MySqlDbType.Int64, "10")> Public Property secondCoordinate As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `crosslinkedresidue_2_secondcoordinate` (`DB_ID`, `secondCoordinate_rank`, `secondCoordinate`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `crosslinkedresidue_2_secondcoordinate` (`DB_ID`, `secondCoordinate_rank`, `secondCoordinate`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `crosslinkedresidue_2_secondcoordinate` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `crosslinkedresidue_2_secondcoordinate` SET `DB_ID`='{0}', `secondCoordinate_rank`='{1}', `secondCoordinate`='{2}' WHERE `DB_ID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `crosslinkedresidue_2_secondcoordinate` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `crosslinkedresidue_2_secondcoordinate` (`DB_ID`, `secondCoordinate_rank`, `secondCoordinate`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, secondCoordinate_rank, secondCoordinate)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{secondCoordinate_rank}', '{secondCoordinate}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `crosslinkedresidue_2_secondcoordinate` (`DB_ID`, `secondCoordinate_rank`, `secondCoordinate`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, secondCoordinate_rank, secondCoordinate)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `crosslinkedresidue_2_secondcoordinate` SET `DB_ID`='{0}', `secondCoordinate_rank`='{1}', `secondCoordinate`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, secondCoordinate_rank, secondCoordinate, DB_ID)
    End Function
#End Region
End Class


End Namespace
