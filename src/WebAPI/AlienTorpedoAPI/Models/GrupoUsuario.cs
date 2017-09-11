using System;
using System.Collections.Generic;

namespace AlienTorpedoAPI.Models
{
    public partial class GrupoUsuario
    {
        public int CdUsuario { get; set; }
        public int CdGrupo { get; set; }
        public short? NrVoto { get; set; }

        public virtual Grupo CdGrupoNavigation { get; set; }
        public virtual Usuario CdUsuarioNavigation { get; set; }
    }
}
