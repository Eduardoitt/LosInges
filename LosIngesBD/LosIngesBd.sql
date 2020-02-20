create database LosInges
go 
use LosInges
create table TipoCliente(
IdTipoCliente int identity primary key not null,
Descripcion varchar(15)
)
--insert into TipoCliente values ('Frecuente'),('Casual')
--select *from TipoCliente
go
Create table Cliente(
IdCliente int identity primary key not null,
Nombre varchar(30),
ApPat varchar(20),
ApMat varchar(20),
Telefono varchar(10),
Correo varchar(40),
IdTipoCliente int foreign key (IdTipoCliente) references TipoCliente (IdTipoCliente)
)
go
create table Status_Auto(
IdStatus_Auto int identity primary key not null,
Descripcion varchar(15)
)
--insert into Status_Auto values ('Diagnostico'),('Reparacion'),('Listo')
--select *from Status_Auto
go
create table Auto(
IdAuto int identity primary key not null,
Placa varchar(7),
IdStatus_Auto int foreign key (IdStatus_Auto) references Status_Auto (IdStatus_Auto),
Marca varchar(10),
Modelo varchar(10),
Anio int,
IdCliente int foreign key (IdCliente) references Cliente(IdCliente)
)

go
create table Departamento(
IdDepartamento int identity primary key not null,
Descripcion varchar(25)
)
--insert into Departamento values ('Carroceria y pintura'),('Electrico'),('Alineacion y balanceo'),('Suspencion'),('Mecanico'),('Diagnostico'),('Refaccionaria')
--select *from Departamento
go
create table Puesto(
IdPuesto int identity primary key not null,
Descripcion varchar (15)
)
--insert into Puesto values ('Supervisor'),('Especialista'),('Cajero')
select *from Puesto
go
Create table Empleado(
IdEmpleado int identity primary key not null,
Nombre varchar(30),
ApPat varchar(20),
ApMat varchar(20),
IdDepartamento int foreign key (IdDepartamento) references Departamento (IdDepartamento),
IdPuesto int foreign key (IdPuesto) references Puesto (Idpuesto)
)
go
create table Diagnostico(
IdDiagnostico int identity primary key not null,
IdAuto int foreign key (IdAuto) references Auto (IdAuto),
IdEmpleado int foreign key (IdEmpleado) references Empleado(IdEmpleado)
)
go
create table Producto(
IdProducto int identity primary key not null,
Descripcion varchar(40),
NoParte varchar(15)
)
--insert into Producto values ('Frenos','123as'),('Caliper','1147gr')
--select *from Producto
go
create table Promocion(
IdPromocion int identity primary key not null,
Promocion int,
FechaInicio date,
Fechavenchimiento date
)
go
create table Restauracion(
IdRestauracion int identity primary key not null,
IdAuto int foreign key (IdAuto) references Auto(IdAuto),
IdEmpleado int foreign key (IdEmpleado) references Empleado(IdEmpleado),
IdDepartamento int foreign key (IdDepartamento) references Departamento (IdDepartamento),
Descripcion varchar(50),
PrecioRestauracion decimal(10,3),
IdProducto int foreign key (IdProducto) references Producto(IdProducto)
)
go
create table Factura(
IdFactura int identity primary key not null,
IdAuto int foreign key (IdAuto) references Auto(IdAuto),
IdCliente int foreign key (IdCliente) references Cliente(IdCliente),
IdRestauracion int foreign key (IdRestauracion) references Restauracion(IdRestauracion) ,
IdProducto int foreign key (IdProducto) references Producto(IdProducto),
IdPromocion int foreign key (IdPromocion) references Promocion (IdPromocion),
IdEmpleado int foreign key (IdEmpleado) references Empleado(IdEmpleado),
SubTotal decimal(10,3),
Total decimal(10,3),
FechaExpedicion date
)
go
create table Auto_Reparacion(
IdAuto int foreign key (IdAuto) references Auto(IdAuto) not null,
IdRestauracion int foreign key (IdRestauracion) references Restauracion(IdRestauracion)  not null,
 primary key(IdAuto,IdRestauracion) 
)
create table Producto_Reparacion(
IdProducto int foreign key (IdProducto) references Producto(IdProducto) not null,
IdRestauracion int foreign key (IdRestauracion) references Restauracion(IdRestauracion)  not null,
primary key(IdProducto,IdRestauracion)
)


-- alta de cliente
/*create procedure SP_Cliente_Alta
@Nombre varchar(50),
@ApPat varchar(50),
@ApMat varchar(50),
@Telefono varchar(10),
@Correo varchar(50)
as
begin
insert into Cliente (Nombre,ApPat,ApMat,Telefono,Correo,IdTipoCliente)
	values(@Nombre,@ApPat,@ApMat,@Telefono,@Correo,2)
end
*/
select *from Cliente
/*
create procedure SP_Cliente_Update
@IdCliente int,
@Nombre varchar(50),
@ApPat varchar(50),
@ApMat varchar(50),
@Telefono varchar(10),
@Correo varchar(50)
as
begin
		update Cliente set Nombre=@Nombre,ApPat=@ApPat,ApMat=@ApMat,Telefono=@Telefono,Correo=@Correo where IdCliente=@IdCliente
end
*/


/*
create procedure SP_Auto_Alta
@Placa varchar(7),
@Marca varchar(10),
@Modelo varchar(10),
@Anio int,
@IdCliente int
as
begin
insert into Auto (Placa,IdStatus_Auto,Marca,Modelo,Anio,IdCliente)
	values(@Placa,1,@Marca,@Modelo,@Anio,@IdCliente )
end
*/

create procedure Alta_Prod
@IdCliente int,
@Nombre varchar(50),
@ApPat varchar(50),
@ApMat varchar(50),
@Telefono varchar(10),
@Correo varchar(50)
as
begin
		update Cliente set Nombre=@Nombre,ApPat=@ApPat,ApMat=@ApMat,Telefono=@Telefono,Correo=@Correo where IdCliente=@IdCliente
end

ALTER procedure [dbo].[Alta_Producto]
@Descripcion varchar(40),
@NoParte varchar(15)
as
begin
insert into Producto (Descripcion,NoParte)
	values(@Descripcion,@NoParte)
end


create procedure Alta_Empleado
@Nombre varchar(30),
@ApPat varchar(20),
@ApMat varchar(20),
@IdDepartamento int,
@IdPuesto int
as
begin
insert into Empleado (Nombre,ApPat,ApMat,IdDepartamento,IdPuesto)
	values(@Nombre,@ApPat,@ApMat,@IdDepartamento,@IdPuesto)
end

select * from empleado
update Empleado set Nombre='Adrian' ,ApPat='Perez', ApMat='Portillo' , IdDepartamento=3 WHERE IdEmpleado=4

create procedure ListaEmpleado
as
begin
select LE.IdEmpleado,LE.Nombre,LE.ApPat, LE.ApMat,D.Descripcion as DepaEmp,P.Descripcion as PuestoEmp from    Empleado AS LE
INNER JOIN Departamento AS d on LE.IdDepartamento = d.IdDepartamento
inner join PUESTO AS P on  LE.IdPuesto = P.IdPuesto
end


