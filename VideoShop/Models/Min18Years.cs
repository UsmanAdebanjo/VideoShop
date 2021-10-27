using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoShop.Models
{
    public class Min18Years:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            var customer = (Customer)validationContext.ObjectInstance;
            
            if (customer.Birtdate == null || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            var age = DateTime.Today.Year - customer.Birtdate.Value.Year;

            if (age > 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Customer must be at least 18years old to go on a membership");
            }
        }
    }
}