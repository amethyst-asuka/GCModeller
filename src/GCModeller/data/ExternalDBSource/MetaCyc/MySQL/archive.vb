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
''' DROP TABLE IF EXISTS `archive`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `archive` (
'''   `WID` bigint(20) NOT NULL,
'''   `OtherWID` bigint(20) NOT NULL,
'''   `Format` varchar(10) NOT NULL,
'''   `Contents` longblob,
'''   `URL` text,
'''   `ToolName` varchar(50) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("archive", Database:="warehouse", SchemaSQL:="
CREATE TABLE `archive` (
  `WID` bigint(20) NOT NULL,
  `OtherWID` bigint(20) NOT NULL,
  `Format` varchar(10) NOT NULL,
  `Contents` longblob,
  `URL` text,
  `ToolName` varchar(50) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class archive: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("OtherWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property OtherWID As Long
    <DatabaseField("Format"), NotNull, DataType(MySqlDbType.VarChar, "10")> Public Property Format As String
    <DatabaseField("Contents"), DataType(MySqlDbType.Blob)> Public Property Contents As Byte()
    <DatabaseField("URL"), DataType(MySqlDbType.Text)> Public Property URL As String
    <DatabaseField("ToolName"), DataType(MySqlDbType.VarChar, "50")> Public Property ToolName As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `archive` (`WID`, `OtherWID`, `Format`, `Contents`, `URL`, `ToolName`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `archive` (`WID`, `OtherWID`, `Format`, `Contents`, `URL`, `ToolName`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `archive` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `archive` SET `WID`='{0}', `OtherWID`='{1}', `Format`='{2}', `Contents`='{3}', `URL`='{4}', `ToolName`='{5}', `DataSetWID`='{6}' WHERE `WID` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `archive` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `archive` (`WID`, `OtherWID`, `Format`, `Contents`, `URL`, `ToolName`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, OtherWID, Format, Contents, URL, ToolName, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{OtherWID}', '{Format}', '{Contents}', '{URL}', '{ToolName}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `archive` (`WID`, `OtherWID`, `Format`, `Contents`, `URL`, `ToolName`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, OtherWID, Format, Contents, URL, ToolName, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `archive` SET `WID`='{0}', `OtherWID`='{1}', `Format`='{2}', `Contents`='{3}', `URL`='{4}', `ToolName`='{5}', `DataSetWID`='{6}' WHERE `WID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, OtherWID, Format, Contents, URL, ToolName, DataSetWID, WID)
    End Function
#End Region
End Class


End Namespace
