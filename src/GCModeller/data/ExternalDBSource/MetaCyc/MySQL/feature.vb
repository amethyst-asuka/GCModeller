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
''' DROP TABLE IF EXISTS `feature`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `feature` (
'''   `WID` bigint(20) NOT NULL,
'''   `Description` varchar(1300) DEFAULT NULL,
'''   `Type` varchar(50) DEFAULT NULL,
'''   `Class` varchar(50) DEFAULT NULL,
'''   `SequenceType` char(1) NOT NULL,
'''   `SequenceWID` bigint(20) DEFAULT NULL,
'''   `Variant` longtext,
'''   `RegionOrPoint` varchar(10) DEFAULT NULL,
'''   `PointType` varchar(10) DEFAULT NULL,
'''   `StartPosition` int(11) DEFAULT NULL,
'''   `EndPosition` int(11) DEFAULT NULL,
'''   `StartPositionApproximate` varchar(10) DEFAULT NULL,
'''   `EndPositionApproximate` varchar(10) DEFAULT NULL,
'''   `ExperimentalSupport` char(1) DEFAULT NULL,
'''   `ComputationalSupport` char(1) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Feature` (`DataSetWID`),
'''   CONSTRAINT `FK_Feature` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("feature", Database:="warehouse", SchemaSQL:="
CREATE TABLE `feature` (
  `WID` bigint(20) NOT NULL,
  `Description` varchar(1300) DEFAULT NULL,
  `Type` varchar(50) DEFAULT NULL,
  `Class` varchar(50) DEFAULT NULL,
  `SequenceType` char(1) NOT NULL,
  `SequenceWID` bigint(20) DEFAULT NULL,
  `Variant` longtext,
  `RegionOrPoint` varchar(10) DEFAULT NULL,
  `PointType` varchar(10) DEFAULT NULL,
  `StartPosition` int(11) DEFAULT NULL,
  `EndPosition` int(11) DEFAULT NULL,
  `StartPositionApproximate` varchar(10) DEFAULT NULL,
  `EndPositionApproximate` varchar(10) DEFAULT NULL,
  `ExperimentalSupport` char(1) DEFAULT NULL,
  `ComputationalSupport` char(1) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Feature` (`DataSetWID`),
  CONSTRAINT `FK_Feature` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class feature: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("Description"), DataType(MySqlDbType.VarChar, "1300")> Public Property Description As String
    <DatabaseField("Type"), DataType(MySqlDbType.VarChar, "50")> Public Property Type As String
    <DatabaseField("Class"), DataType(MySqlDbType.VarChar, "50")> Public Property [Class] As String
    <DatabaseField("SequenceType"), NotNull, DataType(MySqlDbType.VarChar, "1")> Public Property SequenceType As String
    <DatabaseField("SequenceWID"), DataType(MySqlDbType.Int64, "20")> Public Property SequenceWID As Long
    <DatabaseField("Variant"), DataType(MySqlDbType.Text)> Public Property [Variant] As String
    <DatabaseField("RegionOrPoint"), DataType(MySqlDbType.VarChar, "10")> Public Property RegionOrPoint As String
    <DatabaseField("PointType"), DataType(MySqlDbType.VarChar, "10")> Public Property PointType As String
    <DatabaseField("StartPosition"), DataType(MySqlDbType.Int64, "11")> Public Property StartPosition As Long
    <DatabaseField("EndPosition"), DataType(MySqlDbType.Int64, "11")> Public Property EndPosition As Long
    <DatabaseField("StartPositionApproximate"), DataType(MySqlDbType.VarChar, "10")> Public Property StartPositionApproximate As String
    <DatabaseField("EndPositionApproximate"), DataType(MySqlDbType.VarChar, "10")> Public Property EndPositionApproximate As String
    <DatabaseField("ExperimentalSupport"), DataType(MySqlDbType.VarChar, "1")> Public Property ExperimentalSupport As String
    <DatabaseField("ComputationalSupport"), DataType(MySqlDbType.VarChar, "1")> Public Property ComputationalSupport As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `feature` (`WID`, `Description`, `Type`, `Class`, `SequenceType`, `SequenceWID`, `Variant`, `RegionOrPoint`, `PointType`, `StartPosition`, `EndPosition`, `StartPositionApproximate`, `EndPositionApproximate`, `ExperimentalSupport`, `ComputationalSupport`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `feature` (`WID`, `Description`, `Type`, `Class`, `SequenceType`, `SequenceWID`, `Variant`, `RegionOrPoint`, `PointType`, `StartPosition`, `EndPosition`, `StartPositionApproximate`, `EndPositionApproximate`, `ExperimentalSupport`, `ComputationalSupport`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `feature` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `feature` SET `WID`='{0}', `Description`='{1}', `Type`='{2}', `Class`='{3}', `SequenceType`='{4}', `SequenceWID`='{5}', `Variant`='{6}', `RegionOrPoint`='{7}', `PointType`='{8}', `StartPosition`='{9}', `EndPosition`='{10}', `StartPositionApproximate`='{11}', `EndPositionApproximate`='{12}', `ExperimentalSupport`='{13}', `ComputationalSupport`='{14}', `DataSetWID`='{15}' WHERE `WID` = '{16}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `feature` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `feature` (`WID`, `Description`, `Type`, `Class`, `SequenceType`, `SequenceWID`, `Variant`, `RegionOrPoint`, `PointType`, `StartPosition`, `EndPosition`, `StartPositionApproximate`, `EndPositionApproximate`, `ExperimentalSupport`, `ComputationalSupport`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, Description, Type, [Class], SequenceType, SequenceWID, [Variant], RegionOrPoint, PointType, StartPosition, EndPosition, StartPositionApproximate, EndPositionApproximate, ExperimentalSupport, ComputationalSupport, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{Description}', '{Type}', '{[Class]}', '{SequenceType}', '{SequenceWID}', '{[Variant]}', '{RegionOrPoint}', '{PointType}', '{StartPosition}', '{EndPosition}', '{StartPositionApproximate}', '{EndPositionApproximate}', '{ExperimentalSupport}', '{ComputationalSupport}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `feature` (`WID`, `Description`, `Type`, `Class`, `SequenceType`, `SequenceWID`, `Variant`, `RegionOrPoint`, `PointType`, `StartPosition`, `EndPosition`, `StartPositionApproximate`, `EndPositionApproximate`, `ExperimentalSupport`, `ComputationalSupport`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, Description, Type, [Class], SequenceType, SequenceWID, [Variant], RegionOrPoint, PointType, StartPosition, EndPosition, StartPositionApproximate, EndPositionApproximate, ExperimentalSupport, ComputationalSupport, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `feature` SET `WID`='{0}', `Description`='{1}', `Type`='{2}', `Class`='{3}', `SequenceType`='{4}', `SequenceWID`='{5}', `Variant`='{6}', `RegionOrPoint`='{7}', `PointType`='{8}', `StartPosition`='{9}', `EndPosition`='{10}', `StartPositionApproximate`='{11}', `EndPositionApproximate`='{12}', `ExperimentalSupport`='{13}', `ComputationalSupport`='{14}', `DataSetWID`='{15}' WHERE `WID` = '{16}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, Description, Type, [Class], SequenceType, SequenceWID, [Variant], RegionOrPoint, PointType, StartPosition, EndPosition, StartPositionApproximate, EndPositionApproximate, ExperimentalSupport, ComputationalSupport, DataSetWID, WID)
    End Function
#End Region
End Class


End Namespace
