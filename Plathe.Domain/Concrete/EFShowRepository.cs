using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfShowRepository : IShowRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Show> Shows
        {
            get { return context.Shows; }
        }
    }
}
