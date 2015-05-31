using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Concrete
{
    public class EFRowRepository : IRowRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Row> Rows
        {
            get { return context.Rows; }
        }
    }
}
