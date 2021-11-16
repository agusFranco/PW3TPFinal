using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PW3.TPFinal.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ILogger<EventosController> _logger;

        public EventosController(ILogger<EventosController> logger)
        {
            _logger = logger;
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
        public object Cancelar(int id)
        {
            return $"INTENTO DE BORRAR EL EVENTO CON ID {id}";
        }

    }
}
