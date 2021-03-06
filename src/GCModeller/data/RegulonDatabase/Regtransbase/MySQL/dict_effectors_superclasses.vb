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
''' DROP TABLE IF EXISTS `dict_effectors_superclasses`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dict_effectors_superclasses` (
'''   `effector_superclass_guid` int(11) NOT NULL DEFAULT '0',
'''   `name` varchar(100) NOT NULL DEFAULT '',
'''   `parent_guid` int(11) DEFAULT NULL,
'''   `idx` int(11) NOT NULL DEFAULT '0',
'''   `left_idx` int(11) NOT NULL DEFAULT '0',
'''   `right_idx` int(11) NOT NULL DEFAULT '0',
'''   PRIMARY KEY (`effector_superclass_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dict_effectors_superclasses", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `dict_effectors_superclasses` (
  `effector_superclass_guid` int(11) NOT NULL DEFAULT '0',
  `name` varchar(100) NOT NULL DEFAULT '',
  `parent_guid` int(11) DEFAULT NULL,
  `idx` int(11) NOT NULL DEFAULT '0',
  `left_idx` int(11) NOT NULL DEFAULT '0',
  `right_idx` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`effector_superclass_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class dict_effectors_superclasses: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("effector_superclass_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property effector_superclass_guid As Long
    <DatabaseField("name"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property name As String
    <DatabaseField("parent_guid"), DataType(MySqlDbType.Int64, "11")> Public Property parent_guid As Long
    <DatabaseField("idx"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property idx As Long
    <DatabaseField("left_idx"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property left_idx As Long
    <DatabaseField("right_idx"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property right_idx As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `dict_effectors_superclasses` (`effector_superclass_guid`, `name`, `parent_guid`, `idx`, `left_idx`, `right_idx`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `dict_effectors_superclasses` (`effector_superclass_guid`, `name`, `parent_guid`, `idx`, `left_idx`, `right_idx`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `dict_effectors_superclasses` WHERE `effector_superclass_guid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `dict_effectors_superclasses` SET `effector_superclass_guid`='{0}', `name`='{1}', `parent_guid`='{2}', `idx`='{3}', `left_idx`='{4}', `right_idx`='{5}' WHERE `effector_superclass_guid` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `dict_effectors_superclasses` WHERE `effector_superclass_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, effector_superclass_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `dict_effectors_superclasses` (`effector_superclass_guid`, `name`, `parent_guid`, `idx`, `left_idx`, `right_idx`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, effector_superclass_guid, name, parent_guid, idx, left_idx, right_idx)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{effector_superclass_guid}', '{name}', '{parent_guid}', '{idx}', '{left_idx}', '{right_idx}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dict_effectors_superclasses` (`effector_superclass_guid`, `name`, `parent_guid`, `idx`, `left_idx`, `right_idx`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, effector_superclass_guid, name, parent_guid, idx, left_idx, right_idx)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `dict_effectors_superclasses` SET `effector_superclass_guid`='{0}', `name`='{1}', `parent_guid`='{2}', `idx`='{3}', `left_idx`='{4}', `right_idx`='{5}' WHERE `effector_superclass_guid` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, effector_superclass_guid, name, parent_guid, idx, left_idx, right_idx, effector_superclass_guid)
    End Function
#End Region
End Class


End Namespace
