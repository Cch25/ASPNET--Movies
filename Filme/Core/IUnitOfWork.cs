using Filme.Core.Repositories;

namespace Filme.Core
{
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }
        IGenreRepository Genres { get; }
        IRentalsRepository Rentals { get; }
        ICustomerRepository Customers { get; }
        void Complete();
    }
}
