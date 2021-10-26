using Microsoft.Extensions.Logging;
using PW3.TPFinal.Servicios.Contratos;

namespace PW3.TPFinal.Servicios
{
    public class ComensalServicio : IComensalServicio
    {
        private readonly ILogger<ComensalServicio> Logger;

        public ComensalServicio(ILogger<ComensalServicio> logger)
        {  
            this.Logger = logger;
        }
    }
}
