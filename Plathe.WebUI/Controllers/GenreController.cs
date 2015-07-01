using System.Web.Mvc;
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
            return View(movieService.GetMoviesByGenreName(genreQuery));
        }

    }
}