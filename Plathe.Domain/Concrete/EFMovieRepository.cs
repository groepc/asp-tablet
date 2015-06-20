using System.Collections.Generic;
using System.Linq;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfMovieRepository : IMovieRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Movie> Movies
        {
            get { return context.Movies; }
        }

        public IEnumerable<Movie> GetMovieByGenreId(int genreId)
        {
            return context.Movies.Where(m => m.GenreId == genreId);
        }
    }
}
