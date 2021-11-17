﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PW3.TPFinal.Web.Extensiones;

namespace PW3.TPFinal.Web.Filters
{
    public class NoEstaLogeado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.ExisteUsuario())
            {
                context.Result = new RedirectResult("/Evento/Index");                
                return;
            }

            base.OnActionExecuting(context);
        }        
    }
}
