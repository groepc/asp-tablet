using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Plathe.Backend.Models;
using Plathe.Domain.AbstractServices;

namespace Plathe.Backend.Controllers
{
    [Authorize(Roles = "backoffice")]
    public class ShowsController : Controller
    {
        private readonly IShowService _showService;
        private readonly IMovieService _movieService;
        private readonly IRoomService _roomService;

        public ShowsController(IShowService showService, IMovieService movieService, IRoomService roomService)
        {
            _showService = showService;
            _movieService = movieService;
            _roomService = roomService;
        }

        public ShowsController()
        {
            throw new NotImplementedException();
        }

        // GET: Shows
        public ActionResult Index()
        {
            var shows = _showService.GetAllShows();
            return View(shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowViewModel viewModel = new ShowViewModel
            {
                Show = _showService.GetShowById(Convert.ToInt32(id))
            };
            return View(viewModel);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ShowViewModel viewModel = new ShowViewModel
            {
                Movies = _movieService.GetAllMovies(),
                Rooms = _roomService.GetAllRooms()
            };
            return View(viewModel);
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int success = _showService.SaveShow(null, viewModel.MovieId, viewModel.RoomId, viewModel.Subtitle, viewModel.StartingTime, viewModel.ThreeDimensional);
                if (success == 0)
                {
                    return RedirectToAction("Index");
                }

                TempData["message"] = "De show kon niet worden opgeslagen, controller de gegevens";
                TempData["alert-class"] = "danger";
            }
            viewModel.Movies = _movieService.GetAllMovies();
            viewModel.Rooms = _roomService.GetAllRooms();
            return View(viewModel);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ShowViewModel viewModel = new ShowViewModel
            {
                Show = _showService.GetShowById(Convert.ToInt32(id)),
                Movies = _movieService.GetAllMovies(),
                Rooms = _roomService.GetAllRooms()
            };
            return View(viewModel);

        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShowViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _showService.SaveShow(viewModel.ShowId, viewModel.MovieId, viewModel.RoomId, viewModel.Subtitle, viewModel.StartingTime, viewModel.ThreeDimensional);
                return RedirectToAction("Edit", new { });
            }

            viewModel.Movies = _movieService.GetAllMovies();
            viewModel.Rooms = _roomService.GetAllRooms();

            return View(viewModel);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ShowViewModel viewModel = new ShowViewModel
            {
                ShowId = Convert.ToInt32(id)
            };
            return View(viewModel);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _showService.RemoveShowById(Convert.ToInt32(id));
            TempData["message"] = "Voorstelling verwijderd";
            return RedirectToAction("Index");
        }
    }
}
