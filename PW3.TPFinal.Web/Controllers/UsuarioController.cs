using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Modelos;

namespace PW3.TPFinal.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Registrar()
        {         
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(RegistrarUsuarioModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            return View();
        }      
    }
}
