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
''' DROP TABLE IF EXISTS `experiment`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `experiment` (
'''   `WID` bigint(20) NOT NULL,
'''   `Type` varchar(50) NOT NULL,
'''   `ContactWID` bigint(20) DEFAULT NULL,
'''   `ArchiveWID` bigint(20) DEFAULT NULL,
'''   `StartDate` datetime DEFAULT NULL,
'''   `EndDate` datetime DEFAULT NULL,
'''   `Description` text,
'''   `GroupWID` bigint(20) DEFAULT NULL,
'''   `GroupType` varchar(50) DEFAULT NULL,
'''   `GroupSize` int(11) NOT NULL,
'''   `GroupIndex` int(11) DEFAULT NULL,
'''   `TimePoint` int(11) DEFAULT NULL,
'''   `TimeUnit` varchar(20) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `BioSourceWID` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Experiment3` (`ContactWID`),
'''   KEY `FK_Experiment4` (`ArchiveWID`),
'''   KEY `FK_Experiment2` (`GroupWID`),
'''   KEY `FK_Experiment5` (`DataSetWID`),
'''   KEY `FK_Experiment6` (`BioSourceWID`),
'''   CONSTRAINT `FK_Experiment2` FOREIGN KEY (`GroupWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Experiment3` FOREIGN KEY (`ContactWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Experiment4` FOREIGN KEY (`ArchiveWID`) REFERENCES `archive` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Experiment5` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Experiment6` FOREIGN KEY (`BioSourceWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("experiment", Database:="warehouse", SchemaSQL:="
CREATE TABLE `experiment` (
  `WID` bigint(20) NOT NULL,
  `Type` varchar(50) NOT NULL,
  `ContactWID` bigint(20) DEFAULT NULL,
  `ArchiveWID` bigint(20) DEFAULT NULL,
  `StartDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `Description` text,
  `GroupWID` bigint(20) DEFAULT NULL,
  `GroupType` varchar(50) DEFAULT NULL,
  `GroupSize` int(11) NOT NULL,
  `GroupIndex` int(11) DEFAULT NULL,
  `TimePoint` int(11) DEFAULT NULL,
  `TimeUnit` varchar(20) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `BioSourceWID` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Experiment3` (`ContactWID`),
  KEY `FK_Experiment4` (`ArchiveWID`),
  KEY `FK_Experiment2` (`GroupWID`),
  KEY `FK_Experiment5` (`DataSetWID`),
  KEY `FK_Experiment6` (`BioSourceWID`),
  CONSTRAINT `FK_Experiment2` FOREIGN KEY (`GroupWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Experiment3` FOREIGN KEY (`ContactWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Experiment4` FOREIGN KEY (`ArchiveWID`) REFERENCES `archive` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Experiment5` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Experiment6` FOREIGN KEY (`BioSourceWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class experiment: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("Type"), NotNull, DataType(MySqlDbType.VarChar, "50")> Public Property Type As String
    <DatabaseField("ContactWID"), DataType(MySqlDbType.Int64, "20")> Public Property ContactWID As Long
    <DatabaseField("ArchiveWID"), DataType(MySqlDbType.Int64, "20")> Public Property ArchiveWID As Long
    <DatabaseField("StartDate"), DataType(MySqlDbType.DateTime)> Public Property StartDate As Date
    <DatabaseField("EndDate"), DataType(MySqlDbType.DateTime)> Public Property EndDate As Date
    <DatabaseField("Description"), DataType(MySqlDbType.Text)> Public Property Description As String
    <DatabaseField("GroupWID"), DataType(MySqlDbType.Int64, "20")> Public Property GroupWID As Long
    <DatabaseField("GroupType"), DataType(MySqlDbType.VarChar, "50")> Public Property GroupType As String
    <DatabaseField("GroupSize"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property GroupSize As Long
    <DatabaseField("GroupIndex"), DataType(MySqlDbType.Int64, "11")> Public Property GroupIndex As Long
    <DatabaseField("TimePoint"), DataType(MySqlDbType.Int64, "11")> Public Property TimePoint As Long
    <DatabaseField("TimeUnit"), DataType(MySqlDbType.VarChar, "20")> Public Property TimeUnit As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("BioSourceWID"), DataType(MySqlDbType.Int64, "20")> Public Property BioSourceWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `experiment` (`WID`, `Type`, `ContactWID`, `ArchiveWID`, `StartDate`, `EndDate`, `Description`, `GroupWID`, `GroupType`, `GroupSize`, `GroupIndex`, `TimePoint`, `TimeUnit`, `DataSetWID`, `BioSourceWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `experiment` (`WID`, `Type`, `ContactWID`, `ArchiveWID`, `StartDate`, `EndDate`, `Description`, `GroupWID`, `GroupType`, `GroupSize`, `GroupIndex`, `TimePoint`, `TimeUnit`, `DataSetWID`, `BioSourceWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `experiment` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `experiment` SET `WID`='{0}', `Type`='{1}', `ContactWID`='{2}', `ArchiveWID`='{3}', `StartDate`='{4}', `EndDate`='{5}', `Description`='{6}', `GroupWID`='{7}', `GroupType`='{8}', `GroupSize`='{9}', `GroupIndex`='{10}', `TimePoint`='{11}', `TimeUnit`='{12}', `DataSetWID`='{13}', `BioSourceWID`='{14}' WHERE `WID` = '{15}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `experiment` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `experiment` (`WID`, `Type`, `ContactWID`, `ArchiveWID`, `StartDate`, `EndDate`, `Description`, `GroupWID`, `GroupType`, `GroupSize`, `GroupIndex`, `TimePoint`, `TimeUnit`, `DataSetWID`, `BioSourceWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, Type, ContactWID, ArchiveWID, DataType.ToMySqlDateTimeString(StartDate), DataType.ToMySqlDateTimeString(EndDate), Description, GroupWID, GroupType, GroupSize, GroupIndex, TimePoint, TimeUnit, DataSetWID, BioSourceWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{Type}', '{ContactWID}', '{ArchiveWID}', '{StartDate}', '{EndDate}', '{Description}', '{GroupWID}', '{GroupType}', '{GroupSize}', '{GroupIndex}', '{TimePoint}', '{TimeUnit}', '{DataSetWID}', '{BioSourceWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `experiment` (`WID`, `Type`, `ContactWID`, `ArchiveWID`, `StartDate`, `EndDate`, `Description`, `GroupWID`, `GroupType`, `GroupSize`, `GroupIndex`, `TimePoint`, `TimeUnit`, `DataSetWID`, `BioSourceWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, Type, ContactWID, ArchiveWID, DataType.ToMySqlDateTimeString(StartDate), DataType.ToMySqlDateTimeString(EndDate), Description, GroupWID, GroupType, GroupSize, GroupIndex, TimePoint, TimeUnit, DataSetWID, BioSourceWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `experiment` SET `WID`='{0}', `Type`='{1}', `ContactWID`='{2}', `ArchiveWID`='{3}', `StartDate`='{4}', `EndDate`='{5}', `Description`='{6}', `GroupWID`='{7}', `GroupType`='{8}', `GroupSize`='{9}', `GroupIndex`='{10}', `TimePoint`='{11}', `TimeUnit`='{12}', `DataSetWID`='{13}', `BioSourceWID`='{14}' WHERE `WID` = '{15}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, Type, ContactWID, ArchiveWID, DataType.ToMySqlDateTimeString(StartDate), DataType.ToMySqlDateTimeString(EndDate), Description, GroupWID, GroupType, GroupSize, GroupIndex, TimePoint, TimeUnit, DataSetWID, BioSourceWID, WID)
    End Function
#End Region
End Class


End Namespace
