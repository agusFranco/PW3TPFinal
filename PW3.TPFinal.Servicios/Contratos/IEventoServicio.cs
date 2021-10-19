using System.Collections.Generic;
using PW3.TPFinal.Dominio;

namespace PW3.TPFinal.Servicios.Contratos
{
    public interface IEventoServicio
    {
        IList<Evento> ObtenerTodos();

        IList<Evento> ObtenerUltimosSeisConAlMenosUnComentario();
    }
}
