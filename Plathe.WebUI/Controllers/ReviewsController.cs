using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;
using Plathe.WebUI.Models;

namespace Plathe.WebUI.Controllers
{
    public class ReviewsController : Controller
    {
        private IMovieService _movieService;
        private ITicketService _ticketService;
        private IReviewService _reviewService;

        public ReviewsController(IMovieService movieService, ITicketService ticketService, IReviewService reviewService)
        {
            _movieService = movieService;
            _ticketService = ticketService;
            _reviewService = reviewService;
        }

        // GET: Reviews/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                var viewModel = new ReviewViewModel
                {
                    MovieID = (int) id,
                    Movie = _movieService.GetMovieById((int) id)
                };

                return View(viewModel);
            }
            
            return new HttpNotFoundResult();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Ticket ticket = _ticketService.GetTicketByUniqueCode(viewModel.TicketID);

                // if this ticket was for the right movie
                if (ticket.Show.MovieId == viewModel.MovieID)
                {
                    Review review = new Review
                    {
                        TicketID = ticket.UniqueCode,
                        Content = viewModel.Content,
                        MovieID = viewModel.MovieID,
                        Rating = viewModel.Rating,
                        ReviewStatus = 0,
                        UserEmail = viewModel.UserEmail,
                        UserName = viewModel.UserName
                    };

                    _reviewService.CreateReview(review);

                    TempData["Message"] = "Je review is toegevoegd aan de wachtlijst. Wanneer een van onze medewerkers jouw review heeft goedgekeurd wordt hij getoond op de website.";
                    return RedirectToAction("Details", "Movie", new { id = viewModel.MovieID });
                }
            }

            return View(viewModel);
        }
    }
}
