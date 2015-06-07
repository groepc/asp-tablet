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
using Plathe.WebUI.Models;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;

namespace Plathe.WebUI.Controllers
{
    public class ShowsController : Controller
    {
        private EFDbContext db = new EFDbContext();
        private IReservationService reservationService;

        public ShowsController(IReservationService reservationService)
        {

            this.reservationService = reservationService;

        }

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

        // GET: Shows/TicketSelection/5
        public ActionResult TicketSelection(int? id)
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
            };

            TicketSelectionViewModel viewModel = new TicketSelectionViewModel
            {
                Show = show,
                ShowId = show.ShowID
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult TicketSelection(TicketSelectionViewModel viewModel)
        {            

            if (ModelState.IsValid)
            {

                // create reservation
                Reservation reservation = reservationService.createReservation();

                // create viewModel for seatSelection
                TempData["reservation"] = reservation;
                TempData["ticketSelectionViewModel"] = viewModel;

                return RedirectToAction("SeatSelection");
            }
            else
            {
                // modelstate invalid, return ticket selection view
                viewModel.Show = db.Shows.Find(viewModel.ShowId);

                return View(viewModel);
            }
        }

        public ActionResult SeatSelection()
        {


            TicketSelectionViewModel ticketSelectionViewModel = (TicketSelectionViewModel) TempData["ticketSelectionViewModel"];
            var reservation = TempData["reservation"];

            SeatSelectionViewModel viewModel = new SeatSelectionViewModel
            {
                TicketSelectionViewModel = ticketSelectionViewModel
            };

            // get seat selection view
            return View();
        }
        
        [HttpPost]
        public ActionResult SeatSelection(SeatSelectionViewModel viewModel)
        {


            var ShowId = viewModel.ShowId;


            // get current show
            Show show = db.Shows.Find(ShowId);

            // get tickets for show
            var tickets = db.Tickets.Where(s => s.ShowID == show.ShowID);

            // set reservation status of each seat
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



            // data for view
            // ViewBag.ShowId = ShowId;
            // ViewBag.AmountAdults = AmountAdults;
            // ViewBag.AmountAdultsPlus = AmountAdultsPlus;
            // ViewBag.AmountChildren = AmountChildren;
            // ViewBag.AmountPopcorn = AmountPopcorn;
            // ViewBag.TotalAmount = TotalAmount;

            return View(show);
        }

        [HttpPost]
        public ActionResult Payment()
        {

            NameValueCollection data = Request.Form;

            // get total seat numbers
            var TotalSeats = Convert.ToInt32(data["AmountTotal"]);
            var ShowId = Convert.ToInt32(data["ShowId"]);
            Show show = db.Shows.Find(ShowId);

            int AmountAdults = Convert.ToInt32(data["amountAdults"]);
            int AmountAdultsPlus = Convert.ToInt32(data["amountAdultsPlus"]);
            int AmountChildren = Convert.ToInt32(data["amountChildren"]);
            int AmountPopcorn = Convert.ToInt32(data["amountPopcorn"]);


            // get seat ID's
            string seatsString = data["seat-selected"];
            var ChosenSeat = seatsString.Split(',').Select(x => int.Parse(x));
            var ChosenSeatList = ChosenSeat.ToList();

            // set base ticket price
            var ticketPrice = (decimal)8.50;

            // increas price if longer then 120 minutes
            if (show.Movie.Duration >= 120)
            {
                ticketPrice = ticketPrice + (decimal)1.50;
            }

            // increase price if movie is 3D
            if (show.Movie.ThreeDimensional == true)
            {
                ticketPrice = ticketPrice + (decimal)2.50;
            }

            // create reservation
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
                PriceTotal = (decimal)10.00,
                Payed = false,
                PayedOn = DateTime.Now
            };

            // save reservation to DB
            db.Reservations.Add(reservation);
            db.SaveChanges();

            // get reservation ID
            var resId = reservation.ReservationID;
            var totalPrice = (decimal)0.00;

            // create ticket list
            var tickets = new List<Ticket>();

            // create tickets
            for (int i = 0; i < TotalSeats; i++)
            {

                var seatTicketPrice = ticketPrice;

                // give this ticket a seat
                var thisSeat = ChosenSeatList[i];

                // determine what type of ticket this is
                if (AmountAdultsPlus > 0)
                {

                    var dayOfWeek = (int)(show.StartingTime.DayOfWeek + 6) % 7;

                    // only change ticket price between monday and thursday
                    if( dayOfWeek >= 0 && dayOfWeek <= 3 ) {
                        seatTicketPrice = seatTicketPrice - (decimal)1.50;
                    }

                    AmountAdultsPlus--;
                } 
                else if (AmountChildren > 0 )
                {
                    // only for shows before 18
                    if (show.StartingTime.Hour <= 18)
                    {
                        seatTicketPrice = seatTicketPrice - (decimal)1.50;
                    }
                    
                    AmountChildren--;
                }
                else if (AmountPopcorn > 0)
                {
                    seatTicketPrice = seatTicketPrice - (decimal)1.50;   
                    AmountPopcorn--;
                }

                tickets.Add(new Ticket
                {
                    ShowID = show.ShowID,
                    ReservationID = resId,
                    SeatID = thisSeat,
                    UniqueCode = new string(
                                Enumerable.Repeat(chars, 4)
                                .Select(s => s[random.Next(s.Length)])
                                .ToArray()),
                    Price = seatTicketPrice,
                    Options = "options",
                    PopcornTime = false
                });

                totalPrice = totalPrice + seatTicketPrice;
            }
            tickets.ForEach(s => db.Tickets.Add(s));
            db.SaveChanges();

            reservation.PriceTotal = totalPrice;
            db.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            // send variables to view
            ViewBag.ReservationId = resId;
            return View(reservation);
        }
    }
}
