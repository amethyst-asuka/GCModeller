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
''' DROP TABLE IF EXISTS `hardwarewidcontactwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `hardwarewidcontactwid` (
'''   `HardwareWID` bigint(20) NOT NULL,
'''   `ContactWID` bigint(20) NOT NULL,
'''   KEY `FK_HardwareWIDContactWID1` (`HardwareWID`),
'''   KEY `FK_HardwareWIDContactWID2` (`ContactWID`),
'''   CONSTRAINT `FK_HardwareWIDContactWID1` FOREIGN KEY (`HardwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_HardwareWIDContactWID2` FOREIGN KEY (`ContactWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("hardwarewidcontactwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `hardwarewidcontactwid` (
  `HardwareWID` bigint(20) NOT NULL,
  `ContactWID` bigint(20) NOT NULL,
  KEY `FK_HardwareWIDContactWID1` (`HardwareWID`),
  KEY `FK_HardwareWIDContactWID2` (`ContactWID`),
  CONSTRAINT `FK_HardwareWIDContactWID1` FOREIGN KEY (`HardwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_HardwareWIDContactWID2` FOREIGN KEY (`ContactWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class hardwarewidcontactwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("HardwareWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property HardwareWID As Long
    <DatabaseField("ContactWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ContactWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `hardwarewidcontactwid` (`HardwareWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `hardwarewidcontactwid` (`HardwareWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `hardwarewidcontactwid` WHERE `HardwareWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `hardwarewidcontactwid` SET `HardwareWID`='{0}', `ContactWID`='{1}' WHERE `HardwareWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `hardwarewidcontactwid` WHERE `HardwareWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, HardwareWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `hardwarewidcontactwid` (`HardwareWID`, `ContactWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, HardwareWID, ContactWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{HardwareWID}', '{ContactWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `hardwarewidcontactwid` (`HardwareWID`, `ContactWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, HardwareWID, ContactWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `hardwarewidcontactwid` SET `HardwareWID`='{0}', `ContactWID`='{1}' WHERE `HardwareWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, HardwareWID, ContactWID, HardwareWID)
    End Function
#End Region
End Class


End Namespace
