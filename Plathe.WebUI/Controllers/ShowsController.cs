﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;
using System.Collections.Specialized;

namespace Plathe.WebUI.Controllers
{
    public class ShowsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Shows
        public ActionResult Index()
        {
            DateTime tomorrow = DateTime.Today.AddDays(1);

            int daysUntilThursday = ((int)DayOfWeek.Thursday - (int)tomorrow.DayOfWeek + 7) % 7;
            DateTime nextThursday = tomorrow.AddDays(daysUntilThursday);

            var shows = db.Shows
                .Where(s => s.StartingTime >= DateTime.Today)
                .Where(s => s.StartingTime <= nextThursday)
                .Include(s => s.Movie);

            return View(shows.ToList());
        }

        // GET: Shows/Reservate/5
        public ActionResult Reservate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // get current show
            Show show = db.Shows.Find(id);

            if (show == null)
            {
                return HttpNotFound();
            }

            return View(show);
        }


        // POST: Shows/Reservate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservate(int showId, int? adults, int? adultsplus, int? childs, int? popcorn)
        {

            if (ModelState.IsValid)
            {
                if (adults != null || adultsplus != null || childs != null || popcorn != null)
                {
                    //Reservation.SaveReservationWithTickets(showId, adults, adultsplus, childs, popcorn);
                    return RedirectToAction("Reservate", "SeatSelection", new { showId });
                }
                return RedirectToAction("Reservate", "Shows", new {showId });
            }
            return RedirectToAction("Reservate", "Shows", new { showId });
        }

        [HttpPost]
        public ActionResult SeatSelection()
        {

            NameValueCollection data = Request.Form;
            var ShowId = Convert.ToInt32(data["showId"]);
            var AmountAdults = Convert.ToInt32(data["amountAdults"]);
            var AmountChildren = Convert.ToInt32(data["amountChildren"]);
            var TotalAmount = AmountChildren + AmountAdults;

            ViewBag.ShowId = ShowId;
            ViewBag.TotalAmount = TotalAmount;

            // get current show
            Show show = db.Shows.Find(ShowId);

            // get tickets for show
            var tickets = db.Tickets.Where(s => s.ShowID == show.ShowID);

            foreach (var row in show.Room.Rows)
            {
                foreach (var seat in row.Seats)
                {
                    bool isReserved = tickets.Any(t => t.SeatID == seat.SeatID);
                    if (isReserved)
                    {
                        seat.Reserved = true;
                    }
                }
            }

            return View(show);
        }

        [HttpPost]
        public ActionResult Complete()
        {

            NameValueCollection data = Request.Form;




            return View();
        }
    }
}
