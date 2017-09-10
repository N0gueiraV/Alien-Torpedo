using System;
using System.Collections.Generic;

namespace AlienTorpedoAPI.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            GrupoEvento = new HashSet<GrupoEvento>();
            GrupoUsuario = new HashSet<GrupoUsuario>();
        }

        public int CdGrupo { get; set; }
        public string NmGrupo { get; set; }
        public DateTime? DtInclusao { get; set; }

        public virtual ICollection<GrupoEvento> GrupoEvento { get; set; }
        public virtual ICollection<GrupoUsuario> GrupoUsuario { get; set; }
    }
}
