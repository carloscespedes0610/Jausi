USE Jausi
Go

IF OBJECT_ID('procAddCampoTablaPersona') IS NOT NULL
BEGIN 
    DROP PROC procAddCampoTablaPersona
END 
GO


create proc procAddCampoTablaPersona @campoNew nvarchar(Max)
as
begin
	
	declare @activado int
	
	-- verificamos que la tabla tempResultado exista debe tener los id
	IF (OBJECT_ID('Jausi.dbo.tempResultado')IS NOT NULL) begin
	
		IF (OBJECT_ID('Jausi.dbo.tempResAux')IS NOT NULL) 
		begin DROP TABLE Jausi.dbo.tempResAux end
		
		-- guardamos en un tabla auxiliar la tabla tempResultado			
		select * into Jausi.dbo.tempResAux from Jausi.dbo.tempResultado
		
		IF (OBJECT_ID('Jausi.dbo.temp2')IS NOT NULL) 
		begin DROP TABLE Jausi.dbo.temp2 end
		
		---- *** esta parte es la que cambia segun la tabla de la BD ****-----------
		if(@campoNew = 'PersonaNombre')
		begin
			-- cambiamos el nombre de la PK para que no exista 2 campos con el mismo nombre
			select p.PersonaId as temp2Id,p.PersonaNombre into Jausi.dbo.temp2
			from Persona p
			
			set @activado = 1;
		end
		
		if(@campoNew = 'PersonaSexo')
		begin
			select p.PersonaId as temp2Id,p.PersonaSexo into Jausi.dbo.temp2
			from Persona p
			
			set @activado = 1;
		end 
		if(@campoNew = 'PersonaEstadoCivil')
		begin
			select p.PersonaId as temp2Id,p.PersonaEstadoCivil into Jausi.dbo.temp2
			from Persona p;
			set @activado = 1;
		end
		if(@campoNew = 'PersonaFechaNacimiento')
		begin
			select p.PersonaId as temp2Id,p.PersonaFechaNacimiento into Jausi.dbo.temp2 from Persona p;
			set @activado = 1;
		end
		if(@campoNew = 'PersonaTelefono')
		begin
			select p.PersonaId as temp2Id,p.PersonaTelefono into Jausi.dbo.temp2 from Persona p;
			set @activado = 1;
		end
		
		-- preguntamos si entro en alguna opcion
		if(@activado>0)
		begin
			IF (OBJECT_ID('Jausi.dbo.tempResultado')IS NOT NULL) 
			begin DROP TABLE Jausi.dbo.tempResultado end
			
			select * into Jausi.dbo.tempResultado
			from Jausi.dbo.tempResAux tra inner join Jausi.dbo.temp2 t2
				on tra.PersonaId = t2.temp2Id
			
			--borramos el campo temp2Id	de la tabla tempResultado
			ALTER TABLE Jausi.dbo.tempResultado
			DROP COLUMN temp2Id
			
			-- borramos la tablas auxiliares
			DROP TABLE Jausi.dbo.temp2
			DROP TABLE Jausi.dbo.tempResAux
		end
		else
		begin
			RAISERROR('Error campo no definido en la tabla Persona; procAddCampoTablaPersona', 16, 1)
			RETURN
		end
		
		--select * from Jausi.dbo.tempResultado
	end
	else
	begin
		RAISERROR('Error tabla tempResultado esta vacia; procAddCampoTablaPersona', 16, 1)
		RETURN
	end
end
go


IF (OBJECT_ID('Jausi.dbo.tempResultado')IS NOT NULL) 
begin DROP TABLE Jausi.dbo.tempResultado end
Go
	
SELECT PersonaId INTO Jausi.dbo.tempResultado FROM Jausi.dbo.Persona
Go

exec procAddCampoTablaPersona 'PersonaSexo'
Go