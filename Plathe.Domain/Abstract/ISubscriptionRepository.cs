using System;
using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Abstract
{
    public interface ISubscriptionRepository
    {
        IEnumerable<Subscription> Subscriptions { get; }
        Boolean AddSubscription(Subscription subscription);

        Subscription GetSubscriptionById(int id);
    }
}
