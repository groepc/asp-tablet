using System.Collections.Generic;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.TabletUI.Models
{
    public class MovieViewModel
    {

        private IMovieService service;


        public MovieViewModel()
        {
            service = DependencyResolver.Current.GetService<IMovieService>();
        }

        public IEnumerable<Movie> Movies
        {
            get { return service.GetAllMovies(); }
        }
        public Movie Movie
        {
            get { return service.GetMovieById(MovieId); }
        }
        [HiddenInput(DisplayValue = false)]
        public int MovieId { get; set; }
    }
}