using System.Collections.Generic;
using System.Linq;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfTicketRepository : ITicketRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Ticket> Tickets
        {
            get { return _context.Tickets; }
        }

        public IEnumerable<Ticket> GetTicketsByReservationId(int id)
        {
            return _context.Tickets.Where(t => t.ReservationId.Equals(id));
        } 

        public Ticket SaveTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

    }
}
