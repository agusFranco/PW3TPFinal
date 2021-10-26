using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PW3.TPFinal.Comun.Modelos
{
    public class AgregarRecetaModel
    {       
        [Required]
        public int IdCocinero { get; set; }

        [Required(ErrorMessage = "Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion es requerido.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingredientes es requerido.")]
        public string Ingredientes { get; set; }

        [Required(ErrorMessage = "Tiempo de Coccion es requerido.")]
        public int TiempoDeCoccion { get; set; }

        [Required(ErrorMessage = "El Tipo es requerido.")]
        public int IdTipoReceta { get; set; }

        public List<SelectListItem> TipoRecetas { get; set; }
    }
}
