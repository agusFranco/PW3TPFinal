using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class RecetaRepositorio : BaseRepositorio<Receta, int>, IRecetaRepositorio
    {
        public RecetaRepositorio(_20212C_TPContext context) : base(context)
        {
        }
    }
}
