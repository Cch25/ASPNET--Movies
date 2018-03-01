using System;
using System.ComponentModel.DataAnnotations;

namespace Filme.Core.Models
{
    public class Is18YearsOldOrMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unkown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Please enter your birthdate.");
            var age = DateTime.Now.Year - customer.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("You need to be at least 18 years old");

        }
    }
}