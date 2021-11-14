using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class RecetaRepositorio : BaseRepositorio<Receta, int>, IRecetaRepositorio
    {
        public RecetaRepositorio(_20212C_TPContext context) : base(context)
        {
        }

        public IList<Receta> ObtenerPorIdCocinero(int idCocinero)
        {
            return this.Set.Include("IdTipoRecetaNavigation")
                .Where(x => x.IdCocinero == idCocinero).ToList();
        }
    }
}
