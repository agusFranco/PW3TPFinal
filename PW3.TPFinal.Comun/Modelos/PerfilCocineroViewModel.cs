using PW3.TPFinal.Repositorio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW3.TPFinal.Comun.Modelos
{
    public class PerfilCocineroViewModel
    {
        public Usuario Cocinero { get; set; }
        public IList<Receta> Recetas { get; set; }
        public IList<Evento> Eventos { get; set; }
    }
}
