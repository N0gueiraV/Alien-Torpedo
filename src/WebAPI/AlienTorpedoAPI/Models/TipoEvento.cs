using System;
using System.Collections.Generic;

namespace AlienTorpedoAPI.Models
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Evento = new HashSet<Evento>();
        }

        public short CdTipoEvento { get; set; }
        public string NmTipoEvento { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}
