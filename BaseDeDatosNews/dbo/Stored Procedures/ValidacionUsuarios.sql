
CREATE PROCEDURE ValidacionUsuarios
	@nombreUsuario varchar(50), @contrasena varchar(400)
AS BEGIN
	SET @contrasena = CONVERT(
		VARCHAR(max), 
		HASHBYTES('SHA2_512', @contrasena),2) 

	 SELECT * FROM USUARIOS 
	 WHERE NombreUsuario = @nombreUsuario
	 AND Contrasena = @contrasena

END