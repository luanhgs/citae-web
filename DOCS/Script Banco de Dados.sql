CREATE TABLE Usuario (
	idUsuario INT IDENTITY,
	nome VARCHAR(45) NOT NULL,
	email VARCHAR(40) NOT NULL,
	senha VARCHAR(20) NOT NULL,
	imgPergil IMAGE
)

CREATE TABLE Administrador (
	idAdm INT IDENTITY,
	nome VARCHAR(45) NOT NULL,
	email VARCHAR(40) NOT NULL,
	senha VARCHAR(20) NOT NULL,
	imgPergil IMAGE,
	CPF VARCHAR(13) NOT NULL
)

--para testes
INSERT INTO Usuario (nome, email, senha) VALUES('Luan', 'luan@email.com', 'senha')
