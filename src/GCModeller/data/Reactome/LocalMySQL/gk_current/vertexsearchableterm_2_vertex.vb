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
''' DROP TABLE IF EXISTS `vertexsearchableterm_2_vertex`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `vertexsearchableterm_2_vertex` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `vertex_rank` int(10) unsigned DEFAULT NULL,
'''   `vertex` int(10) unsigned DEFAULT NULL,
'''   `vertex_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `vertex` (`vertex`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' -- Dumping events for database 'gk_current'
''' --
''' 
''' --
''' -- Dumping routines for database 'gk_current'
''' --
''' /*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
''' 
''' /*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
''' /*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
''' /*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
''' /*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
''' /*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
''' /*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
''' /*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
''' 
''' -- Dump completed on 2017-03-29 21:34:14
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("vertexsearchableterm_2_vertex", Database:="gk_current", SchemaSQL:="
CREATE TABLE `vertexsearchableterm_2_vertex` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `vertex_rank` int(10) unsigned DEFAULT NULL,
  `vertex` int(10) unsigned DEFAULT NULL,
  `vertex_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `vertex` (`vertex`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class vertexsearchableterm_2_vertex: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("vertex_rank"), DataType(MySqlDbType.Int64, "10")> Public Property vertex_rank As Long
    <DatabaseField("vertex"), DataType(MySqlDbType.Int64, "10")> Public Property vertex As Long
    <DatabaseField("vertex_class"), DataType(MySqlDbType.VarChar, "64")> Public Property vertex_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `vertexsearchableterm_2_vertex` (`DB_ID`, `vertex_rank`, `vertex`, `vertex_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `vertexsearchableterm_2_vertex` (`DB_ID`, `vertex_rank`, `vertex`, `vertex_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `vertexsearchableterm_2_vertex` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `vertexsearchableterm_2_vertex` SET `DB_ID`='{0}', `vertex_rank`='{1}', `vertex`='{2}', `vertex_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `vertexsearchableterm_2_vertex` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `vertexsearchableterm_2_vertex` (`DB_ID`, `vertex_rank`, `vertex`, `vertex_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, vertex_rank, vertex, vertex_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{vertex_rank}', '{vertex}', '{vertex_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `vertexsearchableterm_2_vertex` (`DB_ID`, `vertex_rank`, `vertex`, `vertex_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, vertex_rank, vertex, vertex_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `vertexsearchableterm_2_vertex` SET `DB_ID`='{0}', `vertex_rank`='{1}', `vertex`='{2}', `vertex_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, vertex_rank, vertex, vertex_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
