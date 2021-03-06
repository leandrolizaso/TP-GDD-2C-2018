USE [GD2C2018]
GO
/****** Object:  Schema [gd_esquema]    Script Date: 01:58:54 ******/
CREATE SCHEMA [gd_esquema] AUTHORIZATION [gdEspectaculos2018]
GO
CREATE TABLE [gd_esquema].[Maestra](
	[Espec_Empresa_Razon_Social] [nvarchar](255) NULL,
	[Espec_Empresa_Cuit] [nvarchar](255) NULL,
	[Espec_Empresa_Fecha_Creacion] [datetime] NULL,
	[Espec_Empresa_Mail] [nvarchar](50) NULL,
	[Espec_Empresa_Dom_Calle] [nvarchar](50) NULL,
	[Espec_Empresa_Nro_Calle] [numeric](18, 0) NULL,
	[Espec_Empresa_Piso] [numeric](18, 0) NULL,
	[Espec_Empresa_Depto] [nvarchar](50) NULL,
	[Espec_Empresa_Cod_Postal] [nvarchar](50) NULL,
	[Espectaculo_Cod] [numeric](18, 0) NULL,
	[Espectaculo_Descripcion] [nvarchar](255) NULL,
	[Espectaculo_Fecha] [datetime] NULL,
	[Espectaculo_Fecha_Venc] [datetime] NULL,
	[Espectaculo_Rubro_Descripcion] [nvarchar](255) NULL,
	[Espectaculo_Estado] [nvarchar](255) NULL,
	[Ubicacion_Fila] [varchar](3) NULL,
	[Ubicacion_Asiento] [numeric](18, 0) NULL,
	[Ubicacion_Sin_numerar] [bit] NULL,
	[Ubicacion_Precio] [numeric](18, 0) NULL,
	[Ubicacion_Tipo_Codigo] [numeric](18, 0) NULL,
	[Ubicacion_Tipo_Descripcion] [nvarchar](255) NULL,
	[Cli_Dni] [numeric](18, 0) NULL,
	[Cli_Apeliido] [nvarchar](255) NULL,
	[Cli_Nombre] [nvarchar](255) NULL,
	[Cli_Fecha_Nac] [datetime] NULL,
	[Cli_Mail] [nvarchar](255) NULL,
	[Cli_Dom_Calle] [nvarchar](255) NULL,
	[Cli_Nro_Calle] [numeric](18, 0) NULL,
	[Cli_Piso] [numeric](18, 0) NULL,
	[Cli_Depto] [nvarchar](255) NULL,
	[Cli_Cod_Postal] [nvarchar](255) NULL,
	[Compra_Fecha] [datetime] NULL,
	[Compra_Cantidad] [numeric](18, 0) NULL,
	[Item_Factura_Monto] [numeric](18, 2) NULL,
	[Item_Factura_Cantidad] [numeric](18, 0) NULL,
	[Item_Factura_Descripcion] [nvarchar](60) NULL,
	[Factura_Nro] [numeric](18, 0) NULL,
	[Factura_Fecha] [datetime] NULL,
	[Factura_Total] [numeric](18, 2) NULL,
	[Forma_Pago_Desc] [nvarchar](255) NULL
) ON [PRIMARY]

GO