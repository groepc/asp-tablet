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
        private EFDbContext db = new EFDbContext();

        public GenreService(IGenreRepository genreRepository)
        {
            // todo: make use of repository (but doesn't have Add method..)
            this.repository = genreRepository;
        }

        public int findIdGenreByName(string genreString)
        {
            return 1;
        }
    }
}
