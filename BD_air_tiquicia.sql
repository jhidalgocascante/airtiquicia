
create database AIRTIQUICIA;

USE AIRTIQUICIA;

CREATE TABLE TipoTripulante(CodTipoTripulante INT identity PRIMARY KEY,
							 NombreTipoTripulante VARCHAR(50) NOT NULL);



CREATE TABLE Tripulacion(CodTripulante INT identity PRIMARY KEY,
						 NombreTripulante VARCHAR(50) NOT NULL,
						 CodTipoTripulante INT NOT NULL);

ALTER TABLE Tripulacion ADD CONSTRAINT CodTipoTripulante
	FOREIGN KEY (CodTipoTripulante) REFERENCES TipoTripulante(CodTipoTripulante);


create procedure sp_listarTripulacion
as
begin
select * from Tripulacion

end

create procedure sp_obtenerTripulante(
@CodTripulante int
)
as
begin
select * from Tripulacion where CodTripulante = @CodTripulante

end



create procedure sp_guardarTripulante(
@NombreTripulante varchar(50),
@CodTipoTripulante int
)
as
begin
insert into Tripulacion(NombreTripulante,CodTipoTripulante) values
(@NombreTripulante,@CodTipoTripulante)

end



create procedure sp_editarTripulante(
@CodTripulante int,
@NombreTripulante varchar(50),
@CodTipoTripulante int
)
as
begin
update Tripulacion
set NombreTripulante = @NombreTripulante,
CodTipoTripulante = @CodTipoTripulante
where CodTripulante = @CodTripulante

end


create procedure sp_eliminarTripulante(
@CodTripulante int
)
as
begin
delete from Tripulacion
where CodTripulante = @CodTripulante

end

/****************************************************/

USE AIRTIQUICIA

CREATE TABLE TipoClase(CodClase INT identity PRIMARY KEY,
					   NombreClase VARCHAR(50) NOT NULL)



CREATE TABLE Destinos(CodDestino INT identity PRIMARY KEY,
					 NombreDestino VARCHAR(50) NOT NULL,
					 DescripcionDestino VARCHAR(50) NOT NULL,
				     CodClase INT NOT NULL,
					 ValorDestino DECIMAL(6,2) NOT NULL
					 )

ALTER TABLE Destinos ADD CONSTRAINT CodClase
	FOREIGN KEY (CodClase) REFERENCES TipoClase(CodClase);


create procedure sp_listarDestinos
as
begin
select * from Destinos

end

create procedure sp_obtenerDestino(
@CodDestino int
)
as
begin
select * from Destinos where CodDestino = @CodDestino

end



create procedure sp_guardarDestino(
@NombreDestino varchar(50),
@DescripcionDestino varchar(50),
@CodClase INT,
@ValorDestino DECIMAL(6,2)
)
as
begin
insert into Destinos(NombreDestino,DescripcionDestino,CodClase,ValorDestino) values
(@NombreDestino,@DescripcionDestino,@CodClase,@ValorDestino)

end



create procedure sp_editarDestino(
@CodDestino int,
@NombreDestino varchar(50),
@DescripcionDestino varchar(50),
@CodClase INT,
@ValorDestino DECIMAL(6,2)
)
as
begin
update Destinos
set NombreDestino = @NombreDestino,
DescripcionDestino = @DescripcionDestino,
CodClase = @CodClase,
ValorDestino = @ValorDestino
where CodDestino = @CodDestino

end


create procedure sp_eliminarDestino(
@CodDestino int
)
as
begin
delete from Destinos
where CodDestino = @CodDestino

end

/****************************************************/
/**EQUIPAJE *******/
USE AIRTIQUICIA


CREATE TABLE RangosEquipaje( CodRangoEquipaje INT identity PRIMARY KEY,
							 PesoInicio DECIMAL(6,2) NOT NULL,
							 PesoFin    DECIMAL(6,2) NOT NULL,
							 ValorEquipaje DECIMAL(6,2) NOT NULL,
							 DescripcionRango VARCHAR(200) NOT NULL
							 )


create procedure sp_listarRangosEquipaje
as
begin
select * from RangosEquipaje

end

create procedure sp_obtenerRangoEquipaje(
@CodRangoEquipaje int
)
as
begin
select * from RangosEquipaje where CodRangoEquipaje = @CodRangoEquipaje

end



create procedure sp_guardarRangoEquipaje(
@PesoInicio DECIMAL(6,2) ,
@PesoFin    DECIMAL(6,2) ,
@ValorEquipaje DECIMAL(6,2) ,
@DescripcionRango VARCHAR(200) 
)
as
begin
insert into RangosEquipaje(PesoInicio  ,PesoFin    ,ValorEquipaje ,DescripcionRango ) values
(@PesoInicio  ,@PesoFin    ,@ValorEquipaje ,@DescripcionRango)

end



create procedure sp_editarRangoEquipaje(
@CodRangoEquipaje INT ,
@PesoInicio DECIMAL(6,2) ,
@PesoFin    DECIMAL(6,2) ,
@ValorEquipaje DECIMAL(6,2) ,
@DescripcionRango VARCHAR(200) 
)
as
begin
update RangosEquipaje
set PesoInicio = @PesoInicio,
PesoFin   = @PesoFin ,
ValorEquipaje = @ValorEquipaje,
DescripcionRango = @DescripcionRango
where CodRangoEquipaje = @CodRangoEquipaje

end


create procedure sp_eliminarRangoEquipaje(
@CodRangoEquipaje int
)
as
begin
delete from RangosEquipaje
where CodRangoEquipaje = @CodRangoEquipaje

end


/****************************************************/
/**TIPOS DE AVIONES*******/
USE AIRTIQUICIA


CREATE TABLE MarcaAvion(CodMarca INT identity PRIMARY KEY,
					    NombreMarca VARCHAR(150) NOT NULL)

CREATE TABLE Avion( CodAvion INT identity PRIMARY KEY,
					CodMarca INT NOT NULL,
					ModeloAvion VARCHAR(100) NOT NULL,
				    DetalleAvion VARCHAR(250) NOT NULL
						 )

ALTER TABLE Avion ADD CONSTRAINT CodMarca
	FOREIGN KEY (CodMarca) REFERENCES MarcaAvion(CodMarca);

/**ESTE NO LE CREE EL DETALLE**/
CREATE TABLE AvionDistribucion( CodDistribucion INT identity PRIMARY KEY,
								CodAvion INT NOT NULL,
								CodClase INT NOT NULL,
								NumFilas INT NOT NULL,
								NumColumnas INT NOT NULL,
								NumAsientos INT NOT NULL
						 )

ALTER TABLE AvionDistribucion ADD CONSTRAINT CodAvionDistribucion
	FOREIGN KEY (CodAvion) REFERENCES Avion(CodAvion);

ALTER TABLE AvionDistribucion ADD CONSTRAINT CodClaseDistribucion
	FOREIGN KEY (CodClase) REFERENCES [TipoClase](CodClase);
						


create procedure sp_listarAvion
as
begin
select * from Avion

end

create procedure sp_obtenerAvion(
@CodAvion int
)
as
begin
select * from Avion where CodAvion = @CodAvion

end



create procedure sp_guardarAvion(
@CodMarca int,
@ModeloAvion varchar(100),
@DetalleAvion varchar(250)
)
as
begin
insert into Avion(CodMarca,ModeloAvion,DetalleAvion ) values
(@CodMarca,@ModeloAvion,@DetalleAvion )

end



create procedure sp_editarAvion(
@CodAvion int,
@CodMarca int,
@ModeloAvion varchar(100),
@DetalleAvion varchar(250)
)
as
begin
update Avion
set CodMarca = @CodMarca,
ModeloAvion = @ModeloAvion,
DetalleAvion = @DetalleAvion
where CodAvion = @CodAvion

end


create procedure sp_eliminarAvion(
@CodAvion int
)
as
begin
delete from Avion
where CodAvion = @CodAvion

end




/****************************************************/
/**TIPOS DE AVIONES*******/
USE AIRTIQUICIA



CREATE TABLE VueloCalendario( CodVuelo INT identity PRIMARY KEY,
                              NombreVuelo VARCHAR(250) NOT NULL,
							  FechaVuelo VARCHAR(25),
							  DuracionVuelo DECIMAL(6,2),
							  PaisOrigen  VARCHAR(100),
                              AeropuertoOrigen  VARCHAR(250),
							  PaisDestino  VARCHAR(100),
                              AeropuertoDestino  VARCHAR(250));		


create procedure sp_listarVuelo
as
begin
select * from VueloCalendario

end;

create procedure sp_obtenerVuelo(
@CodVuelo int
)
as
begin
select * from VueloCalendario where CodVuelo = @CodVuelo
end;



create procedure sp_guardarVuelo(
@NombreVuelo VARCHAR(250),
@FechaVuelo VARCHAR(50),
@DuracionVuelo DECIMAL(6,2),
@PaisOrigen  VARCHAR(100),
@AeropuertoOrigen  VARCHAR(250),
@PaisDestino  VARCHAR(100),
@AeropuertoDestino  VARCHAR(250)
)
as
begin
insert into VueloCalendario(
NombreVuelo,
FechaVuelo,
DuracionVuelo,
PaisOrigen,
AeropuertoOrigen,
PaisDestino,
AeropuertoDestino
) values
(@NombreVuelo,
@FechaVuelo,
@DuracionVuelo,
@PaisOrigen,
@AeropuertoOrigen,
@PaisDestino,
@AeropuertoDestino )

end



create procedure sp_editarVuelo(
@CodVuelo int,
@NombreVuelo VARCHAR(250),
@FechaVuelo VARCHAR(50),
@DuracionVuelo DECIMAL(6,2),
@PaisOrigen  VARCHAR(100),
@AeropuertoOrigen  VARCHAR(250),
@PaisDestino  VARCHAR(100),
@AeropuertoDestino  VARCHAR(250)
)
as
begin
update VueloCalendario
set NombreVuelo = @NombreVuelo,
FechaVuelo = FechaVuelo,
DuracionVuelo = @DuracionVuelo,
PaisOrigen = @PaisOrigen,
AeropuertoOrigen = @AeropuertoOrigen,
PaisDestino = @PaisDestino,
AeropuertoDestino = @AeropuertoDestino
where CodVuelo = @CodVuelo

end


create procedure sp_eliminarVuelo(
@CodVuelo int
)
as
begin
delete from VueloCalendario
where CodVuelo = @CodVuelo

end