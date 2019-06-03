USE [master]
GO
/****** Object:  Database [Warehause2]    Script Date: 04.03.2019 10:23:53 ******/
CREATE DATABASE [Warehause2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Warehause2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Warehause2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Warehause2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Warehause2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Warehause2] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Warehause2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Warehause2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Warehause2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Warehause2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Warehause2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Warehause2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Warehause2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Warehause2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Warehause2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Warehause2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Warehause2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Warehause2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Warehause2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Warehause2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Warehause2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Warehause2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Warehause2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Warehause2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Warehause2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Warehause2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Warehause2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Warehause2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Warehause2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Warehause2] SET RECOVERY FULL 
GO
ALTER DATABASE [Warehause2] SET  MULTI_USER 
GO
ALTER DATABASE [Warehause2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Warehause2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Warehause2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Warehause2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Warehause2] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Warehause2', N'ON'
GO
ALTER DATABASE [Warehause2] SET QUERY_STORE = OFF
GO
USE [Warehause2]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 04.03.2019 10:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ID_Client] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Addres] [varchar](50) NOT NULL,
	[Phone_number] [nchar](11) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ID_Client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 04.03.2019 10:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[ID_Member] [int] IDENTITY(1,1) NOT NULL,
	[First_name] [nchar](30) NOT NULL,
	[Second_name] [nchar](30) NULL,
	[Surname] [nchar](30) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Addres] [nchar](50) NOT NULL,
	[Phone_number] [nchar](11) NOT NULL,
	[Passport] [varchar](10) NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[ID_Member] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Passport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 04.03.2019 10:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID_Product] [int] IDENTITY(1,1) NOT NULL,
	[ID_Type] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ID_Provider] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 04.03.2019 10:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Providers](
	[ID_Provider] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Addres] [varchar](50) NOT NULL,
	[Phone_number] [nchar](11) NOT NULL,
 CONSTRAINT [PK_Providers] PRIMARY KEY CLUSTERED 
(
	[ID_Provider] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storage]    Script Date: 04.03.2019 10:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage](
	[ID_Storage] [int] IDENTITY(1,1) NOT NULL,
	[ID_Product] [int] NOT NULL,
	[ID_Client] [int] NOT NULL,
	[ID_Member] [int] NOT NULL,
	[Date_of_order] [date] NOT NULL,
	[Date_of_arrival] [date] NOT NULL,
	[Volume] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
(
	[ID_Storage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 04.03.2019 10:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[ID_Type] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[ID_Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Providers] FOREIGN KEY([ID_Provider])
REFERENCES [dbo].[Providers] ([ID_Provider])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Providers]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Types] FOREIGN KEY([ID_Type])
REFERENCES [dbo].[Types] ([ID_Type])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Types]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_Clients] FOREIGN KEY([ID_Client])
REFERENCES [dbo].[Clients] ([ID_Client])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_Clients]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_Members] FOREIGN KEY([ID_Member])
REFERENCES [dbo].[Members] ([ID_Member])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_Members]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_Products] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Products] ([ID_Product])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_Products]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [CK_Clients_Phone_number] CHECK  (([Phone_number] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [CK_Clients_Phone_number]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [CK_Members_Birthday] CHECK  (([Birthday]>='1940-01-01' AND [Birthday]<='2040-01-01'))
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [CK_Members_Birthday]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [CK_Members_Phone_number] CHECK  (([Phone_number] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [CK_Members_Phone_number]
GO
ALTER TABLE [dbo].[Providers]  WITH CHECK ADD  CONSTRAINT [CK_Providers_Phone_number] CHECK  (([Phone_number] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Providers] CHECK CONSTRAINT [CK_Providers_Phone_number]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [CK_Storage_Date_of_arrival] CHECK  (([Date_of_arrival]>=[Date_of_order]))
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [CK_Storage_Date_of_arrival]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [CK_Storage_Date_of_order] CHECK  (([Date_of_order]>='1960-01-01' AND [Date_of_order]<=CONVERT([date],getdate())))
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [CK_Storage_Date_of_order]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [CK_Storage_Price] CHECK  (([Price]>(0)))
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [CK_Storage_Price]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [CK_Storage_Volume] CHECK  (([Volume]>(0)))
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [CK_Storage_Volume]
GO
USE [master]
GO
ALTER DATABASE [Warehause2] SET  READ_WRITE 
GO
