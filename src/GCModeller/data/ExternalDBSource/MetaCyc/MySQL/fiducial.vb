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
''' DROP TABLE IF EXISTS `fiducial`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `fiducial` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `ArrayGroup_Fiducials` bigint(20) DEFAULT NULL,
'''   `Fiducial_FiducialType` bigint(20) DEFAULT NULL,
'''   `Fiducial_DistanceUnit` bigint(20) DEFAULT NULL,
'''   `Fiducial_Position` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Fiducial1` (`DataSetWID`),
'''   KEY `FK_Fiducial3` (`ArrayGroup_Fiducials`),
'''   KEY `FK_Fiducial4` (`Fiducial_FiducialType`),
'''   KEY `FK_Fiducial5` (`Fiducial_DistanceUnit`),
'''   KEY `FK_Fiducial6` (`Fiducial_Position`),
'''   CONSTRAINT `FK_Fiducial1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Fiducial3` FOREIGN KEY (`ArrayGroup_Fiducials`) REFERENCES `arraygroup` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Fiducial4` FOREIGN KEY (`Fiducial_FiducialType`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Fiducial5` FOREIGN KEY (`Fiducial_DistanceUnit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Fiducial6` FOREIGN KEY (`Fiducial_Position`) REFERENCES `position_` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("fiducial", Database:="warehouse", SchemaSQL:="
CREATE TABLE `fiducial` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `ArrayGroup_Fiducials` bigint(20) DEFAULT NULL,
  `Fiducial_FiducialType` bigint(20) DEFAULT NULL,
  `Fiducial_DistanceUnit` bigint(20) DEFAULT NULL,
  `Fiducial_Position` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Fiducial1` (`DataSetWID`),
  KEY `FK_Fiducial3` (`ArrayGroup_Fiducials`),
  KEY `FK_Fiducial4` (`Fiducial_FiducialType`),
  KEY `FK_Fiducial5` (`Fiducial_DistanceUnit`),
  KEY `FK_Fiducial6` (`Fiducial_Position`),
  CONSTRAINT `FK_Fiducial1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Fiducial3` FOREIGN KEY (`ArrayGroup_Fiducials`) REFERENCES `arraygroup` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Fiducial4` FOREIGN KEY (`Fiducial_FiducialType`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Fiducial5` FOREIGN KEY (`Fiducial_DistanceUnit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Fiducial6` FOREIGN KEY (`Fiducial_Position`) REFERENCES `position_` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class fiducial: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("ArrayGroup_Fiducials"), DataType(MySqlDbType.Int64, "20")> Public Property ArrayGroup_Fiducials As Long
    <DatabaseField("Fiducial_FiducialType"), DataType(MySqlDbType.Int64, "20")> Public Property Fiducial_FiducialType As Long
    <DatabaseField("Fiducial_DistanceUnit"), DataType(MySqlDbType.Int64, "20")> Public Property Fiducial_DistanceUnit As Long
    <DatabaseField("Fiducial_Position"), DataType(MySqlDbType.Int64, "20")> Public Property Fiducial_Position As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `fiducial` (`WID`, `DataSetWID`, `ArrayGroup_Fiducials`, `Fiducial_FiducialType`, `Fiducial_DistanceUnit`, `Fiducial_Position`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `fiducial` (`WID`, `DataSetWID`, `ArrayGroup_Fiducials`, `Fiducial_FiducialType`, `Fiducial_DistanceUnit`, `Fiducial_Position`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `fiducial` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `fiducial` SET `WID`='{0}', `DataSetWID`='{1}', `ArrayGroup_Fiducials`='{2}', `Fiducial_FiducialType`='{3}', `Fiducial_DistanceUnit`='{4}', `Fiducial_Position`='{5}' WHERE `WID` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `fiducial` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `fiducial` (`WID`, `DataSetWID`, `ArrayGroup_Fiducials`, `Fiducial_FiducialType`, `Fiducial_DistanceUnit`, `Fiducial_Position`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, ArrayGroup_Fiducials, Fiducial_FiducialType, Fiducial_DistanceUnit, Fiducial_Position)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{ArrayGroup_Fiducials}', '{Fiducial_FiducialType}', '{Fiducial_DistanceUnit}', '{Fiducial_Position}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `fiducial` (`WID`, `DataSetWID`, `ArrayGroup_Fiducials`, `Fiducial_FiducialType`, `Fiducial_DistanceUnit`, `Fiducial_Position`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, ArrayGroup_Fiducials, Fiducial_FiducialType, Fiducial_DistanceUnit, Fiducial_Position)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `fiducial` SET `WID`='{0}', `DataSetWID`='{1}', `ArrayGroup_Fiducials`='{2}', `Fiducial_FiducialType`='{3}', `Fiducial_DistanceUnit`='{4}', `Fiducial_Position`='{5}' WHERE `WID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, ArrayGroup_Fiducials, Fiducial_FiducialType, Fiducial_DistanceUnit, Fiducial_Position, WID)
    End Function
#End Region
End Class


End Namespace
