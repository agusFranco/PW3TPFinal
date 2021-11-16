using System;
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
            this.IdEvento = evento.IdEvento;
            this.IdCocinero = evento.IdCocinero;
            this.Nombre = evento.Nombre;
            this.Fecha = evento.Fecha;
            this.CantidadComensales = evento.CantidadComensales;
            this.Ubicacion = evento.Ubicacion;
            this.Precio = evento.Precio.ToString("0.00");
            this.Foto = evento.Foto;
            this.Estado = (EstadoDeEvento)evento.Estado;
            this.Puntuacion = ((decimal)evento.Calificaciones.Sum(x => x.Calificacion) / (decimal)evento.Calificaciones.Count).ToString("0.0");
        }

        public int IdEvento { get; set; }

        public int IdCocinero { get; set; }

        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public int CantidadComensales { get; set; }

        public string Ubicacion { get; set; }

        public string Foto { get; set; }

        public string Precio { get; set; }

        public EstadoDeEvento Estado { get; set; }

        public string Puntuacion { get; set; }
    }
}
