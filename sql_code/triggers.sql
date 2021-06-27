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