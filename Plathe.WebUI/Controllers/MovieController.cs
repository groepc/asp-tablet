using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository repository;
        // GET: Movie
        public MovieController (IMovieRepository movieRepository)
        {
            this.repository = movieRepository;
        }

        public ViewResult List()
        {
            return View(repository.Movies);
        }
    }
}