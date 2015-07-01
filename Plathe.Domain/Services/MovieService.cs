using System;
using System.Collections.Generic;
using System.Linq;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IGenreRepository _repositoryGenre;
        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _repository = movieRepository;
            _repositoryGenre = genreRepository;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _repository.Movies;
        }

        public IEnumerable<Movie> GetMoviesByGenreName(string name)
        {
            var genreId = _repositoryGenre.GetGenreIdByName(name);
            return _repository.GetMovieByGenreId(genreId);
        }
        
        public Movie GetMovieById(int id)
        {        
            return _repository.Movies.FirstOrDefault(model => model.MovieId == id);
        }
    }
}