using System;
using System.Collections.Generic;
using System.Linq;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Negocio.Servicios.Contratos;

namespace PW3.TPFinal.Negocio.Servicios
{
    public class EventoServicio : IEventoServicio
    {
        private readonly IEventoRepositorio EventoRepositorio;

        public EventoServicio(IEventoRepositorio eventoRepositorio)
        {
            this.EventoRepositorio = eventoRepositorio;
        }

        public IList<Evento> ObtenerTodos()
        {
            return this.EventoRepositorio.Obtener().ToList();
        }

        public IList<Evento> ObtenerUltimosSeisConAlMenosUnComentario()
        {
            IList<Evento> eventos = this.EventoRepositorio.ObtenerUltimosSeisConAlMenosUnComentario();

            return eventos;
        }
    }
}
