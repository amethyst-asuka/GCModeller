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
''' DROP TABLE IF EXISTS `geneticcode`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `geneticcode` (
'''   `WID` bigint(20) NOT NULL,
'''   `NCBIID` varchar(2) DEFAULT NULL,
'''   `Name` varchar(100) DEFAULT NULL,
'''   `TranslationTable` varchar(64) DEFAULT NULL,
'''   `StartCodon` varchar(64) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_GeneticCode` (`DataSetWID`),
'''   CONSTRAINT `FK_GeneticCode` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("geneticcode", Database:="warehouse", SchemaSQL:="
CREATE TABLE `geneticcode` (
  `WID` bigint(20) NOT NULL,
  `NCBIID` varchar(2) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `TranslationTable` varchar(64) DEFAULT NULL,
  `StartCodon` varchar(64) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_GeneticCode` (`DataSetWID`),
  CONSTRAINT `FK_GeneticCode` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class geneticcode: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("NCBIID"), DataType(MySqlDbType.VarChar, "2")> Public Property NCBIID As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "100")> Public Property Name As String
    <DatabaseField("TranslationTable"), DataType(MySqlDbType.VarChar, "64")> Public Property TranslationTable As String
    <DatabaseField("StartCodon"), DataType(MySqlDbType.VarChar, "64")> Public Property StartCodon As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `geneticcode` (`WID`, `NCBIID`, `Name`, `TranslationTable`, `StartCodon`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `geneticcode` (`WID`, `NCBIID`, `Name`, `TranslationTable`, `StartCodon`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `geneticcode` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `geneticcode` SET `WID`='{0}', `NCBIID`='{1}', `Name`='{2}', `TranslationTable`='{3}', `StartCodon`='{4}', `DataSetWID`='{5}' WHERE `WID` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `geneticcode` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `geneticcode` (`WID`, `NCBIID`, `Name`, `TranslationTable`, `StartCodon`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, NCBIID, Name, TranslationTable, StartCodon, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{NCBIID}', '{Name}', '{TranslationTable}', '{StartCodon}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `geneticcode` (`WID`, `NCBIID`, `Name`, `TranslationTable`, `StartCodon`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, NCBIID, Name, TranslationTable, StartCodon, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `geneticcode` SET `WID`='{0}', `NCBIID`='{1}', `Name`='{2}', `TranslationTable`='{3}', `StartCodon`='{4}', `DataSetWID`='{5}' WHERE `WID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, NCBIID, Name, TranslationTable, StartCodon, DataSetWID, WID)
    End Function
#End Region
End Class


End Namespace
