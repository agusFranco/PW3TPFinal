using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PW3.TPFinal.Web.Extensiones;

namespace PW3.TPFinal.Web.Filters
{
    public class EsCocinero : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.ExisteUsuario())
            {
                context.Result = new RedirectResult("/Usuario/Ingresar");             
                return;
            }

            if (!context.HttpContext.Session.EsCocinero())
            {
                context.Result = new RedirectResult("/Comensal/Reservas");                
                return;
            }

            base.OnActionExecuting(context);
        }        
    }
}
