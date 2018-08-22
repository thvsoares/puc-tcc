using System.Collections.Generic;

namespace PucTcc.Models
{
    public class Aluno
    {
        public long Id { get; set; }
        public long IdCurso { get; set; }
        public string Nome { get; set; }
        public Curso Curso { get; set; }
        public IEnumerable<Turma> Turmas { get; set; }
    }
}