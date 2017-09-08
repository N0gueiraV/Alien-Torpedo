using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlienTorpedoAPI.Models;

namespace AlienTorpedoAPI.Controllers
{
    [Route("api/[controller]")]
    public class GrupoController : Controller
    {
        private readonly dbAlienContext _dbcontext;

        public GrupoController(dbAlienContext dbContext)
        {
            _dbcontext = dbContext;
        }
        // POST api/Grupo
        [HttpPost]
        public IActionResult CadastraGrupo([FromBody]Grupo group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbcontext.Add(group);
            _dbcontext.SaveChanges();

            return Ok("Grupo cadastrado com sucesso!");
        }

    }
}