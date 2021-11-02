using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class ReservaRepositorio : BaseRepositorio<Reserva, int>, IReservaRepositorio
    {
        public ReservaRepositorio(_20212C_TPContext context) : base(context)
        {
        }

        public IList<Reserva> ObtenerReservas(int idUsuario)
        {
            var reservas = this.Set.Where(x => x.IdComensal == idUsuario).ToList();
            return reservas;
        }
    }
}
