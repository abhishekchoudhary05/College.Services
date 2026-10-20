-- Database Creation
CREATE DATABASE CollegeServices;
GO

USE CollegeServices;
GO

/****** Object:  Table [dbo].[Professors]    Script Date: 2026-10-20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Professors](
	[Id] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
	[Name] [varchar](100) NOT NULL,
	[Doj] [datetime] NOT NULL DEFAULT GETDATE(),
	[Teaches] [varchar](200) NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL DEFAULT 0.00,
	[IsPhd] [bit] NOT NULL DEFAULT 0,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Department] [varchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL DEFAULT GETDATE(),
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Create Index on Department for better query performance
CREATE NONCLUSTERED INDEX [IX_Professors_Department] ON [dbo].[Professors]
(
	[Department] ASC
) ON [PRIMARY]
GO

-- Create Index on Name for search operations
CREATE NONCLUSTERED INDEX [IX_Professors_Name] ON [dbo].[Professors]
(
	[Name] ASC
) ON [PRIMARY]
GO
