using System.Collections.Generic;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Modelos
{
    public class AgregarReservaModel
    {
        public int CantidadComensales { get; set; }

        public int IdReceta { get; set; }

        public IList<Evento> Eventos { get; set; }
    }
}
