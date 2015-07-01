using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Backend.Models
{
    public class SalesViewModel
    {

        
        [Range(0, 6)]
        public int AmountBioscoop { get; set; }

        [Range(0, 6)]
        public int AmountRideCard { get; set; }
    }
}