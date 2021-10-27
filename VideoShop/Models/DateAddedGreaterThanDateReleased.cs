using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoShop.Models
{
    public class DateAddedGreaterThanDateReleased:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.DateAdded > movie.DateReleased)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date Added must be later(greaterthan) date released");
            }
            
        }
    }
}