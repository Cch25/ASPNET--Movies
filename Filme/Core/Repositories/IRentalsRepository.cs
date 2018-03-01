using System.Collections.Generic;
using Filme.Core.Models;

namespace Filme.Core.Repositories
{
    public interface IRentalsRepository : IRepository<Rental>
    {
        IEnumerable<Rental> RentsByCustomer(int id);
        IEnumerable<Rental> GetCustomersRents();
        IEnumerable<Rental> GetAllRentals(bool includeRelated = false);
        Rental RemoveMovieFromClient(int id);
    }
}