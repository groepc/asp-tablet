using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Plathe.Domain.Concrete
{
    public class EFMovieRepository : IMovieRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Movie> Movies
        {
            get { return context.Movies; }
        }

        public IEnumerable<Movie> getMovieByGenreId(int genreID)
        {
            return context.Movies.Where(m => m.GenreID == genreID);
        }
    }
}
