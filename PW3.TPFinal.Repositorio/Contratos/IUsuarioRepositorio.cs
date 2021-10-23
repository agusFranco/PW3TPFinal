using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Repositorio.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario, int>
    {
        Usuario ObtenerPorEmail(string email);
        Usuario ValidarUsuario(string email, string password);
    }
}
