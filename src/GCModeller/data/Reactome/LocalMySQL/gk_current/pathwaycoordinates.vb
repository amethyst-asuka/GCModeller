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
''' DROP TABLE IF EXISTS `pathwaycoordinates`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `pathwaycoordinates` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `locatedEvent` int(10) unsigned DEFAULT NULL,
'''   `locatedEvent_class` varchar(64) DEFAULT NULL,
'''   `maxX` int(10) DEFAULT NULL,
'''   `maxY` int(10) DEFAULT NULL,
'''   `minX` int(10) DEFAULT NULL,
'''   `minY` int(10) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `locatedEvent` (`locatedEvent`),
'''   KEY `maxX` (`maxX`),
'''   KEY `maxY` (`maxY`),
'''   KEY `minX` (`minX`),
'''   KEY `minY` (`minY`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("pathwaycoordinates", Database:="gk_current", SchemaSQL:="
CREATE TABLE `pathwaycoordinates` (
  `DB_ID` int(10) unsigned NOT NULL,
  `locatedEvent` int(10) unsigned DEFAULT NULL,
  `locatedEvent_class` varchar(64) DEFAULT NULL,
  `maxX` int(10) DEFAULT NULL,
  `maxY` int(10) DEFAULT NULL,
  `minX` int(10) DEFAULT NULL,
  `minY` int(10) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `locatedEvent` (`locatedEvent`),
  KEY `maxX` (`maxX`),
  KEY `maxY` (`maxY`),
  KEY `minX` (`minX`),
  KEY `minY` (`minY`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class pathwaycoordinates: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("locatedEvent"), DataType(MySqlDbType.Int64, "10")> Public Property locatedEvent As Long
    <DatabaseField("locatedEvent_class"), DataType(MySqlDbType.VarChar, "64")> Public Property locatedEvent_class As String
    <DatabaseField("maxX"), DataType(MySqlDbType.Int64, "10")> Public Property maxX As Long
    <DatabaseField("maxY"), DataType(MySqlDbType.Int64, "10")> Public Property maxY As Long
    <DatabaseField("minX"), DataType(MySqlDbType.Int64, "10")> Public Property minX As Long
    <DatabaseField("minY"), DataType(MySqlDbType.Int64, "10")> Public Property minY As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `pathwaycoordinates` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `pathwaycoordinates` SET `DB_ID`='{0}', `locatedEvent`='{1}', `locatedEvent_class`='{2}', `maxX`='{3}', `maxY`='{4}', `minX`='{5}', `minY`='{6}' WHERE `DB_ID` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `pathwaycoordinates` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, locatedEvent, locatedEvent_class, maxX, maxY, minX, minY)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{locatedEvent}', '{locatedEvent_class}', '{maxX}', '{maxY}', '{minX}', '{minY}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, locatedEvent, locatedEvent_class, maxX, maxY, minX, minY)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `pathwaycoordinates` SET `DB_ID`='{0}', `locatedEvent`='{1}', `locatedEvent_class`='{2}', `maxX`='{3}', `maxY`='{4}', `minX`='{5}', `minY`='{6}' WHERE `DB_ID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, locatedEvent, locatedEvent_class, maxX, maxY, minX, minY, DB_ID)
    End Function
#End Region
End Class


End Namespace
