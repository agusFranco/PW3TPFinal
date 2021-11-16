using System.Collections.Generic;
using PW3.TPFinal.Negocio.Modelos.Data;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Servicios.Contratos
{
    public interface IEventoServicio
    {
        IList<EventoModel> ObtenerUltimosSeisConAlMenosUnComentario();
    }
}
