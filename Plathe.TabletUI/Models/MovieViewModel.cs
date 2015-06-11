using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;

namespace Plathe.TabletUI.Models
{
    public class MovieViewModel
    {

        private IMovieService service;


        public MovieViewModel()
        {
            this.service = DependencyResolver.Current.GetService<IMovieService>();
        }

        public IEnumerable<Movie> Movies
        {
            get { return service.getAllMovies(); }
        }
        public Movie Movie
        {
            get { return service.getMovieById(MovieId); }
        }
        [HiddenInput(DisplayValue = false)]
        public int MovieId { get; set; }
    }
}