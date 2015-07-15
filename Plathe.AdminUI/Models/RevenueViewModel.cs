using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;

namespace Plathe.AdminUI.Models
{
    public class RevenueViewModel
    {
        //private IShowService _showService = DependencyResolver.Current.GetService<IShowService>();
        private IShowService _showService;

        public RevenueViewModel(IShowService showService)
        {
            _showService = showService;
        }

        public Dictionary<string, double> RevenuePerMonth
        {
            get
            {

                var showsByMonth = _showService.GetAllShows()
                    .Where(m => m.StartingTime > StartDate)
                    .Where(m => m.StartingTime < EndDate.AddMonths(1))
                    .OrderBy(m => m.StartingTime)
                    .GroupBy(m => m.StartingTime.Month)
                    .ToList();

                var monthlyRevenue = new Dictionary<string, double>();

                foreach (var showsForMonth in showsByMonth)
                {

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
                                    monthlyRevenue[month] = 0;
                                }

                                monthlyRevenue[month] += (double) ticket.Price;
                            }
                        }
                    }
                }

                return monthlyRevenue;
            }
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


    }
}