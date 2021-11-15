using System.Collections.Generic;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Modelos
{
    public class PerfilCocineroViewModel
    {
        public Usuario Cocinero { get; set; }
        public IList<Receta> Recetas { get; set; }
        public IList<Evento> Eventos { get; set; }
    }
}
