using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Servicios
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

        public Resultado<Usuario> Registrar(RegistrarUsuarioModel modelo)
        {
            var resultado = new Resultado<Usuario>();

            try
            {
                var existente = this.UsuarioRepositorio.ObtenerPorEmail(modelo.Email);

                if (existente != null)
                {
                    resultado.Success = false;
                    resultado.Mensaje = "El Email ya esta en uso.";
                    return resultado;
                }

                Usuario nuevo = new Usuario();

                nuevo.Nombre = modelo.Nombre;
                nuevo.Email = modelo.Email;
                nuevo.Password = modelo.Password;
                nuevo.Perfil = (int)modelo.Perfil;
                nuevo.FechaRegistracion = DateTime.UtcNow;

                this.UsuarioRepositorio.Agregar(nuevo);
                this.UsuarioRepositorio.Guardar();

                resultado.Success = true;
                resultado.Mensaje = $"Bienvenido {nuevo.Nombre}.";
                resultado.Dato = nuevo;
                return resultado;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Ocurrio un error. Ex.Mensaje = {ex.Message}");
                resultado.Success = false;
                resultado.Mensaje = "Ocurrio un error al guardar el usuario. Intente Nuevamente.";
                return resultado;
            }
        }

        public Usuario ValidarUsuario(IngresarUsuarioModel modelo)
        {
            return this.UsuarioRepositorio.ValidarUsuario(modelo.Email, modelo.Password);
        }
    }
}
