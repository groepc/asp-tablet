using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfRowRepository : IRowRepository
    {
        private EfDbContext _context = new EfDbContext();

        public IEnumerable<Row> Rows
        {
            get { return _context.Rows; }
        }
    }
}
