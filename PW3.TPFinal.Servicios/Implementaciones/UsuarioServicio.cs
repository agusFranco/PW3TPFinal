using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Modelos;
using PW3.TPFinal.Dominio;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Servicios.Contratos;

namespace PW3.TPFinal.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio UsuarioRepositorio;
        private readonly ILogger<UsuarioServicio> Logger;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio, ILogger<UsuarioServicio> logger)
        {
            this.UsuarioRepositorio = usuarioRepositorio;
            this.Logger = logger;
        }

        public IList<Usuario> ObtenerTodos()
        {
            return this.UsuarioRepositorio.Obtener().ToList();
        }

        public Usuario Registrar(RegistrarUsuarioModel modelo)
        {
            try
            {
                Usuario nuevo = new Usuario();

                nuevo.Nombre = modelo.Nombre;
                nuevo.Email = modelo.Email;
                nuevo.Password = modelo.Password;       
                nuevo.Perfil = modelo.Perfil ?? 1;
                nuevo.FechaRegistracion = DateTime.UtcNow;

                this.UsuarioRepositorio.Agregar(nuevo);
                this.UsuarioRepositorio.Guardar();
                return nuevo;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Ocurrio un error, {ex.Message}");
                return null;
            }
        }
    }
}
