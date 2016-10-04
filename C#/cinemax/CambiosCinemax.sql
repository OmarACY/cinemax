
-- APLICADO: BECARIOS-PC, MILAN-PC, OMARACY-MAC
-- Creación de trigger que inserta N número de salas como sean indicadas por el campo num_salas en la tabla cine
USE cinemax;
GO

create trigger InsertaSalas
  on Cine.cine
  for insert
 as 
  BEGIN
	DECLARE @cveCine bigint = (Select clave_cin from inserted);

	WHILE((SELECT num_salas FROM Cine WHERE clave_cin = @cveCine) > (SELECT COUNT(*) FROM Cine.sala WHERE clave_cin = @cveCine))
		BEGIN
			INSERT INTO Cine.sala(clave_cin, cupo) VALUES(@cveCine, 30);
		END;
  END;

GO
-- Fin


-- APLICADO: BECARIOS-PC, OMARACY-MAC, MILAN-PC
-- Campo contraseña para la tabla Empleados
ALTER TABLE [Cinemax].[Persona].[empleado] 
ADD contraseña varchar(32) NOT NULL DEFAULT 'AdministracionBasesDatos';
GO
-- Fin

--ALPICADO: OMARACY-MAC, BECARIOS-PC, MILAN-PC
--Reglas para el tipo de membresia y los generos de las peliculas
CREATE RULE TIPO_MEMBRESIA AS @var IN ('Standar', 'Premium', 'Vip')
GO
EXEC sp_bindrule 'TIPO_MEMBRESIA', 'Persona.membresia.tipo'
GO
CREATE RULE GENERO_PELICULA AS @var IN ('Terror', 'Comedia', 'Accion', 'Ciencia', 'Ficcion', 'Animacion', 'Infantil', 'Misterio', 'Drama')
GO
EXEC sp_bindrule 'GENERO_PELICULA', 'Cine.pelicula.genero'
GO
--Fin

--APLICADO: OMARACY-MAC, BECARIOS-PC, MILAN-PC
--Modificacion de el tipo de dato de la tabla funcion de las columnas hora_ini y hora_fin de datetime a time
ALTER TABLE [Cinemax].[Cine].[Funcion] ALTER COLUMN hora_ini TIME NOT NULL;
ALTER TABLE [Cinemax].[Cine].[Funcion] ALTER COLUMN hora_fin TIME NOT NULL;
GO  

-- APLICADO: BECARIOS-PC, MILAN-PC, OMARACY-MAC
-- Eliminación de la columano clave_cue en la tabla venta debido a que la cuenta se puede obtener mediante la clave de venta 
ALTER TABLE [Cinemax].[Venta].[venta] DROP COLUMN clave_cue;
GO


-- APLICADO: MILAN-PC
-- Disparador. Implementación de actualización del total de una venta en base a sus detalles
/****** Object:  Trigger [ActualizaTotal]    Script Date: 02/10/2016 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create trigger [ActualizaTotal]
  on [Cinemax].[Venta].[detalle_venta]
  for insert
 as 
  BEGIN
	DECLARE @cveVenta bigint = (Select clave_ven from inserted);
	DECLARE @subtotal float = (Select subtotal from inserted);

	UPDATE [Cinemax].[Venta].[venta] SET total = total + @subtotal WHERE clave_ven = @cveVenta;
  END;
GO
-- Fin


-- APLICADO: MILAN-PC
-- Disparador. Implementación de actualización de puntos por membresía
/****** Object:  Trigger [ActualizaTotal]    Script Date: 02/10/2016 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create trigger [ActualizaPuntosMembresia]
  on [Cinemax].[Venta].[detalle_venta]
  for insert
 as 
  BEGIN
	DECLARE @cveVenta bigint = (Select clave_ven from inserted);
	DECLARE @cveMembresia bigint = (Select clave_mem from [cinemax].[Venta].[venta] WHERE clave_ven = @cveVenta);
	DECLARE @subtotal float = (Select subtotal from inserted);
	DECLARE @puntos int = CAST(@subtotal * 0.10 as int);

	UPDATE [Cinemax].[Persona].[membresia] SET puntos = puntos + @puntos WHERE clave_mem = @cveMembresia;
  END;
GO
-- Fin


-- APLICADO MILAN-PC
-- Modificación de tabla función. Se agrega la columna cupo para así poder implementar el disparador de actualización de cupos
ALTER TABLE [cinemax].[Cine].[funcion] ADD cupo int NOT NULL DEFAULT 0;
GO

Create trigger [ActualizaCupoFuncion]
  on [Cinemax].[Cine].[funcion]
  for insert
 as 
  BEGIN
	DECLARE @cveFuncion bigint = (Select clave_fun from inserted);
	DECLARE @cveSala bigint = (Select clave_sal from inserted);
	DECLARE @cupo float = (Select cupo from [cinemax].[Cine].[sala] WHERE clave_sal = @cveSala);

	UPDATE [Cinemax].[Cine].[funcion] SET cupo = @cupo WHERE clave_fun = @cveFuncion;
  END;
GO

Create trigger [ActualizaCupoTrasVenta]
  on [Cinemax].[Venta].[detalle_venta]
  for insert
 as 
  BEGIN
	DECLARE @cveVenta bigint = (select clave_ven from inserted); 
	DECLARE @cveFuncion bigint = (Select clave_fun from [Venta].[venta] WHERE clave_ven = @cveVenta);

	UPDATE [Cinemax].[Cine].[funcion] SET cupo = (cupo - 1) WHERE clave_fun = @cveFuncion;
  END;
GO
-- Fin