CREATE PROCEDURE InsercionUsuarios
	@nombreCompleto varchar(250),
	@nombreUsuario varchar(50),
	@contrasena varchar(400)
AS BEGIN
	SET @contrasena = CONVERT(
	VARCHAR(max), 
	HASHBYTES('SHA2_512', @contrasena),2) 

	INSERT Usuarios (NombreCompleto, NombreUsuario, Contrasena)
	VALUES (@nombreCompleto, @nombreUsuario, @contrasena)

END