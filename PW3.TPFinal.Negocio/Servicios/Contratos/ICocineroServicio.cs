using System.Collections.Generic;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Servicios.Contratos
{
    public interface ICocineroServicio
    {
        Resultado<Receta> AgregarReceta(AgregarRecetaModel modelo);

        Resultado<Evento> AgregarEvento(AgregarEventoModel modelo);

        List<TipoReceta> ObtenerTiposDeReceta();

        List<Receta> ObtenerRecetasPorIdCocinero(int idCocinero);

        Usuario ObtenerDatosDelCocinero(int idCocinero);

        IList<Evento> ObtenerEventosPorIdCocinero(int idCocinero);
    }
}
