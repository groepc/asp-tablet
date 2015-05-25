using Plathe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.Controllers
{
    public class TicketsController : Controller
    {
        private CinemaContext db = new CinemaContext();
        // GET: Tickets
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Printing(string id)
        {
            var ReservationID = Convert.ToInt32(id);
            var ReservationInformation = db.Reservations
                .Where(Reservation => Reservation.ReservationID == ReservationID);
            return View(ReservationInformation.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}