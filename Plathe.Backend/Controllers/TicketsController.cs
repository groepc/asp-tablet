using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Backend.Models;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Backend.Controllers
{
    [AllowAnonymous]
    public class TicketsController : Controller
    {

        private readonly IReservationService _reservationService;
        private readonly IShowService _showService;

        public TicketsController(IReservationService reservationService, IShowService showService, ITicketService ticketService)
        {

            _reservationService = reservationService;
            _showService = showService;

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
    }
}