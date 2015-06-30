using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Backend.Models
{
    public class SubscriptionCreateViewModel
    {

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PaymentType { get; set; }
    }
}