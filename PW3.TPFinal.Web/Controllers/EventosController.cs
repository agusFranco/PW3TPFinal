using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Servicios.Contratos;
using PW3.TPFinal.Web.Models;

namespace PW3.TPFinal.Web.Controllers
{
    public class EventosController : Controller
    {
        private readonly ILogger<EventosController> _logger;
        private readonly IEventoServicio _eventoServicio;

        public EventosController(ILogger<EventosController> logger, IEventoServicio eventoServicio)
        {
            _logger = logger;
            _eventoServicio = eventoServicio;
        }

        public IActionResult Index()
        {
            List<Evento> eventosConAlMenosUnComentario = (List<Evento>)_eventoServicio.ObtenerUltimosSeisConAlMenosUnComentario();

            return View(eventosConAlMenosUnComentario);
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
