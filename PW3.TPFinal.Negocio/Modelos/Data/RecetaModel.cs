using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Modelos.Data
{
    public class RecetaModel
    {
        public RecetaModel()
        {
        }

        public RecetaModel(Receta receta)
        {
            this.IdReceta = receta.IdReceta;
            this.Nombre = receta.Nombre;
        }

        public int IdReceta { get; set; }

        public string Nombre { get; set; }
    }
}
