using System.Collections.Generic;

namespace Filme.Core.Dtos
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieId { get; set; }
    }
}