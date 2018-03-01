using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Filme.Core;
using Filme.Core.Dtos;
using Filme.Core.Models;

namespace Filme.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentalsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //put api/rentals
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            var customer = _unitOfWork.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);

            if (rentalDto.MovieId.Count <= 0)
                return BadRequest("No movie id's have been given.");

            if (customer == null)
                return BadRequest("No customer found.");

            var movies = _unitOfWork.Movies.GetAll().Where(m => rentalDto.MovieId.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MovieId.Count)
                return BadRequest("One or more movies id's are not valid.");

            foreach (var movie in movies)
            {
                if (movie.AvailableInStock == 0)
                    return BadRequest("Movie is not available");

                movie.AvailableInStock--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _unitOfWork.Rentals.Add(rental);
            }
            _unitOfWork.Complete();
            return Ok();
        }

        public IEnumerable<Rental> GetRentals()
        {
            var rentals = _unitOfWork.Rentals.GetAll();
            return rentals;
        }
    }
}
