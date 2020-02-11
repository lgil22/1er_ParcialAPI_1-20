Create Database ArticulosDb
Go

use ArticulosDb
go

create table Articulos
(
	ProductoId int identity primary key,
	Descripcion varchar(100) NULL,
	Existencia decimal(12,2),
	Costo decimal(12, 2) NULL,
	ValorInventario decimal(14, 2) NULL,
)