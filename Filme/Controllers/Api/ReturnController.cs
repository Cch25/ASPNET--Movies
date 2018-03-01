using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Filme.Core;
using Filme.Core.Models;


namespace Filme.Controllers.Api
{
    public class ReturnController : ApiController
    {

        private readonly IUnitOfWork _unitOfWork;

        public ReturnController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IEnumerable<Rental> GetCustomers(string query = null)
        {

            var customerRent = _unitOfWork.Rentals.GetAllRentals(true);
            return customerRent;
        }

        [HttpPost]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cust = _unitOfWork.Rentals.RemoveMovieFromClient(id);
            if (cust == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var movieToDelete = cust.Movie.Id;
            var movie = _unitOfWork.Movies.SingleOrDefault(m => m.Id == movieToDelete);
            movie.AvailableInStock++;

            _unitOfWork.Rentals.Remove(cust);

            _unitOfWork.Complete();
        }

    }
}