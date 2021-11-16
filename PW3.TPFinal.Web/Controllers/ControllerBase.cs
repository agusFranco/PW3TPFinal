using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace PW3.TPFinal.Web.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected virtual void AgregarError(string mensaje)
        {
            TempData["MensajeError"] = mensaje;
        }

        protected virtual void AgregarSuccess(string mensaje)
        {
            TempData["MensajeSuccess"] = mensaje;
        }

        protected virtual void AgregarErrorDelModelState()
        {
            this.AgregarError(string.Join(" | ", ModelState.Values
                                 .SelectMany(v => v.Errors)
                                 .Select(e => e.ErrorMessage)));
        }
    }
}
