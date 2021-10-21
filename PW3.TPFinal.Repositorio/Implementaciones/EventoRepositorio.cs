using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class EventoRepositorio : BaseRepositorio<Evento, int>, IEventoRepositorio
    {
        public EventoRepositorio(_20212C_TPContext context) : base(context)
        {
        }
    }
}
