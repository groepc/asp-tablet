﻿using System.Collections.Generic;
using System.Linq;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfGenreRepository : IGenreRepository
    {
        private EfDbContext _context = new EfDbContext();

        public IEnumerable<Genre> Genres
        {
            get { return _context.Genres; }
        }

        public int GetGenreIdByName(string genreId)
        {
            var genre = _context.Genres.FirstOrDefault(a => a.Name == genreId);
            return genre.GenreId;
        }
    }
}

