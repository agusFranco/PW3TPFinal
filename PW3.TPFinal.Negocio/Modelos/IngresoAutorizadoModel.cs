using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Modelos
{
    public class IngresoAutorizadoModel
    {
        public string Ticket { get; set; }

        public Usuario Usuario { get; set; }

        public int Expiracion { get; set; }
    }
}
