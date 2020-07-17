SET ECHO OFF;
clear screen;
prompt Creando tablespace y asignando roles a usuario.;



-- Eliminando el usuario antes de quitar  tablespace.
Drop user belife cascade;


-- Eliminando el table space.
drop tablespace entornoBelife INCLUDING CONTENTS AND DATAFILES CASCADE CONSTRAINTS;


-- Creando el tablespace del entorno.
CREATE TABLESPACE entornoBelife
DATAFILE 'entornobelife.dbf'
size 500M
autoextend on;


-- Creando el usuario.
CREATE USER belife
IDENTIFIED BY belife
DEFAULT TABLESPACE entornoBelife
temporary tablespace temp;


-- Asignando los privilegios al usuario.
GRANT CREATE SESSION TO belife;
GRANT RESOURCE TO belife;
GRANT CREATE VIEW TO belife;
REVOKE UNLIMITED TABLESPACE FROM  belife;


-- Definiendo el tablespace que trabajara el usuario.
ALTER USER belife QUOTA UNLIMITED ON entornoBelife;


-- Estableciendo cambios.
commit;




prompt creando objetos de la base de datos de belife.
-- Eliminacion de tablas.
drop table belife.estadoCivil cascade constraint;
drop table belife.sexo cascade constraint;
DROP TABLE belife.cliente CASCADE CONSTRAINTS;
drop table belife.contrato cascade constraint;
drop table belife.plan cascade constraint;



-- Creacion de tablas.
prompt Creacion de tablas;
prompt Tabla cliente;
CREATE TABLE belife.cliente(
rutCliente varchar2(10) not null,
                nombreCliente VARCHAR2(20) NOT NULL           ,
				apellidosCliente varchar2(20) not null,
				fechaNacimiento date not null,
				idSexo number(1) not null,
				idEstadoCivil number(1) not null,
                CONSTRAINT cliente_pk PRIMARY KEY (rutCliente)
        ) tablespace entornoBelife;

		

		prompt Tabla sexo;
CREATE TABLE belife.Sexo(
                idSexo   NUMBER(1) NOT NULL           ,
                descripcion VARCHAR2(10) NOT NULL           ,
                CONSTRAINT sexo_pk PRIMARY KEY ( idSexo ),
                CONSTRAINT sexo_descripcion_un UNIQUE ( descripcion )
        ) tablespace entornoBelife;
		
		
		prompt Tabla estado civil;
		CREATE TABLE belife.EstadoCivil(
                idEstadoCivil   NUMBER(1) NOT NULL           ,
                descripcion VARCHAR2(15) NOT NULL           ,
                CONSTRAINT estadoCivil_pk PRIMARY KEY ( idEstadoCivil ),
                CONSTRAINT estadoCivil_descripcion_un UNIQUE ( descripcion )
        ) tablespace entornoBelife;
		
		
		prompt Tabla contrato;
		create table belife.contrato(
		numero varchar2(14) not null,
		fechaContrato timestamp not null,
		fechaTerminoContrato timestamp,
		rutCliente varchar2(10) not null,
		idPlan varchar2(5) not null,
		fechaInicioVigencia timestamp not null,
		fechaFinVigencia timestamp not null,
		vigente number(1) not null,
		declaracionSalud number(1) not null,
		primaAnual number(6,2) not null,
		primaMensual number(6,2) not null,
		observaciones varchar2(250),
		constraint contrato_pk primary key (numero, rutCliente, idPlan)
) tablespace entornoBelife;


prompt Tabla plan;
create table belife.plan(
idPlan varchar(5) not null,
nombre varchar2(20) not null,
primaBase number(6,2) not null,
polizaActual varchar2(15) not null,
constraint planpk primary key (idPlan) 
) tablespace entornoBelife;





-- Claves foraneas.
prompt Claves foraneas para tabla cliente;
ALTER TABLE belife.cliente 
ADD CONSTRAINT cliente_sexo_fk FOREIGN KEY (idSexo)
REFERENCES belife.sexo (idSexo)
ADD CONSTRAINT cliente_estadoCivil_fk FOREIGN KEY (idEstadoCivil)
REFERENCES belife.estadoCivil (idEstadoCivil);


prompt Claves foraneas para tabla contrato.
alter table vbelife.contrato
add constraint contrato_cliente_fk foreign key (rutCliente)
references belife.cliente (rutCliente)
add constraint contrato_plan_fk (idPlan)
references belife.plan (idPlan)





prompt Insertando datos..;
		-- Insercion de datos.
										-- Insertando estados civil;
prompt Insertando estado civil;
insert into belife.estadoCivil values (1, 'Soltero');
insert into belife.estadoCivil values(2,'Casado');
insert into belife.estadoCivil values(3, 'Divorciado');
insert into belife.estadoCivil values(4, 'Viudo');


-- Insertando sexo.
prompt insertando sexo;
INSERT INTO belife.sexo VALUES(1, 'hombre');
INSERT INTO belife.sexo VALUES(2, 'Mujer');



		
		prompt Insertando planes.
		insert into belife.plan values('VID01','Vida Inicial', 0.5 ,'POL120113229');
		insert into belife.plan values('VID02','Vida Total',3.5,'POL120648575');
		insert into belife.plan values ('VID03','Vida Conductor',1.2,'POL125235079');
		insert into belife.plan values ('VID04','Vida Senior',2.0,'POL120100054');
		insert into belife.plan values ('VID05','Vida Ahorro',3.5,'POL120500489');


-- Confirmando cambios.
prompt Confirmando los cambios;
commit;

prompt Resultado:;
SELECT 
(SELECT COUNT(*)  FROM belife.estadoCivil) AS "Estado civil",
(select count(*)  from belife.sexo) AS Sexo,
(select count(*) from belife.plan) AS Planes
FROM dual;
