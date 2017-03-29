REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:55:32 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Xfam.Rfam.MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `wikitext`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `wikitext` (
'''   `auto_wiki` int(10) unsigned NOT NULL AUTO_INCREMENT,
'''   `title` varchar(150) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
'''   PRIMARY KEY (`auto_wiki`),
'''   UNIQUE KEY `title_UNIQUE` (`title`)
''' ) ENGINE=InnoDB AUTO_INCREMENT=2450 DEFAULT CHARSET=latin1 COLLATE=latin1_general_cs;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' -- Dumping events for database 'rfam_12_2'
''' --
''' 
''' --
''' -- Dumping routines for database 'rfam_12_2'
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
''' -- Dump completed on 2017-03-29 23:52:18
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("wikitext", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `wikitext` (
  `auto_wiki` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(150) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`auto_wiki`),
  UNIQUE KEY `title_UNIQUE` (`title`)
) ENGINE=InnoDB AUTO_INCREMENT=2450 DEFAULT CHARSET=latin1 COLLATE=latin1_general_cs;")>
Public Class wikitext: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("auto_wiki"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property auto_wiki As Long
    <DatabaseField("title"), NotNull, DataType(MySqlDbType.VarChar, "150")> Public Property title As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `wikitext` (`title`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `wikitext` (`title`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `wikitext` WHERE `auto_wiki` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `wikitext` SET `auto_wiki`='{0}', `title`='{1}' WHERE `auto_wiki` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `wikitext` WHERE `auto_wiki` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, auto_wiki)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `wikitext` (`title`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, title)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{title}', '{1}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `wikitext` (`title`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, title)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `wikitext` SET `auto_wiki`='{0}', `title`='{1}' WHERE `auto_wiki` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, auto_wiki, title, auto_wiki)
    End Function
#End Region
End Class


End Namespace
