using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.AdminUI.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {

        private IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public ActionResult Index()
        {
            IEnumerable<Review> reviews = _reviewService.GetNewReviews().ToList();

            return View(reviews);
        }

        public ActionResult Approve(int id)
        {
            _reviewService.SetStatusForReview(id, 1);
            return RedirectToAction("Index");
        }

        public ActionResult Reject(int id)
        {
            _reviewService.SetStatusForReview(id, -1);
            return RedirectToAction("Index");
        }
    }
}