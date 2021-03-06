﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.WebUI.Models;

namespace Plathe.WebUI.Controllers
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
            MovieDetailViewModel model = new MovieDetailViewModel();
            return View(model);
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
                Movie = movie,
                ShowsForMovie = shows
            };
            
            return View(viewModel);
        }

    }
}