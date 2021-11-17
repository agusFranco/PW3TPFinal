using System;
using System.Collections.Generic;
using System.Linq;
using PW3.TPFinal.Comun.Enums;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Modelos.Data
{
    public class EventoModel
    {
        public EventoModel()
        {
        }

        public EventoModel(Evento evento)
        {
            if (evento == null)
            {
                return;
            }

            this.IdEvento = evento.IdEvento;
            this.IdCocinero = evento.IdCocinero;
            this.NombreCocinero = evento.IdCocineroNavigation?.Nombre;
            this.Nombre = evento.Nombre;
            this.Fecha = evento.Fecha.ToString("dd/MM/yyyy");
            this.CantidadComensales = evento.CantidadComensales;
            this.Ubicacion = evento.Ubicacion;
            this.Precio = evento.Precio.ToString("0.00");
            this.Foto = evento.Foto;
            this.Estado = (EstadoDeEvento)evento.Estado;
            this.Puntuacion = ((decimal)evento.Calificaciones.Sum(x => x.Calificacion) / (decimal)evento.Calificaciones.Count).ToString("0.0");
            this.Calificaciones = evento.Calificaciones.Select(x => new CalificacionModel(x)).ToList();
        }

        public int IdEvento { get; set; }

        public int IdCocinero { get; set; }

        public string Nombre { get; set; }

        public string NombreCocinero { get; set; }

        public string Fecha { get; set; }

        public int CantidadComensales { get; set; }

        public string Ubicacion { get; set; }

        public string Foto { get; set; }

        public string Precio { get; set; }

        public EstadoDeEvento Estado { get; set; }

        public string Puntuacion { get; set; }

        public IList<CalificacionModel> Calificaciones { get; set; }
    }
}
