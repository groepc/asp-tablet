using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Abstract
{
    public interface IShowRepository
    {
        IEnumerable<Show> Shows { get; }
        void AddShow(Show show);
        void UpdateShow(Show show);
        void RemoveShowById(int id);


    }
}
