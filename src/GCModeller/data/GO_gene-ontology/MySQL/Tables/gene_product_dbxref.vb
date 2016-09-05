REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @9/5/2016 7:59:33 AM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `gene_product_dbxref`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `gene_product_dbxref` (
'''   `gene_product_id` int(11) NOT NULL,
'''   `dbxref_id` int(11) NOT NULL,
'''   UNIQUE KEY `gpx3` (`gene_product_id`,`dbxref_id`),
'''   KEY `gpx1` (`gene_product_id`),
'''   KEY `gpx2` (`dbxref_id`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("gene_product_dbxref", Database:="go", SchemaSQL:="
CREATE TABLE `gene_product_dbxref` (
  `gene_product_id` int(11) NOT NULL,
  `dbxref_id` int(11) NOT NULL,
  UNIQUE KEY `gpx3` (`gene_product_id`,`dbxref_id`),
  KEY `gpx1` (`gene_product_id`),
  KEY `gpx2` (`dbxref_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class gene_product_dbxref: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("gene_product_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property gene_product_id As Long
    <DatabaseField("dbxref_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property dbxref_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `gene_product_dbxref` (`gene_product_id`, `dbxref_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `gene_product_dbxref` (`gene_product_id`, `dbxref_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `gene_product_dbxref` WHERE `gene_product_id`='{0}' and `dbxref_id`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `gene_product_dbxref` SET `gene_product_id`='{0}', `dbxref_id`='{1}' WHERE `gene_product_id`='{2}' and `dbxref_id`='{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `gene_product_dbxref` WHERE `gene_product_id`='{0}' and `dbxref_id`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, gene_product_id, dbxref_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `gene_product_dbxref` (`gene_product_id`, `dbxref_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, gene_product_id, dbxref_id)
    End Function
''' <summary>
''' ```SQL
''' REPLACE INTO `gene_product_dbxref` (`gene_product_id`, `dbxref_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, gene_product_id, dbxref_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `gene_product_dbxref` SET `gene_product_id`='{0}', `dbxref_id`='{1}' WHERE `gene_product_id`='{2}' and `dbxref_id`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, gene_product_id, dbxref_id, gene_product_id, dbxref_id)
    End Function
#End Region
End Class


End Namespace
