CREATE PROCEDURE PROJETO.createGroup
	@nome VARCHAR(250), @cadeira INT, @aluno VARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @code VARCHAR(15), @id INT;
	BEGIN TRANSACTION
		SELECT @code = PROJETO.getUniqueCode('G');

		INSERT INTO PROJETO.Criador VALUES(@code);

		INSERT INTO PROJETO.Grupo(nome, cadeira, codigo_criador) VALUES(@nome, @cadeira, @code);
		
		SELECT @id = SCOPE_IDENTITY();

		INSERT INTO PROJETO.GrupoAluno VALUES(@id, @aluno);
	COMMIT

	SELECT @id AS id, @code AS code
END

CREATE PROCEDURE PROJETO.createCadeira
	@nome VARCHAR(250), @link VARCHAR(250), @ano INT, @semestre INT, @nota_final FLOAT, @aluno VARCHAR(250), @instituicao INT
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @code VARCHAR(15), @id INT;
	BEGIN TRANSACTION
		SELECT @code = PROJETO.getUniqueCode('C');

		INSERT INTO PROJETO.Criador VALUES(@code);

		INSERT INTO PROJETO.Cadeira(nome, link, ano, semestre, nota_final, aluno, codigo_criador, instituicao, disabled) VALUES(@nome, @link, @ano, @semestre, @nota_final, @aluno, @code, @instituicao, 0);

		SELECT @id = SCOPE_IDENTITY();
	COMMIT

	SELECT @id AS id, @code AS code
END

CREATE PROCEDURE PROJETO.createPagina
	@titulo VARCHAR(250), @aluno VARCHAR(250), @cadeira INT
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @code VARCHAR(15), @id INT;
	BEGIN TRANSACTION
		SELECT @code = PROJETO.getUniqueCode('P');

		INSERT INTO PROJETO.Criador VALUES(@code);

		INSERT INTO PROJETO.Pagina(titulo,aluno,cadeira,codigo_criador) VALUES(@titulo, @aluno, @cadeira, @code);

		SELECT @id = SCOPE_IDENTITY();
	COMMIT

	SELECT @id AS id, @code AS code
END

CREATE PROCEDURE PROJETO.createPaginaGrupo
	@titulo VARCHAR(250), @aluno VARCHAR(250), @cadeira INT, @grupo INT
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @code VARCHAR(15), @id INT;
	BEGIN TRANSACTION
		SELECT @code = PROJETO.getUniqueCode('P');

		INSERT INTO PROJETO.Criador VALUES(@code);

		INSERT INTO PROJETO.Pagina(titulo,aluno,cadeira,codigo_criador,grupo) VALUES(@titulo, @aluno, @cadeira, @code, @grupo);

		SELECT @id = SCOPE_IDENTITY();
	COMMIT

	SELECT @id AS id, @code AS code
END

CREATE PROCEDURE PROJETO.deletePagina
	@pagId INT
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRANSACTION
		DECLARE @code VARCHAR(20);
		SELECT @code = codigo_criador FROM PROJETO.Pagina WHERE id = @pagId;

		IF EXISTS (SELECT * FROM PROJETO.PaginaGrupo WHERE pagina = @pagId)
			BEGIN
				DELETE FROM PROJETO.PaginaGrupo WHERE pagina = @pagId;
			END

		DELETE FROM PROJETO.Ficheiro WHERE codigo_criador = @code;
		DELETE FROM PROJETO.Pagina WHERE id = @pagId;
		DELETE FROM PROJETO.Criador WHERE codigo = @code;
	COMMIT

END

CREATE PROCEDURE PROJETO.deletePagina
	@pagId INT
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRANSACTION
		DECLARE @code VARCHAR(20);
		SELECT @code = codigo_criador FROM PROJETO.Pagina WHERE id = @pagId;

		IF EXISTS (SELECT * FROM PROJETO.PaginaGrupo WHERE pagina = @pagId)
			BEGIN
				DELETE FROM PROJETO.PaginaGrupo WHERE pagina = @pagId;
			END

		DELETE FROM PROJETO.Ficheiro WHERE codigo_criador = @code;
		DELETE FROM PROJETO.Pagina WHERE id = @pagId;
		DELETE FROM PROJETO.Criador WHERE codigo = @code;
	COMMIT

END

CREATE PROCEDURE PROJETO.deleteInstituicao
	@id INT
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRANSACTION

		IF EXISTS (SELECT * FROM PROJETO.Cadeira WHERE instituicao = @id)
			BEGIN
				UPDATE PROJETO.Instituicao SET disabled = 1 WHERE id = @id;
				UPDATE PROJETO.Cadeira SET disabled = 1 WHERE instituicao = @id;
			END
		ELSE
			BEGIN			
				DELETE FROM PROJETO.Instituicao WHERE id = @id;
			END

	COMMIT

END

CREATE PROCEDURE PROJETO.deleteTipoTarefa
	@id INT
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRANSACTION

		IF EXISTS (SELECT * FROM PROJETO.Tarefa WHERE tipoTarefa = @id)
			BEGIN
				UPDATE PROJETO.TipoTarefa SET disabled = 1 WHERE id = @id;
			END
		ELSE
			BEGIN			
				DELETE FROM PROJETO.TipoTarefa WHERE id = @id;
			END

	COMMIT

END

CREATE PROCEDURE PROJETO.deleteTarefa
	@id INT
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRANSACTION

		IF EXISTS (SELECT * FROM PROJETO.TarefaGrupo WHERE tarefa = @id)
			BEGIN
				DELETE FROM PROJETO.TarefaGrupo WHERE tarefa = @id;
			END
				
		DELETE FROM PROJETO.Tarefa WHERE id = @id;

	COMMIT

END

CREATE PROCEDURE PROJETO.deleteCadeira
	@id INT
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRANSACTION
		DECLARE @code VARCHAR(20);
		SELECT @code = codigo_criador FROM PROJETO.Cadeira WHERE id = @id;

		IF EXISTS (SELECT * FROM PROJETO.Grupo WHERE cadeira = @id)
			BEGIN
				UPDATE PROJETO.Cadeira SET disabled = 1 WHERE id = @id;
			END
		ELSE
			BEGIN
				IF EXISTS (SELECT * FROM PROJETO.ProfessorCadeira WHERE cadeira = @id)
					BEGIN
						DELETE FROM PROJETO.ProfessorCadeira WHERE cadeira = @id;
					END

				IF EXISTS (SELECT * FROM PROJETO.Tarefa WHERE cadeira = @id)
					BEGIN
						DELETE FROM PROJETO.Tarefa WHERE cadeira = @id;
					END

				DELETE FROM PROJETO.Ficheiro WHERE codigo_criador = @code;
				DELETE FROM PROJETO.Cadeira WHERE id = @id;
				DELETE FROM PROJETO.Criador WHERE codigo = @code;
				
			END

		COMMIT

END

CREATE PROCEDURE PROJETO.deleteGrupo	
	@id INT
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRANSACTION
		DECLARE @code VARCHAR(20);
		SELECT @code = codigo_criador FROM PROJETO.Grupo WHERE id = @id;
		
		DELETE FROM PROJETO.PaginaGrupo WHERE grupo = @id;
		DELETE FROM PROJETO.TarefaGrupo WHERE grupo = @id;
		DELETE FROM PROJETO.GrupoAluno WHERE grupo = @id;
		DELETE FROM PROJETO.GrupoProfessor WHERE grupo = @id;
		DELETE FROM PROJETO.Ficheiro WHERE codigo_criador = @code;
		DELETE FROM PROJETO.Criador WHERE codigo = @code;
		DELETE FROM PROJETO.Grupo WHERE id = @id;

	COMMIT

END

CREATE PROCEDURE PROJETO.deleteProfessor	
	@email VARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRANSACTION

		IF EXISTS (SELECT * FROM PROJETO.GrupoProfessor WHERE professor = @email)
			BEGIN
				UPDATE PROJETO.Professor SET disabled = 1 WHERE email = @email;
			END
		ELSE IF EXISTS (SELECT * FROM PROJETO.ProfessorCadeira WHERE professor = @email)
			BEGIN
				UPDATE PROJETO.Professor SET disabled = 1 WHERE email = @email;
			END
		ELSE
			BEGIN
				DELETE FROM PROJETO.Professor WHERE email = @email;
			END

	COMMIT

END

-- SP de Login
CREATE PROCEDURE PROJETO.login
		@email VARCHAR(250), @password VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT * FROM PROJETO.Aluno WHERE email = @email AND password = @password AND disabled = 0)
        SELECT 1
    ELSE
        SELECT 0
END