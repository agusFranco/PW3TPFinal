using PW3.TPFinal.Repositorio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW3.TPFinal.Repositorio.Contratos
{
    public interface IReservaRepositorio : IBaseRepositorio<Reserva, int>
    {
        IList<Reserva> ObtenerReservas(int idUsuario);
    }
}
