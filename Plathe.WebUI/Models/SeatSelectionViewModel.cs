using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.WebUI.Models
{
    public class SeatSelectionViewModel
    {

        private EFDbContext db = new EFDbContext();

        public Show Show { get; set; }

        public TicketSelectionViewModel TicketSelectionViewModel { get; set; }

        public Reservation Reservation { get; set; }

        public IEnumerable<Row> Rows 
        {
            get
            {
                IEnumerable<Row> getRows = this.Show.Room.Rows;

                var tickets = db.Tickets.Where(s => s.ShowID == this.Show.ShowID);

                // set reservation status of each seat
                foreach (var row in getRows)
                {
                    foreach (var seat in row.Seats)
                    {
                        bool isReserved = tickets.Any(t => t.SeatID == seat.SeatID);
                        if (isReserved)
                        {
                            seat.Reserved = true;
                        }
                    }
                }

                return getRows;
            }
        }

    }
}