CREATE TABLE [dbo].[USUARIOS] (
    [UsuarioId]      INT           IDENTITY (1, 1) NOT NULL,
    [NombreCompleto] VARCHAR (250) NULL,
    [NombreUsuario]  VARCHAR (50)  NULL,
    [Contrasena]     VARCHAR (400) NULL,
    CONSTRAINT [pk_UsuarioId] PRIMARY KEY CLUSTERED ([UsuarioId] ASC)
);

