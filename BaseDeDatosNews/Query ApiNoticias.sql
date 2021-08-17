--CREACI�N DE BASE DE DATOS NOTICIAS 
CREATE DATABASE ApiNoticias
USE ApiNoticias


--CREACI�N DE TABLAS 
CREATE TABLE USUARIOS
(
	UsuarioId int identity constraint pk_UsuarioId PRIMARY KEY,
	NombreCompleto varchar (250),
	NombreUsuario varchar (50),
	Contrasena varchar (400)

);


CREATE TABLE AUTORES
(
	AutorId int identity constraint pk_IdAutor PRIMARY KEY,
	NombreAutor varchar (100),
	UsuarioId int constraint fk_IdUsuario FOREIGN KEY
	REFERENCES USUARIOS(UsuarioId),
	
);


CREATE TABLE CATEGORIAS
(
	CategoriaId int identity constraint pk_CategoriaId PRIMARY KEY,
	NombreCategoria varchar (100)
);


CREATE TABLE PAISES
(
	PaisId int identity constraint pk_PaisId PRIMARY KEY,
	NombrePais varchar (100)	
);


CREATE TABLE FUENTES
(
	FuenteId int identity constraint pk_FuenteId PRIMARY KEY,
	NombreFuente varchar (100)	
);


CREATE TABLE ARTICULOS
(
	ArticuloId int identity constraint pk_ArticuloId PRIMARY KEY,
	Titulo varchar (max),
	Descripcion varchar (max),
	Url varchar (max),
	UrlToImage varchar (max),
	FechaPublicacion datetime,
	Contenido varchar (max),
	AutorId int constraint fk_IdAutorr FOREIGN KEY
	REFERENCES AUTORES(AutorId),
	CategoriaId int constraint fk_IdCategoria FOREIGN KEY
	REFERENCES CATEGORIAS(CategoriaId),
	PaisId int constraint fk_IdPais FOREIGN KEY
	REFERENCES PAISES(PaisId),
	FuenteId int constraint fk_IdFuente FOREIGN KEY
	REFERENCES FUENTES(FuenteId)
);


--INSERCI�N DE INFORMACION EN LAS TABLAS
INSERT INTO CATEGORIAS VALUES('Negocios') 
INSERT INTO CATEGORIAS VALUES('Entretenimiento') 
INSERT INTO CATEGORIAS VALUES('General') 
INSERT INTO CATEGORIAS VALUES('Salud') 
INSERT INTO CATEGORIAS VALUES('Ciencia') 
INSERT INTO CATEGORIAS VALUES('Deportes') 
INSERT INTO CATEGORIAS VALUES('Tecnolog�a') 

INSERT INTO PAISES VALUES('Argentina') 
INSERT INTO PAISES VALUES('Australia') 
INSERT INTO PAISES VALUES('Austria') 
INSERT INTO PAISES VALUES('Belgium') 
INSERT INTO PAISES VALUES('Brazil') 
INSERT INTO PAISES VALUES('Bulgaria') 
INSERT INTO PAISES VALUES('Canada') 
INSERT INTO PAISES VALUES('China') 
INSERT INTO PAISES VALUES('Colombia') 
INSERT INTO PAISES VALUES('Cuba') 
INSERT INTO PAISES VALUES('Czech Republic') 
INSERT INTO PAISES VALUES('Egipto') 
INSERT INTO PAISES VALUES('Francia') 
INSERT INTO PAISES VALUES('Germania') 
INSERT INTO PAISES VALUES('Grecia') 
INSERT INTO PAISES VALUES('Hong Kong') 
INSERT INTO PAISES VALUES('Hungria') 
INSERT INTO PAISES VALUES('India') 
INSERT INTO PAISES VALUES('Indonesia') 
INSERT INTO PAISES VALUES('Irlandia') 
INSERT INTO PAISES VALUES('Israel') 
INSERT INTO PAISES VALUES('Italia') 
INSERT INTO PAISES VALUES('Japon') 
INSERT INTO PAISES VALUES('Letonia') 
INSERT INTO PAISES VALUES('Lituania') 
INSERT INTO PAISES VALUES('Malasia') 
INSERT INTO PAISES VALUES('Mexico') 
INSERT INTO PAISES VALUES('Marruecos') 
INSERT INTO PAISES VALUES('Pa�ses Bajos') 
INSERT INTO PAISES VALUES('Nueva Zelanda')
INSERT INTO PAISES VALUES('Nigeria')
INSERT INTO PAISES VALUES('Noruega') 
INSERT INTO PAISES VALUES('Filipinas') 
INSERT INTO PAISES VALUES('Poland') 
INSERT INTO PAISES VALUES('Portugal') 
INSERT INTO PAISES VALUES('Rumania') 
INSERT INTO PAISES VALUES('Federaci�n Rusa') 
INSERT INTO PAISES VALUES('Arabia Saudita') 
INSERT INTO PAISES VALUES('Serbia') 
INSERT INTO PAISES VALUES('Singapur') 
INSERT INTO PAISES VALUES('Eslovaquia') 
INSERT INTO PAISES VALUES('Eslovenia') 
INSERT INTO PAISES VALUES('Sud�frica') 
INSERT INTO PAISES VALUES('Corea') 
INSERT INTO PAISES VALUES('Suecia')
INSERT INTO PAISES VALUES('Suiza')
INSERT INTO PAISES VALUES('Taiwan') 
INSERT INTO PAISES VALUES('Tailandia') 
INSERT INTO PAISES VALUES('Turquia') 
INSERT INTO PAISES VALUES('Ucrania') 
INSERT INTO PAISES VALUES('Emiratos �rabes Unidos') 
INSERT INTO PAISES VALUES('Estado Unidos de America') 
INSERT INTO PAISES VALUES('Venezuela') 

INSERT INTO FUENTES VALUES('CNN') 
INSERT INTO FUENTES VALUES('Diario Libre') 
INSERT INTO FUENTES VALUES('Listin Diario') 

INSERT INTO AUTORES VALUES('Juan', 1)

INSERT INTO ARTICULOS VALUES('Derrumbe en Miami: la familia del cirujano Andr�s Galfrascoli public� una dolorosa despedida en sus redes - LA NACION', 'Seg�n contaron, Andr�s Galfrascoli, y su marido, Fabi�n N��ez, -identificados este fin de semana entre las v�ctimas del accidente en Estados Unidos- estaban buscando otro hijo',
'https://www.lanacion.com.ar/el-mundo/derrumbe-en-miami-la-familia-del-cirujano-andres-galfrascoli-publico-una-dolorsa-despedida-en-sus-nid12072021/',
'https://resizer.glanacion.com/resizer/shQxSYyAguu9JxTqNsXZ2UCHJdE=/768x0/filters:quality(80)/cloudfront-us-east-1.images.arcpublishing.com/lanacionar/NL6WE266WJGLTLGD2NKDD7ZZGU.jpg',
getdate(),'Mientras sigue la b�squeda incesante de las v�ctimas tras el en Surfside, Miami,\" class=\"com-link\" data-reactroot=\"\"&gt;derrumbe del edificioen Surfside, Miami, el equipo de rescatistas identific� a �',1,8,1,1)



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


InsercionUsuarios 'Administrador', 'admin', 'admin1'
InsercionUsuarios 'Admin1', 'admin1', 'admin1'

--select * from USUARIOS

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

--ValidacionUsuarios 'admin', 'admin1'