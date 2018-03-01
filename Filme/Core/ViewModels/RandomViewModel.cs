using System.Collections.Generic;
using Filme.Core.Models;

namespace Filme.Core.ViewModels
{
    public class RandomViewModel
    {
        public List<Customer> Customers{ get; set; }
        public Movie Movies { get; set; }
    }
}