using System.Collections.Generic;
using PW3.TPFinal.Comun.Modelos;
using PW3.TPFinal.Dominio;

namespace PW3.TPFinal.Servicios.Contratos
{
    public interface IUsuarioServicio
    {
        IList<Usuario> ObtenerTodos();

        Usuario Registrar(RegistrarUsuarioModel modelo);
    }
}
