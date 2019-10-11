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

--login do usuario
CREATE FUNCTION userLogin(@email VARCHAR(40), @senha VARCHAR(20)) 
	RETURNS BIT
AS BEGIN
	DECLARE @senhaUser VARCHAR(20)
	SELECT @senhaUser = senha FROM Usuario WHERE email = @email

	IF(@senhaUser LIKE @senha) BEGIN
		RETURN 1
	END

	RETURN 0
END
GO