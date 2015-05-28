using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plathe.DAL;
using Plathe.Models;

namespace Plathe.Controllers
{
    public class ShowsController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: Shows
        public ActionResult Index()
        {
            DateTime today = DateTime.Today;

            var shows = db.Shows
                .Include(s => s.Movie)
                //.Where(s => s.StartingTime.Day >= today.Day)
                .OrderBy(s => s.StartingTime);

            return View(shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {

            // Originele detail controller, hieronder
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
        public ActionResult Reservate(int id, int? adults, int? adultsplus, int? childs, int? popcorn)
        {

            if (adults != null || adultsplus != null || childs != null || popcorn != null) {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            Reservation reservation = new Reservation
            {
                UniqueCode = result,
                PriceTotal = 12.00M,
                CreateOn = DateTime.Now,
            };
            db.Reservations.Add(reservation);
            db.SaveChanges();

            while (adults > 0)
            {
                // TODO: X-aantal Ticket objecten aanmaken, met het zojuist opgeslagen ReservationID
                Ticket ticket = new Ticket
                {

                    ShowID = 3,
                    ReservationID = reservation.ReservationID,
                    UniqueCode = new string(
                    Enumerable.Repeat(chars, 8)
                              .Select(s => s[random.Next(s.Length)])
                              .ToArray()),
                    SeatNumber = "1",
                    Price = 1.00M
                };
                db.Tickets.Add(ticket);
                db.SaveChanges();
                adults = adults - 1;
            }
            return RedirectToAction("Index", "Payment", new { id = reservation.ReservationID });
            } else {
                return RedirectToAction("Details", "Shows", new { id = id });
            }
            
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", show.MovieID);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowID,MovieID,Subtitle,StartingTime,ThreeDimensional")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", show.MovieID);
            return View(show);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = db.Shows.Find(id);
            db.Shows.Remove(show);
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
        }
    }
}
