using System;
using System.ComponentModel.DataAnnotations;

namespace Filme.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name="Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        //[StockValueBetween1And20]
        [Display(Name="Number in stock")]
        public byte NumberInStock { get; set; }

        [Required]
        [Display(Name = "Available in stock")]
        public byte AvailableInStock { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }
    }
}