using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Filme.Core;
using Filme.Core.Dtos;
using Filme.Core.Models;

namespace Filme.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //get api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var moviesQuery = _unitOfWork.Movies.GetMoviesAvailableInStock();

            if (!string.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }
            var movies = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MoviesDto>);
            return Ok(movies);
        }

        //get api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movie = _unitOfWork.Movies.SingleOrDefault(m => m.Id == id);
            return Ok(Mapper.Map<Movie, MoviesDto>(movie));
        }

        //post api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movie = Mapper.Map<MoviesDto, Movie>(movieDto);
            _unitOfWork.Movies.Add(movie);
            _unitOfWork.Complete();
            movie.Id = movieDto.Id;
            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movie);

        }

        //put api/movie/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _unitOfWork.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);
            _unitOfWork.Complete();
            return Ok();
        }

        //delete api/movie/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                BadRequest("No movie found");
            var movie = _unitOfWork.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                BadRequest("No movie found");
            _unitOfWork.Movies.Remove(movie);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
