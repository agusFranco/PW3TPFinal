using System.ComponentModel.DataAnnotations;

namespace PW3.TPFinal.Negocio.Modelos
{
    public class ComentarModel
    {
        [Required(ErrorMessage = "La Calificacion es requerida.")]
        [Range(1, 5, ErrorMessage = "La Calificacion minima es 1 y Maxima es 5")]
        public int Calificacion { get; set; }

        [Required(ErrorMessage = "El Comentario es requerido.")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Evento.")]
        public int IdEvento { get; set; }

        public int IdUsuario { get; set; }
    }
}
