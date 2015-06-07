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
    public class MovieService : IMovieService
    {
        private IMovieRepository repository;
        //private EFDbContext db = new EFDbContext();

        public MovieService(IMovieRepository movieRepository)
        {
            // todo: make use of repository (but doesn't have Add method..)
            this.repository = movieRepository;
        }

        public Movie showMovie()
        {
            return null;
        }
    }
}
