using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Concrete
{
    public class EFRoomRepository : IRoomRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Room> Rooms
        {
            get { return context.Rooms; }
        }
    }
}
