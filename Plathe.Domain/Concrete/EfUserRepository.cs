using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    class EfUserRepository
    {
        private EfDbContext _context = new EfDbContext();

        public IEnumerable<User> Users
        {
            get { return _context.Users; }
        }
    }
}
