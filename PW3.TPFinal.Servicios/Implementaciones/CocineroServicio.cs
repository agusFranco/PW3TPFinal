using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Modelos;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Servicios.Contratos;

namespace PW3.TPFinal.Servicios
{
    public class CocineroServicio : ICocineroServicio
    {
        private readonly IRecetaRepositorio RecetaRepositorio;
        private readonly ITipoRecetaRepositorio TipoRecetaRepositorio;
        private readonly IEventoRepositorio EventoRepositorio;
        private readonly ILogger<CocineroServicio> Logger;

        public CocineroServicio(IRecetaRepositorio recetaRepositorio,
                                ITipoRecetaRepositorio tipoRecetaRepositorio,
                                IEventoRepositorio eventoRepositorio,
                                ILogger<CocineroServicio> logger)
        {
            this.RecetaRepositorio = recetaRepositorio;
            this.TipoRecetaRepositorio = tipoRecetaRepositorio;
            this.EventoRepositorio = eventoRepositorio;
            this.Logger = logger;
        }

        public Resultado<Receta> AgregarReceta(AgregarRecetaModel modelo)
        {
            var resultado = new Resultado<Receta>();

            try
            {
                Receta nueva = new Receta();
                nueva.IdCocinero = modelo.IdCocinero;
                nueva.Nombre = modelo.Nombre;
                nueva.Descripcion = modelo.Descripcion;
                nueva.TiempoCoccion = modelo.TiempoDeCoccion;
                nueva.Ingredientes = modelo.Ingredientes;
                nueva.IdTipoReceta = modelo.IdTipoReceta;

                this.RecetaRepositorio.Agregar(nueva);
                this.RecetaRepositorio.Guardar();

                resultado.Success = true;
                resultado.Mensaje = "Receta guardada correctamente.";
                resultado.Dato = nueva;
                return resultado;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Ocurrio un error. Ex.Mensaje = {ex.Message}");
                resultado.Success = false;
                resultado.Mensaje = "Ocurrio un error al guardar la receta. Intente Nuevamente.";
                return resultado;
            }
        }

        public Resultado<Evento> AgregarEvento(AgregarEventoModel modelo)
        {
            var resultado = new Resultado<Evento>();

            try
            {
                Evento nuevo = new Evento();
                nuevo.IdCocinero = modelo.IdCocinero;
                nuevo.Nombre = modelo.Nombre;
                nuevo.Fecha = modelo.Fecha;
                nuevo.Ubicacion = modelo.Ubicacion;
                nuevo.CantidadComensales = modelo.Cantidad;
                nuevo.Precio = modelo.Precio;
                nuevo.Estado = 1;
                //nuevo.Descripcion = modelo.Descripcion;
                nuevo.Foto = "ASD";
                nuevo.EventosReceta = new List<EventosReceta>() { new EventosReceta() { IdReceta = modelo.RecetasPropuestas.First() } };

                this.EventoRepositorio.Agregar(nuevo);
                this.EventoRepositorio.Guardar();

                resultado.Success = true;
                resultado.Mensaje = "Evento guardado correctamente.";
                resultado.Dato = nuevo;
                return resultado;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Ocurrio un error. Ex.Mensaje = {ex.Message}");
                resultado.Success = false;
                resultado.Mensaje = "Ocurrio un error al guardar la Evento. Intente Nuevamente.";
                return resultado;
            }
        }

        public List<TipoReceta> ObtenerTiposDeReceta()
        {
            return this.TipoRecetaRepositorio.Obtener().ToList();
        }

        public List<Receta> ObtenerRecetasPorIdCocinero(int idCocinero)
        {
            return this.RecetaRepositorio.ObtenerPorIdCocinero(idCocinero).ToList();
        }
    }
}
