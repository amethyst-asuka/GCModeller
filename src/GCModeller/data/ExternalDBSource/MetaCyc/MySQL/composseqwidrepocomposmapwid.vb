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
''' DROP TABLE IF EXISTS `composseqwidrepocomposmapwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `composseqwidrepocomposmapwid` (
'''   `CompositeSequenceWID` bigint(20) NOT NULL,
'''   `ReporterCompositeMapWID` bigint(20) NOT NULL,
'''   KEY `FK_ComposSeqWIDRepoComposMap1` (`CompositeSequenceWID`),
'''   KEY `FK_ComposSeqWIDRepoComposMap2` (`ReporterCompositeMapWID`),
'''   CONSTRAINT `FK_ComposSeqWIDRepoComposMap1` FOREIGN KEY (`CompositeSequenceWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ComposSeqWIDRepoComposMap2` FOREIGN KEY (`ReporterCompositeMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("composseqwidrepocomposmapwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `composseqwidrepocomposmapwid` (
  `CompositeSequenceWID` bigint(20) NOT NULL,
  `ReporterCompositeMapWID` bigint(20) NOT NULL,
  KEY `FK_ComposSeqWIDRepoComposMap1` (`CompositeSequenceWID`),
  KEY `FK_ComposSeqWIDRepoComposMap2` (`ReporterCompositeMapWID`),
  CONSTRAINT `FK_ComposSeqWIDRepoComposMap1` FOREIGN KEY (`CompositeSequenceWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ComposSeqWIDRepoComposMap2` FOREIGN KEY (`ReporterCompositeMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class composseqwidrepocomposmapwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("CompositeSequenceWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property CompositeSequenceWID As Long
    <DatabaseField("ReporterCompositeMapWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ReporterCompositeMapWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `composseqwidrepocomposmapwid` (`CompositeSequenceWID`, `ReporterCompositeMapWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `composseqwidrepocomposmapwid` (`CompositeSequenceWID`, `ReporterCompositeMapWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `composseqwidrepocomposmapwid` WHERE `CompositeSequenceWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `composseqwidrepocomposmapwid` SET `CompositeSequenceWID`='{0}', `ReporterCompositeMapWID`='{1}' WHERE `CompositeSequenceWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `composseqwidrepocomposmapwid` WHERE `CompositeSequenceWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, CompositeSequenceWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `composseqwidrepocomposmapwid` (`CompositeSequenceWID`, `ReporterCompositeMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, CompositeSequenceWID, ReporterCompositeMapWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{CompositeSequenceWID}', '{ReporterCompositeMapWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `composseqwidrepocomposmapwid` (`CompositeSequenceWID`, `ReporterCompositeMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, CompositeSequenceWID, ReporterCompositeMapWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `composseqwidrepocomposmapwid` SET `CompositeSequenceWID`='{0}', `ReporterCompositeMapWID`='{1}' WHERE `CompositeSequenceWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, CompositeSequenceWID, ReporterCompositeMapWID, CompositeSequenceWID)
    End Function
#End Region
End Class


End Namespace
