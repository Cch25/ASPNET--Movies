using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Filme.Core.Models;
using Filme.Core.Repositories;

namespace Filme.Persistence.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {

        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Movie GetMovieDetails(int id)
        {
            return _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
        }
        public IEnumerable<Genre> EditMovie()
        {
            return _context.Genres.ToList();
        }

        public Movie UpdateMovie(int id)
        {
            return _context.Movies.SingleOrDefault(m => m.Id == id);
        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.Single(m => m.Id == id);
        }

        public IEnumerable<Movie> GetMoviesAvailableInStock()
        {
            return _context.Movies
                .Include(g => g.Genre)
                .Where(m => m.AvailableInStock > 0);
        }
     
    }
}