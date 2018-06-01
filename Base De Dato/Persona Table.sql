/********************************************************************/
/*  TABLA			: Persona									*/
/*  AUTOR			: Carlos Cespedes									*/
/*  FECHA			: 30/05/2018									*/
/*  DESCRIPCION		:									            */
/********************************************************************/

Print 'Creating table dbo.Persona'
CREATE TABLE dbo.Persona
(
   PersonaId    int identity(1,1) NOT NULL,  --** Id. de la Persona

   PersonaNombre    varchar(150) NOT NULL,        --** Nombre de la persona
   PersonaSexo		varchar(30) NOT NULL,			  --** Sexo de la persona
   --EstadoId         int NOT NULL,               --** Estado(Activo/Inactivo)

   PersonaEstadoCivil    varchar(30) NOT NULL,    --** Estado Civil
   PersonaFechaNacimiento  datetime NOT NULL,     --** Fecha de ultima modificacion
   PersonaTelefono       varchar(15) NULL,        --** Nro. de Telefono

   CONSTRAINT PersonaPerPK                        -- solo deberia ser PersonaPK pero ya existe
   PRIMARY KEY NONCLUSTERED(PersonaID)
)

GO
