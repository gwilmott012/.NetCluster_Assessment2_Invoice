USE [master]
GO
/****** Object:  Database [Activity12Invoices]    Script Date: 05/15/2017 18:39:18 ******/
CREATE DATABASE [Activity12Invoices] ON  PRIMARY 
( NAME = N'Activity12Invoices', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Activity12Invoices.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Activity12Invoices_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Activity12Invoices_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Activity12Invoices] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Activity12Invoices].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Activity12Invoices] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Activity12Invoices] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Activity12Invoices] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Activity12Invoices] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Activity12Invoices] SET ARITHABORT OFF
GO
ALTER DATABASE [Activity12Invoices] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Activity12Invoices] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Activity12Invoices] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Activity12Invoices] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Activity12Invoices] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Activity12Invoices] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Activity12Invoices] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Activity12Invoices] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Activity12Invoices] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Activity12Invoices] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Activity12Invoices] SET  DISABLE_BROKER
GO
ALTER DATABASE [Activity12Invoices] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Activity12Invoices] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Activity12Invoices] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Activity12Invoices] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Activity12Invoices] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Activity12Invoices] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Activity12Invoices] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Activity12Invoices] SET  READ_WRITE
GO
ALTER DATABASE [Activity12Invoices] SET RECOVERY FULL
GO
ALTER DATABASE [Activity12Invoices] SET  MULTI_USER
GO
ALTER DATABASE [Activity12Invoices] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Activity12Invoices] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Activity12Invoices', N'ON'
GO
USE [Activity12Invoices]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 05/15/2017 18:39:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[CreatedTS] [timestamp] NOT NULL,
 CONSTRAINT [pk_CustomnerID] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 05/15/2017 18:39:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cost] [float] NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[Payment_Date] [date] NOT NULL,
	[Customer_Id] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [pk_InvoiceID] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__Customers__IsDel__0F975522]    Script Date: 05/15/2017 18:39:19 ******/
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF__Customers__Creat__108B795B]    Script Date: 05/15/2017 18:39:19 ******/
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF__Invoices__IsDele__145C0A3F]    Script Date: 05/15/2017 18:39:19 ******/
ALTER TABLE [dbo].[Invoices] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF__Invoices__Create__15502E78]    Script Date: 05/15/2017 18:39:19 ******/
ALTER TABLE [dbo].[Invoices] ADD  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  ForeignKey [FK_Invoices_Customers_Customer_Id]    Script Date: 05/15/2017 18:39:19 ******/
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Customers_Customer_Id] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Customers_Customer_Id]
GO
