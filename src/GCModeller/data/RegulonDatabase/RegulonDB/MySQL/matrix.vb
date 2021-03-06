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
''' DROP TABLE IF EXISTS `matrix`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `matrix` (
'''   `tf_matrix_id` char(12) NOT NULL,
'''   `num_col` decimal(10,0) NOT NULL,
'''   `freq_a` decimal(10,0) NOT NULL,
'''   `freq_c` decimal(10,0) NOT NULL,
'''   `freq_g` decimal(10,0) NOT NULL,
'''   `freq_t` decimal(10,0) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("matrix", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `matrix` (
  `tf_matrix_id` char(12) NOT NULL,
  `num_col` decimal(10,0) NOT NULL,
  `freq_a` decimal(10,0) NOT NULL,
  `freq_c` decimal(10,0) NOT NULL,
  `freq_g` decimal(10,0) NOT NULL,
  `freq_t` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class matrix: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("tf_matrix_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property tf_matrix_id As String
    <DatabaseField("num_col"), NotNull, DataType(MySqlDbType.Decimal)> Public Property num_col As Decimal
    <DatabaseField("freq_a"), NotNull, DataType(MySqlDbType.Decimal)> Public Property freq_a As Decimal
    <DatabaseField("freq_c"), NotNull, DataType(MySqlDbType.Decimal)> Public Property freq_c As Decimal
    <DatabaseField("freq_g"), NotNull, DataType(MySqlDbType.Decimal)> Public Property freq_g As Decimal
    <DatabaseField("freq_t"), NotNull, DataType(MySqlDbType.Decimal)> Public Property freq_t As Decimal
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `matrix` (`tf_matrix_id`, `num_col`, `freq_a`, `freq_c`, `freq_g`, `freq_t`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `matrix` (`tf_matrix_id`, `num_col`, `freq_a`, `freq_c`, `freq_g`, `freq_t`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `matrix` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `matrix` SET `tf_matrix_id`='{0}', `num_col`='{1}', `freq_a`='{2}', `freq_c`='{3}', `freq_g`='{4}', `freq_t`='{5}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `matrix` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `matrix` (`tf_matrix_id`, `num_col`, `freq_a`, `freq_c`, `freq_g`, `freq_t`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, tf_matrix_id, num_col, freq_a, freq_c, freq_g, freq_t)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{tf_matrix_id}', '{num_col}', '{freq_a}', '{freq_c}', '{freq_g}', '{freq_t}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `matrix` (`tf_matrix_id`, `num_col`, `freq_a`, `freq_c`, `freq_g`, `freq_t`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, tf_matrix_id, num_col, freq_a, freq_c, freq_g, freq_t)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `matrix` SET `tf_matrix_id`='{0}', `num_col`='{1}', `freq_a`='{2}', `freq_c`='{3}', `freq_g`='{4}', `freq_t`='{5}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
