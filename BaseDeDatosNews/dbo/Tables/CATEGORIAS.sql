CREATE TABLE [dbo].[CATEGORIAS] (
    [CategoriaId]     INT           IDENTITY (1, 1) NOT NULL,
    [NombreCategoria] VARCHAR (100) NULL,
    CONSTRAINT [pk_CategoriaId] PRIMARY KEY CLUSTERED ([CategoriaId] ASC)
);

