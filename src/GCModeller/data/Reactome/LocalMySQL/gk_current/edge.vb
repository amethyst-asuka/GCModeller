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
''' DROP TABLE IF EXISTS `edge`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `edge` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `edgeType` int(10) DEFAULT NULL,
'''   `pathwayDiagram` int(10) unsigned DEFAULT NULL,
'''   `pathwayDiagram_class` varchar(64) DEFAULT NULL,
'''   `pointCoordinates` text,
'''   `sourceVertex` int(10) unsigned DEFAULT NULL,
'''   `sourceVertex_class` varchar(64) DEFAULT NULL,
'''   `targetVertex` int(10) unsigned DEFAULT NULL,
'''   `targetVertex_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `edgeType` (`edgeType`),
'''   KEY `pathwayDiagram` (`pathwayDiagram`),
'''   KEY `sourceVertex` (`sourceVertex`),
'''   KEY `targetVertex` (`targetVertex`),
'''   FULLTEXT KEY `pointCoordinates` (`pointCoordinates`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("edge", Database:="gk_current", SchemaSQL:="
CREATE TABLE `edge` (
  `DB_ID` int(10) unsigned NOT NULL,
  `edgeType` int(10) DEFAULT NULL,
  `pathwayDiagram` int(10) unsigned DEFAULT NULL,
  `pathwayDiagram_class` varchar(64) DEFAULT NULL,
  `pointCoordinates` text,
  `sourceVertex` int(10) unsigned DEFAULT NULL,
  `sourceVertex_class` varchar(64) DEFAULT NULL,
  `targetVertex` int(10) unsigned DEFAULT NULL,
  `targetVertex_class` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `edgeType` (`edgeType`),
  KEY `pathwayDiagram` (`pathwayDiagram`),
  KEY `sourceVertex` (`sourceVertex`),
  KEY `targetVertex` (`targetVertex`),
  FULLTEXT KEY `pointCoordinates` (`pointCoordinates`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class edge: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("edgeType"), DataType(MySqlDbType.Int64, "10")> Public Property edgeType As Long
    <DatabaseField("pathwayDiagram"), DataType(MySqlDbType.Int64, "10")> Public Property pathwayDiagram As Long
    <DatabaseField("pathwayDiagram_class"), DataType(MySqlDbType.VarChar, "64")> Public Property pathwayDiagram_class As String
    <DatabaseField("pointCoordinates"), DataType(MySqlDbType.Text)> Public Property pointCoordinates As String
    <DatabaseField("sourceVertex"), DataType(MySqlDbType.Int64, "10")> Public Property sourceVertex As Long
    <DatabaseField("sourceVertex_class"), DataType(MySqlDbType.VarChar, "64")> Public Property sourceVertex_class As String
    <DatabaseField("targetVertex"), DataType(MySqlDbType.Int64, "10")> Public Property targetVertex As Long
    <DatabaseField("targetVertex_class"), DataType(MySqlDbType.VarChar, "64")> Public Property targetVertex_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `edge` (`DB_ID`, `edgeType`, `pathwayDiagram`, `pathwayDiagram_class`, `pointCoordinates`, `sourceVertex`, `sourceVertex_class`, `targetVertex`, `targetVertex_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `edge` (`DB_ID`, `edgeType`, `pathwayDiagram`, `pathwayDiagram_class`, `pointCoordinates`, `sourceVertex`, `sourceVertex_class`, `targetVertex`, `targetVertex_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `edge` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `edge` SET `DB_ID`='{0}', `edgeType`='{1}', `pathwayDiagram`='{2}', `pathwayDiagram_class`='{3}', `pointCoordinates`='{4}', `sourceVertex`='{5}', `sourceVertex_class`='{6}', `targetVertex`='{7}', `targetVertex_class`='{8}' WHERE `DB_ID` = '{9}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `edge` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `edge` (`DB_ID`, `edgeType`, `pathwayDiagram`, `pathwayDiagram_class`, `pointCoordinates`, `sourceVertex`, `sourceVertex_class`, `targetVertex`, `targetVertex_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, edgeType, pathwayDiagram, pathwayDiagram_class, pointCoordinates, sourceVertex, sourceVertex_class, targetVertex, targetVertex_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{edgeType}', '{pathwayDiagram}', '{pathwayDiagram_class}', '{pointCoordinates}', '{sourceVertex}', '{sourceVertex_class}', '{targetVertex}', '{targetVertex_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `edge` (`DB_ID`, `edgeType`, `pathwayDiagram`, `pathwayDiagram_class`, `pointCoordinates`, `sourceVertex`, `sourceVertex_class`, `targetVertex`, `targetVertex_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, edgeType, pathwayDiagram, pathwayDiagram_class, pointCoordinates, sourceVertex, sourceVertex_class, targetVertex, targetVertex_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `edge` SET `DB_ID`='{0}', `edgeType`='{1}', `pathwayDiagram`='{2}', `pathwayDiagram_class`='{3}', `pointCoordinates`='{4}', `sourceVertex`='{5}', `sourceVertex_class`='{6}', `targetVertex`='{7}', `targetVertex_class`='{8}' WHERE `DB_ID` = '{9}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, edgeType, pathwayDiagram, pathwayDiagram_class, pointCoordinates, sourceVertex, sourceVertex_class, targetVertex, targetVertex_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
