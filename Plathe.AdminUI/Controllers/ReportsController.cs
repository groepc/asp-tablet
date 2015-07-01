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
            var begin = new DateTime(2015, 01, 01);
            var end = DateTime.Today;

            var showsByMonth = _context.Shows
                .Where(m => m.StartingTime > begin)
                .Where(m => m.StartingTime < end)
                .GroupBy(m => m.StartingTime.Month)
                .ToList();

            Dictionary<string, double> monthlyRevenue = new Dictionary<string, double>();

            foreach (var showsForMonth in showsByMonth)
            {
                var groupKey = showsForMonth.Key;

                foreach (var show in showsForMonth)
                {
                    var month = show.StartingTime.ToString("MMMM");
                    var tickets = show.Tickets;
                    
                    // if a show has any tickets
                    if (tickets.Any())
                    {
                        foreach (var ticket in tickets)
                        {
                            if (!monthlyRevenue.ContainsKey(month))
                            {
                                monthlyRevenue[month] = (double) 0;
                            }

                            monthlyRevenue[month] += (double) ticket.Price;
                        }
                    }
                }
            }

            return View(monthlyRevenue);
        }
    }
}