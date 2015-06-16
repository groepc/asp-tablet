using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfSeatRepository : ISeatRepository
    {
        private EfDbContext _context = new EfDbContext();

        public IEnumerable<Seat> Seats
        {
            get { return _context.Seats; }
        }
    }
}