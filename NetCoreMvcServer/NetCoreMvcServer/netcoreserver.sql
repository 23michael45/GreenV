/*
Navicat MySQL Data Transfer

Source Server         : Root
Source Server Version : 50720
Source Host           : localhost:3306
Source Database       : netcoreserver

Target Server Type    : MYSQL
Target Server Version : 50720
File Encoding         : 65001

Date: 2019-04-25 20:54:29
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `app_groundtruthdata`
-- ----------------------------
DROP TABLE IF EXISTS `app_groundtruthdata`;
CREATE TABLE `app_groundtruthdata` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `createtime` datetime(6) NOT NULL,
  `device` longtext,
  `leftright` tinyint(3) unsigned NOT NULL,
  `nodeindex` tinyint(3) unsigned NOT NULL,
  `timestamp` int(11) NOT NULL,
  `timestampms` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_groundtruthdata
-- ----------------------------

-- ----------------------------
-- Table structure for `app_sensordata`
-- ----------------------------
DROP TABLE IF EXISTS `app_sensordata`;
CREATE TABLE `app_sensordata` (
  `Id` char(36) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `device` longtext,
  `gain` smallint(6) NOT NULL,
  `rate` smallint(6) NOT NULL,
  `sensorvalue` longblob,
  `timestampms` int(11) NOT NULL,
  `timestamps` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_sensordata
-- ----------------------------

-- ----------------------------
-- Table structure for `departments`
-- ----------------------------
DROP TABLE IF EXISTS `departments`;
CREATE TABLE `departments` (
  `Id` char(36) NOT NULL,
  `Code` longtext,
  `ContactNumber` longtext,
  `CreateTime` datetime(6) DEFAULT NULL,
  `CreateUserId` char(36) NOT NULL,
  `IsDeleted` int(11) NOT NULL,
  `Manager` longtext,
  `Name` longtext,
  `ParentId` char(36) NOT NULL,
  `Remarks` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of departments
-- ----------------------------
INSERT INTO `departments` VALUES ('34d52a59-0f17-44be-8cde-e075bebdfaff', null, null, null, '00000000-0000-0000-0000-000000000000', '0', null, 'C320F1', '00000000-0000-0000-0000-000000000000', null);
INSERT INTO `departments` VALUES ('8ed4ed6c-ee71-4fe1-a0f4-26cb606ad9c6', null, null, null, '00000000-0000-0000-0000-000000000000', '0', null, 'C215F1', '00000000-0000-0000-0000-000000000000', null);
INSERT INTO `departments` VALUES ('eda07696-d873-4a5d-b6bc-0402207ac1a2', null, null, null, '00000000-0000-0000-0000-000000000000', '0', null, 'C321F1', '00000000-0000-0000-0000-000000000000', null);

-- ----------------------------
-- Table structure for `groundtruths`
-- ----------------------------
DROP TABLE IF EXISTS `groundtruths`;
CREATE TABLE `groundtruths` (
  `Id` char(36) NOT NULL,
  `DepartmentId` char(36) NOT NULL,
  `desc` longtext,
  `ip` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of groundtruths
-- ----------------------------
INSERT INTO `groundtruths` VALUES ('e36461ca-56cb-4d1a-9e0d-0a64f5d3f72d', '34d52a59-0f17-44be-8cde-e075bebdfaff', null, '192.168.1.12');

-- ----------------------------
-- Table structure for `menus`
-- ----------------------------
DROP TABLE IF EXISTS `menus`;
CREATE TABLE `menus` (
  `Id` char(36) NOT NULL,
  `Code` longtext,
  `Icon` longtext,
  `Name` longtext,
  `ParentId` char(36) NOT NULL,
  `Remarks` longtext,
  `SerialNumber` int(11) NOT NULL,
  `Type` int(11) NOT NULL,
  `Url` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of menus
-- ----------------------------
INSERT INTO `menus` VALUES ('08d6c4c0-777e-c984-4657-93b241a8f265', 'Home', 'fa fa-link', 'Share_HomePage', '00000000-0000-0000-0000-000000000000', null, '0', '0', 'Home/Index');
INSERT INTO `menus` VALUES ('08d6c4c0-777f-6685-8f7b-45483300ffa1', 'Terminal', 'fa fa-link', 'Share_TerminalControl', '00000000-0000-0000-0000-000000000000', null, '1', '0', 'Terminal/Index');
INSERT INTO `menus` VALUES ('08d6c4c0-777f-68e4-4e3d-876a62e86d2b', 'GroundTruth', 'fa fa-link', 'Share_GroundTruthControl', '00000000-0000-0000-0000-000000000000', null, '2', '0', 'GroundTruth/Index');
INSERT INTO `menus` VALUES ('08d6c4c0-777f-698e-b0f5-15a1266c25ec', 'App_SensorData', 'fa fa-link', 'Share_SensorData', '00000000-0000-0000-0000-000000000000', null, '3', '0', 'App_SensorData/Index');
INSERT INTO `menus` VALUES ('08d6c4c0-777f-6b3f-ee93-6b037685cf51', 'User', 'fa fa-link', 'Share_User_Manage', '00000000-0000-0000-0000-000000000000', null, '6', '0', 'User/Index');
INSERT INTO `menus` VALUES ('08d6c4c0-777f-6bd6-837e-cd3d8bba1102', 'Department', 'fa fa-link', 'Share_Department_Manage', '00000000-0000-0000-0000-000000000000', null, '7', '0', 'Department/Index');

-- ----------------------------
-- Table structure for `roles`
-- ----------------------------
DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles` (
  `Id` char(36) NOT NULL,
  `Code` longtext,
  `CreateTime` datetime(6) DEFAULT NULL,
  `CreateUserId` char(36) NOT NULL,
  `Name` longtext,
  `Remarks` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of roles
-- ----------------------------
INSERT INTO `roles` VALUES ('08d6c4c0-777f-93a2-3151-928582b6d51a', 'Share_Administrator', null, '00000000-0000-0000-0000-000000000000', 'Share_Administrator', 'Share_Administrator');
INSERT INTO `roles` VALUES ('08d6c4c0-7780-5b3b-6d1c-b1b4551a5f28', 'Share_CommonUser', null, '00000000-0000-0000-0000-000000000000', 'Share_CommonUser', 'Share_CommonUser');

-- ----------------------------
-- Table structure for `terminals`
-- ----------------------------
DROP TABLE IF EXISTS `terminals`;
CREATE TABLE `terminals` (
  `Id` char(36) NOT NULL,
  `DepartmentId` char(36) NOT NULL,
  `PositionX` int(11) NOT NULL,
  `PositionY` int(11) NOT NULL,
  `desc` longtext,
  `ip` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of terminals
-- ----------------------------
INSERT INTO `terminals` VALUES ('08d6c4c0-7780-8aea-240a-76812891e497', '8ed4ed6c-ee71-4fe1-a0f4-26cb606ad9c6', '608', '608', 'Terminal:0 in Department:8ed4ed6c-ee71-4fe1-a0f4-26cb606ad9c6', '192.168.31.1');
INSERT INTO `terminals` VALUES ('08d6c4c0-7781-33c9-2c8e-a350a97938eb', '34d52a59-0f17-44be-8cde-e075bebdfaff', '274', '274', 'Terminal:1 in Department:34d52a59-0f17-44be-8cde-e075bebdfaff', '192.168.31.2');
INSERT INTO `terminals` VALUES ('08d6c4c0-7781-35e1-351a-671e558be258', 'eda07696-d873-4a5d-b6bc-0402207ac1a2', '639', '671', 'Terminal:2 in Department:eda07696-d873-4a5d-b6bc-0402207ac1a2', '192.168.31.3');
INSERT INTO `terminals` VALUES ('40fce841-04fa-43d9-877d-45a6780c2f50', '34d52a59-0f17-44be-8cde-e075bebdfaff', '0', '0', null, '192.168.1.72');
INSERT INTO `terminals` VALUES ('9bbc1c52-a3fc-42b7-8a4c-7109f99cac22', '34d52a59-0f17-44be-8cde-e075bebdfaff', '0', '0', null, '192.168.1.2');
INSERT INTO `terminals` VALUES ('a640988d-b160-4574-8eba-812f7f2edfbf', '34d52a59-0f17-44be-8cde-e075bebdfaff', '1', '1', '1', '192.168.1.183');

-- ----------------------------
-- Table structure for `userroles`
-- ----------------------------
DROP TABLE IF EXISTS `userroles`;
CREATE TABLE `userroles` (
  `UserId` char(36) NOT NULL,
  `RoleId` char(36) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_UserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_UserRoles_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UserRoles_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userroles
-- ----------------------------

-- ----------------------------
-- Table structure for `users`
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `Id` char(36) NOT NULL,
  `CreateTime` datetime(6) DEFAULT NULL,
  `CreateUserId` char(36) NOT NULL,
  `EMail` longtext,
  `IsDeleted` int(11) NOT NULL,
  `LastLoginTime` datetime(6) NOT NULL,
  `LoginTimes` int(11) NOT NULL,
  `MobileNumber` longtext,
  `Name` longtext,
  `Password` longtext,
  `Remarks` longtext,
  `UserName` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('08d6c4c0-777b-be17-9635-c3b515ec2c9c', null, '00000000-0000-0000-0000-000000000000', null, '0', '0001-01-01 00:00:00.000000', '0', null, 'super admin', 'admin', null, 'admin');

-- ----------------------------
-- Table structure for `__efmigrationshistory`
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20190419101257_InitialCreate', '2.0.1-rtm-125');
