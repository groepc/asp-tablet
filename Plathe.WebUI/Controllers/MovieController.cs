using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;
using Plathe.UnitTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Plathe.UnitTest.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService movieService;
        private IShowService showService;
        
        // GET: Movie
        public MovieController(IMovieService movieService, IShowService showService)
        {
            this.movieService = movieService;
            this.showService = showService;
        }

        public ViewResult Index()
        {
            return View(this.movieService.GetAllMovies().ToList());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // get current movie
            Movie movie = this.movieService.GetMovieById((int) id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            // get shows for this movie
            IEnumerable<Show> shows = this.showService.GetShowsByMovieId((int) id).ToList();

            MovieDetailViewModel viewModel = new MovieDetailViewModel
            {
                movie = movie,
                showsForMovie = shows
            };
            
            return View(viewModel);
        }
    }
}