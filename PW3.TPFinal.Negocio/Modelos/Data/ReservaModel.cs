using System;
using System.Linq;
using PW3.TPFinal.Comun.Enums;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Modelos.Data
{
    public class ReservaModel
    {
        public ReservaModel()
        {
        }

        public ReservaModel(Reserva reserva)
        {
            this.IdReserva = reserva.IdReserva;
            this.IdReceta = reserva.IdReceta;
            this.IdEvento = reserva.IdEvento;
            this.IdComensal = reserva.IdComensal;
            this.CantidadComensales = reserva.CantidadComensales;
            this.FechaCreacion = reserva.FechaCreacion.ToString("dd/MM/yyyy");
            this.EventoEstado = (EstadoDeEvento)reserva.IdEventoNavigation.Estado;
            this.EventoNombre = reserva.IdEventoNavigation.Nombre;
            this.PuedeComentar = this.EventoEstado == EstadoDeEvento.Finalizado && !reserva.IdEventoNavigation.Calificaciones.Any(x => x.IdComensal == reserva.IdComensal);
        }

        public int IdReserva { get; set; }

        public int IdEvento { get; set; }

        public int IdComensal { get; set; }

        public int IdReceta { get; set; }

        public int CantidadComensales { get; set; }

        public string FechaCreacion { get; set; }

        public string EventoNombre { get; set; }

        public EstadoDeEvento EventoEstado { get; set; }

        public bool PuedeComentar { get; set; }
    }
}
