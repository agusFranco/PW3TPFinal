using System.ComponentModel.DataAnnotations;
using PW3.TPFinal.Dominio;

namespace PW3.TPFinal.Comun.Modelos
{
    public class RegistrarUsuarioModel
    {
        [Required(ErrorMessage = "Nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El Nombre no debe superar los 50 caracteres.", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Email es requerido.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "El Email debe ser valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password es requerido.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "El Password debe tener al menos una letra y al menos un numero.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmar Password es requerido.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Los Password deben coincidir.")]
        public string ConfirmarPassword { get; set; }

        [Required(ErrorMessage = "El Perfil es requerido.")]
        public TipoUsuario Perfil { get; set; }
    }
}
