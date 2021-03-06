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
''' DROP TABLE IF EXISTS `spotwidspotidmethodwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `spotwidspotidmethodwid` (
'''   `SpotWID` bigint(20) NOT NULL,
'''   `SpotIdMethodWID` bigint(20) NOT NULL,
'''   KEY `FK_SpotWIDMethWID1` (`SpotWID`),
'''   KEY `FK_SpotWIDMethWID2` (`SpotIdMethodWID`),
'''   CONSTRAINT `FK_SpotWIDMethWID1` FOREIGN KEY (`SpotWID`) REFERENCES `spot` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_SpotWIDMethWID2` FOREIGN KEY (`SpotIdMethodWID`) REFERENCES `spotidmethod` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("spotwidspotidmethodwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `spotwidspotidmethodwid` (
  `SpotWID` bigint(20) NOT NULL,
  `SpotIdMethodWID` bigint(20) NOT NULL,
  KEY `FK_SpotWIDMethWID1` (`SpotWID`),
  KEY `FK_SpotWIDMethWID2` (`SpotIdMethodWID`),
  CONSTRAINT `FK_SpotWIDMethWID1` FOREIGN KEY (`SpotWID`) REFERENCES `spot` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_SpotWIDMethWID2` FOREIGN KEY (`SpotIdMethodWID`) REFERENCES `spotidmethod` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class spotwidspotidmethodwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("SpotWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SpotWID As Long
    <DatabaseField("SpotIdMethodWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SpotIdMethodWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `spotwidspotidmethodwid` (`SpotWID`, `SpotIdMethodWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `spotwidspotidmethodwid` (`SpotWID`, `SpotIdMethodWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `spotwidspotidmethodwid` WHERE `SpotWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `spotwidspotidmethodwid` SET `SpotWID`='{0}', `SpotIdMethodWID`='{1}' WHERE `SpotWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `spotwidspotidmethodwid` WHERE `SpotWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, SpotWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `spotwidspotidmethodwid` (`SpotWID`, `SpotIdMethodWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, SpotWID, SpotIdMethodWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{SpotWID}', '{SpotIdMethodWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `spotwidspotidmethodwid` (`SpotWID`, `SpotIdMethodWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, SpotWID, SpotIdMethodWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `spotwidspotidmethodwid` SET `SpotWID`='{0}', `SpotIdMethodWID`='{1}' WHERE `SpotWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, SpotWID, SpotIdMethodWID, SpotWID)
    End Function
#End Region
End Class


End Namespace
