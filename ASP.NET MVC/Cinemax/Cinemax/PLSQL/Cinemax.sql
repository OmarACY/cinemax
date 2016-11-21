CREATE TABLE "AspNetRoles" ( 
  "Id" NVARCHAR2(128) NOT NULL,
  "Name" NVARCHAR2(256) NOT NULL,
  PRIMARY KEY ("Id")
);


CREATE TABLE "AspNetUserRoles" ( 
  "UserId" NVARCHAR2(128) NOT NULL,
  "RoleId" NVARCHAR2(128) NOT NULL,
  PRIMARY KEY ("UserId", "RoleId")
);


CREATE TABLE "AspNetUsers" ( 
  "Id" NVARCHAR2(128) NOT NULL,
  "Email" NVARCHAR2(256) NULL,
  "EmailConfirmed" NUMBER(1) NOT NULL,
  "PasswordHash" NVARCHAR2(256) NULL,
  "SecurityStamp" NVARCHAR2(256) NULL,
  "PhoneNumber" NVARCHAR2(256) NULL,
  "PhoneNumberConfirmed" NUMBER(1) NOT NULL,
  "TwoFactorEnabled" NUMBER(1) NOT NULL,
  "LockoutEndDateUtc" TIMESTAMP(7) NULL,
  "LockoutEnabled" NUMBER(1) NOT NULL,
  "AccessFailedCount" NUMBER(10) NOT NULL,
  "UserName" NVARCHAR2(256) NOT NULL,
  PRIMARY KEY ("Id")
);


CREATE TABLE "AspNetUserClaims" ( 
  "Id" NUMBER(10) NOT NULL,
  "UserId" NVARCHAR2(128) NOT NULL,
  "ClaimType" NVARCHAR2(256) NULL,
  "ClaimValue" NVARCHAR2(256) NULL,
  PRIMARY KEY ("Id")
);


CREATE SEQUENCE "AspNetUserClaims_SEQ";


CREATE OR REPLACE TRIGGER "AspNetUserClaims_INS_TRG"
  BEFORE INSERT ON "AspNetUserClaims"
  FOR EACH ROW
BEGIN
  SELECT "AspNetUserClaims_SEQ".NEXTVAL INTO :NEW."Id" FROM DUAL;
END;


CREATE TABLE "AspNetUserLogins" ( 
  "LoginProvider" NVARCHAR2(128) NOT NULL,
  "ProviderKey" NVARCHAR2(128) NOT NULL,
  "UserId" NVARCHAR2(128) NOT NULL,
  PRIMARY KEY ("LoginProvider", "ProviderKey", "UserId")
);


CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("Name");

CREATE INDEX "IX_AspNetUserRoles_UserId" ON "AspNetUserRoles" ("UserId");


CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");


CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("UserName");


CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");


CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");


ALTER TABLE "AspNetUserRoles"
  ADD CONSTRAINT "FK_UserRoles_Roles" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id")
  ON DELETE CASCADE;

ALTER TABLE "AspNetUserRoles"
  ADD CONSTRAINT "FK_UserRoles_Users" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id")
  ON DELETE CASCADE;

ALTER TABLE "AspNetUserClaims"
  ADD CONSTRAINT "FK_UserClaims_Users" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id")
  ON DELETE CASCADE;

ALTER TABLE "AspNetUserLogins"
  ADD CONSTRAINT "FK_UserLogins_Users" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id")
  ON DELETE CASCADE;

CREATE table "Cine" (
    "clave_cin"  NUMBER(19) NOT NULL,
    "nombre"     NVARCHAR2(30) NOT NULL,
    "num_salas"  NUMBER(10) NOT NULL,
    "colonia"    NVARCHAR2(45) NOT NULL,
    "calle"      NVARCHAR2(45) NOT NULL,
    "numero"     NUMBER(10) NOT NULL
)
/

alter table "Cine" add constraint  "Cine_PK" primary key ("clave_cin")
/

CREATE sequence "CINE_SEQ" 
/

CREATE trigger "BI_Cine"  
  before insert on "Cine"              
  for each row 
begin  
  if :NEW."clave_cin" is null then
    select "CINE_SEQ".nextval 
    into :NEW."clave_cin" 
    from dual;
  end if;
end;
/  

CREATE table "TelCin" (
    "clave_cin"  NUMBER(19) NOT NULL,
    "telefono"   NVARCHAR2(15) NOT NULL
)
/

alter table "TelCin" add constraint  "tel_cin_PK" primary key ("clave_cin","telefono")
/

ALTER TABLE "TelCin" ADD CONSTRAINT "TEL_CIN_FK" 
FOREIGN KEY ("clave_cin")
REFERENCES "Cine" ("clave_cin")

/

CREATE table "Sala" (
    "clave_sal"  NUMBER(19) NOT NULL,
    "clave_cin"  NUMBER(19) NOT NULL,
    "cupo"       NUMBER(10) NOT NULL,
    constraint  "SALA_PK" primary key ("clave_sal")
)
/

CREATE sequence "SALA_SEQ" 
/

CREATE trigger "BI_sala"  
  before insert on "Sala"              
  for each row 
begin  
  if :NEW."clave_sal" is null then
    select "SALA_SEQ".nextval into :NEW."clave_sal" from dual;
  end if;
end;
/   

ALTER TABLE "Sala" ADD CONSTRAINT "SALA_CINE_FK" 
FOREIGN KEY ("clave_cin")
REFERENCES "Cine" ("clave_cin")

/

CREATE table "Pelicula" (
    "clave_pel"     NUMBER(19) NOT NULL,
    "nombre"        NVARCHAR2(30) NOT NULL,
    "director"      NVARCHAR2(30) NOT NULL,
    "sinopsis"      NVARCHAR2(300) NOT NULL,
    "clasificacion" NVARCHAR2(3) NOT NULL,
    "genero"        NVARCHAR2(15) NOT NULL,
    constraint  "Pelicula_PK" primary key ("clave_pel")
)
/

CREATE sequence "PELICULA_SEQ" 
/

CREATE trigger "BI_Pelicula"  
  before insert on "Pelicula"              
  for each row 
begin  
  if :NEW."clave_pel" is null then
    select "PELICULA_SEQ".nextval into :NEW."clave_pel" from dual;
  end if;
end;
/   

CREATE table "Funcion" (
    "clave_fun"  NUMBER(19) NOT NULL,
    "clave_pel"  NUMBER(19) NOT NULL,
    "clave_sal"  NUMBER(19) NOT NULL,
    "hora_ini"   TIMESTAMP(7) NOT NULL,
    "hora_fin"   TIMESTAMP(7) NOT NULL,
    "fecha"      TIMESTAMP(7) NOT NULL,
    "cupo"       NUMBER(10) NOT NULL,
    constraint  "Funcion_PK" primary key ("clave_fun")
)
/

CREATE sequence "FUNCION_SEQ" 
/

CREATE trigger "BI_Funcion"  
  before insert on "Funcion"              
  for each row 
begin  
  if :NEW."clave_fun" is null then
    select "FUNCION_SEQ".nextval into :NEW."clave_fun" from dual;
  end if;
end;
/   

ALTER TABLE "Funcion" ADD CONSTRAINT "FUNCION_FK" 
FOREIGN KEY ("clave_pel")
REFERENCES "Pelicula" ("clave_pel")

/
ALTER TABLE "Funcion" ADD CONSTRAINT "FUNCION_FK2" 
FOREIGN KEY ("clave_sal")
REFERENCES "Sala" ("clave_sal")

/

CREATE table "Membresia" (
    "clave_mem"  NUMBER(19) NOT NULL,
    "nombre"     NVARCHAR2(30) NOT NULL,
    "app"        NVARCHAR2(30) NOT NULL,
    "apm"        NVARCHAR2(30) NOT NULL,
    "fecha_nac"  TIMESTAMP(7) NOT NULL,
    "colonia"    NVARCHAR2(45) NOT NULL,
    "calle"      NVARCHAR2(45) NOT NULL,
    "numero"     NUMBER(10) NOT NULL,
    "tipo"       NVARCHAR2(10) NOT NULL,
    "puntos"     NUMBER(10) NOT NULL,
    constraint  "Membresia_PK" primary key ("clave_mem")
)
/

CREATE sequence "MEMBRESIA_SEQ" 
/

CREATE trigger "BI_Membresia"  
  before insert on "Membresia"              
  for each row 
begin  
  if :NEW."clave_mem" is null then
    select "MEMBRESIA_SEQ".nextval into :NEW."clave_mem" from dual;
  end if;
end;
/   

CREATE table "Empleado" (
    "clave_emp"  NUMBER(19) NOT NULL,
    "nombre"     NVARCHAR2(30) NOT NULL,
    "app"        NVARCHAR2(30) NOT NULL,
    "apm"        NVARCHAR2(30) NOT NULL,
    "fecha_nac"  TIMESTAMP(7) NOT NULL,
    "colonia"    NVARCHAR2(45) NOT NULL,
    "calle"      NVARCHAR2(45) NOT NULL,
    "numero"     NUMBER(10) NOT NULL,
    "password"   NVARCHAR2(256) NOT NULL,
    constraint  "Empleado_PK" primary key ("clave_emp")
)
/

CREATE sequence "EMPLEADO_SEQ" 
/

CREATE trigger "BI_Empleado"  
  before insert on "Empleado"              
  for each row 
begin  
  if :NEW."clave_emp" is null then
    select "EMPLEADO_SEQ".nextval into :NEW."clave_emp" from dual;
  end if;
end;
/   

CREATE table "TelEmp" (
    "clave_emp"  NUMBER(19) NOT NULL,
    "telefono"   NVARCHAR2(15) NOT NULL
)
/

alter table "TelEmp" add constraint  "TelEmp_PK" primary key ("clave_emp","telefono")
/

ALTER TABLE "TelEmp" ADD CONSTRAINT "TELEMP_FK" 
FOREIGN KEY ("clave_emp")
REFERENCES "Empleado" ("clave_emp")

/

CREATE table "Venta" (
    "clave_venta" NUMBER(19) NOT NULL,
    "clave_mem"   NUMBER(19) NOT NULL,
    "clave_fun"   NUMBER(19) NOT NULL,
    "clave_emp"   NUMBER(19) NOT NULL,
    "total"       FLOAT(49) NOT NULL,
    constraint  "Venta_PK" primary key ("clave_venta")
)
/

CREATE sequence "VENTA_SEQ" 
/

CREATE trigger "BI_Venta"  
  before insert on "Venta"              
  for each row 
begin  
  if :NEW."clave_venta" is null then
    select "VENTA_SEQ".nextval into :NEW."clave_venta" from dual;
  end if;
end;
/   

ALTER TABLE "Venta" ADD CONSTRAINT "VENTA_FK" 
FOREIGN KEY ("clave_mem")
REFERENCES "Membresia" ("clave_mem")

/
ALTER TABLE "Venta" ADD CONSTRAINT "VENTA_FK2" 
FOREIGN KEY ("clave_fun")
REFERENCES "Funcion" ("clave_fun")

/
ALTER TABLE "Venta" ADD CONSTRAINT "VENTA_FK3" 
FOREIGN KEY ("clave_emp")
REFERENCES "Empleado" ("clave_emp")

/


CREATE table "Cuenta" (
    "clave_venta"    NUMBER(19) NOT NULL,
    "numero_tarjeta" NVARCHAR2(16) NOT NULL,
    "codigo_seg"     NVARCHAR2(4) NOT NULL,
    "fecha_venta"    TIMESTAMP(7) NOT NULL,
    constraint  "Cuenta_PK" primary key ("clave_venta")
)
/

ALTER TABLE "Cuenta" ADD CONSTRAINT "CUENTA_FK" 
FOREIGN KEY ("clave_venta")
REFERENCES "Venta" ("clave_venta")

/


CREATE table "DetalleVenta" (
    "clave_venta"  NUMBER(19) NOT NULL,
    "subtotal"     FLOAT(49) NOT NULL,
    "asiento"      NVARCHAR2(5) NOT NULL,
    "tipo_asiento" NVARCHAR2(10) NOT NULL
)
/

alter table "DetalleVenta" add constraint  "DetalleVenta_PK" primary key ("clave_venta","asiento")
/

ALTER TABLE "DetalleVenta" ADD CONSTRAINT "DETALLEVENTA_FK" 
FOREIGN KEY ("clave_venta")
REFERENCES "Venta" ("clave_venta")

/

alter table "Empleado" add
("nombre_usuario" NVARCHAR2(256))
/   


alter table "Empleado" add
("email" NVARCHAR2(256))
/   


CREATE OR REPLACE TRIGGER "SALAS_CINE"
  AFTER INSERT ON "Cine"
  FOR EACH ROW
BEGIN
FOR i IN 1..:NEW."num_salas"
LOOP
    INSERT INTO "Sala"("clave_cin", "cupo") VALUES(:NEW."clave_cin",30);
END LOOP;
END;


CREATE OR REPLACE TRIGGER "ACTUALIZA_TOTAL"
  AFTER INSERT ON "DetalleVenta"
  FOR EACH ROW
BEGIN
  UPDATE "Venta" SET "total" = "total" + :NEW."subtotal" WHERE "clave_venta" = :NEW."clave_venta";
END;  


CREATE OR REPLACE TRIGGER "ACTUALIZA_PUNTOS_MEMBRESIA"
  AFTER INSERT ON "DetalleVenta"
  FOR EACH ROW
DECLARE
  cveMembresia NUMBER;
  pts  NUMBER;
BEGIN
  SELECT "clave_mem" INTO cveMembresia FROM "Venta" WHERE "clave_venta" = :NEW."clave_venta";
  pts := CAST(:NEW."subtotal" * 0.10 AS NUMBER);
  UPDATE "Membresia" SET "puntos" = "puntos" + pts WHERE "clave_mem" = cveMembresia;
END;


CREATE OR REPLACE TRIGGER "ACTUALIZA_CUPO_FUNCION"
  AFTER INSERT ON "Funcion"
  FOR EACH ROW
DECLARE
  cveFuncion NUMBER;
  cveSala NUMBER;
  cupoSala NUMBER;
BEGIN
  cveFuncion := :NEW."clave_fun";
  cveSala := :NEW."clave_sal";
  SELECT "cupo" INTO cupoSala FROM "Sala" WHERE "clave_sal" = cveSala;
  UPDATE "Funcion" SET "cupo" = cupoSala WHERE "clave_fun" = cveFuncion;
END;

CREATE OR REPLACE TRIGGER "ACTUALIZA_CUPO_TRASVENTA"
  AFTER INSERT ON "DetalleVenta"
  FOR EACH ROW
DECLARE
  cveVenta NUMBER;
  cveFuncion NUMBER;
  cupoNuevo NUMBER;
BEGIN
  cveVenta := :NEW."clave_venta";
  SELECT "clave_fun" INTO cveFuncion FROM "Venta" WHERE "clave_venta" = cveVenta;
  SELECT "cupo" INTO cupoNuevo FROM "Funcion" WHERE "clave_fun" = cveFuncion;
  cupoNuevo := cupoNuevo -1;
  UPDATE "Funcion" SET "cupo" = cupoNuevo WHERE "clave_fun" = cveFuncion;
END;

/*Despues de crear la base datos agregar el siguiente registro a la tabla "AspNetUsers"*/
/* Usuario base del sistema user: admin; password: Admin_1 */
eaf855b1-e2d9-4125-87a8-e694b82e83b6, 
admin@cinemax.mx, 
0, 
AOpAOBIJ+uzCkZOQyLApGY3xdCSUJw50KiZHim+cB6VomWpX845RBs+e3C6x+vjz9A==, 
e19199d0-8486-480a-8e02-b44fe658c4e9, 
NULL, 
0, 
0, 
NULL, 
1, 
0, 
admin