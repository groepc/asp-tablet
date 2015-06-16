using System.Collections.Generic;
using System.Linq;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Models
{
    public class SeatSelectionViewModel
    {

        private EfDbContext _db = new EfDbContext();

        public Show Show { get; set; }
      
        public TicketSelectionViewModel TicketSelectionViewModel { get; set; }

        public Reservation Reservation { get; set; }

        public IEnumerable<Row> Rows 
        {
            get
            {
                IEnumerable<Row> getRows = Show.Room.Rows;

                var tickets = _db.Tickets.Where(s => s.ShowId == Show.ShowId);

                // set reservation status of each seat
                foreach (var row in getRows)
                {
                    foreach (var seat in row.Seats)
                    {
                        bool isReserved = tickets.Any(t => t.SeatId == seat.SeatId);
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