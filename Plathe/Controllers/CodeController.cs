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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CheckCode()
        {
            string ReservationCode = Request.Form["code"];
            var ReservationID = db.Reservations
                .Where(Reservation => Reservation.UniqueCode == ReservationCode)
                .Select(Reservation => Reservation.ReservationID)
                .FirstOrDefault();

            if (ReservationID != 0)
            {
                HttpContext.Response.Redirect("/Tickets/Printing");
            }

            return RedirectToAction("Index");
        }
    }
}