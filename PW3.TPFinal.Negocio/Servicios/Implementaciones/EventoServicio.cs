using System;
using System.Collections.Generic;
using System.Linq;
using PW3.TPFinal.Comun.Enums;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Negocio.Modelos;
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

        public Resultado Cancelar(CancelarEventoModel modelo)
        {
            var resultado = new Resultado<object>();

            // 1 - Validar
            if (modelo.IdEvento <= 0 || modelo.IdUsuario <= 0)
            {
                resultado.Success = false;
                resultado.Mensaje = "Evento o Usuario Invalidos.";
                return resultado;
            }

            try
            {
                // 2 - Buscar el Evento
                var evento = this.EventoRepositorio.Obtener(modelo.IdEvento);

                var validacion = this.ValidarEventoParaCancelar(evento, modelo.IdUsuario);

                if (!validacion.Success)
                {
                    return validacion;
                }

                // 3 - Actualizar
                evento.Estado = (int)EstadoDeEvento.Cancelado;

                this.EventoRepositorio.Actualizar(evento);
                this.EventoRepositorio.Guardar();

                resultado.Success = true;
                resultado.Mensaje = "Evento cancelado satisfactoriamente.";
            }
            catch (Exception)
            {
                resultado.Success = false;
                resultado.Mensaje = "Hubo un problema al actualizar el evento.";
            }

            return resultado;
        }

        protected Resultado ValidarEventoParaCancelar(Evento evento, int idUsuario)
        {
            var resultado = new Resultado<object>()
            {
                Success = true
            };

            if (evento == null)
            {
                resultado.Success = false;
                resultado.Mensaje = "Evento invalido.";
                return resultado;
            }

            if (evento.IdCocinero != idUsuario)
            {
                resultado.Success = false;
                resultado.Mensaje = "Usuario no es el creador del evento.";
                return resultado;
            }

            // SI ES PASADO, NO PUEDO CANCELAR          
            if (evento.Fecha.Date <= DateTime.Now.Date)
            {
                resultado.Success = false;
                resultado.Mensaje = "El Evento debe tener fecha futura para poder ser cancelado.";
                return resultado;
            }

            if (evento.Estado != (int)EstadoDeEvento.Pendiente)
            {
                resultado.Success = false;
                resultado.Mensaje = "El Evento debe estar en Estado: Pendiente.";
                return resultado;
            }

            return resultado;
        }
    }
}
