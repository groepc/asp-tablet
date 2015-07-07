﻿using System;
using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.AbstractServices
{
    public interface IShowService
    {

        IEnumerable<Show> GetAllShows();

        IEnumerable<Show> GetShowsByDate(DateTime date);

        IEnumerable<Show> GetShowsThisWeek();

        IEnumerable<Show> GetShowsByMovieId(int id);

        Show GetShowById(int id);

        Show GetShowByMovieId(int id);

        int SaveShow(int? showId, int movieId, int roomId, string subtitle, DateTime startingTime,
            Boolean threeDimensional);

        void RemoveShowById(int id);
    }
}