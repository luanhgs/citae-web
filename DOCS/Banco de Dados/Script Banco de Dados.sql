CREATE TABLE Usuario (
	idUsuario INT IDENTITY,
	nome VARCHAR(45) NOT NULL,
	email VARCHAR(40) NOT NULL,
	senha VARCHAR(20) NOT NULL,
	imgPerfil IMAGE,
	PRIMARY KEY(idUsuario)
)
GO

CREATE TABLE Administrador (
	idAdm INT IDENTITY,
	nome VARCHAR(45) NOT NULL,
	email VARCHAR(40) NOT NULL,
	senha VARCHAR(20) NOT NULL,
	imgPerfil IMAGE,
	CPF VARCHAR(13) NOT NULL,
	PRIMARY KEY(idAdm)
)
GO

CREATE TABLE Ocupacao(
	idOcupacao INT IDENTITY,
	nome VARCHAR(20),
	PRIMARY KEY(idOcupacao)
)
GO

CREATE TABLE Autor(
	idAutor INT IDENTITY,
	nome VARCHAR(30) NOT NULL,
	img IMAGE NOT NULL,
	ocupacao_id INT NOT NULL,
	FOREIGN KEY(ocupacao_id) REFERENCES Ocupacao(idOcupacao),
	PRIMARY KEY(idAutor)
)
GO

CREATE TABLE Categoria(
	idCategoria INT IDENTITY,
	nome VARCHAR(45) NOT NULL,
	img BINARY(100) NOT NULL,
	PRIMARY KEY(idCategoria)
)
GO

CREATE TABLE Citacao(
	idCitacao INT IDENTITY,
	texto VARCHAR(1000) NOT NULL,
	categoria_id INT NOT NULL,
	autor_id INT NOT NULL,
	FOREIGN KEY (categoria_id) REFERENCES Categoria(idCategoria),
	FOREIGN KEY (autor_id) REFERENCES Autor(idAutor),
	PRIMARY KEY(idCitacao)
)
GO

CREATE TABLE ExemploCitacao(
	idExemploCitacao INT IDENTITY,
	texto VARCHAR(1000) NOT NULL,
	citacao_id INT NOT NULL,
	FOREIGN KEY (citacao_id) REFERENCES Citacao(idCitacao),
	PRIMARY KEY(idExemploCitacao)
)
GO

