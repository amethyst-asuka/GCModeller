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
''' DROP TABLE IF EXISTS `hardwarewidsoftwarewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `hardwarewidsoftwarewid` (
'''   `HardwareWID` bigint(20) NOT NULL,
'''   `SoftwareWID` bigint(20) NOT NULL,
'''   KEY `FK_HardwareWIDSoftwareWID1` (`HardwareWID`),
'''   KEY `FK_HardwareWIDSoftwareWID2` (`SoftwareWID`),
'''   CONSTRAINT `FK_HardwareWIDSoftwareWID1` FOREIGN KEY (`HardwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_HardwareWIDSoftwareWID2` FOREIGN KEY (`SoftwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("hardwarewidsoftwarewid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `hardwarewidsoftwarewid` (
  `HardwareWID` bigint(20) NOT NULL,
  `SoftwareWID` bigint(20) NOT NULL,
  KEY `FK_HardwareWIDSoftwareWID1` (`HardwareWID`),
  KEY `FK_HardwareWIDSoftwareWID2` (`SoftwareWID`),
  CONSTRAINT `FK_HardwareWIDSoftwareWID1` FOREIGN KEY (`HardwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_HardwareWIDSoftwareWID2` FOREIGN KEY (`SoftwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class hardwarewidsoftwarewid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("HardwareWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property HardwareWID As Long
    <DatabaseField("SoftwareWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SoftwareWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `hardwarewidsoftwarewid` (`HardwareWID`, `SoftwareWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `hardwarewidsoftwarewid` (`HardwareWID`, `SoftwareWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `hardwarewidsoftwarewid` WHERE `HardwareWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `hardwarewidsoftwarewid` SET `HardwareWID`='{0}', `SoftwareWID`='{1}' WHERE `HardwareWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `hardwarewidsoftwarewid` WHERE `HardwareWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, HardwareWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `hardwarewidsoftwarewid` (`HardwareWID`, `SoftwareWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, HardwareWID, SoftwareWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{HardwareWID}', '{SoftwareWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `hardwarewidsoftwarewid` (`HardwareWID`, `SoftwareWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, HardwareWID, SoftwareWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `hardwarewidsoftwarewid` SET `HardwareWID`='{0}', `SoftwareWID`='{1}' WHERE `HardwareWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, HardwareWID, SoftwareWID, HardwareWID)
    End Function
#End Region
End Class


End Namespace
