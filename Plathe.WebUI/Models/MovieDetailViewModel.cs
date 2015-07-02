using System.Collections.Generic;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Models
{
    public class MovieDetailViewModel
    {
        private IMovieService _service;

        public MovieDetailViewModel()
        {
            _service = DependencyResolver.Current.GetService<IMovieService>();
        }

        public Movie Movie { get; set; }
        public IEnumerable<Movie> Movies { get { return _service.GetAllMovies(); } }
        public IEnumerable<Show> ShowsForMovie { get; set; }
    }
}