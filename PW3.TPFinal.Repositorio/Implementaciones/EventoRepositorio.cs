using PW3.TPFinal.Dominio;
using PW3.TPFinal.Repositorio.Configuracion;
using PW3.TPFinal.Repositorio.Contratos;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class EventoRepositorio : BaseRepositorio<Evento, int>, IEventoRepositorio
    {
        public EventoRepositorio(TPFinalContext context) : base(context)
        {
        }
    }
}
