using System;
using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.AbstractServices
{
    public interface ISubscriptionService
    {
        IEnumerable<Subscription> GetAllSubscriptions();
        Boolean SaveSubscription(string name, DateTime startDate, DateTime endDate);
        Subscription GetSubscriptionById(int id);
    }
}
