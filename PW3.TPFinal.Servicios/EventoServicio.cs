using System;
using System.Collections.Generic;
using System.Linq;
using PW3.TPFinal.Dominio;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Servicios.Contratos;

namespace PW3.TPFinal.Servicios
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
            List<String> comentarios = new List<string>();
            comentarios.Add("Muy buena la comida");
            comentarios.Add("Groso el chef, traiga otra ronda");

            IList<Evento> eventos = new List<Evento>();
            //eventos.Add(new Evento("Evento 1", "/img1.png", comentarios, (decimal)1.5, 2000D));
            //eventos.Add(new Evento("Evento 2", "/img2.png", comentarios, (decimal)2.5, 2400D));
            //eventos.Add(new Evento("Evento 3", "/img3.png", comentarios, (decimal)3.5, 3000D));
            //eventos.Add(new Evento("Evento 4", "/img4.png", comentarios, (decimal)4.5, 2300D));

            return eventos;
        }
    }
}
