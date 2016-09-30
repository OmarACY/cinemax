
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


-- APLICADO: BECARIOS-PC, OMARACY-MAC
-- Campo contraseña para la tabla Empleados
ALTER TABLE [Cinemax].[Persona].[empleado] 
ADD contraseña varchar(32) NOT NULL DEFAULT 'AdministracionBasesDatos';
GO
-- Fin

--ALPICADO: OMARACY-MAC, BECARIOS-PC
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

--APLICADO: OMARACY-MAC, BECARIOS-PC
--Modificacion de el tipo de dato de la tabla funcion de las columnas hora_ini y hora_fin de datetime a time
ALTER TABLE [Cinemax].[Cine].[Funcion] ALTER COLUMN hora_ini TIME NOT NULL;
ALTER TABLE [Cinemax].[Cine].[Funcion] ALTER COLUMN hora_fin TIME NOT NULL;
GO  

-- APLICADO: BECARIOS-PC
-- Eliminación de la columano clave_cue en la tabla venta debido a que la cuenta se puede obtener mediante la clave de venta 
ALTER TABLE [Cinemax].[Venta].[venta] DROP COLUMN clave_cue;
GO