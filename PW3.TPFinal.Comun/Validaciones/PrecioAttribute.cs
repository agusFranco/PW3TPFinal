using System.ComponentModel.DataAnnotations;

namespace PW3.TPFinal.Comun.Validaciones
{
    public class PrecioAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => $"El Precio es invalido.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is decimal && (decimal)value > 0.00M)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage());
        }
    }
}
