-- MySQL Script generated by MySQL Workbench
-- Sun Sep  3 05:59:56 2017
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema kb_go
-- -----------------------------------------------------
-- gene ontology database
DROP SCHEMA IF EXISTS `kb_go` ;

-- -----------------------------------------------------
-- Schema kb_go
--
-- gene ontology database
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `kb_go` DEFAULT CHARACTER SET utf8 ;
SHOW WARNINGS;
-- -----------------------------------------------------
-- Schema kb_UniProtKB
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `kb_UniProtKB` ;

-- -----------------------------------------------------
-- Schema kb_UniProtKB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `kb_UniProtKB` DEFAULT CHARACTER SET utf8 ;
SHOW WARNINGS;
USE `kb_go` ;

-- -----------------------------------------------------
-- Table `kb_go`.`term_namespace`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_go`.`term_namespace` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_go`.`term_namespace` (
  `id` INT ZEROFILL UNSIGNED NOT NULL,
  `namespace` TINYTEXT NOT NULL COMMENT '这个表里面只有三个值',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB
COMMENT = '枚举三个命名空间';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_go`.`go_terms`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_go`.`go_terms` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_go`.`go_terms` (
  `id` INT UNSIGNED NOT NULL COMMENT '其实就是将term编号之中的``GO:``前缀给删除了而得到的一个数字',
  `term` CHAR(16) NOT NULL COMMENT 'GO id',
  `name` VARCHAR(45) NULL,
  `namespace_id` INT UNSIGNED NOT NULL,
  `namespace` VARCHAR(45) NOT NULL,
  `def` LONGTEXT NOT NULL,
  `is_obsolete` TINYINT NOT NULL DEFAULT 0 COMMENT '0 为 False, 1 为 True',
  `comment` LONGTEXT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB
COMMENT = 'GO_term的具体的定义内容';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_go`.`relation_names`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_go`.`relation_names` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_go`.`relation_names` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` MEDIUMTEXT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB
COMMENT = '枚举所有的关系的名称';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_go`.`dag_relationship`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_go`.`dag_relationship` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_go`.`dag_relationship` (
  `id` INT UNSIGNED NOT NULL COMMENT '当前的term编号',
  `relationship` VARCHAR(45) NULL,
  `relationship_id` INT UNSIGNED NOT NULL COMMENT '二者之间的关系编号，由于可能会存在多种互做类型，所以只使用id+term_id的结构来做主键会出现重复entry的问题，在这里将作用的类型也加入进来',
  `term_id` INT UNSIGNED NOT NULL COMMENT '与当前的term发生互做关系的另外的一个partner term的编号',
  `name` VARCHAR(45) NULL COMMENT '发生关系的term的名字',
  PRIMARY KEY (`id`, `term_id`, `relationship_id`))
ENGINE = InnoDB
COMMENT = '由GO_term之间的相互关系所构成的有向无环图Directed Acyclic Graph（DAG）';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_go`.`xref`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_go`.`xref` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_go`.`xref` (
  `go_id` INT UNSIGNED NOT NULL,
  `xref` VARCHAR(45) NOT NULL COMMENT '外部数据库名称',
  `external_id` VARCHAR(45) NOT NULL COMMENT '外部数据库编号',
  `comment` LONGTEXT NULL,
  PRIMARY KEY (`go_id`, `external_id`))
ENGINE = InnoDB
COMMENT = 'GO_term与外部数据库之间的相互关联';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_go`.`term_synonym`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_go`.`term_synonym` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_go`.`term_synonym` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '自增编号',
  `term_id` INT UNSIGNED NOT NULL COMMENT '当前的Go term的编号',
  `synonym` MEDIUMTEXT NOT NULL COMMENT '同义名称',
  `type` VARCHAR(45) NULL COMMENT 'EXACT []  表示完全一样\nRELATED [EC:3.1.27.3] 表示和xxxx有关联，其中EC编号为本表之中的object字段 ',
  `object` VARCHAR(45) NULL COMMENT 'type所指向的类型，可以会为空',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB
COMMENT = 'GO_term的同义词表';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_go`.`alt_id`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_go`.`alt_id` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_go`.`alt_id` (
  `id` INT UNSIGNED NOT NULL,
  `alt_id` INT UNSIGNED NOT NULL,
  `name` MEDIUMTEXT NULL COMMENT 'The name field in the go_term',
  PRIMARY KEY (`id`, `alt_id`))
ENGINE = InnoDB
COMMENT = 'GO_term的主编号和次级编号之间的关系';

SHOW WARNINGS;
USE `kb_UniProtKB` ;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`organism_code`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`organism_code` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`organism_code` (
  `uid` INT UNSIGNED NOT NULL COMMENT '在这里使用的是NCBI Taxonomy编号',
  `organism_name` VARCHAR(100) NOT NULL,
  `domain` VARCHAR(45) NULL,
  `kingdom` VARCHAR(45) NULL,
  `phylum` VARCHAR(45) NULL,
  `class` VARCHAR(45) NULL,
  `order` VARCHAR(45) NULL,
  `family` VARCHAR(45) NULL,
  `genus` VARCHAR(45) NULL,
  `species` VARCHAR(45) NULL,
  `full` MEDIUMTEXT NOT NULL COMMENT '除了前面的标准的分类层次之外，在这里还有包含有非标准的分类层次的信息，使用json字符串存放这些物种分类信息',
  UNIQUE INDEX `organism_name_UNIQUE` (`organism_name` ASC),
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB
COMMENT = '物种信息简表';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`hash_table`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`hash_table` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`hash_table` (
  `uniprot_id` CHAR(32) NOT NULL COMMENT 'uniprot数据库编号首先会在这个表之中进行查找，得到自己唯一的哈希值结果，然后再根据这个哈希值去快速的查找其他的表之中的结果',
  `hash_code` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '每一个字符串形式的uniprot数据库编号都有一个唯一的哈希值编号',
  `name` VARCHAR(45) NULL,
  PRIMARY KEY (`uniprot_id`),
  UNIQUE INDEX `uniprot_id_UNIQUE` (`uniprot_id` ASC),
  UNIQUE INDEX `hash_code_UNIQUE` (`hash_code` ASC))
ENGINE = InnoDB
COMMENT = '这个表主要是为了加快整个数据库的查询效率而建立的冗余表，在这里为每一个uniport accession编号都赋值了一个唯一编号，然后利用这个唯一编号就可以实现对其他数据表之中的数据的快速查询了';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`seq_archive`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`seq_archive` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`seq_archive` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NOT NULL COMMENT 'UniqueIdentifier Is the primary accession number of the UniProtKB entry.(对hash_code起校验用)',
  `entry_name` VARCHAR(45) NULL DEFAULT NULL COMMENT 'EntryName Is the entry name of the UniProtKB entry.',
  `organism_id` INT UNSIGNED NOT NULL COMMENT 'OrganismName Is the scientific name of the organism of the UniProtKB entry, this is the id reference to the organism_code table.',
  `organism_name` LONGTEXT NOT NULL COMMENT '对organism_id校验所使用的',
  `gn` VARCHAR(45) NULL DEFAULT NULL COMMENT 'GeneName Is the first gene name of the UniProtKB entry. If there Is no gene name, OrderedLocusName Or ORFname, the GN field Is Not listed.',
  `pe` VARCHAR(45) NULL DEFAULT NULL COMMENT 'ProteinExistence Is the numerical value describing the evidence for the existence of the protein.',
  `sv` VARCHAR(45) NULL DEFAULT NULL COMMENT 'SequenceVersion Is the version number of the sequence.',
  `prot_name` TINYTEXT NULL DEFAULT NULL COMMENT 'ProteinName Is the recommended name of the UniProtKB entry as annotated in the RecName field. For UniProtKB/TrEMBL entries without a RecName field, the SubName field Is used. In case of multiple SubNames, the first one Is used. The \'precursor\' attribute is excluded, \'Fragment\' is included with the name if applicable.',
  `length` INT(11) NULL DEFAULT NULL COMMENT 'length of the protein sequence',
  `sequence` TEXT NULL DEFAULT NULL COMMENT 'protein sequence',
  PRIMARY KEY (`hash_code`, `uniprot_id`),
  UNIQUE INDEX `uniprot_id_UNIQUE` (`uniprot_id` ASC),
  UNIQUE INDEX `hash_code_UNIQUE` (`hash_code` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = '蛋白质序列存储表';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`protein_GO`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`protein_GO` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`protein_GO` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NOT NULL,
  `go_id` INT UNSIGNED NOT NULL,
  `GO_term` VARCHAR(45) NOT NULL,
  `term_name` TINYTEXT NULL,
  `namespace_id` INT UNSIGNED NOT NULL,
  `namespace` CHAR(32) NULL,
  PRIMARY KEY (`hash_code`, `go_id`))
ENGINE = InnoDB
COMMENT = '对蛋白质的GO功能注释的信息关联表';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`organism_proteome`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`organism_proteome` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`organism_proteome` (
  `org_id` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `id_hashcode` INT UNSIGNED NOT NULL,
  `gene_name` VARCHAR(45) NULL,
  PRIMARY KEY (`org_id`, `id_hashcode`))
ENGINE = InnoDB
COMMENT = '这个表之中列举出了某一个物种其基因组之中所拥有的蛋白质的集合';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`protein_KO`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`protein_KO` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`protein_KO` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `KO` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`hash_code`, `KO`))
ENGINE = InnoDB
COMMENT = '蛋白质的KEGG直系同源的注释信息表，uniprotKB库通过这个表连接kegg知识库';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`literature`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`literature` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`literature` (
  `uid` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `type` VARCHAR(45) NULL,
  `date` VARCHAR(45) NULL,
  `db` VARCHAR(45) NULL,
  `title` VARCHAR(45) NULL,
  `pubmed` VARCHAR(45) NULL,
  `doi` VARCHAR(45) NULL,
  `volume` VARCHAR(45) NULL,
  `pages` VARCHAR(45) NULL,
  `journal` VARCHAR(45) NULL,
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB
COMMENT = '文献报道数据';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`protein_reference`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`protein_reference` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`protein_reference` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `reference_id` INT UNSIGNED NOT NULL,
  `scope` VARCHAR(45) NULL,
  PRIMARY KEY (`hash_code`, `reference_id`))
ENGINE = InnoDB
COMMENT = '对这个蛋白质的文献报道数据';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`protein_functions`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`protein_functions` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`protein_functions` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `function` VARCHAR(45) NULL COMMENT 'comment -> type = function',
  `name` VARCHAR(45) NULL,
  `full_name` VARCHAR(45) NULL COMMENT 'recommendedName',
  `short_name1` VARCHAR(45) NULL COMMENT 'recommendedName',
  `short_name2` VARCHAR(45) NULL COMMENT 'recommendedName',
  `short_name3` VARCHAR(45) NULL COMMENT 'recommendedName',
  PRIMARY KEY (`hash_code`),
  UNIQUE INDEX `hash_code_UNIQUE` (`hash_code` ASC))
ENGINE = InnoDB
COMMENT = '对蛋白质的名称以及功能方面的字符串描述';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`location_id`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`location_id` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`location_id` (
  `uid` INT UNSIGNED NOT NULL,
  `name` VARCHAR(45) NULL,
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`topology_id`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`topology_id` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`topology_id` (
  `uid` INT UNSIGNED NOT NULL,
  `name` VARCHAR(45) NULL,
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`protein_subcellular_location`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`protein_subcellular_location` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`protein_subcellular_location` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `location` VARCHAR(45) NULL,
  `location_id` INT UNSIGNED NULL,
  `topology` VARCHAR(45) NULL,
  `topology_id` INT UNSIGNED NULL,
  PRIMARY KEY (`hash_code`))
ENGINE = InnoDB
COMMENT = '目标蛋白质在细胞质中的亚细胞定位结果';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`alt_id`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`alt_id` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`alt_id` (
  `primary_hashcode` INT UNSIGNED NOT NULL,
  `alt_id` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL COMMENT 'The alternative(secondary) uniprot id',
  `name` VARCHAR(45) NULL COMMENT 'entry -> name',
  PRIMARY KEY (`primary_hashcode`, `alt_id`))
ENGINE = InnoDB
COMMENT = '当uniprot的XML数据库之中的某一条蛋白质的entry由多个uniprot编号的时候，在这个表之中就会记录下其他的编号信息，默认取entry记录的第一个accession编号为主编号';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`tissue_code`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`tissue_code` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`tissue_code` (
  `uid` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `tissue_name` VARCHAR(45) NOT NULL,
  `org_id` INT UNSIGNED NULL,
  `organism` VARCHAR(45) NULL COMMENT '物种名称',
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB
COMMENT = '对某一个物种的组织进行编号';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`tissue_locations`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`tissue_locations` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`tissue_locations` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `name` VARCHAR(45) NULL,
  `tissue_id` INT UNSIGNED NOT NULL,
  `tissue_name` VARCHAR(45) NULL,
  PRIMARY KEY (`hash_code`, `tissue_id`))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`xref`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`xref` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`xref` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `xref` VARCHAR(45) NOT NULL,
  `external_id` VARCHAR(45) NOT NULL,
  `molecule_type` VARCHAR(45) NULL,
  `protein_ID` VARCHAR(45) NULL,
  `nucleotide_ID` VARCHAR(45) NULL,
  PRIMARY KEY (`hash_code`))
ENGINE = InnoDB
COMMENT = '某一个uniprot蛋白质记录对外部的链接信息';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`gene_info`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`gene_info` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`gene_info` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `gene_name` VARCHAR(45) NULL,
  `ORF` VARCHAR(45) NULL,
  `synonym1` VARCHAR(45) NULL,
  `synonym2` VARCHAR(45) NULL,
  `synonym3` VARCHAR(45) NULL,
  PRIMARY KEY (`hash_code`))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`keywords`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`keywords` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`keywords` (
  `uid` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `keyword` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`protein_keywords`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`protein_keywords` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`protein_keywords` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NOT NULL,
  `keyword_id` INT UNSIGNED NOT NULL,
  `keyword` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`hash_code`, `keyword_id`))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`protein_alternative_Name`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`protein_alternative_Name` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`protein_alternative_Name` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `fullName` VARCHAR(45) NULL,
  `shortName1` VARCHAR(45) NULL,
  `shortName2` VARCHAR(45) NULL,
  `shortName3` VARCHAR(45) NULL,
  `shortName4` VARCHAR(45) NULL,
  `shortName5` VARCHAR(45) NULL,
  PRIMARY KEY (`hash_code`))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`peoples`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`peoples` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`peoples` (
  `uid` INT UNSIGNED NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`research_jobs`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`research_jobs` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`research_jobs` (
  `person` INT UNSIGNED NOT NULL,
  `people_name` VARCHAR(45) NULL,
  `literature_id` INT UNSIGNED NOT NULL,
  `literature_title` VARCHAR(45) NULL,
  PRIMARY KEY (`person`, `literature_id`))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`protein_structures`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`protein_structures` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`protein_structures` (
  `uid` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NOT NULL,
  `pdb_id` VARCHAR(45) NULL,
  `method` VARCHAR(45) NULL,
  `resolution` VARCHAR(45) NULL,
  `chains` VARCHAR(45) NULL,
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB
COMMENT = '主要是pdb结构记录数据';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`feature_types`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`feature_types` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`feature_types` (
  `uid` INT UNSIGNED NOT NULL,
  `type_name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`protein_feature_site`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`protein_feature_site` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`protein_feature_site` (
  `uid` INT UNSIGNED NOT NULL,
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `type_id` INT UNSIGNED NOT NULL,
  `type` VARCHAR(45) NULL,
  `description` VARCHAR(45) NULL,
  `position` VARCHAR(45) NULL,
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`protein_feature_regions`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`protein_feature_regions` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`protein_feature_regions` (
  `uid` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `type_id` INT UNSIGNED NOT NULL,
  `type` VARCHAR(45) NULL,
  `description` VARCHAR(45) NULL,
  `begin` VARCHAR(45) NULL,
  `end` VARCHAR(45) NULL,
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `kb_UniProtKB`.`feature_site_variation`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kb_UniProtKB`.`feature_site_variation` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `kb_UniProtKB`.`feature_site_variation` (
  `uid` INT UNSIGNED NOT NULL,
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NULL,
  `original` VARCHAR(45) NULL,
  `variation` VARCHAR(45) NULL,
  `position` VARCHAR(45) NULL,
  PRIMARY KEY (`uid`, `hash_code`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB
COMMENT = '序列的突变位点';

SHOW WARNINGS;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
