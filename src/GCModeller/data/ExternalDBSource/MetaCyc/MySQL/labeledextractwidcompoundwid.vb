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
''' DROP TABLE IF EXISTS `labeledextractwidcompoundwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `labeledextractwidcompoundwid` (
'''   `LabeledExtractWID` bigint(20) NOT NULL,
'''   `CompoundWID` bigint(20) NOT NULL,
'''   KEY `FK_LabeledExtractWIDCompound1` (`LabeledExtractWID`),
'''   KEY `FK_LabeledExtractWIDCompound2` (`CompoundWID`),
'''   CONSTRAINT `FK_LabeledExtractWIDCompound1` FOREIGN KEY (`LabeledExtractWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_LabeledExtractWIDCompound2` FOREIGN KEY (`CompoundWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("labeledextractwidcompoundwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `labeledextractwidcompoundwid` (
  `LabeledExtractWID` bigint(20) NOT NULL,
  `CompoundWID` bigint(20) NOT NULL,
  KEY `FK_LabeledExtractWIDCompound1` (`LabeledExtractWID`),
  KEY `FK_LabeledExtractWIDCompound2` (`CompoundWID`),
  CONSTRAINT `FK_LabeledExtractWIDCompound1` FOREIGN KEY (`LabeledExtractWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_LabeledExtractWIDCompound2` FOREIGN KEY (`CompoundWID`) REFERENCES `chemical` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class labeledextractwidcompoundwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("LabeledExtractWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property LabeledExtractWID As Long
    <DatabaseField("CompoundWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property CompoundWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `labeledextractwidcompoundwid` (`LabeledExtractWID`, `CompoundWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `labeledextractwidcompoundwid` (`LabeledExtractWID`, `CompoundWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `labeledextractwidcompoundwid` WHERE `LabeledExtractWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `labeledextractwidcompoundwid` SET `LabeledExtractWID`='{0}', `CompoundWID`='{1}' WHERE `LabeledExtractWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `labeledextractwidcompoundwid` WHERE `LabeledExtractWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, LabeledExtractWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `labeledextractwidcompoundwid` (`LabeledExtractWID`, `CompoundWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, LabeledExtractWID, CompoundWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{LabeledExtractWID}', '{CompoundWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `labeledextractwidcompoundwid` (`LabeledExtractWID`, `CompoundWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, LabeledExtractWID, CompoundWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `labeledextractwidcompoundwid` SET `LabeledExtractWID`='{0}', `CompoundWID`='{1}' WHERE `LabeledExtractWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, LabeledExtractWID, CompoundWID, LabeledExtractWID)
    End Function
#End Region
End Class


End Namespace
