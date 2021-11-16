using PW3.TPFinal.Repositorio.Data;
using System.Collections.Generic;

namespace PW3.TPFinal.Repositorio.Contratos
{
    public interface IEventoRepositorio : IBaseRepositorio<Evento, int>
    {
        Evento ObtenerCompletoPorId(int id);
        IList<Evento> ObtenerUltimosSeisConAlMenosUnComentario();
        IList<Evento> ObtenerPorIdCocinero(int idCocinero);
        IList<Evento> ObtenerDisponibles();
    }
}
