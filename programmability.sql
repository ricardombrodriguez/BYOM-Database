-- FUNÇÕES, TRIGGERS E STORED PROCEDURES

-- Esta função cria um código único através da concatenação de uma letra com o timestamp.
-- O código gerado é utilizado para inserir na tabela Criador
CREATE FUNCTION PROJETO.getUniqueCode (@char VARCHAR(2))
RETURNS VARCHAR(15)
AS
BEGIN
    DECLARE @time VARCHAR(15), @code VARCHAR(15)
    SELECT @time = CAST(DATEDIFF_BIG(MILLISECOND, '1970-01-01', GETDATE()) AS VARCHAR(15));
    SET @code = CONCAT(@char, @time)
    RETURN @code
END

-- Antes de inserirmos uma entidade capaz de criar um ficheiro, temos de lhe associar uma entidade criador
-- Este trigger utiliza a função getUniqueCode para criar um Criador e só depois insere os valores na tabela Grupo
--CREATE TRIGGER createCriadorGrupo
--ON PROJETO.Grupo
--INSTEAD OF INSERT
--AS
--BEGIN
--    DECLARE @code VARCHAR(15);
--    DECLARE @nome VARCHAR(250), @cadeira INT;
    
--	BEGIN TRANSACTION
--		SELECT @code = PROJETO.getUniqueCode('G');

--		INSERT INTO PROJETO.Criador VALUES(@code);

--		SELECT @nome = nome, @cadeira = cadeira FROM INSERTED;

--		INSERT INTO PROJETO.Grupo(nome, cadeira, codigo_criador) VALUES(@nome, @cadeira, @code);
--	COMMIT

--END

CREATE PROCEDURE PROJETO.createGroup
	@nome VARCHAR(250), @cadeira INT, @aluno VARCHAR(250)
AS
BEGIN
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

-- Antes de inserirmos uma entidade capaz de criar um ficheiro, temos de lhe associar uma entidade criador
-- Este trigger utiliza a função getUniqueCode para criar um Criador e só depois insere os valores na tabela Cadeira
--CREATE TRIGGER createCriadorCadeira
--ON PROJETO.Cadeira
--INSTEAD OF INSERT
--AS
--BEGIN
--    DECLARE @code VARCHAR(15);
--    DECLARE @nome VARCHAR(250), @link VARCHAR(250), @ano INT,
--		@semestre INT, @nota_final FLOAT, @aluno VARCHAR(250), @instituicao INT;
	
--	BEGIN TRANSACTION
--		SELECT @code = PROJETO.getUniqueCode('C');

--		INSERT INTO PROJETO.Criador VALUES(@code);

--		SELECT @nome = nome, @link = link, @ano = ano, @semestre = semestre,
--			@nota_final = nota_final, @aluno = aluno, @instituicao = instituicao
--		FROM INSERTED;

--		INSERT INTO PROJETO.Cadeira(nome, link, ano, semestre, nota_final, aluno, codigo_criador, instituicao, disabled) VALUES(@nome, @link, @ano, @semestre, @nota_final, @aluno, @code, @instituicao, 0);
--	COMMIT

--END

CREATE PROCEDURE PROJETO.createCadeira
	@nome VARCHAR(250), @link VARCHAR(250), @ano INT, @semestre INT, @nota_final FLOAT, @aluno VARCHAR(250), @instituicao INT
AS
BEGIN
	DECLARE @code VARCHAR(15), @id INT;
	BEGIN TRANSACTION
		SELECT @code = PROJETO.getUniqueCode('C');

		INSERT INTO PROJETO.Criador VALUES(@code);

		INSERT INTO PROJETO.Cadeira(nome, link, ano, semestre, nota_final, aluno, codigo_criador, instituicao, disabled) VALUES(@nome, @link, @ano, @semestre, @nota_final, @aluno, @code, @instituicao, 0);

		SELECT @id = SCOPE_IDENTITY();
	COMMIT

	SELECT @id AS id, @code AS code
END

-- Antes de inserirmos uma entidade capaz de criar um ficheiro, temos de lhe associar uma entidade criador
-- Este trigger utiliza a função getUniqueCode para criar um Criador e só depois insere os valores na tabela Tarefa
CREATE TRIGGER createCriadorTarefa
ON PROJETO.Tarefa
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @code VARCHAR(15);
    DECLARE @titulo VARCHAR(250), @descricao VARCHAR(250), @completada_ts DATETIME,
		@data_inicio DATE, @date_final DATE, @tipoTarefa INT, @aluno VARCHAR(250), @cadeira INT;
	
	BEGIN TRANSACTION
		SELECT @code = PROJETO.getUniqueCode('T');

		INSERT INTO PROJETO.Criador VALUES(@code);

		SELECT @titulo = titulo, @descricao = descricao, @completada_ts = completada_ts, @data_inicio = data_inicio,
			@date_final = date_final, @aluno = aluno, @tipoTarefa = tipoTarefa, @cadeira = cadeira
		FROM INSERTED;

		INSERT INTO PROJETO.Tarefa VALUES(@titulo, @descricao, @completada_ts, @data_inicio,
			@date_final, @tipoTarefa, @aluno, @cadeira, @code);
	COMMIT

END

-- Antes de inserirmos uma entidade capaz de criar um ficheiro, temos de lhe associar uma entidade criador
-- Este trigger utiliza a função getUniqueCode para criar um Criador e só depois insere os valores na tabela Pagina

DROP TRIGGER PROJETO.createCriadorPagina

--CREATE TRIGGER createCriadorPagina
--ON PROJETO.Pagina
--INSTEAD OF INSERT
--AS
--BEGIN
--    DECLARE @code VARCHAR(15);
--    DECLARE @titulo VARCHAR(250), @aluno VARCHAR(250), @cadeira INT;

--	BEGIN TRANSACTION
--		SELECT @code = PROJETO.getUniqueCode('P');

--		INSERT INTO PROJETO.Criador VALUES(@code);

--		SELECT @titulo = titulo, @aluno = aluno, @cadeira = cadeira
--		FROM INSERTED;

--		INSERT INTO PROJETO.Pagina VALUES(@titulo, @texto, @aluno, @cadeira, @code);
--	COMMIT

--END

CREATE PROCEDURE PROJETO.createPagina
	@titulo VARCHAR(250), @aluno VARCHAR(250), @cadeira INT
AS
BEGIN
	DECLARE @code VARCHAR(15), @id INT;
	BEGIN TRANSACTION
		SELECT @code = PROJETO.getUniqueCode('P');

		INSERT INTO PROJETO.Criador VALUES(@code);

		INSERT INTO PROJETO.Pagina VALUES(@titulo, @aluno, @cadeira, @code, '');

		SELECT @id = SCOPE_IDENTITY();
	COMMIT

	SELECT @id AS id, @code AS code
END

select * from PROJETO.Pagina

-- SP's de DELETE
CREATE TRIGGER deleteAluno
ON PROJETO.Aluno
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @email VARCHAR(250);

	BEGIN TRANSACTION
		SELECT @email = email FROM DELETED;

		UPDATE PROJETO.Aluno SET disabled = 1 WHERE email = @email;
	COMMIT

END

CREATE PROCEDURE PROJETO.deletePagina
	@pagId INT
AS
BEGIN

	BEGIN TRANSACTION
		DECLARE @code VARCHAR(20);
		SELECT @code = codigo_criador FROM PROJETO.Pagina WHERE id = @pagId;

		IF EXISTS (SELECT * FROM PROJETO.PaginaGrupo WHERE pagina = @pagId)
			BEGIN
				DELETE FROM PROJETO.PaginaGrupo WHERE pagina = @pagId;
			END

		DELETE FROM PROJETO.Ficheiro WHERE codigo_criador = @code;
		DELETE FROM PROJETO.Criador WHERE codigo = @code;
		DELETE FROM PROJETO.Pagina WHERE id = @pagId;
	COMMIT

END

CREATE PROCEDURE PROJETO.deleteInstituicao
	@id INT
AS
BEGIN

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
				DELETE FROM PROJETO.Criador WHERE codigo = @code;
				DELETE FROM PROJETO.Cadeira WHERE id = @id;
			END

		COMMIT

END

CREATE PROCEDURE PROJETO.deleteGrupo	
	@id INT
AS
BEGIN

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
		IF EXISTS (SELECT * FROM PROJETO.Aluno WHERE email = @email AND password = @password AND disabled = 0)
			SELECT 1
		ELSE
			SELECT 0

	END;
GO

CREATE FUNCTION PROJETO.tarefasSemanais ()
RETURNS @t TABLE (
	id INT,
	titulo VARCHAR(250),
	data_tarefa DATE
)
AS
BEGIN 
	DECLARE @addDays INT, @sutractDays INT, @weekday VARCHAR(10), @initDate DATE, @finDate DATE;
	SELECT @weekday = DATENAME(WEEKDAY, GETDATE());

	IF @weekday = 'Monday'
		BEGIN
			SET @sutractDays = 0;
			SET @addDays = 6;
		END
	ELSE IF @weekday = 'Tuesday'
		BEGIN
			SET @sutractDays = -1;
			SET @addDays = 5;
		END
	ELSE IF @weekday = 'Wednesday'
		BEGIN
			SET @sutractDays = -2;
			SET @addDays = 4;
		END
	ELSE IF @weekday = 'Thursday'
		BEGIN
			SET @sutractDays = -3;
			SET @addDays = 3;
		END
	ELSE IF @weekday = 'Friday'
		BEGIN
			SET @sutractDays = -4;
			SET @addDays = 2;
		END
	ELSE IF @weekday = 'Saturday'
		BEGIN
			SET @sutractDays = -5;
			SET @addDays = 1;
		END
	ELSE IF @weekday = 'Sunday'
		BEGIN
			SET @sutractDays = -6;
			SET @addDays = 0
		END

	SELECT @initDate = CAST(DATEADD(DAY, @sutractDays, CAST(GETDATE() AS DATE)) AS DATE);
	SELECT @finDate = CAST(DATEADD(DAY, @addDays, CAST(GETDATE() AS DATE)) AS DATE);

	INSERT INTO @t
	--	SELECT id, CONCAT(titulo, ' ', '[INÍCIO]') as titulo, data_inicio as data_tarefa FROM PROJETO.Tarefa WHERE data_inicio = @initDate
	--	UNION
	--	SELECT id, CONCAT(titulo, ' ', '[FINAL]'), date_final as data_tarefa FROM PROJETO.Tarefa WHERE date_final = @finDate
	--	UNION
		SELECT id, titulo, data_inicio as data_tarefa FROM PROJETO.Tarefa WHERE data_inicio >= @initDate AND data_inicio <= @finDate
		UNION
		SELECT id, titulo, date_final as data_tarefa FROM PROJETO.Tarefa WHERE date_final >= @initDate AND date_final <= @finDate;

	RETURN
END

CREATE FUNCTION PROJETO.getTarefasSemanaByDia (@dia VARCHAR(10))
RETURNs @table TABLE (
	id INT,
	titulo VARCHAR(250),
	descricao VARCHAR(250),
	completada_ts DATETIME,
	data_inicio DATE,
	date_final DATE,
	tipoTarefa INT,
	aluno VARCHAR(250),
	cadeira INT,
	codigo_criador VARCHAR(20)
)
AS
BEGIN
	DECLARE @t TABLE (id INT, titulo VARCHAR(250), data DATE)
	INSERT INTO @t SELECT * FROM PROJETO.tarefasSemanais() as tarefas

	DECLARE tarefas_cursor CURSOR FOR
		SELECT * FROM @t

	DECLARE @id INT, @titulo VARCHAR(250), @data DATE -- para o cursor
	DECLARE @descricao VARCHAR(250), @completada_ts DATETIME, @data_inicio DATE, @date_final DATE, @tipoTarefa INT, @aluno VARCHAR(250), @cadeira INT, @codigo_criador VARCHAR(20)

	OPEN tarefas_cursor
	FETCH NEXT FROM tarefas_cursor INTO @id, @titulo, @data

	WHILE @@FETCH_STATUS = 0  
	BEGIN  
		DECLARE @weekday VARCHAR(10);
		SELECT @weekday = DATENAME(WEEKDAY, @data);
		IF @weekday = @dia
		BEGIN			
			SELECT @descricao = descricao, @completada_ts = completada_ts, @data_inicio = data_inicio, @date_final = date_final, @tipoTarefa = tipoTarefa, @aluno = aluno, @cadeira = cadeira, @codigo_criador = codigo_criador
			FROM PROJETO.Tarefa
			WHERE id = @id

			INSERT INTO @table VALUES(@id, @titulo, @descricao, @completada_ts, @data_inicio, @date_final, @tipoTarefa, @aluno, @cadeira, @codigo_criador)
		END
			   
		FETCH NEXT FROM tarefas_cursor INTO @id, @titulo, @data
	END
	
	RETURN
END

SELECT * FROM PROJETO.Tarefa where titulo Like '% C%'
SELECT * FROM PROJETO.Cadeira

SELECT * FROM PROJETO.tarefasSemanais() as tarefas

SELECT * FROM PROJETO.getTarefasSemanaByDia('Tuesday') WHERE completada_ts IS NULL ORDER BY data_inicio DESC
