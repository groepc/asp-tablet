using System.Collections.Generic;
using Plathe.Domain.Entities;

//Author: Mieke

namespace Plathe.Domain.Abstract
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Genres { get; }
        int GetGenreIdByName(string name);
    }
}
