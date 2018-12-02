
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/01/2018 18:19:10
-- Generated from EDMX file: C:\Users\Admin\CursoMVC2018\SlnInventario\Inventario\Models\modeloInventario.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbInventario];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tblProductos_tblCategorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductos] DROP CONSTRAINT [FK_tblProductos_tblCategorias];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tblCategorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCategorias];
GO
IF OBJECT_ID(N'[dbo].[tblProductos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProductos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tblCategorias'
CREATE TABLE [dbo].[tblCategorias] (
    [idCategoria] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(50)  NOT NULL,
    [descripcion] nvarchar(50)  NOT NULL,
    [esActivo] bit  NOT NULL
);
GO

-- Creating table 'tblProductos'
CREATE TABLE [dbo].[tblProductos] (
    [idProducto] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(50)  NOT NULL,
    [descripcion] varchar(max)  NOT NULL,
    [cantidad] int  NOT NULL,
    [marca] nvarchar(50)  NOT NULL,
    [fechaCreacion] datetime  NOT NULL,
    [idCategoria] int  NOT NULL,
    [esActivo] bit  NOT NULL,
    [unidadMedida] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idCategoria] in table 'tblCategorias'
ALTER TABLE [dbo].[tblCategorias]
ADD CONSTRAINT [PK_tblCategorias]
    PRIMARY KEY CLUSTERED ([idCategoria] ASC);
GO

-- Creating primary key on [idProducto] in table 'tblProductos'
ALTER TABLE [dbo].[tblProductos]
ADD CONSTRAINT [PK_tblProductos]
    PRIMARY KEY CLUSTERED ([idProducto] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idCategoria] in table 'tblProductos'
ALTER TABLE [dbo].[tblProductos]
ADD CONSTRAINT [FK_tblProductos_tblCategorias]
    FOREIGN KEY ([idCategoria])
    REFERENCES [dbo].[tblCategorias]
        ([idCategoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductos_tblCategorias'
CREATE INDEX [IX_FK_tblProductos_tblCategorias]
ON [dbo].[tblProductos]
    ([idCategoria]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------