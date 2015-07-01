using System.Collections.Generic;
using System.Linq;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Services
{
    public class MovieService : IMovieService
    {
        private IMovieRepository repository;
        private IGenreRepository repositoryGenre;

        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            this.repository = movieRepository;
            this.repositoryGenre = genreRepository;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return this.repository.Movies;
        }

        public IEnumerable<Movie> GetMoviesByGenreName(string name)
        {
            var genreId = this.repositoryGenre.GetGenreIdByName(name);
            return this.repository.GetMovieByGenreId(genreId);
        }
        
        public Movie GetMovieById(int id)
        {        
            return repository.Movies.FirstOrDefault(model => model.MovieId == id);
        }
    }
}