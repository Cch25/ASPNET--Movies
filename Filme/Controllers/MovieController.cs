using System;
using System.Web.Mvc;
using AutoMapper;
using Filme.Core;
using Filme.Core.ViewModels;

namespace Filme.Controllers
{
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ViewResult Index()
        {
            return View("List");
        }
        public ActionResult Details(int id)
        {
            var movie = _unitOfWork.Movies.GetMovieDetails(id);

            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }        
        public ActionResult Edit()
        {
            var genre = _unitOfWork.Movies.EditMovie();
            var viewModel = new GenreMovieViewModel
            {
                Genres = genre
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(GenreMovieViewModel movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new GenreMovieViewModel
                {
                    Movies = movie.Movies,
                    Genres = _unitOfWork.Genres.GetAll()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Movies.Id == 0)
            {
                movie.Movies.DateAdded = DateTime.Now;
                movie.Movies.AvailableInStock = movie.Movies.NumberInStock;
                _unitOfWork.Movies.Add(movie.Movies);
            }
            else
            {
                var movieInDb = _unitOfWork.Movies.GetMovie(movie.Movies.Id);
                Mapper.Map(movie,movieInDb);
            }
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Update(int id)
        {
            var movie = _unitOfWork.Movies.UpdateMovie(id);
            if (movie == null)
                HttpNotFound();
            var viewModel = new GenreMovieViewModel
            {
                Movies = movie,
                Genres = _unitOfWork.Genres.GetAll()
            };
            return View("MovieForm", viewModel);
        }
    }
}