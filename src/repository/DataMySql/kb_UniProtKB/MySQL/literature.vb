REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2017/9/3 12:29:35


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports System.Xml.Serialization

Namespace kb_UniProtKB.mysql

''' <summary>
''' ```SQL
''' 文献报道数据
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `literature`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `literature` (
'''   `uid` int(10) unsigned NOT NULL AUTO_INCREMENT,
'''   `type` varchar(45) DEFAULT NULL,
'''   `date` varchar(45) DEFAULT NULL,
'''   `db` varchar(45) DEFAULT NULL,
'''   `title` varchar(45) DEFAULT NULL,
'''   `pubmed` varchar(45) DEFAULT NULL,
'''   `doi` varchar(45) DEFAULT NULL,
'''   `volume` varchar(45) DEFAULT NULL,
'''   `pages` varchar(45) DEFAULT NULL,
'''   `journal` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`uid`),
'''   UNIQUE KEY `uid_UNIQUE` (`uid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='文献报道数据';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("literature", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `literature` (
  `uid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `type` varchar(45) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  `db` varchar(45) DEFAULT NULL,
  `title` varchar(45) DEFAULT NULL,
  `pubmed` varchar(45) DEFAULT NULL,
  `doi` varchar(45) DEFAULT NULL,
  `volume` varchar(45) DEFAULT NULL,
  `pages` varchar(45) DEFAULT NULL,
  `journal` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`uid`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='文献报道数据';")>
Public Class literature: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("uid"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="uid"), XmlAttribute> Public Property uid As Long
    <DatabaseField("type"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="type")> Public Property type As String
    <DatabaseField("date"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="date")> Public Property [date] As String
    <DatabaseField("db"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="db")> Public Property db As String
    <DatabaseField("title"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="title")> Public Property title As String
    <DatabaseField("pubmed"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="pubmed")> Public Property pubmed As String
    <DatabaseField("doi"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="doi")> Public Property doi As String
    <DatabaseField("volume"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="volume")> Public Property volume As String
    <DatabaseField("pages"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="pages")> Public Property pages As String
    <DatabaseField("journal"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="journal")> Public Property journal As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `literature` (`uid`, `type`, `date`, `db`, `title`, `pubmed`, `doi`, `volume`, `pages`, `journal`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `literature` (`uid`, `type`, `date`, `db`, `title`, `pubmed`, `doi`, `volume`, `pages`, `journal`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `literature` WHERE `uid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `literature` SET `uid`='{0}', `type`='{1}', `date`='{2}', `db`='{3}', `title`='{4}', `pubmed`='{5}', `doi`='{6}', `volume`='{7}', `pages`='{8}', `journal`='{9}' WHERE `uid` = '{10}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `literature` WHERE `uid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, uid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `literature` (`uid`, `type`, `date`, `db`, `title`, `pubmed`, `doi`, `volume`, `pages`, `journal`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, uid, type, [date], db, title, pubmed, doi, volume, pages, journal)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{uid}', '{type}', '{[date]}', '{db}', '{title}', '{pubmed}', '{doi}', '{volume}', '{pages}', '{journal}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `literature` (`uid`, `type`, `date`, `db`, `title`, `pubmed`, `doi`, `volume`, `pages`, `journal`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, uid, type, [date], db, title, pubmed, doi, volume, pages, journal)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `literature` SET `uid`='{0}', `type`='{1}', `date`='{2}', `db`='{3}', `title`='{4}', `pubmed`='{5}', `doi`='{6}', `volume`='{7}', `pages`='{8}', `journal`='{9}' WHERE `uid` = '{10}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, uid, type, [date], db, title, pubmed, doi, volume, pages, journal, uid)
    End Function
#End Region
Public Function Clone() As literature
                  Return DirectCast(MyClass.MemberwiseClone, literature)
              End Function
End Class


End Namespace
