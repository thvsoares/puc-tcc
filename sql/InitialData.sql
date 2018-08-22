DECLARE @Curso BIGINT;
DECLARE @Turma BIGINT;
DECLARE @Aluno BIGINT;
DECLARE @IdCurso BIGINT;

DECLARE @Vagas INT;
DECLARE @Alunos INT;
SET @Vagas = 10;
SET @Alunos = 8;

SET @Curso = 0;
WHILE @Curso <= 10
BEGIN
    SET @Curso = @Curso + 1;
    INSERT INTO Curso(Nome) VALUES('Curso ' + CONVERT(VARCHAR(MAX), @Curso));
    SET @IdCurso = @@IDENTITY;
    
    SET @Turma = 0;
    WHILE @Turma <= 10
    BEGIN
        SET @Turma = @Turma + 1;
        INSERT INTO Turma(IdCurso, Nome, Vagas) VALUES(@IdCurso, 'Curso' + CONVERT(VARCHAR(MAX), @Curso) + '.Turma' + CONVERT(VARCHAR(MAX), @Turma), @Vagas);
    END;

    SET @Aluno = 0;
    WHILE @Aluno <= @Alunos
    BEGIN
        SET @Aluno = @Aluno + 1;
        INSERT INTO Aluno(IdCurso, Nome) VALUES(@IdCurso, 'Aluno ' + CONVERT(VARCHAR(MAX), @Aluno));
    END;
END;