/*
Navicat MySQL Data Transfer

Source Server         : greenv
Source Server Version : 50720
Source Host           : localhost:3306
Source Database       : greenv

Target Server Type    : MYSQL
Target Server Version : 50720
File Encoding         : 65001

Date: 2017-12-09 15:25:48
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `app_groundtruthdata`
-- ----------------------------
DROP TABLE IF EXISTS `app_groundtruthdata`;
CREATE TABLE `app_groundtruthdata` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `device` varchar(255) DEFAULT NULL,
  `timestamp` varchar(255) DEFAULT NULL,
  `leftright` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_groundtruthdata
-- ----------------------------

-- ----------------------------
-- Table structure for `app_sensordata`
-- ----------------------------
DROP TABLE IF EXISTS `app_sensordata`;
CREATE TABLE `app_sensordata` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `device` varchar(255) DEFAULT NULL,
  `timestamps` bigint(11) DEFAULT NULL,
  `timestampms` bigint(20) DEFAULT NULL,
  `sensorvalue` blob,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_sensordata
-- ----------------------------
