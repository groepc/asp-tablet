﻿using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.AbstractServices
{
    public interface IShowService
    {

        IEnumerable<Show> getAllShows();

        IEnumerable<Show> getShowsThisWeek();

        IEnumerable<Show> getShowsByMovieId(int id);
        
        Show getShowById(int id);
    }
}