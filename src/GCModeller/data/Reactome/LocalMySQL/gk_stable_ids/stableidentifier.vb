REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:31 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_stable_ids

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `stableidentifier`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `stableidentifier` (
'''   `DB_ID` int(12) unsigned NOT NULL AUTO_INCREMENT,
'''   `identifier` varchar(32) DEFAULT NULL,
'''   `identifierVersion` int(4) DEFAULT NULL,
'''   `instanceId` int(12) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `identifier` (`identifier`(12))
''' ) ENGINE=MyISAM AUTO_INCREMENT=1792857 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' -- Dumping events for database 'gk_stable_ids'
''' --
''' 
''' --
''' -- Dumping routines for database 'gk_stable_ids'
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
''' -- Dump completed on 2017-03-29 21:35:20
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("stableidentifier", Database:="gk_stable_ids", SchemaSQL:="
CREATE TABLE `stableidentifier` (
  `DB_ID` int(12) unsigned NOT NULL AUTO_INCREMENT,
  `identifier` varchar(32) DEFAULT NULL,
  `identifierVersion` int(4) DEFAULT NULL,
  `instanceId` int(12) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `identifier` (`identifier`(12))
) ENGINE=MyISAM AUTO_INCREMENT=1792857 DEFAULT CHARSET=latin1;")>
Public Class stableidentifier: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "12")> Public Property DB_ID As Long
    <DatabaseField("identifier"), DataType(MySqlDbType.VarChar, "32")> Public Property identifier As String
    <DatabaseField("identifierVersion"), DataType(MySqlDbType.Int64, "4")> Public Property identifierVersion As Long
    <DatabaseField("instanceId"), DataType(MySqlDbType.Int64, "12")> Public Property instanceId As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `stableidentifier` (`identifier`, `identifierVersion`, `instanceId`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `stableidentifier` (`identifier`, `identifierVersion`, `instanceId`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `stableidentifier` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `stableidentifier` SET `DB_ID`='{0}', `identifier`='{1}', `identifierVersion`='{2}', `instanceId`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `stableidentifier` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `stableidentifier` (`identifier`, `identifierVersion`, `instanceId`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, identifier, identifierVersion, instanceId)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{identifier}', '{identifierVersion}', '{instanceId}', '{3}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `stableidentifier` (`identifier`, `identifierVersion`, `instanceId`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, identifier, identifierVersion, instanceId)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `stableidentifier` SET `DB_ID`='{0}', `identifier`='{1}', `identifierVersion`='{2}', `instanceId`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, identifier, identifierVersion, instanceId, DB_ID)
    End Function
#End Region
End Class


End Namespace
