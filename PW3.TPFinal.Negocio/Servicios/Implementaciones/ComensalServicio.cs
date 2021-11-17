using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Negocio.Modelos.Data;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Servicios
{
    public class ComensalServicio : IComensalServicio
    {
        private readonly IReservaRepositorio ReservaRepositorio;
        private readonly IEventoRepositorio EventoRepositorio;
        private readonly ICalificacionRepositorio CalificacionRepositorio;
        private readonly ILogger<ComensalServicio> Logger;

        public ComensalServicio(
            IReservaRepositorio reservaRepositorio,
            IEventoRepositorio eventoRepositorio,
            ICalificacionRepositorio calificacionRepositorio,
            ILogger<ComensalServicio> logger)
        {
            this.Logger = logger;
            this.ReservaRepositorio = reservaRepositorio;
            this.EventoRepositorio = eventoRepositorio;
            this.CalificacionRepositorio = calificacionRepositorio;
        }

        public IList<Evento> ObtenerEventosDisponibles()
        {
            return this.EventoRepositorio.ObtenerDisponibles();
        }

        public IList<ReservaModel> ObtenerReservas(int idUsuario)
        {
            IList<ReservaModel> reservas = this.ReservaRepositorio.ObtenerReservas(idUsuario)
                                                                  .Select(x => new ReservaModel(x))
                                                                  .ToList();
            return reservas;
        }

        public Resultado<Reserva> AgregarReserva(AgregarReservaModel modelo)
        {
            var resultado = new Resultado<Reserva>();

            try
            {
                var evento = this.EventoRepositorio.ObtenerCompletoPorId(modelo.IdEvento);

                if (evento == null)
                {
                    resultado.Success = false;
                    resultado.Mensaje = "Evento no encontrado.";
                    return resultado;
                }

                int cantidadReservada = evento.Reservas?.Sum(x => x.CantidadComensales) ?? 0;

                if (cantidadReservada + modelo.CantidadComensales > evento.CantidadComensales)
                {
                    resultado.Success = false;
                    resultado.Mensaje = "Cantidad de comensales superada.";
                    return resultado;
                }

                Reserva nuevo = new Reserva();

                nuevo.IdEvento = modelo.IdEvento;
                nuevo.IdComensal = modelo.IdComensal;
                nuevo.IdReceta = modelo.IdReceta;
                nuevo.CantidadComensales = modelo.CantidadComensales;
                nuevo.FechaCreacion = DateTime.Now.Date;

                this.ReservaRepositorio.Agregar(nuevo);
                this.ReservaRepositorio.Guardar();

                resultado.Success = true;
                resultado.Mensaje = "Reserva guardada correctamente.";
                resultado.Dato = nuevo;
                return resultado;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Ocurrio un error. Ex.Mensaje = {ex.Message}");
                resultado.Success = false;
                resultado.Mensaje = "Ocurrio un error al guardar la Reserva. Intente Nuevamente.";
                return resultado;
            }
        }

        public Resultado ComentarEvento(ComentarModel modelo)
        {
            var resultado = new Resultado();

            try
            {
                var evento = this.EventoRepositorio.Obtener(modelo.IdEvento);

                if (evento == null)
                {
                    resultado.Success = false;
                    resultado.Mensaje = "Evento no encontrado.";
                    return resultado;
                }

                Calificacione nuevo = new Calificacione();

                nuevo.IdEvento = modelo.IdEvento;
                nuevo.IdComensal = modelo.IdUsuario;
                nuevo.Calificacion = modelo.Calificacion;
                nuevo.Comentarios = modelo.Comentario;

                this.CalificacionRepositorio.Agregar(nuevo);
                this.CalificacionRepositorio.Guardar();

                resultado.Success = true;
                resultado.Mensaje = "Comentario guardado correctamente.";
                return resultado;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Ocurrio un error. Ex.Mensaje = {ex.Message}");
                resultado.Success = false;
                resultado.Mensaje = "Ocurrio un error al guardar el Comentario. Intente Nuevamente.";
                return resultado;
            }
        }
    }
}
