using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;
using Plathe.WebUI.Models;

namespace Plathe.WebUI.Controllers
{
    public class ShowsController : Controller
    {
        private EfDbContext _db = new EfDbContext();
        private IReservationService _reservationService;
        private IShowService _showService;
        private ITicketService _ticketService;

        public ShowsController(IReservationService reservationService, IShowService showService, ITicketService ticketService)
        {

            _ticketService = ticketService;
            _reservationService = reservationService;
            _showService = showService;

        }

        // GET: Shows
        public ActionResult Index()
        {
            ShowViewModel viewModel = new ShowViewModel
            {
                Shows = _showService.GetShowsThisWeek()
            };

            return View(viewModel);
        }

        // GET: Shows/TicketSelection/5
        public ActionResult TicketSelection(int id)
        {
            // get current show
            Show show = _showService.GetShowByMovieId(id);

            if (show == null) 
            {
                return HttpNotFound();
            }

            TicketSelectionViewModel viewModel = new TicketSelectionViewModel
            {
                ShowId = show.ShowId
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult TicketSelection(TicketSelectionViewModel viewModel)
        {            

            if (ModelState.IsValid)
            {

                // create reservation
                Reservation reservation = _reservationService.CreateReservation();
                

                // create viewModel for seatSelection
                TempData["reservation"] = reservation;
                TempData["ticketSelectionViewModel"] = viewModel;

                return RedirectToAction("SeatSelection");
            }
            else
            {
                // modelstate invalid, return ticket selection view
                return View(viewModel);
            }
        }

        public ActionResult SeatSelection()
        {

            if (TempData["ticketSelectionViewModel"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TicketSelectionViewModel ticketSelectionViewModel = (TicketSelectionViewModel) TempData["ticketSelectionViewModel"];
            Reservation reservation = (Reservation) TempData["reservation"];

            SeatSelectionViewModel viewModel = new SeatSelectionViewModel
            {
                Show = ticketSelectionViewModel.Show,
                TicketSelectionViewModel = ticketSelectionViewModel,
                Reservation = reservation
            };

            // get seat selection view
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Payment()
        {

            NameValueCollection data = Request.Form;

            Reservation reservation = _reservationService.GetReservationById(Convert.ToInt32(data["ReservationID"]));

            var showId = Convert.ToInt32(data["ShowId"]);
            Show show = _db.Shows.Find(showId);

            int amountAdults = Convert.ToInt32(data["amountAdults"]);
            int amountAdultsPlus = Convert.ToInt32(data["amountAdultsPlus"]);
            int amountChildren = Convert.ToInt32(data["amountChildren"]);
            int amountStudents = Convert.ToInt32(data["amountStudents"]);
            int amountPopcorn = Convert.ToInt32(data["amountPopcorn"]);
            int amountVip = Convert.ToInt32(data["amountVip"]);

            var reservationId = reservation.ReservationId;


            // get seat ID's
            string seatsString = data["seat-selected"];
            var chosenSeat = seatsString.Split(',').Select(x => int.Parse(x)).ToList();

            Decimal totalPrice = _ticketService.CreateTickets(chosenSeat, reservationId, show, false, amountAdults, amountAdultsPlus, amountChildren, amountStudents, amountPopcorn, amountVip);
            _reservationService.UpdateReservation(reservationId, totalPrice);

            // send variables to view
            ViewBag.ReservationId = reservationId;
            return View(reservation);
        }
    }
}