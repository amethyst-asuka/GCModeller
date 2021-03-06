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
''' DROP TABLE IF EXISTS `protocolwidsoftwarewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protocolwidsoftwarewid` (
'''   `ProtocolWID` bigint(20) NOT NULL,
'''   `SoftwareWID` bigint(20) NOT NULL,
'''   KEY `FK_ProtocolWIDSoftwareWID1` (`ProtocolWID`),
'''   KEY `FK_ProtocolWIDSoftwareWID2` (`SoftwareWID`),
'''   CONSTRAINT `FK_ProtocolWIDSoftwareWID1` FOREIGN KEY (`ProtocolWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ProtocolWIDSoftwareWID2` FOREIGN KEY (`SoftwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protocolwidsoftwarewid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `protocolwidsoftwarewid` (
  `ProtocolWID` bigint(20) NOT NULL,
  `SoftwareWID` bigint(20) NOT NULL,
  KEY `FK_ProtocolWIDSoftwareWID1` (`ProtocolWID`),
  KEY `FK_ProtocolWIDSoftwareWID2` (`SoftwareWID`),
  CONSTRAINT `FK_ProtocolWIDSoftwareWID1` FOREIGN KEY (`ProtocolWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProtocolWIDSoftwareWID2` FOREIGN KEY (`SoftwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class protocolwidsoftwarewid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ProtocolWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ProtocolWID As Long
    <DatabaseField("SoftwareWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SoftwareWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protocolwidsoftwarewid` (`ProtocolWID`, `SoftwareWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protocolwidsoftwarewid` (`ProtocolWID`, `SoftwareWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protocolwidsoftwarewid` WHERE `ProtocolWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protocolwidsoftwarewid` SET `ProtocolWID`='{0}', `SoftwareWID`='{1}' WHERE `ProtocolWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protocolwidsoftwarewid` WHERE `ProtocolWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ProtocolWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protocolwidsoftwarewid` (`ProtocolWID`, `SoftwareWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ProtocolWID, SoftwareWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ProtocolWID}', '{SoftwareWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protocolwidsoftwarewid` (`ProtocolWID`, `SoftwareWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ProtocolWID, SoftwareWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protocolwidsoftwarewid` SET `ProtocolWID`='{0}', `SoftwareWID`='{1}' WHERE `ProtocolWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ProtocolWID, SoftwareWID, ProtocolWID)
    End Function
#End Region
End Class


End Namespace
