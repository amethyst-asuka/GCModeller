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
''' DROP TABLE IF EXISTS `namevaluetype`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `namevaluetype` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `Value` varchar(255) DEFAULT NULL,
'''   `Type_` varchar(255) DEFAULT NULL,
'''   `NameValueType_PropertySets` bigint(20) DEFAULT NULL,
'''   `OtherWID` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_NameValueType1` (`DataSetWID`),
'''   KEY `FK_NameValueType66` (`NameValueType_PropertySets`),
'''   CONSTRAINT `FK_NameValueType1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_NameValueType66` FOREIGN KEY (`NameValueType_PropertySets`) REFERENCES `namevaluetype` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("namevaluetype", Database:="warehouse", SchemaSQL:="
CREATE TABLE `namevaluetype` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Value` varchar(255) DEFAULT NULL,
  `Type_` varchar(255) DEFAULT NULL,
  `NameValueType_PropertySets` bigint(20) DEFAULT NULL,
  `OtherWID` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_NameValueType1` (`DataSetWID`),
  KEY `FK_NameValueType66` (`NameValueType_PropertySets`),
  CONSTRAINT `FK_NameValueType1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_NameValueType66` FOREIGN KEY (`NameValueType_PropertySets`) REFERENCES `namevaluetype` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class namevaluetype: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255")> Public Property Name As String
    <DatabaseField("Value"), DataType(MySqlDbType.VarChar, "255")> Public Property Value As String
    <DatabaseField("Type_"), DataType(MySqlDbType.VarChar, "255")> Public Property Type_ As String
    <DatabaseField("NameValueType_PropertySets"), DataType(MySqlDbType.Int64, "20")> Public Property NameValueType_PropertySets As Long
    <DatabaseField("OtherWID"), DataType(MySqlDbType.Int64, "20")> Public Property OtherWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `namevaluetype` (`WID`, `DataSetWID`, `Name`, `Value`, `Type_`, `NameValueType_PropertySets`, `OtherWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `namevaluetype` (`WID`, `DataSetWID`, `Name`, `Value`, `Type_`, `NameValueType_PropertySets`, `OtherWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `namevaluetype` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `namevaluetype` SET `WID`='{0}', `DataSetWID`='{1}', `Name`='{2}', `Value`='{3}', `Type_`='{4}', `NameValueType_PropertySets`='{5}', `OtherWID`='{6}' WHERE `WID` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `namevaluetype` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `namevaluetype` (`WID`, `DataSetWID`, `Name`, `Value`, `Type_`, `NameValueType_PropertySets`, `OtherWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, Name, Value, Type_, NameValueType_PropertySets, OtherWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{Name}', '{Value}', '{Type_}', '{NameValueType_PropertySets}', '{OtherWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `namevaluetype` (`WID`, `DataSetWID`, `Name`, `Value`, `Type_`, `NameValueType_PropertySets`, `OtherWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Name, Value, Type_, NameValueType_PropertySets, OtherWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `namevaluetype` SET `WID`='{0}', `DataSetWID`='{1}', `Name`='{2}', `Value`='{3}', `Type_`='{4}', `NameValueType_PropertySets`='{5}', `OtherWID`='{6}' WHERE `WID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, Name, Value, Type_, NameValueType_PropertySets, OtherWID, WID)
    End Function
#End Region
End Class


End Namespace
