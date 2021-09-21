
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/19/2021 21:34:08
-- Generated from EDMX file: C:\Users\Moulay El Hassan\Desktop\ASP TEST\NEWTEST\DB_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NEWTEST];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__TBL_INVOIC__U_ID__3D5E1FD2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TBL_INVOICES] DROP CONSTRAINT [FK__TBL_INVOIC__U_ID__3D5E1FD2];
GO
IF OBJECT_ID(N'[dbo].[FK__TBL_ORDERS__I_ID__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TBL_ORDERS] DROP CONSTRAINT [FK__TBL_ORDERS__I_ID__4222D4EF];
GO
IF OBJECT_ID(N'[dbo].[FK__TBL_ORDERS__P_ID__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TBL_ORDERS] DROP CONSTRAINT [FK__TBL_ORDERS__P_ID__412EB0B6];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TBL_INVOICES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_INVOICES];
GO
IF OBJECT_ID(N'[dbo].[TBL_ORDERS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_ORDERS];
GO
IF OBJECT_ID(N'[dbo].[TBL_PRODUCTS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_PRODUCTS];
GO
IF OBJECT_ID(N'[dbo].[TBL_USERS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_USERS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TBL_INVOICES'
CREATE TABLE [dbo].[TBL_INVOICES] (
    [I_ID] int IDENTITY(1,1) NOT NULL,
    [U_ID] int  NOT NULL,
    [I_STATUT] int  NOT NULL
);
GO

-- Creating table 'TBL_ORDERS'
CREATE TABLE [dbo].[TBL_ORDERS] (
    [O_ID] int IDENTITY(1,1) NOT NULL,
    [P_ID] int  NOT NULL,
    [I_ID] int  NOT NULL,
    [O_QTE] int  NOT NULL,
    [O_DATE] datetime  NULL
);
GO

-- Creating table 'TBL_PRODUCTS'
CREATE TABLE [dbo].[TBL_PRODUCTS] (
    [P_ID] int IDENTITY(1,1) NOT NULL,
    [P_NAME] varchar(255)  NOT NULL,
    [P_DISCRIPTION] varchar(max)  NOT NULL,
    [P_IMG] varchar(255)  NULL,
    [P_PRICE] real  NOT NULL,
    [P_STATUT] int  NULL
);
GO

-- Creating table 'TBL_USERS'
CREATE TABLE [dbo].[TBL_USERS] (
    [U_ID] int IDENTITY(1,1) NOT NULL,
    [U_EMAIL] varchar(50)  NOT NULL,
    [U_PASSWORD] varchar(100)  NOT NULL,
    [U_PHONE] varchar(50)  NULL,
    [U_ADRESS] varchar(255)  NOT NULL,
    [U_TYPE] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [I_ID] in table 'TBL_INVOICES'
ALTER TABLE [dbo].[TBL_INVOICES]
ADD CONSTRAINT [PK_TBL_INVOICES]
    PRIMARY KEY CLUSTERED ([I_ID] ASC);
GO

-- Creating primary key on [O_ID] in table 'TBL_ORDERS'
ALTER TABLE [dbo].[TBL_ORDERS]
ADD CONSTRAINT [PK_TBL_ORDERS]
    PRIMARY KEY CLUSTERED ([O_ID] ASC);
GO

-- Creating primary key on [P_ID] in table 'TBL_PRODUCTS'
ALTER TABLE [dbo].[TBL_PRODUCTS]
ADD CONSTRAINT [PK_TBL_PRODUCTS]
    PRIMARY KEY CLUSTERED ([P_ID] ASC);
GO

-- Creating primary key on [U_ID] in table 'TBL_USERS'
ALTER TABLE [dbo].[TBL_USERS]
ADD CONSTRAINT [PK_TBL_USERS]
    PRIMARY KEY CLUSTERED ([U_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [U_ID] in table 'TBL_INVOICES'
ALTER TABLE [dbo].[TBL_INVOICES]
ADD CONSTRAINT [FK__TBL_INVOIC__U_ID__3D5E1FD2]
    FOREIGN KEY ([U_ID])
    REFERENCES [dbo].[TBL_USERS]
        ([U_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TBL_INVOIC__U_ID__3D5E1FD2'
CREATE INDEX [IX_FK__TBL_INVOIC__U_ID__3D5E1FD2]
ON [dbo].[TBL_INVOICES]
    ([U_ID]);
GO

-- Creating foreign key on [I_ID] in table 'TBL_ORDERS'
ALTER TABLE [dbo].[TBL_ORDERS]
ADD CONSTRAINT [FK__TBL_ORDERS__I_ID__4222D4EF]
    FOREIGN KEY ([I_ID])
    REFERENCES [dbo].[TBL_INVOICES]
        ([I_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TBL_ORDERS__I_ID__4222D4EF'
CREATE INDEX [IX_FK__TBL_ORDERS__I_ID__4222D4EF]
ON [dbo].[TBL_ORDERS]
    ([I_ID]);
GO

-- Creating foreign key on [P_ID] in table 'TBL_ORDERS'
ALTER TABLE [dbo].[TBL_ORDERS]
ADD CONSTRAINT [FK__TBL_ORDERS__P_ID__412EB0B6]
    FOREIGN KEY ([P_ID])
    REFERENCES [dbo].[TBL_PRODUCTS]
        ([P_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TBL_ORDERS__P_ID__412EB0B6'
CREATE INDEX [IX_FK__TBL_ORDERS__P_ID__412EB0B6]
ON [dbo].[TBL_ORDERS]
    ([P_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------