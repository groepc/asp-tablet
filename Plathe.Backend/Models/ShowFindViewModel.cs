using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Backend.Models
{
    public class ShowFindViewModel
    {
        private readonly IShowService _service;

        public ShowFindViewModel()
        {
            _service = DependencyResolver.Current.GetService<IShowService>();
        }

        public IEnumerable<Show> Shows
        {
            get { return _service.GetShowsByDate(StartTime); }
        }

        public DateTime StartTime;
    }
}