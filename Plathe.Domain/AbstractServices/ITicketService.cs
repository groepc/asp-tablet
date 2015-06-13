using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.AbstractServices
{
    public interface ITicketService
    {
        //IEnumerable<Ticket> getTicketsForShow(int ShowId);
        Ticket CreateTicket(int reservationId, int seatId, string type, Show show, bool secretMovie = false);
        decimal CreateTickets(List<Int32> seats, int reservationId, Show show, bool secretMovie, int adults, int adultsPlus, int children, int students, int popcorn, int vip);
    }
}
