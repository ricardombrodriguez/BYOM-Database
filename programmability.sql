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
CREATE TRIGGER createCriadorGrupo
ON PROJETO.Grupo
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @code VARCHAR(15);
    DECLARE @nome VARCHAR(250), @cadeira INT;
    
	BEGIN TRANSACTION
		SELECT @code = PROJETO.getUniqueCode('G');

		INSERT INTO PROJETO.Criador VALUES(@code);

		SELECT @nome = nome, @cadeira = cadeira FROM INSERTED;

		INSERT INTO PROJETO.Grupo VALUES(@nome, @cadeira, @code);
	COMMIT

END

-- Antes de inserirmos uma entidade capaz de criar um ficheiro, temos de lhe associar uma entidade criador
-- Este trigger utiliza a função getUniqueCode para criar um Criador e só depois insere os valores na tabela Cadeira
CREATE TRIGGER createCriadorCadeira
ON PROJETO.Cadeira
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @code VARCHAR(15);
    DECLARE @nome VARCHAR(250), @link VARCHAR(250), @ano INT,
		@semestre INT, @nota_final FLOAT, @aluno VARCHAR(250), @instituicao INT;
	
	BEGIN TRANSACTION
		SELECT @code = PROJETO.getUniqueCode('C');

		INSERT INTO PROJETO.Criador VALUES(@code);

		SELECT @nome = nome, @link = link, @ano = ano, @semestre = semestre,
			@nota_final = nota_final, @aluno = aluno, @instituicao = instituicao
		FROM INSERTED;

		INSERT INTO PROJETO.Cadeira VALUES(@nome, @link, @ano, @semestre, @nota_final, @aluno, @code, @instituicao);
	COMMIT

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
CREATE TRIGGER createCriadorPagina
ON PROJETO.Pagina
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @code VARCHAR(15);
    DECLARE @titulo VARCHAR(250), @aluno VARCHAR(250), @cadeira INT;

	BEGIN TRANSACTION
		SELECT @code = PROJETO.getUniqueCode('P');

		INSERT INTO PROJETO.Criador VALUES(@code);

		SELECT @titulo = titulo, @aluno = aluno, @cadeira = cadeira
		FROM INSERTED;

		INSERT INTO PROJETO.Pagina VALUES(@titulo, @aluno, @cadeira, @code);
	COMMIT

END