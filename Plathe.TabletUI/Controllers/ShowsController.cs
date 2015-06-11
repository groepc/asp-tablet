﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plathe.TabletUI.Models;
using Plathe.Domain.Concrete;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using Plathe.Domain.AbstractServices;

namespace Plathe.TabletUI.Controllers
{
    public class ShowsController : Controller
    {
        //private EFDbContext db = new EFDbContext();
        //private IReservationService reservationService;
        private IShowService showService;

        public ShowsController(IShowService showService)
        {

        //    this.reservationService = reservationService;
            this.showService = showService;

        }

        // GET: Shows
        public ViewResult List()
        {
            ShowViewModel viewModel = new ShowViewModel();
            return View(viewModel);
        }
        // GET: Shows/TicketSelection/5
        public ViewResult TicketSelection(int? id)
        {
            // get current show
            Show show = showService.getShowById((int)id);

            TicketSelectionViewModel viewModel = new TicketSelectionViewModel
            {
                ShowId = show.ShowID
            };

            return View(viewModel);
        }
    }
}