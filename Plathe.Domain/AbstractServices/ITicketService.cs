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
        Ticket createTicket(int reservationID, int seatID, string type, Show show, bool secretMovie = false);
        void createTickets(List<Int32> seats, int reservationID, Show show, bool secretMovie, int adults, int adultsPlus, int children, int Students, int popcorn);
    }
}
