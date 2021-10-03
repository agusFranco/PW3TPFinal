using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Servicios.Contratos;
using PW3.TPFinal.Web.Models;

namespace PW3.TPFinal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventoServicio _eventoServicio;

        public HomeController(ILogger<HomeController> logger, IEventoServicio eventoServicio)
        {
            _logger = logger;
            _eventoServicio = eventoServicio;
        }

        public IActionResult Index()
        {
            var eventos = this._eventoServicio.ObtenerTodos();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
