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
''' DROP TABLE IF EXISTS `spotidmethod`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `spotidmethod` (
'''   `WID` bigint(20) NOT NULL,
'''   `MethodName` varchar(100) NOT NULL,
'''   `MethodDesc` varchar(500) DEFAULT NULL,
'''   `MethodAbbrev` varchar(10) DEFAULT NULL,
'''   `DatasetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_SpotIdMethDataset` (`DatasetWID`),
'''   CONSTRAINT `FK_SpotIdMethDataset` FOREIGN KEY (`DatasetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("spotidmethod", Database:="warehouse", SchemaSQL:="
CREATE TABLE `spotidmethod` (
  `WID` bigint(20) NOT NULL,
  `MethodName` varchar(100) NOT NULL,
  `MethodDesc` varchar(500) DEFAULT NULL,
  `MethodAbbrev` varchar(10) DEFAULT NULL,
  `DatasetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_SpotIdMethDataset` (`DatasetWID`),
  CONSTRAINT `FK_SpotIdMethDataset` FOREIGN KEY (`DatasetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class spotidmethod: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("MethodName"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property MethodName As String
    <DatabaseField("MethodDesc"), DataType(MySqlDbType.VarChar, "500")> Public Property MethodDesc As String
    <DatabaseField("MethodAbbrev"), DataType(MySqlDbType.VarChar, "10")> Public Property MethodAbbrev As String
    <DatabaseField("DatasetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DatasetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `spotidmethod` (`WID`, `MethodName`, `MethodDesc`, `MethodAbbrev`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `spotidmethod` (`WID`, `MethodName`, `MethodDesc`, `MethodAbbrev`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `spotidmethod` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `spotidmethod` SET `WID`='{0}', `MethodName`='{1}', `MethodDesc`='{2}', `MethodAbbrev`='{3}', `DatasetWID`='{4}' WHERE `WID` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `spotidmethod` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `spotidmethod` (`WID`, `MethodName`, `MethodDesc`, `MethodAbbrev`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, MethodName, MethodDesc, MethodAbbrev, DatasetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{MethodName}', '{MethodDesc}', '{MethodAbbrev}', '{DatasetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `spotidmethod` (`WID`, `MethodName`, `MethodDesc`, `MethodAbbrev`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, MethodName, MethodDesc, MethodAbbrev, DatasetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `spotidmethod` SET `WID`='{0}', `MethodName`='{1}', `MethodDesc`='{2}', `MethodAbbrev`='{3}', `DatasetWID`='{4}' WHERE `WID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, MethodName, MethodDesc, MethodAbbrev, DatasetWID, WID)
    End Function
#End Region
End Class


End Namespace
