using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfTicketRepository : ITicketRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Ticket> Tickets
        {
            get { return context.Tickets; }
        }

        public IEnumerable<Ticket> GetTicketsByReservationId(int id)
        {
            return context.Tickets.Where(t => t.ReservationId.Equals(id));
        } 

        public Ticket SaveTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            context.SaveChanges();
            return ticket;
        }

    }
}
