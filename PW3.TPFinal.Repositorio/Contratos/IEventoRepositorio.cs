using PW3.TPFinal.Repositorio.Data;
using System.Collections.Generic;

namespace PW3.TPFinal.Repositorio.Contratos
{
    public interface IEventoRepositorio : IBaseRepositorio<Evento, int>
    {
        IList<Evento> ObtenerUltimosSeisConAlMenosUnComentario();

        IList<Evento> ObtenerDisponibles();
    }
}
