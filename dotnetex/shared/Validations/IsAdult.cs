using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetex.shared.Validations
{
    public class IsAdult : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

             DateTime date = (DateTime)value;
             if (DateTime.Now.Year - date.Year >= 18)
             {
                 return ValidationResult.Success;
             }
            
            else
            {
               return new ValidationResult("Not a number.");

            }

        }
    }
}
