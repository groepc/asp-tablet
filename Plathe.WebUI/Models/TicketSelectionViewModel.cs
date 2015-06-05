using Plathe.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.WebUI.Models
{
    public class TicketSelectionViewModel
    {

        public Show Show { get; set; }

        public int ShowId { get; set; }
        public int AmountAdults { get; set; }
        public int AmountAdultsPlus { get; set; }
        public int AmountChildren { get; set; }
        public int AmountPopcorn { get; set; }

    }
}