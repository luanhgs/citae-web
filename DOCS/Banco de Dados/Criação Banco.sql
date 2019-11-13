--------------TABELAS--------------


CREATE TABLE Usuario (
	idUsuario INT IDENTITY,
	nome VARCHAR(45) NOT NULL,
	email VARCHAR(40) NOT NULL,
	senha VARCHAR(20) NOT NULL,
	imgPerfil IMAGE
)
GO

CREATE TABLE Administrador (
	idAdm INT IDENTITY,
	nome VARCHAR(45) NOT NULL,
	email VARCHAR(40) NOT NULL,
	senha VARCHAR(20) NOT NULL,
	imgPerfil IMAGE,
	CPF VARCHAR(13) NOT NULL
)
GO
--------------PROCEDIMENTOS--------------

--Cadastro
CREATE PROCEDURE sp_signin_usuario
	@nome VARCHAR(45),
	@email VARCHAR(40),
	@senha VARCHAR(20)
AS BEGIN
	--Campo nome vazio
	IF(dbo.isNull(@nome) LIKE 1) BEGIN
		RAISERROR ('Informe o seu nome', 16, 1)
		RETURN
	END
	
	--E-mail já cadastrado
	if(dbo.emailExists(@email) LIKE 1) BEGIN
		RAISERROR ('E-mail já cadastrado', 16, 1)
		RETURN
	END

	--Senha já cadastrada
	if(dbo.senhaExists(@senha) LIKE 1) BEGIN
		RAISERROR ('Senha já cadastrada', 16, 1)
		RETURN
	END

	--Tudo certo para o cadastro
	INSERT INTO Usuario(nome, email, senha) VALUES (@nome, @email, @senha)
END
GO

--Login
CREATE PROCEDURE sp_login_usuario
	@email VARCHAR(40),
	@senha VARCHAR(20)
AS BEGIN
	DECLARE @senhaUser VARCHAR(20)
	SELECT @senhaUser = senha FROM Usuario WHERE email = @email

	IF(@senhaUser IS NULL) BEGIN
		RAISERROR ('Usuário não cadastrado !', 16, 1)
		RETURN
	END

	IF(@senhaUser NOT LIKE @senha) BEGIN
		RAISERROR ('A senha informada está incorreta !', 16, 1)
		RETURN
	END
END
GO

--------------FUNÇÃO--------------

--verificar se o valor  nulo
CREATE FUNCTION isNull(@valor varchar(100))
	RETURNS BIT
AS BEGIN
	IF(@valor is null or LTRIM(@valor) like '') BEGIN
		RETURN 1
	END
	RETURN 0
END
GO

--verificar se o e-mail do cadastro já existe
CREATE FUNCTION emailExists(@email varchar(40))
	RETURNS BIT
AS BEGIN
	IF EXISTS (SELECT 1 FROM Usuario WHERE email = @email) BEGIN
		RETURN 1
	END
	RETURN 0
END
GO

--verificar se a senha do cadastro já existe
CREATE FUNCTION senhaExists(@senha varchar(20))
	RETURNS BIT
AS BEGIN
	IF EXISTS (SELECT 1 FROM Usuario WHERE senha = @senha) BEGIN
		RETURN 1
	END
	RETURN 0
END
GO


