using PW3.TPFinal.Web.Models;
using System.Collections.Generic;

namespace PW3.TPFinal.Servicios.Contratos
{
    public interface IEventoServicio
    {
        IList<Evento> ObtenerTodos();
        IList<Evento> ObtenerUltimosSeisConAlMenosUnComentario();
    }
}
