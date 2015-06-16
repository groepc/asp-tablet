using System.Collections.Generic;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Models
{
    public class MovieDetailViewModel
    {
        private IMovieService service;


        public MovieDetailViewModel()
        {
            service = DependencyResolver.Current.GetService<IMovieService>();
        }

        public Movie Movie { get; set; }
        public IEnumerable<Movie> Movies { get { return service.GetAllMovies(); } }
        public IEnumerable<Show> ShowsForMovie { get; set; }
    }
}