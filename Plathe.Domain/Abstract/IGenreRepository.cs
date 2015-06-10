using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author: Mieke

namespace Plathe.Domain.Abstract
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Genres { get; }
        int getGenreIdByName(string name);
    }
}
