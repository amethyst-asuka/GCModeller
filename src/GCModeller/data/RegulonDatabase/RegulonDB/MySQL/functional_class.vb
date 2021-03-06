REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:24:24 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `functional_class`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `functional_class` (
'''   `functional_class_id` char(12) NOT NULL,
'''   `fc_description` varchar(500) NOT NULL,
'''   `fc_label_index` varchar(50) NOT NULL,
'''   `head_class` char(12) DEFAULT NULL,
'''   `color_class` varchar(20) DEFAULT NULL,
'''   `fc_reference` varchar(255) NOT NULL,
'''   `fc_note` varchar(2000) DEFAULT NULL,
'''   `fc_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("functional_class", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `functional_class` (
  `functional_class_id` char(12) NOT NULL,
  `fc_description` varchar(500) NOT NULL,
  `fc_label_index` varchar(50) NOT NULL,
  `head_class` char(12) DEFAULT NULL,
  `color_class` varchar(20) DEFAULT NULL,
  `fc_reference` varchar(255) NOT NULL,
  `fc_note` varchar(2000) DEFAULT NULL,
  `fc_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class functional_class: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("functional_class_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property functional_class_id As String
    <DatabaseField("fc_description"), NotNull, DataType(MySqlDbType.VarChar, "500")> Public Property fc_description As String
    <DatabaseField("fc_label_index"), NotNull, DataType(MySqlDbType.VarChar, "50")> Public Property fc_label_index As String
    <DatabaseField("head_class"), DataType(MySqlDbType.VarChar, "12")> Public Property head_class As String
    <DatabaseField("color_class"), DataType(MySqlDbType.VarChar, "20")> Public Property color_class As String
    <DatabaseField("fc_reference"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property fc_reference As String
    <DatabaseField("fc_note"), DataType(MySqlDbType.VarChar, "2000")> Public Property fc_note As String
    <DatabaseField("fc_internal_comment"), DataType(MySqlDbType.Text)> Public Property fc_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `functional_class` (`functional_class_id`, `fc_description`, `fc_label_index`, `head_class`, `color_class`, `fc_reference`, `fc_note`, `fc_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `functional_class` (`functional_class_id`, `fc_description`, `fc_label_index`, `head_class`, `color_class`, `fc_reference`, `fc_note`, `fc_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `functional_class` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `functional_class` SET `functional_class_id`='{0}', `fc_description`='{1}', `fc_label_index`='{2}', `head_class`='{3}', `color_class`='{4}', `fc_reference`='{5}', `fc_note`='{6}', `fc_internal_comment`='{7}', `key_id_org`='{8}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `functional_class` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `functional_class` (`functional_class_id`, `fc_description`, `fc_label_index`, `head_class`, `color_class`, `fc_reference`, `fc_note`, `fc_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, functional_class_id, fc_description, fc_label_index, head_class, color_class, fc_reference, fc_note, fc_internal_comment, key_id_org)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{functional_class_id}', '{fc_description}', '{fc_label_index}', '{head_class}', '{color_class}', '{fc_reference}', '{fc_note}', '{fc_internal_comment}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `functional_class` (`functional_class_id`, `fc_description`, `fc_label_index`, `head_class`, `color_class`, `fc_reference`, `fc_note`, `fc_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, functional_class_id, fc_description, fc_label_index, head_class, color_class, fc_reference, fc_note, fc_internal_comment, key_id_org)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `functional_class` SET `functional_class_id`='{0}', `fc_description`='{1}', `fc_label_index`='{2}', `head_class`='{3}', `color_class`='{4}', `fc_reference`='{5}', `fc_note`='{6}', `fc_internal_comment`='{7}', `key_id_org`='{8}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
