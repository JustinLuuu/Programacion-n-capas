Create database ProductosNCapas
go
use ProductosNCapas
--------------------------------

create table Productos
(
   Id int identity(1,1),
   Nombre varchar(70),
   Marca varchar(40),
   Precio decimal(10,2),
   Proveedor varchar(40)
)

--- PROCEDURES

create procedure sp_Insertar(@Nombre varchar(70), @Marca varchar(40), @Precio decimal(10,2), @Proveedor varchar(40) ) -- INSERTAR INFO.
as
begin
      Insert into Productos values (@Nombre, @Marca, @Precio, @Proveedor)
end


create procedure sp_Mostrar -- MOSTRAR INFO.
as
begin
  Select * from dbo.Productos
end

exec sp_Mostrar

	Select * from dbo.Productos where Nombre = 'jugo' and Marca = 'santa'

	truncate table dbo.Productos