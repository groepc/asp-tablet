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
        private IShowService showService;
        private ITicketService ticketService;

        public ShowsController(IReservationService reservationService, IShowService showService, ITicketService ticketService)
        {

            this.ticketService = ticketService;
            this.reservationService = reservationService;
            this.showService = showService;

        }

        // GET: Shows
        public ActionResult Index()
        {
            ShowViewModel viewModel = new ShowViewModel
            {
                Shows = showService.getShowsThisWeek()
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
            Show show = showService.getShowById(id);

            if (show == null) 
            {
                return HttpNotFound();
            };

            TicketSelectionViewModel viewModel = new TicketSelectionViewModel
            {
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

            Reservation reservation = this.reservationService.getReservationById(Convert.ToInt32(data["ReservationID"]));

            var ShowId = Convert.ToInt32(data["ShowId"]);
            Show show = db.Shows.Find(ShowId);

            int AmountAdults = Convert.ToInt32(data["amountAdults"]);
            int AmountAdultsPlus = Convert.ToInt32(data["amountAdultsPlus"]);
            int AmountChildren = Convert.ToInt32(data["amountChildren"]);
            int AmountStudents = Convert.ToInt32(data["amountStudents"]);
            int AmountPopcorn = Convert.ToInt32(data["amountPopcorn"]);

            var reservationID = reservation.ReservationID;


            // get seat ID's
            string seatsString = data["seat-selected"];
            var ChosenSeat = seatsString.Split(',').Select(x => int.Parse(x)).ToList();

            Decimal totalPrice = this.ticketService.createTickets(ChosenSeat, reservationID, show, false, AmountAdults, AmountAdultsPlus, AmountChildren, AmountStudents, AmountPopcorn);
            this.reservationService.updateReservation(reservationID, totalPrice);

            // send variables to view
            ViewBag.ReservationId = reservationID;
            return View(reservation);
        }
    }
}