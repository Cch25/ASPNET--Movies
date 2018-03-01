using System.Collections.Generic;
using Filme.Core.Models;

namespace Filme.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Genre> EditMovie();
        Movie GetMovieDetails(int id);
        Movie UpdateMovie(int id);
        Movie GetMovie(int id);
        IEnumerable<Movie> GetMoviesAvailableInStock();
    }
}