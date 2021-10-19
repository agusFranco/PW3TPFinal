using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Modelos;
using PW3.TPFinal.Servicios.Contratos;

namespace PW3.TPFinal.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> Logger;
        private readonly IUsuarioServicio UsuarioServicio;

        public UsuarioController(
                                IUsuarioServicio usuarioServicio,
                                ILogger<UsuarioController> logger)
        {
            this.Logger = logger;
            this.UsuarioServicio = usuarioServicio;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(RegistrarUsuarioModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var usuario = this.UsuarioServicio.Registrar(modelo);

            if (usuario == null)
            {
                return View(modelo);
            }

            return RedirectToAction("Index", "Eventos");
        }
    }
}
