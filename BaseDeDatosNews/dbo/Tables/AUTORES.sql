CREATE TABLE [dbo].[AUTORES] (
    [AutorId]     INT           IDENTITY (1, 1) NOT NULL,
    [NombreAutor] VARCHAR (100) NULL,
    [UsuarioId]   INT           NULL,
    CONSTRAINT [pk_IdAutor] PRIMARY KEY CLUSTERED ([AutorId] ASC),
    CONSTRAINT [fk_IdUsuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[USUARIOS] ([UsuarioId])
);

