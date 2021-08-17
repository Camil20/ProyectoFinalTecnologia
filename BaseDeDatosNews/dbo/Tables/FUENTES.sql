CREATE TABLE [dbo].[FUENTES] (
    [FuenteId]     INT           IDENTITY (1, 1) NOT NULL,
    [NombreFuente] VARCHAR (100) NULL,
    CONSTRAINT [pk_FuenteId] PRIMARY KEY CLUSTERED ([FuenteId] ASC)
);

