using Filme.Core.Models;
using Filme.Core.Repositories;

namespace Filme.Persistence.Repositories
{
    public class GenreRepository : Repository<Genre>,IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}