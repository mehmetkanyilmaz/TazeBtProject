USE [master]
GO
/****** Object:  Database [TazeBt]    Script Date: 22.05.2022 22:28:59 ******/
CREATE DATABASE [TazeBt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TazeBt', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TazeBt.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TazeBt_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TazeBt_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TazeBt] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TazeBt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TazeBt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TazeBt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TazeBt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TazeBt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TazeBt] SET ARITHABORT OFF 
GO
ALTER DATABASE [TazeBt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TazeBt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TazeBt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TazeBt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TazeBt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TazeBt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TazeBt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TazeBt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TazeBt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TazeBt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TazeBt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TazeBt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TazeBt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TazeBt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TazeBt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TazeBt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TazeBt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TazeBt] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TazeBt] SET  MULTI_USER 
GO
ALTER DATABASE [TazeBt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TazeBt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TazeBt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TazeBt] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TazeBt] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TazeBt] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TazeBt] SET QUERY_STORE = OFF
GO
USE [TazeBt]
GO
/****** Object:  Table [dbo].[ArticleCategories]    Script Date: 22.05.2022 22:29:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ArticleCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 22.05.2022 22:29:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[Contents] [nvarchar](max) NOT NULL,
	[CUser] [int] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 22.05.2022 22:29:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Contents] [nvarchar](max) NOT NULL,
	[CUser] [int] NOT NULL,
	[CDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22.05.2022 22:29:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Adress] [nchar](10) NOT NULL,
	[Birtday] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ArticleCategories] ON 

INSERT [dbo].[ArticleCategories] ([Id], [ArticleId], [Name]) VALUES (1, 2, N'Yazılım')
INSERT [dbo].[ArticleCategories] ([Id], [ArticleId], [Name]) VALUES (2, 2, N'Backend')
INSERT [dbo].[ArticleCategories] ([Id], [ArticleId], [Name]) VALUES (3, 3, N'Yazılım')
INSERT [dbo].[ArticleCategories] ([Id], [ArticleId], [Name]) VALUES (4, 3, N'Frontend')
INSERT [dbo].[ArticleCategories] ([Id], [ArticleId], [Name]) VALUES (5, 5, N'Doğa')
SET IDENTITY_INSERT [dbo].[ArticleCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [Title], [Date], [Contents], [CUser]) VALUES (2, N'YAZI 1', CAST(N'2022-05-16T00:00:00' AS SmallDateTime), N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 1)
INSERT [dbo].[Articles] ([Id], [Title], [Date], [Contents], [CUser]) VALUES (3, N'YAZI 2', CAST(N'2022-05-16T00:00:00' AS SmallDateTime), N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 1)
INSERT [dbo].[Articles] ([Id], [Title], [Date], [Contents], [CUser]) VALUES (5, N'YAZI 3', CAST(N'2022-05-19T00:00:00' AS SmallDateTime), N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 1)
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [ArticleId], [Contents], [CUser], [CDate]) VALUES (18, 2, N'Merhaba', 1, CAST(N'2022-05-22T22:13:00' AS SmallDateTime))
INSERT [dbo].[Comments] ([Id], [ArticleId], [Contents], [CUser], [CDate]) VALUES (19, 2, N'Deneme Yorum...', 1, CAST(N'2022-05-22T22:14:00' AS SmallDateTime))
INSERT [dbo].[Comments] ([Id], [ArticleId], [Contents], [CUser], [CDate]) VALUES (20, 3, N'Yorum 1', 1, CAST(N'2022-05-22T22:18:00' AS SmallDateTime))
INSERT [dbo].[Comments] ([Id], [ArticleId], [Contents], [CUser], [CDate]) VALUES (21, 3, N'Yorum 2', 1, CAST(N'2022-05-22T22:18:00' AS SmallDateTime))
INSERT [dbo].[Comments] ([Id], [ArticleId], [Contents], [CUser], [CDate]) VALUES (22, 3, N'Yorum 3', 1, CAST(N'2022-05-22T22:18:00' AS SmallDateTime))
INSERT [dbo].[Comments] ([Id], [ArticleId], [Contents], [CUser], [CDate]) VALUES (23, 5, N'Yorum', 1, CAST(N'2022-05-22T22:22:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [Adress], [Birtday]) VALUES (1, N'Mehmet', N'Kanyılmaz', N'mehmetkanyilmaz@outlook.com.tr', N'1234', N'Sakarya   ', CAST(N'1996-05-31T00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [TazeBt] SET  READ_WRITE 
GO
