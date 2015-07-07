using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfShowRepository : IShowRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Show> Shows
        {
            get { return _context.Shows; }
        }

        public void AddShow(Show show)
        {
            _context.Shows.Add(show);
            _context.SaveChanges();
        }

        public void UpdateShow(Show show)
        {
            _context.Entry(show);
            _context.SaveChanges();
        }

        public void RemoveShowById(int id)
        {
            Show show = _context.Shows.Find(id);
            _context.Shows.Remove(show);
            _context.SaveChanges();
        }
    }
}
