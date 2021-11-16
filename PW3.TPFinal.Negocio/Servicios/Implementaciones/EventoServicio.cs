using System.Collections.Generic;
using System.Linq;
using PW3.TPFinal.Negocio.Modelos.Data;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Servicios
{
    public class EventoServicio : IEventoServicio
    {
        private readonly IEventoRepositorio EventoRepositorio;

        public EventoServicio(IEventoRepositorio eventoRepositorio)
        {
            this.EventoRepositorio = eventoRepositorio;
        }

        public IList<EventoModel> ObtenerUltimosSeisConAlMenosUnComentario()
        {
            return this.EventoRepositorio.ObtenerUltimosSeisConAlMenosUnComentario()
                                         .Select(x => new EventoModel(x))
                                         .ToList();
        }

        public Evento ObtenerPorId(int id)
        {
            return this.EventoRepositorio.ObtenerCompletoPorId(id);
        }
    }
}
