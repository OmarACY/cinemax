
-- APLICADO: BECARIOS-PC
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