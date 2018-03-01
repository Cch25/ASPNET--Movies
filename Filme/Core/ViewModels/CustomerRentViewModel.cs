using System.Collections.Generic;
using Filme.Core.Models;

namespace Filme.Core.ViewModels
{
    public class CustomerRentViewModel
    {
        public IEnumerable<Rental> Customers { get; set; }
        public int MoviesCount { get; set; }
    }
}