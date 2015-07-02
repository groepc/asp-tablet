using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.AbstractServices
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAllRooms();
    }
}