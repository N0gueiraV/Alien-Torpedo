using System;
using System.Collections.Generic;

namespace AlienTorpedoAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Evento = new HashSet<Evento>();
            GrupoUsuario = new HashSet<GrupoUsuario>();
        }

        public int CdUsuario { get; set; }
        public string NmEmail { get; set; }
        public string NmUsuario { get; set; }
        public string NmSenha { get; set; }
        public bool? DvAtivo { get; set; }
        public DateTime? DtInclusao { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
        public virtual ICollection<GrupoUsuario> GrupoUsuario { get; set; }
    }
}
