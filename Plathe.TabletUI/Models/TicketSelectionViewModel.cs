using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.TabletUI.Models
{
    public class TicketSelectionViewModel
    {
        private IShowService service;

        public TicketSelectionViewModel()
        {
            service = DependencyResolver.Current.GetService<IShowService>();
        }

        public Show Show
        {
           get { return service.GetShowById(ShowId); }
        }

        [HiddenInput(DisplayValue = false)]
        public int ShowId { get; set; }

        [Range(0, 5)]
        public int AmountAdults { get; set; }

        [Range(0, 5)]
        public int AmountAdultsPlus { get; set; }

        [Range(0, 5)]
        public int AmountChildren { get; set; }

        [Range(0, 5)]
        public int AmountPopcorn { get; set; }

        [Range(1, 25)]
        public int TotalAmount
        {
            get { return AmountAdults + AmountAdultsPlus + AmountChildren + AmountPopcorn; }
        }

    }
}