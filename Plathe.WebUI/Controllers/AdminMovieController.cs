using System.Linq;
using System.Web.Mvc;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Controllers
{
    [Authorize]
    public class AdminMovieController : Controller
    {
        private IMovieRepository _repository;

        public AdminMovieController(IMovieRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index()
        {
            return View(_repository.Movies);
        }

        public ViewResult Edit(int id)
        {
            Movie movie = _repository.Movies.FirstOrDefault(p => p.MovieId == id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveMovie(movie);
                TempData["message"] = string.Format("{0} is opgeslagen", movie.Title);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(movie);
            }
        }

        public ViewResult Create()
        {
            return View("Create", new Movie());
        }

        //[HttpPost]
        //public ActionResult Create(Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repository.SaveMovie(movie);
        //        TempData["message"] = string.Format("{0} is opgeslagen", movie.Title);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // there is something wrong with the data values
        //        return View(movie);
        //    }
        //}
    }
}