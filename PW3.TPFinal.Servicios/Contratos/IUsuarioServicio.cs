using System.Collections.Generic;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Repositorio.Modelos;

namespace PW3.TPFinal.Servicios.Contratos
{
    public interface IUsuarioServicio
    {
        IList<Usuario> ObtenerTodos();

        Resultado<Usuario> Registrar(RegistrarUsuarioModel modelo);

        Usuario ValidarUsuario(IngresarUsuarioModel modelo);
    }
}
