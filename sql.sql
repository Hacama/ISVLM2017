USE [master]
GO
/****** Object:  Database [BD_Agencia]    Script Date: 16/01/2018 06:48:39 p.m. ******/
CREATE DATABASE [BD_Agencia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_Agencia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\BD_Agencia.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BD_Agencia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\BD_Agencia_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BD_Agencia] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_Agencia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_Agencia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_Agencia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_Agencia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_Agencia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_Agencia] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_Agencia] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BD_Agencia] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BD_Agencia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_Agencia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_Agencia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_Agencia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_Agencia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_Agencia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_Agencia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_Agencia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_Agencia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_Agencia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_Agencia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_Agencia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_Agencia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_Agencia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_Agencia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_Agencia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_Agencia] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_Agencia] SET  MULTI_USER 
GO
ALTER DATABASE [BD_Agencia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_Agencia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_Agencia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_Agencia] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BD_Agencia]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[SP_INSERTAR]

@DATE DATE,
@C INT,
@T INT,
@P21 INT,
@G INT,
@D INT,
@O INT,
@B INT,
@CRR INT
AS
BEGIN

update [dbo].[TB_STOCK_TRANSACCION]
set stocktransaccion_cero =@C
where
stocktransaccion_transaccion =2
and stocktransaccion_fecha = @DATE
and stock_id = '700022'

update [dbo].[TB_STOCK_TRANSACCION]
set stocktransaccion_cero =@T
where
stocktransaccion_transaccion =2
and stocktransaccion_fecha =@DATE
and stock_id = '700062'

update [dbo].[TB_STOCK_TRANSACCION]
set stocktransaccion_cero =@P21
where
stocktransaccion_transaccion =2
and stocktransaccion_fecha =@DATE
and stock_id = '700041'

update [dbo].[TB_STOCK_TRANSACCION]
set stocktransaccion_cero =@G
where
stocktransaccion_transaccion =2
and stocktransaccion_fecha =@DATE
and stock_id = '700036'


update [dbo].[TB_STOCK_TRANSACCION]
set stocktransaccion_cero =@D
where
stocktransaccion_transaccion =2
and stocktransaccion_fecha =@DATE
and stock_id = '700001'


update [dbo].[TB_STOCK_TRANSACCION]
set stocktransaccion_cero =@O
where
stocktransaccion_transaccion =2
and stocktransaccion_fecha =@DATE
and stock_id = '700868'

update [dbo].[TB_STOCK_TRANSACCION]
set stocktransaccion_cero =@B
where
stocktransaccion_transaccion =2
and stocktransaccion_fecha =@DATE
and stock_id = '700840'

update [dbo].[TB_STOCK_TRANSACCION]
set stocktransaccion_cero =@CRR
where
stocktransaccion_transaccion =2
and stocktransaccion_fecha =@DATE
and stock_id = '700784'


 
END




GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_CAJA_BILLETE]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[SP_LISTAR_CAJA_BILLETE]
@stock_marca int,
@stock_mes int
AS
BEGIN
 if @stock_marca=0
begin
	select d.cajadetalle_fecha , d.cajadetalle_billete_docientos *200 + d.cajadetalle_billete_cien *100 +
	d.cajadetalle_billete_cincuenta *50 +d.cajadetalle_billete_veinte *20 +
	d.cajadetalle_billete_diez *10
	 as cantidad, d.cajadetalle_descripcion  from [dbo].[TB_CAJA_DETALLE] d
 
end
else 
begin

select d.cajadetalle_fecha , d.cajadetalle_billete_docientos *200 + d.cajadetalle_billete_cien *100 +
	d.cajadetalle_billete_cincuenta *50 +d.cajadetalle_billete_veinte *20 +
	d.cajadetalle_billete_diez *10
	 as cantidad, d.cajadetalle_descripcion  from [dbo].[TB_CAJA_DETALLE] d
	 where 	 DatePart(Month, d.cajadetalle_fecha )=@stock_mes 


end
END




GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_CAJA_MONEDA]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[SP_LISTAR_CAJA_MONEDA]
@stock_marca int,
@stock_mes int
AS
BEGIN

if @stock_marca=0
begin
 select m.cajadetallemoneda_fecha , m.cajadetallemoneda_monto , m.cajadetallemoneda_descripcion 
  from [dbo].[TB_CAJA_DETALLE_MONEDA] m
   
end
else 
begin

 select m.cajadetallemoneda_fecha , m.cajadetallemoneda_monto , m.cajadetallemoneda_descripcion 
  from [dbo].[TB_CAJA_DETALLE_MONEDA] m
  where 	 DatePart(Month,  m.cajadetallemoneda_fecha )=@stock_mes 


end
END




GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_EJEMPLAR_VENTA_PORTIPO]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[SP_LISTAR_EJEMPLAR_VENTA_PORTIPO]

AS
BEGIN

	select venta.stocktransaccion_fecha as fecha ,venta.stock_id  as id, s.stock_nombre  as nombre,
	 venta.stocktransaccion_cantidad as pauta,dev.stocktransaccion_cantidad as dev ,
	dev.stocktransaccion_cero, p.tipoejemplares_ejemplar
	   from
	(
	select st.stocktransaccion_fecha,st.stocktransaccion_cantidad,st.stock_id 
		 from [dbo].[TB_STOCK_TRANSACCION] st
	where st.stocktransaccion_transaccion=1
	) as venta
	inner join
	(
	select st.stocktransaccion_fecha,st.stocktransaccion_cantidad,st.stock_id,
	st.stocktransaccion_cero  
		 from [dbo].[TB_STOCK_TRANSACCION] st
	where st.stocktransaccion_transaccion=2
	) as dev
	on venta.stock_id =dev.stock_id
	and venta.stocktransaccion_fecha=dev.stocktransaccion_fecha 
	inner join TB_STOCK s
	on venta.stock_id = s.stock_id   
	inner join TB_TIPOEJEMPLAR_STOCK  p
	on s.stock_id = p.stock_id 
	where s.stock_tipomercaderia=1
	order by  tipoejemplares_ejemplar ,venta.stocktransaccion_fecha    asc

 
END




GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_VENTA_PORMARCA]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[SP_LISTAR_VENTA_PORMARCA]
@stock_marca int,
@stock_mes int

AS
BEGIN
if @stock_marca=0
begin

	select venta.stocktransaccion_fecha as fecha ,venta.stock_id  as id, s.stock_nombre  as nombre,
	 venta.stocktransaccion_cantidad as pauta,dev.stocktransaccion_cantidad as dev ,
	venta.stock_precio as precio, venta.stock_comision_canilla as comision_canillla, 
	venta.stock_comision_distribuidor as comision_distribuidor,s .stock_tipomercaderia  , p.proveedor_descripcion 
	   from
	(
	select st.stocktransaccion_fecha,st.stocktransaccion_cantidad,st.stock_id ,
	 st.stock_precio ,st.stock_comision_canilla,st.stock_comision_distribuidor 
		 from [dbo].[TB_STOCK_TRANSACCION] st
	where st.stocktransaccion_transaccion=1	
	) as venta
	inner join
	(
	select st.stocktransaccion_fecha,st.stocktransaccion_cantidad,st.stock_id ,
	 st.stock_precio ,st.stock_comision_canilla,st.stock_comision_distribuidor 
		 from [dbo].[TB_STOCK_TRANSACCION] st
	where st.stocktransaccion_transaccion=2	
	) as dev
	on venta.stock_id =dev.stock_id
	and venta.stocktransaccion_fecha=dev.stocktransaccion_fecha 
	inner join TB_STOCK s
	on venta.stock_id = s.stock_id   
	inner join TB_PROVEEDOR  p
	on s.proveedor_id = p.proveedor_id 
	order by  venta.stocktransaccion_fecha , s.proveedor_id,s.stock_tipomercaderia    asc
end
else 
begin
	select venta.stocktransaccion_fecha as fecha ,venta.stock_id  as id, s.stock_nombre  as nombre,
	 venta.stocktransaccion_cantidad as pauta,dev.stocktransaccion_cantidad as dev ,
	venta.stock_precio as precio, venta.stock_comision_canilla as comision_canillla, 
	venta.stock_comision_distribuidor as comision_distribuidor,s .stock_tipomercaderia  , p.proveedor_descripcion 
	   from
	(
	select st.stocktransaccion_fecha,st.stocktransaccion_cantidad,st.stock_id ,
	 st.stock_precio ,st.stock_comision_canilla,st.stock_comision_distribuidor 
		 from [dbo].[TB_STOCK_TRANSACCION] st
	where st.stocktransaccion_transaccion=1
	and  DatePart(Month, stocktransaccion_fecha)=@stock_mes 
	) as venta
	inner join
	(
	select st.stocktransaccion_fecha,st.stocktransaccion_cantidad,st.stock_id ,
	 st.stock_precio ,st.stock_comision_canilla,st.stock_comision_distribuidor 
		 from [dbo].[TB_STOCK_TRANSACCION] st
	where st.stocktransaccion_transaccion=2
	and  DatePart(Month, stocktransaccion_fecha)=@stock_mes 
	) as dev
	on venta.stock_id =dev.stock_id
	and venta.stocktransaccion_fecha=dev.stocktransaccion_fecha 
	inner join TB_STOCK s
	on venta.stock_id = s.stock_id   
	inner join TB_PROVEEDOR  p
	on s.proveedor_id = p.proveedor_id 
	WHERE s.stock_marca =@stock_marca
	order by  venta.stocktransaccion_fecha , s.proveedor_id,s.stock_tipomercaderia    asc

end

END




GO
/****** Object:  Table [dbo].[TB_CAJA_DETALLE]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CAJA_DETALLE](
	[cajadetalle_id] [int] IDENTITY(1,1) NOT NULL,
	[cajadetalle_fecha] [date] NOT NULL,
	[cajadetalle_billete_docientos] [int] NOT NULL,
	[cajadetalle_billete_cien] [int] NOT NULL,
	[cajadetalle_billete_cincuenta] [int] NOT NULL,
	[cajadetalle_billete_veinte] [int] NOT NULL,
	[cajadetalle_billete_diez] [int] NOT NULL,
	[cajadetalle_descripcion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TB_CAJA_DETALLE_1] PRIMARY KEY CLUSTERED 
(
	[cajadetalle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CAJA_DETALLE_BILLETE]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CAJA_DETALLE_BILLETE](
	[cajadetallebillete_id] [int] IDENTITY(1,1) NOT NULL,
	[cajadetalle_id] [int] NOT NULL,
	[cajadetallebillete_tipo] [int] NOT NULL,
	[cajadetallebillete_serie] [varchar](12) NOT NULL,
	[cajadetallebillete_descripcion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TB_CAJA_DETALLE_BILLETES] PRIMARY KEY CLUSTERED 
(
	[cajadetallebillete_id] ASC,
	[cajadetalle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CAJA_DETALLE_MONEDA]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CAJA_DETALLE_MONEDA](
	[cajadetallemoneda_id] [int] IDENTITY(1,1) NOT NULL,
	[cajadetallemoneda_fecha] [date] NOT NULL,
	[cajadetallemoneda_monto] [decimal](18, 2) NOT NULL,
	[cajadetallemoneda_descripcion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TB_CAJA_DETALLE_MONEDA] PRIMARY KEY CLUSTERED 
(
	[cajadetallemoneda_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CLIENTE]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CLIENTE](
	[cliente_id] [int] NOT NULL,
	[cliente_nombres] [varchar](200) NOT NULL,
	[cliente_tipopersona] [int] NOT NULL,
	[cliente_direccion] [varchar](200) NOT NULL,
	[cliente_dni] [int] NOT NULL,
	[cliente_fechanacimiento] [date] NULL,
	[cliente_tipovendedor] [int] NULL,
 CONSTRAINT [PK_TB_CLIENTES] PRIMARY KEY CLUSTERED 
(
	[cliente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CLIENTE_INCIDENCIA_EJEMPLAR]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CLIENTE_INCIDENCIA_EJEMPLAR](
	[clienteincidenciaejemplar_id] [int] IDENTITY(1,1) NOT NULL,
	[clientes_id] [int] NOT NULL,
	[clienteincidenciaejemplar_fecha] [date] NOT NULL,
	[clienteincidenciaejemplar_cantidad] [int] NOT NULL,
	[clienteincidenciaejemplar_tipo] [int] NOT NULL,
	[clienteincidenciaejemplar_descripcion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TB_CLIENTE_INCIDENCIA_EJEMPLAR] PRIMARY KEY CLUSTERED 
(
	[clienteincidenciaejemplar_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CLIENTE_TELEFONO]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CLIENTE_TELEFONO](
	[clientetelefono_id] [int] IDENTITY(1,1) NOT NULL,
	[cliente_id] [int] NOT NULL,
	[clientetelefono_numero] [int] NOT NULL,
 CONSTRAINT [PK_TB_CLIENTES_TELEFONO] PRIMARY KEY CLUSTERED 
(
	[clientetelefono_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_CODIGO_GENERAL]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CODIGO_GENERAL](
	[codigogeneral_id] [int] NOT NULL,
	[codigogeneral_descrip] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TB_CODIGOS_GENERAL] PRIMARY KEY CLUSTERED 
(
	[codigogeneral_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CODIGO_GENERAL_DETALLE]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CODIGO_GENERAL_DETALLE](
	[codigogeneral_id] [int] NOT NULL,
	[codigodetalle_id] [int] NOT NULL,
	[codigodetalle_descrip] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TB_CODIGO_GENERAL_DETALLE_1] PRIMARY KEY CLUSTERED 
(
	[codigogeneral_id] ASC,
	[codigodetalle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CONF_EJEMPLAR]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CONF_EJEMPLAR](
	[conf_ejemplares_id] [int] IDENTITY(1,1) NOT NULL,
	[conf_dia_semana] [int] NOT NULL,
	[stock_id] [int] NOT NULL,
	[conf_transaccion] [int] NOT NULL,
	[conf_ejemplar] [int] NOT NULL,
 CONSTRAINT [PK_TB_CONF_EJEMPLARES] PRIMARY KEY CLUSTERED 
(
	[conf_ejemplares_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_PROVEEDOR]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_PROVEEDOR](
	[proveedor_id] [int] IDENTITY(1,1) NOT NULL,
	[proveedor_descripcion] [varchar](200) NOT NULL,
	[proveedor_ruc] [char](12) NOT NULL,
	[proveedor_direccion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TB_PROVEEDOR] PRIMARY KEY CLUSTERED 
(
	[proveedor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_STOCK]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_STOCK](
	[stock_id] [int] NOT NULL,
	[stock_nombre] [varchar](50) NOT NULL,
	[stock_precio] [decimal](18, 2) NOT NULL,
	[stock_comision_canilla] [decimal](18, 2) NOT NULL,
	[stock_comision_distribuidor] [decimal](18, 2) NOT NULL,
	[stock_tipomercaderia] [int] NOT NULL,
	[stock_fechaventa] [date] NOT NULL,
	[proveedor_id] [int] NOT NULL,
	[stock_marca] [int] NULL,
 CONSTRAINT [PK_TB_STOCK] PRIMARY KEY CLUSTERED 
(
	[stock_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_STOCK_TRANSACCION]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_STOCK_TRANSACCION](
	[stocktransaccion_id] [int] IDENTITY(1,1) NOT NULL,
	[stocktransaccion_fecha] [date] NOT NULL,
	[stocktransaccion_transaccion] [int] NOT NULL,
	[stocktransaccion_cantidad] [int] NOT NULL,
	[stock_id] [int] NOT NULL,
	[stock_precio] [decimal](18, 2) NOT NULL,
	[stock_comision_canilla] [decimal](18, 2) NOT NULL,
	[stock_comision_distribuidor] [decimal](18, 2) NOT NULL,
	[stocktransaccion_cero] [int] NOT NULL,
	[stocktransaccion_totalVentanilla] [int] NULL,
 CONSTRAINT [PK_TB_STOCK_TRANSACCIONES] PRIMARY KEY CLUSTERED 
(
	[stocktransaccion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_STOCK_TRANSACCION_CAJA]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_STOCK_TRANSACCION_CAJA](
	[stocktransaccioncaja_id] [int] IDENTITY(1,1) NOT NULL,
	[stocktransaccioncaja_fecha] [date] NOT NULL,
	[stocktransaccioncaja_transaccion] [int] NOT NULL,
	[stocktransaccioncaja_cantidad] [int] NOT NULL,
	[stock_id] [int] NOT NULL,
	[stock_precio] [decimal](18, 2) NOT NULL,
	[stock_comision_canilla] [decimal](18, 2) NOT NULL,
	[stocktransaccioncaja_descripcion] [varchar](100) NOT NULL,
	[stocktransaccion_transaccion] [int] NOT NULL,
	[stocktransaccioncaja_estado] [int] NOT NULL,
 CONSTRAINT [PK_TB_STOCK_TRANSACCION_CAJA] PRIMARY KEY CLUSTERED 
(
	[stocktransaccioncaja_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_TIPOEJEMPLAR_STOCK]    Script Date: 16/01/2018 06:48:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPOEJEMPLAR_STOCK](
	[tipoejemplares_stock_id] [int] IDENTITY(1,1) NOT NULL,
	[tipoejemplares_ejemplar] [int] NOT NULL,
	[stock_id] [int] NOT NULL,
 CONSTRAINT [PK_TB_TIPOEJEMPLARES_STOCK] PRIMARY KEY CLUSTERED 
(
	[tipoejemplares_stock_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TB_CAJA_DETALLE_BILLETE]  WITH CHECK ADD  CONSTRAINT [FK_TB_CAJA_DETALLE_BILLETES_TB_CAJA_DETALLE] FOREIGN KEY([cajadetalle_id])
REFERENCES [dbo].[TB_CAJA_DETALLE] ([cajadetalle_id])
GO
ALTER TABLE [dbo].[TB_CAJA_DETALLE_BILLETE] CHECK CONSTRAINT [FK_TB_CAJA_DETALLE_BILLETES_TB_CAJA_DETALLE]
GO
ALTER TABLE [dbo].[TB_CLIENTE_INCIDENCIA_EJEMPLAR]  WITH CHECK ADD  CONSTRAINT [FK_TB_CLIENTE_INCIDENCIA_EJEMPLAR_TB_CLIENTE] FOREIGN KEY([clientes_id])
REFERENCES [dbo].[TB_CLIENTE] ([cliente_id])
GO
ALTER TABLE [dbo].[TB_CLIENTE_INCIDENCIA_EJEMPLAR] CHECK CONSTRAINT [FK_TB_CLIENTE_INCIDENCIA_EJEMPLAR_TB_CLIENTE]
GO
ALTER TABLE [dbo].[TB_CLIENTE_TELEFONO]  WITH CHECK ADD  CONSTRAINT [FK_TB_CLIENTES_TELEFONO_TB_CLIENTES] FOREIGN KEY([cliente_id])
REFERENCES [dbo].[TB_CLIENTE] ([cliente_id])
GO
ALTER TABLE [dbo].[TB_CLIENTE_TELEFONO] CHECK CONSTRAINT [FK_TB_CLIENTES_TELEFONO_TB_CLIENTES]
GO
ALTER TABLE [dbo].[TB_CODIGO_GENERAL_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_TB_CODIGO_GENERAL_DETALLE_TB_CODIGOS_GENERAL] FOREIGN KEY([codigogeneral_id])
REFERENCES [dbo].[TB_CODIGO_GENERAL] ([codigogeneral_id])
GO
ALTER TABLE [dbo].[TB_CODIGO_GENERAL_DETALLE] CHECK CONSTRAINT [FK_TB_CODIGO_GENERAL_DETALLE_TB_CODIGOS_GENERAL]
GO
ALTER TABLE [dbo].[TB_CONF_EJEMPLAR]  WITH CHECK ADD  CONSTRAINT [FK_TB_CONF_EJEMPLARES_TB_STOCK] FOREIGN KEY([stock_id])
REFERENCES [dbo].[TB_STOCK] ([stock_id])
GO
ALTER TABLE [dbo].[TB_CONF_EJEMPLAR] CHECK CONSTRAINT [FK_TB_CONF_EJEMPLARES_TB_STOCK]
GO
ALTER TABLE [dbo].[TB_STOCK]  WITH CHECK ADD  CONSTRAINT [FK_TB_STOCK_TB_PROVEEDOR] FOREIGN KEY([proveedor_id])
REFERENCES [dbo].[TB_PROVEEDOR] ([proveedor_id])
GO
ALTER TABLE [dbo].[TB_STOCK] CHECK CONSTRAINT [FK_TB_STOCK_TB_PROVEEDOR]
GO
ALTER TABLE [dbo].[TB_STOCK_TRANSACCION]  WITH CHECK ADD  CONSTRAINT [FK_TB_STOCK_TRANSACCIONES_TB_STOCK] FOREIGN KEY([stock_id])
REFERENCES [dbo].[TB_STOCK] ([stock_id])
GO
ALTER TABLE [dbo].[TB_STOCK_TRANSACCION] CHECK CONSTRAINT [FK_TB_STOCK_TRANSACCIONES_TB_STOCK]
GO
ALTER TABLE [dbo].[TB_STOCK_TRANSACCION_CAJA]  WITH CHECK ADD  CONSTRAINT [FK_TB_STOCK_TRANSACCION_CAJA_TB_STOCK] FOREIGN KEY([stock_id])
REFERENCES [dbo].[TB_STOCK] ([stock_id])
GO
ALTER TABLE [dbo].[TB_STOCK_TRANSACCION_CAJA] CHECK CONSTRAINT [FK_TB_STOCK_TRANSACCION_CAJA_TB_STOCK]
GO
ALTER TABLE [dbo].[TB_TIPOEJEMPLAR_STOCK]  WITH CHECK ADD  CONSTRAINT [FK_TB_TIPOEJEMPLARES_STOCK_TB_STOCK] FOREIGN KEY([stock_id])
REFERENCES [dbo].[TB_STOCK] ([stock_id])
GO
ALTER TABLE [dbo].[TB_TIPOEJEMPLAR_STOCK] CHECK CONSTRAINT [FK_TB_TIPOEJEMPLARES_STOCK_TB_STOCK]
GO
USE [master]
GO
ALTER DATABASE [BD_Agencia] SET  READ_WRITE 
GO
