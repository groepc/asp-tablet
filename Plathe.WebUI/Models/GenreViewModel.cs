using Plathe.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.WebUI.Models
{
    public class GenreViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public string CurrentGenre { get; set; }

    }
}