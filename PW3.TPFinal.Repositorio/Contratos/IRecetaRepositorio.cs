using System.Collections.Generic;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Repositorio.Contratos
{
    public interface IRecetaRepositorio : IBaseRepositorio<Receta, int>
    {
        IList<Receta> ObtenerPorIdCocinero(int idCocinero);
    }
}
