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
        private IGenreRepository repositoryGenre;
        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            this.repository = movieRepository;
            this.repositoryGenre = genreRepository;
        }

        public IEnumerable<Movie> getAllMovies()
        {
            return this.repository.Movies;
        }

        public IEnumerable<Movie> getMoviesByGenreName(string name)
        {
            var genreID = this.repositoryGenre.getGenreIdByName(name);
            return this.repository.getMovieByGenreId(genreID);
        }
        public Movie getMovieById(int id)
        {
            return repository.Movies.FirstOrDefault(model => model.MovieID == id);
        }
    }
}