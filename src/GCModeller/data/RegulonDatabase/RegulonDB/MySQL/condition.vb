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
''' DROP TABLE IF EXISTS `condition`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `condition` (
'''   `condition_id` char(12) NOT NULL,
'''   `control_condition` varchar(2000) NOT NULL,
'''   `control_details` varchar(2000) DEFAULT NULL,
'''   `exp_condition` varchar(2000) NOT NULL,
'''   `exp_details` varchar(2000) DEFAULT NULL,
'''   `condition_global` varchar(2000) DEFAULT NULL,
'''   `condition_notes` varchar(2000) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("condition", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `condition` (
  `condition_id` char(12) NOT NULL,
  `control_condition` varchar(2000) NOT NULL,
  `control_details` varchar(2000) DEFAULT NULL,
  `exp_condition` varchar(2000) NOT NULL,
  `exp_details` varchar(2000) DEFAULT NULL,
  `condition_global` varchar(2000) DEFAULT NULL,
  `condition_notes` varchar(2000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class condition: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("condition_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property condition_id As String
    <DatabaseField("control_condition"), NotNull, DataType(MySqlDbType.VarChar, "2000")> Public Property control_condition As String
    <DatabaseField("control_details"), DataType(MySqlDbType.VarChar, "2000")> Public Property control_details As String
    <DatabaseField("exp_condition"), NotNull, DataType(MySqlDbType.VarChar, "2000")> Public Property exp_condition As String
    <DatabaseField("exp_details"), DataType(MySqlDbType.VarChar, "2000")> Public Property exp_details As String
    <DatabaseField("condition_global"), DataType(MySqlDbType.VarChar, "2000")> Public Property condition_global As String
    <DatabaseField("condition_notes"), DataType(MySqlDbType.VarChar, "2000")> Public Property condition_notes As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `condition` (`condition_id`, `control_condition`, `control_details`, `exp_condition`, `exp_details`, `condition_global`, `condition_notes`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `condition` (`condition_id`, `control_condition`, `control_details`, `exp_condition`, `exp_details`, `condition_global`, `condition_notes`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `condition` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `condition` SET `condition_id`='{0}', `control_condition`='{1}', `control_details`='{2}', `exp_condition`='{3}', `exp_details`='{4}', `condition_global`='{5}', `condition_notes`='{6}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `condition` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `condition` (`condition_id`, `control_condition`, `control_details`, `exp_condition`, `exp_details`, `condition_global`, `condition_notes`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, condition_id, control_condition, control_details, exp_condition, exp_details, condition_global, condition_notes)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{condition_id}', '{control_condition}', '{control_details}', '{exp_condition}', '{exp_details}', '{condition_global}', '{condition_notes}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `condition` (`condition_id`, `control_condition`, `control_details`, `exp_condition`, `exp_details`, `condition_global`, `condition_notes`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, condition_id, control_condition, control_details, exp_condition, exp_details, condition_global, condition_notes)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `condition` SET `condition_id`='{0}', `control_condition`='{1}', `control_details`='{2}', `exp_condition`='{3}', `exp_details`='{4}', `condition_global`='{5}', `condition_notes`='{6}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
