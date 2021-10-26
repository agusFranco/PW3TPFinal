using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Servicios.Contratos;

namespace PW3.TPFinal.Web.Controllers
{
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
            return View();
        }

        [Route("/Comensal/")]
        [Route("/Comensal/Reservas")]
        public IActionResult Reservas()
        {
            return View();
        }

        public IActionResult Comentarios()
        {
            return View();
        }
    }
}
