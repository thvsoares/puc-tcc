﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PucTcc.Models;

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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> Get()
        {
            return _context.Alunos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Aluno> Get(long id)
        {
            return _context.Alunos.FirstOrDefault(f => f.Id == id);
        }
    }
}