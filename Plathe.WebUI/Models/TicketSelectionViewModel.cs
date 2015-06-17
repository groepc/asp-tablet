using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Models
{
    public class TicketSelectionViewModel
    {
        private IShowRepository _repository;

        public TicketSelectionViewModel()
        {
            _repository = DependencyResolver.Current.GetService<IShowRepository>();
        }

        public Show Show { 
            get 
            {

                return _repository.Shows.First(model => model.ShowId == ShowId);
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
        public int AmountVip { get; set; }

        [Range(1, 36)]
        public int TotalAmount
        {
            get { return AmountAdults + AmountAdultsPlus + AmountChildren +  AmountStudents + AmountPopcorn + AmountVip; }
        }

    }
}