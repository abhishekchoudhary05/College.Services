/****** Object:  Table [dbo].[Employees]    Script Date: 11/18/2020 2:37:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NULL,
	[Gender] [varchar](50) NULL,
	[Salary] [numeric](18, 2) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employee_Id]  DEFAULT (newid()) FOR [Id]
GO


