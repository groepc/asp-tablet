using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Backend.Models
{
    public class ShowListViewModel
    {
         private readonly IShowService _service;

        public ShowListViewModel()
        {
            _service = DependencyResolver.Current.GetService<IShowService>();
        }

        public IEnumerable<Show> Shows
        {
            get { return _service.GetAllShows(); }
        }

        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Display(Name = "Zaal")]
        public string RoomName { get; set; }

        [Display(Name = "Ondertiteling")]
        public string Subtitle { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start tijd")]
        public DateTime StartingTime { get; set; }

        public Boolean ThreeDimensional { get; set; }
    }
}