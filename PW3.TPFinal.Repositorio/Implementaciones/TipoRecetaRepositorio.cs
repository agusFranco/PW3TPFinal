using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class TipoRecetaRepositorio : BaseRepositorio<TipoReceta, int>, ITipoRecetaRepositorio
    {
        public TipoRecetaRepositorio(_20212C_TPContext context) : base(context)
        {
        }
    }
}
