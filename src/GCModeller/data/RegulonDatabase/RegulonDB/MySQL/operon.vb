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
''' DROP TABLE IF EXISTS `operon`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `operon` (
'''   `operon_id` char(12) NOT NULL,
'''   `operon_name` varchar(255) NOT NULL,
'''   `firstgeneposleft` decimal(10,0) NOT NULL,
'''   `lastgeneposright` decimal(10,0) NOT NULL,
'''   `regulationposleft` decimal(10,0) NOT NULL,
'''   `regulationposright` decimal(10,0) NOT NULL,
'''   `operon_strand` varchar(10) DEFAULT NULL,
'''   `operon_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("operon", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `operon` (
  `operon_id` char(12) NOT NULL,
  `operon_name` varchar(255) NOT NULL,
  `firstgeneposleft` decimal(10,0) NOT NULL,
  `lastgeneposright` decimal(10,0) NOT NULL,
  `regulationposleft` decimal(10,0) NOT NULL,
  `regulationposright` decimal(10,0) NOT NULL,
  `operon_strand` varchar(10) DEFAULT NULL,
  `operon_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class operon: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("operon_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property operon_id As String
    <DatabaseField("operon_name"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property operon_name As String
    <DatabaseField("firstgeneposleft"), NotNull, DataType(MySqlDbType.Decimal)> Public Property firstgeneposleft As Decimal
    <DatabaseField("lastgeneposright"), NotNull, DataType(MySqlDbType.Decimal)> Public Property lastgeneposright As Decimal
    <DatabaseField("regulationposleft"), NotNull, DataType(MySqlDbType.Decimal)> Public Property regulationposleft As Decimal
    <DatabaseField("regulationposright"), NotNull, DataType(MySqlDbType.Decimal)> Public Property regulationposright As Decimal
    <DatabaseField("operon_strand"), DataType(MySqlDbType.VarChar, "10")> Public Property operon_strand As String
    <DatabaseField("operon_internal_comment"), DataType(MySqlDbType.Text)> Public Property operon_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `operon` (`operon_id`, `operon_name`, `firstgeneposleft`, `lastgeneposright`, `regulationposleft`, `regulationposright`, `operon_strand`, `operon_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `operon` (`operon_id`, `operon_name`, `firstgeneposleft`, `lastgeneposright`, `regulationposleft`, `regulationposright`, `operon_strand`, `operon_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `operon` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `operon` SET `operon_id`='{0}', `operon_name`='{1}', `firstgeneposleft`='{2}', `lastgeneposright`='{3}', `regulationposleft`='{4}', `regulationposright`='{5}', `operon_strand`='{6}', `operon_internal_comment`='{7}', `key_id_org`='{8}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `operon` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `operon` (`operon_id`, `operon_name`, `firstgeneposleft`, `lastgeneposright`, `regulationposleft`, `regulationposright`, `operon_strand`, `operon_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, operon_id, operon_name, firstgeneposleft, lastgeneposright, regulationposleft, regulationposright, operon_strand, operon_internal_comment, key_id_org)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{operon_id}', '{operon_name}', '{firstgeneposleft}', '{lastgeneposright}', '{regulationposleft}', '{regulationposright}', '{operon_strand}', '{operon_internal_comment}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `operon` (`operon_id`, `operon_name`, `firstgeneposleft`, `lastgeneposright`, `regulationposleft`, `regulationposright`, `operon_strand`, `operon_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, operon_id, operon_name, firstgeneposleft, lastgeneposright, regulationposleft, regulationposright, operon_strand, operon_internal_comment, key_id_org)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `operon` SET `operon_id`='{0}', `operon_name`='{1}', `firstgeneposleft`='{2}', `lastgeneposright`='{3}', `regulationposleft`='{4}', `regulationposright`='{5}', `operon_strand`='{6}', `operon_internal_comment`='{7}', `key_id_org`='{8}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
