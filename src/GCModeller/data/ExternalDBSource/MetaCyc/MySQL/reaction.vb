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
''' DROP TABLE IF EXISTS `reaction`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reaction` (
'''   `WID` bigint(20) NOT NULL,
'''   `Name` varchar(250) DEFAULT NULL,
'''   `DeltaG` varchar(50) DEFAULT NULL,
'''   `ECNumber` varchar(50) DEFAULT NULL,
'''   `ECNumberProposed` varchar(50) DEFAULT NULL,
'''   `Spontaneous` char(1) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `REACTION_DWID` (`DataSetWID`),
'''   CONSTRAINT `FK_Reaction` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reaction", Database:="warehouse", SchemaSQL:="
CREATE TABLE `reaction` (
  `WID` bigint(20) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `DeltaG` varchar(50) DEFAULT NULL,
  `ECNumber` varchar(50) DEFAULT NULL,
  `ECNumberProposed` varchar(50) DEFAULT NULL,
  `Spontaneous` char(1) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `REACTION_DWID` (`DataSetWID`),
  CONSTRAINT `FK_Reaction` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class reaction: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "250")> Public Property Name As String
    <DatabaseField("DeltaG"), DataType(MySqlDbType.VarChar, "50")> Public Property DeltaG As String
    <DatabaseField("ECNumber"), DataType(MySqlDbType.VarChar, "50")> Public Property ECNumber As String
    <DatabaseField("ECNumberProposed"), DataType(MySqlDbType.VarChar, "50")> Public Property ECNumberProposed As String
    <DatabaseField("Spontaneous"), DataType(MySqlDbType.VarChar, "1")> Public Property Spontaneous As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `reaction` (`WID`, `Name`, `DeltaG`, `ECNumber`, `ECNumberProposed`, `Spontaneous`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `reaction` (`WID`, `Name`, `DeltaG`, `ECNumber`, `ECNumberProposed`, `Spontaneous`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `reaction` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `reaction` SET `WID`='{0}', `Name`='{1}', `DeltaG`='{2}', `ECNumber`='{3}', `ECNumberProposed`='{4}', `Spontaneous`='{5}', `DataSetWID`='{6}' WHERE `WID` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `reaction` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `reaction` (`WID`, `Name`, `DeltaG`, `ECNumber`, `ECNumberProposed`, `Spontaneous`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, Name, DeltaG, ECNumber, ECNumberProposed, Spontaneous, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{Name}', '{DeltaG}', '{ECNumber}', '{ECNumberProposed}', '{Spontaneous}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reaction` (`WID`, `Name`, `DeltaG`, `ECNumber`, `ECNumberProposed`, `Spontaneous`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, Name, DeltaG, ECNumber, ECNumberProposed, Spontaneous, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `reaction` SET `WID`='{0}', `Name`='{1}', `DeltaG`='{2}', `ECNumber`='{3}', `ECNumberProposed`='{4}', `Spontaneous`='{5}', `DataSetWID`='{6}' WHERE `WID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, Name, DeltaG, ECNumber, ECNumberProposed, Spontaneous, DataSetWID, WID)
    End Function
#End Region
End Class


End Namespace
