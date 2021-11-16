using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Negocio.Modelos.Data;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Web.Models;

namespace PW3.TPFinal.Web.Controllers
{
    public class EventoController : ControllerBase
    {
        private readonly ILogger<EventoController> Logger;
        private readonly IEventoServicio EventoServicio;

        public EventoController(ILogger<EventoController> logger, IEventoServicio eventoServicio)
        {
            this.Logger = logger;
            this.EventoServicio = eventoServicio;
        }

        public IActionResult Index()
        {
            IList<EventoModel> eventos = this.EventoServicio.ObtenerUltimosSeisConAlMenosUnComentario();
            return View(eventos);
        }

        [Route("/Evento/{id}/Detalle")]
        public IActionResult Detalle(int id)
        {            
            var evento = this.EventoServicio.ObtenerPorId(id);

            if (evento == null)
            {
                this.AgregarError("No se encontro el evento.");
                RedirectToAction(nameof(this.Index));
            }

            return View(evento);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
