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
''' DROP TABLE IF EXISTS `lightsource`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `lightsource` (
'''   `WID` bigint(20) NOT NULL,
'''   `Wavelength` float DEFAULT NULL,
'''   `Type` varchar(100) DEFAULT NULL,
'''   `InstrumentWID` bigint(20) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `LightSource_DWID` (`DataSetWID`),
'''   CONSTRAINT `FK_LightSource1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("lightsource", Database:="warehouse", SchemaSQL:="
CREATE TABLE `lightsource` (
  `WID` bigint(20) NOT NULL,
  `Wavelength` float DEFAULT NULL,
  `Type` varchar(100) DEFAULT NULL,
  `InstrumentWID` bigint(20) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `LightSource_DWID` (`DataSetWID`),
  CONSTRAINT `FK_LightSource1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class lightsource: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("Wavelength"), DataType(MySqlDbType.Double)> Public Property Wavelength As Double
    <DatabaseField("Type"), DataType(MySqlDbType.VarChar, "100")> Public Property Type As String
    <DatabaseField("InstrumentWID"), DataType(MySqlDbType.Int64, "20")> Public Property InstrumentWID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `lightsource` (`WID`, `Wavelength`, `Type`, `InstrumentWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `lightsource` (`WID`, `Wavelength`, `Type`, `InstrumentWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `lightsource` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `lightsource` SET `WID`='{0}', `Wavelength`='{1}', `Type`='{2}', `InstrumentWID`='{3}', `DataSetWID`='{4}' WHERE `WID` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `lightsource` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `lightsource` (`WID`, `Wavelength`, `Type`, `InstrumentWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, Wavelength, Type, InstrumentWID, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{Wavelength}', '{Type}', '{InstrumentWID}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `lightsource` (`WID`, `Wavelength`, `Type`, `InstrumentWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, Wavelength, Type, InstrumentWID, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `lightsource` SET `WID`='{0}', `Wavelength`='{1}', `Type`='{2}', `InstrumentWID`='{3}', `DataSetWID`='{4}' WHERE `WID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, Wavelength, Type, InstrumentWID, DataSetWID, WID)
    End Function
#End Region
End Class


End Namespace
