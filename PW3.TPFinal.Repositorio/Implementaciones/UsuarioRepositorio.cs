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
    }
}
