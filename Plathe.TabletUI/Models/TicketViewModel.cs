using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.TabletUI.Models
{
    public class TicketViewModel
    {

        private readonly ITicketService _service;


        public TicketViewModel()
        {
            _service = DependencyResolver.Current.GetService<ITicketService>();
        }

        public IEnumerable<Ticket> Tickets
        {
            get { return _service.GetTicketsByReservationId(ReservationId).ToList(); }
        }
        [HiddenInput(DisplayValue = false)]
        public int ReservationId { get; set; }
    }
}