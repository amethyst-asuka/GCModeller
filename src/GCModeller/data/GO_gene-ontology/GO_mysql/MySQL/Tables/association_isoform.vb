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
''' DROP TABLE IF EXISTS `association_isoform`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `association_isoform` (
'''   `association_id` int(11) NOT NULL,
'''   `gene_product_id` int(11) NOT NULL,
'''   KEY `association_id` (`association_id`),
'''   KEY `gene_product_id` (`gene_product_id`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("association_isoform", Database:="go", SchemaSQL:="
CREATE TABLE `association_isoform` (
  `association_id` int(11) NOT NULL,
  `gene_product_id` int(11) NOT NULL,
  KEY `association_id` (`association_id`),
  KEY `gene_product_id` (`gene_product_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class association_isoform: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("association_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property association_id As Long
    <DatabaseField("gene_product_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property gene_product_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `association_isoform` (`association_id`, `gene_product_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `association_isoform` (`association_id`, `gene_product_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `association_isoform` WHERE `association_id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `association_isoform` SET `association_id`='{0}', `gene_product_id`='{1}' WHERE `association_id` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `association_isoform` WHERE `association_id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, association_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `association_isoform` (`association_id`, `gene_product_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, association_id, gene_product_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{association_id}', '{gene_product_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `association_isoform` (`association_id`, `gene_product_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, association_id, gene_product_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `association_isoform` SET `association_id`='{0}', `gene_product_id`='{1}' WHERE `association_id` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, association_id, gene_product_id, association_id)
    End Function
#End Region
End Class


End Namespace
