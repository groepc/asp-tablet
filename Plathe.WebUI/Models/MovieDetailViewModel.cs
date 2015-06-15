using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plathe.UnitTest.Models
{
    public class MovieDetailViewModel
    {
        public Movie movie { get; set; }
        public IEnumerable<Show> showsForMovie { get; set; }
    }
}