using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PW3.TPFinal.Comun.Validaciones;

namespace PW3.TPFinal.Repositorio.Modelos
{
    public class AgregarEventoModel
    {

        [Required(ErrorMessage = "El Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Fecha es requerida.")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La Descripcion es requerida.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La Ubicacion es requerida.")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "La Cantidad es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad minima es 1.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Las Recetas Propuestas son requeridas.")]
        public int[] RecetasPropuestas { get; set; }

        [Required(ErrorMessage = "El Precio es requerido.")]
        [Precio]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La Foto es requerida.")]
        public IFormFile Foto { get; set; }

        public int IdCocinero { get; set; }

        public List<SelectListItem> Recetas { get; set; }
    }
}
