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
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `feature_types`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `feature_types` (
'''   `uid` int(10) unsigned NOT NULL,
'''   `type_name` varchar(45) NOT NULL,
'''   PRIMARY KEY (`uid`),
'''   UNIQUE KEY `uid_UNIQUE` (`uid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("feature_types", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `feature_types` (
  `uid` int(10) unsigned NOT NULL,
  `type_name` varchar(45) NOT NULL,
  PRIMARY KEY (`uid`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class feature_types: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("uid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="uid"), XmlAttribute> Public Property uid As Long
    <DatabaseField("type_name"), NotNull, DataType(MySqlDbType.VarChar, "45"), Column(Name:="type_name")> Public Property type_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `feature_types` (`uid`, `type_name`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `feature_types` (`uid`, `type_name`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `feature_types` WHERE `uid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `feature_types` SET `uid`='{0}', `type_name`='{1}' WHERE `uid` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `feature_types` WHERE `uid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, uid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `feature_types` (`uid`, `type_name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, uid, type_name)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{uid}', '{type_name}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `feature_types` (`uid`, `type_name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, uid, type_name)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `feature_types` SET `uid`='{0}', `type_name`='{1}' WHERE `uid` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, uid, type_name, uid)
    End Function
#End Region
Public Function Clone() As feature_types
                  Return DirectCast(MyClass.MemberwiseClone, feature_types)
              End Function
End Class


End Namespace
