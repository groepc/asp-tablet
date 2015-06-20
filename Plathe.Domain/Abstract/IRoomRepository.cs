using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Abstract
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Rooms { get; }
    }
}