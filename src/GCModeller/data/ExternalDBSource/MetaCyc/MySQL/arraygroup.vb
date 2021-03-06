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
''' DROP TABLE IF EXISTS `arraygroup`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `arraygroup` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `Identifier` varchar(255) DEFAULT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `Barcode` varchar(255) DEFAULT NULL,
'''   `ArraySpacingX` float DEFAULT NULL,
'''   `ArraySpacingY` float DEFAULT NULL,
'''   `NumArrays` smallint(6) DEFAULT NULL,
'''   `OrientationMark` varchar(255) DEFAULT NULL,
'''   `OrientationMarkPosition` varchar(25) DEFAULT NULL,
'''   `Width` float DEFAULT NULL,
'''   `Length` float DEFAULT NULL,
'''   `ArrayGroup_SubstrateType` bigint(20) DEFAULT NULL,
'''   `ArrayGroup_DistanceUnit` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_ArrayGroup1` (`DataSetWID`),
'''   KEY `FK_ArrayGroup3` (`ArrayGroup_SubstrateType`),
'''   KEY `FK_ArrayGroup4` (`ArrayGroup_DistanceUnit`),
'''   CONSTRAINT `FK_ArrayGroup1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ArrayGroup3` FOREIGN KEY (`ArrayGroup_SubstrateType`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ArrayGroup4` FOREIGN KEY (`ArrayGroup_DistanceUnit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("arraygroup", Database:="warehouse", SchemaSQL:="
CREATE TABLE `arraygroup` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `Identifier` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Barcode` varchar(255) DEFAULT NULL,
  `ArraySpacingX` float DEFAULT NULL,
  `ArraySpacingY` float DEFAULT NULL,
  `NumArrays` smallint(6) DEFAULT NULL,
  `OrientationMark` varchar(255) DEFAULT NULL,
  `OrientationMarkPosition` varchar(25) DEFAULT NULL,
  `Width` float DEFAULT NULL,
  `Length` float DEFAULT NULL,
  `ArrayGroup_SubstrateType` bigint(20) DEFAULT NULL,
  `ArrayGroup_DistanceUnit` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_ArrayGroup1` (`DataSetWID`),
  KEY `FK_ArrayGroup3` (`ArrayGroup_SubstrateType`),
  KEY `FK_ArrayGroup4` (`ArrayGroup_DistanceUnit`),
  CONSTRAINT `FK_ArrayGroup1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ArrayGroup3` FOREIGN KEY (`ArrayGroup_SubstrateType`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ArrayGroup4` FOREIGN KEY (`ArrayGroup_DistanceUnit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class arraygroup: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("Identifier"), DataType(MySqlDbType.VarChar, "255")> Public Property Identifier As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255")> Public Property Name As String
    <DatabaseField("Barcode"), DataType(MySqlDbType.VarChar, "255")> Public Property Barcode As String
    <DatabaseField("ArraySpacingX"), DataType(MySqlDbType.Double)> Public Property ArraySpacingX As Double
    <DatabaseField("ArraySpacingY"), DataType(MySqlDbType.Double)> Public Property ArraySpacingY As Double
    <DatabaseField("NumArrays"), DataType(MySqlDbType.Int64, "6")> Public Property NumArrays As Long
    <DatabaseField("OrientationMark"), DataType(MySqlDbType.VarChar, "255")> Public Property OrientationMark As String
    <DatabaseField("OrientationMarkPosition"), DataType(MySqlDbType.VarChar, "25")> Public Property OrientationMarkPosition As String
    <DatabaseField("Width"), DataType(MySqlDbType.Double)> Public Property Width As Double
    <DatabaseField("Length"), DataType(MySqlDbType.Double)> Public Property Length As Double
    <DatabaseField("ArrayGroup_SubstrateType"), DataType(MySqlDbType.Int64, "20")> Public Property ArrayGroup_SubstrateType As Long
    <DatabaseField("ArrayGroup_DistanceUnit"), DataType(MySqlDbType.Int64, "20")> Public Property ArrayGroup_DistanceUnit As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `arraygroup` (`WID`, `DataSetWID`, `Identifier`, `Name`, `Barcode`, `ArraySpacingX`, `ArraySpacingY`, `NumArrays`, `OrientationMark`, `OrientationMarkPosition`, `Width`, `Length`, `ArrayGroup_SubstrateType`, `ArrayGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `arraygroup` (`WID`, `DataSetWID`, `Identifier`, `Name`, `Barcode`, `ArraySpacingX`, `ArraySpacingY`, `NumArrays`, `OrientationMark`, `OrientationMarkPosition`, `Width`, `Length`, `ArrayGroup_SubstrateType`, `ArrayGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `arraygroup` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `arraygroup` SET `WID`='{0}', `DataSetWID`='{1}', `Identifier`='{2}', `Name`='{3}', `Barcode`='{4}', `ArraySpacingX`='{5}', `ArraySpacingY`='{6}', `NumArrays`='{7}', `OrientationMark`='{8}', `OrientationMarkPosition`='{9}', `Width`='{10}', `Length`='{11}', `ArrayGroup_SubstrateType`='{12}', `ArrayGroup_DistanceUnit`='{13}' WHERE `WID` = '{14}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `arraygroup` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `arraygroup` (`WID`, `DataSetWID`, `Identifier`, `Name`, `Barcode`, `ArraySpacingX`, `ArraySpacingY`, `NumArrays`, `OrientationMark`, `OrientationMarkPosition`, `Width`, `Length`, `ArrayGroup_SubstrateType`, `ArrayGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, Identifier, Name, Barcode, ArraySpacingX, ArraySpacingY, NumArrays, OrientationMark, OrientationMarkPosition, Width, Length, ArrayGroup_SubstrateType, ArrayGroup_DistanceUnit)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{Identifier}', '{Name}', '{Barcode}', '{ArraySpacingX}', '{ArraySpacingY}', '{NumArrays}', '{OrientationMark}', '{OrientationMarkPosition}', '{Width}', '{Length}', '{ArrayGroup_SubstrateType}', '{ArrayGroup_DistanceUnit}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `arraygroup` (`WID`, `DataSetWID`, `Identifier`, `Name`, `Barcode`, `ArraySpacingX`, `ArraySpacingY`, `NumArrays`, `OrientationMark`, `OrientationMarkPosition`, `Width`, `Length`, `ArrayGroup_SubstrateType`, `ArrayGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Identifier, Name, Barcode, ArraySpacingX, ArraySpacingY, NumArrays, OrientationMark, OrientationMarkPosition, Width, Length, ArrayGroup_SubstrateType, ArrayGroup_DistanceUnit)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `arraygroup` SET `WID`='{0}', `DataSetWID`='{1}', `Identifier`='{2}', `Name`='{3}', `Barcode`='{4}', `ArraySpacingX`='{5}', `ArraySpacingY`='{6}', `NumArrays`='{7}', `OrientationMark`='{8}', `OrientationMarkPosition`='{9}', `Width`='{10}', `Length`='{11}', `ArrayGroup_SubstrateType`='{12}', `ArrayGroup_DistanceUnit`='{13}' WHERE `WID` = '{14}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, Identifier, Name, Barcode, ArraySpacingX, ArraySpacingY, NumArrays, OrientationMark, OrientationMarkPosition, Width, Length, ArrayGroup_SubstrateType, ArrayGroup_DistanceUnit, WID)
    End Function
#End Region
End Class


End Namespace
