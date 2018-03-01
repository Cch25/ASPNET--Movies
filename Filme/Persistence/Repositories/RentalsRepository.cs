using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Filme.Core.Models;
using Filme.Core.Repositories;

namespace Filme.Persistence.Repositories
{
    public class RentalsRepository : Repository<Rental>, IRentalsRepository
    {
        public RentalsRepository(ApplicationDbContext context) : base(context)
        {
        }
        public IEnumerable<Rental> RentsByCustomer(int id)
        {
            return _context.Rentals.Include(m => m.Movie)
                .Include(c => c.Customer).Where(c => c.Customer.Id == id).ToList();
        }
        public IEnumerable<Rental> GetCustomersRents()
        {
            return _context.Rentals.Include(m => m.Movie)
                .Include(c => c.Customer).Distinct().ToList();
        }

        public IEnumerable<Rental> GetAllRentals(bool includeRelated = false)
        {
            if (!includeRelated)
                return _context.Rentals.ToList();
            return _context.Rentals.Include(c => c.Customer)
                .Include(m => m.Movie).ToList();
        }

        public Rental RemoveMovieFromClient(int id)
        {
            return _context.Rentals.Include(c => c.Customer)
                .Include(m => m.Movie)
                .FirstOrDefault(c => c.Customer.Id == id);
        }
    }
}