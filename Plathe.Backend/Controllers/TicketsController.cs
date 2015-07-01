using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Plathe.Backend.Models;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.TabletUI.Models;

namespace Plathe.Backend.Controllers
{
    [Authorize(Roles = "sales")]
    public class TicketsController : Controller
    {

        private readonly IReservationService _reservationService;
        private readonly IShowService _showService;
        private readonly ITicketService _ticketService;
        private readonly ISeatService _seatService;

        public TicketsController(IReservationService reservationService, IShowService showService, ITicketService ticketService, ISeatService seatService)
        {

            _reservationService = reservationService;
            _showService = showService;
            _ticketService = ticketService;
            _seatService = seatService;

        }
        // GET: Tickets
        public ActionResult Index(DateTime? date)
        {

            ShowFindViewModel viewModel = new ShowFindViewModel
            {
                StartTime = date ?? DateTime.Now.Date
            };
            return View(viewModel);
        }

        public ActionResult TicketSelection(int id)
        {
            // get current show
            Show show = _showService.GetShowById(id);

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
                List<int> chosenSeats = _seatService.FindFreeSeats(viewModel.Show, viewModel.TotalAmount);

                Decimal totalPrice = _ticketService.CreateTickets(
                    chosenSeats,
                    reservation.ReservationId,
                    viewModel.Show,
                    false,
                    viewModel.AmountAdults,
                    viewModel.AmountAdultsPlus,
                    viewModel.AmountChildren,
                    0,
                    viewModel.AmountPopcorn,
                    0);

                _reservationService.UpdateReservation(reservation.ReservationId, totalPrice);



                return RedirectToAction("Printing", new { id = reservation.ReservationId });
            }
            // modelstate invalid, return ticket selection view
            return View(viewModel);
        }

        public ActionResult Printing(int id)
        {

            var model = new TicketViewModel
            {
                ReservationId = id
            };

            return View(model);
        }
    }
}