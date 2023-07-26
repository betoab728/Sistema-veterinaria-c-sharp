-- MySQL dump 10.13  Distrib 5.7.23, for Win32 (AMD64)
--
-- Host: grupoctc.ddns.net    Database: allqovet
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.48-MariaDB-0ubuntu0.18.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Cargo`
--

DROP TABLE IF EXISTS `Cargo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Cargo` (
  `idCargo` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCargo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cargo`
--

LOCK TABLES `Cargo` WRITE;
/*!40000 ALTER TABLE `Cargo` DISABLE KEYS */;
INSERT INTO `Cargo` VALUES (1,'Recepcionista'),(2,'Administrador');
/*!40000 ALTER TABLE `Cargo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `analisis`
--

DROP TABLE IF EXISTS `analisis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `analisis` (
  `idAnalisis` int(11) NOT NULL AUTO_INCREMENT,
  `idmascota` int(11) DEFAULT NULL,
  `Medico` varchar(100) DEFAULT NULL,
  `Propietario` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idAnalisis`),
  KEY `idmascota_idx` (`idmascota`),
  CONSTRAINT `idmascota` FOREIGN KEY (`idmascota`) REFERENCES `mascota` (`idMascota`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `analisis`
--

LOCK TABLES `analisis` WRITE;
/*!40000 ALTER TABLE `analisis` DISABLE KEYS */;
/*!40000 ALTER TABLE `analisis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `boleta`
--

DROP TABLE IF EXISTS `boleta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `boleta` (
  `Idboleta` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `Serie` varchar(4) DEFAULT NULL,
  `Numero` int(11) DEFAULT NULL,
  `Idventa` int(11) DEFAULT NULL,
  `Total` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`Idboleta`),
  KEY `idventa_idx` (`Idventa`),
  CONSTRAINT `idventa` FOREIGN KEY (`Idventa`) REFERENCES `venta` (`Idventa`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `boleta`
--

LOCK TABLES `boleta` WRITE;
/*!40000 ALTER TABLE `boleta` DISABLE KEYS */;
INSERT INTO `boleta` VALUES (2,'2023-06-21','16:13:31','B001',1,26,16.00),(3,'2023-06-21','16:15:11','B001',2,26,16.00),(4,'2023-06-21','16:16:08','B001',3,26,16.00),(5,'2023-06-21','16:19:22','B001',4,26,16.00),(6,'2023-06-21','16:21:42','B001',5,26,16.00),(7,'2023-06-21','16:24:27','B001',6,26,16.00),(8,'2023-06-21','16:25:46','B001',7,26,16.00),(9,'2023-06-21','16:29:01','B001',8,26,16.00),(10,'2023-06-21','16:30:20','B001',9,26,16.00),(11,'2023-06-21','16:32:02','B001',10,26,16.00),(12,'2023-06-21','16:33:35','B001',11,26,16.00),(13,'2023-06-21','16:35:47','B001',12,26,16.00),(14,'2023-06-21','16:37:17','B001',13,26,16.00),(15,'2023-06-21','16:39:02','B001',14,26,16.00),(16,'2023-06-21','16:43:55','B001',15,26,16.00),(17,'2023-06-21','17:53:13','B001',16,26,16.00),(18,'2023-06-21','19:12:11','B001',17,1,5.00),(19,'2023-06-27','23:25:14','B001',18,35,1.00),(20,'2023-06-28','18:59:02','B001',19,39,1.00),(21,'2023-06-29','23:53:38','B001',20,41,1.00),(22,'2023-07-05','19:49:25','B001',21,49,1.00),(23,'2023-07-08','22:10:39','B000',0,47,2.00),(24,'2023-07-12','21:10:21','B001',1,50,95.00);
/*!40000 ALTER TABLE `boleta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cajachica`
--

DROP TABLE IF EXISTS `cajachica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cajachica` (
  `Idcajachica` int(11) NOT NULL AUTO_INCREMENT,
  `FechaApertura` datetime DEFAULT CURRENT_TIMESTAMP,
  `FechaCierre` datetime DEFAULT NULL,
  `Idtrabajador` int(11) DEFAULT NULL,
  `Estado` tinyint(1) DEFAULT '1',
  `ImporteApertura` decimal(10,2) DEFAULT NULL,
  `ImporteCierre` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`Idcajachica`),
  KEY `idtrabajador_idx` (`Idtrabajador`),
  CONSTRAINT `idtrabajadorxfd` FOREIGN KEY (`Idtrabajador`) REFERENCES `trabajador` (`Idtrabajador`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cajachica`
--

LOCK TABLES `cajachica` WRITE;
/*!40000 ALTER TABLE `cajachica` DISABLE KEYS */;
INSERT INTO `cajachica` VALUES (1,'2023-06-18 18:33:18','2023-07-14 15:45:47',2,0,20.00,259.00),(2,'2023-07-05 18:24:51',NULL,1,0,30.00,NULL),(3,'2023-07-05 19:29:22',NULL,1,1,30.00,NULL);
/*!40000 ALTER TABLE `cajachica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categoria` (
  `Idcategoria` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Idcategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Juguete'),(2,'Comida'),(3,'Ropa'),(4,'Medicamento'),(10,'RicoCat'),(11,'accesorios');
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `causamovimiento`
--

DROP TABLE IF EXISTS `causamovimiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `causamovimiento` (
  `idcausa` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idcausa`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `causamovimiento`
--

LOCK TABLES `causamovimiento` WRITE;
/*!40000 ALTER TABLE `causamovimiento` DISABLE KEYS */;
INSERT INTO `causamovimiento` VALUES (1,'VENTA DE PRODUCTOS'),(2,'INGRESO DE PRODUCTOS');
/*!40000 ALTER TABLE `causamovimiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cita`
--

DROP TABLE IF EXISTS `cita`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cita` (
  `Idcita` int(11) NOT NULL AUTO_INCREMENT,
  `Idtipo` int(11) DEFAULT NULL,
  `Fecha` date DEFAULT NULL,
  `Hora` datetime DEFAULT NULL,
  `Descripcion` varchar(200) DEFAULT NULL,
  `idMascota` int(11) DEFAULT NULL,
  `atendido` char(1) DEFAULT NULL,
  `estado` char(1) DEFAULT '1',
  PRIMARY KEY (`Idcita`),
  KEY `idtipo_idx` (`Idtipo`),
  KEY `fk_idMascota` (`idMascota`),
  CONSTRAINT `fk_idMascota` FOREIGN KEY (`idMascota`) REFERENCES `mascota` (`idMascota`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idtipoxcx` FOREIGN KEY (`Idtipo`) REFERENCES `tipocita` (`Idtipocita`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cita`
--

LOCK TABLES `cita` WRITE;
/*!40000 ALTER TABLE `cita` DISABLE KEYS */;
INSERT INTO `cita` VALUES (8,1,'2023-07-07','2023-07-05 17:00:05','ffsdfdsf',1,'1','0'),(9,1,'2023-07-08','2023-07-05 08:51:03','desparacitacion externa',9,'1','0');
/*!40000 ALTER TABLE `cita` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cliente` (
  `idCliente` int(11) NOT NULL AUTO_INCREMENT,
  `DNI` char(8) DEFAULT NULL,
  `ApellidoPaterno` varchar(50) DEFAULT NULL,
  `ApellidoMaterno` varchar(50) DEFAULT NULL,
  `Nombres` varchar(50) DEFAULT NULL,
  `Direccion` varchar(200) DEFAULT NULL,
  `Telefono` varchar(20) DEFAULT NULL,
  `Correo` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'96521478','Torres','Atarama','Lisbeth','piura','4547875','ddcdeeefe@gmail.com'),(2,'45879632','Maza','Escobar','Ricardo','urb piura','9878787','trefsdf@gmail.com'),(3,'56932147','Castro','Ancajima','Adriana','talara','93356566','ddgralk@gmail.com'),(4,'85544798','Vegas','Palomino','Carlos Javier','sullana','98745897','erfreegw@gmail.com'),(5,'7845457','Ruiz','Palacion','Gianina','castilla','9855457','fgrsdww@gmail.com'),(6,'78454578','Garcia','Torres','Maria','piura','9854547','hgfser@gmail.com'),(7,'56632145','campos','rivera','bertha','av grau 656','545454','bhhg@gmail.com'),(8,'78841236','reyes','correa','omar','trujiillo','8989898','8989898'),(9,'323233','seminario','chavez','estefano','castilla','90090','90090'),(10,'02851527','SEMINARIO','ADRIANZEN','PEDRO','CALLE HUASCAR 700','876543234','876543234'),(11,'80234559','MONTERO','TALLEDO','CESAR ALBERTO','av progreso','999999','999999'),(12,'07438830','ALEGRE','SAENZ','ALBERTO PABLO','','',''),(13,'73043989','SEGURA','MARCELO','NATHALY MARIEL','Ignacio Merino','98562322','98562322'),(15,'','Clientes-Varios','','','','',''),(16,'73043989','SEGURA','MARCELO','NATHALY MARIEL','','',''),(17,'45678525','MARONA','ACERO','RENE','','',''),(18,'00255357','MARCELO','YARLEQUE','MARIELA MILAGROS','cccccccc','789456123','789456123'),(19,'09859503','LACHERRE','CALDERON','ENRIQUE MANUEL','Catacaos','954786958','954786958');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `correlativo`
--

DROP TABLE IF EXISTS `correlativo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `correlativo` (
  `idcorrelativo` int(11) NOT NULL,
  `numero_ficha` int(11) DEFAULT NULL,
  `numero_venta` int(11) DEFAULT NULL,
  `serie_venta` varchar(10) DEFAULT NULL,
  `serie_factura` varchar(10) DEFAULT NULL,
  `numero_factura` int(11) DEFAULT NULL,
  `serie_boleta` varchar(10) DEFAULT NULL,
  `numero_boleta` int(11) DEFAULT NULL,
  PRIMARY KEY (`idcorrelativo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `correlativo`
--

LOCK TABLES `correlativo` WRITE;
/*!40000 ALTER TABLE `correlativo` DISABLE KEYS */;
INSERT INTO `correlativo` VALUES (1,1,32,'NV-001','F-001',0,'B001',1);
/*!40000 ALTER TABLE `correlativo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalleanalisis`
--

DROP TABLE IF EXISTS `detalleanalisis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalleanalisis` (
  `idDetalle` int(11) NOT NULL,
  `idAnalisis` int(11) DEFAULT NULL,
  `DetalleAnalisis` varchar(45) DEFAULT NULL,
  `Resultados` varchar(20) DEFAULT NULL,
  `Unidades` varchar(15) DEFAULT NULL,
  `ValorReferencial` varchar(20) DEFAULT NULL,
  `Metodo` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`idDetalle`),
  KEY `idanalisis_idx` (`idAnalisis`),
  CONSTRAINT `idanalisis` FOREIGN KEY (`idAnalisis`) REFERENCES `analisis` (`idAnalisis`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalleanalisis`
--

LOCK TABLES `detalleanalisis` WRITE;
/*!40000 ALTER TABLE `detalleanalisis` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalleanalisis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalleboleta`
--

DROP TABLE IF EXISTS `detalleboleta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalleboleta` (
  `Iddetalle` int(11) NOT NULL AUTO_INCREMENT,
  `Idboleta` int(11) DEFAULT NULL,
  `Idproducto` int(11) DEFAULT NULL,
  `Descripcion` varchar(50) DEFAULT NULL,
  `Cantidad` int(11) DEFAULT NULL,
  `Precio` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`Iddetalle`),
  KEY `idboleta_idx` (`Idboleta`),
  KEY `idproducto_idx` (`Idproducto`),
  CONSTRAINT `idboleta` FOREIGN KEY (`Idboleta`) REFERENCES `boleta` (`Idboleta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idproductoxx` FOREIGN KEY (`Idproducto`) REFERENCES `producto` (`Idproducto`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalleboleta`
--

LOCK TABLES `detalleboleta` WRITE;
/*!40000 ALTER TABLE `detalleboleta` DISABLE KEYS */;
INSERT INTO `detalleboleta` VALUES (1,2,6,'Producto 1 Dog Chow',6,6.00),(2,2,10,'Producto 5 Cat Chow',10,10.00),(3,3,6,'Producto 1 Dog Chow',6,6.00),(4,3,10,'Producto 5 Cat Chow',10,10.00),(5,4,6,'Producto 1 Dog Chow',6,6.00),(6,4,10,'Producto 5 Cat Chow',10,10.00),(7,5,6,'Producto 1 Dog Chow',6,6.00),(8,5,10,'Producto 5 Cat Chow',10,10.00),(9,6,6,'Producto 1 Dog Chow',6,6.00),(10,6,10,'Producto 5 Cat Chow',10,10.00),(11,7,6,'Producto 1 Dog Chow',6,6.00),(12,7,10,'Producto 5 Cat Chow',10,10.00),(13,8,6,'Producto 1 Dog Chow',6,6.00),(14,8,10,'Producto 5 Cat Chow',10,10.00),(15,9,6,'Producto 1 Dog Chow',6,6.00),(16,9,10,'Producto 5 Cat Chow',10,10.00),(17,10,6,'Producto 1 Dog Chow',6,6.00),(18,10,10,'Producto 5 Cat Chow',10,10.00),(19,11,6,'Producto 1 Dog Chow',6,6.00),(20,11,10,'Producto 5 Cat Chow',10,10.00),(21,12,6,'Producto 1 Dog Chow',6,6.00),(22,12,10,'Producto 5 Cat Chow',10,10.00),(23,13,6,'Producto 1 Dog Chow',6,6.00),(24,13,10,'Producto 5 Cat Chow',10,10.00),(25,14,6,'Producto 1 Dog Chow',6,6.00),(26,14,10,'Producto 5 Cat Chow',10,10.00),(27,15,6,'Producto 1 Dog Chow',6,6.00),(28,15,10,'Producto 5 Cat Chow',10,10.00),(29,16,6,'Producto 1 Dog Chow',6,6.00),(30,16,10,'Producto 5 Cat Chow',10,10.00),(31,17,6,'Producto 1 Dog Chow',6,6.00),(32,17,10,'Producto 5 Cat Chow',10,10.00),(33,18,6,'Producto 1',2,2.00),(34,18,7,'Producto 2',3,3.00),(35,19,8,'Producto 3 Dog Chow',1,1.00),(36,20,7,'Producto 2 Cat Chow',1,1.00),(37,21,5,'comida cachorro Super Can',1,1.00),(38,22,7,'Producto 2 Cat Chow',1,1.00),(39,23,1,'comida adulto Dog Chow',2,2.00),(40,24,1,'comida adulto Dog Chow',3,25.00),(41,24,5,'comida cachorro Super Can',1,20.00);
/*!40000 ALTER TABLE `detalleboleta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detallefactura`
--

DROP TABLE IF EXISTS `detallefactura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detallefactura` (
  `Iddetalle` int(11) NOT NULL AUTO_INCREMENT,
  `Idfactura` int(11) DEFAULT NULL,
  `Idproducto` int(11) DEFAULT NULL,
  `Descripcion` varchar(50) DEFAULT NULL,
  `Cantidad` int(11) DEFAULT NULL,
  `Precio` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`Iddetalle`),
  KEY `idfactura_idx` (`Idfactura`),
  KEY `idproducto_idx` (`Idproducto`),
  CONSTRAINT `idfactura` FOREIGN KEY (`Idfactura`) REFERENCES `factura` (`Idfactura`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idproductoxc` FOREIGN KEY (`Idproducto`) REFERENCES `producto` (`Idproducto`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detallefactura`
--

LOCK TABLES `detallefactura` WRITE;
/*!40000 ALTER TABLE `detallefactura` DISABLE KEYS */;
INSERT INTO `detallefactura` VALUES (1,1,6,'Producto 1 Dog Chow',6,6.00),(2,1,10,'Producto 5 Cat Chow',10,10.00),(3,2,6,'Producto 1 Dog Chow',6,6.00),(4,2,10,'Producto 5 Cat Chow',10,10.00),(5,3,5,'comida cachorro Super Can',1,1.00),(6,4,6,'Producto 1',2,2.00),(7,4,7,'Producto 2',3,3.00),(8,4,1,'Producto',12,12.00);
/*!40000 ALTER TABLE `detallefactura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalleficha`
--

DROP TABLE IF EXISTS `detalleficha`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalleficha` (
  `iddetalle` int(11) NOT NULL AUTO_INCREMENT,
  `idficha` int(11) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `descripcion` varchar(200) DEFAULT NULL,
  `temperatura` varchar(200) DEFAULT NULL,
  `proxcita` date DEFAULT NULL,
  `registrado` char(1) DEFAULT '1',
  PRIMARY KEY (`iddetalle`),
  KEY `idfichadetalleficha_idx` (`idficha`),
  CONSTRAINT `idfichadetalleficha` FOREIGN KEY (`idficha`) REFERENCES `ficha` (`Idficha`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalleficha`
--

LOCK TABLES `detalleficha` WRITE;
/*!40000 ALTER TABLE `detalleficha` DISABLE KEYS */;
INSERT INTO `detalleficha` VALUES (1,1,'2023-06-16','prueba descripcion','38 ffdf','2023-07-16','1'),(2,1,'2023-06-15','prueba 2 descripcion','36.8 efere','2023-08-16','1'),(3,1,'2023-06-17','prueba sabado 17 junio','fsdf4343','2023-07-20','1'),(4,2,'2023-07-05','atendido ','38','2023-09-05','1'),(5,2,'2023-07-12','atencion martes 12-07 paciente vino con garrapatas','38','2023-07-26','1'),(6,2,'2023-07-19','apetito normal','38.6','2023-07-28','1');
/*!40000 ALTER TABLE `detalleficha` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detallepedido`
--

DROP TABLE IF EXISTS `detallepedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detallepedido` (
  `Iddetalle` int(11) NOT NULL AUTO_INCREMENT,
  `Idpedido` int(11) DEFAULT NULL,
  `idproducto` int(11) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `precio` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`Iddetalle`),
  KEY `idpedido_idx` (`Idpedido`),
  KEY `idprodpedido_idx` (`idproducto`),
  CONSTRAINT `idpedido` FOREIGN KEY (`Idpedido`) REFERENCES `pedido` (`idPedido`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idprodpedido` FOREIGN KEY (`idproducto`) REFERENCES `producto` (`Idproducto`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detallepedido`
--

LOCK TABLES `detallepedido` WRITE;
/*!40000 ALTER TABLE `detallepedido` DISABLE KEYS */;
INSERT INTO `detallepedido` VALUES (8,NULL,5,'comida cachorro Super Can',1,20.00),(9,9,8,'Producto 3 Dog Chow',1,18.00),(10,10,8,'Producto 3 Dog Chow',1,18.00),(11,11,8,'Producto 3 Dog Chow',21,18.00),(12,12,8,'Producto 3 Dog Chow',1,18.00),(13,13,8,'Producto 3 Dog Chow',1,18.00),(14,14,8,'Producto 3 Dog Chow',1,18.00),(15,15,8,'Producto 3 Dog Chow',1,18.00),(16,16,8,'Producto 3 Dog Chow',1,18.00),(17,17,8,'Producto 3 Dog Chow',1,18.00),(18,18,8,'Producto 3 Dog Chow',1,18.00),(19,19,8,'Producto 3 Dog Chow',1,18.00),(20,20,5,'comida cachorro Super Can',3,20.00),(21,21,1,'comida adulto Dog Chow',20,25.00);
/*!40000 ALTER TABLE `detallepedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalleventa`
--

DROP TABLE IF EXISTS `detalleventa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalleventa` (
  `Iddetalle` int(11) NOT NULL AUTO_INCREMENT,
  `Idventa` int(11) DEFAULT NULL,
  `Idproducto` int(11) DEFAULT NULL,
  `Descripcion` varchar(50) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `Precio` decimal(10,2) DEFAULT NULL,
  `costo` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`Iddetalle`),
  KEY `idproducto_idx` (`Idproducto`),
  KEY `idventax_idx` (`Idventa`),
  CONSTRAINT `idproductox` FOREIGN KEY (`Idproducto`) REFERENCES `producto` (`Idproducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idventax` FOREIGN KEY (`Idventa`) REFERENCES `venta` (`Idventa`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalleventa`
--

LOCK TABLES `detalleventa` WRITE;
/*!40000 ALTER TABLE `detalleventa` DISABLE KEYS */;
INSERT INTO `detalleventa` VALUES (11,1,6,'Producto 1',2,40.00,NULL),(12,1,7,'Producto 2',3,75.00,NULL),(13,2,8,'Producto 3',1,18.00,NULL),(14,2,9,'Producto 4',2,44.00,NULL),(15,3,10,'Producto 5',5,95.00,NULL),(16,6,6,'Producto 1',10,30.00,NULL),(17,7,7,'Producto 1',5,30.00,NULL),(18,8,10,'Producto 5',6,30.00,NULL),(19,2,7,'Producto 2 Cat Chow',7,25.00,15.00),(20,2,8,'Producto 3 Dog Chow',8,18.00,8.00),(21,25,5,'comida cachorro Super Can',1,20.00,13.00),(22,25,10,'Producto 5 Cat Chow',2,19.00,9.00),(23,26,6,'Producto 1 Dog Chow',6,20.00,10.00),(24,26,10,'Producto 5 Cat Chow',10,19.00,9.00),(25,27,6,'Producto 1 Dog Chow',1,20.00,10.00),(26,27,8,'Producto 3 Dog Chow',2,18.00,8.00),(27,28,5,'comida cachorro Super Can',1,20.00,13.00),(28,28,6,'Producto 1 Dog Chow',2,20.00,10.00),(29,29,1,'comida adulto Dog Chow',1,25.00,15.00),(30,29,1,'comida adulto Dog Chow',2,25.00,15.00),(31,30,1,'comida adulto Dog Chow',1,25.00,15.00),(32,31,5,'comida cachorro Super Can',1,20.00,13.00),(33,1,1,'Producto',12,12.00,5.00),(34,32,6,'Producto 1 Dog Chow',1,20.00,10.00),(35,33,6,'Producto 1 Dog Chow',1,20.00,10.00),(36,34,7,'Producto 2 Cat Chow',1,25.00,15.00),(37,35,8,'Producto 3 Dog Chow',1,18.00,8.00),(38,39,7,'Producto 2 Cat Chow',1,25.00,15.00),(39,40,7,'Producto 2 Cat Chow',1,25.00,15.00),(40,41,5,'comida cachorro Super Can',1,20.00,13.00),(41,42,9,'Producto 4 Canbo',1,22.00,12.00),(42,43,8,'Producto 3 Dog Chow',2,18.00,8.00),(43,44,5,'comida cachorro Super Can',3,20.00,13.00),(44,46,7,'Producto 2 Cat Chow',1,25.00,15.00),(45,47,1,'comida adulto Dog Chow',2,25.00,15.00),(46,48,1,'comida adulto Dog Chow',1,25.00,15.00),(47,49,7,'Producto 2 Cat Chow',1,25.00,15.00),(48,50,1,'comida adulto Dog Chow',3,25.00,15.00),(49,50,5,'comida cachorro Super Can',1,20.00,13.00),(50,51,1,'comida adulto Dog Chow',1,25.00,15.00),(51,52,1,'comida adulto Dog Chow',1,25.00,15.00);
/*!40000 ALTER TABLE `detalleventa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `documento`
--

DROP TABLE IF EXISTS `documento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `documento` (
  `iddocumento` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`iddocumento`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documento`
--

LOCK TABLES `documento` WRITE;
/*!40000 ALTER TABLE `documento` DISABLE KEYS */;
INSERT INTO `documento` VALUES (1,'BOLETA'),(2,'FACTURA'),(3,'NOTA DE VENTA');
/*!40000 ALTER TABLE `documento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entrada`
--

DROP TABLE IF EXISTS `entrada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `entrada` (
  `Identrada` int(11) NOT NULL AUTO_INCREMENT,
  `Idmovimiento` int(11) DEFAULT NULL,
  `Idproducto` int(11) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  PRIMARY KEY (`Identrada`),
  KEY `idmov2_idx` (`Idmovimiento`),
  CONSTRAINT `idmov2` FOREIGN KEY (`Idmovimiento`) REFERENCES `movimiento` (`idMovimiento`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entrada`
--

LOCK TABLES `entrada` WRITE;
/*!40000 ALTER TABLE `entrada` DISABLE KEYS */;
INSERT INTO `entrada` VALUES (1,14,5,1),(2,15,8,1),(3,16,8,1),(4,17,8,21),(5,18,8,1),(6,19,8,1),(7,20,8,1),(8,21,8,1),(9,22,8,1),(10,23,8,1),(11,24,8,1),(12,25,8,1),(13,32,5,3),(14,41,1,20);
/*!40000 ALTER TABLE `entrada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura`
--

DROP TABLE IF EXISTS `factura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `factura` (
  `Idfactura` int(11) NOT NULL AUTO_INCREMENT,
  `Fecha` date DEFAULT NULL,
  `Hora` time DEFAULT NULL,
  `Serie` varchar(5) DEFAULT NULL,
  `Numero` int(11) DEFAULT NULL,
  `Idventa` int(11) DEFAULT NULL,
  `Total` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`Idfactura`),
  KEY `idventa_idx` (`Idventa`),
  CONSTRAINT `idventaxd` FOREIGN KEY (`Idventa`) REFERENCES `venta` (`Idventa`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura`
--

LOCK TABLES `factura` WRITE;
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
INSERT INTO `factura` VALUES (1,'2023-06-21','17:35:57','F-001',1,26,16.00),(2,'2023-06-21','17:46:13','F-001',2,26,16.00),(3,'2023-06-29','23:58:09','F-001',3,41,1.00),(4,'2023-07-08','22:09:09','F000',0,1,17.00);
/*!40000 ALTER TABLE `factura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ficha`
--

DROP TABLE IF EXISTS `ficha`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ficha` (
  `Idficha` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) DEFAULT NULL,
  `registro` datetime DEFAULT CURRENT_TIMESTAMP,
  `Idmascota` int(11) DEFAULT NULL,
  `Idcliente` int(11) DEFAULT NULL,
  `Idcita` int(11) DEFAULT NULL,
  PRIMARY KEY (`Idficha`),
  KEY `idcliente_idx` (`Idcliente`),
  KEY `idmascota_idx` (`Idmascota`),
  KEY `idcita_idx` (`Idcita`),
  CONSTRAINT `idcita` FOREIGN KEY (`Idcita`) REFERENCES `cita` (`Idcita`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idclientegf` FOREIGN KEY (`Idcliente`) REFERENCES `cliente` (`idCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idmascotaxcsd` FOREIGN KEY (`Idmascota`) REFERENCES `mascota` (`idMascota`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ficha`
--

LOCK TABLES `ficha` WRITE;
/*!40000 ALTER TABLE `ficha` DISABLE KEYS */;
INSERT INTO `ficha` VALUES (1,1,'2023-06-16 17:43:51',1,11,NULL),(2,2,'2023-07-05 19:56:33',9,19,NULL);
/*!40000 ALTER TABLE `ficha` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marca`
--

DROP TABLE IF EXISTS `marca`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `marca` (
  `Idmarca` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Idmarca`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marca`
--

LOCK TABLES `marca` WRITE;
/*!40000 ALTER TABLE `marca` DISABLE KEYS */;
INSERT INTO `marca` VALUES (1,'Dog Chow'),(2,'Cat Chow'),(3,'Canbo'),(4,'Pedigree'),(5,'Super Can'),(6,'Friskies'),(7,'Simparica 4-10 kg'),(8,'pedigree');
/*!40000 ALTER TABLE `marca` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mascota`
--

DROP TABLE IF EXISTS `mascota`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mascota` (
  `idMascota` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(60) DEFAULT NULL,
  `FechaNacimiento` date DEFAULT NULL,
  `raza` varchar(45) DEFAULT NULL,
  `especie` varchar(45) DEFAULT NULL,
  `sexo` varchar(1) DEFAULT NULL,
  `capa` varchar(45) DEFAULT NULL,
  `observacion` varchar(200) DEFAULT NULL,
  `idcliente` int(11) DEFAULT NULL,
  PRIMARY KEY (`idMascota`),
  KEY `idclientemascota_idx` (`idcliente`),
  CONSTRAINT `idclientemascota` FOREIGN KEY (`idcliente`) REFERENCES `cliente` (`idCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mascota`
--

LOCK TABLES `mascota` WRITE;
/*!40000 ALTER TABLE `mascota` DISABLE KEYS */;
INSERT INTO `mascota` VALUES (1,'chester','2023-01-01','doberman','canino','m','chocolate','sdeefef',11),(2,'thor','2023-06-14','pitbull','canino','m','gris','edede',11),(3,'apolo','2023-05-14','dogo','canino','m','blanco','5454',12),(4,'boby','2018-01-11','shitzu','canino','m','marron','25245',12),(5,'patitas','2022-10-05','pitbull','perro','f','marron','',13),(6,'Eddyto','2023-07-04','Ninguna','Canino','m','HOla','',16),(7,'Fuffy','2023-07-05','-','Canino','m','-','',17),(8,'kitty','2023-01-10','-','felino','m','blanco','-',18),(9,'Eddy','2023-05-05','Shitzu','Canino','m','Marron','\"Es mordelón\"',19);
/*!40000 ALTER TABLE `mascota` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mediopago`
--

DROP TABLE IF EXISTS `mediopago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mediopago` (
  `Idmediopago` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Idmediopago`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mediopago`
--

LOCK TABLES `mediopago` WRITE;
/*!40000 ALTER TABLE `mediopago` DISABLE KEYS */;
INSERT INTO `mediopago` VALUES (1,'Efectivo'),(2,'Yape'),(3,'VISA DEBITO'),(4,'VISA CREDITO'),(5,'MASTER CARD DEBITO'),(6,'MASTER CARD CREDITO');
/*!40000 ALTER TABLE `mediopago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `menu` (
  `idmenu` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `descripcion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idmenu`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (1,'btnVentas','Ventas'),(2,'btnClientes','Clientes'),(3,'btnProductos','Productos'),(4,'btnFacturacion','Facturacion'),(5,'btnReportes','Reportes'),(6,'btnAlmacen','Almacen'),(7,'btnConsultorio','Consultorio'),(8,'btnMantenimiento','Mantenimiento'),(9,'btnSistema','Sistema');
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movimiento`
--

DROP TABLE IF EXISTS `movimiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movimiento` (
  `idMovimiento` int(11) NOT NULL AUTO_INCREMENT,
  `Tipo` varchar(1) DEFAULT NULL,
  `Fecha` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `Idventa` int(11) DEFAULT NULL,
  `Idpedido` int(11) DEFAULT NULL,
  `idcausa` int(11) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `estado` char(1) DEFAULT '1',
  PRIMARY KEY (`idMovimiento`),
  KEY `idventramov_idx` (`Idventa`),
  KEY `idpedidomov_idx` (`Idpedido`),
  KEY `idcausamov_idx` (`idcausa`),
  CONSTRAINT `idcausamov` FOREIGN KEY (`idcausa`) REFERENCES `causamovimiento` (`idcausa`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idpedidomov` FOREIGN KEY (`Idpedido`) REFERENCES `pedido` (`idPedido`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idventramov` FOREIGN KEY (`Idventa`) REFERENCES `venta` (`Idventa`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movimiento`
--

LOCK TABLES `movimiento` WRITE;
/*!40000 ALTER TABLE `movimiento` DISABLE KEYS */;
INSERT INTO `movimiento` VALUES (1,'s','2023-06-19 23:07:49',2,NULL,1,3,'1'),(2,'s','2023-06-20 17:35:57',25,NULL,1,6,'1'),(3,'s','2023-06-20 17:39:04',26,NULL,1,4,'1'),(4,'s','2023-06-20 20:58:29',27,NULL,1,3,'1'),(5,'s','2023-06-20 22:41:42',28,NULL,1,3,'1'),(6,'s','2023-06-22 00:04:05',29,NULL,1,3,'1'),(7,'s','2023-06-22 00:07:56',30,NULL,1,1,'1'),(8,'s','2023-06-22 00:56:35',31,NULL,1,1,'1'),(14,'e','2023-06-24 05:28:02',NULL,8,2,1,'1'),(15,'e','2023-06-24 05:32:56',NULL,9,2,1,'1'),(16,'e','2023-06-24 05:36:26',NULL,10,2,1,'1'),(17,'e','2023-06-24 05:38:21',NULL,11,2,21,'1'),(18,'e','2023-06-24 05:43:32',NULL,12,2,1,'1'),(19,'e','2023-06-24 05:49:50',NULL,13,2,1,'1'),(20,'e','2023-06-24 05:51:22',NULL,14,2,1,'1'),(21,'e','2023-06-24 05:52:42',NULL,15,2,1,'1'),(22,'e','2023-06-24 05:54:00',NULL,16,2,1,'1'),(23,'e','2023-06-24 05:54:27',NULL,17,2,1,'1'),(24,'e','2023-06-24 05:58:22',NULL,18,2,1,'1'),(25,'e','2023-06-24 06:00:19',NULL,19,2,1,'1'),(26,'s','2023-06-25 23:26:34',32,NULL,1,1,'1'),(27,'s','2023-06-25 23:28:22',33,NULL,1,1,'1'),(28,'s','2023-06-25 23:29:48',34,NULL,1,1,'1'),(29,'s','2023-06-28 04:19:03',35,NULL,1,1,'1'),(30,'s','2023-06-28 23:57:59',39,NULL,1,1,'1'),(31,'s','2023-06-29 00:02:24',40,NULL,1,1,'1'),(32,'e','2023-06-29 20:17:32',NULL,20,2,3,'1'),(33,'s','2023-06-30 00:57:00',41,NULL,1,1,'1'),(34,'s','2023-06-30 01:33:24',42,NULL,1,1,'1'),(35,'s','2023-06-30 03:54:29',43,NULL,1,2,'1'),(36,'s','2023-06-30 03:56:58',44,NULL,1,3,'1'),(37,'s','2023-07-05 03:46:57',46,NULL,1,1,'1'),(38,'s','2023-07-06 00:39:11',47,NULL,1,2,'0'),(39,'s','2023-07-06 00:43:40',48,NULL,1,1,'1'),(40,'s','2023-07-06 00:47:16',49,NULL,1,1,'0'),(41,'e','2023-07-06 00:59:27',NULL,21,2,20,'1'),(42,'s','2023-07-13 02:08:54',50,NULL,1,4,'0'),(43,'s','2023-07-20 00:20:52',51,NULL,1,1,'0'),(44,'s','2023-07-20 00:29:59',52,NULL,1,1,'0');
/*!40000 ALTER TABLE `movimiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nivelacceso`
--

DROP TABLE IF EXISTS `nivelacceso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nivelacceso` (
  `Idnivel` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Idnivel`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nivelacceso`
--

LOCK TABLES `nivelacceso` WRITE;
/*!40000 ALTER TABLE `nivelacceso` DISABLE KEYS */;
INSERT INTO `nivelacceso` VALUES (1,'VENTAS'),(2,'ADMINISTRADOR');
/*!40000 ALTER TABLE `nivelacceso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operacion`
--

DROP TABLE IF EXISTS `operacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `operacion` (
  `Idoperacion` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date DEFAULT NULL,
  `Concepto` varchar(200) DEFAULT NULL,
  `Tipo` varchar(1) DEFAULT NULL,
  `Idmediopago` int(11) DEFAULT NULL,
  `Importe` decimal(10,2) DEFAULT NULL,
  `Digitostarjeta` varchar(16) DEFAULT NULL,
  `Estado` char(1) DEFAULT '1',
  `Idventa` int(11) DEFAULT NULL,
  `Idcajachica` int(11) DEFAULT NULL,
  `FechaRegistro` datetime DEFAULT CURRENT_TIMESTAMP,
  `idtipo` int(11) DEFAULT NULL,
  `iddocumento` int(11) DEFAULT NULL,
  `serie` varchar(10) DEFAULT NULL,
  `numero` int(11) DEFAULT NULL,
  PRIMARY KEY (`Idoperacion`),
  KEY `idmedio_idx` (`Idmediopago`),
  KEY `idventaaa_idx` (`Idventa`),
  KEY `idcajach_idx` (`Idcajachica`),
  KEY `idtipo_idx` (`idtipo`),
  KEY `iddocumento` (`iddocumento`),
  CONSTRAINT `idcajach` FOREIGN KEY (`Idcajachica`) REFERENCES `cajachica` (`Idcajachica`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idmedio` FOREIGN KEY (`Idmediopago`) REFERENCES `mediopago` (`Idmediopago`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idtipo` FOREIGN KEY (`idtipo`) REFERENCES `tipooperacion` (`idtipooperacion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idventaaa` FOREIGN KEY (`Idventa`) REFERENCES `venta` (`Idventa`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `operacion_ibfk_1` FOREIGN KEY (`iddocumento`) REFERENCES `documento` (`iddocumento`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operacion`
--

LOCK TABLES `operacion` WRITE;
/*!40000 ALTER TABLE `operacion` DISABLE KEYS */;
INSERT INTO `operacion` VALUES (1,NULL,'Pago de venta N° NV-001-00000018','I',1,25.00,'','1',34,1,'2023-06-25 08:31:06',1,1,NULL,NULL),(2,NULL,'Pago de venta N° NV-001-00000019','I',1,18.00,'','1',35,1,'2023-06-27 23:22:10',1,2,NULL,NULL),(3,NULL,'Pago de venta N° NV-001-00000020','I',1,25.00,'','1',39,1,'2023-06-28 18:58:13',1,NULL,NULL,NULL),(4,NULL,'Pago de venta N° NV-001-00000021','I',1,25.00,'','0',40,1,'2023-06-28 19:02:41',1,NULL,NULL,NULL),(5,NULL,'Pago de venta N° NV-001-00000022','I',1,20.00,'','1',41,1,'2023-06-29 19:57:31',1,NULL,NULL,NULL),(6,NULL,'prueba',NULL,NULL,NULL,NULL,'1',NULL,NULL,'2023-06-29 20:40:38',NULL,NULL,NULL,NULL),(7,'2023-06-29','cuaderno rayado','E',2,7.00,NULL,'1',NULL,1,'2023-06-29 22:39:27',53,3,'1',222),(8,NULL,'Pago de venta N° NV-001-00000024','I',1,36.00,'','1',43,1,'2023-06-29 22:54:44',1,NULL,NULL,NULL),(9,NULL,'Pago de venta N° NV-001-00000025','I',1,60.00,'','1',44,1,'2023-06-29 22:57:07',1,NULL,NULL,NULL),(10,NULL,'Pago de venta N° NV-001-00000026','I',1,25.00,'','1',46,1,'2023-07-04 22:47:07',1,NULL,NULL,NULL),(11,NULL,'Pago de venta N° NV-001-00000027','I',1,50.00,'','0',47,1,'2023-07-05 19:41:28',1,NULL,NULL,NULL),(12,NULL,'Pago de venta N° NV-001-00000028','I',1,25.00,'','1',48,1,'2023-07-05 19:44:09',1,NULL,NULL,NULL),(13,NULL,'Pago de venta N° NV-001-00000029','I',1,25.00,'','0',49,1,'2023-07-05 19:47:32',1,NULL,NULL,NULL),(14,NULL,'Pago de venta N° NV-001-00000030','I',1,95.00,'','0',50,1,'2023-07-12 21:09:11',1,NULL,NULL,NULL),(15,NULL,'Pago de venta N° NV-001-00000031','I',1,25.00,'','0',51,1,'2023-07-19 19:21:12',1,NULL,NULL,NULL),(16,NULL,'Pago de venta N° NV-001-00000032','I',1,25.00,'','0',52,1,'2023-07-19 19:30:09',1,NULL,NULL,NULL);
/*!40000 ALTER TABLE `operacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedido`
--

DROP TABLE IF EXISTS `pedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pedido` (
  `idPedido` int(11) NOT NULL AUTO_INCREMENT,
  `Fecha` datetime DEFAULT NULL,
  `Serie` varchar(5) DEFAULT NULL,
  `Numero` int(11) DEFAULT NULL,
  `idproveedor` int(11) DEFAULT NULL,
  `Total` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idPedido`),
  KEY `idprovx_idx` (`idproveedor`),
  CONSTRAINT `idprovx` FOREIGN KEY (`idproveedor`) REFERENCES `proveedor` (`idProveedor`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedido`
--

LOCK TABLES `pedido` WRITE;
/*!40000 ALTER TABLE `pedido` DISABLE KEYS */;
INSERT INTO `pedido` VALUES (8,'2023-06-24 00:00:00','1',12,1,20.00),(9,'2023-06-24 00:00:00','1',12,1,18.00),(10,'2023-06-24 00:00:00','1',12,2,18.00),(11,'2023-06-24 00:00:00','1',12,1,378.00),(12,'2023-06-24 00:00:00','1',12,2,18.00),(13,'2023-06-24 00:00:00','1',12,1,18.00),(14,'2023-06-24 00:00:00','1',12,2,18.00),(15,'2023-06-24 00:00:00','1',12,3,18.00),(16,'2023-06-24 00:00:00','1',12,1,18.00),(17,'2023-06-24 00:00:00','1',12,3,18.00),(18,'2023-06-24 00:00:00','1',12,3,18.00),(19,'2023-06-24 00:00:00','12',11,2,18.00),(20,'2023-06-29 00:00:00','001',123,1,60.00),(21,'2023-07-05 00:00:00','001',878,1,500.00);
/*!40000 ALTER TABLE `pedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permiso`
--

DROP TABLE IF EXISTS `permiso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permiso` (
  `idpermiso` int(11) NOT NULL AUTO_INCREMENT,
  `idnivel` int(11) DEFAULT NULL,
  `permiso_menu` char(1) DEFAULT NULL,
  `idsubmenu` int(11) DEFAULT NULL,
  `idmenu` char(1) DEFAULT NULL,
  `permiso_submenu` char(1) DEFAULT NULL,
  PRIMARY KEY (`idpermiso`),
  KEY `fk_idnivelpermiso` (`idnivel`),
  KEY `fk_idsubmenupermiso` (`idsubmenu`),
  CONSTRAINT `fk_idnivelpermiso` FOREIGN KEY (`idnivel`) REFERENCES `nivelacceso` (`Idnivel`),
  CONSTRAINT `fk_idsubmenupermiso` FOREIGN KEY (`idsubmenu`) REFERENCES `submenu` (`idsubmenu`)
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permiso`
--

LOCK TABLES `permiso` WRITE;
/*!40000 ALTER TABLE `permiso` DISABLE KEYS */;
INSERT INTO `permiso` VALUES (7,2,'1',25,'1','1'),(8,2,'1',26,'1','1'),(9,2,'1',27,'1','1'),(10,2,'1',28,'1','1'),(11,2,'1',29,'1','1'),(12,2,'1',30,'2','1'),(13,2,'1',31,'2','1'),(14,2,'1',32,'3','1'),(15,2,'1',33,'3','1'),(16,2,'1',34,'3','1'),(17,2,'1',35,'3','1'),(18,2,'1',36,'4','1'),(19,2,'1',37,'4','1'),(20,2,'1',38,'5','1'),(21,2,'1',39,'5','1'),(22,2,'1',40,'5','1'),(23,2,'1',41,'5','1'),(24,2,'1',42,'5','1'),(25,2,'1',43,'6','1'),(26,2,'1',44,'6','1'),(27,2,'1',45,'6','1'),(28,2,'1',46,'7','1'),(29,2,'1',47,'7','1'),(30,2,'1',48,'7','1'),(31,2,'1',49,'7','1'),(32,2,'1',50,'8','1'),(33,2,'1',51,'8','1'),(34,2,'1',52,'8','1'),(35,2,'1',53,'8','1'),(36,2,'1',54,'9','1'),(37,2,'1',55,'9','1'),(38,1,'1',25,'1','1'),(39,1,'1',26,'1','1'),(40,1,'1',27,'1','1'),(41,1,'1',28,'1','1'),(42,1,'1',29,'1','1'),(43,1,'1',30,'2','0'),(44,1,'1',31,'2','1'),(45,1,'1',32,'3','0'),(46,1,'1',33,'3','1'),(47,1,'1',34,'3','0'),(48,1,'1',35,'3','0'),(49,1,'1',36,'4','1'),(50,1,'1',37,'4','1'),(51,1,'0',38,'5','0'),(52,1,'0',39,'5','0'),(53,1,'0',40,'5','0'),(54,1,'0',41,'5','0'),(55,1,'0',42,'5','0'),(56,1,'0',43,'6','0'),(57,1,'0',44,'6','0'),(58,1,'0',45,'6','0'),(59,1,'1',46,'7','1'),(60,1,'1',47,'7','1'),(61,1,'1',48,'7','1'),(62,1,'1',49,'7','1'),(63,1,'0',50,'8','0'),(64,1,'0',51,'8','0'),(65,1,'0',52,'8','0'),(66,1,'0',53,'8','0'),(67,1,'0',54,'9','0'),(68,1,'0',55,'9','0');
/*!40000 ALTER TABLE `permiso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto` (
  `Idproducto` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(20) DEFAULT NULL,
  `Descripcion` varchar(100) DEFAULT NULL,
  `Idmarca` int(11) DEFAULT NULL,
  `Idcategoria` int(11) DEFAULT NULL,
  `PrecioCosto` decimal(10,2) DEFAULT NULL,
  `PrecioVenta` decimal(10,2) DEFAULT NULL,
  `FechaVencimiento` date DEFAULT NULL,
  `stock_minimo` int(11) DEFAULT NULL,
  `manejastock` char(1) DEFAULT NULL,
  PRIMARY KEY (`Idproducto`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`),
  KEY `idmarca_idx` (`Idmarca`),
  KEY `idcategoria_idx` (`Idcategoria`),
  CONSTRAINT `idcategoria` FOREIGN KEY (`Idcategoria`) REFERENCES `categoria` (`Idcategoria`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idmarca` FOREIGN KEY (`Idmarca`) REFERENCES `marca` (`Idmarca`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (1,'989897','comida adulto',1,1,15.00,25.00,'2023-06-08',0,'1'),(5,'235464','comida cachorro',5,2,13.00,20.00,'2023-07-21',0,'1'),(6,'656516','Producto 1',1,1,10.00,20.00,'2023-06-30',0,'1'),(7,'866546','Producto 2',2,1,15.00,25.00,'2023-06-30',0,'1'),(8,'121457','Producto 3',1,2,8.00,18.00,'2023-06-30',0,'1'),(9,'754545','Producto 4',3,2,12.00,22.00,'2023-06-30',0,'1'),(10,'656778','Producto 5',2,3,9.00,19.00,'2023-06-30',0,'1'),(11,'565464','Prueba',3,2,12.00,15.00,'2024-07-12',0,'1'),(12,'787878','producto nuevo',1,2,15.00,25.00,'2023-07-04',NULL,'1'),(13,'88888','pollo gritón',1,1,16.00,30.00,'2023-07-05',NULL,'1'),(15,'n2652','producto prueba juev',4,2,12.00,20.00,'2023-07-13',NULL,'1'),(17,'gf5454','prueba jueves trac',4,2,12.00,50.00,'2023-07-13',8,'1'),(18,'656865','prueba de srvicio',1,1,40.00,50.00,NULL,0,'0');
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productovitrina`
--

DROP TABLE IF EXISTS `productovitrina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `productovitrina` (
  `Idproducto` int(11) NOT NULL,
  `Idvitrina` int(11) NOT NULL,
  `Stock` int(11) DEFAULT NULL,
  PRIMARY KEY (`Idproducto`,`Idvitrina`),
  KEY `idvitrina_idx` (`Idvitrina`),
  KEY `idproducto_idx` (`Idproducto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productovitrina`
--

LOCK TABLES `productovitrina` WRITE;
/*!40000 ALTER TABLE `productovitrina` DISABLE KEYS */;
INSERT INTO `productovitrina` VALUES (0,2,0),(1,1,22),(5,2,1),(6,1,10),(7,1,3),(8,2,25),(9,2,7),(10,3,0),(17,2,0);
/*!40000 ALTER TABLE `productovitrina` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proveedor` (
  `idProveedor` int(11) NOT NULL AUTO_INCREMENT,
  `Ruc` char(11) DEFAULT NULL,
  `RazonSocial` varchar(100) DEFAULT NULL,
  `Direccion` varchar(200) DEFAULT NULL,
  `Telefono` varchar(100) DEFAULT NULL,
  `Correo` varchar(100) DEFAULT NULL,
  `Contacto1` int(11) DEFAULT NULL,
  `Contacto2` int(11) DEFAULT NULL,
  `Contacto3` int(11) DEFAULT NULL,
  PRIMARY KEY (`idProveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'20553856451','BI GRAND CONFECCIONES S.A.C.','mmmm','7898546','789456',789456,789456,1478252),(2,'20538856674','ARTROSCOPICTRAUMA S.A.C.','scdsdf','56663','ccccccc',77777,88888,999999),(3,'20480316259','D\'AROMAS E.I.R.L.','xxxxxx','777777','vfvrf@gmail.com',1145236,258963,111111);
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prueba`
--

DROP TABLE IF EXISTS `prueba`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `prueba` (
  `idprueba` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `apellido` varchar(45) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  PRIMARY KEY (`idprueba`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prueba`
--

LOCK TABLES `prueba` WRITE;
/*!40000 ALTER TABLE `prueba` DISABLE KEYS */;
INSERT INTO `prueba` VALUES (1,'elias','sdfddf',NULL),(2,'elias','sdfddf',NULL),(3,'dff','ereewr',NULL),(4,'alberto','sdfddf',NULL),(5,'erwere','weef',NULL),(6,'dsfdf','ewrer',NULL),(7,'alberto','sdfddf',NULL),(8,'alberto','sdfddf',NULL),(9,'alberto','sdfddf',NULL),(10,'adsae','asasd',NULL),(11,'42343','22343',NULL),(12,'alberto','sdfddf',NULL);
/*!40000 ALTER TABLE `prueba` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `receta`
--

DROP TABLE IF EXISTS `receta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `receta` (
  `Idreceta` int(11) NOT NULL AUTO_INCREMENT,
  `Idmascota` int(11) DEFAULT NULL,
  `Fecha` date DEFAULT NULL,
  `Hora` time DEFAULT NULL,
  `Idtrabajador` int(11) DEFAULT NULL,
  `Descripcion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Idreceta`),
  KEY `idmascota_idx` (`Idmascota`),
  CONSTRAINT `idmascotaxx` FOREIGN KEY (`Idmascota`) REFERENCES `mascota` (`idMascota`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `receta`
--

LOCK TABLES `receta` WRITE;
/*!40000 ALTER TABLE `receta` DISABLE KEYS */;
/*!40000 ALTER TABLE `receta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salida`
--

DROP TABLE IF EXISTS `salida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salida` (
  `Idsalida` int(11) NOT NULL AUTO_INCREMENT,
  `Idmovimiento` int(11) DEFAULT NULL,
  `Idproducto` int(11) DEFAULT NULL,
  `Cantidad` int(11) DEFAULT NULL,
  PRIMARY KEY (`Idsalida`),
  KEY `idmov1_idx` (`Idmovimiento`),
  CONSTRAINT `idmov1` FOREIGN KEY (`Idmovimiento`) REFERENCES `movimiento` (`idMovimiento`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salida`
--

LOCK TABLES `salida` WRITE;
/*!40000 ALTER TABLE `salida` DISABLE KEYS */;
INSERT INTO `salida` VALUES (1,1,7,1),(2,1,8,2),(3,2,5,1),(4,2,10,5),(5,3,6,3),(6,3,10,1),(7,4,6,1),(8,4,8,2),(9,5,5,1),(10,5,6,2),(11,6,1,1),(12,6,1,2),(13,7,1,1),(14,8,5,1),(15,26,6,1),(16,27,6,1),(17,28,7,1),(18,29,8,1),(19,30,7,1),(20,31,7,1),(21,33,5,1),(22,34,9,1),(23,35,8,2),(24,36,5,3),(25,37,7,1),(26,38,1,2),(27,39,1,1),(28,40,7,1),(29,42,1,3),(30,42,5,1),(31,43,1,1),(32,44,1,1);
/*!40000 ALTER TABLE `salida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `submenu`
--

DROP TABLE IF EXISTS `submenu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `submenu` (
  `idsubmenu` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `idmenu` int(11) DEFAULT NULL,
  PRIMARY KEY (`idsubmenu`),
  KEY `fk_idsubmenumenu` (`idmenu`),
  CONSTRAINT `fk_idsubmenumenu` FOREIGN KEY (`idmenu`) REFERENCES `menu` (`idmenu`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `submenu`
--

LOCK TABLES `submenu` WRITE;
/*!40000 ALTER TABLE `submenu` DISABLE KEYS */;
INSERT INTO `submenu` VALUES (25,'btnNuevaVenta','Nueva Venta',1),(26,'btnBuscarVenta','Buscar Venta',1),(27,'btnIniciarCaja','Iniciar Caja',1),(28,'btnCerrarCaja','Cerrar Caja',1),(29,'btnMovCaja','Movimiento de caja',1),(30,'btnNuevoCliente','Nuevo Cliente',2),(31,'btnBuscarCliente','Buscar Cliente',2),(32,'btnNuevoProducto','Nuevo Producto',3),(33,'btnBuscarProducto','Buscar Producto',3),(34,'btnMarca','Marcas',3),(35,'btnCategoria','Categorias',3),(36,'btnNuevoComprobante','Nuevo Comprobante',4),(37,'btnBuscarComprobante','Buscar Comprobante',4),(38,'btnRepClientes','Reporte Clientes',5),(39,'btnRepStock','Reporte Stock',5),(40,'btnRepFacturacion','Reporte Facturacion',5),(41,'btnRepVentas','Reporte Ventas',5),(42,'btnRepCaducidad','Reporte Caducidad',5),(43,'btnIngresos','Ingresos',6),(44,'btnSalidas','Salidas',6),(45,'btnStock','Stock',6),(46,'btnFichas','Fichas',7),(47,'btnBuscarFicha','Buscar Ficha',7),(48,'btnCitas','Citas',7),(49,'btnListaCitas','Listado Citas',7),(50,'btnTrabajadores','Trabajadores',8),(51,'btnUsuarios','Usuarios',8),(52,'btnProveedores','Proveedores',8),(53,'btnMedioPago','Nuevo Medio Pago',8),(54,'btnPermisos','Permisos',9),(55,'btnBackup','Copia de seguridad',9);
/*!40000 ALTER TABLE `submenu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipocita`
--

DROP TABLE IF EXISTS `tipocita`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipocita` (
  `Idtipocita` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Idtipocita`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipocita`
--

LOCK TABLES `tipocita` WRITE;
/*!40000 ALTER TABLE `tipocita` DISABLE KEYS */;
INSERT INTO `tipocita` VALUES (1,'Cita Médica'),(2,'Cita Estética'),(14,'Cita Quirúrgica');
/*!40000 ALTER TABLE `tipocita` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipooperacion`
--

DROP TABLE IF EXISTS `tipooperacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipooperacion` (
  `idtipooperacion` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `tipo` char(1) DEFAULT NULL,
  `afectacaja` char(1) DEFAULT NULL,
  `estado` char(1) DEFAULT NULL,
  PRIMARY KEY (`idtipooperacion`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipooperacion`
--

LOCK TABLES `tipooperacion` WRITE;
/*!40000 ALTER TABLE `tipooperacion` DISABLE KEYS */;
INSERT INTO `tipooperacion` VALUES (1,'PAGO DE VENTA','I','S','1'),(2,'TRANSFERENCIA','E','S','1'),(3,'PAGO DE NOTA DE CREDITO','E','S','1'),(4,'DEUDORES/ACREEDORES','I','S','1'),(5,'PAGO A PROVEEDOR','E','S','1'),(6,'COBRO DE CREDITO','I','S','1'),(7,'VALOR POR NOTA DE CREDITO','E','S','1'),(12,'AFP - FONDO DE PENSIONES','E','S','1'),(13,'ALQUILER','E','S','1'),(14,'ACCESORIOS OFICINA','E','S','1'),(15,'CUOTA COMPRA ACTIVO - IMMUEBLES - MAQUINARIAS - OT','E','S','1'),(16,'CANJE DE CHEQUE','E','S','1'),(17,'COMISIONES','E','S','1'),(18,'ARTICULOS DE COMPUTO','E','S','1'),(19,'CUADRE','S','S','1'),(20,'ENVIO DE ENCOMIENDA','E','S','1'),(21,'ESSALUD - SEGURO LABORAL','E','S','1'),(22,'GASTOS MEDICOS','E','S','1'),(23,'GASTO DE REPRESENTACION','E','S','1'),(24,'GASTOS NOTARIALES','E','S','1'),(25,'INGRESOS EN EFECTIVO','I','S','1'),(26,'IGV - IMPUESTO GENERAL A LAS VENTAS','E','S','1'),(27,'IMPRENTA','E','S','1'),(28,'IMPUESTO A LA RENTA','E','S','1'),(29,'INGRESOS VARIOS','I','S','1'),(30,'JUAN - ENVIO DE ENCOMIENDA','E','S','1'),(31,'MENU','E','S','1'),(32,'MOBILIARIO','E','S','1'),(33,'MULTA SUNAT','E','S','1'),(34,'MOVILIDAD','E','S','1'),(35,'NOTA DE DEBITO','I','S','1'),(36,'ONP - PAGO DE FONDO DE PENSIONES','E','S','1'),(37,'OTRO TIPO DE OPERACION','S','S','1'),(38,'DEPOSITO A CTA DE AHORROS','E','S','1'),(39,'CUOTA PRESTAMO BANCARIO','E','S','1'),(40,'DEPOSITO A CTA CORRIENTE','E','S','1'),(41,'PAGO A PROVEEDOR','E','S','1'),(42,'PRESTAMOS A TERCEROS','E','S','1'),(43,'PUBLICIDAD','E','S','1'),(44,'REEMBOLSO','E','S','1'),(45,'REMESA DE EFECTIVO','E','S','1'),(46,'REMUNERACION','E','S','1'),(47,'RECEPCION DE ENCOMIENDA','E','S','1'),(48,'SERVICIOS A CLIENTES','E','S','1'),(49,'SERVICIOS PUBLICOS: TELEFONIA - AGUA - LUZ ','E','S','1'),(50,'SERVICIOS DE TERCEROS','E','S','1'),(51,'TASAS - INTERESES - OTROS CARGOS','E','S','1'),(52,'UTILES DE ASEO','E','S','1'),(53,'UTILES DE OFICINA','E','S','1'),(54,'VIATICOS','E','S','1');
/*!40000 ALTER TABLE `tipooperacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trabajador`
--

DROP TABLE IF EXISTS `trabajador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trabajador` (
  `Idtrabajador` int(11) NOT NULL AUTO_INCREMENT,
  `DNI` varchar(8) DEFAULT NULL,
  `ApellidoPaterno` varchar(50) DEFAULT NULL,
  `ApellidoMaterno` varchar(50) DEFAULT NULL,
  `Nombres` varchar(50) DEFAULT NULL,
  `FechaNacimiento` date DEFAULT NULL,
  `FechaIngreso` date DEFAULT NULL,
  `idcargo` int(11) DEFAULT NULL,
  `FechaCese` date DEFAULT NULL,
  `Direccion` varchar(200) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `Correo` varchar(45) DEFAULT NULL,
  `sexo` char(1) DEFAULT NULL,
  `estado` int(11) DEFAULT NULL,
  PRIMARY KEY (`Idtrabajador`),
  KEY `idcargotrabajador_idx` (`idcargo`),
  CONSTRAINT `idcargotrabajador` FOREIGN KEY (`idcargo`) REFERENCES `Cargo` (`idCargo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trabajador`
--

LOCK TABLES `trabajador` WRITE;
/*!40000 ALTER TABLE `trabajador` DISABLE KEYS */;
INSERT INTO `trabajador` VALUES (1,'85541236','castillo','rodrighuez','jose','2000-01-01','2022-05-10',1,NULL,'casa','333333','','M',1),(2,'74454575','calle','chavez','daniel','2023-05-01','2000-06-11',1,NULL,'casa','938486320','dwdsdwd@gmail.com','M',1),(4,'72640783','SEMINARIO','CHAVEZ','ESTEFANO AUGUSTO','2023-07-05','2023-07-05',1,NULL,'','','dddd','M',1);
/*!40000 ALTER TABLE `trabajador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `Idusuario` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) DEFAULT NULL,
  `Contraseña` varchar(64) DEFAULT NULL,
  `Idtrabajador` int(11) DEFAULT NULL,
  `Idnivelacceso` int(11) DEFAULT NULL,
  `estado` int(11) DEFAULT '1',
  PRIMARY KEY (`Idusuario`),
  KEY `idtrabajador_idx` (`Idtrabajador`),
  KEY `idnivel_idx` (`Idnivelacceso`),
  CONSTRAINT `idnivel` FOREIGN KEY (`Idnivelacceso`) REFERENCES `nivelacceso` (`Idnivel`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idtrabajadorcdds` FOREIGN KEY (`Idtrabajador`) REFERENCES `trabajador` (`Idtrabajador`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (2,'ventas','4hUSMoQ/xe510Mi/wMdL3NrOl7ABp9q2WPeifsyNk/U=',2,1,1),(3,'admin','JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=',1,2,1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta`
--

DROP TABLE IF EXISTS `venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `venta` (
  `Idventa` int(11) NOT NULL AUTO_INCREMENT,
  `Fecha` date DEFAULT NULL,
  `Hora` time DEFAULT NULL,
  `Idcliente` int(11) DEFAULT NULL,
  `Idtrabajador` int(11) DEFAULT NULL,
  `Total` decimal(10,2) DEFAULT NULL,
  `Utilidad` decimal(10,2) DEFAULT NULL,
  `serie` varchar(10) DEFAULT NULL,
  `numero` int(11) DEFAULT NULL,
  `estado` char(1) DEFAULT '1',
  `idcajachica` int(11) DEFAULT NULL,
  `IdUsuarioAnula` int(11) DEFAULT NULL,
  `motivo` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Idventa`),
  KEY `idtrabajador_idx` (`Idtrabajador`),
  KEY `idclienteventa_idx` (`Idcliente`),
  KEY `cajachica_idx` (`idcajachica`),
  KEY `FK_idusuarioanula` (`IdUsuarioAnula`),
  CONSTRAINT `FK_idusuarioanula` FOREIGN KEY (`IdUsuarioAnula`) REFERENCES `usuario` (`Idusuario`),
  CONSTRAINT `cajachica` FOREIGN KEY (`idcajachica`) REFERENCES `cajachica` (`Idcajachica`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idclienteventa` FOREIGN KEY (`Idcliente`) REFERENCES `cliente` (`idCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idtrabajador` FOREIGN KEY (`Idtrabajador`) REFERENCES `trabajador` (`Idtrabajador`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta`
--

LOCK TABLES `venta` WRITE;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
INSERT INTO `venta` VALUES (1,'2023-06-01','10:00:00',1,1,50.00,NULL,NULL,NULL,'1',1,3,'0'),(2,'2023-06-01','11:30:00',2,2,30.00,NULL,NULL,NULL,'1',1,3,'0'),(3,'2023-06-02','09:45:00',1,2,25.00,NULL,NULL,NULL,'1',1,3,'0'),(4,'2023-06-02','13:15:00',3,1,40.00,NULL,NULL,NULL,'1',1,3,'0'),(5,'2023-06-03','12:00:00',2,1,15.00,NULL,NULL,NULL,'1',1,3,'0'),(6,'2023-06-16','12:00:00',4,1,25.00,NULL,NULL,NULL,'1',1,3,'0'),(7,'2023-06-16','12:00:00',4,1,25.00,NULL,NULL,NULL,'1',1,3,'0'),(8,'2023-06-16','12:00:00',4,1,25.00,NULL,NULL,NULL,'1',1,3,'0'),(9,'2023-06-16','00:20:23',4,1,25.00,NULL,NULL,NULL,'1',1,3,'0'),(10,'2023-06-19','18:07:48',7,2,61.00,30.00,'NV-001',1,'1',1,3,'0'),(12,'2023-06-20','00:20:23',1,2,30.00,5.00,'fgfg',8,'1',1,3,'0'),(13,'2023-06-20','00:20:23',2,1,11.00,1.00,'ww',11,'1',1,3,'0'),(14,'2023-06-20','11:06:38',1,2,30.00,5.00,'fgfg',8,'1',1,3,'0'),(15,'2023-06-20','11:07:58',1,2,30.00,5.00,'fgfg',8,'1',1,3,'0'),(16,'2023-06-20','11:08:06',1,2,30.00,5.00,'fgfg',8,'1',1,3,'0'),(18,'2023-06-16','11:08:06',2,1,33.00,2.00,'232',2,'1',1,3,'0'),(19,'2023-06-20','12:23:35',1,2,30.00,5.00,'fgfg',8,'1',1,3,'0'),(20,'2023-06-16','11:08:06',2,2,25.00,1.00,NULL,8,'1',1,3,'0'),(21,'2023-06-20','12:27:11',1,2,30.00,5.00,'fgfg',8,'1',1,3,'0'),(22,'2023-06-20','12:27:36',1,2,30.00,5.00,'fgfg',8,'1',1,3,'0'),(23,'2023-06-20','12:28:47',1,2,30.00,5.00,'fgfg',8,'1',1,3,'0'),(24,'2023-06-20','12:32:23',1,2,30.00,5.00,'fgfg',8,'1',1,3,'0'),(25,'2023-06-20','12:35:57',2,1,115.00,57.00,'NV-001',9,'1',1,3,'0'),(26,'2023-06-20','12:39:04',4,2,79.00,40.00,'NV-001',10,'1',1,3,'0'),(27,'2023-06-20','15:58:29',7,1,56.00,30.00,'NV-001',11,'1',1,3,'0'),(28,'2023-06-20','17:41:24',8,1,60.00,27.00,'NV-001',12,'1',1,3,'0'),(29,'2023-06-21','19:04:04',7,2,75.00,30.00,'NV-001',13,'1',1,3,'0'),(30,'2023-06-21','19:07:56',3,1,25.00,10.00,'NV-001',14,'1',1,3,'0'),(31,'2023-06-21','19:56:35',3,1,20.00,7.00,'NV-001',15,'1',1,3,'0'),(32,'2023-06-25','18:26:34',7,1,20.00,10.00,'NV-001',16,'1',1,3,'0'),(33,'2023-06-25','18:28:22',7,2,20.00,10.00,'NV-001',17,'1',1,3,'0'),(34,'2023-06-25','18:29:48',2,2,25.00,10.00,'NV-001',18,'1',1,3,'0'),(35,'2023-06-27','23:19:03',3,1,18.00,10.00,'NV-001',19,'1',1,3,'0'),(39,'2023-06-28','18:57:59',9,1,25.00,10.00,'NV-001',20,'1',1,3,'0'),(40,'2023-06-28','19:02:23',11,1,25.00,10.00,'NV-001',21,'1',1,3,'0'),(41,'2023-06-29','19:56:59',2,1,20.00,7.00,'NV-001',22,'1',1,3,'0'),(42,'2023-06-29','20:33:24',3,2,22.00,10.00,'NV-001',23,'1',1,3,'0'),(43,'2023-06-29','22:54:28',10,1,36.00,20.00,'NV-001',24,'1',1,3,'0'),(44,'2023-06-29','22:56:57',1,1,60.00,21.00,'NV-001',25,'1',1,3,'0'),(46,'2023-07-04','22:46:56',15,1,25.00,10.00,'NV-001',26,'1',1,3,'0'),(47,'2023-07-05','19:39:10',19,1,50.00,20.00,'NV-001',27,'0',1,3,'no quiso llevar producto'),(48,'2023-07-05','19:43:40',19,1,25.00,10.00,'NV-001',28,'1',1,3,'0'),(49,'2023-07-05','19:47:16',19,1,25.00,10.00,'NV-001',29,'0',1,3,'0'),(50,'2023-07-12','21:08:53',19,2,95.00,37.00,'NV-001',30,'0',1,3,'cambio de productos'),(51,'2023-07-19','19:20:49',7,4,25.00,10.00,'NV-001',31,'0',1,3,'devolucion'),(52,'2023-07-19','19:29:59',19,4,25.00,10.00,'NV-001',32,'0',1,3,'producto defectuoso');
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vitrina`
--

DROP TABLE IF EXISTS `vitrina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vitrina` (
  `idVitrina` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idVitrina`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vitrina`
--

LOCK TABLES `vitrina` WRITE;
/*!40000 ALTER TABLE `vitrina` DISABLE KEYS */;
INSERT INTO `vitrina` VALUES (1,'vitrina 1'),(2,'mueble'),(3,'estante');
/*!40000 ALTER TABLE `vitrina` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-26 11:42:46
