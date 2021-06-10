SET DATEFORMAT dmy

USE master

if exists (SELECT * FROM sys.databases WHERE name = 'ProyectoFinal')
begin
	DROP DATABASE ProyectoFinal
end

CREATE DATABASE ProyectoFinal ON
(
	NAME=ProyectoFinal,
	FILENAME='C:\BD2020\ProyectoFinal.mdf'
)

GO
USE ProyectoFinal

CREATE TABLE Empresas
(
	 RUT int NOT NULL PRIMARY KEY,
	 nombre  varchar(50)NOT NULL,
	 telefono  varchar (50)NOT NULL,
	 correoElectronico varchar (50)NOT NULL 
)


CREATE TABLE Paquetes
(
	RUT int FOREIGN KEY References Empresas(RUT), 
	numeroP int NOT NULL, 
	peso float NOT NULL, 
	tipoDePaquete varchar (20) NOT NULL, 
	descripción varchar (50) NOT NULL
	PRIMARY KEY (RUT,numeroP)
)

CREATE TABLE Usuarios 
(
	usuarioLogueo varchar (20) PRIMARY KEY,
	contrasenia varchar (20) NOT NULL,
	nombreCompleto varchar(50) NOT NULL

)

CREATE TABLE SolicitudEntrega
(
	numeroInterno int IDENTITY(100,1) PRIMARY KEY,
	numeroP int ,
	RUT int ,
	fechaEntrega datetime NOT NULL,
	estadoActual varchar (20) NOT NULL,
	direccion varchar (30) NOT NULL,
	nombreDest varchar (20) NOT NULL,
	usuarioLogueo varchar(20)FOREIGN KEY References Usuarios(usuarioLogueo),
	FOREIGN KEY (RUT, numeroP)References Paquetes(RUT,numeroP)
	
)
GO
------------------------------------------------------------------------------------------------------------------
--datos de prueba
INSERT INTO Empresas(RUT ,nombre,telefono,correoElectronico)VALUES (111,'Emp1','12049878','Emp1@gmail.com');
INSERT INTO Empresas(RUT ,nombre,telefono,correoElectronico)VALUES (222,'Emp2','26489800','Emp2@gmail.com');
INSERT INTO Empresas(RUT ,nombre,telefono,correoElectronico)VALUES (333,'Emp3','41253876','Emp3@gmail.com');
INSERT INTO Empresas(RUT ,nombre,telefono,correoElectronico)VALUES (444,'Emp4','25059859','Emp4@gmail.com');
INSERT INTO Empresas(RUT ,nombre,telefono,correoElectronico)VALUES (555,'Emp5','85969849','Emp5@gmail.com');
INSERT INTO Empresas(RUT ,nombre,telefono,correoElectronico)VALUES (666,'Emp6','45049875','Emp6@gmail.com');

INSERT INTO Paquetes(RUT ,numeroP,peso,tipoDePaquete,descripción)VALUES (111,1,5,'bulto','paquete1');
INSERT INTO Paquetes(RUT ,numeroP,peso,tipoDePaquete,descripción)VALUES (111,2,4,'fragil','paquete2');
INSERT INTO Paquetes(RUT ,numeroP,peso,tipoDePaquete,descripción)VALUES (333,1,5,'comun','paquete3');
INSERT INTO Paquetes(RUT ,numeroP,peso,tipoDePaquete,descripción)VALUES (555,1,10,'comun','paquete4');
INSERT INTO Paquetes(RUT ,numeroP,peso,tipoDePaquete,descripción)VALUES (555,2,7,'bulto','paquete5');
INSERT INTO Paquetes(RUT ,numeroP,peso,tipoDePaquete,descripción)VALUES (222,1,15,'comun','paquete6');
INSERT INTO Paquetes(RUT ,numeroP,peso,tipoDePaquete,descripción)VALUES (111,3,5,'fragil','paquete7');

INSERT INTO Usuarios(usuarioLogueo ,contrasenia,nombreCompleto)VALUES ('usuario1','contra1','JuanPerez');
INSERT INTO Usuarios(usuarioLogueo ,contrasenia,nombreCompleto)VALUES ('usuario2','contra2','AnaRodriguez');
INSERT INTO Usuarios(usuarioLogueo ,contrasenia,nombreCompleto)VALUES ('usuario3','contra3','JosePaz');
INSERT INTO Usuarios(usuarioLogueo ,contrasenia,nombreCompleto)VALUES ('usuario4','contra4','MonicaLeal');
INSERT INTO Usuarios(usuarioLogueo ,contrasenia,nombreCompleto)VALUES ('usuario5','contra5','RamonRoldon');

INSERT INTO SolicitudEntrega(RUT,numeroP,fechaEntrega,estadoActual,direccion,nombreDest,usuarioLogueo) VALUES (111,1,'12/12/2021','endeposito', 'Calle1', 'Cliente1','usuario1');
INSERT INTO SolicitudEntrega(RUT,numeroP,fechaEntrega,estadoActual,direccion,nombreDest,usuarioLogueo) VALUES (555,1,'03/05/2021','endeposito', 'Calle2', 'Cliente2','usuario5');
INSERT INTO SolicitudEntrega(RUT,numeroP,fechaEntrega,estadoActual,direccion,nombreDest,usuarioLogueo) VALUES (222,1,'01/06/2021','encamino','Calle3', 'Cliente3','usuario3');
INSERT INTO SolicitudEntrega(RUT,numeroP,fechaEntrega,estadoActual,direccion,nombreDest,usuarioLogueo) VALUES (555,2,'28/07/2021','encamino', 'Calle4', 'Cliente4','usuario2');
INSERT INTO SolicitudEntrega(RUT,numeroP,fechaEntrega,estadoActual,direccion,nombreDest,usuarioLogueo) VALUES (111,2,'01/04/2021','entregado', 'Calle5', 'Cliente5','usuario3');



----------------------------------------------------------------------------------------------------------------

GO

Create Procedure LogueoUsuario 
@usuarioLogueo varchar (20), 
@contrasenia varchar (20) 
AS
Begin
	Select *	From Usuarios Where usuarioLogueo = @usuarioLogueo AND contrasenia = @contrasenia
End
go




GO

--ABM Empresas

CREATE PROC BuscarEmpresa
@RUT int 
AS
begin
		SELECT * FROM Empresas WHERE @RUT = RUT
end

GO

CREATE PROC AgregarEmpresa

	@RUT int ,
	@nombre varchar(50),
	@telefono varchar (50),
	@correoElectronico varchar (50)
	
	
AS
begin
	
	if exists (SELECT * FROM Empresas WHERE RUT = @RUT)
		return -1 --La empresa ya existe
	
		INSERT Empresas VALUES (@RUT, @nombre,@telefono,@correoElectronico)
		if @@ERROR <> 0
		begin			
			return -2 --Error al insertar
		end			

		return 1
end
/*declare @resp int
exec @resp = AgregarEmpresa 777,'Emp7','541531','hgjfghjfgjgfj'
print @resp*/
GO



CREATE PROC EliminarEmpresa
	@RUT int
AS
begin
		If not exists (SELECT * FROM Empresas WHERE RUT = @RUT)		
			return -1	
		if exists (SELECT numeroInterno From SolicitudEntrega WHERE RUT = @RUT)
			return -2
				
				begin transaction 
 
					declare @falla int  
					delete from Paquetes where RUT = @RUT     
					set @falla=@@ERROR    					     
					delete from Empresas where RUT = @RUT
				
	
					if(@falla<>0)             
						begin               
							rollback transaction    
							return -3     
						end	
							COMMIT TRANSACTION
							return 1	
				
end
/*declare @resp int
exec @resp = EliminarEmpresa 222
print @resp*/
GO

CREATE PROCEDURE ModificarEmpresa
	@RUT int ,
	@nombre varchar(50),
	@telefono varchar (50),
	@correoElectronico varchar (50)
AS
begin
		IF not exists (SELECT * FROM Empresas WHERE RUT = @RUT)
				return -1

		
			UPDATE Empresas 
			SET nombre = @nombre,
			telefono = @telefono,
			correoElectronico = @correoElectronico
			WHERE RUT = @RUT
			
			IF @@ERROR <> 0
				begin
					RETURN -2;
				end		

			RETURN 1;
			


end

GO
/*declare @resp int
exec @resp = ModificarEmpresa 555,'AAA', '4124214', 'aaaa@gmail.com'
print @resp*/



CREATE PROCEDURE ListarEmpresas
AS
begin
		SELECT RUT,nombre,telefono,correoElectronico FROM Empresas

end
GO

-------------ABM Paquetes

CREATE PROC BuscarPaquete
@numeroP int,
@RUT int
AS
begin
		SELECT * FROM Paquetes WHERE @numeroP = numeroP AND @RUT = RUT
end

GO

CREATE PROC AgregarPaquete
	@RUT int , 
	@numeroP int , 
	@peso float , 
	@tipoDePaquete varchar (20),
	@descripción varchar (50) 

AS
begin
		if not exists (SELECT * FROM Empresas WHERE  RUT = @RUT)
			return -1
		if exists (SELECT * FROM Paquetes WHERE  RUT = @RUT AND numeroP = @numeroP)
			return -2 
		if @peso <= 0
			return -3
		if @tipoDePaquete NOT IN ('comun','bulto','fragil')
			return -4

		
		INSERT Paquetes VALUES (@RUT,@numeroP,@peso,@tipoDePaquete,@descripción)

		if @@ERROR <> 0
			return -5
					
		return 1

end
/*declare @resp int
exec @resp = AgregarPaquete 111, 2, 15,
print @resp*/
GO

CREATE PROC ModificarPaquete
	@RUT int , 
	@numeroP int , 
	@peso float , 
	@tipoDePaquete varchar (20),
	@descripción varchar (50)

AS
begin
		if not exists( SELECT * FROM Paquetes WHERE  RUT = @RUT AND @numeroP = numeroP)
			return -1
		if @peso <= 0
			return -2
		if @tipoDePaquete NOT IN ('comun','bulto','fragil')
			return -3
		
		
		UPDATE Paquetes set peso = @peso ,
		tipoDePaquete = @tipoDePaquete ,
		descripción = @descripción 
		WHERE RUT = @RUT AND @numeroP = numeroP
		

		if @@ERROR <> 0
			begin
				RETURN -4
			end

		RETURN 1

end

GO

CREATE PROC EliminarPaquete
	@RUT int , 
	@numeroP int

AS
begin
	
	if not exists (SELECT * FROM Paquetes WHERE @RUT = RUT AND @numeroP = numeroP)
		return -1
	
	DECLARE @Error int
	begin transaction

		DELETE FROM SolicitudEntrega WHERE @RUT = RUT AND @numeroP = numeroP
		SET @Error = @@ERROR

		DELETE FROM Paquetes WHERE @RUT = RUT AND @numeroP = numeroP
		SET @Error = @Error + @@ERROR
		
		if @Error <> 0
			begin
				ROLLBACK TRANSACTION 
				RETURN -2
			end
		
		COMMIT TRANSACTION
		RETURN 1
end

GO
CREATE PROCEDURE ListarPaquetesSinSolicitud
AS
begin				
		SELECT RUT,numeroP,peso,tipoDePaquete,descripción FROM Paquetes WHERE NOT EXISTS (SELECT * FROM SolicitudEntrega WHERE Paquetes.RUT = SolicitudEntrega.RUT AND Paquetes.numeroP = SolicitudEntrega.numeroP)
		

end		
GO
CREATE PROCEDURE ListarPaquetesXEmpresa
@RUT int
AS
begin				
		SELECT numeroP,peso,tipoDePaquete,descripción FROM Paquetes WHERE  Paquetes.RUT = @RUT
		

end		

GO
-------------------------------------------------------------------------------------------------
--ABM Usuarios

CREATE PROC BuscarUsuario
@usuarioLogueo varchar(20) 
AS
begin
		SELECT * FROM Usuarios WHERE @usuarioLogueo = usuarioLogueo
end

GO

CREATE PROC AgregarUsuario
	
	@usuarioLogueo varchar (20),
	@contrasenia varchar (20),
	@nombreCompleto varchar(50)

AS
begin
	if exists(SELECT * FROM Usuarios WHERE @usuarioLogueo = usuarioLogueo )
		return -1

	
		INSERT Usuarios VALUES (@usuarioLogueo,@contrasenia,@nombreCompleto)
	
		if @@Error <> 0
			begin
				return -2
			end

		
		return 1
end

GO

CREATE PROC ModificarUsuario

	@usuarioLogueo varchar (20),
	@contrasenia varchar (20),
	@nombreCompleto varchar(50)

AS
begin
	if not exists(SELECT * FROM Usuarios WHERE @usuarioLogueo = usuarioLogueo )
		return -1
		
		UPDATE Usuarios 
		SET contrasenia = @contrasenia,
		nombreCompleto = @nombreCompleto
		WHERE usuarioLogueo = @usuarioLogueo
		

		if @@error <> 0
			begin 
				return -2
			end
		

		return 1
end

GO

CREATE PROC EliminarUsuario

	@usuarioLogueo varchar (20)

AS
begin
	
	if not exists (SELECT * FROM Usuarios WHERE usuarioLogueo = @usuarioLogueo)
		return -1
	if exists (SELECT * FROM SolicitudEntrega WHERE usuarioLogueo = @usuarioLogueo)
		return -2

	

		DELETE FROM Usuarios WHERE usuarioLogueo = @usuarioLogueo
		
		if @@ERROR <> 0
			begin
				return -3
			end

		return 1
end

GO

-------------------------------------------------------------------
--Registro de solicitud de entrega

CREATE PROC AgregarRegistro
    
	@numeroP int ,
	@RUT int ,
	@fechaEntrega datetime,
	@direccion varchar (30),
	@nombreDest varchar (20),
	@usuarioLogueo varchar(20)
	
AS
begin
		if not exists (SELECT * FROM Paquetes WHERE numeroP = @numeroP AND RUT = @RUT)
			return -1
		if not exists (SELECT * FROM Usuarios WHERE usuarioLogueo = @usuarioLogueo)
			return -2
		if @fechaEntrega < GETDATE()
		  return -3
		if exists (SELECT* FROM  SolicitudEntrega WHERE numeroP = @numeroP AND RUT = @RUT)
			return -4

		  			
		INSERT SolicitudEntrega VALUES (@numeroP, @RUT,@fechaEntrega,'endeposito',@direccion,@nombreDest,@usuarioLogueo)
		if @@ERROR <> 0
		begin
			return -5 --Error al insertar
		end			
		
		return 1

end

GO

CREATE PROCEDURE ListarSolicitudes
AS
begin				
	
		SELECT numeroInterno,numeroP,RUT,fechaEntrega,estadoActual,direccion,nombreDest,usuarioLogueo FROM  SolicitudEntrega

end		
GO

CREATE PROCEDURE ListarXFecha
@fecha datetime
AS
begin				
	
		SELECT numeroInterno,numeroP,RUT,estadoActual,direccion,nombreDest,usuarioLogueo FROM  SolicitudEntrega WHERE fechaEntrega = @fecha AND estadoActual = 'endeposito'

end		

GO
CREATE PROCEDURE ListarDepCam
AS
begin				
		SELECT numeroInterno,numeroP,RUT,fechaEntrega,estadoActual,direccion,nombreDest,usuarioLogueo FROM SolicitudEntrega WHERE SolicitudEntrega.estadoActual = 'endeposito' OR SolicitudEntrega.estadoActual = 'encamino' 
		

end		

GO

CREATE PROCEDURE ModificarEstado
@NumeroInt int,
@EstadoActual varchar(20)
AS
begin
		if @EstadoActual NOT IN ('endeposito','encamino')
			return -1
		IF @EstadoActual = 'encamino'
			UPDATE SolicitudEntrega set estadoActual = 'entregado' WHERE numeroInterno = @NumeroInt 
		IF @EstadoActual = 'endeposito'
			UPDATE SolicitudEntrega set estadoActual = 'encamino' WHERE numeroInterno = @NumeroInt 

		if @@ERROR <> 0
			begin
				RETURN -2
			end

		RETURN 1

end

GO

CREATE PROC BuscarSolicitud
@RUT int,
@numeroP int
AS
begin
		SELECT numeroInterno,fechaEntrega,estadoActual,direccion,nombreDest,usuarioLogueo FROM SolicitudEntrega WHERE @RUT = RUT AND  numeroP = @numeroP
end
