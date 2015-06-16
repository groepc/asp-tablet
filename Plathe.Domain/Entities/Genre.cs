using System.Collections.Generic;

//Author: Mieke

namespace Plathe.Domain.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
