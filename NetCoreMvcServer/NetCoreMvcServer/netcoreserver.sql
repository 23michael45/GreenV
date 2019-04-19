/*
Navicat MySQL Data Transfer

Source Server         : Root
Source Server Version : 50720
Source Host           : localhost:3306
Source Database       : netcoreserver

Target Server Type    : MYSQL
Target Server Version : 50720
File Encoding         : 65001

Date: 2019-04-19 22:57:08
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
) ENGINE=InnoDB AUTO_INCREMENT=1356 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_groundtruthdata
-- ----------------------------
INSERT INTO `app_groundtruthdata` VALUES ('1', '2019-04-19 20:54:55.975513', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('2', '2019-04-19 20:55:02.009222', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('3', '2019-04-19 20:55:04.009128', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('4', '2019-04-19 20:55:06.011072', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('5', '2019-04-19 20:55:58.356059', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('6', '2019-04-19 20:56:00.007477', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('7', '2019-04-19 20:56:02.020990', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('8', '2019-04-19 20:56:04.027145', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('9', '2019-04-19 20:56:06.132989', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('10', '2019-04-19 20:56:07.967848', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('11', '2019-04-19 20:56:09.969567', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('12', '2019-04-19 20:56:11.968811', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('13', '2019-04-19 20:56:13.969258', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('14', '2019-04-19 20:56:15.970562', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('15', '2019-04-19 20:56:17.971254', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('16', '2019-04-19 20:56:19.971729', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('17', '2019-04-19 20:56:55.024882', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('18', '2019-04-19 20:56:58.755128', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('19', '2019-04-19 20:56:59.063709', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('20', '2019-04-19 20:56:59.342442', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('21', '2019-04-19 20:56:59.623591', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('22', '2019-04-19 20:56:59.837170', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('23', '2019-04-19 20:57:00.099716', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('24', '2019-04-19 20:57:00.369162', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('25', '2019-04-19 20:57:00.700767', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('26', '2019-04-19 20:57:28.725175', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('27', '2019-04-19 20:57:32.838200', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('28', '2019-04-19 20:57:33.192326', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('29', '2019-04-19 20:57:33.242284', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('30', '2019-04-19 20:57:33.326265', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('31', '2019-04-19 20:57:33.477760', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('32', '2019-04-19 20:57:33.699278', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('33', '2019-04-19 20:57:34.003146', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('34', '2019-04-19 20:57:34.302461', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('35', '2019-04-19 20:57:34.655547', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('36', '2019-04-19 20:57:35.640881', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('37', '2019-04-19 20:57:36.081783', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('38', '2019-04-19 20:57:36.365912', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('39', '2019-04-19 20:57:36.659250', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('40', '2019-04-19 20:57:36.903615', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('41', '2019-04-19 20:57:37.232979', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('42', '2019-04-19 20:57:37.349496', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('43', '2019-04-19 20:57:37.658494', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('44', '2019-04-19 20:57:38.033534', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('45', '2019-04-19 20:57:38.082932', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('46', '2019-04-19 20:57:38.087660', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('47', '2019-04-19 20:57:38.305431', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('48', '2019-04-19 20:57:38.478642', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('49', '2019-04-19 20:57:38.681064', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('50', '2019-04-19 20:57:38.914546', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('51', '2019-04-19 20:57:39.446762', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('52', '2019-04-19 20:57:39.672027', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('53', '2019-04-19 20:57:41.020122', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('54', '2019-04-19 20:57:42.028639', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('55', '2019-04-19 20:57:43.398595', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('56', '2019-04-19 20:57:45.156581', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('57', '2019-04-19 20:57:45.659856', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('58', '2019-04-19 20:57:46.160480', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('59', '2019-04-19 20:57:46.712546', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('60', '2019-04-19 20:57:48.239473', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('61', '2019-04-19 20:57:50.114613', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('62', '2019-04-19 20:57:52.070484', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('63', '2019-04-19 20:57:54.059889', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('64', '2019-04-19 20:57:56.041081', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('65', '2019-04-19 20:57:58.016862', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('66', '2019-04-19 20:58:00.017987', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('67', '2019-04-19 20:58:02.061541', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('68', '2019-04-19 20:58:04.058733', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('69', '2019-04-19 20:58:06.121629', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('70', '2019-04-19 20:58:08.053357', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('71', '2019-04-19 20:58:10.030797', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('72', '2019-04-19 20:58:12.037706', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('73', '2019-04-19 20:58:14.056408', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('74', '2019-04-19 20:58:16.045179', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('75', '2019-04-19 20:58:18.036296', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('76', '2019-04-19 20:58:20.065184', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('77', '2019-04-19 20:58:22.106226', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('78', '2019-04-19 20:58:24.053088', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('79', '2019-04-19 20:58:26.054303', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('80', '2019-04-19 20:58:28.049641', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('81', '2019-04-19 20:58:30.063119', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('82', '2019-04-19 20:58:32.061478', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('83', '2019-04-19 20:58:34.091903', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('84', '2019-04-19 20:58:36.047134', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('85', '2019-04-19 20:58:38.054130', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('86', '2019-04-19 20:58:40.082645', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('87', '2019-04-19 20:58:42.104258', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('88', '2019-04-19 20:58:44.066074', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('89', '2019-04-19 20:58:47.356861', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('90', '2019-04-19 20:58:52.738290', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('91', '2019-04-19 20:58:52.743013', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('92', '2019-04-19 20:58:52.770327', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('93', '2019-04-19 20:58:54.084164', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('94', '2019-04-19 20:58:56.064012', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('95', '2019-04-19 20:58:58.078192', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('96', '2019-04-19 20:59:00.095258', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('97', '2019-04-19 20:59:02.057808', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('98', '2019-04-19 20:59:04.063530', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('99', '2019-04-19 20:59:06.064193', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('100', '2019-04-19 20:59:08.086362', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('101', '2019-04-19 20:59:10.036248', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('102', '2019-04-19 20:59:12.037231', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('103', '2019-04-19 20:59:14.037290', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('104', '2019-04-19 20:59:48.227018', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('105', '2019-04-19 20:59:51.309249', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('106', '2019-04-19 20:59:51.359757', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('107', '2019-04-19 20:59:51.366906', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('108', '2019-04-19 20:59:51.394203', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('109', '2019-04-19 20:59:51.442058', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('110', '2019-04-19 20:59:51.472580', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('111', '2019-04-19 20:59:51.501281', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('112', '2019-04-19 20:59:51.529121', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('113', '2019-04-19 20:59:51.559648', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('114', '2019-04-19 20:59:51.589152', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('115', '2019-04-19 20:59:51.617265', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('116', '2019-04-19 20:59:51.690125', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('117', '2019-04-19 20:59:51.740838', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('118', '2019-04-19 20:59:51.839004', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('119', '2019-04-19 20:59:51.911194', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('120', '2019-04-19 20:59:52.027323', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('121', '2019-04-19 20:59:52.123324', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('122', '2019-04-19 20:59:52.425889', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('123', '2019-04-19 20:59:54.080433', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('124', '2019-04-19 20:59:56.113908', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('125', '2019-04-19 20:59:58.090138', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('126', '2019-04-19 21:00:00.064554', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('127', '2019-04-19 21:00:02.070835', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('128', '2019-04-19 21:00:04.056556', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('129', '2019-04-19 21:00:06.060734', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('130', '2019-04-19 21:00:11.809773', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('131', '2019-04-19 21:00:12.536075', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('132', '2019-04-19 21:00:12.577731', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('133', '2019-04-19 21:00:15.680130', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('134', '2019-04-19 21:00:16.066314', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('135', '2019-04-19 21:00:18.066789', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('136', '2019-04-19 21:00:20.067228', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('137', '2019-04-19 21:00:22.067972', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('138', '2019-04-19 21:00:24.068672', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('139', '2019-04-19 21:00:26.069459', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('140', '2019-04-19 21:00:48.314135', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('141', '2019-04-19 21:00:51.182687', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('142', '2019-04-19 21:00:52.609630', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('143', '2019-04-19 21:00:53.739224', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('144', '2019-04-19 21:01:19.795395', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('145', '2019-04-19 21:01:20.306406', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('146', '2019-04-19 21:01:23.368714', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('147', '2019-04-19 21:01:24.334462', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('148', '2019-04-19 21:01:25.206038', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('149', '2019-04-19 21:01:25.258502', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('150', '2019-04-19 21:01:25.336693', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('151', '2019-04-19 21:01:25.437108', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('152', '2019-04-19 21:01:25.443209', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('153', '2019-04-19 21:01:25.682475', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('154', '2019-04-19 21:01:25.710487', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('155', '2019-04-19 21:01:25.783828', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('156', '2019-04-19 21:01:25.813688', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('157', '2019-04-19 21:01:25.888307', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('158', '2019-04-19 21:01:25.944126', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('159', '2019-04-19 21:01:26.061622', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('160', '2019-04-19 21:01:26.142374', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('161', '2019-04-19 21:01:26.171919', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('162', '2019-04-19 21:01:26.204009', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('163', '2019-04-19 21:01:26.232817', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('164', '2019-04-19 21:01:26.264419', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('165', '2019-04-19 21:01:26.273706', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('166', '2019-04-19 21:01:26.282085', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('167', '2019-04-19 21:01:26.287954', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('168', '2019-04-19 21:01:26.296289', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('169', '2019-04-19 21:01:26.321810', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('170', '2019-04-19 21:01:28.150494', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('171', '2019-04-19 21:01:30.150618', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('172', '2019-04-19 21:01:32.119891', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('173', '2019-04-19 21:01:48.117295', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('174', '2019-04-19 21:01:48.121803', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('175', '2019-04-19 21:01:48.126479', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('176', '2019-04-19 21:01:48.130975', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('177', '2019-04-19 21:01:48.135362', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('178', '2019-04-19 21:01:53.172775', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('179', '2019-04-19 21:01:53.177258', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('180', '2019-04-19 21:01:53.181902', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('181', '2019-04-19 21:01:53.206746', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('182', '2019-04-19 21:01:53.213642', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('183', '2019-04-19 21:01:54.205528', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('184', '2019-04-19 21:01:56.110659', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('185', '2019-04-19 21:01:58.189707', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('186', '2019-04-19 21:02:00.199969', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('187', '2019-04-19 21:02:02.114901', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('188', '2019-04-19 21:02:04.139848', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('189', '2019-04-19 21:02:06.178228', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('190', '2019-04-19 21:02:08.137571', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('191', '2019-04-19 21:02:10.156917', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('192', '2019-04-19 21:02:12.128950', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('193', '2019-04-19 21:02:14.122177', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('194', '2019-04-19 21:02:16.137615', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('195', '2019-04-19 21:02:18.124692', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('196', '2019-04-19 21:02:20.169829', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('197', '2019-04-19 21:02:22.157276', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('198', '2019-04-19 21:02:24.176644', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('199', '2019-04-19 21:02:26.129425', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('200', '2019-04-19 21:02:28.132838', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('201', '2019-04-19 21:02:30.155829', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('202', '2019-04-19 21:02:32.132120', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('203', '2019-04-19 21:02:34.153002', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('204', '2019-04-19 21:02:36.139674', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('205', '2019-04-19 21:02:38.147598', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('206', '2019-04-19 21:02:43.239004', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('207', '2019-04-19 21:02:43.293729', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('208', '2019-04-19 21:02:44.138964', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('209', '2019-04-19 21:02:46.171686', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('210', '2019-04-19 21:02:48.184972', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('211', '2019-04-19 21:02:50.207154', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('212', '2019-04-19 21:02:52.197312', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('213', '2019-04-19 21:02:54.202093', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('214', '2019-04-19 21:02:56.193307', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('215', '2019-04-19 21:02:58.149365', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('216', '2019-04-19 21:03:00.147792', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('217', '2019-04-19 21:03:02.178173', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('218', '2019-04-19 21:03:04.154688', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('219', '2019-04-19 21:03:06.180173', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('220', '2019-04-19 21:03:08.188317', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('221', '2019-04-19 21:03:10.179864', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('222', '2019-04-19 21:03:12.215339', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('223', '2019-04-19 21:03:14.190314', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('224', '2019-04-19 21:03:16.178940', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('225', '2019-04-19 21:03:18.169074', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('226', '2019-04-19 21:03:20.186319', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('227', '2019-04-19 21:03:22.215181', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('228', '2019-04-19 21:03:24.199572', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('229', '2019-04-19 21:03:26.227495', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('230', '2019-04-19 21:03:28.211327', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('231', '2019-04-19 21:03:30.188012', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('232', '2019-04-19 21:03:32.193063', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('233', '2019-04-19 21:03:34.196818', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('234', '2019-04-19 21:03:36.254879', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('235', '2019-04-19 21:03:38.210821', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('236', '2019-04-19 21:03:40.210884', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('237', '2019-04-19 21:03:42.197928', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('238', '2019-04-19 21:03:45.382457', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('239', '2019-04-19 21:03:46.174470', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('240', '2019-04-19 21:03:48.184395', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('241', '2019-04-19 21:03:50.211753', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('242', '2019-04-19 21:03:52.175461', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('243', '2019-04-19 21:03:54.217090', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('244', '2019-04-19 21:03:56.216638', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('245', '2019-04-19 21:03:58.210623', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('246', '2019-04-19 21:04:00.188505', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('247', '2019-04-19 21:04:02.199903', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('248', '2019-04-19 21:04:04.209224', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('249', '2019-04-19 21:04:06.210987', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('250', '2019-04-19 21:04:08.189328', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('251', '2019-04-19 21:04:10.243082', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('252', '2019-04-19 21:04:12.250756', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('253', '2019-04-19 21:04:14.243979', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('254', '2019-04-19 21:04:16.220563', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('255', '2019-04-19 21:04:18.210774', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('256', '2019-04-19 21:04:20.205391', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('257', '2019-04-19 21:04:22.235524', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('258', '2019-04-19 21:04:24.272269', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('259', '2019-04-19 21:04:58.257750', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('260', '2019-04-19 21:05:00.407045', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('261', '2019-04-19 21:05:02.459026', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('262', '2019-04-19 21:05:04.457267', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('263', '2019-04-19 21:05:06.436792', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('264', '2019-04-19 21:05:08.537431', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('265', '2019-04-19 21:05:10.236107', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('266', '2019-04-19 21:05:12.468855', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('267', '2019-04-19 21:05:14.529844', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('268', '2019-04-19 21:05:16.410735', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('269', '2019-04-19 21:05:18.280024', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('270', '2019-04-19 21:05:20.491787', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('271', '2019-04-19 21:05:24.285755', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('272', '2019-04-19 21:05:26.268907', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('273', '2019-04-19 21:05:28.703000', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('274', '2019-04-19 21:05:30.584291', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('275', '2019-04-19 21:05:32.653288', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('276', '2019-04-19 21:05:34.647379', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('277', '2019-04-19 21:05:36.529175', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('278', '2019-04-19 21:05:38.456688', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('279', '2019-04-19 21:05:40.397399', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('280', '2019-04-19 21:05:42.532762', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('281', '2019-04-19 21:05:44.452238', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('282', '2019-04-19 21:05:46.612448', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('283', '2019-04-19 21:05:48.530230', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('284', '2019-04-19 21:05:50.459288', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('285', '2019-04-19 21:05:52.549403', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('286', '2019-04-19 21:05:54.361699', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('287', '2019-04-19 21:05:56.441117', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('288', '2019-04-19 21:05:58.315450', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('289', '2019-04-19 21:06:30.935284', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('290', '2019-04-19 21:06:38.627886', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('291', '2019-04-19 21:06:44.654719', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('292', '2019-04-19 21:06:46.630555', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('293', '2019-04-19 21:06:48.740250', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('294', '2019-04-19 21:06:50.631458', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('295', '2019-04-19 21:06:52.632233', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('296', '2019-04-19 21:07:06.737881', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('297', '2019-04-19 21:07:12.765063', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('298', '2019-04-19 21:07:14.763274', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('299', '2019-04-19 21:07:20.789989', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('300', '2019-04-19 21:07:26.830215', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('301', '2019-04-19 21:07:28.808136', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('302', '2019-04-19 21:07:30.811843', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('303', '2019-04-19 21:07:32.816277', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('304', '2019-04-19 21:07:34.817237', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('305', '2019-04-19 21:07:36.812931', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('306', '2019-04-19 21:07:38.820136', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('307', '2019-04-19 21:07:40.815064', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('308', '2019-04-19 21:07:42.817062', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('309', '2019-04-19 21:07:44.822027', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('310', '2019-04-19 21:07:46.817268', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('311', '2019-04-19 21:07:48.825966', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('312', '2019-04-19 21:07:50.819638', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('313', '2019-04-19 21:07:52.826612', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('314', '2019-04-19 21:07:54.825579', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('315', '2019-04-19 21:07:56.822784', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('316', '2019-04-19 21:07:58.831601', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('317', '2019-04-19 21:08:00.825074', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('318', '2019-04-19 21:08:02.826403', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('319', '2019-04-19 21:08:04.826130', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('320', '2019-04-19 21:08:06.835957', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('321', '2019-04-19 21:08:08.829026', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('322', '2019-04-19 21:08:10.835437', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('323', '2019-04-19 21:08:12.837213', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('324', '2019-04-19 21:08:14.832270', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('325', '2019-04-19 21:08:16.843766', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('326', '2019-04-19 21:08:18.840551', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('327', '2019-04-19 21:08:20.837475', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('328', '2019-04-19 21:08:22.836972', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('329', '2019-04-19 21:08:24.840556', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('330', '2019-04-19 21:08:26.844703', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('331', '2019-04-19 21:08:28.841552', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('332', '2019-04-19 21:08:30.842545', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('333', '2019-04-19 21:08:32.848095', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('334', '2019-04-19 21:08:34.843348', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('335', '2019-04-19 21:08:36.844811', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('336', '2019-04-19 21:08:38.850993', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('337', '2019-04-19 21:08:44.903297', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('338', '2019-04-19 21:08:46.882136', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('339', '2019-04-19 21:08:48.882459', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('340', '2019-04-19 21:08:50.883143', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('341', '2019-04-19 21:08:52.883600', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('342', '2019-04-19 21:08:54.891735', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('343', '2019-04-19 21:09:02.954424', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('344', '2019-04-19 21:09:04.935597', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('345', '2019-04-19 21:09:06.937590', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('346', '2019-04-19 21:10:28.166128', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('347', '2019-04-19 21:10:28.337825', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('348', '2019-04-19 21:10:28.348515', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('349', '2019-04-19 21:10:28.353378', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('350', '2019-04-19 21:10:28.358561', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('351', '2019-04-19 21:10:28.363977', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('352', '2019-04-19 21:10:28.393862', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('353', '2019-04-19 21:10:28.399925', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('354', '2019-04-19 21:10:28.405573', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('355', '2019-04-19 21:10:29.368667', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('356', '2019-04-19 21:10:39.708890', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('357', '2019-04-19 21:10:39.813294', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('358', '2019-04-19 21:10:39.916431', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('359', '2019-04-19 21:10:39.993361', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('360', '2019-04-19 21:10:40.188287', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('361', '2019-04-19 21:10:41.450994', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('362', '2019-04-19 21:10:43.490861', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('363', '2019-04-19 21:10:45.419304', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('364', '2019-04-19 21:10:47.387290', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('365', '2019-04-19 21:10:49.405722', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('366', '2019-04-19 21:10:51.425248', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('367', '2019-04-19 21:10:53.447025', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('368', '2019-04-19 21:10:55.417404', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('369', '2019-04-19 21:10:57.408858', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('370', '2019-04-19 21:10:59.416080', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('371', '2019-04-19 21:11:01.434467', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('372', '2019-04-19 21:11:03.384325', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('373', '2019-04-19 21:11:05.425248', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('374', '2019-04-19 21:11:07.451931', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('375', '2019-04-19 21:11:09.420854', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('376', '2019-04-19 21:11:11.404246', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('377', '2019-04-19 21:11:13.440378', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('378', '2019-04-19 21:11:19.460432', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('379', '2019-04-19 21:11:21.757889', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('380', '2019-04-19 21:11:23.438243', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('381', '2019-04-19 21:11:25.438940', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('382', '2019-04-19 21:11:27.446243', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('383', '2019-04-19 21:11:29.447889', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('384', '2019-04-19 21:11:31.449652', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('385', '2019-04-19 21:11:33.445538', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('386', '2019-04-19 21:11:35.445206', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('387', '2019-04-19 21:11:37.446617', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('388', '2019-04-19 21:11:39.446641', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('389', '2019-04-19 21:11:41.451644', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('390', '2019-04-19 21:11:43.450471', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('391', '2019-04-19 21:11:47.488117', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('392', '2019-04-19 21:11:49.469385', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('393', '2019-04-19 21:12:13.109363', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('394', '2019-04-19 21:12:25.620479', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('395', '2019-04-19 21:12:25.671928', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('396', '2019-04-19 21:12:25.888460', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('397', '2019-04-19 21:12:26.036665', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('398', '2019-04-19 21:12:26.186752', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('399', '2019-04-19 21:12:26.337092', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('400', '2019-04-19 21:12:26.608406', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('401', '2019-04-19 21:12:26.761442', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('402', '2019-04-19 21:12:26.985326', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('403', '2019-04-19 21:12:27.058519', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('404', '2019-04-19 21:12:27.111539', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('405', '2019-04-19 21:12:27.116215', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('406', '2019-04-19 21:12:27.308986', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('407', '2019-04-19 21:12:27.312746', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('408', '2019-04-19 21:12:27.316342', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('409', '2019-04-19 21:12:27.555608', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('410', '2019-04-19 21:12:27.782454', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('411', '2019-04-19 21:12:28.647118', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('412', '2019-04-19 21:12:29.602535', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('413', '2019-04-19 21:12:31.738815', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('414', '2019-04-19 21:12:33.533150', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('415', '2019-04-19 21:12:35.533670', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('416', '2019-04-19 21:12:37.537878', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('417', '2019-04-19 21:12:39.519335', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('418', '2019-04-19 21:12:41.499418', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('419', '2019-04-19 21:12:43.560299', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('420', '2019-04-19 21:12:45.561658', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('421', '2019-04-19 21:12:47.496486', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('422', '2019-04-19 21:12:49.670115', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('423', '2019-04-19 21:12:51.528881', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('424', '2019-04-19 21:12:53.512353', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('425', '2019-04-19 21:12:55.528766', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('426', '2019-04-19 21:12:57.617635', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('427', '2019-04-19 21:12:59.501976', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('428', '2019-04-19 21:13:01.685475', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('429', '2019-04-19 21:13:03.513912', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('430', '2019-04-19 21:20:01.987512', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('431', '2019-04-19 21:20:03.959511', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('432', '2019-04-19 21:20:05.959593', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('433', '2019-04-19 21:20:07.959795', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('434', '2019-04-19 21:20:09.960176', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('435', '2019-04-19 21:20:11.960924', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('436', '2019-04-19 21:20:13.961667', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('437', '2019-04-19 21:20:15.962486', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('438', '2019-04-19 21:20:17.963150', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('439', '2019-04-19 21:20:19.968721', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('440', '2019-04-19 21:20:21.970408', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('441', '2019-04-19 21:20:23.972185', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('442', '2019-04-19 21:20:25.972303', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('443', '2019-04-19 21:20:27.973145', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('444', '2019-04-19 21:20:29.973714', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('445', '2019-04-19 21:20:31.974645', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('446', '2019-04-19 21:20:33.975208', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('447', '2019-04-19 21:20:35.975849', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('448', '2019-04-19 21:20:37.976537', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('449', '2019-04-19 21:20:39.977103', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('450', '2019-04-19 21:20:41.977651', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('451', '2019-04-19 21:20:43.978629', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('452', '2019-04-19 21:20:45.979231', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('453', '2019-04-19 21:20:47.979869', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('454', '2019-04-19 21:20:49.980432', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('455', '2019-04-19 21:20:51.981236', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('456', '2019-04-19 21:20:53.981748', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('457', '2019-04-19 21:20:55.982215', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('458', '2019-04-19 21:20:57.983071', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('459', '2019-04-19 21:20:59.983730', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('460', '2019-04-19 21:21:01.986166', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('461', '2019-04-19 21:21:03.986894', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('462', '2019-04-19 21:21:05.989620', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('463', '2019-04-19 21:21:07.990218', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('464', '2019-04-19 21:21:09.992032', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('465', '2019-04-19 21:21:11.992648', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('466', '2019-04-19 21:21:13.999805', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('467', '2019-04-19 21:32:02.747565', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('468', '2019-04-19 21:32:04.862240', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('469', '2019-04-19 21:32:06.953268', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('470', '2019-04-19 21:32:09.002648', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('471', '2019-04-19 21:32:11.097726', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('472', '2019-04-19 21:32:13.038403', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('473', '2019-04-19 21:32:14.891568', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('474', '2019-04-19 21:32:16.922719', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('475', '2019-04-19 21:32:19.003968', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('476', '2019-04-19 21:32:20.872547', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('477', '2019-04-19 21:32:22.762813', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('478', '2019-04-19 21:32:24.933958', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('479', '2019-04-19 21:32:26.900004', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('480', '2019-04-19 21:32:28.986937', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('481', '2019-04-19 21:32:30.987274', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('482', '2019-04-19 21:32:34.781990', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('483', '2019-04-19 21:32:36.758855', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('484', '2019-04-19 21:32:39.019172', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('485', '2019-04-19 21:32:41.153903', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('486', '2019-04-19 21:32:42.874478', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('487', '2019-04-19 21:32:44.762067', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('488', '2019-04-19 21:32:46.763079', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('489', '2019-04-19 21:32:48.763945', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('490', '2019-04-19 21:32:50.765271', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('491', '2019-04-19 21:32:52.765924', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('492', '2019-04-19 21:32:54.773545', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('493', '2019-04-19 21:32:56.768502', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('494', '2019-04-19 21:32:58.768606', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('495', '2019-04-19 21:33:00.771477', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('496', '2019-04-19 21:33:02.771012', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('497', '2019-04-19 21:33:04.771632', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('498', '2019-04-19 21:33:06.778661', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('499', '2019-04-19 21:33:08.773493', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('500', '2019-04-19 21:33:10.774118', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('501', '2019-04-19 21:33:12.778130', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('502', '2019-04-19 21:33:14.776075', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('503', '2019-04-19 21:33:16.776021', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('504', '2019-04-19 21:33:18.776426', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('505', '2019-04-19 21:33:20.779348', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('506', '2019-04-19 21:33:22.780958', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('507', '2019-04-19 21:33:24.783712', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('508', '2019-04-19 21:33:26.781987', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('509', '2019-04-19 21:33:28.791735', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('510', '2019-04-19 21:33:30.804057', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('511', '2019-04-19 21:33:32.804921', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('512', '2019-04-19 21:33:34.806265', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('513', '2019-04-19 21:33:36.811530', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('514', '2019-04-19 21:33:38.814971', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('515', '2019-04-19 21:33:40.811650', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('516', '2019-04-19 21:33:42.812688', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('517', '2019-04-19 21:33:44.812583', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('518', '2019-04-19 21:33:46.813177', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('519', '2019-04-19 21:33:48.813829', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('520', '2019-04-19 21:33:50.820229', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('521', '2019-04-19 21:33:52.822512', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('522', '2019-04-19 21:33:54.823983', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('523', '2019-04-19 21:33:56.819789', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('524', '2019-04-19 21:33:58.826785', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('525', '2019-04-19 21:34:00.828143', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('526', '2019-04-19 21:34:02.826616', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('527', '2019-04-19 21:34:04.825058', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('528', '2019-04-19 21:34:06.831114', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('529', '2019-04-19 21:34:08.830356', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('530', '2019-04-19 21:34:10.828767', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('531', '2019-04-19 21:34:12.829356', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('532', '2019-04-19 21:34:43.082424', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('533', '2019-04-19 21:34:45.036960', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('534', '2019-04-19 21:34:47.036477', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('535', '2019-04-19 21:34:49.037000', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('536', '2019-04-19 21:34:51.040278', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('537', '2019-04-19 21:34:53.040589', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('538', '2019-04-19 21:34:55.041051', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('539', '2019-04-19 21:34:57.042035', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('540', '2019-04-19 21:34:59.042299', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('541', '2019-04-19 21:35:01.043583', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('542', '2019-04-19 21:35:03.052921', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('543', '2019-04-19 21:35:05.074355', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('544', '2019-04-19 21:35:07.070326', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('545', '2019-04-19 21:35:09.089253', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('546', '2019-04-19 21:35:11.153455', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('547', '2019-04-19 21:35:13.068965', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('548', '2019-04-19 21:35:15.083971', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('549', '2019-04-19 21:35:17.099359', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('550', '2019-04-19 21:35:19.115152', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('551', '2019-04-19 21:35:21.091116', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('552', '2019-04-19 21:35:23.107857', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('553', '2019-04-19 21:35:27.102290', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('554', '2019-04-19 21:35:29.236256', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('555', '2019-04-19 21:35:31.080951', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('556', '2019-04-19 21:35:33.468231', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('557', '2019-04-19 22:04:48.875473', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('558', '2019-04-19 22:04:50.860181', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('559', '2019-04-19 22:04:52.862995', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('560', '2019-04-19 22:04:54.864017', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('561', '2019-04-19 22:04:56.861315', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('562', '2019-04-19 22:04:58.861477', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('563', '2019-04-19 22:05:00.865076', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('564', '2019-04-19 22:05:02.863197', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('565', '2019-04-19 22:05:04.869463', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('566', '2019-04-19 22:05:06.865320', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('567', '2019-04-19 22:05:08.869673', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('568', '2019-04-19 22:05:10.867825', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('569', '2019-04-19 22:05:12.870524', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('570', '2019-04-19 22:05:14.869177', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('571', '2019-04-19 22:05:16.870088', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('572', '2019-04-19 22:05:18.870535', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('573', '2019-04-19 22:05:20.870846', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('574', '2019-04-19 22:05:22.871904', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('575', '2019-04-19 22:05:24.871992', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('576', '2019-04-19 22:05:26.875232', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('577', '2019-04-19 22:05:28.874256', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('578', '2019-04-19 22:05:30.875161', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('579', '2019-04-19 22:05:32.875748', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('580', '2019-04-19 22:05:34.876906', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('581', '2019-04-19 22:05:36.877993', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('582', '2019-04-19 22:05:38.878069', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('583', '2019-04-19 22:05:40.879030', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('584', '2019-04-19 22:05:42.880066', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('585', '2019-04-19 22:05:44.880140', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('586', '2019-04-19 22:05:46.880777', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('587', '2019-04-19 22:05:48.881019', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('588', '2019-04-19 22:05:50.881488', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('589', '2019-04-19 22:05:52.882759', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('590', '2019-04-19 22:05:54.882890', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('591', '2019-04-19 22:05:56.883862', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('592', '2019-04-19 22:05:58.885129', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('593', '2019-04-19 22:06:00.885654', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('594', '2019-04-19 22:06:02.886896', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('595', '2019-04-19 22:06:04.887864', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('596', '2019-04-19 22:06:06.888700', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('597', '2019-04-19 22:06:08.891451', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('598', '2019-04-19 22:06:10.892918', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('599', '2019-04-19 22:06:12.892517', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('600', '2019-04-19 22:06:14.893182', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('601', '2019-04-19 22:06:16.895541', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('602', '2019-04-19 22:06:18.893502', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('603', '2019-04-19 22:06:20.895360', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('604', '2019-04-19 22:06:22.895187', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('605', '2019-04-19 22:06:24.895970', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('606', '2019-04-19 22:06:26.901694', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('607', '2019-04-19 22:06:28.900025', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('608', '2019-04-19 22:06:30.898224', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('609', '2019-04-19 22:06:32.902494', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('610', '2019-04-19 22:06:34.904678', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('611', '2019-04-19 22:06:36.905660', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('612', '2019-04-19 22:06:38.905569', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('613', '2019-04-19 22:06:40.908425', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('614', '2019-04-19 22:06:42.905403', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('615', '2019-04-19 22:06:44.905469', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('616', '2019-04-19 22:06:46.911451', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('617', '2019-04-19 22:06:48.912984', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('618', '2019-04-19 22:06:50.914109', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('619', '2019-04-19 22:06:52.917002', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('620', '2019-04-19 22:06:54.918115', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('621', '2019-04-19 22:06:56.918186', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('622', '2019-04-19 22:06:58.919163', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('623', '2019-04-19 22:07:00.915920', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('624', '2019-04-19 22:07:02.915988', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('625', '2019-04-19 22:07:04.922086', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('626', '2019-04-19 22:07:06.918301', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('627', '2019-04-19 22:07:08.918960', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('628', '2019-04-19 22:07:10.925151', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('629', '2019-04-19 22:07:12.926646', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('630', '2019-04-19 22:07:14.928224', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('631', '2019-04-19 22:07:16.926083', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('632', '2019-04-19 22:07:18.933628', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('633', '2019-04-19 22:07:20.930469', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('634', '2019-04-19 22:07:22.935097', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('635', '2019-04-19 22:07:24.936704', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('636', '2019-04-19 22:07:26.932714', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('637', '2019-04-19 22:07:28.933475', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('638', '2019-04-19 22:07:30.939509', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('639', '2019-04-19 22:07:32.941274', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('640', '2019-04-19 22:07:34.943078', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('641', '2019-04-19 22:07:36.944285', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('642', '2019-04-19 22:07:38.941208', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('643', '2019-04-19 22:07:40.942255', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('644', '2019-04-19 22:07:42.948275', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('645', '2019-04-19 22:07:44.944724', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('646', '2019-04-19 22:07:46.951004', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('647', '2019-04-19 22:07:48.947440', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('648', '2019-04-19 22:07:50.952565', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('649', '2019-04-19 22:07:52.948831', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('650', '2019-04-19 22:07:54.954255', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('651', '2019-04-19 22:07:56.955863', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('652', '2019-04-19 22:07:58.952966', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('653', '2019-04-19 22:08:00.957765', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('654', '2019-04-19 22:08:02.954646', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('655', '2019-04-19 22:08:04.960456', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('656', '2019-04-19 22:08:06.962074', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('657', '2019-04-19 22:08:08.963342', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('658', '2019-04-19 22:08:10.966402', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('659', '2019-04-19 22:08:12.967933', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('660', '2019-04-19 22:08:14.968959', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('661', '2019-04-19 22:08:16.965624', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('662', '2019-04-19 22:08:18.970874', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('663', '2019-04-19 22:08:20.972781', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('664', '2019-04-19 22:08:22.974408', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('665', '2019-04-19 22:08:24.973147', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('666', '2019-04-19 22:08:26.972147', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('667', '2019-04-19 22:08:28.977362', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('668', '2019-04-19 22:08:30.973855', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('669', '2019-04-19 22:08:32.976559', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('670', '2019-04-19 22:08:34.980355', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('671', '2019-04-19 22:08:36.982693', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('672', '2019-04-19 22:08:38.983779', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('673', '2019-04-19 22:08:40.980659', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('674', '2019-04-19 22:08:42.985496', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('675', '2019-04-19 22:08:44.985556', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('676', '2019-04-19 22:08:46.989271', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('677', '2019-04-19 22:08:48.990952', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('678', '2019-04-19 22:08:50.989565', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('679', '2019-04-19 22:08:52.993813', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('680', '2019-04-19 22:08:54.989911', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('681', '2019-04-19 22:08:56.995974', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('682', '2019-04-19 22:08:58.997801', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('683', '2019-04-19 22:09:00.996323', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('684', '2019-04-19 22:09:02.993671', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('685', '2019-04-19 22:09:05.000623', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('686', '2019-04-19 22:09:07.001686', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('687', '2019-04-19 22:09:09.003064', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('688', '2019-04-19 22:09:11.000225', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('689', '2019-04-19 22:09:13.000245', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('690', '2019-04-19 22:09:15.000930', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('691', '2019-04-19 22:09:17.006541', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('692', '2019-04-19 22:09:19.007671', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('693', '2019-04-19 22:09:21.009789', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('694', '2019-04-19 22:09:23.006727', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('695', '2019-04-19 22:09:25.011927', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('696', '2019-04-19 22:09:27.009512', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('697', '2019-04-19 22:09:29.014476', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('698', '2019-04-19 22:09:31.015812', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('699', '2019-04-19 22:09:33.012792', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('700', '2019-04-19 22:09:35.018555', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('701', '2019-04-19 22:09:37.019619', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('702', '2019-04-19 22:09:39.022521', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('703', '2019-04-19 22:09:41.023109', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('704', '2019-04-19 22:09:43.019541', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('705', '2019-04-19 22:09:45.025390', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('706', '2019-04-19 22:09:47.027338', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('707', '2019-04-19 22:09:49.028702', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('708', '2019-04-19 22:09:51.025245', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('709', '2019-04-19 22:09:53.027220', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('710', '2019-04-19 22:09:55.027326', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('711', '2019-04-19 22:09:57.027550', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('712', '2019-04-19 22:09:59.032910', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('713', '2019-04-19 22:10:01.034855', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('714', '2019-04-19 22:10:03.032635', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('715', '2019-04-19 22:10:05.032451', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('716', '2019-04-19 22:10:07.037899', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('717', '2019-04-19 22:10:09.039609', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('718', '2019-04-19 22:10:11.036717', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('719', '2019-04-19 22:10:13.036312', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('720', '2019-04-19 22:10:15.041665', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('721', '2019-04-19 22:11:03.369214', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('722', '2019-04-19 22:11:05.346115', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('723', '2019-04-19 22:11:07.343322', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('724', '2019-04-19 22:11:09.344773', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('725', '2019-04-19 22:11:11.344872', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('726', '2019-04-19 22:11:13.346274', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('727', '2019-04-19 22:11:15.346137', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('728', '2019-04-19 22:11:17.346907', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('729', '2019-04-19 22:11:19.348389', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('730', '2019-04-19 22:11:21.348423', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('731', '2019-04-19 22:11:23.349251', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('732', '2019-04-19 22:11:25.349646', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('733', '2019-04-19 22:11:27.350330', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('734', '2019-04-19 22:11:29.351117', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('735', '2019-04-19 22:11:31.351460', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('736', '2019-04-19 22:11:33.352392', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('737', '2019-04-19 22:11:35.352863', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('738', '2019-04-19 22:11:37.353494', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('739', '2019-04-19 22:11:39.354267', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('740', '2019-04-19 22:11:41.354971', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('741', '2019-04-19 22:11:43.356714', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('742', '2019-04-19 22:11:45.357000', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('743', '2019-04-19 22:11:47.358150', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('744', '2019-04-19 22:11:49.358289', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('745', '2019-04-19 22:11:51.358950', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('746', '2019-04-19 22:11:53.360205', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('747', '2019-04-19 22:11:55.360126', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('748', '2019-04-19 22:11:57.360561', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('749', '2019-04-19 22:11:59.361810', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('750', '2019-04-19 22:12:01.361852', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('751', '2019-04-19 22:12:03.363210', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('752', '2019-04-19 22:12:05.363149', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('753', '2019-04-19 22:12:28.748255', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('754', '2019-04-19 22:12:28.896130', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('755', '2019-04-19 22:12:29.494855', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('756', '2019-04-19 22:12:31.492315', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('757', '2019-04-19 22:12:33.493521', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('758', '2019-04-19 22:12:35.493601', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('759', '2019-04-19 22:12:37.495394', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('760', '2019-04-19 22:12:39.499682', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('761', '2019-04-19 22:12:41.497059', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('762', '2019-04-19 22:12:43.497935', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('763', '2019-04-19 22:12:45.498176', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('764', '2019-04-19 22:12:47.499291', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('765', '2019-04-19 22:12:49.500286', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('766', '2019-04-19 22:12:51.501538', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('767', '2019-04-19 22:12:53.502987', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('768', '2019-04-19 22:12:55.503034', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('769', '2019-04-19 22:12:57.503371', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('770', '2019-04-19 22:12:59.503864', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('771', '2019-04-19 22:13:01.505073', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('772', '2019-04-19 22:13:03.505847', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('773', '2019-04-19 22:13:05.505586', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('774', '2019-04-19 22:13:07.506667', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('775', '2019-04-19 22:13:09.506836', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('776', '2019-04-19 22:13:11.508205', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('777', '2019-04-19 22:13:13.517250', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('778', '2019-04-19 22:13:15.509526', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('779', '2019-04-19 22:13:17.509980', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('780', '2019-04-19 22:13:19.510377', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('781', '2019-04-19 22:13:21.510419', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('782', '2019-04-19 22:13:23.512323', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('783', '2019-04-19 22:13:25.512875', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('784', '2019-04-19 22:13:27.513884', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('785', '2019-04-19 22:13:29.514941', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('786', '2019-04-19 22:13:31.514581', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('787', '2019-04-19 22:13:33.516245', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('788', '2019-04-19 22:13:35.516282', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('789', '2019-04-19 22:13:37.516902', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('790', '2019-04-19 22:13:39.518028', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('791', '2019-04-19 22:13:41.517918', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('792', '2019-04-19 22:13:43.519180', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('793', '2019-04-19 22:13:45.519147', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('794', '2019-04-19 22:13:47.519725', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('795', '2019-04-19 22:13:49.520845', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('796', '2019-04-19 22:13:51.521268', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('797', '2019-04-19 22:13:53.522230', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('798', '2019-04-19 22:13:55.522828', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('799', '2019-04-19 22:13:57.523442', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('800', '2019-04-19 22:13:59.523925', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('801', '2019-04-19 22:14:01.525011', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('802', '2019-04-19 22:14:03.527249', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('803', '2019-04-19 22:14:05.528203', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('804', '2019-04-19 22:14:07.528706', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('805', '2019-04-19 22:14:09.528939', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('806', '2019-04-19 22:14:11.530063', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('807', '2019-04-19 22:14:13.530900', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('808', '2019-04-19 22:14:15.530690', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('809', '2019-04-19 22:17:24.769967', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('810', '2019-04-19 22:18:08.758660', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('811', '2019-04-19 22:18:10.742589', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('812', '2019-04-19 22:18:12.742354', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('813', '2019-04-19 22:18:14.743429', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('814', '2019-04-19 22:18:16.749954', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('815', '2019-04-19 22:18:18.745800', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('816', '2019-04-19 22:18:20.746834', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('817', '2019-04-19 22:18:22.748098', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('818', '2019-04-19 22:18:24.754620', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('819', '2019-04-19 22:18:26.750690', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('820', '2019-04-19 22:18:28.750896', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('821', '2019-04-19 22:18:30.751867', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('822', '2019-04-19 22:18:32.752491', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('823', '2019-04-19 22:18:34.758510', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('824', '2019-04-19 22:18:36.754981', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('825', '2019-04-19 22:19:10.901642', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('826', '2019-04-19 22:19:11.005202', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('827', '2019-04-19 22:19:11.010187', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('828', '2019-04-19 22:19:11.014660', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('829', '2019-04-19 22:19:11.018657', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('830', '2019-04-19 22:19:11.045890', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('831', '2019-04-19 22:19:11.049802', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('832', '2019-04-19 22:19:11.053847', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('833', '2019-04-19 22:19:11.057665', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('834', '2019-04-19 22:19:11.070572', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('835', '2019-04-19 22:19:11.074705', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('836', '2019-04-19 22:19:11.080017', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('837', '2019-04-19 22:19:11.084086', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('838', '2019-04-19 22:19:12.819197', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('839', '2019-04-19 22:19:14.819468', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('840', '2019-04-19 22:20:15.063607', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('841', '2019-04-19 22:20:17.056041', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('842', '2019-04-19 22:20:19.057207', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('843', '2019-04-19 22:20:21.059219', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('844', '2019-04-19 22:20:23.055395', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('845', '2019-04-19 22:20:25.061812', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('846', '2019-04-19 22:20:27.062217', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('847', '2019-04-19 22:20:29.062777', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('848', '2019-04-19 22:20:31.061402', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('849', '2019-04-19 22:20:33.063912', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('850', '2019-04-19 22:20:35.061840', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('851', '2019-04-19 22:20:37.062903', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('852', '2019-04-19 22:23:36.017833', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('853', '2019-04-19 22:23:38.006950', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('854', '2019-04-19 22:23:40.006756', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('855', '2019-04-19 22:23:42.004596', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('856', '2019-04-19 22:23:44.010301', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('857', '2019-04-19 22:27:59.582349', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('858', '2019-04-19 22:28:01.565016', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('859', '2019-04-19 22:28:03.565750', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('860', '2019-04-19 22:28:05.569261', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('861', '2019-04-19 22:28:07.572067', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('862', '2019-04-19 22:28:09.572975', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('863', '2019-04-19 22:28:11.573689', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('864', '2019-04-19 22:28:13.571262', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('865', '2019-04-19 22:28:15.571877', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('866', '2019-04-19 22:28:17.572123', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('867', '2019-04-19 22:28:19.572981', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('868', '2019-04-19 22:28:21.573944', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('869', '2019-04-19 22:28:23.574883', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('870', '2019-04-19 22:28:25.580795', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('871', '2019-04-19 22:28:27.582446', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('872', '2019-04-19 22:28:29.584422', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('873', '2019-04-19 22:28:31.583576', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('874', '2019-04-19 22:28:33.582345', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('875', '2019-04-19 22:28:35.583218', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('876', '2019-04-19 22:28:37.589174', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('877', '2019-04-19 22:28:39.589601', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('878', '2019-04-19 22:28:41.591408', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('879', '2019-04-19 22:28:43.589239', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('880', '2019-04-19 22:28:45.589659', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('881', '2019-04-19 22:28:47.593325', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('882', '2019-04-19 22:28:49.597435', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('883', '2019-04-19 22:28:51.595902', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('884', '2019-04-19 22:28:53.594377', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('885', '2019-04-19 22:28:55.595672', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('886', '2019-04-19 22:28:57.596505', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('887', '2019-04-19 22:28:59.597671', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('888', '2019-04-19 22:29:01.597633', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('889', '2019-04-19 22:29:03.598788', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('890', '2019-04-19 22:29:05.602567', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('891', '2019-04-19 22:29:07.600699', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('892', '2019-04-19 22:29:09.601493', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('893', '2019-04-19 22:29:11.603339', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('894', '2019-04-19 22:29:13.603098', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('895', '2019-04-19 22:29:15.604133', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('896', '2019-04-19 22:29:17.606145', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('897', '2019-04-19 22:29:19.608219', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('898', '2019-04-19 22:29:21.608664', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('899', '2019-04-19 22:29:23.607598', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('900', '2019-04-19 22:29:25.609718', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('901', '2019-04-19 22:29:27.608833', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('902', '2019-04-19 22:29:29.610661', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('903', '2019-04-19 22:29:31.610952', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('904', '2019-04-19 22:29:33.611725', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('905', '2019-04-19 22:29:35.611666', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('906', '2019-04-19 22:29:37.611499', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('907', '2019-04-19 22:29:39.612701', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('908', '2019-04-19 22:29:41.614515', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('909', '2019-04-19 22:29:43.614248', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('910', '2019-04-19 22:29:45.615013', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('911', '2019-04-19 22:29:47.616025', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('912', '2019-04-19 22:29:49.616074', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('913', '2019-04-19 22:29:51.616851', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('914', '2019-04-19 22:29:53.617268', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('915', '2019-04-19 22:29:55.618181', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('916', '2019-04-19 22:29:57.618194', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('917', '2019-04-19 22:29:59.619088', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('918', '2019-04-19 22:30:01.620019', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('919', '2019-04-19 22:30:03.621019', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('920', '2019-04-19 22:30:05.621901', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('921', '2019-04-19 22:30:07.621971', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('922', '2019-04-19 22:30:09.623006', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('923', '2019-04-19 22:30:11.623587', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('924', '2019-04-19 22:30:13.623754', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('925', '2019-04-19 22:30:15.624473', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('926', '2019-04-19 22:30:17.624792', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('927', '2019-04-19 22:30:19.625778', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('928', '2019-04-19 22:30:21.626887', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('929', '2019-04-19 22:30:23.627508', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('930', '2019-04-19 22:30:25.631275', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('931', '2019-04-19 22:30:27.632037', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('932', '2019-04-19 22:30:29.632366', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('933', '2019-04-19 22:30:31.633226', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('934', '2019-04-19 22:30:33.633532', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('935', '2019-04-19 22:30:35.634695', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('936', '2019-04-19 22:30:37.634846', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('937', '2019-04-19 22:30:39.636095', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('938', '2019-04-19 22:30:41.636367', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('939', '2019-04-19 22:30:43.636826', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('940', '2019-04-19 22:30:45.638024', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('941', '2019-04-19 22:30:47.638711', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('942', '2019-04-19 22:30:49.638818', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('943', '2019-04-19 22:30:51.639327', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('944', '2019-04-19 22:30:53.640245', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('945', '2019-04-19 22:30:55.640740', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('946', '2019-04-19 22:30:57.641425', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('947', '2019-04-19 22:30:59.642089', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('948', '2019-04-19 22:31:01.642876', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('949', '2019-04-19 22:31:03.643683', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('950', '2019-04-19 22:31:05.644107', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('951', '2019-04-19 22:31:07.644954', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('952', '2019-04-19 22:31:09.645180', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('953', '2019-04-19 22:31:11.646099', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('954', '2019-04-19 22:31:13.647157', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('955', '2019-04-19 22:31:15.647706', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('956', '2019-04-19 22:31:17.648735', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('957', '2019-04-19 22:31:19.649162', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('958', '2019-04-19 22:31:21.649884', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('959', '2019-04-19 22:31:23.650279', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('960', '2019-04-19 22:31:25.651283', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('961', '2019-04-19 22:31:27.651714', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('962', '2019-04-19 22:31:29.652475', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('963', '2019-04-19 22:31:31.653116', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('964', '2019-04-19 22:31:33.657505', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('965', '2019-04-19 22:31:35.658174', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('966', '2019-04-19 22:31:37.658874', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('967', '2019-04-19 22:31:39.659164', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('968', '2019-04-19 22:31:41.660290', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('969', '2019-04-19 22:31:43.661056', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('970', '2019-04-19 22:31:45.661506', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('971', '2019-04-19 22:31:47.662847', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('972', '2019-04-19 22:31:49.663265', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('973', '2019-04-19 22:31:51.664052', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('974', '2019-04-19 22:31:53.664331', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('975', '2019-04-19 22:31:55.665717', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('976', '2019-04-19 22:31:57.666563', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('977', '2019-04-19 22:31:59.667474', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('978', '2019-04-19 22:32:01.669012', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('979', '2019-04-19 22:32:03.668846', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('980', '2019-04-19 22:32:05.668747', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('981', '2019-04-19 22:32:07.671171', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('982', '2019-04-19 22:32:09.670641', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('983', '2019-04-19 22:32:11.671579', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('984', '2019-04-19 22:32:13.671471', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('985', '2019-04-19 22:32:15.672028', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('986', '2019-04-19 22:32:17.672705', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('987', '2019-04-19 22:32:19.673670', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('988', '2019-04-19 22:32:21.674150', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('989', '2019-04-19 22:32:23.674809', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('990', '2019-04-19 22:32:25.678557', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('991', '2019-04-19 22:32:27.679668', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('992', '2019-04-19 22:32:29.678890', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('993', '2019-04-19 22:32:31.679065', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('994', '2019-04-19 22:32:33.680373', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('995', '2019-04-19 22:32:35.682099', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('996', '2019-04-19 22:32:37.681421', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('997', '2019-04-19 22:32:39.682728', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('998', '2019-04-19 22:32:41.683060', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('999', '2019-04-19 22:32:43.683481', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1000', '2019-04-19 22:32:45.684516', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1001', '2019-04-19 22:32:47.685091', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1002', '2019-04-19 22:32:49.686693', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1003', '2019-04-19 22:32:51.687317', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1004', '2019-04-19 22:32:53.687249', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1005', '2019-04-19 22:32:55.688554', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1006', '2019-04-19 22:32:57.688837', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1007', '2019-04-19 22:32:59.689746', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1008', '2019-04-19 22:33:01.691473', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1009', '2019-04-19 22:33:03.690856', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1010', '2019-04-19 22:33:05.691134', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1011', '2019-04-19 22:33:07.692020', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1012', '2019-04-19 22:33:09.692550', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1013', '2019-04-19 22:33:11.694038', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1014', '2019-04-19 22:33:13.693851', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1015', '2019-04-19 22:33:15.694702', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1016', '2019-04-19 22:33:17.695288', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1017', '2019-04-19 22:33:19.696641', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1018', '2019-04-19 22:33:21.696866', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1019', '2019-04-19 22:33:23.696964', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1020', '2019-04-19 22:33:25.698706', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1021', '2019-04-19 22:33:27.698716', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1022', '2019-04-19 22:33:29.702916', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1023', '2019-04-19 22:33:31.700924', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1024', '2019-04-19 22:33:33.701761', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1025', '2019-04-19 22:33:35.709056', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1026', '2019-04-19 22:33:37.705565', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1027', '2019-04-19 22:33:39.706936', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1028', '2019-04-19 22:33:41.707405', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1029', '2019-04-19 22:33:43.707189', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1030', '2019-04-19 22:33:45.707921', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1031', '2019-04-19 22:33:47.709298', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1032', '2019-04-19 22:33:49.714863', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1033', '2019-04-19 22:33:51.716239', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1034', '2019-04-19 22:33:53.717820', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1035', '2019-04-19 22:33:55.720937', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1036', '2019-04-19 22:33:57.716891', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1037', '2019-04-19 22:33:59.721626', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1038', '2019-04-19 22:34:01.719541', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1039', '2019-04-19 22:34:03.718696', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1040', '2019-04-19 22:34:05.725132', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1041', '2019-04-19 22:34:07.721747', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1042', '2019-04-19 22:34:09.726507', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1043', '2019-04-19 22:34:11.728206', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1044', '2019-04-19 22:34:13.725100', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1045', '2019-04-19 22:34:15.729648', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1046', '2019-04-19 22:34:17.726676', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1047', '2019-04-19 22:34:19.726910', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1048', '2019-04-19 22:36:58.824954', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1049', '2019-04-19 22:37:00.808839', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1050', '2019-04-19 22:37:02.814920', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1051', '2019-04-19 22:37:04.811429', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1052', '2019-04-19 22:37:06.817436', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1053', '2019-04-19 22:37:08.812302', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1054', '2019-04-19 22:37:10.818707', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1055', '2019-04-19 22:37:12.820479', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1056', '2019-04-19 22:37:14.816650', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1057', '2019-04-19 22:37:16.820101', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1058', '2019-04-19 22:37:18.818932', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1059', '2019-04-19 22:37:20.820016', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1060', '2019-04-19 22:37:22.820063', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1061', '2019-04-19 22:37:24.826003', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1062', '2019-04-19 22:37:26.823525', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1063', '2019-04-19 22:37:28.823197', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1064', '2019-04-19 22:37:30.830453', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1065', '2019-04-19 22:37:32.826585', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1066', '2019-04-19 22:37:34.827492', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1067', '2019-04-19 22:37:36.828701', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1068', '2019-04-19 22:37:38.827680', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1069', '2019-04-19 22:37:40.830184', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1070', '2019-04-19 22:37:42.830779', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1071', '2019-04-19 22:37:44.831397', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1072', '2019-04-19 22:37:46.830446', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1073', '2019-04-19 22:37:48.830410', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1074', '2019-04-19 22:37:50.831357', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1075', '2019-04-19 22:41:58.589159', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1076', '2019-04-19 22:42:00.488070', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1077', '2019-04-19 22:42:02.486084', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1078', '2019-04-19 22:42:04.487341', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1079', '2019-04-19 22:42:06.487271', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1080', '2019-04-19 22:42:08.488658', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1081', '2019-04-19 22:42:10.489364', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1082', '2019-04-19 22:42:12.489368', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1083', '2019-04-19 22:42:14.490614', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1084', '2019-04-19 22:42:16.496121', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1085', '2019-04-19 22:42:18.497350', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1086', '2019-04-19 22:42:20.499096', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1087', '2019-04-19 22:42:22.499867', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1088', '2019-04-19 22:42:24.500474', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1089', '2019-04-19 22:42:26.500904', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1090', '2019-04-19 22:42:28.502080', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1091', '2019-04-19 22:42:30.502299', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1092', '2019-04-19 22:42:32.503444', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1093', '2019-04-19 22:42:34.503835', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1094', '2019-04-19 22:42:36.504938', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1095', '2019-04-19 22:42:38.505744', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1096', '2019-04-19 22:42:40.506054', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1097', '2019-04-19 22:42:42.506362', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1098', '2019-04-19 22:42:44.507213', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1099', '2019-04-19 22:42:46.507877', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1100', '2019-04-19 22:42:48.508741', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1101', '2019-04-19 22:42:50.508733', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1102', '2019-04-19 22:42:52.510243', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1103', '2019-04-19 22:42:54.510766', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1104', '2019-04-19 22:42:56.510537', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1105', '2019-04-19 22:42:58.511970', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1106', '2019-04-19 22:43:00.512456', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1107', '2019-04-19 22:43:02.512877', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1108', '2019-04-19 22:43:04.513752', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1109', '2019-04-19 22:43:06.514383', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1110', '2019-04-19 22:43:08.515565', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1111', '2019-04-19 22:43:10.515747', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1112', '2019-04-19 22:43:12.516321', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1113', '2019-04-19 22:43:14.516988', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1114', '2019-04-19 22:43:16.517741', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1115', '2019-04-19 22:43:18.518170', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1116', '2019-04-19 22:43:20.518388', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1117', '2019-04-19 22:43:22.518925', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1118', '2019-04-19 22:43:24.520079', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1119', '2019-04-19 22:43:26.521310', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1120', '2019-04-19 22:43:28.521249', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1121', '2019-04-19 22:43:30.522176', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1122', '2019-04-19 22:43:32.523364', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1123', '2019-04-19 22:43:34.523345', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1124', '2019-04-19 22:43:36.523889', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1125', '2019-04-19 22:43:38.525037', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1126', '2019-04-19 22:43:40.525180', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1127', '2019-04-19 22:43:42.526591', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1128', '2019-04-19 22:43:44.526785', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1129', '2019-04-19 22:43:46.527774', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1130', '2019-04-19 22:43:48.528452', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1131', '2019-04-19 22:43:50.529744', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1132', '2019-04-19 22:43:52.530047', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1133', '2019-04-19 22:43:54.531369', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1134', '2019-04-19 22:43:56.531702', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1135', '2019-04-19 22:43:58.532112', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1136', '2019-04-19 22:45:07.021409', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1137', '2019-04-19 22:45:09.001696', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1138', '2019-04-19 22:45:11.001660', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1139', '2019-04-19 22:45:13.003253', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1140', '2019-04-19 22:45:15.004231', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1141', '2019-04-19 22:45:17.004432', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1142', '2019-04-19 22:45:19.005624', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1143', '2019-04-19 22:45:21.006701', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1144', '2019-04-19 22:45:23.012198', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1145', '2019-04-19 22:45:25.009119', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1146', '2019-04-19 22:45:27.009308', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1147', '2019-04-19 22:45:29.012020', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1148', '2019-04-19 22:45:31.011633', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1149', '2019-04-19 22:45:33.011530', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1150', '2019-04-19 22:45:35.016410', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1151', '2019-04-19 22:45:37.018646', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1152', '2019-04-19 22:45:39.014334', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1153', '2019-04-19 22:45:41.022310', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1154', '2019-04-19 22:45:43.023117', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1155', '2019-04-19 22:45:45.024555', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1156', '2019-04-19 22:45:47.021482', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1157', '2019-04-19 22:45:49.024716', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1158', '2019-04-19 22:45:51.022416', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1159', '2019-04-19 22:45:53.023546', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1160', '2019-04-19 22:45:55.026875', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1161', '2019-04-19 22:45:57.024905', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1162', '2019-04-19 22:45:59.030255', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1163', '2019-04-19 22:46:01.031818', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1164', '2019-04-19 22:46:03.027284', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1165', '2019-04-19 22:46:05.032974', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1166', '2019-04-19 22:46:07.034419', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1167', '2019-04-19 22:46:09.036221', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1168', '2019-04-19 22:46:11.038037', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1169', '2019-04-19 22:46:13.033937', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1170', '2019-04-19 22:46:15.036217', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1171', '2019-04-19 22:46:17.035440', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1172', '2019-04-19 22:46:19.035260', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1173', '2019-04-19 22:46:21.038467', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1174', '2019-04-19 22:46:23.037409', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1175', '2019-04-19 22:46:25.042665', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1176', '2019-04-19 22:46:27.038484', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1177', '2019-04-19 22:46:29.038522', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1178', '2019-04-19 22:46:31.044691', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1179', '2019-04-19 22:46:33.041905', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1180', '2019-04-19 22:46:35.047013', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1181', '2019-04-19 22:46:37.046998', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1182', '2019-04-19 22:46:39.043693', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1183', '2019-04-19 22:46:41.048927', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1184', '2019-04-19 22:46:43.045146', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1185', '2019-04-19 22:46:45.051486', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1186', '2019-04-19 22:46:47.053311', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1187', '2019-04-19 22:46:49.054733', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1188', '2019-04-19 22:46:51.051711', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1189', '2019-04-19 22:46:53.057373', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1190', '2019-04-19 22:46:55.058363', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1191', '2019-04-19 22:46:57.060102', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1192', '2019-04-19 22:46:59.056824', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1193', '2019-04-19 22:47:01.062489', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1194', '2019-04-19 22:47:03.064533', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1195', '2019-04-19 22:47:05.061457', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1196', '2019-04-19 22:47:07.066515', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1197', '2019-04-19 22:47:09.067702', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1198', '2019-04-19 22:47:11.064630', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1199', '2019-04-19 22:47:13.070503', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1200', '2019-04-19 22:47:15.072653', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1201', '2019-04-19 22:47:17.069521', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1202', '2019-04-19 22:47:19.070489', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1203', '2019-04-19 22:47:27.154704', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1204', '2019-04-19 22:47:29.116886', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1205', '2019-04-19 22:47:31.117471', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1206', '2019-04-19 22:47:33.118062', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1207', '2019-04-19 22:47:35.119292', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1208', '2019-04-19 22:47:37.121424', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1209', '2019-04-19 22:47:39.125541', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1210', '2019-04-19 22:47:41.122490', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1211', '2019-04-19 22:47:43.122620', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1212', '2019-04-19 22:47:45.123259', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1213', '2019-04-19 22:47:47.123880', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1214', '2019-04-19 22:47:49.124434', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1215', '2019-04-19 22:47:51.126315', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1216', '2019-04-19 22:47:53.127150', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1217', '2019-04-19 22:47:55.127708', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1218', '2019-04-19 22:47:57.128256', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1219', '2019-04-19 22:47:59.128649', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1220', '2019-04-19 22:48:01.129482', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1221', '2019-04-19 22:48:03.129969', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1222', '2019-04-19 22:48:05.130269', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1223', '2019-04-19 22:48:07.131684', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1224', '2019-04-19 22:48:09.132074', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1225', '2019-04-19 22:48:11.133330', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1226', '2019-04-19 22:48:13.133296', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1227', '2019-04-19 22:48:15.135008', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1228', '2019-04-19 22:48:17.136009', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1229', '2019-04-19 22:48:19.136033', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1230', '2019-04-19 22:48:21.179255', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1231', '2019-04-19 22:48:23.288075', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1232', '2019-04-19 22:48:25.140670', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1233', '2019-04-19 22:48:27.141301', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1234', '2019-04-19 22:48:29.142410', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1235', '2019-04-19 22:48:31.143429', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1236', '2019-04-19 22:48:33.143762', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1237', '2019-04-19 22:48:35.144965', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1238', '2019-04-19 22:48:37.145134', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1239', '2019-04-19 22:48:39.146215', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1240', '2019-04-19 22:48:41.146466', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1241', '2019-04-19 22:48:43.147022', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1242', '2019-04-19 22:48:45.148024', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1243', '2019-04-19 22:48:47.148891', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1244', '2019-04-19 22:48:49.164159', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1245', '2019-04-19 22:49:29.061374', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1246', '2019-04-19 22:49:29.566444', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1247', '2019-04-19 22:49:29.589583', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1248', '2019-04-19 22:49:30.593947', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1249', '2019-04-19 22:50:02.689774', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1250', '2019-04-19 22:50:02.703015', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1251', '2019-04-19 22:50:02.711727', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1252', '2019-04-19 22:50:02.720993', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1253', '2019-04-19 22:50:02.729181', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1254', '2019-04-19 22:50:02.733572', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1255', '2019-04-19 22:50:02.738284', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1256', '2019-04-19 22:50:02.743955', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1257', '2019-04-19 22:50:02.749336', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1258', '2019-04-19 22:50:02.754902', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1259', '2019-04-19 22:50:02.760843', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1260', '2019-04-19 22:50:02.765674', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1261', '2019-04-19 22:50:02.769909', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1262', '2019-04-19 22:50:02.774238', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1263', '2019-04-19 22:50:02.778704', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1264', '2019-04-19 22:50:02.783866', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1265', '2019-04-19 22:50:02.789160', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1266', '2019-04-19 22:50:02.793162', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1267', '2019-04-19 22:50:02.797244', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1268', '2019-04-19 22:50:02.800906', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1269', '2019-04-19 22:50:02.804266', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1270', '2019-04-19 22:50:02.807719', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1271', '2019-04-19 22:50:02.810807', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1272', '2019-04-19 22:50:02.813796', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1273', '2019-04-19 22:50:02.816801', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1274', '2019-04-19 22:50:02.820104', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1275', '2019-04-19 22:50:02.823420', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1276', '2019-04-19 22:50:02.826510', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1277', '2019-04-19 22:50:02.829672', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1278', '2019-04-19 22:50:03.173498', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1279', '2019-04-19 22:50:05.173652', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1280', '2019-04-19 22:51:15.528883', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1281', '2019-04-19 22:51:17.506945', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1282', '2019-04-19 22:51:19.505915', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1283', '2019-04-19 22:51:21.518852', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1284', '2019-04-19 22:51:23.508056', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1285', '2019-04-19 22:51:25.508316', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1286', '2019-04-19 22:51:33.756162', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1287', '2019-04-19 22:51:34.444873', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1288', '2019-04-19 22:51:35.649139', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1289', '2019-04-19 22:51:35.674007', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1290', '2019-04-19 22:51:35.719803', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1291', '2019-04-19 22:51:37.512242', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1292', '2019-04-19 22:51:52.948770', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1293', '2019-04-19 22:51:53.117260', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1294', '2019-04-19 22:51:53.303919', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1295', '2019-04-19 22:51:53.430089', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1296', '2019-04-19 22:51:53.608960', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1297', '2019-04-19 22:51:53.690709', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1298', '2019-04-19 22:51:53.817340', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1299', '2019-04-19 22:51:54.255743', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1300', '2019-04-19 22:51:55.518017', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1301', '2019-04-19 22:51:57.518906', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1302', '2019-04-19 22:51:59.518975', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1303', '2019-04-19 22:52:01.520149', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1304', '2019-04-19 22:52:03.520915', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1305', '2019-04-19 22:52:05.521069', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1306', '2019-04-19 22:52:07.568475', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1307', '2019-04-19 22:52:09.522606', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1308', '2019-04-19 22:52:11.523797', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1309', '2019-04-19 22:52:13.552518', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1310', '2019-04-19 22:52:15.524506', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1311', '2019-04-19 22:52:17.524648', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1312', '2019-04-19 22:52:19.526158', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1313', '2019-04-19 22:52:21.525791', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1314', '2019-04-19 22:55:26.829231', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1315', '2019-04-19 22:55:28.815632', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1316', '2019-04-19 22:55:30.816146', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1317', '2019-04-19 22:55:32.814290', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1318', '2019-04-19 22:55:34.817182', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1319', '2019-04-19 22:55:36.817078', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1320', '2019-04-19 22:55:38.818598', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1321', '2019-04-19 22:55:40.816827', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1322', '2019-04-19 22:55:42.817346', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1323', '2019-04-19 22:55:44.818133', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1324', '2019-04-19 22:55:46.823275', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1325', '2019-04-19 22:55:48.821130', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1326', '2019-04-19 22:55:50.846684', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1327', '2019-04-19 22:55:52.820277', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1328', '2019-04-19 22:55:54.821244', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1329', '2019-04-19 22:55:56.821704', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1330', '2019-04-19 22:55:58.825914', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1331', '2019-04-19 22:56:00.823877', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1332', '2019-04-19 22:56:02.825273', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1333', '2019-04-19 22:56:04.826539', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1334', '2019-04-19 22:56:06.831540', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1335', '2019-04-19 22:56:08.828606', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1336', '2019-04-19 22:56:10.833487', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1337', '2019-04-19 22:56:12.835862', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1338', '2019-04-19 22:56:14.837100', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1339', '2019-04-19 22:56:16.834937', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1340', '2019-04-19 22:56:18.837757', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1341', '2019-04-19 22:56:20.834400', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1342', '2019-04-19 22:56:22.834111', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1343', '2019-04-19 22:56:24.840100', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1344', '2019-04-19 22:56:26.841160', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1345', '2019-04-19 22:56:28.840970', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1346', '2019-04-19 22:56:30.840555', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1347', '2019-04-19 22:56:32.844319', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1348', '2019-04-19 22:56:34.840721', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1349', '2019-04-19 22:56:36.847283', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1350', '2019-04-19 22:56:38.847416', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1351', '2019-04-19 22:56:40.845407', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1352', '2019-04-19 22:56:42.846608', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1353', '2019-04-19 22:56:44.851054', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1354', '2019-04-19 22:56:46.852612', '192.168.1.183', '22', '11', '999', '888');
INSERT INTO `app_groundtruthdata` VALUES ('1355', '2019-04-19 22:56:48.853573', '192.168.1.183', '22', '11', '999', '888');

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
INSERT INTO `menus` VALUES ('08d6c4c0-777f-6a51-9d21-0e44bee97c6c', 'App_GroundTruthData', 'fa fa-link', 'Share_GroundTruthData', '00000000-0000-0000-0000-000000000000', null, '4', '0', 'App_GroundTruthData/Index');
INSERT INTO `menus` VALUES ('08d6c4c0-777f-6acb-b8f7-8d71391f4c86', 'Map', 'fa fa-link', 'Share_Map', '00000000-0000-0000-0000-000000000000', null, '5', '0', 'Map/Index');
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
