using System.Collections.Generic;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Servicios.Contratos
{
    public interface IUsuarioServicio
    {
        IList<Usuario> ObtenerTodos();

        Resultado<Usuario> Registrar(RegistrarUsuarioModel modelo);

        Usuario ValidarUsuario(IngresarUsuarioModel modelo);
    }
}
