﻿# mv_entry2protein
_namespace: [SMRUCC.genomics.Analysis.Annotations.Interpro.Tables](./index.md)_

--
 
 DROP TABLE IF EXISTS `mv_entry2protein`;
 /*!40101 SET @saved_cs_client = @@character_set_client */;
 /*!40101 SET character_set_client = utf8 */;
 CREATE TABLE `mv_entry2protein` (
 `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
 `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
 `match_count` int(7) NOT NULL,
 PRIMARY KEY (`entry_ac`,`protein_ac`),
 KEY `fk_mv_entry2protein$protein` (`protein_ac`),
 CONSTRAINT `fk_mv_entry2protein$entry` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
 CONSTRAINT `fk_mv_entry2protein$protein` FOREIGN KEY (`protein_ac`) REFERENCES `protein` (`protein_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
 ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 /*!40101 SET character_set_client = @saved_cs_client */;
 
 --



