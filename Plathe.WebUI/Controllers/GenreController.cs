using Plathe.Domain.Abstract;
using Plathe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.WebUI.Controllers
{
    public class GenreController : Controller
    {
        private IGenreRepository repository;
        //
        // GET: /Genre/
        public GenreController(IGenreRepository genreRepository)
        {
            this.repository = genreRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List(string genre)
        {
            GenreViewModel model = new GenreViewModel
            {

                Genres = repository.Genres
                    .Where(p => genre == null || p.Name == genre)
                    .OrderBy(p => p.Name),

                CurrentGenre = genre
            };

            return View(model);
        }
    }
}