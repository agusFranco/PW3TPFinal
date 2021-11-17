using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PW3.TPFinal.Web.Extensiones;

namespace PW3.TPFinal.Web.Filters
{
    public class Logeado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.ExisteUsuario())
            {
                context.Result = new RedirectResult("/Usuario/Ingresar");                
                return;
            }

            base.OnActionExecuting(context);
        }        
    }
}
