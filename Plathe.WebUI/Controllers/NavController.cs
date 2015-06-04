using Plathe.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IGenreRepository repository;

        public NavController(IGenreRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> genres = repository.Genres
                                .Select(x => x.Name)
                                .Distinct()
                                .OrderBy(x => x);

            return PartialView(genres);
        }
    }
}