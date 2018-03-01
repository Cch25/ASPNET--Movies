using System;
using System.ComponentModel.DataAnnotations;

namespace Filme.Core.Models
{
    public class Rental
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date rented")]
        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        public Customer Customer { get; set; }

        public Movie Movie { get; set; }

    }
}