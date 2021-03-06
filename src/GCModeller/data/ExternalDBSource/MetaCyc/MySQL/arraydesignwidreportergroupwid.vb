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
''' DROP TABLE IF EXISTS `arraydesignwidreportergroupwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `arraydesignwidreportergroupwid` (
'''   `ArrayDesignWID` bigint(20) NOT NULL,
'''   `ReporterGroupWID` bigint(20) NOT NULL,
'''   KEY `FK_ArrayDesignWIDReporterGro1` (`ArrayDesignWID`),
'''   KEY `FK_ArrayDesignWIDReporterGro2` (`ReporterGroupWID`),
'''   CONSTRAINT `FK_ArrayDesignWIDReporterGro1` FOREIGN KEY (`ArrayDesignWID`) REFERENCES `arraydesign` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ArrayDesignWIDReporterGro2` FOREIGN KEY (`ReporterGroupWID`) REFERENCES `designelementgroup` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("arraydesignwidreportergroupwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `arraydesignwidreportergroupwid` (
  `ArrayDesignWID` bigint(20) NOT NULL,
  `ReporterGroupWID` bigint(20) NOT NULL,
  KEY `FK_ArrayDesignWIDReporterGro1` (`ArrayDesignWID`),
  KEY `FK_ArrayDesignWIDReporterGro2` (`ReporterGroupWID`),
  CONSTRAINT `FK_ArrayDesignWIDReporterGro1` FOREIGN KEY (`ArrayDesignWID`) REFERENCES `arraydesign` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ArrayDesignWIDReporterGro2` FOREIGN KEY (`ReporterGroupWID`) REFERENCES `designelementgroup` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class arraydesignwidreportergroupwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ArrayDesignWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ArrayDesignWID As Long
    <DatabaseField("ReporterGroupWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ReporterGroupWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `arraydesignwidreportergroupwid` (`ArrayDesignWID`, `ReporterGroupWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `arraydesignwidreportergroupwid` (`ArrayDesignWID`, `ReporterGroupWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `arraydesignwidreportergroupwid` WHERE `ArrayDesignWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `arraydesignwidreportergroupwid` SET `ArrayDesignWID`='{0}', `ReporterGroupWID`='{1}' WHERE `ArrayDesignWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `arraydesignwidreportergroupwid` WHERE `ArrayDesignWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ArrayDesignWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `arraydesignwidreportergroupwid` (`ArrayDesignWID`, `ReporterGroupWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ArrayDesignWID, ReporterGroupWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ArrayDesignWID}', '{ReporterGroupWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `arraydesignwidreportergroupwid` (`ArrayDesignWID`, `ReporterGroupWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ArrayDesignWID, ReporterGroupWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `arraydesignwidreportergroupwid` SET `ArrayDesignWID`='{0}', `ReporterGroupWID`='{1}' WHERE `ArrayDesignWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ArrayDesignWID, ReporterGroupWID, ArrayDesignWID)
    End Function
#End Region
End Class


End Namespace
