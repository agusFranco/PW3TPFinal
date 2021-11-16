using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PW3.TPFinal.Negocio.Modelos.Data;

namespace PW3.TPFinal.Negocio.Modelos
{
    public class AgregarReservaModel
    {
        [Required(ErrorMessage = "La Cantidad es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad minima es 1.")]
        public int CantidadComensales { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una Receta.")]
        public int IdReceta { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Evento.")]
        public int IdEvento { get; set; }

        public int IdComensal { get; set; }

        public IList<EventoRecetasModel> Eventos { get; set; }
    }
}
