using System;
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


        [HttpPost]
        public ActionResult SeatSelection()
        {

            NameValueCollection data = Request.Form;
            int TotalAmount = 0;

            var ShowId = Convert.ToInt32(data["showId"]);

            ViewBag.ShowId = ShowId;

            var shows = db.Shows.Find(ShowId);

            var ticketPrice = (decimal)0.00;
            if (shows.Movie.Duration > 120)
            {
                ticketPrice = (decimal)9.50;
            }
            else
            {
                ticketPrice = (decimal)8.50;
            }

            if (shows.Movie.ThreeDimensional == true)
            {
                var ticketprice = ticketPrice + (decimal)2.50;
            }


            //Todo, verplaats dit!
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            Reservation reservation = new Reservation
            {
                UniqueCode = result,
                CreateOn = DateTime.Now,
            };
            db.Reservations.Add(reservation);
            db.SaveChanges();


            if (!String.IsNullOrWhiteSpace(data["amountAdults"]))
            {
                int adults =  Convert.ToInt32(data["amountAdults"]);
                TotalAmount += adults;

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
                        Price = ticketPrice,
                        SeatID = 0
                    };
                    db.Tickets.Add(ticket);
                    db.SaveChanges();
                    adults = adults - 1;
                }

            }

            if (!String.IsNullOrWhiteSpace(data["amountChildren"]))
            {
                int children = Convert.ToInt32(data["amountChildren"]);
                TotalAmount += children;

                while (children > 0)
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
                        Price = (ticketPrice - (decimal)1.50),
                        SeatID = 0
                    };
                    db.Tickets.Add(ticket);
                    db.SaveChanges();
                    children = children - 1;
                }
            }

            if (!String.IsNullOrWhiteSpace(data["amountAdultsPlus"]))
            {
                int adultsPlus = Convert.ToInt32(data["amountAdults"]);
                TotalAmount += adultsPlus;

                while (adultsPlus > 0)
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
                        Price = (ticketPrice - (decimal)1.50),
                        SeatID = 0
                    };
                    db.Tickets.Add(ticket);
                    db.SaveChanges();
                    adultsPlus = adultsPlus - 1;
                }
            }

            if (!String.IsNullOrWhiteSpace(data["amountPopcorn"]))
            {
                int popcorn = Convert.ToInt32(data["amountAdults"]);
                TotalAmount += popcorn;

                while (popcorn > 0)
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
                        Price = (ticketPrice + (decimal)5.00),
                        SeatID = 0
                    };
                    db.Tickets.Add(ticket);
                    db.SaveChanges();
                    popcorn = popcorn - 1;
                }
            }

            ViewBag.TotalAmount = TotalAmount;


            ViewBag.reservationId = reservation.ReservationID;

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
