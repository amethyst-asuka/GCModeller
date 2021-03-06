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
''' DROP TABLE IF EXISTS `citation`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `citation` (
'''   `WID` bigint(20) NOT NULL,
'''   `Citation` text,
'''   `PMID` decimal(10,0) DEFAULT NULL,
'''   `Title` varchar(255) DEFAULT NULL,
'''   `Authors` varchar(255) DEFAULT NULL,
'''   `Publication` varchar(255) DEFAULT NULL,
'''   `Publisher` varchar(255) DEFAULT NULL,
'''   `Editor` varchar(255) DEFAULT NULL,
'''   `Year` varchar(255) DEFAULT NULL,
'''   `Volume` varchar(255) DEFAULT NULL,
'''   `Issue` varchar(255) DEFAULT NULL,
'''   `Pages` varchar(255) DEFAULT NULL,
'''   `URI` varchar(255) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `CITATION_PMID` (`PMID`),
'''   KEY `CITATION_CITATION` (`Citation`(20)),
'''   KEY `FK_Citation` (`DataSetWID`),
'''   CONSTRAINT `FK_Citation` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("citation", Database:="warehouse", SchemaSQL:="
CREATE TABLE `citation` (
  `WID` bigint(20) NOT NULL,
  `Citation` text,
  `PMID` decimal(10,0) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Authors` varchar(255) DEFAULT NULL,
  `Publication` varchar(255) DEFAULT NULL,
  `Publisher` varchar(255) DEFAULT NULL,
  `Editor` varchar(255) DEFAULT NULL,
  `Year` varchar(255) DEFAULT NULL,
  `Volume` varchar(255) DEFAULT NULL,
  `Issue` varchar(255) DEFAULT NULL,
  `Pages` varchar(255) DEFAULT NULL,
  `URI` varchar(255) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `CITATION_PMID` (`PMID`),
  KEY `CITATION_CITATION` (`Citation`(20)),
  KEY `FK_Citation` (`DataSetWID`),
  CONSTRAINT `FK_Citation` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class citation: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("Citation"), DataType(MySqlDbType.Text)> Public Property Citation As String
    <DatabaseField("PMID"), DataType(MySqlDbType.Decimal)> Public Property PMID As Decimal
    <DatabaseField("Title"), DataType(MySqlDbType.VarChar, "255")> Public Property Title As String
    <DatabaseField("Authors"), DataType(MySqlDbType.VarChar, "255")> Public Property Authors As String
    <DatabaseField("Publication"), DataType(MySqlDbType.VarChar, "255")> Public Property Publication As String
    <DatabaseField("Publisher"), DataType(MySqlDbType.VarChar, "255")> Public Property Publisher As String
    <DatabaseField("Editor"), DataType(MySqlDbType.VarChar, "255")> Public Property Editor As String
    <DatabaseField("Year"), DataType(MySqlDbType.VarChar, "255")> Public Property Year As String
    <DatabaseField("Volume"), DataType(MySqlDbType.VarChar, "255")> Public Property Volume As String
    <DatabaseField("Issue"), DataType(MySqlDbType.VarChar, "255")> Public Property Issue As String
    <DatabaseField("Pages"), DataType(MySqlDbType.VarChar, "255")> Public Property Pages As String
    <DatabaseField("URI"), DataType(MySqlDbType.VarChar, "255")> Public Property URI As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `citation` (`WID`, `Citation`, `PMID`, `Title`, `Authors`, `Publication`, `Publisher`, `Editor`, `Year`, `Volume`, `Issue`, `Pages`, `URI`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `citation` (`WID`, `Citation`, `PMID`, `Title`, `Authors`, `Publication`, `Publisher`, `Editor`, `Year`, `Volume`, `Issue`, `Pages`, `URI`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `citation` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `citation` SET `WID`='{0}', `Citation`='{1}', `PMID`='{2}', `Title`='{3}', `Authors`='{4}', `Publication`='{5}', `Publisher`='{6}', `Editor`='{7}', `Year`='{8}', `Volume`='{9}', `Issue`='{10}', `Pages`='{11}', `URI`='{12}', `DataSetWID`='{13}' WHERE `WID` = '{14}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `citation` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `citation` (`WID`, `Citation`, `PMID`, `Title`, `Authors`, `Publication`, `Publisher`, `Editor`, `Year`, `Volume`, `Issue`, `Pages`, `URI`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, Citation, PMID, Title, Authors, Publication, Publisher, Editor, Year, Volume, Issue, Pages, URI, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{Citation}', '{PMID}', '{Title}', '{Authors}', '{Publication}', '{Publisher}', '{Editor}', '{Year}', '{Volume}', '{Issue}', '{Pages}', '{URI}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `citation` (`WID`, `Citation`, `PMID`, `Title`, `Authors`, `Publication`, `Publisher`, `Editor`, `Year`, `Volume`, `Issue`, `Pages`, `URI`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, Citation, PMID, Title, Authors, Publication, Publisher, Editor, Year, Volume, Issue, Pages, URI, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `citation` SET `WID`='{0}', `Citation`='{1}', `PMID`='{2}', `Title`='{3}', `Authors`='{4}', `Publication`='{5}', `Publisher`='{6}', `Editor`='{7}', `Year`='{8}', `Volume`='{9}', `Issue`='{10}', `Pages`='{11}', `URI`='{12}', `DataSetWID`='{13}' WHERE `WID` = '{14}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, Citation, PMID, Title, Authors, Publication, Publisher, Editor, Year, Volume, Issue, Pages, URI, DataSetWID, WID)
    End Function
#End Region
End Class


End Namespace
