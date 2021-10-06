using System;
using System.Collections.Generic;
using PW3.TPFinal.Servicios.Contratos;
using PW3.TPFinal.Web.Models;

namespace PW3.TPFinal.Servicios
{
    public class EventoServicio : IEventoServicio
    {
        public IList<Evento> ObtenerTodos()
        {
            return new List<Evento>();
        }

        public IList<Evento> ObtenerUltimosSeisConAlMenosUnComentario()
        {
            List<String> comentarios = new List<string>();
            comentarios.Add("Muy buena la comida");
            comentarios.Add("Groso el chef, traiga otra ronda");

            IList<Evento> eventos = new List<Evento>();
            eventos.Add(new Evento("Evento 1", "/img1.png", comentarios, (decimal)1.5, 2000D));
            eventos.Add(new Evento("Evento 2", "/img2.png", comentarios, (decimal)2.5, 2400D));
            eventos.Add(new Evento("Evento 3", "/img3.png", comentarios, (decimal)3.5, 3000D));
            eventos.Add(new Evento("Evento 4", "/img4.png", comentarios, (decimal)4.5, 2300D));

            return eventos;
        }
    }
}
