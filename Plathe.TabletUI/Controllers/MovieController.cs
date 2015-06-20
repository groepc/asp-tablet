using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.TabletUI.Models;

namespace Plathe.TabletUI.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        // GET: Movies
        public ViewResult List()
        {
            MovieViewModel model = new MovieViewModel();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            Movie movie = movieService.GetMovieById(id);

            MovieViewModel model = new MovieViewModel
            {
                MovieId = movie.MovieId
            };
            return View(model);
        }
    }
}