using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Plathe.Domain.Entities;

namespace Plathe.Backend.Models
{
    public class ShowViewModel
    {
        public Show Show;

        [Display(Name = "Ondertiteling")]
        public string Subtitle { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:ddMMyyyy HHmm}")]
        [Display(Name = "Start tijd")]
        public DateTime StartingTime { get; set; }

        public Boolean ThreeDimensional { get; set; }

        public int MovieId { get; set; }

        public int RoomId { get; set; }

        public IEnumerable<Movie> Movies;

        public IEnumerable<Room> Rooms;

        [HiddenInput(DisplayValue = false)]
        public int ShowId { get; set; }

    }
}