using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetex.shared.Validations
{
    public class IsAdult : ValidationAttribute
    {
        private string error_message { get; set; } = "Should be older than 18";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (ErrorMessage != null)
            {
                error_message = ErrorMessageString;
            }

            DateTime date = (DateTime)value;
            if (DateTime.Now.Year - date.Year >= 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(error_message);
            }

        }
    }
}
