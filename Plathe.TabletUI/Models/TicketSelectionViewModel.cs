using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;

namespace Plathe.TabletUI.Models
{
    public class TicketSelectionViewModel
    {
        private IShowService service;

        public TicketSelectionViewModel()
        {
            this.service = DependencyResolver.Current.GetService<IShowService>();
        }

        public Show Show
        {
           get { return service.getShowById(ShowId); }
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
            get { return this.AmountAdults + this.AmountAdultsPlus + this.AmountChildren + this.AmountPopcorn; }
        }

    }
}