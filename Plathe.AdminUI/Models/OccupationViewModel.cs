using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.AdminUI.Models
{
    public class OccupationViewModel
    {

        private IShowService _showService = DependencyResolver.Current.GetService<IShowService>();

        public IEnumerable<Show> Shows
        {
            get
            {
                return _showService.GetAllShows()
                    .Where(model => model.StartingTime.Month == this.ChosenDate.Month)
                    .Where(model => model.StartingTime.Day == this.ChosenDate.Day)
                    .ToList();
            }
        }

        public DateTime ChosenDate { get; set; }

        public DateTime DayBefore
        {
            get { return ChosenDate.AddDays(-1); }
        }

        public DateTime DayAfter
        {
            get { return ChosenDate.AddDays(1); }
        }

        public int TotalSeats
        {
            get
            {
                return Shows.Sum(show => show.Room.TotalSeats);
            }
        }

        public int TotalOccupiedSeats
        {
            get
            {
                return Shows.Sum(show => show.Tickets.Count);
            }
        }
    }
}