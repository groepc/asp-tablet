using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.WebUI.Models
{
    public class SeatSelectionViewModel
    {
        public Show Show { get; set; }

        public TicketSelectionViewModel TicketSelectionViewModel { get; set; }

    }
}