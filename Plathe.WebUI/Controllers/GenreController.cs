using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Controllers
{
    public class GenreController : Controller
    {

        private IGenreRepository repository;
        
        public GenreController(IGenreRepository genreRepository)
        {
            this.repository = genreRepository;
        }

       public ActionResult Browse(string Genre)
        {
            // Retrieve Genre and its assosiated movies from database
            var genreModel = repository.Genres.Single(g => g.Name == Genre);

            return View(repository.Genres);
        }

    }
}