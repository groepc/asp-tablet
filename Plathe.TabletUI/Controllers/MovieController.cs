using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;
using System.Collections.Specialized;
using Plathe.TabletUI.Models;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;

namespace Plathe.TabletUI.Controllers
{
    public class MovieController : Controller
    {
        //private EFDbContext db = new EFDbContext();
        private IMovieService movieService;


        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        // GET: Shows
        public ViewResult List()
        {
            MovieViewModel model = new MovieViewModel { };
            return View(model);
        }
        /*
        public ViewResult Details(int id)
        {
            var movie = repository.Movies.FirstOrDefault(m => m.MovieID == id);

            return View(movie);
        }*/
    }
}