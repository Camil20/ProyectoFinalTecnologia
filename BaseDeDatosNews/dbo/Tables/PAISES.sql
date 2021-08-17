CREATE TABLE [dbo].[PAISES] (
    [PaisId]     INT           IDENTITY (1, 1) NOT NULL,
    [NombrePais] VARCHAR (100) NULL,
    CONSTRAINT [pk_PaisId] PRIMARY KEY CLUSTERED ([PaisId] ASC)
);

