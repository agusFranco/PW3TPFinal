using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Modelos;
using PW3.TPFinal.Repositorio.Data;
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

            var resultado = this.UsuarioServicio.Registrar(modelo);

            if (!resultado.Success)
            {
                ViewBag.Mensaje = resultado.Mensaje;
                return View(modelo);
            }

            TempData["Mensaje"] = resultado.Mensaje;
            return RedirectToAction("Index", "Eventos");
        }

        public IActionResult Ingresar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(IngresarUsuarioModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Usuario usuarioBuscado = UsuarioServicio.ValidarUsuario(modelo);
            if (usuarioBuscado != null)
            {
                HttpContext.Session.SetInt32("idUsuario", usuarioBuscado.IdUsuario);
                HttpContext.Session.SetInt32("rolUsuario", usuarioBuscado.Perfil);
                

                return RedirectToAction("Index", "Evento");
            }

            ModelState.AddModelError(string.Empty, "Credenciales incorrectas");
            return View(modelo);
        }
    }
}
