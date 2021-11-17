using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Negocio.Modelos.Data;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Web.Extensiones;
using PW3.TPFinal.Web.Filters;

namespace PW3.TPFinal.Web.Controllers
{
    [EsComensal]
    public class ComensalController : ControllerBase
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
            var modelo = this.ObtenerAgregarReservaModel();
            return View(modelo);
        }

        [HttpPost]
        public IActionResult Reserva(AgregarReservaModel modelo)
        {
            if (!ModelState.IsValid)
            {
                this.AgregarErrorDelModelState();
                return View(this.ObtenerAgregarReservaModel(modelo));
            }

            modelo.IdComensal = HttpContext.Session.ObtenerIdUsuario();

            var resultado = this.ComensalServicio.AgregarReserva(modelo);

            if (!resultado.Success)
            {
                this.AgregarError(resultado.Mensaje);
                return View(this.ObtenerAgregarReservaModel(modelo));
            }

            this.AgregarSuccess(resultado.Mensaje);
            return RedirectToAction("Reservas", "Comensal");
        }

        [Route("/Comensal/")]
        [Route("/Comensal/Reservas")]
        public IActionResult Reservas()
        {
            Usuario comensal = HttpContext.Session.ObtenerUsuario();
            IList<ReservaModel> reservas = this.ComensalServicio.ObtenerReservas(comensal.IdUsuario);
            return View(reservas);
        }

        [HttpPost]
        public IActionResult Comentar(ComentarModel modelo)
        {
            if (!ModelState.IsValid)
            {
                this.AgregarErrorDelModelState();
                return RedirectToAction(nameof(Reservas));
            }

            modelo.IdUsuario = HttpContext.Session.ObtenerIdUsuario();

            var resultado = this.ComensalServicio.ComentarEvento(modelo);

            if (!resultado.Success)
            {
                this.AgregarError(resultado.Mensaje);
                return RedirectToAction(nameof(Reservas));
            }

            this.AgregarSuccess(resultado.Mensaje);
            return RedirectToAction(nameof(Reservas));
        }

        private AgregarReservaModel ObtenerAgregarReservaModel(AgregarReservaModel modelo = null)
        {
            modelo ??= new AgregarReservaModel();

            modelo.Eventos = this.ComensalServicio.ObtenerEventosDisponibles().Select(x => new EventoRecetasModel(x)).ToList();

            return modelo;
        }
    }
}
