using System.Linq;
using PW3.TPFinal.Dominio;
using PW3.TPFinal.Repositorio.Configuracion;
using PW3.TPFinal.Repositorio.Contratos;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario, int>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(TPFinalContext context) : base(context)
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
