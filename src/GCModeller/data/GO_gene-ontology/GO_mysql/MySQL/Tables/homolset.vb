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
''' DROP TABLE IF EXISTS `homolset`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `homolset` (
'''   `id` int(11) NOT NULL AUTO_INCREMENT,
'''   `symbol` varchar(128) DEFAULT NULL,
'''   `dbxref_id` int(11) DEFAULT NULL,
'''   `target_gene_product_id` int(11) DEFAULT NULL,
'''   `taxon_id` int(11) DEFAULT NULL,
'''   `type_id` int(11) DEFAULT NULL,
'''   `description` text,
'''   PRIMARY KEY (`id`),
'''   UNIQUE KEY `dbxref_id` (`dbxref_id`),
'''   KEY `target_gene_product_id` (`target_gene_product_id`),
'''   KEY `taxon_id` (`taxon_id`),
'''   KEY `type_id` (`type_id`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("homolset", Database:="go", SchemaSQL:="
CREATE TABLE `homolset` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `symbol` varchar(128) DEFAULT NULL,
  `dbxref_id` int(11) DEFAULT NULL,
  `target_gene_product_id` int(11) DEFAULT NULL,
  `taxon_id` int(11) DEFAULT NULL,
  `type_id` int(11) DEFAULT NULL,
  `description` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `dbxref_id` (`dbxref_id`),
  KEY `target_gene_product_id` (`target_gene_product_id`),
  KEY `taxon_id` (`taxon_id`),
  KEY `type_id` (`type_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class homolset: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("symbol"), DataType(MySqlDbType.VarChar, "128")> Public Property symbol As String
    <DatabaseField("dbxref_id"), DataType(MySqlDbType.Int64, "11")> Public Property dbxref_id As Long
    <DatabaseField("target_gene_product_id"), DataType(MySqlDbType.Int64, "11")> Public Property target_gene_product_id As Long
    <DatabaseField("taxon_id"), DataType(MySqlDbType.Int64, "11")> Public Property taxon_id As Long
    <DatabaseField("type_id"), DataType(MySqlDbType.Int64, "11")> Public Property type_id As Long
    <DatabaseField("description"), DataType(MySqlDbType.Text)> Public Property description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `homolset` (`symbol`, `dbxref_id`, `target_gene_product_id`, `taxon_id`, `type_id`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `homolset` (`symbol`, `dbxref_id`, `target_gene_product_id`, `taxon_id`, `type_id`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `homolset` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `homolset` SET `id`='{0}', `symbol`='{1}', `dbxref_id`='{2}', `target_gene_product_id`='{3}', `taxon_id`='{4}', `type_id`='{5}', `description`='{6}' WHERE `id` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `homolset` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `homolset` (`symbol`, `dbxref_id`, `target_gene_product_id`, `taxon_id`, `type_id`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, symbol, dbxref_id, target_gene_product_id, taxon_id, type_id, description)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{symbol}', '{dbxref_id}', '{target_gene_product_id}', '{taxon_id}', '{type_id}', '{description}', '{6}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `homolset` (`symbol`, `dbxref_id`, `target_gene_product_id`, `taxon_id`, `type_id`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, symbol, dbxref_id, target_gene_product_id, taxon_id, type_id, description)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `homolset` SET `id`='{0}', `symbol`='{1}', `dbxref_id`='{2}', `target_gene_product_id`='{3}', `taxon_id`='{4}', `type_id`='{5}', `description`='{6}' WHERE `id` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, symbol, dbxref_id, target_gene_product_id, taxon_id, type_id, description, id)
    End Function
#End Region
End Class


End Namespace
