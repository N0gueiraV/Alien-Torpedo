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
    public class UsuarioController : Controller
    {
        //Vinicius - Construtor para iniciar dbcontext - INI
        private readonly dbAlienContext _dbcontext;

        public UsuarioController(dbAlienContext dbContext)
        {
            _dbcontext = dbContext;
        }
        //Vinicius - Construtor para iniciar dbcontext - FIM

        // POST api/Usuario
        [HttpPost]
        public IActionResult CadastraUsuario([FromBody]Usuario user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.NmSenha = CriptografaSenha(user.NmSenha);

            _dbcontext.Add(user);
            _dbcontext.SaveChanges();

            return Ok("Usuário cadastrado com sucesso!");
        }

        [HttpPut("{CdUsuario}")]
        public IActionResult AlteraSenha(int CdUsuario, [FromBody] Usuario user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (user == null || user.NmSenha == "")
            {
                return BadRequest("Favor fornecer a nova senha!");
            }

            //Selecionando usuário
            var UsuarioCadastrado = _dbcontext.Usuario.FirstOrDefault(u => u.CdUsuario == CdUsuario);

            UsuarioCadastrado.NmSenha = CriptografaSenha(user.NmSenha);

            _dbcontext.Usuario.Update(UsuarioCadastrado);
            _dbcontext.SaveChanges();

            return Ok("Senha alterada com sucesso!");
        }


        private string CriptografaSenha(string senha)
        {


            return senha;
        } 
    }
}