using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AlienTorpedoAPI.Models
{
    public class UsuarioValidation
    {

        public int CdUsuario { get; set; }

        //[Required(ErrorMessage = "Obrigatório informar um e-mail válido")]
        public string NmEmail { get; set; }

        [StringLength(80, ErrorMessage = "O nome do usuário não deve passar de 80 caracteres")]
        //[Required(ErrorMessage ="Obrigatório informar um nome de usuário")]
        public string NmUsuario { get; set; }

        //[Required(ErrorMessage = "Obrigatório informar uma senha")]
        public string NmSenha { get; set; }

        //[Required(ErrorMessage = "Obrigatório informar o status do usuário")]
        public bool? DvAtivo { get; set; }

        public DateTime? DtInclusao { get; set; }
    }
}
