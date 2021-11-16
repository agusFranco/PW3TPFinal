namespace PW3.TPFinal.Negocio.Modelos
{
    public class CancelarEventoModel
    {
        public int IdUsuario { get; set; }

        public int IdEvento { get; set; }

        public CancelarEventoModel(int idUsuario, int idEvento)
        {
            this.IdEvento = idEvento;
            this.IdUsuario = idUsuario;
        }
    }
}
