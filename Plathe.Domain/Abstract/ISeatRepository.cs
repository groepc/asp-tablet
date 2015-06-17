using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Abstract
{
    public interface ISeatRepository
    {
        IEnumerable<Seat> Seats { get; }
    }
}