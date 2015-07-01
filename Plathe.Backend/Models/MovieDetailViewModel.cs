using System.Collections.Generic;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Backend.Models
{
    public class MovieListViewModel
    {
        private readonly IMovieService _service;


        public MovieListViewModel()
        {
            _service = DependencyResolver.Current.GetService<IMovieService>();
        }
        public IEnumerable<Movie> Movies { get { return _service.GetAllMovies(); } }
    }
}