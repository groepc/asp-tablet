using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Plathe.Domain.Entities;
using Plathe.Domain.AbstractServices;

namespace Plathe.WebUI.Models
{

    public class ShowViewModel
    {
        public IEnumerable<Show> Shows { get; set; }

        private readonly IShowService _service;
        private readonly IMovieService _movieService;
        private readonly IRoomService _roomService;

        public ShowViewModel()
        {
            _service = DependencyResolver.Current.GetService<IShowService>();
            _movieService = DependencyResolver.Current.GetService<IMovieService>();
            _roomService = DependencyResolver.Current.GetService<IRoomService>();
        }

        public Show Show
        {
            get { return _service.GetShowById(ShowId); }
        }

        [Display(Name = "Ondertiteling")]
        public string Subtitle { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Start tijd")]
        public DateTime StartingTime { get; set; }

        public Boolean ThreeDimensional { get; set; }

        public int MovieId { get; set; }
        public int RoomId { get; set; }

        public IEnumerable<Movie> Movies
        {
            get { return _movieService.GetAllMovies(); }
        }

        public IEnumerable<Room> Rooms
        {
            get { return _roomService.GetAllRooms(); }
        }

        [HiddenInput(DisplayValue = false)]
        public int ShowId { get; set; }
    }
}