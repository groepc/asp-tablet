using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System.Linq;

namespace Plathe.Domain.Concrete
{
    public class EfShowRepository : IShowRepository
    {
        private EfDbContext _context = new EfDbContext();

        public IEnumerable<Show> Shows
        {
            get { return _context.Shows; }
        }

        public void SaveShow(Show show)
        {
            if (show.ShowId == 0)
            {
                _context.Shows.Add(show);
            }
            else
            {
                Show dbEntry = _context.Shows.Find(show.ShowId);
                if (dbEntry != null)
                {
                    dbEntry.MovieId = show.MovieId;
                    dbEntry.RoomId = show.RoomId;
                    dbEntry.Subtitle = show.Subtitle;
                    dbEntry.StartingTime = show.StartingTime;
                    dbEntry.ThreeDimensional = show.ThreeDimensional;
                }
            }
            _context.SaveChanges();
        }
    }
}

