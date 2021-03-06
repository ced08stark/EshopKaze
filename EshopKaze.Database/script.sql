USE [EshopKaze]
GO
ALTER TABLE [dbo].[Category] DROP CONSTRAINT [FK_Categorie_Categorie]
GO
/****** Object:  Index [IX_Categorie]    Script Date: 13/03/2022 03:11:32 ******/
ALTER TABLE [dbo].[Category] DROP CONSTRAINT [IX_Categorie]
GO
/****** Object:  Table [dbo].[User]    Script Date: 13/03/2022 03:11:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 13/03/2022 03:11:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 13/03/2022 03:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 13/03/2022 03:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categorie]    Script Date: 13/03/2022 03:11:33 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [IX_Categorie] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Categorie_Categorie] FOREIGN KEY([Name])
REFERENCES [dbo].[Category] ([Name])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Categorie_Categorie]
GO
