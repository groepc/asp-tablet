using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Plathe.AdminUI.Models;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.AdminUI.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        // GET: Movie
        public ActionResult List()
        {
            MovieViewModel model = new MovieViewModel();
            return View(model);
        }
        /*
        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,GenreId,Title,Language,Duration,MinimumAge,Description,ThreeDimensional,Image,RatingViolence,RatingFear,RatingSex,RatingDiscrimination,RatingDrugs,RatingLanguage,Director,MainCharacters,LinkToImdb,LinkToTrailer,LinkToWebsite,PlaysUntill")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", movie.GenreId);
            return View(movie);
        }
        */
        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movie = movieService.GetMovieById(id);
           
            MovieViewModel model = new MovieViewModel
            {
                MovieId = movie.MovieId
            };
            return View(model);
        }
        
        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,GenreId,Title,Language,Duration,MinimumAge,Description,ThreeDimensional,Image,RatingViolence,RatingFear,RatingSex,RatingDiscrimination,RatingDrugs,RatingLanguage,Director,MainCharacters,LinkToImdb,LinkToTrailer,LinkToWebsite,PlaysUntill")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", movie.GenreId);
            return View(movie);
        }
        /*
        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
