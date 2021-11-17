using System;
using System.ComponentModel.DataAnnotations;

namespace PW3.TPFinal.Comun.Validaciones
{
    public class FechaMayorAHoyAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => $"La fecha ingresada es invalida.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime && ((DateTime)value).Date > DateTime.Today.Date)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage());
        }
    }
}
