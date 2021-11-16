using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Negocio.Servicios.Contratos;

namespace PW3.TPFinal.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ILogger<EventosController> Logger;
        private readonly IEventoServicio EventoServicio;

        public EventosController(
            IEventoServicio eventoServicio,
            ILogger<EventosController> logger)
        {
            this.EventoServicio = eventoServicio;
            this.Logger = logger;
        }

        [HttpGet]
        [Authorize]
        public object Get()
        {
            return $"Autorizado";
        }

        [Route("prueba")]
        [HttpGet]
        public object Prueba()
        {
            return "Sin Autorizacion";
        }

        // Eventos/{id}
        [Route("{id}")]
        [HttpDelete]
        [Authorize]
        public Resultado Cancelar(int id)
        {
            // Obtengo el UsuarioId del Claim NameIdentifier
            var usuarioId = int.Parse(this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var modelo = new CancelarEventoModel(usuarioId, id);

            var resultado = this.EventoServicio.Cancelar(modelo);

            return resultado;
        }
    }
}
