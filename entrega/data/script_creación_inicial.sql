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
	usua_password NVARCHAR(255) NOT NULL,
	usua_login_fallidos NUMERIC(1,0) constraint df_fallidos default (0),
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
	ubic_precio NUMERIC(18,0), -- se mantiene el tipo por la Maestra
	ubic_comision numeric (18,2),
	ubic_item_factura_cantidad NUMERIC (18,0), -- item_factura_cantidad Maestra
	ubic_item_factura_descripcion nvarchar(60), -- item_factura_descripcion Maestra 
	ubic_tipo NUMERIC(18,0) NOT NULl,
	ubic_publ NUMERIC(18,0) NOT NULl,	
	ubic_compra NUMERIC(18,0),
	ubic_factura NUMERIC(18,0),
	PRIMARY KEY (ubic_id),
	FOREIGN KEY (ubic_tipo) REFERENCES PEL.Tipo_Ubicacion (tipo_ubic_id),
	FOREIGN KEY (ubic_compra) REFERENCES PEL.Compra(compr_id),
	FOREIGN KEY (ubic_publ) REFERENCES PEL.Publicacion(publ_id),
	FOREIGN KEY (ubic_factura) REFERENCES PEL.Factura(fact_id)
)

GO




--------------------------------------------------------------
-------------------Migración de los datos---------------------
--------------------------------------------------------------

--falta: (podemos hacer los sp para llenar estas que faltan)
	--premio
	--grado
	--premio_cliente
	
--------------------------------------------------
-------------Funciones y procedures---------------
--------------------------------------------------

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


--------------------------------------------------
-------------Datos--------------------------------
--------------------------------------------------
	
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

INSERT INTO PEL.Grado (grad_descripcion,grad_porcentaje) values
	('Alta',15),
	('Media',10),
	('Baja',5)
GO

INSERT INTO PEL.Rol(rol_nombre, rol_estado) values
	('Administrador General', 'A')
GO

INSERT INTO PEL.Usuario (usua_username, usua_password, usua_estado) values
	--A de activo? deberiamos tenerlos en la estrategia 
	('admin',hashbytes('SHA2_256','w23e'),'A')
GO

INSERT INTO PEL.Rol_Funcion(rol_func_rol, rol_func_func) values
	(1,1),
	(1,2),
	(1,3),
	(1,4),
	(1,5)

GO

INSERT INTO PEL.Rol_Usuario(rol_usua_rol, rol_usua_usua) values
	(1,1)
GO

INSERT INTO PEL.Rubro (rubr_descripcion)
  	SELECT DISTINCT Espectaculo_Rubro_Descripcion
	FROM gd_esquema.Maestra
GO


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
	 group by Factura_Fecha, Factura_Total,Factura_Nro,Espec_Empresa_Razon_Social,Espec_Empresa_Cuit

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

-- Ubicaciones en general

INSERT INTO PEL.Ubicacion (ubic_fila, 
						   ubic_asiento, 
						   ubic_sin_numerar, 
						   ubic_precio, 
						   ubic_publ, 
						   ubic_tipo, 
						   ubic_compra)
	SELECT DISTINCT Ubicacion_Fila, 
					Ubicacion_Asiento, 
					Ubicacion_Sin_numerar,
					Ubicacion_Precio,
					Espectaculo_Cod, 
					Ubicacion_Tipo_Codigo, -- dado que el tipo_ubic_id lo sacamos de ese campo, tambien podria ser algo que manaje el motor y tirar un select
					(select compr_id from PEL.Compra where compr_cliente = Cli_DNI)
	FROM gd_esquema.Maestra
	where Factura_Fecha is null

	--No se si eso alcanza para conseguir la compra, por ejemplo si el cliente compro varias de la misma publicacion el mismo dia
			-- aparenta que si (?
GO

-- ubicaciones facturadas

update PEL.Ubicacion
	set ubic_factura = (select fact_id from PEL.Factura where fact_numero = Factura_nro), ubic_comision = Item_Factura_Monto, ubic_item_factura_cantidad = Item_Factura_Cantidad,ubic_item_factura_descripcion = Item_Factura_Descripcion
	from gd_esquema.Maestra
	where Factura_nro is not null and ubic_fila=Ubicacion_fila and ubic_asiento=Ubicacion_Asiento and ubic_publ= Espectaculo_Cod and ubic_tipo = Ubicacion_tipo_codigo


-- se calcula importe de factura: sumatoria de los precios de cada ubicacion

update PEL.Factura
set fact_importe = (select sum(ubic_precio) from PEL.Ubicacion where ubic_factura = fact_id
					group by ubic_factura)

-- Trigger para persistir la password hasheada

go
create trigger tr_usuario_con_pass_hasheada on PEL.Usuario instead of insert,update
as
begin
	declare @username nvarchar (50),@password nvarchar(255),@estado char(1)
	declare cUsuarios cursor for select usua_username,usua_password,usua_estado from inserted
	open cUsuarios 
	
	fetch next from cUsuarios into @username,@password,@estado
	while(@@FETCH_STATUS = 0)
	begin
		insert Usuario (usua_username,usua_password,usua_estado) values (@username,PEL.f_hash(@password),@estado)
	fetch next from cUsuarios into @username,@password,@estado
	end

	close cUsuarios 
	deallocate cUsuarios 
end

-- SP para validar el login de un Usuario

go
create procedure validar_usuario(@username nvarchar(50),@password nvarchar(255),@usua_id numeric(18,0) output,@mensaje nvarchar(255)) 
as
begin
	declare @usua_pass nvarchar(255), @usua_fallidos numeric (1,0), @usua_estado char(1)
	select @usua_id=usua_id,@usua_pass = usua_password, @usua_fallidos= usua_login_fallidos,@usua_estado = usua_estado from PEL.Usuario where usua_username = @username
	set @mensaje = 'Logueo con éxito!'
	if(@usua_estado = 'I')
		begin
			if(@usua_fallidos = 3)
				set @mensaje = 'El usuario esta inhabilitado por tener 3 login fallidos.'
			else
				set @mensaje = 'El usuario fue inhabilitado por el Administrador.'
		set @usua_id = -1
		return	-- funciona asi esto ? xd
		end

	if(@usua_pass = PEL.f_hash(@password))
		set @usua_fallidos = 0
	else
		begin
		set @usua_fallidos = @usua_fallidos + 1
		if(@usua_fallidos = 3 )
			begin
				update PEL.Usuario
				set  usua_estado = 'I'
				where usua_username = @username
			end
	end

	update PEL.Usuario
	set usua_login_fallidos = @usua_fallidos
	where usua_username = @username
	return
end