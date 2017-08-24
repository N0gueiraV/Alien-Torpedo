using System;
using System.Collections.Generic;

namespace AlienTorpedoAPI.Models
{
    public partial class Evento
    {
        public Evento()
        {
            GrupoEvento = new HashSet<GrupoEvento>();
        }

        public int CdEvento { get; set; }
        public short? CdTipoEvento { get; set; }
        public string NmEvento { get; set; }
        public string NmEndereco { get; set; }
        public double? VlEvento { get; set; }
        public double? VlNota { get; set; }
        public bool? DvParticular { get; set; }
        public int? CdUsuario { get; set; }

        public virtual ICollection<GrupoEvento> GrupoEvento { get; set; }
        public virtual TipoEvento CdTipoEventoNavigation { get; set; }
        public virtual Usuario CdUsuarioNavigation { get; set; }
    }
}
