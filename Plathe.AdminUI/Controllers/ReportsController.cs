using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.AdminUI.Models;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;

namespace Plathe.AdminUI.Controllers
{
    [Authorize]
    public class ReportsController : AppController
    {
        private readonly IShowService _showService;

        public ReportsController(IShowService showService)
        {
            _showService = showService;
        }

        public ActionResult OccupationPerShow()
        {
            var chosenDate = DateTime.Today;
            //String date = Request.QueryString["date"];
            String date = "15-7-2015";
            if (date != null)
            {
                chosenDate = Convert.ToDateTime(date);
            }

            OccupationViewModel viewModel = new OccupationViewModel
            {
                ChosenDate = chosenDate
            };

            return View(viewModel);
        }

        public ActionResult Revenue()
        {

            var viewModel = new RevenueViewModel(_showService)
            {
                StartDate = new DateTime(2015, 1, 1),
                EndDate = DateTime.Today
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Revenue(RevenueViewModel model)
        {

            var viewModel = new RevenueViewModel(_showService)
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            return View(viewModel);
        }
    }
}