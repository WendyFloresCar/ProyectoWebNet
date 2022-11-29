
create database proyectobase


create table Empresa
(
idEmpresa int primary key identity(1,1),
ruc varchar(500),
razonSocial varchar(500)
)


create table Trabajador
(
idTrabajador int primary key identity(1,1),
nombres varchar(500),
apellidos varchar(500),
tipoDocumento varchar(10),
numeroDocumento varchar(50),
direccion varchar(max),
correo varchar(max),
idEmpresa int foreign key references Empresa(idEmpresa),
fechaNacimiento datetime,
estadoCivil varchar(500),
estado bit,
fechaCreacion datetime,
horaCreacion time
)

insert into Empresa values ('20252575457','LEVEL 3 PERU S.A.')
insert into Empresa values ('20429683581','MINERA LUREN.')
insert into Empresa values ('20331066703','INRETAIL PHARMA S.A')
