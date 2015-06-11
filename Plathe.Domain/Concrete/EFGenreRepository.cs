﻿using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Concrete
{
    public class EFGenreRepository : IGenreRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Genre> Genres
        {
            get { return context.Genres; }
        }

        public int getGenreIdByName(string genreID)
        {
            var genre = context.Genres.FirstOrDefault(a => a.Name == genreID);

            return genre.GenreID;
        }
    }
}
