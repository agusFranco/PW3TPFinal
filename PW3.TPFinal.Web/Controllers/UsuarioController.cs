using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Enums;
using PW3.TPFinal.Comun.Modelos;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Servicios.Contratos;
using PW3.TPFinal.Web.Extensiones;

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

            HttpContext.Session.SetUsuario(resultado.Dato);

            return this.Redirigir(resultado.Dato.Perfil);
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

            Usuario usuario = UsuarioServicio.ValidarUsuario(modelo);

            if (usuario != null)
            {
                HttpContext.Session.SetUsuario(usuario);
                return this.Redirigir(usuario.Perfil);
            }

            ModelState.AddModelError(string.Empty, "Credenciales incorrectas");
            return View(modelo);
        }

        private RedirectToActionResult Redirigir(int perfil)
        {
            if (perfil == (int)TipoUsuario.Cocinero)
                return RedirectToAction("Perfil", "Cocinero");

            if (perfil == (int)TipoUsuario.Comensal)
                return RedirectToAction("Reservas", "Comensal");

            return RedirectToAction("Index", "Evento");
        }
    }
}
