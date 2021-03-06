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
''' DROP TABLE IF EXISTS `compositeseqwidbioseqwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `compositeseqwidbioseqwid` (
'''   `CompositeSequenceWID` bigint(20) NOT NULL,
'''   `BioSequenceWID` bigint(20) NOT NULL,
'''   KEY `FK_CompositeSeqWIDBioSeqWID1` (`CompositeSequenceWID`),
'''   CONSTRAINT `FK_CompositeSeqWIDBioSeqWID1` FOREIGN KEY (`CompositeSequenceWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("compositeseqwidbioseqwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `compositeseqwidbioseqwid` (
  `CompositeSequenceWID` bigint(20) NOT NULL,
  `BioSequenceWID` bigint(20) NOT NULL,
  KEY `FK_CompositeSeqWIDBioSeqWID1` (`CompositeSequenceWID`),
  CONSTRAINT `FK_CompositeSeqWIDBioSeqWID1` FOREIGN KEY (`CompositeSequenceWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class compositeseqwidbioseqwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("CompositeSequenceWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property CompositeSequenceWID As Long
    <DatabaseField("BioSequenceWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioSequenceWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `compositeseqwidbioseqwid` (`CompositeSequenceWID`, `BioSequenceWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `compositeseqwidbioseqwid` (`CompositeSequenceWID`, `BioSequenceWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `compositeseqwidbioseqwid` WHERE `CompositeSequenceWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `compositeseqwidbioseqwid` SET `CompositeSequenceWID`='{0}', `BioSequenceWID`='{1}' WHERE `CompositeSequenceWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `compositeseqwidbioseqwid` WHERE `CompositeSequenceWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, CompositeSequenceWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `compositeseqwidbioseqwid` (`CompositeSequenceWID`, `BioSequenceWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, CompositeSequenceWID, BioSequenceWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{CompositeSequenceWID}', '{BioSequenceWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `compositeseqwidbioseqwid` (`CompositeSequenceWID`, `BioSequenceWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, CompositeSequenceWID, BioSequenceWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `compositeseqwidbioseqwid` SET `CompositeSequenceWID`='{0}', `BioSequenceWID`='{1}' WHERE `CompositeSequenceWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, CompositeSequenceWID, BioSequenceWID, CompositeSequenceWID)
    End Function
#End Region
End Class


End Namespace
