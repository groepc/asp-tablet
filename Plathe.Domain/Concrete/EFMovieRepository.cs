using System;
using System.Collections.Generic;
using System.Linq;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfMovieRepository : IMovieRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Movie> Movies
        {
            get { return _context.Movies; }
        }

        public Movie FindMovieById(int id)
        {
            return _context.Movies.Find(id);
        }

        public IEnumerable<Movie> GetMovieByGenreId(int genreId)
        {
            return _context.Movies.Where(m => m.GenreId == genreId);
        }
    }
}
