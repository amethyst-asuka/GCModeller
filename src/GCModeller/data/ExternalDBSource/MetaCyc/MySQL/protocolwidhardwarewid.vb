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
''' DROP TABLE IF EXISTS `protocolwidhardwarewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protocolwidhardwarewid` (
'''   `ProtocolWID` bigint(20) NOT NULL,
'''   `HardwareWID` bigint(20) NOT NULL,
'''   KEY `FK_ProtocolWIDHardwareWID1` (`ProtocolWID`),
'''   KEY `FK_ProtocolWIDHardwareWID2` (`HardwareWID`),
'''   CONSTRAINT `FK_ProtocolWIDHardwareWID1` FOREIGN KEY (`ProtocolWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ProtocolWIDHardwareWID2` FOREIGN KEY (`HardwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protocolwidhardwarewid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `protocolwidhardwarewid` (
  `ProtocolWID` bigint(20) NOT NULL,
  `HardwareWID` bigint(20) NOT NULL,
  KEY `FK_ProtocolWIDHardwareWID1` (`ProtocolWID`),
  KEY `FK_ProtocolWIDHardwareWID2` (`HardwareWID`),
  CONSTRAINT `FK_ProtocolWIDHardwareWID1` FOREIGN KEY (`ProtocolWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProtocolWIDHardwareWID2` FOREIGN KEY (`HardwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class protocolwidhardwarewid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ProtocolWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ProtocolWID As Long
    <DatabaseField("HardwareWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property HardwareWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protocolwidhardwarewid` (`ProtocolWID`, `HardwareWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protocolwidhardwarewid` (`ProtocolWID`, `HardwareWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protocolwidhardwarewid` WHERE `ProtocolWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protocolwidhardwarewid` SET `ProtocolWID`='{0}', `HardwareWID`='{1}' WHERE `ProtocolWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protocolwidhardwarewid` WHERE `ProtocolWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ProtocolWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protocolwidhardwarewid` (`ProtocolWID`, `HardwareWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ProtocolWID, HardwareWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ProtocolWID}', '{HardwareWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protocolwidhardwarewid` (`ProtocolWID`, `HardwareWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ProtocolWID, HardwareWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protocolwidhardwarewid` SET `ProtocolWID`='{0}', `HardwareWID`='{1}' WHERE `ProtocolWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ProtocolWID, HardwareWID, ProtocolWID)
    End Function
#End Region
End Class


End Namespace
