using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Modelos;
using PW3.TPFinal.Servicios.Contratos;

namespace PW3.TPFinal.Web.Controllers
{
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
            return View();
        }

        [HttpPost]
        public IActionResult Recetas(AgregarRecetaModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var resultado = this.CocineroServicio.AgregarReceta(modelo);

            if (!resultado.Success)
            {
                ViewBag.Mensaje = resultado.Mensaje;
                return View(modelo);
            }

            TempData["Mensaje"] = resultado.Mensaje;

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
    }
}
