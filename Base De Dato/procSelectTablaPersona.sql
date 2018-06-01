USE Jausi
Go

IF OBJECT_ID('procSelectTablaPersona') IS NOT NULL
BEGIN 
    DROP PROC procSelectTablaPersona
END 
GO

/*
	ejemplos de parametros:
		campos = "PersonaNombre,PersonaSexo,"
		*NOTA: el campo PersonaId viene por defecto 
			   no se debe estar mencionado en el parametro campos
			   y toda la cadena debe terminar con una coma
*/

create proc procSelectTablaPersona @campos nvarchar(Max),
								   @filtrosWhere nvarchar(MAX)
as
begin 

	declare @campoNew nvarchar(MAX)
	declare @pos int
	declare @aux_pos int 
	
	IF (OBJECT_ID('Jausi.dbo.tempResultado')IS NOT NULL) 
	begin DROP TABLE Jausi.dbo.tempResultado end
	
	SELECT PersonaId INTO Jausi.dbo.tempResultado FROM Jausi.dbo.Persona
	
	---************* Procesamiento del SELECT ************-------------
	
	set @pos = (select CHARINDEX(',',@campos));
	
	while(@pos>0)
	begin
		set @campoNew = (Select SUBSTRING(@campos,0,@pos));
		
		exec procAddCampoTablaPersona @campoNew
		
		set @aux_pos = @pos + 1;  -- para que salte la coma
		set @campos = SUBSTRING(@campos,@aux_pos,Len(@campos));
		set @pos = (select CHARINDEX(',',@campos));
	end
	
	select * from Jausi.dbo.tempResultado
	
	/*
	-- preguntamos si queda un campo si añadir
	if(LEN(@campos)>0)
	begin
		set @campoNew = (Select SUBSTRING(@campos,0,Len(@campos)+1));
		exec procAddCampoTabla @campoNew
		
	end
*/

end
Go

exec procSelectTablaPersona 
	'PersonaNombre,PersonaSexo,PersonaFechaNacimiento,PersonaEstadoCivil,PersonaTelefono,',''
	--'PersonaNombre,PersonaTelefono',''
go

