using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PucTcc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PucTcc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly PucTccContext _context;

        public AlunoController(PucTccContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> Get()
        {
            return _context.Alunos;
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> Get(long id)
        {
            return _context.Alunos
                .Include(c => c.Curso)
                .Include(a => a.Turmas)
                .ThenInclude(at => at.Turma)
                .FirstOrDefault(f => f.Id == id);
        }
    }
}
