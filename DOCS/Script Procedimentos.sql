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
	IF(dbo.userLogin(@email, @senha) LIKE 0) BEGIN
		RAISERROR ('Algo de errado, verifique os campos !', 16, 1)
		RETURN
	END
END
GO