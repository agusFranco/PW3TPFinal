using PW3.TPFinal.Dominio;

namespace PW3.TPFinal.Repositorio.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario, int>
    {
        Usuario ObtenerPorEmail(string email);
    }
}
