using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Plathe.Domain.Abstract;

//Author: Mieke

namespace Plathe.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IGenreRepository _repository;

        public NavController(IGenreRepository repo)
        {
            _repository = repo;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> genres = _repository.Genres
                                .Select(x => x.Name)
                                .Distinct()
                                .OrderBy(x => x);

            return PartialView(genres);
        }
    }
}