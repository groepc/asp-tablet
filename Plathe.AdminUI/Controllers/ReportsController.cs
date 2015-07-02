using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.AdminUI.Models;
using Plathe.Domain.Abstract;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;

namespace Plathe.AdminUI.Controllers
{
    [Authorize]
    public class ReportsController : AppController
    {
        private readonly EfDbContext _context = new EfDbContext();

        public ReportsController()
        {
        }

        public ActionResult OccupationPerShow()
        {
            var chosenDate = DateTime.Today;
            String date = Request.QueryString["date"];
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
            var viewModel = new RevenueViewModel
            {
                StartDate = new DateTime(2015, 1, 1),
                EndDate = DateTime.Today
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Revenue(RevenueViewModel model)
        {

            var viewModel = new RevenueViewModel
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            return View(viewModel);
        }
    }
}