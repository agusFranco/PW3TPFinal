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
        private readonly ILogger<CocineroServicio> Logger;

        public CocineroServicio(IRecetaRepositorio recetaRepositorio,
                                ITipoRecetaRepositorio tipoRecetaRepositorio,
                                ILogger<CocineroServicio> logger)
        {
            this.RecetaRepositorio = recetaRepositorio;
            this.TipoRecetaRepositorio = tipoRecetaRepositorio;
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

        public List<TipoReceta> ObtenerTiposDeReceta()
        {
            return this.TipoRecetaRepositorio.Obtener().ToList();
        }
    }
}
