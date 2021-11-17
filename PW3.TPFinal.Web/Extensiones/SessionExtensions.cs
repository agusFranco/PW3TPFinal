using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PW3.TPFinal.Comun.Constantes;
using PW3.TPFinal.Comun.Enums;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Web.Extensiones
{
    public static class SessionExtensions
    {
        public static void Set(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Obtener<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetUsuario(this ISession session, Usuario usuario)
        {
            session.Set(Constantes.SESSION_USUARIO, usuario);
            session.SetInt32(Constantes.SESSION_EXISTE_USUARIO, Convert.ToInt32(true));
            session.SetInt32(Constantes.SESSION_PERFIL, usuario.Perfil);
        }

        public static bool ExisteUsuario(this ISession session)
        {
            var existeUsuario = session.GetInt32(Constantes.SESSION_EXISTE_USUARIO);
            return Convert.ToBoolean(existeUsuario);
        }

        public static Usuario ObtenerUsuario(this ISession session)
        {
            return session.Obtener<Usuario>(Constantes.SESSION_USUARIO);
        }

        public static TipoUsuario ObtenerPerfil(this ISession session)
        {
            var perfil = session.GetInt32(Constantes.SESSION_PERFIL);

            return perfil != null ? (TipoUsuario)perfil : TipoUsuario.Desconocido;
        }

        public static bool EsComensal(this ISession session)
        {
            var perfil = session.ObtenerPerfil();

            return (TipoUsuario)perfil == TipoUsuario.Comensal;
        }

        public static bool EsCocinero(this ISession session)
        {
            var perfil = session.ObtenerPerfil();

            return (TipoUsuario)perfil == TipoUsuario.Cocinero;
        }

        public static int ObtenerIdUsuario(this ISession session)
        {            
            return ObtenerUsuario(session).IdUsuario;            
        }
    }
}
