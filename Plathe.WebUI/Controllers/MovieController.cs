using Plathe.Domain.Abstract;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;
using Plathe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Plathe.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository repository;
        
        // GET: Movie
        public MovieController(IMovieRepository movieRepository)
        {
            this.repository = movieRepository;
        }

       public ViewResult Index()
        {
            return View(repository.Movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Movie movie = db.Movies.Find(id);
            Movie movie = repository.Movies.First(s => s.MovieID == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

    }
}