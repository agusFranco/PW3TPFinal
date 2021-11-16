using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Enums;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Web.Extensiones;
using PW3.TPFinal.Web.Filters;


namespace PW3.TPFinal.Web.Controllers
{
    public class UsuarioController : ControllerBase
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
        [NoEstaLogeado]
        public IActionResult Registrar(RegistrarUsuarioModel modelo)
        {
            if (!ModelState.IsValid)
            {
                this.AgregarErrorDelModelState();
                return View(modelo);
            }

            var resultado = this.UsuarioServicio.Registrar(modelo);

            if (!resultado.Success)
            {
                this.AgregarError(resultado.Mensaje);
                return View(modelo);
            }

            return this.FinalizarIngreso(resultado.Dato);
        }

        [NoEstaLogeado]
        public IActionResult Ingresar()
        {
            return View();
        }


        [Logeado]
        public IActionResult Salir()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("X-PW3-Ticket");
            return RedirectToAction("Index", "Evento");
        }

        [HttpPost]
        [NoEstaLogeado]
        public IActionResult Ingresar(IngresarUsuarioModel modelo)
        {
            if (!ModelState.IsValid)
            {
                this.AgregarErrorDelModelState();
                return View();
            }

            var resultado = this.UsuarioServicio.ValidarUsuario(modelo);

            if (!resultado.Success)
            {
                ModelState.AddModelError(string.Empty, "Credenciales incorrectas");
                return View(modelo);
            }

            return this.FinalizarIngreso(resultado.Dato);
        }

        private IActionResult FinalizarIngreso(IngresoAutorizadoModel modelo)
        {
            this.AgregarSuccess("Bienvenido.!");
            Response.Cookies.Append("X-PW3-Ticket", modelo.Ticket);           
            HttpContext.Session.SetUsuario(modelo.Usuario);
            return this.Redirigir(modelo.Usuario.Perfil);
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
