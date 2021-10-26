using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Web.Extensiones;

namespace PW3.TPFinal.Web.Middleware
{
    public class UsuarioMiddleware
    {
        private readonly RequestDelegate _next;

        public UsuarioMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context, ILogger<UsuarioMiddleware> logger)
        {
            if (context.Session.ExisteUsuario())
            {
                context.Response.Redirect("/Evento/Index");
                return;
            }

            await _next(context);          
        }
    }
}
