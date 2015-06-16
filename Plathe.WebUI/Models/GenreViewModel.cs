using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Models
{
    public class GenreViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public string CurrentGenre { get; set; }

    }
}