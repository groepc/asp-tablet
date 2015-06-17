using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.TabletUI.Models;

namespace Plathe.TabletUI.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movies
        public ViewResult List()
        {
            MovieViewModel model = new MovieViewModel();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            MovieViewModel model = new MovieViewModel
            {
                MovieId = id
            };
            return View(model);
        }
    }
}