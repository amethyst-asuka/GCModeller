REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:24:24 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `version`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `version` (
'''   `version_regulon` varchar(10) NOT NULL,
'''   `version_ecocyc` varchar(100) NOT NULL,
'''   `version_date_time` varchar(100) NOT NULL,
'''   `version_internal_comment` varchar(4000) DEFAULT NULL,
'''   `head_citation` varchar(4000) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' -- Dumping events for database 'regulondb_93'
''' --
''' 
''' --
''' -- Dumping routines for database 'regulondb_93'
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
''' -- Dump completed on 2017-03-29 23:21:44
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("version", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `version` (
  `version_regulon` varchar(10) NOT NULL,
  `version_ecocyc` varchar(100) NOT NULL,
  `version_date_time` varchar(100) NOT NULL,
  `version_internal_comment` varchar(4000) DEFAULT NULL,
  `head_citation` varchar(4000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class version: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("version_regulon"), NotNull, DataType(MySqlDbType.VarChar, "10")> Public Property version_regulon As String
    <DatabaseField("version_ecocyc"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property version_ecocyc As String
    <DatabaseField("version_date_time"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property version_date_time As String
    <DatabaseField("version_internal_comment"), DataType(MySqlDbType.VarChar, "4000")> Public Property version_internal_comment As String
    <DatabaseField("head_citation"), DataType(MySqlDbType.VarChar, "4000")> Public Property head_citation As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `version` (`version_regulon`, `version_ecocyc`, `version_date_time`, `version_internal_comment`, `head_citation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `version` (`version_regulon`, `version_ecocyc`, `version_date_time`, `version_internal_comment`, `head_citation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `version` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `version` SET `version_regulon`='{0}', `version_ecocyc`='{1}', `version_date_time`='{2}', `version_internal_comment`='{3}', `head_citation`='{4}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `version` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `version` (`version_regulon`, `version_ecocyc`, `version_date_time`, `version_internal_comment`, `head_citation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, version_regulon, version_ecocyc, version_date_time, version_internal_comment, head_citation)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{version_regulon}', '{version_ecocyc}', '{version_date_time}', '{version_internal_comment}', '{head_citation}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `version` (`version_regulon`, `version_ecocyc`, `version_date_time`, `version_internal_comment`, `head_citation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, version_regulon, version_ecocyc, version_date_time, version_internal_comment, head_citation)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `version` SET `version_regulon`='{0}', `version_ecocyc`='{1}', `version_date_time`='{2}', `version_internal_comment`='{3}', `head_citation`='{4}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
