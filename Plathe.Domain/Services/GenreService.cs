using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions;

namespace Plathe.Domain.Services
{
    public class GenreService : IGenreService
    {

        private IGenreRepository repository;

        public GenreService(IGenreRepository genreRepository)
        {
            repository = genreRepository;
        }

       public IEnumerable<Genre> GetAllGenres()
        {
            return repository.Genres;
        }

    }
}
