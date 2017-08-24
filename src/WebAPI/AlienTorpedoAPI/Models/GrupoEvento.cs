using System;
using System.Collections.Generic;

namespace AlienTorpedoAPI.Models
{
    public partial class GrupoEvento
    {
        public int IdGrupoEvento { get; set; }
        public short? CdGrupo { get; set; }
        public int? CdEvento { get; set; }
        public string NmDescricao { get; set; }
        public DateTime? DtEvento { get; set; }

        public virtual Evento CdEventoNavigation { get; set; }
        public virtual Grupo CdGrupoNavigation { get; set; }
    }
}
