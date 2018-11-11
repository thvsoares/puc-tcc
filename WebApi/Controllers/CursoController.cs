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
    public class CursoController : ControllerBase
    {
        private readonly PucTccContext _context;

        public CursoController(PucTccContext context)
        {
            _context = context;
        }

        // GET api/aluno
        [HttpGet]
        public ActionResult<IEnumerable<Curso>> Get()
        {
            return _context.Cursos;
        }

        // PUT api/aluno/{id}
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody]Curso curso){
            var cursodb = _context.Cursos.FirstOrDefault(f => f.Id == id);
            try
            {
                if (cursodb != null)
                {
                    cursodb.Nome = curso.Nome;
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }
            return NotFound();
        }

        // DELETE api/aluno/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var curso = _context.Cursos.FirstOrDefault(f => f.Id == id);
            if (curso != null)
            {
                try
                {
                    _context.Cursos.Remove(curso);
                    _context.SaveChanges();
                    return Ok();
                }
                catch (System.Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }
            return NotFound();
        }
    }
}
