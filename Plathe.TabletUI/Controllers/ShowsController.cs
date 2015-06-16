﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.TabletUI.Models;

namespace Plathe.TabletUI.Controllers
{
    public class ShowsController : Controller
    {
        private IShowService _showService;
        private IReservationService _reservationService;
        private ITicketService _ticketService;
        private ISeatService _seatService;

        public ShowsController(IShowService showService, IReservationService reservationService, ITicketService ticketService, ISeatService seatService)
        {

            _reservationService = reservationService;
            _showService = showService;
            _ticketService = ticketService;
            _seatService = seatService;
        }

        // GET: Shows
        public ViewResult List()
        {
            ShowViewModel viewModel = new ShowViewModel();
            return View(viewModel);
        }
        // GET: Shows/TicketSelection/5
        public ViewResult TicketSelection(int id)
        {
            // get current show
            Show show = _showService.GetShowById(id);

            TicketSelectionViewModel viewModel = new TicketSelectionViewModel
            {
                ShowId = show.ShowId
            };

            return View(viewModel);
        }

        [HttpPost]
        public ViewResult TicketSelection(TicketSelectionViewModel viewModel)
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


                // TODO: redirect to payment controller
                //return Redirect("/Payment/Index/" + reservation.ReservationId);
                // return RedirectToAction("Index", "Payment", reservation.ReservationId);
            }
            else
            {
                // modelstate invalid, return ticket selection view
                return View(viewModel);
            }
        }
    }
}