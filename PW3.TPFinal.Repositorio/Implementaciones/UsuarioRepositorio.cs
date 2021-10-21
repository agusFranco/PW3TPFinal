using System.Linq;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario, int>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(_20212C_TPContext context) : base(context)
        {
        }

        public Usuario ObtenerPorEmail(string email)
        {
            var emailLower = email.ToLowerInvariant();

            return this.Set.Where(x => x.Email.Equals(emailLower))
                           .FirstOrDefault();
        }
    }
}
