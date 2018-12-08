--------------------------------------------------------------
-------------------Creación del esquema-----------------------
--------------------------------------------------------------

CREATE SCHEMA PEL AUTHORIZATION gdEspectaculos2018

GO 

--------------------------------------------------------------
------------------ Creación de las Secuencias-----------------
--------------------------------------------------------------

create sequence PEL.Compra_seq start with 1 increment by 1

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
	grad_estado char(1) not null,
	PRIMARY KEY (grad_id)
)
CREATE TABLE PEL.Rol (
	rol_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	rol_nombre NVARCHAR(50) NOT NULL UNIQUE,
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

CREATE TABLE PEL.Cliente (
	clie_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	clie_usuario NUMERIC(18,0),
	clie_nombre NVARCHAR(255),
	clie_apellido NVARCHAR(255),
	clie_tipo_doc NVARCHAR(255),
	clie_nro_doc NVARCHAR(255) not null unique ,
	clie_cuil NVARCHAR(255),
	clie_mail NVARCHAR(255) not null,
	clie_telefono NVARCHAR(255),
	clie_fecha_nac DATETIME,
	clie_fecha_crea DATETIME,
	clie_direccion NVARCHAR(255),
	clie_datos_tarjeta NVARCHAR(255),
	clie_codigo_postal NVARCHAR(255),
	clie_estado CHAR (1),
	PRIMARY KEY (clie_id),
	FOREIGN KEY (clie_usuario) REFERENCES PEL.Usuario
)

CREATE TABLE PEL.Empresa (
	empr_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	empr_usuario NUMERIC(18,0),
	empr_direccion NVARCHAR(255) NOT NULL,
	empr_razon_social NVARCHAR(255) NOT NULL UNIQUE,
	empr_cuit NVARCHAR(255) NOT NULL UNIQUE,			
	empr_estado CHAR(1),
	empr_fecha DATETIME,
	empr_telefono NVARCHAR(255),			
	empr_mail NVARCHAR(255) NOT NULL,
	empr_codigo_postal NVARCHAR(255),
	empr_ciudad NVARCHAR(255),
	PRIMARY KEY (empr_id),
	FOREIGN KEY (empr_usuario) REFERENCES PEL.Usuario(usua_id)
)

CREATE TABLE PEL.Publicacion (
	publ_id NUMERIC(18,0) NOT NULL,
	publ_descripcion NVARCHAR(255) NOT NULL,
	publ_estado NUMERIC(18,0),
	publ_fecha_publi DATETIME,
	publ_fecha_ven DATETIME,
	publ_rubro NUMERIC(18,0),
	publ_direccion NVARCHAR(255),
	publ_grado NUMERIC(18,0),
	publ_empresa_resp NUMERIC(18,0),
	PRIMARY KEY (publ_id),
	FOREIGN KEY (publ_rubro) REFERENCES PEL.Rubro (rubr_id),
	FOREIGN KEY (publ_grado) REFERENCES PEL.Grado (grad_id),
	FOREIGN KEY (publ_empresa_resp) REFERENCES PEL.Empresa (empr_id),
	FOREIGN KEY (publ_estado) REFERENCES PEL.Estado_Publicacion (Esta_id)
)

CREATE TABLE PEL.Premio(
	prem_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	prem_descripcion NVARCHAR(255) NOT NULL,
	prem_costo_puntos NUMERIC(18,2) NOT NULL,
	PRIMARY KEY (prem_id)
)

CREATE TABLE PEL.Canje (
	canje_id numeric(18,0) identity(1,1) not null,
	canje_cliente NUMERIC(18,0) NOT NULL,
	canje_premio NUMERIC(18,0) NOT NULL,
	canje_fecha datetime not null,
	canje_puntos_gastados numeric(18,0) not null,
	PRIMARY KEY (canje_id),
	FOREIGN KEY (canje_cliente) REFERENCES PEL.Cliente(clie_id),
	FOREIGN KEY (canje_premio) REFERENCES PEL.Premio(prem_id)
)

CREATE TABLE PEL.Compra (
	compr_id int not null default next value for PEL.Compra_seq,
	compr_cliente NUMERIC(18,0),
	compr_publi NUMERIC(18,0),
	compr_fecha DATETIME,
	compr_detalle NVARCHAR(255),
	compr_total NUMERIC(18,2),
	compr_descuento NVARCHAR(255),
	compr_datos_tarjeta NVARCHAR(255),
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
	fact_importe NUMERIC(18,2) , 
	fact_empr NUMERIC(18,0),
	fact_numero NUMERIC(18,0), 
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
	ubic_precio NUMERIC(18,0), 
	ubic_comision numeric (18,2),
	ubic_item_factura_cantidad NUMERIC (18,0),
	ubic_item_factura_descripcion nvarchar(60),
	ubic_tipo NUMERIC(18,0) NOT NULl,
	ubic_publ NUMERIC(18,0) NOT NULl,	
	ubic_compra int,
	ubic_factura NUMERIC(18,0),
	PRIMARY KEY (ubic_id),
	FOREIGN KEY (ubic_tipo) REFERENCES PEL.Tipo_Ubicacion (tipo_ubic_id),
	FOREIGN KEY (ubic_compra) REFERENCES PEL.Compra(compr_id),
	FOREIGN KEY (ubic_publ) REFERENCES PEL.Publicacion(publ_id),
	FOREIGN KEY (ubic_factura) REFERENCES PEL.Factura(fact_id)
)

GO

--------------------------------------------------
--------Functions, procedures & triggers----------
--------------------------------------------------

CREATE FUNCTION PEL.f_string_split (@string NVARCHAR(MAX), @delimiter CHAR(1)) 
RETURNS @output TABLE(splitdata NVARCHAR(MAX)) 
BEGIN 
    DECLARE @start INT, @end INT 
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string) 
    WHILE @start < LEN(@string) + 1 BEGIN 
        IF @end = 0  
            SET @end = LEN(@string) + 1
       
        INSERT INTO @output (splitdata)  
        VALUES(SUBSTRING(@string, @start, @end - @start)) 
        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @string, @start)
        
    END 
    RETURN 
END
go

create function PEL.f_hash (@pass nvarchar(255))
	returns nvarchar(255)
	begin
		return hashbytes('SHA2_256', @pass);
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
return @id_estado
end
go

create procedure PEL.validar_usuario(@username nvarchar(50),@password nvarchar(255)) 
as
begin
	declare @usua_pass nvarchar(255);
	declare @usua_fallidos numeric (1,0);
	declare @usua_estado char(1);
	declare @mensaje nvarchar(255); 
	declare @usua_id numeric(18,0)
	
	select 
	  @usua_id=usua_id,
	  @usua_pass = usua_password, 
	  @usua_fallidos= usua_login_fallidos,
	  @usua_estado = usua_estado 
	from PEL.Usuario where usua_username = @username;

	if(@usua_id is null)
	begin
	   select -1, 'El usuario o contraseña son incorrectos.';
	   return;
	end;
	
	if(@usua_estado = 'R')
	begin
		select -2, 'El usuario debe cambiar su contraseña';
		return;
	end
	
	set @mensaje = case @usua_estado
		when 'B' then 'El usuario fue inhabilitado por el Administrador.'
		when 'I' then 'El usuario esta inhabilitado por tener 3 login fallidos.'
	end;

	if(@mensaje is not null)
	begin
		select -1, @mensaje;
		return;
	end;

	if(@usua_pass = PEL.f_hash(@password))
		begin
		set @usua_fallidos = 0
		end
	else
		begin
		set @usua_fallidos = @usua_fallidos + 1
		if(@usua_fallidos = 3 )
			begin
				set @usua_estado = 'I';
				set @mensaje = 'Debido a 3 intentos fallidos de inicio de sesion su usuario ha sido inhabilitado.';
				set @usua_id = -1;
			end
		else
		begin
		    set @mensaje = 'El usuario o contraseña son incorrectos.';
			set @usua_id = -1;
		end
	end

	update PEL.Usuario
	set usua_login_fallidos = @usua_fallidos,
	    usua_estado = @usua_estado
	where usua_username = @username;

	select @usua_id, @mensaje;
end


-- 0:true, 1:false
go
create function PEL.f_es_username_valido(@usuario nvarchar(50))
returns int
begin
	declare @respuesta int
	set @respuesta = 0
	if(@usuario in (select usua_username from PEL.Usuario))
		set @respuesta = 1
	return @respuesta
end


go
create procedure PEL.generar_username(@data nvarchar(50) output)
as
begin
	set @data = (SELECT RIGHT(CONVERT(varchar(50), NEWID()),12))
	while(PEL.f_es_username_valido(@data)!=0)
		set @data = (SELECT RIGHT(CONVERT(varchar(50), NEWID()),12))
	return
end
go
-- Inicialmente se registra a un usuario Cliente unicamente con el Rol Cliente


create procedure PEL.registrar_usuario_cliente
		(@username nvarchar(50),@password nvarchar(255),
		@nombre nvarchar(255), @apellido nvarchar(255),@tipo_doc nvarchar(255),@nro_doc nvarchar(255),@cuil nvarchar(255),@mail nvarchar(255),@telefono nvarchar(255),
		@fecha_nac nvarchar(30),@fecha_crea nvarchar(30),@direccion nvarchar(255), @codigo_postal nvarchar(255),@datos_tarjeta nvarchar(255))
as
begin
	
	declare @usua_id numeric (18,0),@mensaje nvarchar(255), @estado varchar(1)
	set @estado = 'A'
	 
	if(@nro_doc is null)
		begin
			set @usua_id = -1
			set @mensaje='Recuerde que es obligatorio que ingrese su DNI.'
			select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
			return
		end	

	if(PEL.f_es_username_valido(@username) != 0)
		begin
			set @usua_id = -1
			set @mensaje='El usuario no es valido, ya se encuentra en uso.'
			select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
			return
		end

	if(@nro_doc in (select clie_nro_doc from PEL.Cliente)) -- es antiguo?
		begin
				declare @usuario_cliente numeric(18,0)
				set @usuario_cliente = (select isnull(clie_usuario,0) from PEL.Cliente where clie_nro_doc = @nro_doc)
				if( @usuario_cliente != 0) -- tiene usuario?
					begin
						set @usua_id = -1
						set @mensaje= 'El Cliente ya posee un Usuario'
						select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
						return
					end
			-- si es antiguo y no tiene usuario, como se esta registrando de nuevo..actualizo sus datos? o los dejo igual ? 
		end
	else
		begin

			if(isdate(@fecha_nac) != 1)
				begin
						set @usua_id = -1
						set @mensaje= 'La fecha de nacimiento es inválida.'
						select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
						return
				end

			if(isdate(@fecha_crea) != 1)
				begin
						set @usua_id = -1
						set @mensaje= 'La fecha de creación es inválida.'
						select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
						return
				end

			begin try
				insert PEL.Cliente (clie_nombre, clie_apellido, clie_tipo_doc, clie_nro_doc, clie_cuil, clie_mail, clie_telefono, clie_fecha_nac, clie_fecha_crea, clie_direccion, clie_codigo_postal,clie_datos_tarjeta,clie_estado) values 
				(@nombre, @apellido, @tipo_doc, @nro_doc, @cuil, @mail, @telefono,convert(datetime,@fecha_nac), convert(datetime,@fecha_crea), @direccion, @codigo_postal , @datos_tarjeta,'A') 				
			end try
			begin catch 
				set @usua_id = -1
				set @mensaje= 'El dni es inválido.'
				select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
				return
			end catch

		end

	if(@username is null or @username = '')
		exec PEL.generar_username @data = @username output
	if(@password is null or @password = '')
		begin
		set @password = (SELECT RIGHT(CONVERT(varchar(255), NEWID()),12))
		set @estado = 'R'
		end

	
	insert PEL.Usuario (usua_username,usua_password,usua_estado) values (@username,PEL.f_hash (@password),@estado)
	set @usua_id = (select usua_id from PEL.Usuario where usua_username = @username)
	insert PEL.Rol_Usuario (rol_usua_rol,rol_usua_usua) values ((select rol_id from PEL.Rol where rol_nombre = 'Cliente'), @usua_id)
	update PEL.Cliente 
		set clie_usuario = @usua_id 
		where clie_nro_doc = @nro_doc
	
	select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
	return
end
go
-- Inicialmente se registra a un usuario Empresa unicamente con el Rol Empresa


create procedure PEL.registrar_usuario_empresa
		(@username nvarchar(50),@password nvarchar(255),
		@direccion nvarchar(255), @ciudad nvarchar(255), @codigo_postal nvarchar(255), @razon_social nvarchar(200),@cuit nvarchar(200),@fecha nvarchar(30),@telefono nvarchar(255),@mail nvarchar(255))
as
begin
	
	declare @usua_id numeric (18,0),@mensaje nvarchar(255),@estado varchar(1)
	set @estado = 'A'

	if(@direccion is null or @razon_social is null or @cuit is null or @mail is null)
		begin
			set @usua_id = -1
			set @mensaje='Recuerde que es obligatorio que complete los siguientes campos: direccion,razon social,cuit,mail.'
			select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
			return
		end

	if(PEL.f_es_username_valido(@username) != 0)
		begin
			set @usua_id = -1
			set @mensaje='El usuario no es valido, ya se encuentra en uso.'
			select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
			return
		end

	if(@cuit in (select empr_cuit from PEL.Empresa)) -- es antiguo?
		begin
				declare @usuario_empresa numeric(18,0)
				set @usuario_empresa= (select isnull(empr_usuario,0) from PEL.Empresa where empr_cuit = @cuit)
				if( @usuario_empresa != 0) -- tiene usuario?
					begin
						set @usua_id = -1
						set @mensaje= 'La Empresa ya posee un Usuario'
						select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
						return
					end
			-- si es antiguo y no tiene usuario, como se esta registrando de nuevo..actualizo sus datos? o los dejo igual ? 
		end
	else 
		begin

			if(isdate(@fecha) != 1)
				begin
						set @usua_id = -1
						set @mensaje= 'La fecha de ingresada es inválida.'
						select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
						return
				end

			begin try
				insert into PEL.Empresa (empr_direccion, empr_ciudad, empr_codigo_postal, empr_razon_social, empr_cuit, empr_estado, empr_fecha, empr_telefono, empr_mail) 
				values (@direccion, @ciudad, @codigo_postal, @razon_social, @cuit, 'A' , convert(datetime,@fecha), @telefono, @mail)
			end try
			begin catch
				set @usua_id = -1
				set @mensaje= 'El cuit es inválido.'
				select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
				return
			end catch
		end

	if(@username is null or @username = '')
		exec PEL.generar_username @data = @username output;
	if(@password is null or @password = '')
		begin
		set @password = (SELECT RIGHT(CONVERT(varchar(255), NEWID()),12))
		set @estado = 'R'
		end
			
	insert PEL.Usuario (usua_username,usua_password,usua_estado) values (@username,PEL.f_hash (@password),@estado)
	set @usua_id = (select usua_id from PEL.Usuario where usua_username = @username)
	insert PEL.Rol_Usuario (rol_usua_rol,rol_usua_usua) values ((select rol_id from PEL.Rol where rol_nombre = 'Empresa'), @usua_id)
	update PEL.Empresa 
		set empr_usuario = @usua_id 
		where empr_cuit = @cuit
	
	select @username as username,@password as password ,@usua_id as usuario ,@mensaje as mensaje
	return
end
GO


--Historial de cliente paginado

CREATE PROCEDURE PEL.sp_ver_compras (@clie_id numeric(18,0), @pag int)
AS	
BEGIN
SELECT  compr_fecha, compr_detalle, compr_medio_pago, compr_total, compr_puntos_acum
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY compr_fecha  ) AS RowNum, *
          FROM      PEL.Compra inner join PEL.Cliente on compr_cliente = clie_id
		  WHERE @clie_id = clie_id
        ) AS RowConstrainedResult
WHERE   RowNum > (@pag-1)*10 
    AND RowNum <= @pag*10
GROUP BY compr_fecha, compr_detalle, compr_medio_pago, compr_total, compr_puntos_acum, RowNum
ORDER BY RowNum
END
GO

CREATE PROCEDURE PEL.sp_total_compras(@clie_id numeric(18,0))
AS
BEGIN
SELECT count(compr_id) FROM PEL.Compra where compr_cliente = @clie_id
END
GO

--Listado de publicaciones paginado
CREATE PROCEDURE PEL.sp_ver_publicaciones (@categorias nvarchar(255), @detalle varchar(255),@desde varchar(30),@hasta varchar(30),@pag int)
AS
BEGIN	  
SELECT  publ_descripcion,publ_fecha_ven,publ_direccion,(select rubr_descripcion from PEL.Rubro where rubr_id = publ_rubro) as rubro
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY grad_porcentaje desc) AS RowNum, *
          FROM      PEL.Publicacion inner join PEL.Grado on publ_grado = grad_id and publ_estado = 2
		  where publ_rubro in (case when @categorias != '' then (select * from PEL.f_string_split(@categorias,',')) else (select publ_rubro) end)
		  and (convert(date,publ_fecha_ven,121) between convert(date,@desde,121) and convert(date,@hasta,121))
		  and publ_descripcion like (case when @detalle != '' then '%' + @detalle + '%' else publ_descripcion end)
        ) AS RowConstrainedResult
WHERE   RowNum > (@pag-1)*10 
    AND RowNum <= @pag*10
ORDER BY RowNum
END
GO

CREATE PROCEDURE PEL.sp_total_publicaciones(@categorias nvarchar(255), @detalle varchar(255),@desde varchar(30),@hasta varchar(30))
AS
BEGIN
SELECT    count(publ_id)
		  FROM      PEL.Publicacion
		  where publ_estado = 2
		  and publ_rubro in (case when @categorias != '' then (select * from PEL.f_string_split(@categorias,',')) else (select publ_rubro) end)
		  and (convert(date,publ_fecha_publi,121) between convert(date,@desde,121) and convert(date,@hasta,121))
		  and (convert(date,publ_fecha_ven,121) between convert(date,@desde,121) and convert(date,@hasta,121))
		  and publ_descripcion like (case when @detalle != '' then '%' + @detalle + '%' else publ_descripcion end)
END
GO

CREATE PROCEDURE PEL.sp_ver_publicaciones_empresa (@categorias nvarchar(255), @detalle varchar(255),@desde varchar(30),@hasta varchar(30),@pag int, @empresa numeric(18,0))
AS
BEGIN	  
SELECT  publ_descripcion,publ_fecha_ven,publ_direccion,(select rubr_descripcion from PEL.Rubro where rubr_id = publ_rubro) as rubro
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY grad_porcentaje desc) AS RowNum, *
          FROM      PEL.Publicacion inner join PEL.Grado on publ_grado = grad_id and publ_empresa_resp = @empresa
		  where publ_rubro in (case when @categorias != '' then (select * from PEL.f_string_split(@categorias,',')) else (select publ_rubro) end) 
		  and (convert(date,publ_fecha_ven,121) between convert(date,@desde,121) and convert(date,@hasta,121))
		  and publ_descripcion like (case when @detalle != '' then '%' + @detalle + '%' else publ_descripcion end)
        ) AS RowConstrainedResult
WHERE   RowNum > (@pag-1)*10 
    AND RowNum <= @pag*10
ORDER BY RowNum
END
GO



CREATE PROCEDURE PEL.sp_total_publicaciones_empresa(@categorias nvarchar(255), @detalle varchar(255),@desde varchar(30),@hasta varchar(30), @empresa numeric(18,0))
AS
BEGIN
SELECT    count(publ_id)
		  FROM      PEL.Publicacion
		  where publ_empresa_resp = @empresa
		  and publ_rubro in (case when @categorias != '' then (select * from PEL.f_string_split(@categorias,',')) else (select publ_rubro) end)
		  and (convert(date,publ_fecha_publi,121) between convert(date,@desde,121) and convert(date,@hasta,121))
		  and (convert(date,publ_fecha_ven,121) between convert(date,@desde,121) and convert(date,@hasta,121))
		  and publ_descripcion like (case when @detalle != '' then '%' + @detalle + '%' else publ_descripcion end)
END
GO

--Listados estadisticos

CREATE PROCEDURE PEL.sp_listado_no_vendidas (@grado numeric(18,0), @fecha_desde varchar(30),@fecha_hasta varchar(30))
AS                                                                 --Es la fecha del mes y año que seleccionaron en el abm
BEGIN
SELECT TOP 5 publ_descripcion, publ_fecha_ven, (select rubr_descripcion from PEL.Rubro where rubr_id = publ_rubro) as rubro, publ_direccion 
			   FROM PEL.Publicacion join PEL.Grado on grad_id = publ_grado and publ_grado like case when @grado != 0 then @grado else publ_grado end
			   join PEL.Ubicacion on ubic_publ = publ_id 
			   WHERE ubic_compra is null 
			   and convert(date,publ_fecha_ven,121) between convert(date,@fecha_desde,121) and convert(date,@fecha_hasta,121)
			   group by publ_empresa_resp, publ_id, publ_descripcion, publ_fecha_ven, publ_rubro, publ_direccion, grad_porcentaje
			   order by count(ubic_id) desc,publ_fecha_ven desc, grad_porcentaje desc
END
GO
				
CREATE PROCEDURE PEL.sp_clientes_puntos_vencidos (@fecha varchar(30), @fecha_desde varchar(30), @fecha_hasta varchar(30))
AS
BEGIN
SELECT TOP 5 clie_nombre, clie_apellido, clie_nro_doc, sum(compr_puntos_acum - compr_puntos_gast) as puntos 
	FROM PEL.Cliente join Compra on compr_cliente = clie_id
		where convert(date,compr_fecha,121) between convert(date,@fecha_desde,121) and convert(date,@fecha_hasta,121)
			 and convert(date,compr_fecha,121) not between dateadd(day,-30,convert(date,@fecha,121)) and convert(date,@fecha,121)
		group by clie_id,clie_nombre, clie_apellido, clie_nro_doc
		order by puntos desc
END
GO

CREATE PROCEDURE PEL.sp_clientes_mayor_compra (@fecha_desde varchar(30), @fecha_hasta varchar(30))
AS
BEGIN
SELECT TOP 5 clie_nombre, clie_apellido, clie_nro_doc, count(compr_id) as [Cantidad de compras]
	FROM PEL.Cliente join PEL.Compra on compr_cliente = clie_id join PEL.Publicacion on publ_id=compr_publi
	where convert(date,compr_fecha,121) between convert(date,@fecha_desde,121) and convert(date,@fecha_hasta,121)
	group by clie_id, clie_nombre, clie_apellido, clie_nro_doc, publ_empresa_resp
	order by count(compr_id) desc
END
GO


CREATE PROCEDURE PEL.sp_generar_rendiciones (@cantidad int, @empresa numeric(18,0), @fecha varchar(30))
AS
BEGIN

	INSERT INTO PEL.Factura (fact_fecha, fact_numero, fact_empr) 
		 values (convert(datetime,@fecha,121),
		(select (max(fact_numero)+1) from PEL.Factura),
	     @empresa)

	DECLARE @factura numeric(18,0)
	SELECT @factura = fact_id FROM PEL.Factura where fact_numero = (select max(fact_numero) from PEL.Factura)

	UPDATE PEL.Ubicacion
	set ubic_factura = @factura,
		   ubic_item_factura_descripcion = 'Comision por compra',
		   ubic_item_factura_cantidad = 1,
		   ubic_comision = case when (select grad_porcentaje from PEL.Publicacion join PEL.Grado on grad_id = publ_grado and publ_id = ubic_publ) = 0 then 0
								 else ubic_precio/(select grad_porcentaje from PEL.Publicacion join PEL.Grado on grad_id = publ_grado and publ_id = ubic_publ) end
	where ubic_id in (SELECT TOP (@cantidad) ubic_id 
					FROM PEL.Ubicacion join PEL.Publicacion ON publ_empresa_resp = @empresa and ubic_publ = publ_id 
					join PEL.Compra ON compr_id = ubic_compra
					WHERE ubic_factura is null
					ORDER BY compr_fecha ASC)
	
	UPDATE PEL.Factura
	set fact_importe = (select sum(ubic_precio) from PEL.Ubicacion where fact_id = @factura and ubic_factura = fact_id  group by ubic_factura),
		fact_comision = (select sum(ubic_comision) from PEL.Ubicacion where ubic_factura = fact_id)
	where fact_id = @factura

	SELECT @factura
END
GO

CREATE PROCEDURE PEL.sp_cantidad_a_rendir (@empresa numeric(18,0))
AS
BEGIN
	SELECT isnull(count(ubic_id),0) as cantidad FROM PEL.Ubicacion join PEL.Publicacion ON ubic_publ = publ_id and publ_empresa_resp = @empresa join PEL.Compra ON compr_id = ubic_compra
	WHERE ubic_factura is null and ubic_compra is not null
END
GO

CREATE PROCEDURE PEL.sp_empresas_por_rendir
AS
BEGIN
	SELECT empr_id, empr_razon_social, count(ubic_id) as cantidad FROM PEL.Ubicacion join PEL.Publicacion ON publ_id = ubic_publ join PEL.Empresa ON publ_empresa_resp = empr_id
	WHERE ubic_factura is null and ubic_compra is not null
	GROUP BY empr_id, empr_razon_social
	ORDER BY 1

END
GO


create procedure PEL.sp_ver_puntos (@usua_id numeric (18,0),@fecha varchar(30))
as
begin
	select compr_puntos_acum - compr_puntos_gast as puntos_disponibles , DATEADD(day,30,compr_fecha) as fecha_vencimiento
	from PEL.Cliente join PEL.Compra on @usua_id = clie_usuario and compr_cliente = clie_id
	where compr_fecha between dateadd(day,-30,convert(date,@fecha,121)) and convert(date,@fecha,121) and compr_puntos_acum - compr_puntos_gast > 0
	order by 2
end
go

create procedure PEL.sp_total_puntos (@usua_id numeric (18,0),@fecha varchar(30))
as
begin
	select sum(compr_puntos_acum - compr_puntos_gast)
    from PEL.Cliente join PEL.Compra on @usua_id = clie_usuario and compr_cliente = clie_id
	where compr_fecha between dateadd(day,-30,convert(date,@fecha,121)) and convert(date,@fecha,121) and compr_puntos_acum - compr_puntos_gast > 0
	group by compr_cliente
end
go

create procedure PEL.sp_descontar_puntos (@usua_id numeric (18,0),@fecha varchar(30),@puntos_a_gastar numeric (18,0))
as
begin

	declare @id_compra int,@puntos_acum numeric (18,0), @puntos_gast numeric (18,0)
	declare cCompras cursor for 
		select compr_id ,compr_puntos_acum,compr_puntos_gast
		from PEL.Cliente join PEL.Compra on @usua_id = clie_usuario and compr_cliente = clie_id
		where compr_fecha between dateadd(day,-30,convert(date,@fecha,121)) and convert(date,@fecha,121)
		order by compr_fecha
		
	open cCompras
	fetch cCompras into @id_compra,@puntos_acum,@puntos_gast
	
	while(@@FETCH_STATUS=0 and @puntos_a_gastar > 0)
	begin
		declare @puntos_disponibles numeric(18,0)
		set @puntos_disponibles = @puntos_acum - @puntos_gast
		if(@puntos_a_gastar > @puntos_disponibles)
			begin
				update PEL.Compra
				set compr_puntos_gast = @puntos_acum
				where compr_id = @id_compra
				set @puntos_a_gastar = @puntos_a_gastar - @puntos_disponibles
			end
		else
			begin
				update PEL.Compra
				set compr_puntos_gast = @puntos_gast + @puntos_a_gastar
				where compr_id = @id_compra
				set @puntos_a_gastar = 0
			end
		fetch cCompras into @id_compra,@puntos_acum,@puntos_gast
	end
	close cCompras
	deallocate cCompras
	return
end
go

CREATE PROCEDURE PEL.sp_canjear_premio (@cliente numeric(18,0), @premio varchar(50), @fecha varchar(30))
AS
BEGIN
	DECLARE @puntos numeric(18,2), @id_premio numeric(18,0)
	select @puntos = prem_costo_puntos, @id_premio = prem_id from PEL.Premio where prem_descripcion = @premio
	INSERT INTO PEL.Canje values (@cliente,@id_premio, convert(datetime,@fecha,121),@puntos)
	select @puntos
END
GO

CREATE PROCEDURE PEL.crear_rol(@rol_nombre nvarchar(50), @funciones nvarchar(50)) 
AS
BEGIN
	DECLARE @rol_id numeric (18,0);
	DECLARE @func_id numeric (18,0);

	INSERT INTO PEl.Rol (rol_nombre, rol_estado) VALUES (@rol_nombre, 'A');

	SELECT @rol_id = rol_id FROM pel.Rol WHERE rol_nombre = @rol_nombre;

	DECLARE c_func CURSOR READ_ONLY FOR 
	  SELECT splitdata
	  FROM PEL.f_string_split(@funciones,',');

	OPEN c_func;
	FETCH NEXT FROM c_func INTO @func_id;
	WHILE(@@FETCH_STATUS=0) BEGIN
		INSERT INTO PEL.Rol_Funcion (rol_func_rol, rol_func_func) VALUES (@rol_id,@func_id);
		FETCH NEXT FROM c_func INTO @func_id;
	END

END;
GO

CREATE PROCEDURE PEL.modificar_rol(@rol_id decimal(18,0), @rol_nombre nvarchar(50), @funciones nvarchar(50)) 
AS
BEGIN
	DECLARE @func_id numeric (18,0);

	UPDATE PEl.Rol 
	    SET rol_nombre = @rol_nombre, 
		    rol_estado = 'A'
		where rol_id = @rol_id;

	DELETE PEL.Rol_Funcion where rol_func_rol = @rol_id;

    DECLARE c_func CURSOR READ_ONLY FOR 
	  SELECT splitdata
	  FROM PEL.f_string_split(@funciones,',');

	OPEN c_func;
	FETCH NEXT FROM c_func INTO @func_id;
	WHILE(@@FETCH_STATUS=0) BEGIN
		INSERT INTO PEL.Rol_Funcion (rol_func_rol, rol_func_func) VALUES (@rol_id,@func_id);
		FETCH NEXT FROM c_func INTO @func_id;
	END

END;
GO

CREATE PROCEDURE PEL.sp_baja_rol (@rol numeric(18,0))
AS
BEGIN

DELETE FROM PEL.Rol_Usuario WHERE rol_usua_rol = @rol

UPDATE PEL.Rol
SET rol_estado = 'B' where rol_id = @rol

END
GO

CREATE PROCEDURE PEL.sp_comprar(@publicacion numeric(18,0), @ubicaciones varchar(255), @fecha varchar(30), @cliente numeric (18,0))
AS
BEGIN
	declare @total numeric(18,2)
	declare @datos_tarjeta nvarchar (255)
	set @datos_tarjeta = (select clie_datos_tarjeta from PEL.Cliente where clie_id = @cliente)
	select @total = sum(ubic_precio) from PEL.Ubicacion where ubic_id in (select * from PEL.f_string_split(@ubicaciones, ','))
	insert into PEL.Compra (compr_cliente, compr_publi, compr_fecha, compr_detalle, compr_total, compr_descuento,compr_datos_tarjeta, compr_medio_pago, compr_puntos_acum, compr_puntos_gast)values 
	(@cliente, @publicacion, convert(datetime, @fecha, 121), '', @total, ' ', @datos_tarjeta, 'Tarjeta', round(@total/100,0),0)

	declare @compra numeric(18,0)
	set @compra = (select max(compr_id) from PEL.Compra)
	
	update PEL.Ubicacion 
	set ubic_compra = @compra
	where ubic_id in (select * from PEL.f_string_split(@ubicaciones, ','))

	declare @cantidad int
	set @cantidad = (select count(distinct(ubic_id)) from PEl.Ubicacion where ubic_publ = @publicacion and ubic_compra = @compra)

	update PEL.Compra 
	set compr_detalle = convert(nvarchar, @cantidad) + ' ubicaciones para ' + (select publ_descripcion from PEL.Publicacion where publ_id = @publicacion)
	where compr_id = @compra

END
GO

CREATE PROCEDURE PEL.sp_cambiar_pass (@usuario decimal, @password nvarchar(255))
AS
BEGIN

UPDATE PEL.Usuario
SET usua_password = pel.f_hash(@password), usua_estado = 'A'
where usua_id = @usuario
END

GO
--------------------------------------------------------------
-------------------Migración de los datos---------------------
--------------------------------------------------------------

INSERT INTO PEL.Premio (prem_descripcion,prem_costo_puntos) values
	('Televisor 7K', '1000'),
	('Celular C6','200'),
	('Juego de té', '100'),
	('Peluche', '55'),
	('Juego de ingenio','25')
GO	

INSERT INTO PEL.Funcion (func_nombre) values 
	('ABM DE ROL'),
    ('ABM DE CLIENTE'),
    ('ABM DE EMPRESA'),
    ('ABM DE GRADO'),
	('ABM DE CATEGORIA'),
	('COMPRAR'),
	('CANJE Y ADMINISTRACION DE PUNTOS'),
	('GENERAR PUBLICACION'),
	('EDITAR PUBLICACION'),
	('CONSULTA HISTORIAL'),
	('GENERAR RENDICION'),
	('CONSULTAR LISTADO')
	
GO

INSERT INTO PEL.Estado_Publicacion (Esta_descripcion) values
	('Borrador'),
	('Activa'),
	('Finalizada')
GO

INSERT INTO PEL.Grado (grad_descripcion,grad_porcentaje,grad_estado) values
	('Alta',15,'A'),
	('Media',10,'A'),
	('Baja',5,'A'),
	('Migrado',0,'B')
GO

INSERT INTO PEL.Rol(rol_nombre, rol_estado) values
	('Administrador', 'A'),
	('Cliente','A'),
	('Empresa','A')
GO

INSERT INTO PEL.Usuario (usua_username, usua_password, usua_estado) values
	('admin',PEL.f_hash('w23e'),'A')
GO

INSERT INTO PEL.Rol_Funcion(rol_func_rol, rol_func_func) values
	(1,1),
	(1,2),
	(1,3),
	(1,4),
	(1,5),
	(1,12),
	(2,6),
	(2,7),
	(2,10),
	(3,8),
	(3,9),
	(1,11)

GO

INSERT INTO PEL.Rol_Usuario(rol_usua_rol, rol_usua_usua) values
	(1,1)
GO

INSERT INTO PEL.Rubro (rubr_descripcion)
  	SELECT DISTINCT Espectaculo_Rubro_Descripcion
	FROM gd_esquema.Maestra
GO


INSERT INTO PEL.Empresa (empr_razon_social, 
						 empr_cuit, 
						 empr_fecha, 
						 empr_mail, 
						 empr_direccion,
						 empr_codigo_postal,
						 empr_ciudad)
	SELECT DISTINCT Espec_Empresa_Razon_Social, 
					Espec_Empresa_Cuit, 
					Espec_Empresa_Fecha_Creacion, 
					Espec_Empresa_Mail, 
					Espec_Empresa_Dom_Calle + ' '  + 
						CONVERT(nvarchar,Espec_Empresa_Nro_Calle) + ' '  + 
						CONVERT(nvarchar,Espec_Empresa_Piso) + ' '  +
						Espec_Empresa_Depto,
						Espec_Empresa_Cod_Postal,
						''
	FROM gd_esquema.Maestra
GO

update PEL.Empresa
 set empr_estado = 'M'


INSERT INTO PEL.Publicacion (publ_id,
							 publ_descripcion, 
							 publ_fecha_publi, 
							 publ_fecha_ven, 
							 publ_rubro, 
							 publ_estado,
							 publ_empresa_resp)
  	SELECT DISTINCT Espectaculo_Cod, 
					Espectaculo_Descripcion,
					Espectaculo_Fecha, 
					Espectaculo_Fecha_Venc, 
					(SELECT rubr_id FROM PEL.Rubro WHERE rubr_descripcion = Espectaculo_Rubro_Descripcion), 
					PEL.calcular_publ_estado(Espectaculo_Fecha_Venc,getdate()),
					(select empr_id from PEL.Empresa where empr_razon_social = Espec_Empresa_Razon_Social and empr_cuit =  Espec_Empresa_Cuit)
	FROM gd_esquema.Maestra
GO

declare @id_grado numeric(18,0)
set @id_grado = (select grad_id from PEL.Grado where grad_descripcion = 'Migrado')
update PEL.Publicacion
	set publ_grado = @id_grado



INSERT INTO PEL.Tipo_Ubicacion (tipo_ubic_descripcion, tipo_ubic_id)
	SELECT DISTINCT Ubicacion_Tipo_Descripcion, Ubicacion_Tipo_Codigo
	FROM gd_esquema.Maestra
GO



INSERT INTO PEL.Factura (fact_fecha, 
						 fact_comision, 
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


INSERT INTO PEL.Cliente (clie_nro_doc, 
						 clie_apellido, 
						 clie_nombre, 
						 clie_fecha_nac, 
						 clie_mail, 
						 clie_direccion,
						 clie_codigo_postal)
	SELECT DISTINCT Cli_Dni,
					Cli_Apeliido, 
					Cli_Nombre, 
					Cli_Fecha_Nac, 
					Cli_Mail, Cli_Dom_Calle + ' '  + 
						convert(nvarchar,Cli_Nro_Calle) + ' '  +
						convert(nvarchar,Cli_Piso) + ' '  +
						Cli_Depto,
					Cli_Cod_Postal
	FROM gd_esquema.Maestra
	where cli_dni is not null
GO 

update PEL.Cliente
 set clie_estado = 'M'

INSERT INTO PEL.Compra (compr_fecha,
						compr_total,  
						compr_medio_pago, 
						compr_publi, 
						compr_cliente)
	--Habria que verificar que las cantidades coincidan 
	SELECT DISTINCT Compra_Fecha,
					Ubicacion_Precio*Compra_cantidad, 
					Forma_Pago_Desc, 
					Espectaculo_Cod, 
					(SELECT clie_id FROM PEL.Cliente WHERE clie_nro_doc = Cli_Dni)
	FROM gd_esquema.Maestra
	where cli_dni is not null and compra_fecha is not null and Forma_Pago_Desc is not null
GO

update PEL.Compra
	set compr_puntos_acum = (select round(compr_total/100,0)),compr_puntos_gast = 0



INSERT INTO PEL.Ubicacion (ubic_fila, 
						   ubic_asiento, 
						   ubic_sin_numerar, 
						   ubic_precio, 
						   ubic_publ, 
						   ubic_tipo)
	SELECT DISTINCT Ubicacion_Fila, 
					Ubicacion_Asiento, 
					Ubicacion_Sin_numerar,
					Ubicacion_Precio,
					Espectaculo_Cod, 
					Ubicacion_Tipo_Codigo 
	FROM gd_esquema.Maestra 
	where Factura_Fecha is null
GO



update PEL.Ubicacion
	set ubic_factura = (select fact_id from PEL.Factura where fact_numero = Factura_nro), 
		ubic_comision = Item_Factura_Monto,
		ubic_item_factura_cantidad = Item_Factura_Cantidad,
		ubic_item_factura_descripcion = Item_Factura_Descripcion,
		ubic_compra = compr_id
	from gd_esquema.Maestra join PEL.Compra on compr_fecha = Compra_Fecha 
							join PEL.Cliente on clie_nro_doc = Cli_Dni
	where Factura_nro is not null and ubic_fila=Ubicacion_fila and ubic_asiento=Ubicacion_Asiento and ubic_publ= Espectaculo_Cod and ubic_tipo = Ubicacion_tipo_codigo



update PEL.Factura
set fact_importe = (select sum(ubic_precio) from PEL.Ubicacion where ubic_factura = fact_id
					group by ubic_factura)
go


ALTER TABLE PEL.cliente
ADD CONSTRAINT ck_clie_dni 
CHECK (
PATINDEX('[0-9][0-9].[0-9][0-9][0-9].[0-9][0-9][0-9]',clie_nro_doc) +
PATINDEX(     '[0-9].[0-9][0-9][0-9].[0-9][0-9][0-9]',clie_nro_doc) +
PATINDEX('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]',clie_nro_doc) +
PATINDEX(     '[0-9][0-9][0-9][0-9][0-9][0-9][0-9]',clie_nro_doc) 
> 0
);
GO

CREATE TRIGGER PEL.tr_validar_cuit
ON PEL.Empresa
AFTER INSERT, UPDATE
AS
	Declare @cuit nvarchar(255);
	select @cuit = empr_cuit from inserted;

	if PATINDEX('[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]',@cuit)= 0
		begin
		throw 50000,'CUIT incorrecto',1;	
		rollback
		end
GO


