using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;
using System.Linq;
using System.Collections.Generic;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class EventoRepositorio : BaseRepositorio<Evento, int>, IEventoRepositorio
    {
        public EventoRepositorio(_20212C_TPContext context) : base(context)
        {
        }

        public IList<Evento> ObtenerUltimosSeisConAlMenosUnComentario()
        {
            return Set.Where( evento =>
               evento.Estado == 1 &&
               evento.Calificaciones.Any(calificacion => calificacion.Comentarios.Length > 0)
            )
            .OrderBy( evento =>
                evento.Fecha
            )
            .Take(6)
            .ToList();
        }
    }
}
