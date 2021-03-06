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
''' DROP TABLE IF EXISTS `factorvalue`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `factorvalue` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `Identifier` varchar(255) DEFAULT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `ExperimentalFactor` bigint(20) DEFAULT NULL,
'''   `ExperimentalFactor2` bigint(20) DEFAULT NULL,
'''   `FactorValue_Measurement` bigint(20) DEFAULT NULL,
'''   `FactorValue_Value` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_FactorValue1` (`DataSetWID`),
'''   KEY `FK_FactorValue3` (`ExperimentalFactor`),
'''   KEY `FK_FactorValue4` (`ExperimentalFactor2`),
'''   KEY `FK_FactorValue5` (`FactorValue_Measurement`),
'''   KEY `FK_FactorValue6` (`FactorValue_Value`),
'''   CONSTRAINT `FK_FactorValue1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FactorValue3` FOREIGN KEY (`ExperimentalFactor`) REFERENCES `experimentalfactor` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FactorValue4` FOREIGN KEY (`ExperimentalFactor2`) REFERENCES `experimentalfactor` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FactorValue5` FOREIGN KEY (`FactorValue_Measurement`) REFERENCES `measurement` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FactorValue6` FOREIGN KEY (`FactorValue_Value`) REFERENCES `term` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("factorvalue", Database:="warehouse", SchemaSQL:="
CREATE TABLE `factorvalue` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `Identifier` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `ExperimentalFactor` bigint(20) DEFAULT NULL,
  `ExperimentalFactor2` bigint(20) DEFAULT NULL,
  `FactorValue_Measurement` bigint(20) DEFAULT NULL,
  `FactorValue_Value` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_FactorValue1` (`DataSetWID`),
  KEY `FK_FactorValue3` (`ExperimentalFactor`),
  KEY `FK_FactorValue4` (`ExperimentalFactor2`),
  KEY `FK_FactorValue5` (`FactorValue_Measurement`),
  KEY `FK_FactorValue6` (`FactorValue_Value`),
  CONSTRAINT `FK_FactorValue1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FactorValue3` FOREIGN KEY (`ExperimentalFactor`) REFERENCES `experimentalfactor` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FactorValue4` FOREIGN KEY (`ExperimentalFactor2`) REFERENCES `experimentalfactor` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FactorValue5` FOREIGN KEY (`FactorValue_Measurement`) REFERENCES `measurement` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FactorValue6` FOREIGN KEY (`FactorValue_Value`) REFERENCES `term` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class factorvalue: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("Identifier"), DataType(MySqlDbType.VarChar, "255")> Public Property Identifier As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255")> Public Property Name As String
    <DatabaseField("ExperimentalFactor"), DataType(MySqlDbType.Int64, "20")> Public Property ExperimentalFactor As Long
    <DatabaseField("ExperimentalFactor2"), DataType(MySqlDbType.Int64, "20")> Public Property ExperimentalFactor2 As Long
    <DatabaseField("FactorValue_Measurement"), DataType(MySqlDbType.Int64, "20")> Public Property FactorValue_Measurement As Long
    <DatabaseField("FactorValue_Value"), DataType(MySqlDbType.Int64, "20")> Public Property FactorValue_Value As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `factorvalue` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentalFactor`, `ExperimentalFactor2`, `FactorValue_Measurement`, `FactorValue_Value`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `factorvalue` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentalFactor`, `ExperimentalFactor2`, `FactorValue_Measurement`, `FactorValue_Value`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `factorvalue` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `factorvalue` SET `WID`='{0}', `DataSetWID`='{1}', `Identifier`='{2}', `Name`='{3}', `ExperimentalFactor`='{4}', `ExperimentalFactor2`='{5}', `FactorValue_Measurement`='{6}', `FactorValue_Value`='{7}' WHERE `WID` = '{8}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `factorvalue` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `factorvalue` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentalFactor`, `ExperimentalFactor2`, `FactorValue_Measurement`, `FactorValue_Value`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, Identifier, Name, ExperimentalFactor, ExperimentalFactor2, FactorValue_Measurement, FactorValue_Value)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{Identifier}', '{Name}', '{ExperimentalFactor}', '{ExperimentalFactor2}', '{FactorValue_Measurement}', '{FactorValue_Value}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `factorvalue` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentalFactor`, `ExperimentalFactor2`, `FactorValue_Measurement`, `FactorValue_Value`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Identifier, Name, ExperimentalFactor, ExperimentalFactor2, FactorValue_Measurement, FactorValue_Value)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `factorvalue` SET `WID`='{0}', `DataSetWID`='{1}', `Identifier`='{2}', `Name`='{3}', `ExperimentalFactor`='{4}', `ExperimentalFactor2`='{5}', `FactorValue_Measurement`='{6}', `FactorValue_Value`='{7}' WHERE `WID` = '{8}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, Identifier, Name, ExperimentalFactor, ExperimentalFactor2, FactorValue_Measurement, FactorValue_Value, WID)
    End Function
#End Region
End Class


End Namespace
