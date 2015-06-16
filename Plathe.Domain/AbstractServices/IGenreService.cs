using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.AbstractServices
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
        
    }
}
