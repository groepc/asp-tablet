using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plathe.Domain.Entities;

namespace Plathe.Domain.AbstractServices
{
    public interface IMovieService
    {
        IEnumerable<Movie> getAllMovies();
    }
}