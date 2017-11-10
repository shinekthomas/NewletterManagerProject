
--IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'NewsletterDB')
--	CREATE DATABASE NewsletterDB;

--GO

USE [NewsletterDB]
GO

/****** Object:  Table [dbo].[Newsletter]    Script Date: 2017-11-10 10:51:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Newsletter](
	[NewsletterId] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [varchar](100) NOT NULL UNIQUE,
	[HowHeardAboutUs] [int] NOT NULL,
	[Reason] [nvarchar](250) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_Newsletter] PRIMARY KEY CLUSTERED 
(
	[NewsletterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO