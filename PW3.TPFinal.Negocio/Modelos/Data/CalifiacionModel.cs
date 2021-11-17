using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Modelos.Data
{
    public class CalificacionModel
    {
        public CalificacionModel()
        {
        }

        public CalificacionModel(Calificacione calificacion)
        {
            if (calificacion == null)
            {
                return;
            }

            this.IdCalificacion = calificacion.IdCalificacion;
            this.Calificacion = calificacion.Calificacion;
            this.Comentarios = calificacion.Comentarios;
            this.NombreComensal = calificacion.IdComensalNavigation?.Nombre;
        }

        public int IdCalificacion { get; set; }

        public string NombreComensal { get; set; }

        public int Calificacion { get; set; }

        public string Comentarios { get; set; }
    }
}
