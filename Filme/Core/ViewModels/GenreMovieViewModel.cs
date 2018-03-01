using System.Collections.Generic;
using Filme.Core.Models;

namespace Filme.Core.ViewModels
{
    public class GenreMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movies { get; set; }

        public string Title
        {
            get
            {
                if (Movies != null && Movies.Id != 0)
                    return "Edit movie";
                return "New movie";
            }
        }
     }
}