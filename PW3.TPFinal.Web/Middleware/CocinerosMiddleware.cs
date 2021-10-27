using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Web.Extensiones;

namespace PW3.TPFinal.Web.Middleware
{
    public class CocinerosMiddleware
    {
        private readonly RequestDelegate _next;

        public CocinerosMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context, ILogger<CocinerosMiddleware> logger)
        {
            if (!context.Session.ExisteUsuario())
            {
                context.Response.Redirect("/Usuario/Ingresar");
                return;
            }

            if (!context.Session.EsComensal())
            {
                context.Response.Redirect("/Cocinero/Perfil");
                return;
            }

            await _next(context);          
        }
    }
}
