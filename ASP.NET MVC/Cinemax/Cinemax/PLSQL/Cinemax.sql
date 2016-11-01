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