/*
 Navicat Premium Data Transfer

 Source Server         : DESKTOP-CH3GMM4
 Source Server Type    : SQL Server
 Source Server Version : 16001000 (16.00.1000)
 Source Host           : 127.0.0.1:1433
 Source Catalog        : shopweb
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000 (16.00.1000)
 File Encoding         : 65001

 Date: 03/08/2023 19:23:10
*/


-- ----------------------------
-- Table structure for ShopCart
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ShopCart]') AND type IN ('U'))
	DROP TABLE [dbo].[ShopCart]
GO

CREATE TABLE [dbo].[ShopCart] (
  [s_id] bigint  NOT NULL,
  [c_number] int  NOT NULL,
  [p_number] int  NOT NULL
)
GO

ALTER TABLE [dbo].[ShopCart] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table ShopCart
-- ----------------------------
ALTER TABLE [dbo].[ShopCart] ADD CONSTRAINT [PK_ShopCart] PRIMARY KEY CLUSTERED ([s_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table ShopCart
-- ----------------------------
ALTER TABLE [dbo].[ShopCart] ADD CONSTRAINT [FK_ShopCart_Customer_accounttable] FOREIGN KEY ([c_number]) REFERENCES [dbo].[Customer_accounttable] ([c_number]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[ShopCart] ADD CONSTRAINT [FK_ShopCart_Product_datatable] FOREIGN KEY ([p_number]) REFERENCES [dbo].[Product_datatable] ([p_number]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

