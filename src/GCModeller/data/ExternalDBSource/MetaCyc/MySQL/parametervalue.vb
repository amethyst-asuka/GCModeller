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
''' DROP TABLE IF EXISTS `parametervalue`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `parametervalue` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `Value` varchar(255) DEFAULT NULL,
'''   `ParameterType` bigint(20) DEFAULT NULL,
'''   `ParameterizableApplication` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_ParameterValue1` (`DataSetWID`),
'''   KEY `FK_ParameterValue2` (`ParameterType`),
'''   KEY `FK_ParameterValue3` (`ParameterizableApplication`),
'''   CONSTRAINT `FK_ParameterValue1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ParameterValue2` FOREIGN KEY (`ParameterType`) REFERENCES `parameter` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ParameterValue3` FOREIGN KEY (`ParameterizableApplication`) REFERENCES `parameterizableapplication` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("parametervalue", Database:="warehouse", SchemaSQL:="
CREATE TABLE `parametervalue` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `Value` varchar(255) DEFAULT NULL,
  `ParameterType` bigint(20) DEFAULT NULL,
  `ParameterizableApplication` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_ParameterValue1` (`DataSetWID`),
  KEY `FK_ParameterValue2` (`ParameterType`),
  KEY `FK_ParameterValue3` (`ParameterizableApplication`),
  CONSTRAINT `FK_ParameterValue1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ParameterValue2` FOREIGN KEY (`ParameterType`) REFERENCES `parameter` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ParameterValue3` FOREIGN KEY (`ParameterizableApplication`) REFERENCES `parameterizableapplication` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class parametervalue: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("Value"), DataType(MySqlDbType.VarChar, "255")> Public Property Value As String
    <DatabaseField("ParameterType"), DataType(MySqlDbType.Int64, "20")> Public Property ParameterType As Long
    <DatabaseField("ParameterizableApplication"), DataType(MySqlDbType.Int64, "20")> Public Property ParameterizableApplication As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `parametervalue` (`WID`, `DataSetWID`, `Value`, `ParameterType`, `ParameterizableApplication`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `parametervalue` (`WID`, `DataSetWID`, `Value`, `ParameterType`, `ParameterizableApplication`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `parametervalue` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `parametervalue` SET `WID`='{0}', `DataSetWID`='{1}', `Value`='{2}', `ParameterType`='{3}', `ParameterizableApplication`='{4}' WHERE `WID` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `parametervalue` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `parametervalue` (`WID`, `DataSetWID`, `Value`, `ParameterType`, `ParameterizableApplication`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, Value, ParameterType, ParameterizableApplication)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{Value}', '{ParameterType}', '{ParameterizableApplication}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `parametervalue` (`WID`, `DataSetWID`, `Value`, `ParameterType`, `ParameterizableApplication`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Value, ParameterType, ParameterizableApplication)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `parametervalue` SET `WID`='{0}', `DataSetWID`='{1}', `Value`='{2}', `ParameterType`='{3}', `ParameterizableApplication`='{4}' WHERE `WID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, Value, ParameterType, ParameterizableApplication, WID)
    End Function
#End Region
End Class


End Namespace
