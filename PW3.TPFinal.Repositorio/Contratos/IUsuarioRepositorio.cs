using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Repositorio.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario, int>
    {
        Usuario ObtenerPorEmail(string email);
        bool ValidarUsuario(string email, string password);
    }
}
