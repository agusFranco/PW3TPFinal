using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Modelos;
using PW3.TPFinal.Servicios.Contratos;
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
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
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

        private AgregarRecetaModel ObtenerAgregarRecetaModel(AgregarRecetaModel modelo = null)
        {
            modelo ??= new AgregarRecetaModel();

            modelo.TipoRecetas = this.ObtenerTipoRecetas();

            return modelo;
        }
    }
}
