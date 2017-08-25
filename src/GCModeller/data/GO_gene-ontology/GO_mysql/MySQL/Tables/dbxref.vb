REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:59 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `dbxref`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dbxref` (
'''   `id` int(11) NOT NULL AUTO_INCREMENT,
'''   `xref_dbname` varchar(55) NOT NULL,
'''   `xref_key` varchar(255) NOT NULL,
'''   `xref_keytype` varchar(32) DEFAULT NULL,
'''   `xref_desc` varchar(255) DEFAULT NULL,
'''   PRIMARY KEY (`id`),
'''   UNIQUE KEY `xref_key` (`xref_key`,`xref_dbname`),
'''   UNIQUE KEY `dx0` (`id`),
'''   UNIQUE KEY `dx6` (`xref_key`,`xref_dbname`),
'''   KEY `dx1` (`xref_dbname`),
'''   KEY `dx2` (`xref_key`),
'''   KEY `dx3` (`id`,`xref_dbname`),
'''   KEY `dx4` (`id`,`xref_key`,`xref_dbname`),
'''   KEY `dx5` (`id`,`xref_key`)
''' ) ENGINE=MyISAM AUTO_INCREMENT=85803 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dbxref", Database:="go", SchemaSQL:="
CREATE TABLE `dbxref` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `xref_dbname` varchar(55) NOT NULL,
  `xref_key` varchar(255) NOT NULL,
  `xref_keytype` varchar(32) DEFAULT NULL,
  `xref_desc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `xref_key` (`xref_key`,`xref_dbname`),
  UNIQUE KEY `dx0` (`id`),
  UNIQUE KEY `dx6` (`xref_key`,`xref_dbname`),
  KEY `dx1` (`xref_dbname`),
  KEY `dx2` (`xref_key`),
  KEY `dx3` (`id`,`xref_dbname`),
  KEY `dx4` (`id`,`xref_key`,`xref_dbname`),
  KEY `dx5` (`id`,`xref_key`)
) ENGINE=MyISAM AUTO_INCREMENT=85803 DEFAULT CHARSET=latin1;")>
Public Class dbxref: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("xref_dbname"), NotNull, DataType(MySqlDbType.VarChar, "55")> Public Property xref_dbname As String
    <DatabaseField("xref_key"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property xref_key As String
    <DatabaseField("xref_keytype"), DataType(MySqlDbType.VarChar, "32")> Public Property xref_keytype As String
    <DatabaseField("xref_desc"), DataType(MySqlDbType.VarChar, "255")> Public Property xref_desc As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `dbxref` (`xref_dbname`, `xref_key`, `xref_keytype`, `xref_desc`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `dbxref` (`xref_dbname`, `xref_key`, `xref_keytype`, `xref_desc`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `dbxref` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `dbxref` SET `id`='{0}', `xref_dbname`='{1}', `xref_key`='{2}', `xref_keytype`='{3}', `xref_desc`='{4}' WHERE `id` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `dbxref` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `dbxref` (`xref_dbname`, `xref_key`, `xref_keytype`, `xref_desc`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, xref_dbname, xref_key, xref_keytype, xref_desc)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{xref_dbname}', '{xref_key}', '{xref_keytype}', '{xref_desc}', '{4}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dbxref` (`xref_dbname`, `xref_key`, `xref_keytype`, `xref_desc`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, xref_dbname, xref_key, xref_keytype, xref_desc)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `dbxref` SET `id`='{0}', `xref_dbname`='{1}', `xref_key`='{2}', `xref_keytype`='{3}', `xref_desc`='{4}' WHERE `id` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, xref_dbname, xref_key, xref_keytype, xref_desc, id)
    End Function
#End Region
End Class


End Namespace
