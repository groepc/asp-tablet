using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System.Linq;

namespace Plathe.Domain.Concrete
{
    public class EfShowRepository : IShowRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Show> Shows
        {
            get { return context.Shows; }
        }

        public void SaveShow(Show show)
        {
            if (show.ShowId == 0)
            {
                context.Shows.Add(show);
            }
            else
            {
                Show dbEntry = context.Shows.Find(show.ShowId);
                if (dbEntry != null)
                {
                    dbEntry.MovieId = show.MovieId;
                    dbEntry.RoomId = show.RoomId;
                    dbEntry.Subtitle = show.Subtitle;
                    dbEntry.StartingTime = show.StartingTime;
                    dbEntry.ThreeDimensional = show.ThreeDimensional;
                }
            }
            context.SaveChanges();
        }
    }
}

