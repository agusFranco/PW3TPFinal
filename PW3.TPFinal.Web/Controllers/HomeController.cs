using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PW3.TPFinal.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> Logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.Logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
