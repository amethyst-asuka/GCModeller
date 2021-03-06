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
''' DROP TABLE IF EXISTS `product`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `product` (
'''   `product_id` char(12) NOT NULL,
'''   `product_name` varchar(255) DEFAULT NULL,
'''   `molecular_weigth` decimal(20,5) DEFAULT NULL,
'''   `isoelectric_point` decimal(20,10) DEFAULT NULL,
'''   `location` varchar(1000) DEFAULT NULL,
'''   `anticodon` varchar(10) DEFAULT NULL,
'''   `product_sequence` varchar(4000) DEFAULT NULL,
'''   `product_note` longtext,
'''   `product_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL,
'''   `product_type` varchar(25) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("product", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `product` (
  `product_id` char(12) NOT NULL,
  `product_name` varchar(255) DEFAULT NULL,
  `molecular_weigth` decimal(20,5) DEFAULT NULL,
  `isoelectric_point` decimal(20,10) DEFAULT NULL,
  `location` varchar(1000) DEFAULT NULL,
  `anticodon` varchar(10) DEFAULT NULL,
  `product_sequence` varchar(4000) DEFAULT NULL,
  `product_note` longtext,
  `product_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL,
  `product_type` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class product: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("product_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property product_id As String
    <DatabaseField("product_name"), DataType(MySqlDbType.VarChar, "255")> Public Property product_name As String
    <DatabaseField("molecular_weigth"), DataType(MySqlDbType.Decimal)> Public Property molecular_weigth As Decimal
    <DatabaseField("isoelectric_point"), DataType(MySqlDbType.Decimal)> Public Property isoelectric_point As Decimal
    <DatabaseField("location"), DataType(MySqlDbType.VarChar, "1000")> Public Property location As String
    <DatabaseField("anticodon"), DataType(MySqlDbType.VarChar, "10")> Public Property anticodon As String
    <DatabaseField("product_sequence"), DataType(MySqlDbType.VarChar, "4000")> Public Property product_sequence As String
    <DatabaseField("product_note"), DataType(MySqlDbType.Text)> Public Property product_note As String
    <DatabaseField("product_internal_comment"), DataType(MySqlDbType.Text)> Public Property product_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property key_id_org As String
    <DatabaseField("product_type"), DataType(MySqlDbType.VarChar, "25")> Public Property product_type As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `product` (`product_id`, `product_name`, `molecular_weigth`, `isoelectric_point`, `location`, `anticodon`, `product_sequence`, `product_note`, `product_internal_comment`, `key_id_org`, `product_type`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `product` (`product_id`, `product_name`, `molecular_weigth`, `isoelectric_point`, `location`, `anticodon`, `product_sequence`, `product_note`, `product_internal_comment`, `key_id_org`, `product_type`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `product` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `product` SET `product_id`='{0}', `product_name`='{1}', `molecular_weigth`='{2}', `isoelectric_point`='{3}', `location`='{4}', `anticodon`='{5}', `product_sequence`='{6}', `product_note`='{7}', `product_internal_comment`='{8}', `key_id_org`='{9}', `product_type`='{10}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `product` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `product` (`product_id`, `product_name`, `molecular_weigth`, `isoelectric_point`, `location`, `anticodon`, `product_sequence`, `product_note`, `product_internal_comment`, `key_id_org`, `product_type`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, product_id, product_name, molecular_weigth, isoelectric_point, location, anticodon, product_sequence, product_note, product_internal_comment, key_id_org, product_type)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{product_id}', '{product_name}', '{molecular_weigth}', '{isoelectric_point}', '{location}', '{anticodon}', '{product_sequence}', '{product_note}', '{product_internal_comment}', '{key_id_org}', '{product_type}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `product` (`product_id`, `product_name`, `molecular_weigth`, `isoelectric_point`, `location`, `anticodon`, `product_sequence`, `product_note`, `product_internal_comment`, `key_id_org`, `product_type`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, product_id, product_name, molecular_weigth, isoelectric_point, location, anticodon, product_sequence, product_note, product_internal_comment, key_id_org, product_type)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `product` SET `product_id`='{0}', `product_name`='{1}', `molecular_weigth`='{2}', `isoelectric_point`='{3}', `location`='{4}', `anticodon`='{5}', `product_sequence`='{6}', `product_note`='{7}', `product_internal_comment`='{8}', `key_id_org`='{9}', `product_type`='{10}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
