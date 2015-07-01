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
        
        // GET: Movie
        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
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
            Movie movie = movieService.GetMovieById((int) id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            MovieDetailViewModel viewModel = new MovieDetailViewModel
            {
                Movie = movie
            };


            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"];
            }

            return View(viewModel);
        }

    }
}