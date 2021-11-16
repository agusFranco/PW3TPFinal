using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PW3.TPFinal.Comun.Enums;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class EventoRepositorio : BaseRepositorio<Evento, int>, IEventoRepositorio
    {
        public EventoRepositorio(_20212C_TPContext context) : base(context)
        {
        }

        public IList<Evento> ObtenerPorIdCocinero(int idCocinero)
        {
            return Set.Where(evento => evento.IdCocinero == idCocinero).ToList();
        }

        public Evento ObtenerCompletoPorId(int id)
        {
            return this.Set.Include(x => x.Reservas)
                           .Include(x => x.Calificaciones)
                            .ThenInclude(d => d.IdComensalNavigation)
                           .Include(x => x.EventosReceta)
                           .Include(x => x.IdCocineroNavigation)
                           .Where(x => x.IdEvento == id)
                           .FirstOrDefault();
        }

        public IList<Evento> ObtenerUltimosSeisConAlMenosUnComentario()
        {
            return Set.Include(x => x.Calificaciones)
                      .Where(evento => evento.Estado == (int)EstadoDeEvento.Finalizado &&
                                       evento.Calificaciones.Any(calificacion => calificacion.Comentarios.Length > 0))
                      .OrderBy(evento => evento.Fecha)
                      .Take(6)
                      .ToList();
        }

        public IList<Evento> ObtenerDisponibles()
        {
            return this.Set.Include(x => x.Reservas)
                           .Where(x => x.Estado == (int)EstadoDeEvento.Pendiente &&
                                       x.Reservas.Sum(d => d.CantidadComensales) < x.CantidadComensales)
                           .Include(x => x.EventosReceta)
                           .ThenInclude(x => x.IdRecetaNavigation)
                           .ToList();
        }
    }
}
