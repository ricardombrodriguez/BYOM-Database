CREATE FUNCTION PROJETO.getUniqueCode (@char VARCHAR(2))
RETURNS VARCHAR(15)
AS
BEGIN
    DECLARE @time VARCHAR(15), @code VARCHAR(15)
    SELECT @time = CAST(DATEDIFF_BIG(MILLISECOND, '1970-01-01', GETDATE()) AS VARCHAR(15));
    SET @code = CONCAT(@char, @time)
    RETURN @code
END

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

SELECT * FROM PROJETO.tarefasSemanais() as tarefas
SELECT * FROM PROJETO.getTarefasSemanaByDia('Tuesday') WHERE completada_ts IS NULL ORDER BY data_inicio DESC