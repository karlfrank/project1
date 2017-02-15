
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/14/2016 20:26:56
-- Generated from EDMX file: C:\Users\Mart\Source\Repos\Elibrium\test\Elibrium\Domain\Model2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Kontaktiraamat];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person] DROP CONSTRAINT [FK_CustomerClient];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerHasEmailTemplateCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonEmailTemplate] DROP CONSTRAINT [FK_CustomerHasEmailTemplateCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerHasOffersCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonOffer] DROP CONSTRAINT [FK_CustomerHasOffersCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerHasEmailTemplateEmailTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonEmailTemplate] DROP CONSTRAINT [FK_CustomerHasEmailTemplateEmailTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerHasOffersOffer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonOffer] DROP CONSTRAINT [FK_CustomerHasOffersOffer];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_CustomerContact];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactContactType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_ContactContactType];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPosition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Position] DROP CONSTRAINT [FK_PersonPosition];
GO
IF OBJECT_ID(N'[dbo].[FK_PositionPositionType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Position] DROP CONSTRAINT [FK_PositionPositionType];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonHobby]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hobby] DROP CONSTRAINT [FK_PersonHobby];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO
IF OBJECT_ID(N'[dbo].[PersonEmailTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonEmailTemplate];
GO
IF OBJECT_ID(N'[dbo].[ContactType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactType];
GO
IF OBJECT_ID(N'[dbo].[EmailTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailTemplate];
GO
IF OBJECT_ID(N'[dbo].[Hobby]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hobby];
GO
IF OBJECT_ID(N'[dbo].[Offer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offer];
GO
IF OBJECT_ID(N'[dbo].[PersonOffer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonOffer];
GO
IF OBJECT_ID(N'[dbo].[Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact];
GO
IF OBJECT_ID(N'[dbo].[Position]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Position];
GO
IF OBJECT_ID(N'[dbo].[PositionType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PositionType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Client'
CREATE TABLE [dbo].[Client] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(128)  NOT NULL,
    [BusinessNo] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(128)  NOT NULL,
    [LastName] nvarchar(256)  NOT NULL,
    [DBO] datetime  NOT NULL,
    [ClientId] int  NOT NULL
);
GO

-- Creating table 'PersonEmailTemplate'
CREATE TABLE [dbo].[PersonEmailTemplate] (
    [Id] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [EmailTemplateId] int  NOT NULL
);
GO

-- Creating table 'ContactType'
CREATE TABLE [dbo].[ContactType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'EmailTemplate'
CREATE TABLE [dbo].[EmailTemplate] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Body] nvarchar(1024)  NOT NULL,
    [Header] nvarchar(128)  NOT NULL,
    [Type] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Hobby'
CREATE TABLE [dbo].[Hobby] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(128)  NOT NULL,
    [PersonId] int  NOT NULL
);
GO

-- Creating table 'Offer'
CREATE TABLE [dbo].[Offer] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(128)  NOT NULL,
    [Description] nvarchar(1024)  NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NOT NULL
);
GO

-- Creating table 'PersonOffer'
CREATE TABLE [dbo].[PersonOffer] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OfferId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [Status] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'Contact'
CREATE TABLE [dbo].[Contact] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(128)  NOT NULL,
    [PersonId] int  NOT NULL,
    [ContactTypeId] int  NOT NULL
);
GO

-- Creating table 'Position'
CREATE TABLE [dbo].[Position] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PersonId] int  NOT NULL,
    [PositionTypeId] int  NOT NULL,
    [DateFrom] nvarchar(max)  NOT NULL,
    [DateTo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PositionType'
CREATE TABLE [dbo].[PositionType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonEmailTemplate'
ALTER TABLE [dbo].[PersonEmailTemplate]
ADD CONSTRAINT [PK_PersonEmailTemplate]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactType'
ALTER TABLE [dbo].[ContactType]
ADD CONSTRAINT [PK_ContactType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmailTemplate'
ALTER TABLE [dbo].[EmailTemplate]
ADD CONSTRAINT [PK_EmailTemplate]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Hobby'
ALTER TABLE [dbo].[Hobby]
ADD CONSTRAINT [PK_Hobby]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offer'
ALTER TABLE [dbo].[Offer]
ADD CONSTRAINT [PK_Offer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonOffer'
ALTER TABLE [dbo].[PersonOffer]
ADD CONSTRAINT [PK_PersonOffer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contact'
ALTER TABLE [dbo].[Contact]
ADD CONSTRAINT [PK_Contact]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Position'
ALTER TABLE [dbo].[Position]
ADD CONSTRAINT [PK_Position]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PositionType'
ALTER TABLE [dbo].[PositionType]
ADD CONSTRAINT [PK_PositionType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientId] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [FK_CustomerClient]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Client]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerClient'
CREATE INDEX [IX_FK_CustomerClient]
ON [dbo].[Person]
    ([ClientId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonEmailTemplate'
ALTER TABLE [dbo].[PersonEmailTemplate]
ADD CONSTRAINT [FK_CustomerHasEmailTemplateCustomer]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerHasEmailTemplateCustomer'
CREATE INDEX [IX_FK_CustomerHasEmailTemplateCustomer]
ON [dbo].[PersonEmailTemplate]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonOffer'
ALTER TABLE [dbo].[PersonOffer]
ADD CONSTRAINT [FK_CustomerHasOffersCustomer]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerHasOffersCustomer'
CREATE INDEX [IX_FK_CustomerHasOffersCustomer]
ON [dbo].[PersonOffer]
    ([PersonId]);
GO

-- Creating foreign key on [EmailTemplateId] in table 'PersonEmailTemplate'
ALTER TABLE [dbo].[PersonEmailTemplate]
ADD CONSTRAINT [FK_CustomerHasEmailTemplateEmailTemplate]
    FOREIGN KEY ([EmailTemplateId])
    REFERENCES [dbo].[EmailTemplate]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerHasEmailTemplateEmailTemplate'
CREATE INDEX [IX_FK_CustomerHasEmailTemplateEmailTemplate]
ON [dbo].[PersonEmailTemplate]
    ([EmailTemplateId]);
GO

-- Creating foreign key on [OfferId] in table 'PersonOffer'
ALTER TABLE [dbo].[PersonOffer]
ADD CONSTRAINT [FK_CustomerHasOffersOffer]
    FOREIGN KEY ([OfferId])
    REFERENCES [dbo].[Offer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerHasOffersOffer'
CREATE INDEX [IX_FK_CustomerHasOffersOffer]
ON [dbo].[PersonOffer]
    ([OfferId]);
GO

-- Creating foreign key on [PersonId] in table 'Contact'
ALTER TABLE [dbo].[Contact]
ADD CONSTRAINT [FK_CustomerContact]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerContact'
CREATE INDEX [IX_FK_CustomerContact]
ON [dbo].[Contact]
    ([PersonId]);
GO

-- Creating foreign key on [ContactTypeId] in table 'Contact'
ALTER TABLE [dbo].[Contact]
ADD CONSTRAINT [FK_ContactContactType]
    FOREIGN KEY ([ContactTypeId])
    REFERENCES [dbo].[ContactType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactContactType'
CREATE INDEX [IX_FK_ContactContactType]
ON [dbo].[Contact]
    ([ContactTypeId]);
GO

-- Creating foreign key on [PersonId] in table 'Position'
ALTER TABLE [dbo].[Position]
ADD CONSTRAINT [FK_PersonPosition]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPosition'
CREATE INDEX [IX_FK_PersonPosition]
ON [dbo].[Position]
    ([PersonId]);
GO

-- Creating foreign key on [PositionTypeId] in table 'Position'
ALTER TABLE [dbo].[Position]
ADD CONSTRAINT [FK_PositionPositionType]
    FOREIGN KEY ([PositionTypeId])
    REFERENCES [dbo].[PositionType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionPositionType'
CREATE INDEX [IX_FK_PositionPositionType]
ON [dbo].[Position]
    ([PositionTypeId]);
GO

-- Creating foreign key on [PersonId] in table 'Hobby'
ALTER TABLE [dbo].[Hobby]
ADD CONSTRAINT [FK_PersonHobby]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonHobby'
CREATE INDEX [IX_FK_PersonHobby]
ON [dbo].[Hobby]
    ([PersonId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------