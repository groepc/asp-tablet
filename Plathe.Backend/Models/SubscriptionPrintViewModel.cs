using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Backend.Models
{
    public class SubscriptionPrintViewModel
    {
        private readonly ISubscriptionService _service;

        public SubscriptionPrintViewModel()
        {
            _service = DependencyResolver.Current.GetService<ISubscriptionService>();
        }

        public Subscription Subscription
        {
            get { return _service.GetSubscriptionById(SubscriptionId); }
        }

        public int SubscriptionId;
    }
}