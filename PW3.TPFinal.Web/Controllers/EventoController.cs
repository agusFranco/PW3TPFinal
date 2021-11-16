using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Web.Models;
using PW3.TPFinal.Negocio.Modelos.Data;

namespace PW3.TPFinal.Web.Controllers
{
    public class EventoController : ControllerBase
    {
        private readonly ILogger<EventoController> _logger;
        private readonly IEventoServicio _eventoServicio;

        public EventoController(ILogger<EventoController> logger, IEventoServicio eventoServicio)
        {
            _logger = logger;
            _eventoServicio = eventoServicio;
        }

        public IActionResult Index()
        {
            IList<EventoModel> eventos = _eventoServicio.ObtenerUltimosSeisConAlMenosUnComentario();
            return View(eventos);
        }      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
