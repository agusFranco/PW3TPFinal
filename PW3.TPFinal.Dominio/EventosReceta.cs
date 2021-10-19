using System;
using System.Collections.Generic;

#nullable disable

namespace PW3.TPFinal.Dominio
{
    public partial class EventosReceta
    {
        public int IdEventoReceta { get; set; }
        public int IdEvento { get; set; }
        public int IdReceta { get; set; }

        public virtual Evento IdEventoNavigation { get; set; }
        public virtual Receta IdRecetaNavigation { get; set; }
    }
}
