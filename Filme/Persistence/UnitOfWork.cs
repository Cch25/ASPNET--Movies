using Filme.Core;
using Filme.Core.Models;
using Filme.Core.Repositories;
using Filme.Persistence.Repositories;

namespace Filme.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IMovieRepository Movies { get; }
        public IGenreRepository Genres { get; }
        public IRentalsRepository Rentals { get; }
        public ICustomerRepository Customers { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
            Genres = new GenreRepository(_context);
            Rentals = new RentalsRepository(_context);
            Customers = new CustomerRepository(_context);
        }
        
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}