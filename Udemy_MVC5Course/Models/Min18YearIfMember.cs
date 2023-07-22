using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Udemy_MVC5Course.Models
{
    public class Min18YearIfMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipId==0 || customer.MemberShipId == 1)
            {
                return ValidationResult.Success;
            }
            else if (customer.Birthdate == null)
            {
                return new ValidationResult("Birth Date Required");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult(" Customer Should be at list 18 year old go on a membership");




        }
    }
}