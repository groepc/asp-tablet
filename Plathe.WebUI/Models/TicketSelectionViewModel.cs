using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.WebUI.Models
{
    public class TicketSelectionViewModel
    {
        private IShowRepository repository;

        public TicketSelectionViewModel()
        {
            this.repository = DependencyResolver.Current.GetService<IShowRepository>();
        }

        public Show Show { 
            get 
            {

                return repository.Shows.Where(model => model.ShowId == this.ShowId).First();
            }
        }

        [HiddenInput(DisplayValue = false)]
        public int ShowId { get; set; }
        
        [Range(0, 6)]
        public int AmountAdults { get; set; }

        [Range(0, 6)]
        public int AmountAdultsPlus { get; set; }

        [Range(0, 6)]
        public int AmountChildren { get; set; }

        [Range(0, 6)]
        public int AmountStudents { get; set; }

        [Range(0, 6)]
        public int AmountPopcorn { get; set; }

        //VIP-kaartje
        [Range(0, 6)]
        public int AmountVIP { get; set; }

        [Range(1, 36)]
        public int TotalAmount
        {
            get { return this.AmountAdults + this.AmountAdultsPlus + this.AmountChildren +  this.AmountStudents + this.AmountPopcorn + this.AmountVIP; }
        }

    }
}