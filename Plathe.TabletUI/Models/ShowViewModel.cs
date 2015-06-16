using System.Collections.Generic;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.TabletUI.Models
{
    public class ShowViewModel
    {
        public IShowService service;

        public ShowViewModel()
        {
            service = DependencyResolver.Current.GetService<IShowService>();
        }
        public IEnumerable<Show> Shows
        {
            get { return service.GetShowsThisWeek(); }
        }

        public Show Show
        {
            get { return service.GetShowById(ShowId); }
        }

        [HiddenInput(DisplayValue = false)]
        public int ShowId { get; set; }
    }
}