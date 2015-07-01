using System;
using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Abstract
{
    public interface IMovieRepository
    {
       IEnumerable<Movie> Movies { get; }
       IEnumerable<Movie> GetMovieByGenreId(int genreId);
    }
}
