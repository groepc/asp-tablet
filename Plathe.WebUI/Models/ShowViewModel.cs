using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plathe.WebUI.Models
{
    public class ShowViewModel
    {
        public IEnumerable<Show> Shows { get; set; }

    }
}