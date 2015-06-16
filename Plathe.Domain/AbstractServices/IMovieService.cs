using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.AbstractServices
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        IEnumerable<Movie> GetMoviesByGenreName(string name);
        Movie GetMovieById(int id);
    }
}