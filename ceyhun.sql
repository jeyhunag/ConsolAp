USE [master]
GO
/****** Object:  Database [Employe data tracking working time]    Script Date: 8/4/2022 9:33:09 PM ******/
CREATE DATABASE [Employe data tracking working time]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Employe data tracking working time', FILENAME = N'C:\Sql\MSSQL15.SQLEXPRESS\MSSQL\DATA\Employe data tracking working time.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Employe data tracking working time_log', FILENAME = N'C:\Sql\MSSQL15.SQLEXPRESS\MSSQL\DATA\Employe data tracking working time_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Employe data tracking working time] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Employe data tracking working time].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Employe data tracking working time] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET ARITHABORT OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Employe data tracking working time] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Employe data tracking working time] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Employe data tracking working time] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Employe data tracking working time] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Employe data tracking working time] SET  MULTI_USER 
GO
ALTER DATABASE [Employe data tracking working time] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Employe data tracking working time] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Employe data tracking working time] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Employe data tracking working time] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Employe data tracking working time] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Employe data tracking working time] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Employe data tracking working time] SET QUERY_STORE = OFF
GO
USE [Employe data tracking working time]
GO
/****** Object:  Table [dbo].[PersonelInfor]    Script Date: 8/4/2022 9:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonelInfor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WorkNumber] [int] NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[Surname] [varchar](25) NOT NULL,
	[Position] [varchar](15) NOT NULL,
	[DateOfEmployment] [date] NOT NULL,
	[WageRate] [float] NOT NULL,
	[MontlyWorkingTime] [int] NOT NULL,
 CONSTRAINT [PK_PersonelInfor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkTimeInformation]    Script Date: 8/4/2022 9:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkTimeInformation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[WorkerNumberr] [int] NOT NULL,
	[WorkDay] [int] NOT NULL,
	[Introductionthour] [int] NOT NULL,
	[IntroductionMinute] [int] NOT NULL,
	[Exithour] [int] NOT NULL,
	[ExitMinute] [int] NOT NULL,
 CONSTRAINT [PK_WorkTimeInformation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Employe data tracking working time] SET  READ_WRITE 
GO
