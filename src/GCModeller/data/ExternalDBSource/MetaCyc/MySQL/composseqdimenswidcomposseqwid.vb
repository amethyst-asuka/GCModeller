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
''' DROP TABLE IF EXISTS `composseqdimenswidcomposseqwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `composseqdimenswidcomposseqwid` (
'''   `CompositeSequenceDimensionWID` bigint(20) NOT NULL,
'''   `CompositeSequenceWID` bigint(20) NOT NULL,
'''   KEY `FK_ComposSeqDimensWIDComposS1` (`CompositeSequenceDimensionWID`),
'''   KEY `FK_ComposSeqDimensWIDComposS2` (`CompositeSequenceWID`),
'''   CONSTRAINT `FK_ComposSeqDimensWIDComposS1` FOREIGN KEY (`CompositeSequenceDimensionWID`) REFERENCES `designelementdimension` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ComposSeqDimensWIDComposS2` FOREIGN KEY (`CompositeSequenceWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("composseqdimenswidcomposseqwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `composseqdimenswidcomposseqwid` (
  `CompositeSequenceDimensionWID` bigint(20) NOT NULL,
  `CompositeSequenceWID` bigint(20) NOT NULL,
  KEY `FK_ComposSeqDimensWIDComposS1` (`CompositeSequenceDimensionWID`),
  KEY `FK_ComposSeqDimensWIDComposS2` (`CompositeSequenceWID`),
  CONSTRAINT `FK_ComposSeqDimensWIDComposS1` FOREIGN KEY (`CompositeSequenceDimensionWID`) REFERENCES `designelementdimension` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ComposSeqDimensWIDComposS2` FOREIGN KEY (`CompositeSequenceWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class composseqdimenswidcomposseqwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("CompositeSequenceDimensionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property CompositeSequenceDimensionWID As Long
    <DatabaseField("CompositeSequenceWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property CompositeSequenceWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `composseqdimenswidcomposseqwid` WHERE `CompositeSequenceDimensionWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `composseqdimenswidcomposseqwid` SET `CompositeSequenceDimensionWID`='{0}', `CompositeSequenceWID`='{1}' WHERE `CompositeSequenceDimensionWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `composseqdimenswidcomposseqwid` WHERE `CompositeSequenceDimensionWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, CompositeSequenceDimensionWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, CompositeSequenceDimensionWID, CompositeSequenceWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{CompositeSequenceDimensionWID}', '{CompositeSequenceWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, CompositeSequenceDimensionWID, CompositeSequenceWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `composseqdimenswidcomposseqwid` SET `CompositeSequenceDimensionWID`='{0}', `CompositeSequenceWID`='{1}' WHERE `CompositeSequenceDimensionWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, CompositeSequenceDimensionWID, CompositeSequenceWID, CompositeSequenceDimensionWID)
    End Function
#End Region
End Class


End Namespace
