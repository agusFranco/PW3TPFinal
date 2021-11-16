using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Repositorio.Data;
using System.Collections.Generic;

namespace PW3.TPFinal.Negocio.Servicios.Contratos
{
    public interface IComensalServicio
    {
        List<Reserva> ObtenerReservas(int idUsuario);

        IList<Evento> ObtenerEventosDisponibles();

        Resultado<Reserva> AgregarReserva(AgregarReservaModel modelo);
    }
}
