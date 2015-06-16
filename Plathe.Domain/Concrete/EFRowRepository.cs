using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Concrete
{
    public class EfRowRepository : IRowRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Row> Rows
        {
            get { return context.Rows; }
        }
    }
}
