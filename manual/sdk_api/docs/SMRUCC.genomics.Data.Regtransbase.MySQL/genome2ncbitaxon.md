﻿# genome2ncbitaxon
_namespace: [SMRUCC.genomics.Data.Regtransbase.MySQL](./index.md)_

--
 
 DROP TABLE IF EXISTS `genome2ncbitaxon`;
 /*!40101 SET @saved_cs_client = @@character_set_client */;
 /*!40101 SET character_set_client = utf8 */;
 CREATE TABLE `genome2ncbitaxon` (
 `genome_guid` int(10) unsigned NOT NULL DEFAULT '0',
 `ncbi_tax_id` int(10) unsigned NOT NULL DEFAULT '0',
 PRIMARY KEY (`genome_guid`)
 ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 /*!40101 SET character_set_client = @saved_cs_client */;
 
 --




