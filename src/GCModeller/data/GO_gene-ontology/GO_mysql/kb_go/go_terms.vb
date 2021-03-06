REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2017/9/3 12:29:34


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports System.Xml.Serialization

Namespace kb_go

''' <summary>
''' ```SQL
''' GO_term的具体的定义内容
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `go_terms`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `go_terms` (
'''   `id` int(10) unsigned NOT NULL COMMENT '其实就是将term编号之中的``GO:``前缀给删除了而得到的一个数字',
'''   `term` char(16) NOT NULL COMMENT 'GO id',
'''   `name` varchar(45) DEFAULT NULL,
'''   `namespace_id` int(10) unsigned NOT NULL,
'''   `namespace` varchar(45) NOT NULL,
'''   `def` longtext NOT NULL,
'''   `is_obsolete` tinyint(4) NOT NULL DEFAULT '0' COMMENT '0 为 False, 1 为 True',
'''   `comment` longtext,
'''   PRIMARY KEY (`id`),
'''   UNIQUE KEY `id_UNIQUE` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='GO_term的具体的定义内容';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("go_terms", Database:="kb_go", SchemaSQL:="
CREATE TABLE `go_terms` (
  `id` int(10) unsigned NOT NULL COMMENT '其实就是将term编号之中的``GO:``前缀给删除了而得到的一个数字',
  `term` char(16) NOT NULL COMMENT 'GO id',
  `name` varchar(45) DEFAULT NULL,
  `namespace_id` int(10) unsigned NOT NULL,
  `namespace` varchar(45) NOT NULL,
  `def` longtext NOT NULL,
  `is_obsolete` tinyint(4) NOT NULL DEFAULT '0' COMMENT '0 为 False, 1 为 True',
  `comment` longtext,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='GO_term的具体的定义内容';")>
Public Class go_terms: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
''' <summary>
''' 其实就是将term编号之中的``GO:``前缀给删除了而得到的一个数字
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="id"), XmlAttribute> Public Property id As Long
''' <summary>
''' GO id
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("term"), NotNull, DataType(MySqlDbType.VarChar, "16"), Column(Name:="term")> Public Property term As String
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="name")> Public Property name As String
    <DatabaseField("namespace_id"), NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="namespace_id")> Public Property namespace_id As Long
    <DatabaseField("namespace"), NotNull, DataType(MySqlDbType.VarChar, "45"), Column(Name:="namespace")> Public Property [namespace] As String
    <DatabaseField("def"), NotNull, DataType(MySqlDbType.Text), Column(Name:="def")> Public Property def As String
''' <summary>
''' 0 为 False, 1 为 True
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("is_obsolete"), NotNull, DataType(MySqlDbType.Int64, "4"), Column(Name:="is_obsolete")> Public Property is_obsolete As Long
    <DatabaseField("comment"), DataType(MySqlDbType.Text), Column(Name:="comment")> Public Property comment As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `go_terms` (`id`, `term`, `name`, `namespace_id`, `namespace`, `def`, `is_obsolete`, `comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `go_terms` (`id`, `term`, `name`, `namespace_id`, `namespace`, `def`, `is_obsolete`, `comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `go_terms` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `go_terms` SET `id`='{0}', `term`='{1}', `name`='{2}', `namespace_id`='{3}', `namespace`='{4}', `def`='{5}', `is_obsolete`='{6}', `comment`='{7}' WHERE `id` = '{8}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `go_terms` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `go_terms` (`id`, `term`, `name`, `namespace_id`, `namespace`, `def`, `is_obsolete`, `comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, term, name, namespace_id, [namespace], def, is_obsolete, comment)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{term}', '{name}', '{namespace_id}', '{[namespace]}', '{def}', '{is_obsolete}', '{comment}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `go_terms` (`id`, `term`, `name`, `namespace_id`, `namespace`, `def`, `is_obsolete`, `comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, term, name, namespace_id, [namespace], def, is_obsolete, comment)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `go_terms` SET `id`='{0}', `term`='{1}', `name`='{2}', `namespace_id`='{3}', `namespace`='{4}', `def`='{5}', `is_obsolete`='{6}', `comment`='{7}' WHERE `id` = '{8}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, term, name, namespace_id, [namespace], def, is_obsolete, comment, id)
    End Function
#End Region
Public Function Clone() As go_terms
                  Return DirectCast(MyClass.MemberwiseClone, go_terms)
              End Function
End Class


End Namespace
