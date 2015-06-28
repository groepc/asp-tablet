using System.Collections.Generic;
using System.Web.Mvc;

//Author: Mieke

namespace Plathe.Domain.Entities
{
    public class Genre
    {
        [HiddenInput(DisplayValue = true)]
        public int GenreId { get; set; }
        
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
