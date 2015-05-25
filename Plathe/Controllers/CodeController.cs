using Plathe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Models;

namespace Plathe.Controllers
{
    public class CodeController : Controller
    {

        private CinemaContext db = new CinemaContext();

        // GET: Code
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string code)
        {
            string ReservationCode = code;
            var ReservationID = db.Reservations
                .Where(Reservation => Reservation.UniqueCode == ReservationCode)
                .Select(Reservation => Reservation.ReservationID)
                .FirstOrDefault();

            if (ReservationID != 0)
            {
                return RedirectToAction("Printing", "Tickets", new { id = ReservationID });
             
            }
            else
            {
                ViewData["NoResults"] = "De code die u heeft ingevoerd is onjuist, probeer opnieuw.";
                return View();
            }
        }
    }
}