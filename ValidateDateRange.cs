using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment
{
    public class ValidateDateRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // your validation logic
            if (Convert.ToDateTime( value) >= Convert.ToDateTime("01/01/2019") && Convert.ToDateTime( value ) <= Convert.ToDateTime("30/06/2019"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date must be between 01/01/2019 and 30/06/2019.");
            }
        }
    }
}
