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
''' DROP TABLE IF EXISTS `term`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `term` (
'''   `id` int(11) NOT NULL AUTO_INCREMENT,
'''   `name` varchar(255) NOT NULL DEFAULT '',
'''   `term_type` varchar(55) NOT NULL,
'''   `acc` varchar(255) NOT NULL,
'''   `is_obsolete` int(11) NOT NULL DEFAULT '0',
'''   `is_root` int(11) NOT NULL DEFAULT '0',
'''   `is_relation` int(11) NOT NULL DEFAULT '0',
'''   PRIMARY KEY (`id`),
'''   UNIQUE KEY `acc` (`acc`),
'''   UNIQUE KEY `t0` (`id`),
'''   KEY `t1` (`name`),
'''   KEY `t2` (`term_type`),
'''   KEY `t3` (`acc`),
'''   KEY `t4` (`id`,`acc`),
'''   KEY `t5` (`id`,`name`),
'''   KEY `t6` (`id`,`term_type`),
'''   KEY `t7` (`id`,`acc`,`name`,`term_type`)
''' ) ENGINE=MyISAM AUTO_INCREMENT=43827 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("term", Database:="go", SchemaSQL:="
CREATE TABLE `term` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL DEFAULT '',
  `term_type` varchar(55) NOT NULL,
  `acc` varchar(255) NOT NULL,
  `is_obsolete` int(11) NOT NULL DEFAULT '0',
  `is_root` int(11) NOT NULL DEFAULT '0',
  `is_relation` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `acc` (`acc`),
  UNIQUE KEY `t0` (`id`),
  KEY `t1` (`name`),
  KEY `t2` (`term_type`),
  KEY `t3` (`acc`),
  KEY `t4` (`id`,`acc`),
  KEY `t5` (`id`,`name`),
  KEY `t6` (`id`,`term_type`),
  KEY `t7` (`id`,`acc`,`name`,`term_type`)
) ENGINE=MyISAM AUTO_INCREMENT=43827 DEFAULT CHARSET=latin1;")>
Public Class term: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("name"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property name As String
    <DatabaseField("term_type"), NotNull, DataType(MySqlDbType.VarChar, "55")> Public Property term_type As String
    <DatabaseField("acc"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property acc As String
    <DatabaseField("is_obsolete"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property is_obsolete As Long
    <DatabaseField("is_root"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property is_root As Long
    <DatabaseField("is_relation"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property is_relation As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `term` (`name`, `term_type`, `acc`, `is_obsolete`, `is_root`, `is_relation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `term` (`name`, `term_type`, `acc`, `is_obsolete`, `is_root`, `is_relation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `term` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `term` SET `id`='{0}', `name`='{1}', `term_type`='{2}', `acc`='{3}', `is_obsolete`='{4}', `is_root`='{5}', `is_relation`='{6}' WHERE `id` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `term` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `term` (`name`, `term_type`, `acc`, `is_obsolete`, `is_root`, `is_relation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, name, term_type, acc, is_obsolete, is_root, is_relation)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{name}', '{term_type}', '{acc}', '{is_obsolete}', '{is_root}', '{is_relation}', '{6}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `term` (`name`, `term_type`, `acc`, `is_obsolete`, `is_root`, `is_relation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, name, term_type, acc, is_obsolete, is_root, is_relation)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `term` SET `id`='{0}', `name`='{1}', `term_type`='{2}', `acc`='{3}', `is_obsolete`='{4}', `is_root`='{5}', `is_relation`='{6}' WHERE `id` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, name, term_type, acc, is_obsolete, is_root, is_relation, id)
    End Function
#End Region
End Class


End Namespace
