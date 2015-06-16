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

namespace Plathe.WebUI.Models
{
    public class MovieDetailViewModel
    {
        private IMovieService service;


        public MovieDetailViewModel()
        {
            this.service = DependencyResolver.Current.GetService<IMovieService>();
        }

        public Movie movie { get; set; }
        public IEnumerable<Movie> Movies { get { return service.GetAllMovies(); } }
        public IEnumerable<Show> showsForMovie { get; set; }
    }
}