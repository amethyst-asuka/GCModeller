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
''' DROP TABLE IF EXISTS `measurement`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `measurement` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `Type_` varchar(25) DEFAULT NULL,
'''   `Value` varchar(255) DEFAULT NULL,
'''   `KindCV` varchar(25) DEFAULT NULL,
'''   `OtherKind` varchar(255) DEFAULT NULL,
'''   `Measurement_Unit` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Measurement1` (`DataSetWID`),
'''   KEY `FK_Measurement2` (`Measurement_Unit`),
'''   CONSTRAINT `FK_Measurement1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Measurement2` FOREIGN KEY (`Measurement_Unit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("measurement", Database:="warehouse", SchemaSQL:="
CREATE TABLE `measurement` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `Type_` varchar(25) DEFAULT NULL,
  `Value` varchar(255) DEFAULT NULL,
  `KindCV` varchar(25) DEFAULT NULL,
  `OtherKind` varchar(255) DEFAULT NULL,
  `Measurement_Unit` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Measurement1` (`DataSetWID`),
  KEY `FK_Measurement2` (`Measurement_Unit`),
  CONSTRAINT `FK_Measurement1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Measurement2` FOREIGN KEY (`Measurement_Unit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class measurement: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("Type_"), DataType(MySqlDbType.VarChar, "25")> Public Property Type_ As String
    <DatabaseField("Value"), DataType(MySqlDbType.VarChar, "255")> Public Property Value As String
    <DatabaseField("KindCV"), DataType(MySqlDbType.VarChar, "25")> Public Property KindCV As String
    <DatabaseField("OtherKind"), DataType(MySqlDbType.VarChar, "255")> Public Property OtherKind As String
    <DatabaseField("Measurement_Unit"), DataType(MySqlDbType.Int64, "20")> Public Property Measurement_Unit As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `measurement` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `measurement` SET `WID`='{0}', `DataSetWID`='{1}', `Type_`='{2}', `Value`='{3}', `KindCV`='{4}', `OtherKind`='{5}', `Measurement_Unit`='{6}' WHERE `WID` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `measurement` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, Type_, Value, KindCV, OtherKind, Measurement_Unit)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{Type_}', '{Value}', '{KindCV}', '{OtherKind}', '{Measurement_Unit}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Type_, Value, KindCV, OtherKind, Measurement_Unit)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `measurement` SET `WID`='{0}', `DataSetWID`='{1}', `Type_`='{2}', `Value`='{3}', `KindCV`='{4}', `OtherKind`='{5}', `Measurement_Unit`='{6}' WHERE `WID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, Type_, Value, KindCV, OtherKind, Measurement_Unit, WID)
    End Function
#End Region
End Class


End Namespace
