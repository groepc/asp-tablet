using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Abstract
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> Tickets { get; }

        IEnumerable<Ticket> GetTicketsByReservationId(int id);
        Ticket SaveTicket(Ticket reservation);
    }
}
