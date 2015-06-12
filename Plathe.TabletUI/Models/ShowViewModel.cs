using Plathe.Domain.Entities;
using Plathe.Domain.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;

namespace Plathe.TabletUI.Models
{
    public class ShowViewModel
    {
        public IShowService service;

        public ShowViewModel()
        {
            this.service = DependencyResolver.Current.GetService<IShowService>();
        }
        public IEnumerable<Show> Shows
        {
            get { return service.GetAllShows(); }
        }

        public Show Show
        {
            get { return service.GetShowById(ShowId); }
        }

        [HiddenInput(DisplayValue = false)]
        public int ShowId { get; set; }
    }
}