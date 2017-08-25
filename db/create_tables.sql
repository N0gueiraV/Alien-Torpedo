/*
Project: Alien-Torpedo
Description: create tables
Author: Renato Crudo
Date: 08/08/2017
*/

use dbAlien;

Go

/*
If OBJECT_ID('Grupo_evento') is not null Drop table Grupo_evento

If OBJECT_ID('Evento') is not null Drop table Evento
If OBJECT_ID('Tipo_evento') is not null Drop table Tipo_evento

If OBJECT_ID('Grupo_usuario') is not null Drop table Grupo_usuario

If OBJECT_ID('Usuario') is not null Drop table Usuario
If OBJECT_ID('Grupo') is not null Drop table Grupo
*/

-- Usuario
Create Table Usuario
(
	Cd_usuario		int identity(1,1)
	,Nm_email		varchar(80)	
	,Nm_usuario		varchar(80)
	,Nm_senha		varchar(20)
	,Dv_ativo		bit
	,Dt_inclusao	datetime
	Constraint pk_cd_usuario primary key(Cd_usuario)
)
go

-- Grupo
Create Table Grupo
(
	Cd_grupo		int identity(1,1)
	,Nm_grupo		varchar(60)
	,Dt_inclusao	datetime
	Constraint pk_cd_grupo primary key(Cd_grupo)
)
go

-- Grupo_usuario
Create Table Grupo_usuario
(
	Cd_usuario	int
	,Cd_grupo	int
	,Nr_voto	smallint
	Constraint pk_cd_usuario_grupo primary key(Cd_usuario, Cd_grupo)
	,Constraint fk_cd_usuario foreign key(Cd_usuario) references Usuario
	,Constraint fk_cd_grupo foreign key(Cd_grupo) references Grupo 
)
go

-- Tipo_evento
Create Table Tipo_evento
(
	Cd_tipo_evento	smallint
	,Nm_tipo_evento varchar(60)
	Constraint pk_cd_tipo_evento primary key(Cd_tipo_evento)
)
go

-- Evento
Create table Evento
(
	Cd_evento	int
	,Cd_tipo_evento smallint
	,Nm_evento	varchar(60)
	,Nm_endereco varchar(100)
	,Vl_evento float
	,Vl_nota float
	,Dv_particular bit
	,Cd_usuario int
	Constraint pk_cd_evento primary key(Cd_evento)
	,Constraint fk_evento_tipo_evento foreign key(Cd_tipo_evento) references Tipo_evento
	,Constraint fk_evento_usuario foreign key(Cd_usuario) references Usuario
)
go 

-- Grupo_evento
Create Table Grupo_evento
(
	Id_grupo_evento int
	,Cd_grupo		int
	,Cd_evento		int
	,Nm_descricao	varchar(80)
	,Dt_evento		datetime
	Constraint pk_id_grupo_evento primary key(Id_grupo_evento)
	,Constraint fk_grupo_evento_grupo foreign key(Cd_grupo) references Grupo
	,Constraint fk_grupo_evento_evento foreign key(Cd_evento) references Evento
)