--------------------------------------------------------------
-------------------Creación del esquema-----------------------
--------------------------------------------------------------

CREATE SCHEMA PEL AUTHORIZATION gdEspectaculos2018

GO 

--------------------------------------------------------------
-------------------Creación de las tablas---------------------
--------------------------------------------------------------

CREATE TABLE PEL.Rubro (
	rubr_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	rubr_descripcion NVARCHAR(255),
	PRIMARY KEY (rubr_id)
)
CREATE TABLE PEL.Grado (
	grad_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	grad_descripcion NVARCHAR(255) NOT NULL,
	grad_porcentaje NUMERIC(18,2) NOT NULL,
	PRIMARY KEY (grad_id)
)
CREATE TABLE PEL.Rol (
	rol_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	rol_nombre NVARCHAR(50) NOT NULL,
	rol_estado CHAR(1) NOT NULL,
	PRIMARY KEY (rol_id)
)

CREATE TABLE PEL.Usuario (
	usua_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	usua_username NVARCHAR(50) NOT NULL UNIQUE,
	usua_password NVARCHAR(100) NOT NULL,
	usua_login_fallidos NUMERIC(1,0) NOT NULL,
	usua_estado CHAR(1) NOT NULL,
	PRIMARY KEY (usua_id)
)


CREATE TABLE PEL.Funcion (
	func_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	func_nombre NVARCHAR(50) NOT NULL UNIQUE,
	PRIMARY KEY (func_id)
)


CREATE TABLE PEL.Rol_Funcion(
	rol_func_rol NUMERIC(18,0) NOT NULL,
	rol_func_func NUMERIC(18,0) NOT NULL,
	PRIMARY KEY (rol_func_rol,rol_func_func),
	FOREIGN KEY (rol_func_rol) REFERENCES PEL.Rol(rol_id),
	FOREIGN KEY (rol_func_func) REFERENCES PEL.Funcion(func_id)
)


CREATE TABLE PEL.Rol_Usuario (
	rol_usua_usua NUMERIC(18,0) NOT NULL,
	rol_usua_rol NUMERIC(18,0) NOT NULL,
	PRIMARY KEY (rol_usua_usua,rol_usua_rol),
	FOREIGN KEY (rol_usua_usua) REFERENCES PEL.Usuario (usua_id),
	FOREIGN KEY (rol_usua_rol) REFERENCES PEL.Rol (rol_id)
)

CREATE TABLE PEL.Estado_Publicacion (
	Esta_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	Esta_descripcion NVARCHAR(255) NOT NULL,
	PRIMARY KEY(Esta_id)
)

CREATE TABLE PEL.Publicacion (
	publ_id NUMERIC(18,0) NOT NULL,
	publ_descripcion NVARCHAR(255) NOT NULL,
	publ_estado NUMERIC(18,0),
	publ_fecha_publi DATETIME,
	publ_fecha_ven DATETIME,
	publ_fecha_hora DATETIME,
	publ_rubro NUMERIC(18,0),
	publ_direccion NVARCHAR(255),
	publ_grado NUMERIC(18,0),
	publ_usua_resp NUMERIC(18,0),
	PRIMARY KEY (publ_id),
	FOREIGN KEY (publ_rubro) REFERENCES PEL.Rubro (rubr_id),
	FOREIGN KEY (publ_grado) REFERENCES PEL.Grado (grad_id),
	FOREIGN KEY (publ_usua_resp) REFERENCES PEL.Usuario (usua_id),
	FOREIGN KEY (publ_estado) REFERENCES PEL.Estado_Publicacion (Esta_id)
)

CREATE TABLE PEL.Cliente (
	clie_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	clie_usuario NUMERIC(18,0),
	clie_nombre NVARCHAR(255),
	clie_apellido NVARCHAR(255),
	clie_tipo_doc NVARCHAR(255),
	clie_nro_doc NVARCHAR(255),
	clie_cuil NVARCHAR(255),
	clie_mail NVARCHAR(255),
	clie_telefono NVARCHAR(255),
	clie_fecha_nac DATETIME,
	clie_fecha_crea DATETIME,
	clie_direccion NVARCHAR(255),
	clie_datos_tarjeta NVARCHAR,
	clie_estado CHAR (1),
	PRIMARY KEY (clie_id),
	FOREIGN KEY (clie_usuario) REFERENCES PEL.Usuario
)

CREATE TABLE PEL.Empresa (
	empr_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	empr_usuario NUMERIC(18,0),
	empr_direccion NVARCHAR(255) NOT NULL,
	empr_razon_social NVARCHAR(200) NOT NULL,	-- bajo la cant de char por problemilla al actualizar tabla por unique
	empr_cuit NVARCHAR(200) NOT NULL,			-- idem top
	empr_fecha DATETIME,
	empr_telefono NVARCHAR(255),			
	empr_mail NVARCHAR(255) NOT NULL,					
	PRIMARY KEY (empr_id),
	FOREIGN KEY (empr_usuario) REFERENCES PEL.Usuario(usua_id),
	CONSTRAINT empr_un UNIQUE(empr_cuit, empr_razon_social)
)

CREATE TABLE PEL.Premio(
	prem_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	prem_descripcion NVARCHAR(255) NOT NULL,
	prem_porcentaje NUMERIC(18,2) NOT NULL,
	prem_cliente NUMERIC(18,0) NOT NULL,
	PRIMARY KEY (prem_id),
	FOREIGN KEY (prem_cliente) REFERENCES PEL.Cliente(clie_id)
)

CREATE TABLE PEL.Premio_Cliente (
	prem_clie_clie NUMERIC(18,0) NOT NULL,
	prem_clie_prem NUMERIC(18,0) NOT NULL,
	PRIMARY KEY (prem_clie_clie,prem_clie_prem),
	FOREIGN KEY (prem_clie_clie) REFERENCES PEL.Cliente(clie_id),
	FOREIGN KEY (prem_clie_prem) REFERENCES PEL.Premio(prem_id)
)

CREATE TABLE PEL.Compra (
	compr_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	compr_cliente NUMERIC(18,0),
	compr_publi NUMERIC(18,0),
	compr_fecha DATETIME,
	compr_detalle NVARCHAR(255),
	compr_total NUMERIC(18,2),
	compr_descuento NVARCHAR(255),
	compr_medio_pago NVARCHAR(255),
	compr_puntos_acum NUMERIC(18,0),
	compr_puntos_gast NUMERIC(18,0),
	PRIMARY KEY (compr_id),
	FOREIGN KEY (compr_cliente) REFERENCES PEL.Cliente(clie_id),
	FOREIGN KEY (compr_publi) REFERENCES PEL.Publicacion(publ_id)
)

CREATE TABLE PEL.Factura (
	fact_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	fact_fecha DATETIME,
	fact_comision NUMERIC(18,2),
	fact_importe NUMERIC(18,2) , -- se carga despues, lo que se tiene ya calculado es la comision
	fact_empr NUMERIC(18,0),
	fact_numero NUMERIC(18,0), -- agregado por el null de la maestra que rompia con el fact_id
	PRIMARY KEY (fact_id),
	FOREIGN KEY (fact_empr) REFERENCES PEL.Empresa(empr_id)
)

CREATE TABLE PEL.Item_Factura (
	item_factura NUMERIC(18,0) NOT NULL,
	item_compra NUMERIC(18,0) NOT NULL,
	item_comision NUMERIC(18,2) NOT NULL,
	PRIMARY KEY (item_factura,item_compra),
	FOREIGN KEY (item_factura) REFERENCES PEL.Factura(fact_id),
	FOREIGN KEY (item_compra) REFERENCES PEL.Compra(compr_id)
)

CREATE TABLE PEL.Tipo_Ubicacion (
	tipo_ubic_id NUMERIC(18,0),
	tipo_ubic_descripcion NVARCHAR(255) NOT NULL,
	PRIMARY KEY (tipo_ubic_id)
)

CREATE TABLE PEL.Ubicacion (
	ubic_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	ubic_fila NVARCHAR(2) NOT NULL,
	ubic_asiento NUMERIC (2,0),
	ubic_sin_numerar BIT NOT NULL,
	ubic_precio NUMERIC(18,0),
	ubic_tipo NUMERIC(18,0) NOT NULl,
	ubic_publ NUMERIC(18,0) NOT NULl,	
	ubic_compra NUMERIC(18,0),
	PRIMARY KEY (ubic_id),
	FOREIGN KEY (ubic_tipo) REFERENCES PEL.Tipo_Ubicacion (tipo_ubic_id),
	FOREIGN KEY (ubic_compra) REFERENCES PEL.Compra(compr_id),
	FOREIGN KEY (ubic_publ) REFERENCES PEL.Publicacion(publ_id)

)

GO




--------------------------------------------------------------
-------------------Migración de los datos---------------------
--------------------------------------------------------------

--falta:
	--premio
	--grado
	--premio_cliente
	--rol_funcion
	--rol_usuario
	--usuario	
	
INSERT INTO PEL.Funcion (func_nombre) values 
	('ABM DE ROL'),
    ('ABM DE CLIENTE'),
    ('ABM DE EMPRESA'),
    ('ABM DE GRADO'),
	('ABM DE CATEGORIA')
GO

INSERT INTO PEL.Estado_Publicacion (Esta_descripcion) values
	('Finalizada'),
	('Activa'),
	('Borrador')
GO


-- Password

create function PEL.f_hash (@pass nvarchar(255))
	returns nvarchar(255)
	begin
		return hashbytes('SHA2_256', @pass);
	end
go

create procedure PEL.hash (@pass nvarchar(255),@pass_h nvarchar(255) output)
as
begin
	select @pass_h= hashbytes('SHA2_256', @pass);
	return
end
go

-- Rubro: uno solo con cadena vacia

INSERT INTO PEL.Rubro (rubr_descripcion)
  	SELECT DISTINCT Espectaculo_Rubro_Descripcion
	FROM gd_esquema.Maestra
GO

-- Publicacion

create function PEL.calcular_publ_estado(@fecha_venc date, @fecha_tope date)
returns numeric(18,0)
begin
declare @id_estado numeric(18,0)
if( @fecha_venc < @fecha_tope)
		set @id_estado = (select Esta_id from PEL.Estado_Publicacion where Esta_descripcion = 'Finalizada')
	else
		set @id_estado = (select Esta_id from PEL.Estado_Publicacion where Esta_descripcion = 'Activa')

--alta paja hacer select para eso pero bueno D: podriamos usar la "descricion" y fue, si se quiere agregar 
	--una descripcion de verdad se pone _detalle :P
	--PD: "borrador" nnv *Estrategia* 
	--PD2: y el mail ? que pacho con el estado ? XD
return @id_estado
end
go

INSERT INTO PEL.Publicacion (publ_id,
							 publ_descripcion, 
							 publ_fecha_publi, 
							 publ_fecha_ven, 
							 publ_rubro, 
							 publ_estado)
  	SELECT DISTINCT Espectaculo_Cod, 
					Espectaculo_Descripcion,
					Espectaculo_Fecha, 
					Espectaculo_Fecha_Venc, 
					(SELECT rubr_id FROM PEL.Rubro WHERE rubr_descripcion = Espectaculo_Rubro_Descripcion), 
				--	(SELECT Esta_id FROM PEL.Estado_Publicacion WHERE Esta_descripcion = 'Activa')
					PEL.calcular_publ_estado(Espectaculo_Fecha_Venc,getdate())
	FROM gd_esquema.Maestra
GO

-- Tipo_Ubicacion

INSERT INTO PEL.Tipo_Ubicacion (tipo_ubic_descripcion, tipo_ubic_id)
	SELECT DISTINCT Ubicacion_Tipo_Descripcion, Ubicacion_Tipo_Codigo
	FROM gd_esquema.Maestra
GO

-- Empresa

INSERT INTO PEL.Empresa (empr_razon_social, 
						 empr_cuit, 
						 empr_fecha, 
						 empr_mail, 
						 empr_direccion)
	SELECT DISTINCT Espec_Empresa_Razon_Social, 
					Espec_Empresa_Cuit, 
					Espec_Empresa_Fecha_Creacion, 
					Espec_Empresa_Mail, 
					Espec_Empresa_Dom_Calle + 
						CONVERT(nvarchar,Espec_Empresa_Nro_Calle) + 
						CONVERT(nvarchar,Espec_Empresa_Piso) + 
						Espec_Empresa_Depto + Espec_Empresa_Cod_Postal
	FROM gd_esquema.Maestra
GO

--Factura
-- falta lo del importe: sumatoria del precio de las ubicaciones referenciadas por item_factura
INSERT INTO PEL.Factura (fact_fecha, 
						 fact_comision, 
				--		 fact_id, si esto era asi despues teniamos que controlar la generacion de id, que lo haga el motor
						 fact_numero,
						 fact_empr)
	 SELECT Factura_Fecha, 
			Factura_Total,
			Factura_Nro,
			(SELECT empr_id FROM PEL.Empresa 
			where empr_razon_social = Espec_Empresa_Razon_Social and empr_cuit = Espec_Empresa_Cuit)
	 FROM gd_esquema.Maestra
	 where Factura_Nro is not null
	 group by Factura_Fecha, Factura_Total,Factura_Nro

GO

-- Cliente

INSERT INTO PEL.Cliente (clie_nro_doc, 
						 clie_apellido, 
						 clie_nombre, 
						 clie_fecha_nac, 
						 clie_mail, 
						 clie_direccion)
	SELECT DISTINCT Cli_Dni,
					Cli_Apeliido, 
					Cli_Nombre, 
					Cli_Fecha_Nac, 
					Cli_Mail, Cli_Dom_Calle + 
						convert(nvarchar,Cli_Nro_Calle) + 
						convert(nvarchar,Cli_Piso) +
						Cli_Depto + Cli_Cod_Postal
	FROM gd_esquema.Maestra
	where cli_dni is not null 
GO 


-- Compra
-- que hacemos con los puntos ? O sea hay compras de 2019 y todo xd *Estrategia*
INSERT INTO PEL.Compra (compr_fecha,
						compr_total,  
						compr_medio_pago, 
						compr_publi, 
						compr_cliente)
	--Habria que verificar que las cantidades coincidan 
	SELECT DISTINCT Compra_Fecha,
					Ubicacion_Precio*Compra_cantidad, -- compra_cantidad siempre es 1 pero bueno (?
					Forma_Pago_Desc, 
					Espectaculo_Cod, 
					(SELECT clie_id FROM PEL.Cliente WHERE clie_nro_doc = Cli_Dni)
	FROM gd_esquema.Maestra
	where cli_dni is not null and compra_fecha is not null and Forma_Pago_Desc is not null
GO
