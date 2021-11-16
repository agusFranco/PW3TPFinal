using System.Collections.Generic;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Negocio.Modelos.Data;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Servicios.Contratos
{
    public interface IEventoServicio
    {
        IList<EventoModel> ObtenerUltimosSeisConAlMenosUnComentario();

        Evento ObtenerPorId(int id);

        Resultado Cancelar(CancelarEventoModel modelo);
    }
}
