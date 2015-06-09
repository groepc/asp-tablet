using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plathe.Domain.Abstract;

namespace Plathe.Domain.Services
{
    public class MovieService : IMovieService
    {
        private IMovieRepository repository;
        public MovieService(IMovieRepository movieRepository)
        {
            this.repository = movieRepository;
        }

        public IEnumerable<Movie> getAllMovies()
        {
            return this.repository.Movies;
        }
    }
}