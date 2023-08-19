
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2023 22:30:18
-- Generated from EDMX file: C:\Users\12530\Documents\GitHub\FIT5032\WebApplication2\WebApplication2\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'studentSet'
CREATE TABLE [dbo].[studentSet] (
    [studentId] int IDENTITY(1,1) NOT NULL,
    [firstname] nvarchar(max)  NOT NULL,
    [lastname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'unitSet'
CREATE TABLE [dbo].[unitSet] (
    [unitId] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [student_studentId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [studentId] in table 'studentSet'
ALTER TABLE [dbo].[studentSet]
ADD CONSTRAINT [PK_studentSet]
    PRIMARY KEY CLUSTERED ([studentId] ASC);
GO

-- Creating primary key on [unitId] in table 'unitSet'
ALTER TABLE [dbo].[unitSet]
ADD CONSTRAINT [PK_unitSet]
    PRIMARY KEY CLUSTERED ([unitId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [student_studentId] in table 'unitSet'
ALTER TABLE [dbo].[unitSet]
ADD CONSTRAINT [FK_studentunit]
    FOREIGN KEY ([student_studentId])
    REFERENCES [dbo].[studentSet]
        ([studentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_studentunit'
CREATE INDEX [IX_FK_studentunit]
ON [dbo].[unitSet]
    ([student_studentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------