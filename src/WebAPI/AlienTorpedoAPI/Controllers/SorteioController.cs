using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlienTorpedoAPI.Classes;
using AlienTorpedoAPI.Models;

namespace AlienTorpedoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Sorteio")]
    public class SorteioController : Controller
    {

        private readonly dbAlienContext _dbcontext;
        public SorteioController(dbAlienContext dbContext)
        {
            _dbcontext = dbContext;
        }

        // GET: api/Sorteio
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sorteio/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Sorteio
        [HttpPost]
        public void Post([FromBody]GrupoEvento grupoEvento)
        {

            Sorteio sorteio = new Sorteio();
            sorteio.GeraSorteio(grupoEvento, _dbcontext);
        }

        //[HttpPost]
        //public void Post([FromBody]int id)
        //{
        //    Sorteio sorteio = new Sorteio();
        //    sorteio.GeraSorteio(id, _dbcontext);
        //}

        // PUT: api/Sorteio/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
