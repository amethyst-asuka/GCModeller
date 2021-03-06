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
''' DROP TABLE IF EXISTS `transcriptionunitcomponent`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `transcriptionunitcomponent` (
'''   `Type` varchar(100) NOT NULL,
'''   `TranscriptionUnitWID` bigint(20) NOT NULL,
'''   `OtherWID` bigint(20) NOT NULL,
'''   KEY `FK_TranscriptionUnitComponent1` (`TranscriptionUnitWID`),
'''   CONSTRAINT `FK_TranscriptionUnitComponent1` FOREIGN KEY (`TranscriptionUnitWID`) REFERENCES `transcriptionunit` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("transcriptionunitcomponent", Database:="warehouse", SchemaSQL:="
CREATE TABLE `transcriptionunitcomponent` (
  `Type` varchar(100) NOT NULL,
  `TranscriptionUnitWID` bigint(20) NOT NULL,
  `OtherWID` bigint(20) NOT NULL,
  KEY `FK_TranscriptionUnitComponent1` (`TranscriptionUnitWID`),
  CONSTRAINT `FK_TranscriptionUnitComponent1` FOREIGN KEY (`TranscriptionUnitWID`) REFERENCES `transcriptionunit` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class transcriptionunitcomponent: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("Type"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property Type As String
    <DatabaseField("TranscriptionUnitWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property TranscriptionUnitWID As Long
    <DatabaseField("OtherWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property OtherWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `transcriptionunitcomponent` (`Type`, `TranscriptionUnitWID`, `OtherWID`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `transcriptionunitcomponent` (`Type`, `TranscriptionUnitWID`, `OtherWID`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `transcriptionunitcomponent` WHERE `TranscriptionUnitWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `transcriptionunitcomponent` SET `Type`='{0}', `TranscriptionUnitWID`='{1}', `OtherWID`='{2}' WHERE `TranscriptionUnitWID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `transcriptionunitcomponent` WHERE `TranscriptionUnitWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, TranscriptionUnitWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `transcriptionunitcomponent` (`Type`, `TranscriptionUnitWID`, `OtherWID`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, Type, TranscriptionUnitWID, OtherWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{Type}', '{TranscriptionUnitWID}', '{OtherWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `transcriptionunitcomponent` (`Type`, `TranscriptionUnitWID`, `OtherWID`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, Type, TranscriptionUnitWID, OtherWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `transcriptionunitcomponent` SET `Type`='{0}', `TranscriptionUnitWID`='{1}', `OtherWID`='{2}' WHERE `TranscriptionUnitWID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, Type, TranscriptionUnitWID, OtherWID, TranscriptionUnitWID)
    End Function
#End Region
End Class


End Namespace
