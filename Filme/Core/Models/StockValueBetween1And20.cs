using System.ComponentModel.DataAnnotations;

namespace Filme.Core.Models
{
    public class StockValueBetween1And20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie == null)
                return new ValidationResult("You need to provide a number in stock.");

            return (movie.NumberInStock > 0 && movie.NumberInStock < 21) 
                ? ValidationResult.Success 
                : new ValidationResult("The number in stock must be between 1 and 20");

        }
    }
}