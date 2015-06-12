﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
