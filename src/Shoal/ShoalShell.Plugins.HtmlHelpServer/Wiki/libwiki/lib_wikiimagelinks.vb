REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 

REM  Dump @12/3/2015 8:20:41 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Wiki.MySQL

''' <summary>
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `lib_wikiimagelinks`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `lib_wikiimagelinks` (
'''   `il_from` int(10) unsigned NOT NULL DEFAULT '0',
'''   `il_from_namespace` int(11) NOT NULL DEFAULT '0',
'''   `il_to` varbinary(255) NOT NULL DEFAULT '',
'''   UNIQUE KEY `il_from` (`il_from`,`il_to`),
'''   KEY `il_to` (`il_to`,`il_from`),
'''   KEY `il_backlinks_namespace` (`il_to`,`il_from_namespace`,`il_from`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=binary;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("lib_wikiimagelinks", Database:="wiki")>
Public Class lib_wikiimagelinks: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("il_from"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property il_from As Long
    <DatabaseField("il_from_namespace"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property il_from_namespace As Long
    <DatabaseField("il_to"), PrimaryKey, NotNull, DataType(MySqlDbType.Blob)> Public Property il_to As Byte()
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `lib_wikiimagelinks` (`il_from`, `il_from_namespace`, `il_to`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `lib_wikiimagelinks` (`il_from`, `il_from_namespace`, `il_to`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `lib_wikiimagelinks` WHERE `il_from`='{0}' and `il_to`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `lib_wikiimagelinks` SET `il_from`='{0}', `il_from_namespace`='{1}', `il_to`='{2}' WHERE `il_from`='{3}' and `il_to`='{4}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, il_from, il_to)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, il_from, il_from_namespace, il_to)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, il_from, il_from_namespace, il_to)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, il_from, il_from_namespace, il_to, il_from, il_to)
    End Function
#End Region
End Class


End Namespace
