using Microsoft.Extensions.Logging;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using System.Collections.Generic;

namespace PW3.TPFinal.Negocio.Servicios
{
    public class ComensalServicio : IComensalServicio
    {
        private readonly IReservaRepositorio ReservaRepositorio;
        private readonly IEventoRepositorio EventoRepositorio;
        private readonly ILogger<ComensalServicio> Logger;

        public ComensalServicio(IReservaRepositorio reservaRepositorio, IEventoRepositorio eventoRepositorio, ILogger<ComensalServicio> logger)
        {  
            this.Logger = logger;
            this.ReservaRepositorio = reservaRepositorio;
            this.EventoRepositorio = eventoRepositorio;
        }

        public IList<Evento> ObtenerEventosDisponibles()
        {
           return this.EventoRepositorio.ObtenerDisponibles();
        }

 public List<Reserva> ObtenerReservas(int idUsuario)
        {
            List<Reserva> reservas  = this.ReservaRepositorio.ObtenerReservas(idUsuario);
          
            return reservas;
        }
    }
}
