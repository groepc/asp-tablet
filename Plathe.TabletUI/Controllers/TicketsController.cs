﻿using System.Web.Mvc;
using Plathe.TabletUI.Models;

namespace Plathe.TabletUI.Controllers
{
    public class TicketsController : Controller
    {
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