REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:56 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `zonedefect`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `zonedefect` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `ArrayManufactureDeviation` bigint(20) DEFAULT NULL,
'''   `ZoneDefect_DefectType` bigint(20) DEFAULT NULL,
'''   `ZoneDefect_PositionDelta` bigint(20) DEFAULT NULL,
'''   `Zone` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_ZoneDefect1` (`DataSetWID`),
'''   KEY `FK_ZoneDefect2` (`ArrayManufactureDeviation`),
'''   KEY `FK_ZoneDefect3` (`ZoneDefect_DefectType`),
'''   KEY `FK_ZoneDefect4` (`ZoneDefect_PositionDelta`),
'''   KEY `FK_ZoneDefect5` (`Zone`),
'''   CONSTRAINT `FK_ZoneDefect1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ZoneDefect2` FOREIGN KEY (`ArrayManufactureDeviation`) REFERENCES `arraymanufacturedeviation` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ZoneDefect3` FOREIGN KEY (`ZoneDefect_DefectType`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ZoneDefect4` FOREIGN KEY (`ZoneDefect_PositionDelta`) REFERENCES `positiondelta` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ZoneDefect5` FOREIGN KEY (`Zone`) REFERENCES `zone` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("zonedefect", Database:="warehouse", SchemaSQL:="
CREATE TABLE `zonedefect` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `ArrayManufactureDeviation` bigint(20) DEFAULT NULL,
  `ZoneDefect_DefectType` bigint(20) DEFAULT NULL,
  `ZoneDefect_PositionDelta` bigint(20) DEFAULT NULL,
  `Zone` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_ZoneDefect1` (`DataSetWID`),
  KEY `FK_ZoneDefect2` (`ArrayManufactureDeviation`),
  KEY `FK_ZoneDefect3` (`ZoneDefect_DefectType`),
  KEY `FK_ZoneDefect4` (`ZoneDefect_PositionDelta`),
  KEY `FK_ZoneDefect5` (`Zone`),
  CONSTRAINT `FK_ZoneDefect1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ZoneDefect2` FOREIGN KEY (`ArrayManufactureDeviation`) REFERENCES `arraymanufacturedeviation` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ZoneDefect3` FOREIGN KEY (`ZoneDefect_DefectType`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ZoneDefect4` FOREIGN KEY (`ZoneDefect_PositionDelta`) REFERENCES `positiondelta` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ZoneDefect5` FOREIGN KEY (`Zone`) REFERENCES `zone` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class zonedefect: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("ArrayManufactureDeviation"), DataType(MySqlDbType.Int64, "20")> Public Property ArrayManufactureDeviation As Long
    <DatabaseField("ZoneDefect_DefectType"), DataType(MySqlDbType.Int64, "20")> Public Property ZoneDefect_DefectType As Long
    <DatabaseField("ZoneDefect_PositionDelta"), DataType(MySqlDbType.Int64, "20")> Public Property ZoneDefect_PositionDelta As Long
    <DatabaseField("Zone"), DataType(MySqlDbType.Int64, "20")> Public Property Zone As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `zonedefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `ZoneDefect_DefectType`, `ZoneDefect_PositionDelta`, `Zone`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `zonedefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `ZoneDefect_DefectType`, `ZoneDefect_PositionDelta`, `Zone`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `zonedefect` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `zonedefect` SET `WID`='{0}', `DataSetWID`='{1}', `ArrayManufactureDeviation`='{2}', `ZoneDefect_DefectType`='{3}', `ZoneDefect_PositionDelta`='{4}', `Zone`='{5}' WHERE `WID` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `zonedefect` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `zonedefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `ZoneDefect_DefectType`, `ZoneDefect_PositionDelta`, `Zone`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, ArrayManufactureDeviation, ZoneDefect_DefectType, ZoneDefect_PositionDelta, Zone)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{ArrayManufactureDeviation}', '{ZoneDefect_DefectType}', '{ZoneDefect_PositionDelta}', '{Zone}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `zonedefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `ZoneDefect_DefectType`, `ZoneDefect_PositionDelta`, `Zone`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, ArrayManufactureDeviation, ZoneDefect_DefectType, ZoneDefect_PositionDelta, Zone)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `zonedefect` SET `WID`='{0}', `DataSetWID`='{1}', `ArrayManufactureDeviation`='{2}', `ZoneDefect_DefectType`='{3}', `ZoneDefect_PositionDelta`='{4}', `Zone`='{5}' WHERE `WID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, ArrayManufactureDeviation, ZoneDefect_DefectType, ZoneDefect_PositionDelta, Zone, WID)
    End Function
#End Region
End Class


End Namespace
