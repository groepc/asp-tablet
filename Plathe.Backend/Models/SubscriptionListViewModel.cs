using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Backend.Models
{
    public class SubscriptionListViewModel
    {
        private readonly ISubscriptionService _service;

        public SubscriptionListViewModel()
        {
            _service = DependencyResolver.Current.GetService<ISubscriptionService>();
        }

        public IEnumerable<Subscription> Subscriptions
        {
            get { return _service.GetAllSubscriptions(); }
        }
    }
}