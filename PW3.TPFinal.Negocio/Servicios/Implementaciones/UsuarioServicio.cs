
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PW3.TPFinal.Comun.Configuracion;
using PW3.TPFinal.Comun.Resultado;
using PW3.TPFinal.Negocio.Modelos;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;
using BCryptNet = BCrypt.Net.BCrypt;

namespace PW3.TPFinal.Negocio.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio UsuarioRepositorio;
        private readonly ILogger<UsuarioServicio> Logger;
        private readonly JWTConfiguracion JWTConfiguracion;

        public UsuarioServicio(
            IOptions<JWTConfiguracion> jwtConfiguracion,
            IUsuarioRepositorio usuarioRepositorio,
            ILogger<UsuarioServicio> logger)
        {
            this.UsuarioRepositorio = usuarioRepositorio;
            this.Logger = logger;
            this.JWTConfiguracion = jwtConfiguracion.Value;
        }

        public IList<Usuario> ObtenerTodos()
        {
            return this.UsuarioRepositorio.Obtener().ToList();
        }

        public Resultado<IngresoAutorizadoModel> Registrar(RegistrarUsuarioModel modelo)
        {
            var resultado = new Resultado<IngresoAutorizadoModel>();

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
                nuevo.Password = BCryptNet.HashPassword(modelo.Password);
                nuevo.Perfil = (int)modelo.Perfil;
                nuevo.FechaRegistracion = DateTime.UtcNow;

                this.UsuarioRepositorio.Agregar(nuevo);
                this.UsuarioRepositorio.Guardar();

                return this.GenerarTicketDeIngreso(nuevo);
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Ocurrio un error. Ex.Mensaje = {ex.Message}");
                resultado.Success = false;
                resultado.Mensaje = "Ocurrio un error al guardar el usuario. Intente Nuevamente.";
                return resultado;
            }
        }

        public Resultado<IngresoAutorizadoModel> ValidarUsuario(IngresarUsuarioModel modelo)
        {
            var resultado = new Resultado<IngresoAutorizadoModel>();

            Usuario usuario = this.UsuarioRepositorio.ObtenerPorEmail(modelo.Email);

            if (usuario == null || !BCryptNet.Verify(modelo.Password, usuario.Password))
            {
                resultado.Success = false;
                resultado.Mensaje = "Usuario o Contraseña invalidos.";
                return resultado;
            }               

            return this.GenerarTicketDeIngreso(usuario);
        }

        public Resultado<IngresoAutorizadoModel> GenerarTicketDeIngreso(Usuario usuario)
        {
            var resultado = new Resultado<IngresoAutorizadoModel>();

            try
            {
                var iat = new DateTimeOffset(DateTime.UtcNow).ToUniversalTime().ToUnixTimeSeconds().ToString();
                var expirationDays = TimeSpan.FromDays(this.JWTConfiguracion.ExpirationDays);

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Task.FromResult(Guid.NewGuid().ToString()).Result),
                    new Claim(JwtRegisteredClaimNames.Iat, iat, ClaimValueTypes.Integer64),
                    new Claim(JwtRegisteredClaimNames.Sid, usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email)
                };

                var jwtSecurityToken = new JwtSecurityToken(
                                            issuer: this.JWTConfiguracion.Issuer,
                                            audience: this.JWTConfiguracion.Audience,
                                            claims: claims,
                                            expires: DateTime.Now.AddDays(10),
                                            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.JWTConfiguracion.SecretKey)), SecurityAlgorithms.HmacSha256)
                                        );

                var encodedJWTSecurityToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                resultado.Success = true;
                resultado.Dato = new IngresoAutorizadoModel()
                {
                    Ticket = encodedJWTSecurityToken,
                    Expiracion = (int)expirationDays.TotalSeconds,
                    Usuario = usuario
                };
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Success = false;
                resultado.Mensaje = "Hubo un problema al generar el ticket";
                return resultado;
            }
        }
    }
}
