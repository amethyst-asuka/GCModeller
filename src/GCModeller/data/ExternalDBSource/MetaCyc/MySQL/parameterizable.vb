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
''' DROP TABLE IF EXISTS `parameterizable`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `parameterizable` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `MAGEClass` varchar(100) NOT NULL,
'''   `Identifier` varchar(255) DEFAULT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `URI` varchar(255) DEFAULT NULL,
'''   `Model` varchar(255) DEFAULT NULL,
'''   `Make` varchar(255) DEFAULT NULL,
'''   `Hardware_Type` bigint(20) DEFAULT NULL,
'''   `Text` varchar(1000) DEFAULT NULL,
'''   `Title` varchar(255) DEFAULT NULL,
'''   `Protocol_Type` bigint(20) DEFAULT NULL,
'''   `Software_Type` bigint(20) DEFAULT NULL,
'''   `Hardware` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Parameterizable1` (`DataSetWID`),
'''   KEY `FK_Parameterizable3` (`Hardware_Type`),
'''   KEY `FK_Parameterizable4` (`Protocol_Type`),
'''   KEY `FK_Parameterizable5` (`Software_Type`),
'''   KEY `FK_Parameterizable6` (`Hardware`),
'''   CONSTRAINT `FK_Parameterizable1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Parameterizable3` FOREIGN KEY (`Hardware_Type`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Parameterizable4` FOREIGN KEY (`Protocol_Type`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Parameterizable5` FOREIGN KEY (`Software_Type`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Parameterizable6` FOREIGN KEY (`Hardware`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("parameterizable", Database:="warehouse", SchemaSQL:="
CREATE TABLE `parameterizable` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `MAGEClass` varchar(100) NOT NULL,
  `Identifier` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `URI` varchar(255) DEFAULT NULL,
  `Model` varchar(255) DEFAULT NULL,
  `Make` varchar(255) DEFAULT NULL,
  `Hardware_Type` bigint(20) DEFAULT NULL,
  `Text` varchar(1000) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Protocol_Type` bigint(20) DEFAULT NULL,
  `Software_Type` bigint(20) DEFAULT NULL,
  `Hardware` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Parameterizable1` (`DataSetWID`),
  KEY `FK_Parameterizable3` (`Hardware_Type`),
  KEY `FK_Parameterizable4` (`Protocol_Type`),
  KEY `FK_Parameterizable5` (`Software_Type`),
  KEY `FK_Parameterizable6` (`Hardware`),
  CONSTRAINT `FK_Parameterizable1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Parameterizable3` FOREIGN KEY (`Hardware_Type`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Parameterizable4` FOREIGN KEY (`Protocol_Type`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Parameterizable5` FOREIGN KEY (`Software_Type`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Parameterizable6` FOREIGN KEY (`Hardware`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class parameterizable: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("MAGEClass"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property MAGEClass As String
    <DatabaseField("Identifier"), DataType(MySqlDbType.VarChar, "255")> Public Property Identifier As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255")> Public Property Name As String
    <DatabaseField("URI"), DataType(MySqlDbType.VarChar, "255")> Public Property URI As String
    <DatabaseField("Model"), DataType(MySqlDbType.VarChar, "255")> Public Property Model As String
    <DatabaseField("Make"), DataType(MySqlDbType.VarChar, "255")> Public Property Make As String
    <DatabaseField("Hardware_Type"), DataType(MySqlDbType.Int64, "20")> Public Property Hardware_Type As Long
    <DatabaseField("Text"), DataType(MySqlDbType.VarChar, "1000")> Public Property Text As String
    <DatabaseField("Title"), DataType(MySqlDbType.VarChar, "255")> Public Property Title As String
    <DatabaseField("Protocol_Type"), DataType(MySqlDbType.Int64, "20")> Public Property Protocol_Type As Long
    <DatabaseField("Software_Type"), DataType(MySqlDbType.Int64, "20")> Public Property Software_Type As Long
    <DatabaseField("Hardware"), DataType(MySqlDbType.Int64, "20")> Public Property Hardware As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `parameterizable` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `URI`, `Model`, `Make`, `Hardware_Type`, `Text`, `Title`, `Protocol_Type`, `Software_Type`, `Hardware`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `parameterizable` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `URI`, `Model`, `Make`, `Hardware_Type`, `Text`, `Title`, `Protocol_Type`, `Software_Type`, `Hardware`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `parameterizable` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `parameterizable` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `Identifier`='{3}', `Name`='{4}', `URI`='{5}', `Model`='{6}', `Make`='{7}', `Hardware_Type`='{8}', `Text`='{9}', `Title`='{10}', `Protocol_Type`='{11}', `Software_Type`='{12}', `Hardware`='{13}' WHERE `WID` = '{14}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `parameterizable` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `parameterizable` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `URI`, `Model`, `Make`, `Hardware_Type`, `Text`, `Title`, `Protocol_Type`, `Software_Type`, `Hardware`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, URI, Model, Make, Hardware_Type, Text, Title, Protocol_Type, Software_Type, Hardware)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{MAGEClass}', '{Identifier}', '{Name}', '{URI}', '{Model}', '{Make}', '{Hardware_Type}', '{Text}', '{Title}', '{Protocol_Type}', '{Software_Type}', '{Hardware}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `parameterizable` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `URI`, `Model`, `Make`, `Hardware_Type`, `Text`, `Title`, `Protocol_Type`, `Software_Type`, `Hardware`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, URI, Model, Make, Hardware_Type, Text, Title, Protocol_Type, Software_Type, Hardware)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `parameterizable` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `Identifier`='{3}', `Name`='{4}', `URI`='{5}', `Model`='{6}', `Make`='{7}', `Hardware_Type`='{8}', `Text`='{9}', `Title`='{10}', `Protocol_Type`='{11}', `Software_Type`='{12}', `Hardware`='{13}' WHERE `WID` = '{14}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, URI, Model, Make, Hardware_Type, Text, Title, Protocol_Type, Software_Type, Hardware, WID)
    End Function
#End Region
End Class


End Namespace
