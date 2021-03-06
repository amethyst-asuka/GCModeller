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
''' DROP TABLE IF EXISTS `quanttymapwidquanttymapwi`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `quanttymapwidquanttymapwi` (
'''   `QuantitationTypeMappingWID` bigint(20) NOT NULL,
'''   `QuantitationTypeMapWID` bigint(20) NOT NULL,
'''   KEY `FK_QuantTyMapWIDQuantTyMapWI1` (`QuantitationTypeMappingWID`),
'''   KEY `FK_QuantTyMapWIDQuantTyMapWI2` (`QuantitationTypeMapWID`),
'''   CONSTRAINT `FK_QuantTyMapWIDQuantTyMapWI1` FOREIGN KEY (`QuantitationTypeMappingWID`) REFERENCES `quantitationtypemapping` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantTyMapWIDQuantTyMapWI2` FOREIGN KEY (`QuantitationTypeMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("quanttymapwidquanttymapwi", Database:="warehouse", SchemaSQL:="
CREATE TABLE `quanttymapwidquanttymapwi` (
  `QuantitationTypeMappingWID` bigint(20) NOT NULL,
  `QuantitationTypeMapWID` bigint(20) NOT NULL,
  KEY `FK_QuantTyMapWIDQuantTyMapWI1` (`QuantitationTypeMappingWID`),
  KEY `FK_QuantTyMapWIDQuantTyMapWI2` (`QuantitationTypeMapWID`),
  CONSTRAINT `FK_QuantTyMapWIDQuantTyMapWI1` FOREIGN KEY (`QuantitationTypeMappingWID`) REFERENCES `quantitationtypemapping` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_QuantTyMapWIDQuantTyMapWI2` FOREIGN KEY (`QuantitationTypeMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class quanttymapwidquanttymapwi: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("QuantitationTypeMappingWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property QuantitationTypeMappingWID As Long
    <DatabaseField("QuantitationTypeMapWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property QuantitationTypeMapWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `quanttymapwidquanttymapwi` (`QuantitationTypeMappingWID`, `QuantitationTypeMapWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `quanttymapwidquanttymapwi` (`QuantitationTypeMappingWID`, `QuantitationTypeMapWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `quanttymapwidquanttymapwi` WHERE `QuantitationTypeMappingWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `quanttymapwidquanttymapwi` SET `QuantitationTypeMappingWID`='{0}', `QuantitationTypeMapWID`='{1}' WHERE `QuantitationTypeMappingWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `quanttymapwidquanttymapwi` WHERE `QuantitationTypeMappingWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, QuantitationTypeMappingWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `quanttymapwidquanttymapwi` (`QuantitationTypeMappingWID`, `QuantitationTypeMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, QuantitationTypeMappingWID, QuantitationTypeMapWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{QuantitationTypeMappingWID}', '{QuantitationTypeMapWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `quanttymapwidquanttymapwi` (`QuantitationTypeMappingWID`, `QuantitationTypeMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, QuantitationTypeMappingWID, QuantitationTypeMapWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `quanttymapwidquanttymapwi` SET `QuantitationTypeMappingWID`='{0}', `QuantitationTypeMapWID`='{1}' WHERE `QuantitationTypeMappingWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, QuantitationTypeMappingWID, QuantitationTypeMapWID, QuantitationTypeMappingWID)
    End Function
#End Region
End Class


End Namespace
