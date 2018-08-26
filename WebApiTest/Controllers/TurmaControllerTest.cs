using Microsoft.EntityFrameworkCore;
using PucTcc.Controllers;
using PucTcc.Models;
using System;
using System.Linq;
using Xunit;

namespace WebApiTest.Controller
{
    public class TurmaControllerTest
    {
        [Fact]
        public void MatricularTurmaOk()
        {
            var context = CreateContext();
            var controller = new TurmaController(context);
            controller.MatricularAluno(10, 100);
            var turmaAluno = context.AlunosTurmas.FirstOrDefault(f => f.IdAluno == 100 && f.IdTurma == 10);
            Assert.True(turmaAluno != null);
            Assert.Equal(1, turmaAluno.Turma.Vagas);
        }

        [Fact]
        public void MatricularTurmaCompleta()
        {
            var context = CreateContext();
            var controller = new TurmaController(context);
            controller.MatricularAluno(10, 100);
            controller.MatricularAluno(10, 101);
            var turmaAluno = context.AlunosTurmas.FirstOrDefault(f => f.IdAluno == 100 && f.IdTurma == 10);
            Assert.Equal(0, turmaAluno.Turma.Vagas);
        }

        [Fact]
        public void MatricularTurmaDuplicada()
        {
            var context = CreateContext();
            var controller = new TurmaController(context);
            var message = Assert.Throws<ApplicationException>(() =>
            {
                controller.MatricularAluno(10, 100);
                controller.MatricularAluno(10, 100);
            }).Message;
            Assert.Contains("já matriculado", message);
        }

        [Fact]
        public void MatricularTurmaLotada()
        {
            var context = CreateContext();
            var controller = new TurmaController(context);
            var message = Assert.Throws<ApplicationException>(() =>
            {
                controller.MatricularAluno(10, 100);
                controller.MatricularAluno(10, 101);
                controller.MatricularAluno(10, 102);
            }).Message;
            Assert.Contains("sem vagas", message);
        }

        private PucTccContext CreateContext()
        {
            var context = new PucTccContext(
                new DbContextOptionsBuilder<PucTccContext>()
                    .UseInMemoryDatabase(databaseName: "Turmas")
                    .Options);
            context.Database.EnsureDeleted();
            CreateTestData(ref context);
            return context;
        }

        private void CreateTestData(ref PucTccContext context)
        {
            var curso = new Curso()
            {
                Id = 1,
                Nome = "Curso"
            };
            var turma = new Turma()
            {
                Id = 10,
                Nome = "Curso.Turma1",
                IdCurso = curso.Id,
                Curso = curso,
                Vagas = 2,
            };

            for (int i = 0; i < 3; i++)
            {
                context.Alunos.Add(new Aluno()
                {
                    Id = 100 + i,
                    Nome = "Aluno" + i,
                    IdCurso = curso.Id,
                    Curso = curso
                });
            }

            context.Cursos.Add(curso);
            context.Turmas.Add(turma);
            context.SaveChanges();
        }
    }
}