using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Services
{
    public class GenreService : IGenreService
    {

        private IGenreRepository _repository;

        public GenreService(IGenreRepository genreRepository)
        {
            _repository = genreRepository;
        }

       public IEnumerable<Genre> GetAllGenres()
        {
            return _repository.Genres;
        }

    }
}
