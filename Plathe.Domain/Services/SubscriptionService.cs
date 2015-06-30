using System;
using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.Domain.Extensions;

namespace Plathe.Domain.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _repository = subscriptionRepository;
        }

        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return _repository.Subscriptions;
        }

        public Boolean SaveSubscription(string name, DateTime startDate, DateTime endDate)
        {
            Subscription subscription = new Subscription{
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                SubscriptionNumber = "".CreateRandomString()
                };
            return _repository.AddSubscription(subscription);
        }

        public Subscription GetSubscriptionById(int id)
        {
            return _repository.GetSubscriptionById(id);
        }
    }
}
