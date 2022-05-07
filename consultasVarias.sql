/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [CodVuelo]
      ,[NombreVuelo]
      ,[FechaVuelo]
      ,[DuracionVuelo]
      ,[PaisOrigen]
      ,[AeropuertoOrigen]
      ,[PaisDestino]
      ,[AeropuertoDestino]
  FROM [AIRTIQUICIA].[dbo].[VueloCalendario]
  WHERE [PaisDestino] like '%'+@Mexico+'%'
     and ( (FechaVuelo >= @fechaInicio) and (FechaVuelo <= @fechaInicio))
