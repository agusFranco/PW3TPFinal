using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Repositorio.Modelos;
using PW3.TPFinal.Servicios.Contratos;
using PW3.TPFinal.Web.Extensiones;
using PW3.TPFinal.Web.Filters;

namespace PW3.TPFinal.Web.Controllers
{
    [EsCocinero]
    public class CocineroController : Controller
    {
        private readonly ILogger<CocineroController> Logger;
        private readonly ICocineroServicio CocineroServicio;

        public CocineroController(
                                ICocineroServicio cocineroServicio,
                                ILogger<CocineroController> logger)
        {
            this.Logger = logger;
            this.CocineroServicio = cocineroServicio;
        }

        public IActionResult Recetas()
        {
            return View(this.ObtenerAgregarRecetaModel());
        }

        [HttpPost]
        public IActionResult Recetas(AgregarRecetaModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(this.ObtenerAgregarRecetaModel(modelo));
            }

            modelo.IdCocinero = HttpContext.Session.ObtenerIdUsuario();

            var resultado = this.CocineroServicio.AgregarReceta(modelo);

            TempData["Mensaje"] = resultado.Mensaje;

            if (!resultado.Success)
            {
                return View(this.ObtenerAgregarRecetaModel(modelo));
            }

            return RedirectToAction("Perfil", "Cocinero");
        }

        public IActionResult Eventos()
        {
            return View(this.ObtenerNuevoEventoModel());
        }

        [HttpPost]
        public IActionResult Eventos(AgregarEventoModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(this.ObtenerNuevoEventoModel(modelo));
            }

            modelo.IdCocinero = HttpContext.Session.ObtenerIdUsuario();

            var resultado = this.CocineroServicio.AgregarEvento(modelo);

            TempData["Mensaje"] = resultado.Mensaje;

            if (!resultado.Success)
            {
                return View(this.ObtenerNuevoEventoModel(modelo));
            }

            return RedirectToAction("Perfil", "Cocinero");
        }

        public IActionResult Perfil()
        {
            // Mandar datos del cocinero
            int idCocinero = HttpContext.Session.ObtenerIdUsuario();
            Usuario cocinero = this.CocineroServicio.ObtenerDatosDelCocinero(idCocinero);

            // Mandar listado de recetas
            IList<Receta> recetas = this.CocineroServicio.ObtenerRecetasPorIdCocinero(idCocinero);

            // Mandar listado de eventos
            IList<Evento> eventos = this.CocineroServicio.ObtenerEventosPorIdCocinero(idCocinero);

            PerfilCocineroViewModel perfilCocineroViewModel = new PerfilCocineroViewModel
            {
                Cocinero = cocinero,
                Recetas = recetas,
                Eventos = eventos
            };

            return View(perfilCocineroViewModel);
        }

        public IActionResult Cancelacion()
        {
            return View();
        }

        private List<SelectListItem> ObtenerTipoRecetas()
        {
            return this.CocineroServicio.ObtenerTiposDeReceta()?
                                                    .Select(x => new SelectListItem() { Text = x.Nombre, Value = x.IdTipoReceta.ToString() })?
                                                    .ToList() ?? new List<SelectListItem>();
        }

        private List<SelectListItem> ObtenerRecetas()
        {
            return this.CocineroServicio.ObtenerRecetasPorIdCocinero(HttpContext.Session.ObtenerIdUsuario())?
                                                    .Select(x => new SelectListItem() { Text = x.Nombre, Value = x.IdReceta.ToString() })?
                                                    .ToList() ?? new List<SelectListItem>();
        }

        private AgregarRecetaModel ObtenerAgregarRecetaModel(AgregarRecetaModel modelo = null)
        {
            modelo ??= new AgregarRecetaModel();

            modelo.TipoRecetas = this.ObtenerTipoRecetas();

            return modelo;
        }

        private AgregarEventoModel ObtenerNuevoEventoModel(AgregarEventoModel modelo = null)
        {
            modelo ??= new AgregarEventoModel();

            modelo.Recetas = this.ObtenerRecetas();

            return modelo;
        }
    }
}
