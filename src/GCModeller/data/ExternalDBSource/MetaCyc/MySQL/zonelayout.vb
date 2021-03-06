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
''' DROP TABLE IF EXISTS `zonelayout`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `zonelayout` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `NumFeaturesPerRow` smallint(6) DEFAULT NULL,
'''   `NumFeaturesPerCol` smallint(6) DEFAULT NULL,
'''   `SpacingBetweenRows` float DEFAULT NULL,
'''   `SpacingBetweenCols` float DEFAULT NULL,
'''   `ZoneLayout_DistanceUnit` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_ZoneLayout1` (`DataSetWID`),
'''   KEY `FK_ZoneLayout2` (`ZoneLayout_DistanceUnit`),
'''   CONSTRAINT `FK_ZoneLayout1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ZoneLayout2` FOREIGN KEY (`ZoneLayout_DistanceUnit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
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
''' -- Dump completed on 2015-12-03 20:02:01
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("zonelayout", Database:="warehouse", SchemaSQL:="
CREATE TABLE `zonelayout` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `NumFeaturesPerRow` smallint(6) DEFAULT NULL,
  `NumFeaturesPerCol` smallint(6) DEFAULT NULL,
  `SpacingBetweenRows` float DEFAULT NULL,
  `SpacingBetweenCols` float DEFAULT NULL,
  `ZoneLayout_DistanceUnit` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_ZoneLayout1` (`DataSetWID`),
  KEY `FK_ZoneLayout2` (`ZoneLayout_DistanceUnit`),
  CONSTRAINT `FK_ZoneLayout1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ZoneLayout2` FOREIGN KEY (`ZoneLayout_DistanceUnit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class zonelayout: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("NumFeaturesPerRow"), DataType(MySqlDbType.Int64, "6")> Public Property NumFeaturesPerRow As Long
    <DatabaseField("NumFeaturesPerCol"), DataType(MySqlDbType.Int64, "6")> Public Property NumFeaturesPerCol As Long
    <DatabaseField("SpacingBetweenRows"), DataType(MySqlDbType.Double)> Public Property SpacingBetweenRows As Double
    <DatabaseField("SpacingBetweenCols"), DataType(MySqlDbType.Double)> Public Property SpacingBetweenCols As Double
    <DatabaseField("ZoneLayout_DistanceUnit"), DataType(MySqlDbType.Int64, "20")> Public Property ZoneLayout_DistanceUnit As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `zonelayout` (`WID`, `DataSetWID`, `NumFeaturesPerRow`, `NumFeaturesPerCol`, `SpacingBetweenRows`, `SpacingBetweenCols`, `ZoneLayout_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `zonelayout` (`WID`, `DataSetWID`, `NumFeaturesPerRow`, `NumFeaturesPerCol`, `SpacingBetweenRows`, `SpacingBetweenCols`, `ZoneLayout_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `zonelayout` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `zonelayout` SET `WID`='{0}', `DataSetWID`='{1}', `NumFeaturesPerRow`='{2}', `NumFeaturesPerCol`='{3}', `SpacingBetweenRows`='{4}', `SpacingBetweenCols`='{5}', `ZoneLayout_DistanceUnit`='{6}' WHERE `WID` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `zonelayout` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `zonelayout` (`WID`, `DataSetWID`, `NumFeaturesPerRow`, `NumFeaturesPerCol`, `SpacingBetweenRows`, `SpacingBetweenCols`, `ZoneLayout_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, NumFeaturesPerRow, NumFeaturesPerCol, SpacingBetweenRows, SpacingBetweenCols, ZoneLayout_DistanceUnit)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{NumFeaturesPerRow}', '{NumFeaturesPerCol}', '{SpacingBetweenRows}', '{SpacingBetweenCols}', '{ZoneLayout_DistanceUnit}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `zonelayout` (`WID`, `DataSetWID`, `NumFeaturesPerRow`, `NumFeaturesPerCol`, `SpacingBetweenRows`, `SpacingBetweenCols`, `ZoneLayout_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, NumFeaturesPerRow, NumFeaturesPerCol, SpacingBetweenRows, SpacingBetweenCols, ZoneLayout_DistanceUnit)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `zonelayout` SET `WID`='{0}', `DataSetWID`='{1}', `NumFeaturesPerRow`='{2}', `NumFeaturesPerCol`='{3}', `SpacingBetweenRows`='{4}', `SpacingBetweenCols`='{5}', `ZoneLayout_DistanceUnit`='{6}' WHERE `WID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, NumFeaturesPerRow, NumFeaturesPerCol, SpacingBetweenRows, SpacingBetweenCols, ZoneLayout_DistanceUnit, WID)
    End Function
#End Region
End Class


End Namespace
