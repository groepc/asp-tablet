using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfRoomRepository : IRoomRepository
    {
        private EfDbContext _context = new EfDbContext();

        public IEnumerable<Room> Rooms
        {
            get { return _context.Rooms; }
        }
    }
}
