using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Abstract
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> Tickets { get; }
        IEnumerable<Ticket> GetTicketsByReservationId(int id);
        Ticket SaveTicket(Ticket reservation);
    }


}
