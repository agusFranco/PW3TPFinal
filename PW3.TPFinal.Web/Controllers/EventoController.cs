using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Negocio.Modelos.Data;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using System.Collections.Generic;

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
    }
}
