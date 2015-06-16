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
                Shows = showService.GetShowsThisWeek()
            };

            return View(viewModel);
        }

        // GET: Shows/TicketSelection/5
        public ActionResult TicketSelection(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // get current show
            Show show = showService.GetShowById(id);

            if (show == null) 
            {
                return HttpNotFound();
            };

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
                Reservation reservation = reservationService.CreateReservation();
                

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

            Reservation reservation = this.reservationService.GetReservationById(Convert.ToInt32(data["ReservationID"]));

            var ShowId = Convert.ToInt32(data["ShowId"]);
            Show show = db.Shows.Find(ShowId);

            int AmountAdults = Convert.ToInt32(data["amountAdults"]);
            int AmountAdultsPlus = Convert.ToInt32(data["amountAdultsPlus"]);
            int AmountChildren = Convert.ToInt32(data["amountChildren"]);
            int AmountStudents = Convert.ToInt32(data["amountStudents"]);
            int AmountPopcorn = Convert.ToInt32(data["amountPopcorn"]);
            int AmountVIP = Convert.ToInt32(data["amountVIP"]);

            var reservationID = reservation.ReservationId;


            // get seat ID's
            string seatsString = data["seat-selected"];
            var ChosenSeat = seatsString.Split(',').Select(x => int.Parse(x)).ToList();

            Decimal totalPrice = this.ticketService.CreateTickets(ChosenSeat, reservationID, show, false, AmountAdults, AmountAdultsPlus, AmountChildren, AmountStudents, AmountPopcorn, AmountVIP);
            this.reservationService.UpdateReservation(reservationID, totalPrice);

            // send variables to view
            ViewBag.ReservationId = reservationID;
            return View(reservation);
        }
    }
}