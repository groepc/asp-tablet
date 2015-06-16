using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Concrete
{
    public class EfTicketRepository : ITicketRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Ticket> Tickets
        {
            get { return context.Tickets; }
        }

        public Ticket SaveTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            context.SaveChanges();
            return ticket;
        }

    }
}
