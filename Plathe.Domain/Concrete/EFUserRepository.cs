using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    class EfUserRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<User> Users
        {
            get { return _context.Users; }
        }
    }
}