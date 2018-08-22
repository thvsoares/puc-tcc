using System.Collections.Generic;

namespace PucTcc.Models
{
    public class Turma
    {
        public long Id { get; set; }
        public long IdCurso { get; set; }
        public string Nome { get; set; }
        public int Vagas { get; set; }
        public Curso Curso { get; set; }
        public IEnumerable<Aluno> Alunos { get; set; }
    }
}