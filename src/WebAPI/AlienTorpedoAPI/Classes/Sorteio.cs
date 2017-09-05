using AlienTorpedoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlienTorpedoAPI.Classes
{
    public class Sorteio
    {
        public int IdGrupoEvento, CdGrupo, CdEvento, CdUsuario;
        public string NmDescricao;
        public DateTime DtEvento;

        public Sorteio()
        {
        }

        public void GeraSorteio(int idGrupoEvento, dbAlienContext dbContext)
        {
            var GrupoEvento = dbContext.GrupoEvento.FirstOrDefault(u => u.IdGrupoEvento == idGrupoEvento);
            GrupoEvento.CdEvento = 1;

            dbContext.GrupoEvento.Update(GrupoEvento);
            dbContext.SaveChanges();
        }

        public void GeraSorteio(GrupoEvento grupoEvento, dbAlienContext dbContext)
        {
            int idGrupoEvento = 0;

            idGrupoEvento = grupoEvento.IdGrupoEvento;

            var GrupoEvento = dbContext.GrupoEvento.FirstOrDefault(u => u.IdGrupoEvento == idGrupoEvento);

            Random rand = new Random();
            int toSkip = rand.Next(1, dbContext.Evento.Count()+1);

            var Evento = dbContext.Evento.FirstOrDefault(u => u.CdEvento == toSkip);
                
                //Skip(toSkip).Take(1).First();
                        
            GrupoEvento.CdEvento = Evento.CdEvento;

            dbContext.GrupoEvento.Update(GrupoEvento);
            dbContext.SaveChanges();
        }

        public void GeraSorteio(int idGrupo, int cdGrupo, int cdUsuario)
        {

        }
    }
}
