using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlienTorpedoAPI.Models;
using AlienTorpedoAPI.Classes;

namespace AlienTorpedoAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
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
                return Json(new { cdretorno = 1, mensagem = "Chamada fora do padrão, favor verificar!" });
            }

            try
            {
                user.NmSenha = Senha.CriptografaSenha(user.NmSenha.ToString());
                user.DtInclusao = DateTime.Now;

                _dbcontext.Add(user);
                _dbcontext.SaveChanges();

                return Json(new { cdretorno = 0, mensagem = "Usuário cadastrado com sucesso" });
            }
            catch
            {
                return Json(new { cdretorno = 1, mensagem = "Erro ao cadastrar usuário, favor verificar!"});
            }

        }

        [HttpPut]
        public IActionResult AlteraSenha([FromBody] Usuario user)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { cdretorno = 1, mensagem = "Chamada fora do padrão, favor verificar!" });
            }

            if (user == null || user.NmSenha == "")
            {
                return Json(new { cdretorno = 1, mensagem = "Favor fornecer a nova senha!" });
            }

            var CdRetorno = Senha.AlteraSenha(user.CdUsuario, user.NmSenha, _dbcontext);

            if (CdRetorno == 0)
            {
                return Json(new { cdretorno = 0, mensagem = "Senha alterada com sucesso!" });
            }
            else
            {
                return Json(new { cdretorno = 1, mensagem = "Falha ao alterar senha, favor verificar!" });
            }
            
        }

        [HttpPut]
        public IActionResult EditaUsuario([FromBody] Usuario user)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { cdretorno = 1, mensagem = "Chamada fora do padrão, favor verificar!" });
            }

            try
            {
                var UsuarioCadastrado = _dbcontext.Usuario.FirstOrDefault(u => u.CdUsuario == user.CdUsuario);

                UsuarioCadastrado.NmUsuario = user.NmUsuario;
                UsuarioCadastrado.NmEmail = user.NmEmail;
                if (UsuarioCadastrado.NmSenha != user.NmSenha)
                {
                    UsuarioCadastrado.NmSenha = Senha.CriptografaSenha(user.NmSenha);
                }
                _dbcontext.Usuario.Update(UsuarioCadastrado);
                _dbcontext.SaveChanges();

                return Json(new { cdretorno = 0, mensagem = "Usuário alterado com sucesso!" });
            }
            catch
            {
                return Json(new { cdretorno = 1, mensagem = "Falha ao alterar usuário, favor verificar!" });
            }
        }

        [HttpPut]
        public IActionResult AlteraStatus([FromBody] Usuario user)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { cdretorno = 1, mensagem = "Chamada fora do padrão, favor verificar!" });
            }

            try
            {
                var UsuarioCadastrado = _dbcontext.Usuario.FirstOrDefault(u => u.CdUsuario == user.CdUsuario);

                UsuarioCadastrado.DvAtivo = user.DvAtivo;
                _dbcontext.Usuario.Update(UsuarioCadastrado);
                _dbcontext.SaveChanges();

                return Json(new { cdretorno = 0, mensagem = "Status alterado com sucesso!" });
            }
            catch
            {
                return Json(new { cdretorno = 1, mensagem = "Falha ao alterar status, favor verificar!" });
            }
        }
    }
}