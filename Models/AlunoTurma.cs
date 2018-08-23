using System.Collections.Generic;

namespace PucTcc.Models
{
    public class AlunoTurma
    {
        public long IdAluno { get; set; }
        public long IdTurma { get; set; }
        public Aluno Aluno { get; set; }
        public Turma Turma { get; set; }
    }
}