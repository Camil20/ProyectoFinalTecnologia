CREATE TABLE [dbo].[ARTICULOS] (
    [ArticuloId]       INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]           VARCHAR (MAX) NULL,
    [Descripcion]      VARCHAR (MAX) NULL,
    [Url]              VARCHAR (MAX) NULL,
    [UrlToImage]       VARCHAR (MAX) NULL,
    [FechaPublicacion] DATETIME      NULL,
    [Contenido]        VARCHAR (MAX) NULL,
    [AutorId]          INT           NULL,
    [CategoriaId]      INT           NULL,
    [PaisId]           INT           NULL,
    [FuenteId]         INT           NULL,
    CONSTRAINT [pk_ArticuloId] PRIMARY KEY CLUSTERED ([ArticuloId] ASC),
    CONSTRAINT [fk_IdAutorr] FOREIGN KEY ([AutorId]) REFERENCES [dbo].[AUTORES] ([AutorId]),
    CONSTRAINT [fk_IdCategoria] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[CATEGORIAS] ([CategoriaId]),
    CONSTRAINT [fk_IdFuente] FOREIGN KEY ([FuenteId]) REFERENCES [dbo].[FUENTES] ([FuenteId]),
    CONSTRAINT [fk_IdPais] FOREIGN KEY ([PaisId]) REFERENCES [dbo].[PAISES] ([PaisId])
);

