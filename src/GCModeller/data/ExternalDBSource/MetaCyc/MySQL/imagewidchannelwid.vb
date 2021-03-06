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
''' DROP TABLE IF EXISTS `imagewidchannelwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `imagewidchannelwid` (
'''   `ImageWID` bigint(20) NOT NULL,
'''   `ChannelWID` bigint(20) NOT NULL,
'''   KEY `FK_ImageWIDChannelWID1` (`ImageWID`),
'''   KEY `FK_ImageWIDChannelWID2` (`ChannelWID`),
'''   CONSTRAINT `FK_ImageWIDChannelWID1` FOREIGN KEY (`ImageWID`) REFERENCES `image` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ImageWIDChannelWID2` FOREIGN KEY (`ChannelWID`) REFERENCES `channel` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("imagewidchannelwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `imagewidchannelwid` (
  `ImageWID` bigint(20) NOT NULL,
  `ChannelWID` bigint(20) NOT NULL,
  KEY `FK_ImageWIDChannelWID1` (`ImageWID`),
  KEY `FK_ImageWIDChannelWID2` (`ChannelWID`),
  CONSTRAINT `FK_ImageWIDChannelWID1` FOREIGN KEY (`ImageWID`) REFERENCES `image` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ImageWIDChannelWID2` FOREIGN KEY (`ChannelWID`) REFERENCES `channel` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class imagewidchannelwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ImageWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ImageWID As Long
    <DatabaseField("ChannelWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ChannelWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `imagewidchannelwid` (`ImageWID`, `ChannelWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `imagewidchannelwid` (`ImageWID`, `ChannelWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `imagewidchannelwid` WHERE `ImageWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `imagewidchannelwid` SET `ImageWID`='{0}', `ChannelWID`='{1}' WHERE `ImageWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `imagewidchannelwid` WHERE `ImageWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ImageWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `imagewidchannelwid` (`ImageWID`, `ChannelWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ImageWID, ChannelWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ImageWID}', '{ChannelWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `imagewidchannelwid` (`ImageWID`, `ChannelWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ImageWID, ChannelWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `imagewidchannelwid` SET `ImageWID`='{0}', `ChannelWID`='{1}' WHERE `ImageWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ImageWID, ChannelWID, ImageWID)
    End Function
#End Region
End Class


End Namespace
