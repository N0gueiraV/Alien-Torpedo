using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlienTorpedoAPI;
using AlienTorpedoAPI.Models;

namespace AlienTorpedoAPI.Classes
{
    public static class Senha
    {
        public static int AlteraSenha(int CdUsuario, string NovaSenha, dbAlienContext dbcontext)
        {
            //Selecionando usuário
            try
            {
                var UsuarioCadastrado = dbcontext.Usuario.FirstOrDefault(u => u.CdUsuario == CdUsuario);

                UsuarioCadastrado.NmSenha = CriptografaSenha(NovaSenha);

                dbcontext.Usuario.Update(UsuarioCadastrado);
                dbcontext.SaveChanges();
                return 0;
            }

            catch
            {
                return 1;
            }
        }

        public static string CriptografaSenha(string senha)
        {
            return senha;
        }

    }
}
