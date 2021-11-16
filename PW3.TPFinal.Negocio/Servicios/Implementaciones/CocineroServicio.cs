using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Enums;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Servicios
{
    public class CocineroServicio : ICocineroServicio
    {
        private readonly IRecetaRepositorio RecetaRepositorio;
        private readonly ITipoRecetaRepositorio TipoRecetaRepositorio;
        private readonly IEventoRepositorio EventoRepositorio;
        private readonly IHostingEnvironment HostingEnvironment;
        private readonly IUsuarioRepositorio UsuarioRepositorio;
        private readonly ILogger<CocineroServicio> Logger;

        public CocineroServicio(IRecetaRepositorio recetaRepositorio,
                                ITipoRecetaRepositorio tipoRecetaRepositorio,
                                IEventoRepositorio eventoRepositorio,
                                IHostingEnvironment hostingEnvironment,
                                ILogger<CocineroServicio> logger,
                                IUsuarioRepositorio usuarioRepositorio)
        {
            this.UsuarioRepositorio = usuarioRepositorio;
            this.RecetaRepositorio = recetaRepositorio;
            this.TipoRecetaRepositorio = tipoRecetaRepositorio;
            this.EventoRepositorio = eventoRepositorio;
            this.HostingEnvironment = hostingEnvironment;
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
                nuevo.Estado = (int)EstadoDeEvento.Pendiente;
                //nuevo.Descripcion = modelo.Descripcion;
                nuevo.Foto = $"{Guid.NewGuid()}{Path.GetExtension(modelo.Foto.FileName)}";
                nuevo.EventosReceta = modelo.RecetasPropuestas.Select(x => new EventosReceta() { IdReceta = x }).ToList();

                this.EventoRepositorio.Agregar(nuevo);
                this.EventoRepositorio.Guardar();

                this.GuardarFoto(modelo.Foto, nuevo.Foto);

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

        private Task GuardarFoto(IFormFile foto, string fotoId)
        {
            string fotos = Path.Combine(this.HostingEnvironment.ContentRootPath, "Fotos");

            Directory.CreateDirectory(fotos);

            string filePath = Path.Combine(fotos, fotoId);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                return foto.CopyToAsync(fileStream);
            }
        }

        public Usuario ObtenerDatosDelCocinero(int idCocinero)
        {
            return this.UsuarioRepositorio.Obtener(idCocinero);
        }

        public IList<Evento> ObtenerEventosPorIdCocinero(int idCocinero)
        {
            return this.EventoRepositorio.ObtenerPorIdCocinero(idCocinero);
        }
    }
}
