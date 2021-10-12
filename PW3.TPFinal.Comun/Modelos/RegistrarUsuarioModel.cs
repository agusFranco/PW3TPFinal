using System.ComponentModel.DataAnnotations;

namespace PW3.TPFinal.Comun.Modelos
{
    public class RegistrarUsuarioModel
    {
        [Required(ErrorMessage = "Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Email es requerido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password es requerido.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmar Password es requerido.")]
        public string ConfirmarPassword { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido.")]
        public int? Perfil { get; set; }
    }
}
