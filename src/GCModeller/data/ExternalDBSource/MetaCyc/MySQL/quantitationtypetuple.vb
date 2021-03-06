REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:56 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `quantitationtypetuple`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `quantitationtypetuple` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `DesignElementTuple` bigint(20) DEFAULT NULL,
'''   `QuantitationType` bigint(20) DEFAULT NULL,
'''   `QuantitationTypeTuple_Datum` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_QuantitationTypeTuple1` (`DataSetWID`),
'''   KEY `FK_QuantitationTypeTuple2` (`DesignElementTuple`),
'''   KEY `FK_QuantitationTypeTuple3` (`QuantitationType`),
'''   KEY `FK_QuantitationTypeTuple4` (`QuantitationTypeTuple_Datum`),
'''   CONSTRAINT `FK_QuantitationTypeTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantitationTypeTuple2` FOREIGN KEY (`DesignElementTuple`) REFERENCES `designelementtuple` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantitationTypeTuple3` FOREIGN KEY (`QuantitationType`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantitationTypeTuple4` FOREIGN KEY (`QuantitationTypeTuple_Datum`) REFERENCES `datum` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("quantitationtypetuple", Database:="warehouse", SchemaSQL:="
CREATE TABLE `quantitationtypetuple` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `DesignElementTuple` bigint(20) DEFAULT NULL,
  `QuantitationType` bigint(20) DEFAULT NULL,
  `QuantitationTypeTuple_Datum` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_QuantitationTypeTuple1` (`DataSetWID`),
  KEY `FK_QuantitationTypeTuple2` (`DesignElementTuple`),
  KEY `FK_QuantitationTypeTuple3` (`QuantitationType`),
  KEY `FK_QuantitationTypeTuple4` (`QuantitationTypeTuple_Datum`),
  CONSTRAINT `FK_QuantitationTypeTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_QuantitationTypeTuple2` FOREIGN KEY (`DesignElementTuple`) REFERENCES `designelementtuple` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_QuantitationTypeTuple3` FOREIGN KEY (`QuantitationType`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_QuantitationTypeTuple4` FOREIGN KEY (`QuantitationTypeTuple_Datum`) REFERENCES `datum` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class quantitationtypetuple: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("DesignElementTuple"), DataType(MySqlDbType.Int64, "20")> Public Property DesignElementTuple As Long
    <DatabaseField("QuantitationType"), DataType(MySqlDbType.Int64, "20")> Public Property QuantitationType As Long
    <DatabaseField("QuantitationTypeTuple_Datum"), DataType(MySqlDbType.Int64, "20")> Public Property QuantitationTypeTuple_Datum As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `quantitationtypetuple` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `quantitationtypetuple` SET `WID`='{0}', `DataSetWID`='{1}', `DesignElementTuple`='{2}', `QuantitationType`='{3}', `QuantitationTypeTuple_Datum`='{4}' WHERE `WID` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `quantitationtypetuple` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, DesignElementTuple, QuantitationType, QuantitationTypeTuple_Datum)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{DesignElementTuple}', '{QuantitationType}', '{QuantitationTypeTuple_Datum}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, DesignElementTuple, QuantitationType, QuantitationTypeTuple_Datum)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `quantitationtypetuple` SET `WID`='{0}', `DataSetWID`='{1}', `DesignElementTuple`='{2}', `QuantitationType`='{3}', `QuantitationTypeTuple_Datum`='{4}' WHERE `WID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, DesignElementTuple, QuantitationType, QuantitationTypeTuple_Datum, WID)
    End Function
#End Region
End Class


End Namespace
