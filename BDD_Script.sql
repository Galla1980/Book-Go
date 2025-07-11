USE [master]
GO
/****** Object:  Database [SistemaBiblioteca]    Script Date: 26/6/2025 00:42:50 ******/
CREATE DATABASE [SistemaBiblioteca]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaBiblioteca', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SistemaBiblioteca.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SistemaBiblioteca_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SistemaBiblioteca_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SistemaBiblioteca] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaBiblioteca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaBiblioteca] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaBiblioteca] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaBiblioteca] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SistemaBiblioteca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaBiblioteca] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET RECOVERY FULL 
GO
ALTER DATABASE [SistemaBiblioteca] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaBiblioteca] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaBiblioteca] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaBiblioteca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaBiblioteca] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SistemaBiblioteca] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SistemaBiblioteca] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SistemaBiblioteca', N'ON'
GO
ALTER DATABASE [SistemaBiblioteca] SET QUERY_STORE = ON
GO
ALTER DATABASE [SistemaBiblioteca] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SistemaBiblioteca]
GO
/****** Object:  Table [dbo].[Cliente_327LG]    Script Date: 26/6/2025 00:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente_327LG](
	[DNI_327LG] [nvarchar](8) NOT NULL,
	[Nombre_327LG] [nvarchar](50) NOT NULL,
	[Apellido_327LG] [nvarchar](50) NOT NULL,
	[Email_327LG] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Cliente_327LG] PRIMARY KEY CLUSTERED 
(
	[DNI_327LG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ejemplar_327LG]    Script Date: 26/6/2025 00:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ejemplar_327LG](
	[nroEJemplar_327LG] [int] IDENTITY(1,1) NOT NULL,
	[Estado_327LG] [nvarchar](15) NOT NULL,
	[ISBN_327LG] [nvarchar](13) NOT NULL,
 CONSTRAINT [PK_Ejemplar_327LG] PRIMARY KEY CLUSTERED 
(
	[nroEJemplar_327LG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura_327LG]    Script Date: 26/6/2025 00:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura_327LG](
	[nroFactura] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_327LG] [datetime] NOT NULL,
	[DNI_327LG] [nvarchar](8) NOT NULL,
	[Monto_327LG] [decimal](18, 2) NOT NULL,
	[ISBN_327LG] [nvarchar](13) NOT NULL,
 CONSTRAINT [PK_Factura_327LG] PRIMARY KEY CLUSTERED 
(
	[nroFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro_327LG]    Script Date: 26/6/2025 00:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro_327LG](
	[ISBN_327LG] [nvarchar](13) NOT NULL,
	[Titulo_327LG] [nvarchar](150) NOT NULL,
	[Autor_327LG] [nvarchar](100) NOT NULL,
	[Edicion_327LG] [int] NOT NULL,
	[Editorial_327LG] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Libro_327LG] PRIMARY KEY CLUSTERED 
(
	[ISBN_327LG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prestamo_327LG]    Script Date: 26/6/2025 00:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamo_327LG](
	[nroPrestamo_327LG] [int] IDENTITY(1,1) NOT NULL,
	[FechaDevolucion_327LG] [date] NULL,
	[FechaADevolver_327LG] [date] NOT NULL,
	[nroEjemplar_327LG] [int] NOT NULL,
	[Activo_327LG] [bit] NOT NULL,
	[DNI_327LG] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Prestamo_327LG] PRIMARY KEY CLUSTERED 
(
	[nroPrestamo_327LG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sancion_327LG]    Script Date: 26/6/2025 00:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sancion_327LG](
	[nroSancion_327LG] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion_327LG] [nvarchar](max) NOT NULL,
	[Razon_327LG] [nvarchar](20) NOT NULL,
	[nroPrestamo_327LG] [int] NOT NULL,
	[DNI_327LG] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Sancion_327LG] PRIMARY KEY CLUSTERED 
(
	[nroSancion_327LG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_327LG]    Script Date: 26/6/2025 00:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_327LG](
	[DNI_327LG] [nvarchar](10) NOT NULL,
	[Apellido_327LG] [nvarchar](25) NOT NULL,
	[Nombre_327LG] [nvarchar](25) NOT NULL,
	[Username_327LG] [nvarchar](20) NOT NULL,
	[Password_327LG] [nvarchar](64) NOT NULL,
	[Rol_327LG] [nvarchar](20) NOT NULL,
	[Email_327LG] [nvarchar](30) NOT NULL,
	[Bloqueado_327LG] [bit] NOT NULL,
	[Activo_327LG] [bit] NOT NULL,
	[Intento_327LG] [int] NOT NULL,
	[IdiomaPref_327LG] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Usuario_327LG] PRIMARY KEY CLUSTERED 
(
	[DNI_327LG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cliente_327LG] ([DNI_327LG], [Nombre_327LG], [Apellido_327LG], [Email_327LG]) VALUES (N'12345678', N'Santino', N'Olivola', N'Kz5cqwfVmw+tNrz9WpLmodbcbVtagxQkfLvord2Wwgw=')
INSERT [dbo].[Cliente_327LG] ([DNI_327LG], [Nombre_327LG], [Apellido_327LG], [Email_327LG]) VALUES (N'45823327', N'Lucas', N'Gallardo', N'Z4jhhUw3e2Th1lrhS2FPITiERn/4FNt8/kxB9dP+vCU=')
GO
SET IDENTITY_INSERT [dbo].[Ejemplar_327LG] ON 

INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (13, N'Disponible', N'9780345538376')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (14, N'Disponible', N'9780345538376')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (15, N'Disponible', N'9780345538376')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (16, N'Disponible', N'9780345538376')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (17, N'Disponible', N'9780345538376')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (18, N'Disponible', N'9780553106633')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (19, N'Disponible', N'9780553106633')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (20, N'Disponible', N'9780553106633')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (21, N'Disponible', N'9780553106633')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (22, N'Disponible', N'9780553106633')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (23, N'Disponible', N'9788413142345')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (24, N'Disponible', N'9788413142345')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (25, N'Disponible', N'9788413142345')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (26, N'Disponible', N'9788413142345')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (27, N'Disponible', N'9788413142345')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (28, N'Disponible', N'9788426418174')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (29, N'Disponible', N'9788426418174')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (30, N'Disponible', N'9788426418174')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (31, N'Disponible', N'9788426418174')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (32, N'Disponible', N'9788426418174')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (33, N'Disponible', N'9788437622096')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (34, N'Disponible', N'9788437622096')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (35, N'Disponible', N'9788437622096')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (36, N'Disponible', N'9788437622096')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (37, N'Disponible', N'9788437622096')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (38, N'Disponible', N'9788478887194')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (39, N'Disponible', N'9788478887194')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (40, N'Disponible', N'9788478887194')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (41, N'Disponible', N'9788478887194')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (42, N'Disponible', N'9788478887194')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (43, N'Disponible', N'9788497592208')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (44, N'Disponible', N'9788497592208')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (45, N'Disponible', N'9788497592208')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (46, N'Disponible', N'9788497592208')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (47, N'Disponible', N'9788497592208')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (48, N'Disponible', N'9788497931353')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (49, N'Disponible', N'9788497931353')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (50, N'Disponible', N'9788497931353')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (51, N'Disponible', N'9788497931353')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (52, N'Disponible', N'9788497931353')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (53, N'Disponible', N'9789500720413')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (54, N'Disponible', N'9789500720413')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (55, N'Disponible', N'9789500720413')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (56, N'Disponible', N'9789500720413')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (57, N'Disponible', N'9789875668104')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (58, N'Disponible', N'9789875668104')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (59, N'Disponible', N'9789875668104')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (60, N'Disponible', N'9789875668104')
INSERT [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG], [Estado_327LG], [ISBN_327LG]) VALUES (61, N'Disponible', N'9789875668104')
SET IDENTITY_INSERT [dbo].[Ejemplar_327LG] OFF
GO
INSERT [dbo].[Libro_327LG] ([ISBN_327LG], [Titulo_327LG], [Autor_327LG], [Edicion_327LG], [Editorial_327LG]) VALUES (N'9780345538376', N'El Nombre del Viento', N'Patrick Rothfuss', 1, N'Plaza & Janés')
INSERT [dbo].[Libro_327LG] ([ISBN_327LG], [Titulo_327LG], [Autor_327LG], [Edicion_327LG], [Editorial_327LG]) VALUES (N'9780553106633', N'Juego de Tronos', N'George R.R. Martin', 1, N'Bantam Books')
INSERT [dbo].[Libro_327LG] ([ISBN_327LG], [Titulo_327LG], [Autor_327LG], [Edicion_327LG], [Editorial_327LG]) VALUES (N'9788413142345', N'Sapiens: De animales a dioses', N'Yuval Noah Harari', 2, N'Debate')
INSERT [dbo].[Libro_327LG] ([ISBN_327LG], [Titulo_327LG], [Autor_327LG], [Edicion_327LG], [Editorial_327LG]) VALUES (N'9788426418174', N'Cien años de soledad', N'Gabriel García Márquez', 6, N'Sudamericana')
INSERT [dbo].[Libro_327LG] ([ISBN_327LG], [Titulo_327LG], [Autor_327LG], [Edicion_327LG], [Editorial_327LG]) VALUES (N'9788437622096', N'La Odisea', N'Homero', 4, N'Cátedra')
INSERT [dbo].[Libro_327LG] ([ISBN_327LG], [Titulo_327LG], [Autor_327LG], [Edicion_327LG], [Editorial_327LG]) VALUES (N'9788478887194', N'Harry Potter y la piedra filosofal', N'J.K. Rowling', 1, N'Salamandra')
INSERT [dbo].[Libro_327LG] ([ISBN_327LG], [Titulo_327LG], [Autor_327LG], [Edicion_327LG], [Editorial_327LG]) VALUES (N'9788497592208', N'La Metamorfosis', N'Franz Kafka', 2, N'Alianza Editorial')
INSERT [dbo].[Libro_327LG] ([ISBN_327LG], [Titulo_327LG], [Autor_327LG], [Edicion_327LG], [Editorial_327LG]) VALUES (N'9788497931353', N'1984', N'George Orwell', 3, N'Debolsillo')
INSERT [dbo].[Libro_327LG] ([ISBN_327LG], [Titulo_327LG], [Autor_327LG], [Edicion_327LG], [Editorial_327LG]) VALUES (N'9789500720413', N'Don Quijote de la Mancha', N'Miguel de Cervantes', 5, N'Losada')
INSERT [dbo].[Libro_327LG] ([ISBN_327LG], [Titulo_327LG], [Autor_327LG], [Edicion_327LG], [Editorial_327LG]) VALUES (N'9789875668104', N'La sombra del viento', N'Carlos Ruiz Zafón', 1, N'Planeta')
GO
INSERT [dbo].[Usuario_327LG] ([DNI_327LG], [Apellido_327LG], [Nombre_327LG], [Username_327LG], [Password_327LG], [Rol_327LG], [Email_327LG], [Bloqueado_327LG], [Activo_327LG], [Intento_327LG], [IdiomaPref_327LG]) VALUES (N'11111111', N'Admin', N'Admin', N'Admin', N'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', N'Admin', N'Admin@gmail.com', 0, 1, 0, N'spanish')
INSERT [dbo].[Usuario_327LG] ([DNI_327LG], [Apellido_327LG], [Nombre_327LG], [Username_327LG], [Password_327LG], [Rol_327LG], [Email_327LG], [Bloqueado_327LG], [Activo_327LG], [Intento_327LG], [IdiomaPref_327LG]) VALUES (N'45236234', N'Lockett', N'Tomas', N'45236234Tomas', N'7b02d12354102aa097894503dd0b617f0d656a7332b0db29d52b27c189b86d88', N'Bibliotecario', N'TomasLockett@gmail.com', 0, 1, 0, N'spanish')
INSERT [dbo].[Usuario_327LG] ([DNI_327LG], [Apellido_327LG], [Nombre_327LG], [Username_327LG], [Password_327LG], [Rol_327LG], [Email_327LG], [Bloqueado_327LG], [Activo_327LG], [Intento_327LG], [IdiomaPref_327LG]) VALUES (N'45823326', N'Felix', N'Joaquin', N'45823326Joaquin', N'28e9d728e85146efdf1c4af986ec626e51ffd6503542563949815a019f290fa5', N'Repositor', N'JoaquinFelix@gmail.com', 0, 1, 0, N'spanish')
INSERT [dbo].[Usuario_327LG] ([DNI_327LG], [Apellido_327LG], [Nombre_327LG], [Username_327LG], [Password_327LG], [Rol_327LG], [Email_327LG], [Bloqueado_327LG], [Activo_327LG], [Intento_327LG], [IdiomaPref_327LG]) VALUES (N'45823327', N'Gallardo', N'Lucas', N'45823327Lucas', N'63ebbeea5c0ba0e7cd414ec4bf17ed940d766a229f0639d2d23cf393b8d3573a', N'Bibliotecario', N'lucasgallardo@gmail.com', 0, 1, 0, N'english')
INSERT [dbo].[Usuario_327LG] ([DNI_327LG], [Apellido_327LG], [Nombre_327LG], [Username_327LG], [Password_327LG], [Rol_327LG], [Email_327LG], [Bloqueado_327LG], [Activo_327LG], [Intento_327LG], [IdiomaPref_327LG]) VALUES (N'45823328', N'Gallardo', N'Lucas', N'45823328Lucas', N'656bf71a4c0700dd3fbe436640ff9712c343e0a242b5fde7c1081ee42dfd35e7', N'Bibliotecario', N'werewrewr', 0, 1, 0, N'spanish')
GO
ALTER TABLE [dbo].[Usuario_327LG] ADD  CONSTRAINT [DF_Usuario_327LG_IdiomaPref_327LG]  DEFAULT ('Español') FOR [IdiomaPref_327LG]
GO
ALTER TABLE [dbo].[Ejemplar_327LG]  WITH CHECK ADD  CONSTRAINT [FK_Ejemplar_327LG_Libro_327LG] FOREIGN KEY([ISBN_327LG])
REFERENCES [dbo].[Libro_327LG] ([ISBN_327LG])
GO
ALTER TABLE [dbo].[Ejemplar_327LG] CHECK CONSTRAINT [FK_Ejemplar_327LG_Libro_327LG]
GO
ALTER TABLE [dbo].[Factura_327LG]  WITH CHECK ADD  CONSTRAINT [FK_Factura_327LG_Cliente_327LG] FOREIGN KEY([DNI_327LG])
REFERENCES [dbo].[Cliente_327LG] ([DNI_327LG])
GO
ALTER TABLE [dbo].[Factura_327LG] CHECK CONSTRAINT [FK_Factura_327LG_Cliente_327LG]
GO
ALTER TABLE [dbo].[Factura_327LG]  WITH CHECK ADD  CONSTRAINT [FK_Factura_327LG_Libro_327LG] FOREIGN KEY([ISBN_327LG])
REFERENCES [dbo].[Libro_327LG] ([ISBN_327LG])
GO
ALTER TABLE [dbo].[Factura_327LG] CHECK CONSTRAINT [FK_Factura_327LG_Libro_327LG]
GO
ALTER TABLE [dbo].[Prestamo_327LG]  WITH CHECK ADD  CONSTRAINT [FK_Prestamo_327LG_Cliente_327LG] FOREIGN KEY([DNI_327LG])
REFERENCES [dbo].[Cliente_327LG] ([DNI_327LG])
GO
ALTER TABLE [dbo].[Prestamo_327LG] CHECK CONSTRAINT [FK_Prestamo_327LG_Cliente_327LG]
GO
ALTER TABLE [dbo].[Prestamo_327LG]  WITH CHECK ADD  CONSTRAINT [FK_Prestamo_327LG_Ejemplar_327LG] FOREIGN KEY([nroEjemplar_327LG])
REFERENCES [dbo].[Ejemplar_327LG] ([nroEJemplar_327LG])
GO
ALTER TABLE [dbo].[Prestamo_327LG] CHECK CONSTRAINT [FK_Prestamo_327LG_Ejemplar_327LG]
GO
ALTER TABLE [dbo].[Sancion_327LG]  WITH CHECK ADD  CONSTRAINT [FK_Sancion_327LG_Cliente_327LG] FOREIGN KEY([DNI_327LG])
REFERENCES [dbo].[Cliente_327LG] ([DNI_327LG])
GO
ALTER TABLE [dbo].[Sancion_327LG] CHECK CONSTRAINT [FK_Sancion_327LG_Cliente_327LG]
GO
ALTER TABLE [dbo].[Sancion_327LG]  WITH CHECK ADD  CONSTRAINT [FK_Sancion_327LG_Prestamo_327LG] FOREIGN KEY([nroPrestamo_327LG])
REFERENCES [dbo].[Prestamo_327LG] ([nroPrestamo_327LG])
GO
ALTER TABLE [dbo].[Sancion_327LG] CHECK CONSTRAINT [FK_Sancion_327LG_Prestamo_327LG]
GO
USE [master]
GO
ALTER DATABASE [SistemaBiblioteca] SET  READ_WRITE 
GO
