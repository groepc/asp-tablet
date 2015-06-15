using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using Plathe.Domain.AbstractServices;

namespace Plathe.WebUI.Controllers
{
    public class GenreController : Controller
    {
        private IMovieService movieService;
        
        public GenreController(IMovieService movieService)
        {
            this.movieService= movieService;
        }

       public ActionResult Browse()
       {       
           // Retrieve Genre and its assosiated movies from database
            var genreQuery = Request.QueryString["genreID"];
            return View(this.movieService.GetMoviesByGenreName(genreQuery));
        }

    }
}