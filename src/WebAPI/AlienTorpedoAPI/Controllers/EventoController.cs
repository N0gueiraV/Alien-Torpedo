using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlienTorpedoAPI.Models;

namespace AlienTorpedoAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class EventoController : Controller
    {
        private readonly dbAlienContext _dbcontext;

        public EventoController(dbAlienContext dbContext)
        {
            _dbcontext = dbContext;
        }

        // POST api/Evento/CadastraEvento
        [HttpPost]
        public IActionResult CadastraEvento([FromBody]Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbcontext.Add(evento);
            _dbcontext.SaveChanges();

            return Ok("Evento cadastrado com sucesso!");
        }

        // POST api/Evento/CadastraTipoEventos
        [HttpPost]
        public IActionResult CadastraTipoEvento([FromBody]TipoEvento tpevento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbcontext.Add(tpevento);
            _dbcontext.SaveChanges();

            return Ok("Tipo de evento cadastrado com sucesso!");
        }

        [HttpGet]
        public IActionResult ListaTipoEvento()
        {
            var TipoEventos = _dbcontext.TipoEvento.ToList();

            return Ok(TipoEventos);
        }

    }
}