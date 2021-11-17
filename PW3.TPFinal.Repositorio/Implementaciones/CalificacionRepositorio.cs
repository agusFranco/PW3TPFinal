using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class CalificacionRepositorio : BaseRepositorio<Calificacione, int>, ICalificacionRepositorio
    {
        public CalificacionRepositorio(_20212C_TPContext context) : base(context)
        {
        }
    }
}
