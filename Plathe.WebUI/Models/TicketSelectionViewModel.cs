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
        public int ShowId { get; set; } 
        public Movie Movie { get; set; }
        public Boolean Error { get; set; }
        public String ErrorMessage { get; set; }

    }
}