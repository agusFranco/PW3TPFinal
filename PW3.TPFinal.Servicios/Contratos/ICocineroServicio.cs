using System.Collections.Generic;
using PW3.TPFinal.Comun.Modelos;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Servicios.Contratos
{
    public interface ICocineroServicio
    {
        Resultado<Receta> AgregarReceta(AgregarRecetaModel modelo);

        List<TipoReceta> ObtenerTiposDeReceta();
    }
}
