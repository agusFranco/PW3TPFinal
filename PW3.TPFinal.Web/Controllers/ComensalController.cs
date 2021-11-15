using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Web.Extensiones;
using PW3.TPFinal.Web.Filters;

namespace PW3.TPFinal.Web.Controllers
{
    [EsComensal]
    public class ComensalController : Controller
    {
        private readonly ILogger<ComensalController> Logger;
        private readonly IComensalServicio ComensalServicio;

        public ComensalController(
                                IComensalServicio comensalServicio,
                                ILogger<ComensalController> logger)
        {
            this.Logger = logger;
            this.ComensalServicio = comensalServicio;
        }

        public IActionResult Reserva()
        {
            var eventos = this.ComensalServicio.ObtenerEventosDisponibles();
            return View(eventos);
        }

        [HttpPost]
        public IActionResult Reserva(AgregarReservaModel modelo)
        {
            return View();
        }

        [Route("/Comensal/")]
        [Route("/Comensal/Reservas")]
        public IActionResult Reservas()
        {
            Usuario comensal = HttpContext.Session.ObtenerUsuario();
            IList<Reserva> reservas = this.ComensalServicio.ObtenerReservas(comensal.IdUsuario);
            return View(reservas);
        }

        public IActionResult Comentarios()
        {
            return View();
        }
    }
}
