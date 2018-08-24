using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PucTcc.Models;

namespace PucTcc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly PucTccContext _context;

        public TurmaController(PucTccContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Turma>> Get()
        {
            return _context.Turmas;
        }

        [HttpGet("curso/{idCurso}/vagasDisponiveis={vagasDisponiveis}")]
        public ActionResult<IEnumerable<Turma>> TurmasCurso(long idCurso, bool vagasDisponiveis = false)
        {
            var query = _context.Turmas
                .Where(w => w.IdCurso == idCurso);
            if (vagasDisponiveis)
                query = query.Where(w => w.Vagas > 0);
            return query.ToList();
        }

        [HttpPut("matricularAluno/{id}")]
        public ActionResult<AlunoTurma> MatricularAluno(long id, [FromBody]long idAluno)
        {
            var turma = _context.Turmas.FirstOrDefault(f => f.Id == id);
            if (turma.Vagas < 1)
                throw new ApplicationException("Turma sem vagas!");

            var turmasAluno = _context.AlunosTurmas.Where(w => w.IdAluno == idAluno && w.IdTurma == id);
            if (turmasAluno.Any())
                throw new ApplicationException("Aluno já matriculado na turma!");

            turma.Vagas--;
            var matricula = new AlunoTurma()
            {
                IdAluno = idAluno,
                IdTurma = id
            };
            _context.AlunosTurmas.Add(matricula);
            _context.SaveChanges();
            return matricula;
        }
    }
}
