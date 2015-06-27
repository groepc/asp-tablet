using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Abstract
{
    public interface IShowRepository
    {
        IEnumerable<Show> Shows { get; }

        void SaveShow(Show show);
    }
}
