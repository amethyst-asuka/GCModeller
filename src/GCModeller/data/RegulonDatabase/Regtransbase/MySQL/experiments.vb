REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 10:54:58 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `experiments`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `experiments` (
'''   `exp_guid` int(11) NOT NULL DEFAULT '0',
'''   `pkg_guid` int(11) NOT NULL DEFAULT '0',
'''   `art_guid` int(11) NOT NULL DEFAULT '0',
'''   `descript` blob,
'''   `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   PRIMARY KEY (`exp_guid`),
'''   KEY `FK_experiments-pkg_guid` (`pkg_guid`),
'''   KEY `FK_experiments-art_guid` (`art_guid`),
'''   CONSTRAINT `FK_experiments-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
'''   CONSTRAINT `FK_experiments-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("experiments", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `experiments` (
  `exp_guid` int(11) NOT NULL DEFAULT '0',
  `pkg_guid` int(11) NOT NULL DEFAULT '0',
  `art_guid` int(11) NOT NULL DEFAULT '0',
  `descript` blob,
  `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`exp_guid`),
  KEY `FK_experiments-pkg_guid` (`pkg_guid`),
  KEY `FK_experiments-art_guid` (`art_guid`),
  CONSTRAINT `FK_experiments-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
  CONSTRAINT `FK_experiments-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class experiments: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("exp_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property exp_guid As Long
    <DatabaseField("pkg_guid"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property pkg_guid As Long
    <DatabaseField("art_guid"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property art_guid As Long
    <DatabaseField("descript"), DataType(MySqlDbType.Blob)> Public Property descript As Byte()
    <DatabaseField("last_update"), NotNull, DataType(MySqlDbType.DateTime)> Public Property last_update As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `experiments` (`exp_guid`, `pkg_guid`, `art_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `experiments` (`exp_guid`, `pkg_guid`, `art_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `experiments` WHERE `exp_guid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `experiments` SET `exp_guid`='{0}', `pkg_guid`='{1}', `art_guid`='{2}', `descript`='{3}', `last_update`='{4}' WHERE `exp_guid` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `experiments` WHERE `exp_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, exp_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `experiments` (`exp_guid`, `pkg_guid`, `art_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, exp_guid, pkg_guid, art_guid, descript, DataType.ToMySqlDateTimeString(last_update))
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{exp_guid}', '{pkg_guid}', '{art_guid}', '{descript}', '{last_update}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `experiments` (`exp_guid`, `pkg_guid`, `art_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, exp_guid, pkg_guid, art_guid, descript, DataType.ToMySqlDateTimeString(last_update))
    End Function
''' <summary>
''' ```SQL
''' UPDATE `experiments` SET `exp_guid`='{0}', `pkg_guid`='{1}', `art_guid`='{2}', `descript`='{3}', `last_update`='{4}' WHERE `exp_guid` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, exp_guid, pkg_guid, art_guid, descript, DataType.ToMySqlDateTimeString(last_update), exp_guid)
    End Function
#End Region
End Class


End Namespace
