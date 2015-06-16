using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Concrete
{
    public class EfRoomRepository : IRoomRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Room> Rooms
        {
            get { return context.Rooms; }
        }
    }
}
