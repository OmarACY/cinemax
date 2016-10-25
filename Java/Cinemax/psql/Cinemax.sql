-- Database: "Cinemax"
-- DROP DATABASE "Cinemax";
CREATE DATABASE "Cinemax"
  WITH OWNER = postgres
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       LC_COLLATE = 'Spanish_Spain.1252'
       LC_CTYPE = 'Spanish_Spain.1252'
       CONNECTION LIMIT = -1;


/******************************************************************************/


-- Creación de esquemas y tablas
-- APLICADO: MILAN-PC
create schema Persona;
create schema Cine;
create schema Venta;

create table Cine.cine (
	clave_cin bigserial not null,
	nombre varchar(30) not null,
	num_salas int not null,
	colonia varchar(45) not null,
	calle varchar(45) not null,
	numero int not null,
	constraint PK_CIN primary key (clave_cin)
);

create table Cine.tel_cin (
	clave_cin bigint not null,
	telefono varchar(15) not null,
	constraint FK_TEL_CIN foreign key (clave_cin) references Cine.cine(clave_cin)
);

create table Cine.sala(
	clave_sal bigserial not null,
	clave_cin bigint not null,
	cupo int not null,
	constraint PK_SAL primary key (clave_sal),
	constraint PK_SAL_CIN foreign key (clave_cin) references Cine.cine(clave_cin)
);

create table Cine.pelicula(
	clave_pel bigserial not null,
	nombre varchar(30) not null,
	director varchar(30) not null,
	sinopsis varchar(300) not null,
	clasificacion varchar(1) not null,
	genero varchar(15) not null,
	constraint PK_PEL primary key (clave_pel)
);

create table Cine.funcion (
	clave_fun bigserial not null,
	clave_pel bigint not null,
	clave_sal bigint not null,
	hora_ini time not null,
	hora_fin time not null,
	fecha date not null,
	constraint PK_FUN primary key (clave_fun),
	constraint FK_FUN_PEL foreign key (clave_pel) references Cine.pelicula(clave_pel),
	constraint FK_FUN_SAL foreign key (clave_sal) references Cine.sala(clave_sal)
);

create table Persona.membresia (
	clave_mem bigserial not null,
	nombre varchar(30) not null,
	app varchar(30) not null,
	apm varchar(30) not null,
	fecha_nac date not null,
	colonia varchar(45) not null,
	calle varchar(45) not null,
	numero int not null,
	tipo varchar(10) not null,
	puntos int not null,
	constraint PK_MEM primary key (clave_mem)
);

create table Persona.empleado (
	clave_emp bigserial not null,
	nombres varchar(30) not null,
	app varchar(30) not null,
	apm varchar(30) not null,
	fecha_nac date not null,
	colonia varchar(45) not null,
	calle varchar(45) not null,
	numero int not null,
        contraseña varchar(32) not null,
	constraint PK_EMP primary key (clave_emp)
);

create table Persona.tel_emp (
	clave_emp bigint not null,
	telefono varchar(15) not null,
	constraint FK_TEL_EMP foreign key (clave_emp) references Persona.empleado(clave_emp)
);

create table Venta.venta (
	clave_ven bigserial not null,
	total float not null,
	clave_mem bigint not null,
	clave_fun bigint not null,
	clave_emp bigint not null,
	constraint PK_VEN primary key (clave_ven),
	constraint FK_VEN_MEM foreign key (clave_mem) references Persona.membresia(clave_mem),
	constraint FK_VEN_FUN foreign key (clave_fun) references Cine.funcion(clave_fun),
	constraint FK_VEN_EMP foreign key (clave_emp) references Persona.empleado(clave_emp)	
);

create table Venta.cuenta(
	clave_ven bigint not null,
	numero_tar varchar(16) not null,
	codigo_seg varchar(4) not null,
	fecha_ven date not null,
	constraint FK_VEN_CUE foreign key (clave_ven) references Venta.venta(clave_ven)
);

create table Venta.detalle_venta(
	clave_ven bigint not null,
	subtotal float not null,
	asiento varchar(5) not null,
	tipo_asi varchar(10) not null,
	constraint FK_DET_VEN foreign key (clave_ven) references Venta.venta(clave_ven)
);

-- Adición de cupo en las funciones. Se utiliza al momento de consultar 
-- las funciones disponibles en la sección de ventas
-- APLICADO: OMAR-PC, MILAN-PC, BC-PC
ALTER TABLE Cine.funcion ADD cupo int NOT NULL DEFAULT 0;

-- Creación de trigger Inserta_Salas
-- APLICADO: OMAR-PC, MILAN-PC, BC-PC
CREATE OR REPLACE FUNCTION InsertaSalas() RETURNS TRIGGER AS $Inserta_Salas$
BEGIN
	WHILE(NEW.num_salas > (SELECT COUNT(*) FROM Cine.sala WHERE clave_cin = New.clave_cin)) LOOP
		INSERT INTO Cine.sala(clave_cin, cupo) VALUES(NEW.clave_cin, 30); 	
	END LOOP;
	
	RETURN NEW;
END
$Inserta_Salas$ LANGUAGE plpgsql;

CREATE TRIGGER Inserta_Salas AFTER INSERT ON Cine.cine
FOR EACH ROW EXECUTE PROCEDURE InsertaSalas();


-- Modificación del valor por defecto en el cupo de las funciones
-- APLICADO: BC-PC
ALTER TABLE Cine.funcion ALTER COLUMN cupo SET DEFAULT 80;