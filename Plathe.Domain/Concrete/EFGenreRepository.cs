using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Concrete
{
    public class EfGenreRepository : IGenreRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Genre> Genres
        {
            get { return context.Genres; }
        }

        public int GetGenreIdByName(string genreId)
        {
            var genre = context.Genres.FirstOrDefault(a => a.Name == genreId);

            return genre.GenreId;
        }
    }
}

