using System.ComponentModel.DataAnnotations;

namespace PW3.TPFinal.Comun.Validaciones
{
    public class PrecioAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => $"El Precio es invalido.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {           
            if (!decimal.TryParse(value as string, out decimal result) || result <= 0)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
