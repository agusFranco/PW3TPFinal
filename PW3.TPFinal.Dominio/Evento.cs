using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PW3.TPFinal.Web.Models
{
    public class Evento
    {
        public String Nombre { get; set; }
        public String Foto { get; set; }
        public Decimal Puntuacion { get; set; }
        public List<String> Comentarios { get; set; }
        public Cocinero cocinero { get; set; }
        public Double Precio { get; set; }

        public Evento(String Nombre, String Foto, List<String> Comentarios, Decimal Puntuacion, Double Precio)
        {
            this.Nombre = Nombre;
            this.Foto = Foto;
            this.Comentarios = Comentarios;
            this.Puntuacion = Puntuacion;
            this.Precio = Precio;
        }
    }
}
