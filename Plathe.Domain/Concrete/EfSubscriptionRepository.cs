using System;
using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfSubscriptionRepository : ISubscriptionRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Subscription> Subscriptions
        {
            get { return _context.Subscriptions; }
        }

        public Boolean AddSubscription(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            var succesful = _context.SaveChanges();
            return succesful > 0;
        }

        public Subscription GetSubscriptionById(int id)
        {
            return _context.Subscriptions.Find(id);
        }

    }
}
