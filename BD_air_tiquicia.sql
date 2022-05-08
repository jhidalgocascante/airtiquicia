
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
                              AeropuertoDestino  VARCHAR(250)
							  );		

ALTER TABLE VueloCalendario ADD  CodDestino INT;

ALTER TABLE VueloCalendario ADD CONSTRAINT CodDestino
	FOREIGN KEY (CodDestino) REFERENCES Destinos(CodDestino);


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


--drop procedure sp_guardarVuelo;
create  procedure sp_guardarVuelo(
@NombreVuelo VARCHAR(250),
@FechaVuelo VARCHAR(50),
@DuracionVuelo DECIMAL(6,2),
@PaisOrigen  VARCHAR(100),
@AeropuertoOrigen  VARCHAR(250),
@PaisDestino  VARCHAR(100),
@AeropuertoDestino  VARCHAR(250),
@CodDestino  int
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
AeropuertoDestino,
CodDestino
) values
(@NombreVuelo,
@FechaVuelo,
@DuracionVuelo,
@PaisOrigen,
@AeropuertoOrigen,
@PaisDestino,
@AeropuertoDestino,
@CodDestino)

end


--drop procedure sp_editarVuelo
create procedure sp_editarVuelo(
@CodVuelo int,
@NombreVuelo VARCHAR(250),
@FechaVuelo VARCHAR(50),
@DuracionVuelo DECIMAL(6,2),
@PaisOrigen  VARCHAR(100),
@AeropuertoOrigen  VARCHAR(250),
@PaisDestino  VARCHAR(100),
@AeropuertoDestino  VARCHAR(250),
@CodDestino int
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
AeropuertoDestino = @AeropuertoDestino,
CodDestino = @CodDestino
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




-------drop procedure sp_buscarVuelos
create procedure sp_buscarVuelos(
@DestinoBusqueda VARCHAR(100),
@FechaInicio VARCHAR(50),
@FechaFinal VARCHAR(50)
)
as
begin
	 SELECT [CodVuelo]
      ,[NombreVuelo]
      ,[FechaVuelo]
      ,[DuracionVuelo]
      ,[PaisOrigen]
      ,[AeropuertoOrigen]
      ,[PaisDestino]
      ,[AeropuertoDestino]
	  ,[VueloCalendario].[CodDestino]
	  ,[Destinos].[DescripcionDestino]
	  ,[Destinos].[ValorDestino]
	  ,[Destinos].[CodClase]
	  ,[TipoClase].NombreClase
  FROM [AIRTIQUICIA].[dbo].[VueloCalendario], [AIRTIQUICIA].[dbo].[Destinos],
       [AIRTIQUICIA].[dbo].[TipoClase]
  WHERE [PaisDestino] like '%'+@DestinoBusqueda+'%'
     and ( (FechaVuelo >= cast(@FechaInicio as date)) and (FechaVuelo <= cast(@FechaFinal as date)))
	 and [Destinos].[CodDestino] = [VueloCalendario].[CodDestino]
	 and [TipoClase].CodClase = [Destinos].[CodClase]
end;




CREATE TABLE Reserva(   CodReserva INT identity PRIMARY KEY,
						CodVuelo INT,
						NumOcupantes INT,
						NumKilosEquipaje DECIMAL(17,2),
						MonTiquete DECIMAL(17,2),
						MonEquipaje DECIMAL(17,2),
						MonTotal DECIMAL(17,2),
						--
						NumIdentificacion VARCHAR(60),
						NomIdentificacion VARCHAR(100),
						ApeIdentificacion VARCHAR(250),
						FecNacimiento VARCHAR(20),
						DesCorreo VARCHAR(100),
						NumTelefono VARCHAR(30)
							  );		

ALTER TABLE Reserva ADD CONSTRAINT CodVuelo
	FOREIGN KEY (CodVuelo) REFERENCES VueloCalendario(CodVuelo);


--drop procedure sp_listarReserva
create procedure sp_listarReserva
as
begin
 SELECT [Reserva].[CodReserva],
       [Reserva].[CodVuelo],
        [Reserva].[NumOcupantes], 
        [Reserva].[NumKilosEquipaje], 
        [Reserva].[MonTiquete], 
        [Reserva].[MonEquipaje], 
        [Reserva].[MonTotal], 
        [Reserva].[NumIdentificacion],
        [Reserva].[NomIdentificacion],
        [Reserva].[ApeIdentificacion],
        [Reserva].[FecNacimiento],
        [Reserva].[DesCorreo],
        [Reserva].[NumTelefono],
		[VueloCalendario].[NombreVuelo] ,
        [VueloCalendario].[FechaVuelo],
        [VueloCalendario].[PaisDestino],
	  [Destinos].[DescripcionDestino],
	  [Destinos].[ValorDestino],
        [TipoClase].NombreClase
  FROM [AIRTIQUICIA].[dbo].[VueloCalendario], [AIRTIQUICIA].[dbo].[Destinos],
       [AIRTIQUICIA].[dbo].[TipoClase],[AIRTIQUICIA].[dbo].[Reserva]
  WHERE [Destinos].[CodDestino] = [VueloCalendario].[CodDestino]
	 and [TipoClase].CodClase = [Destinos].[CodClase]
	 and [Reserva].codVuelo = [VueloCalendario].[CodVuelo];

end;

--drop procedure sp_obtenerReserva
create procedure sp_obtenerReserva(
@CodReserva int
)
as
begin
SELECT [Reserva].[CodReserva],
       [Reserva].[CodVuelo],
        [Reserva].[NumOcupantes], 
        [Reserva].[NumKilosEquipaje], 
        [Reserva].[MonTiquete], 
        [Reserva].[MonEquipaje], 
        [Reserva].[MonTotal], 
        [Reserva].[NumIdentificacion],
        [Reserva].[NomIdentificacion],
        [Reserva].[ApeIdentificacion],
        [Reserva].[FecNacimiento],
        [Reserva].[DesCorreo],
        [Reserva].[NumTelefono],
		[VueloCalendario].[NombreVuelo] ,
        [VueloCalendario].[FechaVuelo],
        [VueloCalendario].[PaisDestino],
	  [Destinos].[DescripcionDestino],
	  [Destinos].[ValorDestino],
        [TipoClase].NombreClase
  FROM [AIRTIQUICIA].[dbo].[VueloCalendario], [AIRTIQUICIA].[dbo].[Destinos],
       [AIRTIQUICIA].[dbo].[TipoClase],[AIRTIQUICIA].[dbo].[Reserva]
  WHERE [Reserva].[CodReserva] = @CodReserva
    and [Destinos].[CodDestino] = [VueloCalendario].[CodDestino]
	 and [TipoClase].CodClase = [Destinos].[CodClase]
	 and [Reserva].codVuelo = [VueloCalendario].[CodVuelo];

end;


--drop procedure sp_guardarVuelo;
create  procedure sp_guardarReserva(
@CodVuelo INT,
@NumOcupantes INT,
@NumKilosEquipaje DECIMAL(17,2),
@MonTiquete DECIMAL(17,2),
@MonEquipaje DECIMAL(17,2),
@MonTotal DECIMAL(17,2),
@NumIdentificacion VARCHAR(60),
@NomIdentificacion VARCHAR(100),
@ApeIdentificacion VARCHAR(250),
@FecNacimiento VARCHAR(20),
@DesCorreo VARCHAR(100),
@NumTelefono VARCHAR(30)
)
as
begin
insert into Reserva(
CodVuelo,
NumOcupantes ,
NumKilosEquipaje ,
MonTiquete ,
MonEquipaje ,
MonTotal,
NumIdentificacion ,
NomIdentificacion ,
ApeIdentificacion ,
FecNacimiento ,
DesCorreo ,
NumTelefono 
) values
(@CodVuelo,
@NumOcupantes ,
@NumKilosEquipaje ,
@MonTiquete ,
@MonEquipaje ,
@MonTotal,
@NumIdentificacion ,
@NomIdentificacion ,
@ApeIdentificacion ,
@FecNacimiento ,
@DesCorreo ,
@NumTelefono )

end


--drop procedure sp_editarVuelo
create procedure sp_editarReserva(
@CodReserva INT,
@CodVuelo INT,
@NumOcupantes INT,
@NumKilosEquipaje DECIMAL(17,2),
@MonTiquete DECIMAL(17,2),
@MonEquipaje DECIMAL(17,2),
@MonTotal DECIMAL(17,2),
@NumIdentificacion VARCHAR(60),
@NomIdentificacion VARCHAR(100),
@ApeIdentificacion VARCHAR(250),
@FecNacimiento VARCHAR(20),
@DesCorreo VARCHAR(100),
@NumTelefono VARCHAR(30)
)
as
begin
update Reserva
set CodVuelo = @CodVuelo,
NumOcupantes = @NumOcupantes,
NumKilosEquipaje = @NumKilosEquipaje, 
MonTiquete = @MonTiquete ,
MonEquipaje = @MonEquipaje,
MonTotal = @MonTotal,
NumIdentificacion = @NumIdentificacion ,
NomIdentificacion = @NomIdentificacion,
ApeIdentificacion = @ApeIdentificacion ,
FecNacimiento = @FecNacimiento ,
DesCorreo = @DesCorreo,
NumTelefono = @NumTelefono
where CodReserva = @CodReserva;
end


create procedure sp_eliminarReserva(
@CodReserva int
)
as
begin
delete from Reserva
where CodReserva = @CodReserva

end




--
-------drop procedure sp_buscarVuelos
create procedure sp_buscarDetalleVuelo(
@CodVuelo int
)
as
begin
	 SELECT [CodVuelo]
      ,[NombreVuelo]
      ,[FechaVuelo]
      ,[DuracionVuelo]
      ,[PaisOrigen]
      ,[AeropuertoOrigen]
      ,[PaisDestino]
      ,[AeropuertoDestino]
	  ,[VueloCalendario].[CodDestino]
	  ,[Destinos].[DescripcionDestino]
	  ,[Destinos].[ValorDestino]
	  ,[Destinos].[CodClase]
	  ,[TipoClase].NombreClase
  FROM [AIRTIQUICIA].[dbo].[VueloCalendario], [AIRTIQUICIA].[dbo].[Destinos],
       [AIRTIQUICIA].[dbo].[TipoClase]
  WHERE [VueloCalendario].[CodVuelo] = @CodVuelo
	 and [Destinos].[CodDestino] = [VueloCalendario].[CodDestino]
	 and [TipoClase].CodClase = [Destinos].[CodClase]
end;
