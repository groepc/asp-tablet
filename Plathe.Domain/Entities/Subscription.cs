using System;

namespace Plathe.Domain.Entities
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string SubscriptionNumber { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
