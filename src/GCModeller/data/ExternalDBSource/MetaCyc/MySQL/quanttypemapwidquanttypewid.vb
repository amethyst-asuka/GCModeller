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
''' DROP TABLE IF EXISTS `quanttypemapwidquanttypewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `quanttypemapwidquanttypewid` (
'''   `QuantitationTypeMapWID` bigint(20) NOT NULL,
'''   `QuantitationTypeWID` bigint(20) NOT NULL,
'''   KEY `FK_QuantTypeMapWIDQuantTypeW1` (`QuantitationTypeMapWID`),
'''   KEY `FK_QuantTypeMapWIDQuantTypeW2` (`QuantitationTypeWID`),
'''   CONSTRAINT `FK_QuantTypeMapWIDQuantTypeW1` FOREIGN KEY (`QuantitationTypeMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantTypeMapWIDQuantTypeW2` FOREIGN KEY (`QuantitationTypeWID`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("quanttypemapwidquanttypewid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `quanttypemapwidquanttypewid` (
  `QuantitationTypeMapWID` bigint(20) NOT NULL,
  `QuantitationTypeWID` bigint(20) NOT NULL,
  KEY `FK_QuantTypeMapWIDQuantTypeW1` (`QuantitationTypeMapWID`),
  KEY `FK_QuantTypeMapWIDQuantTypeW2` (`QuantitationTypeWID`),
  CONSTRAINT `FK_QuantTypeMapWIDQuantTypeW1` FOREIGN KEY (`QuantitationTypeMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_QuantTypeMapWIDQuantTypeW2` FOREIGN KEY (`QuantitationTypeWID`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class quanttypemapwidquanttypewid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("QuantitationTypeMapWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property QuantitationTypeMapWID As Long
    <DatabaseField("QuantitationTypeWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property QuantitationTypeWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `quanttypemapwidquanttypewid` (`QuantitationTypeMapWID`, `QuantitationTypeWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `quanttypemapwidquanttypewid` (`QuantitationTypeMapWID`, `QuantitationTypeWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `quanttypemapwidquanttypewid` WHERE `QuantitationTypeMapWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `quanttypemapwidquanttypewid` SET `QuantitationTypeMapWID`='{0}', `QuantitationTypeWID`='{1}' WHERE `QuantitationTypeMapWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `quanttypemapwidquanttypewid` WHERE `QuantitationTypeMapWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, QuantitationTypeMapWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `quanttypemapwidquanttypewid` (`QuantitationTypeMapWID`, `QuantitationTypeWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, QuantitationTypeMapWID, QuantitationTypeWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{QuantitationTypeMapWID}', '{QuantitationTypeWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `quanttypemapwidquanttypewid` (`QuantitationTypeMapWID`, `QuantitationTypeWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, QuantitationTypeMapWID, QuantitationTypeWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `quanttypemapwidquanttypewid` SET `QuantitationTypeMapWID`='{0}', `QuantitationTypeWID`='{1}' WHERE `QuantitationTypeMapWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, QuantitationTypeMapWID, QuantitationTypeWID, QuantitationTypeMapWID)
    End Function
#End Region
End Class


End Namespace
